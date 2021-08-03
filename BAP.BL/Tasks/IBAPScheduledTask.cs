// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="IBAPScheduledTask.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.DAL.Entities;

namespace BAP.BL.Tasks
{
    /// <summary>
    /// Interface IBAPScheduledTask
    /// </summary>
    public interface IBAPScheduledTask
    {
        /// <summary>
        /// Gets the custom data json example.
        /// </summary>
        /// <value>The custom data json example.</value>
        string CustomDataJsonExample { get; }
        /// <summary>
        /// Runs the task.
        /// </summary>
        /// <param name="taskInfo">The task information.</param>
        /// <returns>ScheduledTaskResult.</returns>
        ScheduledTaskResult RunTask(ScheduledTask taskInfo);
    }
}