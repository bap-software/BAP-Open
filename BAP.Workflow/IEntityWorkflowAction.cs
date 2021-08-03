// ***********************************************************************
// Assembly         : BAP.Workflow
// Author           : Victor Mamray
// Created          : 06-11-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-09-2020
// ***********************************************************************
// <copyright file="IEntityWorkflowAction.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.Common;
using System.Collections.Generic;

namespace BAP.Workflow
{
    /// <summary>
    /// Class ExecutionResut.
    /// </summary>
    public class ExecutionResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ExecutionResult"/> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool Success { get; set; }
        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        /// <value>The messages.</value>
        public IList<string> Messages { get; set; }
    }

    /// <summary>
    /// Interface IEntityWorkflowAction
    /// Implements the <see cref="BAP.Common.IWorkflowAction" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="BAP.Common.IWorkflowAction" />
    public interface IEntityWorkflowAction<T> : IWorkflowAction where T : class, IBapEntity 
    {
        /// <summary>
        /// Executes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="actionAttributes">The action attributes.</param>
        /// <returns>ExecutionResut.</returns>
        ExecutionResult Execute(IBapEntity entity, List<ActionAttribute<T>> actionAttributes);
    }
}
