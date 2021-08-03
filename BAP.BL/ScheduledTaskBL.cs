// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 05-20-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ScheduledTaskBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;
using System.Collections.Generic;

using PagedList;

using BAP.Common;
using BAP.BL.Tasks;
using BAP.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace BAP.BL
{
    /// <summary>
    /// Interface IScheduledTaskBL
    /// </summary>
    public interface IScheduledTaskBL
    {
        /// <summary>
        /// Gets all scheduled tasks.
        /// </summary>
        /// <returns>IList&lt;ScheduledTask&gt;.</returns>
        IList<ScheduledTask> GetAllScheduledTasks();
        /// <summary>
        /// Gets all scheduled tasks asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;ScheduledTask&gt;&gt;.</returns>
        Task<IList<ScheduledTask>> GetAllScheduledTasksAsync();

        /// <summary>
        /// Searches the scheduled tasks.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ScheduledTask&gt;.</returns>
        IPagedList<ScheduledTask> SearchScheduledTasks(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the scheduled tasks asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;ScheduledTask&gt;&gt;.</returns>
        Task<IPagedList<ScheduledTask>> SearchScheduledTasksAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the scheduled task by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ScheduledTask.</returns>
        ScheduledTask GetScheduledTaskById(int id);
        /// <summary>
        /// Gets the scheduled task by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ScheduledTask&gt;.</returns>
        Task<ScheduledTask> GetScheduledTaskByIdAsync(int id);

        /// <summary>
        /// Gets the scheduled task by name.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ScheduledTask.</returns>
        ScheduledTask GetScheduledTaskByName(string name);
        /// <summary>
        /// Gets the scheduled task by name asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Task&lt;ScheduledTask&gt;.</returns>
        Task<ScheduledTask> GetScheduledTaskByNameAsync(string name);

        /// <summary>
        /// Adds the scheduled task.
        /// </summary>
        /// <param name="scheduledTasks">The scheduled tasks.</param>
        void AddScheduledTask(params ScheduledTask[] scheduledTasks);
        /// <summary>
        /// Adds the scheduled task asynchronous.
        /// </summary>
        /// <param name="scheduledTasks">The scheduled tasks.</param>
        /// <returns>Task.</returns>
        Task AddScheduledTaskAsync(params ScheduledTask[] scheduledTasks);

        /// <summary>
        /// Updates the scheduled task.
        /// </summary>
        /// <param name="scheduledTasks">The scheduled tasks.</param>
        void UpdateScheduledTask(params ScheduledTask[] scheduledTasks);
        /// <summary>
        /// Updates the scheduled task asynchronous.
        /// </summary>
        /// <param name="scheduledTasks">The scheduled tasks.</param>
        /// <returns>Task.</returns>
        Task UpdateScheduledTaskAsync(params ScheduledTask[] scheduledTasks);

        /// <summary>
        /// Removes the scheduled task.
        /// </summary>
        /// <param name="scheduledTasks">The scheduled tasks.</param>
        void RemoveScheduledTask(params ScheduledTask[] scheduledTasks);
        /// <summary>
        /// Removes the scheduled task asynchronous.
        /// </summary>
        /// <param name="scheduledTasks">The scheduled tasks.</param>
        /// <returns>Task.</returns>
        Task RemoveScheduledTaskAsync(params ScheduledTask[] scheduledTasks);
    }

    /// <summary>
    /// Class BusinessLayer.
    /// Implements the <see cref="BAP.BL.ISubscriberBL" />
    /// Implements the <see cref="BAP.BL.IDocumentTemplateBL" />
    /// Implements the <see cref="BAP.BL.IContentControlParameterBL" />
    /// Implements the <see cref="BAP.BL.IBlogAuthorBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.BlogAuthor}" />
    /// Implements the <see cref="BAP.BL.IBlogCommentUserBL" />
    /// Implements the <see cref="BAP.BL.IAttachmentHistBL" />
    /// Implements the <see cref="BAP.BL.IStateBL" />
    /// Implements the <see cref="BAP.BL.IOrganizationUserBL" />
    /// Implements the <see cref="BAP.BL.ISubscriptionBL" />
    /// Implements the <see cref="BAP.BL.IModuleBL" />
    /// Implements the <see cref="BAP.BL.IMessageBL" />
    /// Implements the <see cref="BAP.BL.IContentViewControlBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.ContentViewControl}" />
    /// Implements the <see cref="BAP.BL.IEventLogBL" />
    /// Implements the <see cref="BAP.BL.INewsLetterBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.NewsLetter}" />
    /// Implements the <see cref="BAP.BL.ILocalizationBL" />
    /// Implements the <see cref="BAP.BL.IWorkflowStageTransitionBL" />
    /// Implements the <see cref="BAP.BL.IScheduledTaskBL" />
    /// Implements the <see cref="BAP.BL.ILookupBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.Lookup}" />
    /// Implements the <see cref="BAP.BL.IWorkflowClassBL" />
    /// Implements the <see cref="BAP.BL.ICustomConfigurationBL" />
    /// Implements the <see cref="BAP.BL.ILookupValueBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.LookupValue}" />
    /// Implements the <see cref="System.IDisposable" />
    /// Implements the <see cref="BAP.BL.IBlogPostBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.BlogPost}" />
    /// Implements the <see cref="BAP.BL.ICurrencyBL" />
    /// Implements the <see cref="BAP.BL.IContentControlBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.ContentControl}" />
    /// Implements the <see cref="BAP.BL.IAttachmentBL" />
    /// Implements the <see cref="BAP.BL.IWorkflowObjectBL" />
    /// Implements the <see cref="BAP.BL.IContentNodeRouteBL" />
    /// Implements the <see cref="BAP.BL.IOrganizationBL" />
    /// Implements the <see cref="BAP.BL.IBlogBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.Blog}" />
    /// Implements the <see cref="BAP.BL.IWorkflowActionBL" />
    /// Implements the <see cref="BAP.BL.IWorkflowActionAttributeBL" />
    /// Implements the <see cref="BAP.BL.IStagingEntityBL" />
    /// Implements the <see cref="BAP.BL.IContentNodeBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.ContentNode}" />
    /// Implements the <see cref="BAP.BL.IWorkflowStageBL" />
    /// Implements the <see cref="BAP.BL.IOrganizationServiceBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.OrganizationService}" />
    /// Implements the <see cref="BAP.BL.ICountryBL" />
    /// Implements the <see cref="BAP.BL.IBlogCommentBL" />
    /// Implements the <see cref="BAP.BL.IContentViewBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.ContentView}" />
    /// Implements the <see cref="BAP.BL.IContentControlTypeBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.ContentControlType}" />
    /// Implements the <see cref="BAP.BL.IContentLocalizationBL" />
    /// </summary>
    /// <seealso cref="BAP.BL.ISubscriberBL" />
    /// <seealso cref="BAP.BL.IDocumentTemplateBL" />
    /// <seealso cref="BAP.BL.IContentControlParameterBL" />
    /// <seealso cref="BAP.BL.IBlogAuthorBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.BlogAuthor}" />
    /// <seealso cref="BAP.BL.IBlogCommentUserBL" />
    /// <seealso cref="BAP.BL.IAttachmentHistBL" />
    /// <seealso cref="BAP.BL.IStateBL" />
    /// <seealso cref="BAP.BL.IOrganizationUserBL" />
    /// <seealso cref="BAP.BL.ISubscriptionBL" />
    /// <seealso cref="BAP.BL.IModuleBL" />
    /// <seealso cref="BAP.BL.IMessageBL" />
    /// <seealso cref="BAP.BL.IContentViewControlBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.ContentViewControl}" />
    /// <seealso cref="BAP.BL.IEventLogBL" />
    /// <seealso cref="BAP.BL.INewsLetterBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.NewsLetter}" />
    /// <seealso cref="BAP.BL.ILocalizationBL" />
    /// <seealso cref="BAP.BL.IWorkflowStageTransitionBL" />
    /// <seealso cref="BAP.BL.IScheduledTaskBL" />
    /// <seealso cref="BAP.BL.ILookupBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.Lookup}" />
    /// <seealso cref="BAP.BL.IWorkflowClassBL" />
    /// <seealso cref="BAP.BL.ICustomConfigurationBL" />
    /// <seealso cref="BAP.BL.ILookupValueBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.LookupValue}" />
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="BAP.BL.IBlogPostBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.BlogPost}" />
    /// <seealso cref="BAP.BL.ICurrencyBL" />
    /// <seealso cref="BAP.BL.IContentControlBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.ContentControl}" />
    /// <seealso cref="BAP.BL.IAttachmentBL" />
    /// <seealso cref="BAP.BL.IWorkflowObjectBL" />
    /// <seealso cref="BAP.BL.IContentNodeRouteBL" />
    /// <seealso cref="BAP.BL.IOrganizationBL" />
    /// <seealso cref="BAP.BL.IBlogBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.Blog}" />
    /// <seealso cref="BAP.BL.IWorkflowActionBL" />
    /// <seealso cref="BAP.BL.IWorkflowActionAttributeBL" />
    /// <seealso cref="BAP.BL.IStagingEntityBL" />
    /// <seealso cref="BAP.BL.IContentNodeBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.ContentNode}" />
    /// <seealso cref="BAP.BL.IWorkflowStageBL" />
    /// <seealso cref="BAP.BL.IOrganizationServiceBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.OrganizationService}" />
    /// <seealso cref="BAP.BL.ICountryBL" />
    /// <seealso cref="BAP.BL.IBlogCommentBL" />
    /// <seealso cref="BAP.BL.IContentViewBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.ContentView}" />
    /// <seealso cref="BAP.BL.IContentControlTypeBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.ContentControlType}" />
    /// <seealso cref="BAP.BL.IContentLocalizationBL" />
    public partial class BusinessLayer : IScheduledTaskBL
    {
        #region scheduledTasks

        /// <summary>
        /// Gets all scheduled tasks.
        /// </summary>
        /// <returns>IList&lt;ScheduledTask&gt;.</returns>
        public IList<ScheduledTask> GetAllScheduledTasks()
        {
            return _unitOfWork.ScheduledTaskRepository.GetAll();
        }

        /// <summary>
        /// get all scheduled tasks as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;ScheduledTask&gt;.</returns>
        public async Task<IList<ScheduledTask>> GetAllScheduledTasksAsync()
        {
            return await _unitOfWork.ScheduledTaskRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the scheduled tasks.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ScheduledTask&gt;.</returns>
        public IPagedList<ScheduledTask> SearchScheduledTasks(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<ScheduledTask>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _unitOfWork.ScheduledTaskRepository.GetPagedList(page, pageSize, ParseJSONSearchString<ScheduledTask>(where), sortExpression);
        }

        /// <summary>
        /// search scheduled tasks as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ScheduledTask&gt;.</returns>
        public async Task<IPagedList<ScheduledTask>> SearchScheduledTasksAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<ScheduledTask>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return await _unitOfWork.ScheduledTaskRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<ScheduledTask>(where), sortExpression);
        }

        /// <summary>
        /// Gets the scheduled task by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ScheduledTask.</returns>
        public ScheduledTask GetScheduledTaskById(int id)
        {
            return _unitOfWork.ScheduledTaskRepository.GetSingle(a => a.Id == id);
        }

        /// <summary>
        /// get scheduled task by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ScheduledTask.</returns>
        public async Task<ScheduledTask> GetScheduledTaskByIdAsync(int id)
        {
            return await _unitOfWork.ScheduledTaskRepository.GetSingleAsync(a => a.Id == id);
        }

        /// <summary>
        /// Gets the scheduled task by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>ScheduledTask</returns>
        public ScheduledTask GetScheduledTaskByName(string name)
        {
            return _unitOfWork.ScheduledTaskRepository.GetSingle(a => a.Name == name);
        }

        /// <summary>
        /// get scheduled task by name as an asynchronous operation.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>ScheduledTask.</returns>
        public async Task<ScheduledTask> GetScheduledTaskByNameAsync(string name)
        {
            return await _unitOfWork.ScheduledTaskRepository.GetSingleAsync(a => a.Name == name);
        }

        /// <summary>
        /// Adds the scheduled task.
        /// </summary>
        /// <param name="scheduledTasks">The scheduled tasks.</param>
        public void AddScheduledTask(params ScheduledTask[] scheduledTasks)
        {
            var taskEngine = new TaskEngine();
            foreach (var task in scheduledTasks.Where(a => a.Enabled))
            {
                if (task.Recurring)
                    task.UniqueId = Guid.NewGuid().ToString();

                task.UniqueId = taskEngine.AddTask(task);
            }

            _unitOfWork.ScheduledTaskRepository.Add(scheduledTasks);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add scheduled task as an asynchronous operation.
        /// </summary>
        /// <param name="scheduledTasks">The scheduled tasks.</param>
        public async Task AddScheduledTaskAsync(params ScheduledTask[] scheduledTasks)
        {
            var taskEngine = new TaskEngine();
            foreach (var task in scheduledTasks.Where(a => a.Enabled))
            {
                if (task.Recurring)
                    task.UniqueId = Guid.NewGuid().ToString();

                task.UniqueId = taskEngine.AddTask(task);
            }

            _unitOfWork.ScheduledTaskRepository.Add(scheduledTasks);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the scheduled task.
        /// </summary>
        /// <param name="scheduledTasks">The scheduled tasks.</param>
        public void UpdateScheduledTask(params ScheduledTask[] scheduledTasks)
        {
            var taskEngine = new TaskEngine();
            foreach (var task in scheduledTasks)
            {
                taskEngine.RemoveTask(task);
                if(task.Enabled)
                {
                    if(task.Recurring && string.IsNullOrEmpty(task.UniqueId))
                        task.UniqueId = Guid.NewGuid().ToString();
                    task.UniqueId = taskEngine.AddTask(task);
                }
            }

            _unitOfWork.ScheduledTaskRepository.Update(scheduledTasks);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update scheduled task as an asynchronous operation.
        /// </summary>
        /// <param name="scheduledTasks">The scheduled tasks.</param>
        public async Task UpdateScheduledTaskAsync(params ScheduledTask[] scheduledTasks)
        {
            var taskEngine = new TaskEngine();
            foreach (var task in scheduledTasks)
            {
                taskEngine.RemoveTask(task);
                if (task.Enabled)
                {
                    if (task.Recurring && string.IsNullOrEmpty(task.UniqueId))
                        task.UniqueId = Guid.NewGuid().ToString();
                    task.UniqueId = taskEngine.AddTask(task);
                }
            }

            _unitOfWork.ScheduledTaskRepository.Update(scheduledTasks);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the scheduled task.
        /// </summary>
        /// <param name="scheduledTasks">The scheduled tasks.</param>
        public void RemoveScheduledTask(params ScheduledTask[] scheduledTasks)
        {
            var taskEngine = new TaskEngine();
            foreach (var task in scheduledTasks)
            {
                taskEngine.RemoveTask(task);
            }

            _unitOfWork.ScheduledTaskRepository.Remove(scheduledTasks);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove scheduled task as an asynchronous operation.
        /// </summary>
        /// <param name="scheduledTasks">The scheduled tasks.</param>
        public async Task RemoveScheduledTaskAsync(params ScheduledTask[] scheduledTasks)
        {
            var taskEngine = new TaskEngine();
            foreach (var task in scheduledTasks)
            {
                taskEngine.RemoveTask(task);
            }

            _unitOfWork.ScheduledTaskRepository.Remove(scheduledTasks);
            await _unitOfWork.SaveAsync();
        }

        #endregion
    }
}