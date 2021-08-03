// ***********************************************************************
// Assembly         : BAP.Workflow
// Author           : Victor Mamray
// Created          : 07-15-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-15-2020
// ***********************************************************************
// <copyright file="ISupportWorkflow.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.Common;
using BAP.DAL.Entities;
using System.Collections.Generic;

namespace BAP.Workflow
{
    /// <summary>
    /// Interface to be implemented by business logic class of particular BAP entity type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISupportWorkflow<T> where T : class, IBapEntity
    {
        /// <summary>
        /// Gets the available flows.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>List&lt;WorkflowClass&gt;.</returns>
        List<WorkflowClass> GetAvailableFlows(T entity);
        /// <summary>
        /// Chooses the workflow.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="workflowId">The workflow identifier.</param>
        /// <returns>Workflow&lt;T&gt;.</returns>
        Workflow<T> ChooseWorkflow(T entity, int workflowId);
        /// <summary>
        /// Set current workflow to NULL for particular type of entity
        /// </summary>
        /// <param name="entity">The entity.</param>
        void RemoveCurrentWorkflow(T entity);
        /// <summary>
        /// Gets the current workflow.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="metaId">The meta identifier.</param>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <returns>Workflow&lt;T&gt;.</returns>
        Workflow<T> GetCurrentWorkflow(T entity, int? metaId = null, int? attachmentId = null);
        /// <summary>
        /// Chooses the transition.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <param name="metaTranstionId">The meta transtion identifier.</param>
        /// <param name="comment">The comment.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool ChooseTransition(Workflow<T> workflow, int metaTranstionId, string comment);
        /// <summary>
        /// Does the action.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <param name="metaActionId">The meta action identifier.</param>
        /// <param name="attributesJson">The attributes json.</param>
        /// <returns>System.String.</returns>
        string DoAction(Workflow<T> workflow, int metaActionId, string attributesJson);
        /// <summary>
        /// Saves the workflow.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        void SaveWorkflow(Workflow<T> workflow);
    }
}
