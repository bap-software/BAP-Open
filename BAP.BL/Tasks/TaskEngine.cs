// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="TaskEngine.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Web.Mvc;
using System.Reflection;
using System.Collections.Generic;

using NCrontab;
using Hangfire;

using BAP.Log;
using BAP.DAL;
using BAP.Common;
using BAP.DAL.Entities;

namespace BAP.BL.Tasks
{
    /// <summary>
    /// Class TaskEngine.
    /// Implements the <see cref="BAP.Common.BAPBaseClassWithLogging" />
    /// </summary>
    /// <seealso cref="BAP.Common.BAPBaseClassWithLogging" />
    public class TaskEngine : BAPBaseClassWithLogging
    {
        /// <summary>
        /// The configuration helper
        /// </summary>
        private readonly IConfigHelper _configHelper;
        /// <summary>
        /// The authentication helper
        /// </summary>
        private readonly IAuthorizationContext _authHelper;
        /// <summary>
        /// The scheduled task bl
        /// </summary>
        private readonly IScheduledTaskBL _scheduledTaskBL;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskEngine"/> class.
        /// </summary>
        public TaskEngine()
            : base(DependencyResolver.Current.GetService<ILogger>())
        {
            _configHelper = DependencyResolver.Current.GetService<IConfigHelper>();
            _authHelper = DependencyResolver.Current.GetService<IAuthorizationContext>();            
            _scheduledTaskBL = new BusinessLayer(_configHelper, _authHelper, _logger);
        }

        /// <summary>
        /// Gets all future tasks.
        /// </summary>
        /// <returns>IEnumerable&lt;ScheduledTask&gt;.</returns>
        public IEnumerable<ScheduledTask> GetAllFutureTasks()
        {
            if (!_authHelper.IsAuthenticated && !_authHelper.LoginBuiltInUser(_configHelper.BuiltInJobUser))
            {
                LogError($"Trying to get list of jobs and could not authenticate built-in job running user.");
                return null;
            }
            
            var result = _scheduledTaskBL.GetAllScheduledTasks()
            .Where(x => x.Enabled && (x.Recurring || x.LastRun == null));
            _authHelper.LogoffBuiltInUser();
            return result;            
        }

        /// <summary>
        /// Adds the task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns>System.String.</returns>
        public string AddTask(ScheduledTask task)
        {
            if (task.Recurring)
            {
                if(string.IsNullOrEmpty(task.UniqueId))
                    task.UniqueId = Guid.NewGuid().ToString();
                RecurringJob.AddOrUpdate(task.UniqueId, () => ExecuteTask(task), task.Interval);
                return task.UniqueId;
            }
            else
            {
                if (task.NextRun.HasValue && task.NextRun > DateTime.Now.AddSeconds(15))
                {
                    return BackgroundJob.Schedule(() => ExecuteTask(task), new DateTimeOffset(task.NextRun.Value));
                }                    
                else
                {
                    return BackgroundJob.Enqueue(() => ExecuteTask(task));
                }
            }
        }

        /// <summary>
        /// Removes the task.
        /// </summary>
        /// <param name="task">The task.</param>
        public void RemoveTask(ScheduledTask task)
        {
            if (task == null || string.IsNullOrEmpty(task.UniqueId))
                return;

            if (task.Recurring)
            {
                RecurringJob.RemoveIfExists(task.UniqueId);
            }
            else
            {
                BackgroundJob.Delete(task.UniqueId);
            }
        }

        /// <summary>
        /// Gets the task custom data json example.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns>System.String.</returns>
        public string GetTaskCustomDataJsonExample(ScheduledTask task)
        {
            string result = null;
            if (task == null || string.IsNullOrEmpty(task.JobAssembly) || string.IsNullOrEmpty(task.JobClass))
                return result;

            var assembly = Assembly.Load(task.JobAssembly);
            if (assembly != null)
            {
                var type = assembly.GetType(task.JobClass);
                if (type != null && typeof(IBAPScheduledTask).IsAssignableFrom(type))
                {
                    IBAPScheduledTask taskInstance = (IBAPScheduledTask)Activator.CreateInstance(type);
                    result = taskInstance.CustomDataJsonExample;
                }
            }

            return result;
        }

        /// <summary>
        /// Executes the task.
        /// </summary>
        /// <param name="task">The task.</param>
        public void ExecuteTask(ScheduledTask task)
        {          
            //Local variables
            var success = true;
            var message = string.Empty;

            //Validation
            if (task == null || string.IsNullOrEmpty(task.JobAssembly) || string.IsNullOrEmpty(task.JobClass))
            {
                var name = task != null ? task.Name : "Unknown";
                LogError($"Trying to run schedulued task '{name}' with invalid parameters.");
                return;
            }

            if (!_authHelper.IsAuthenticated && !_authHelper.LoginBuiltInUser(_configHelper.BuiltInJobUser))
            {
                LogError($"Trying to run job '{task.Name}' and could not authenticate built-in job running user.");
                return;
            }

            var allTasks = _scheduledTaskBL.GetAllScheduledTasks().ToList();
            var currentTask = _scheduledTaskBL.GetAllScheduledTasks()
                .SingleOrDefault(x => x.Id == task.Id);

            if (currentTask == null)
            {
                _authHelper.LogoffBuiltInUser();
                LogError($"Trying to run job '{task.Name}' which does not exist in DB");
                return;
            }

            if (!currentTask.Enabled)
            {
                _authHelper.LogoffBuiltInUser();
                LogError($"Trying to run job '{task.Name}' which is disabled.");
                return;
            }

            if (currentTask.Running)
            {
                _authHelper.LogoffBuiltInUser();
                LogError($"Trying to run job '{task.Name}' which is already running.");
                return;
            }
            
            //Try to run task
            try
            {
                currentTask.Running = true;
                _scheduledTaskBL.UpdateScheduledTask();

                var assembly = Assembly.Load(task.JobAssembly);
                if (assembly != null)
                {
                    var type = assembly.GetType(task.JobClass);
                    if (type != null && typeof(IBAPScheduledTask).IsAssignableFrom(type))
                    {
                        IBAPScheduledTask taskInstance = (IBAPScheduledTask)Activator.CreateInstance(type);
                        var result = taskInstance.RunTask(task);                        
                        success = result.Success;
                        message = result.Message;

                        LogDebug($"Executed task {task.Name} using this data '{task.JobData}', got Success={success}, with message='{message}'.");
                    }
                    else
                    {
                        LogError($"Unable to find executor class {task.JobClass} for the given task {task.Name}.");
                    }
                }
                else
                {
                    LogError($"Unable to find assembly {task.JobAssembly} for the given task {task.Name}.");
                }
            }
            catch (Exception ex)
            {
                success = false;
                message = $"Running scheduled task '{task.Name}' failed with error: '{ex.Message}'";
                LogException(ex);
            }

            //Update results about run
            try
            {
                var now = DateTime.Now;                
                if (task.Recurring)
                {
                    if (success)
                    {
                        var schedule = CrontabSchedule.Parse(task.Interval);
                        currentTask.NextRun = schedule.GetNextOccurrence(now);                        
                    }
                }
                else
                {
                    currentTask.Enabled = false;                    
                }

                currentTask.Executions++;
                currentTask.LastRun = now;
                currentTask.LastResult = success;
                currentTask.LastMessage = message;
                currentTask.Running = false;
                currentTask.LastModifiedDate = now;                
                _scheduledTaskBL.UpdateScheduledTask(currentTask);
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
            finally
            {
                LogDebug($"Task '{task.Name}' finished to run with result '{success}' and message: '{message}'.");
                _authHelper.LogoffBuiltInUser();
            }
        }
    }
}