// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 05-20-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="WorkflowObjectBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using PagedList;

using BAP.Common;
using BAP.DAL.Entities;

namespace BAP.BL
{
    /// <summary>
    /// Interface IWorkflowObjectBL
    /// </summary>
    public interface IWorkflowObjectBL
    {
        /// <summary>
        /// Gets all workflow objects.
        /// </summary>
        /// <returns>IList&lt;WorkflowObject&gt;.</returns>
        IList<WorkflowObject> GetAllWorkflowObjects();
        /// <summary>
        /// Gets all workflow objects asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;WorkflowObject&gt;&gt;.</returns>
        Task<IList<WorkflowObject>> GetAllWorkflowObjectsAsync();

        /// <summary>
        /// Searches the workflow objects.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;WorkflowObject&gt;.</returns>
        IPagedList<WorkflowObject> SearchWorkflowObjects(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the workflow objects asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;WorkflowObject&gt;&gt;.</returns>
        Task<IPagedList<WorkflowObject>> SearchWorkflowObjectsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the workflow object by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>WorkflowObject.</returns>
        WorkflowObject GetWorkflowObjectById(int id);
        /// <summary>
        /// Gets the workflow object by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;WorkflowObject&gt;.</returns>
        Task<WorkflowObject> GetWorkflowObjectByIdAsync(int id);

        /// <summary>
        /// Gets the workflow object by entity.
        /// </summary>
        /// <param name="entityAssembly">The entity assembly.</param>
        /// <param name="entityClass">The entity class.</param>
        /// <param name="entityId">The entity identifier.</param>
        /// <returns>WorkflowObject.</returns>
        WorkflowObject GetWorkflowObjectByEntity(string entityAssembly, string entityClass, int entityId);
        /// <summary>
        /// Gets the workflow object by entity asynchronous.
        /// </summary>
        /// <param name="entityAssembly">The entity assembly.</param>
        /// <param name="entityClass">The entity class.</param>
        /// <param name="entityId">The entity identifier.</param>
        /// <returns>Task&lt;WorkflowObject&gt;.</returns>
        Task<WorkflowObject> GetWorkflowObjectByEntityAsync(string entityAssembly, string entityClass, int entityId);

        /// <summary>
        /// Adds the workflow object.
        /// </summary>
        /// <param name="workflowObject">The workflow object.</param>
        void AddWorkflowObject(WorkflowObject workflowObject);
        /// <summary>
        /// Adds the workflow object asynchronous.
        /// </summary>
        /// <param name="workflowObject">The workflow object.</param>
        /// <returns>Task.</returns>
        Task AddWorkflowObjectAsync(WorkflowObject workflowObject);

        /// <summary>
        /// Updates the workflow object.
        /// </summary>
        /// <param name="workflowObject">The workflow object.</param>
        void UpdateWorkflowObject(WorkflowObject workflowObject);
        /// <summary>
        /// Updates the workflow object asynchronous.
        /// </summary>
        /// <param name="workflowObject">The workflow object.</param>
        /// <returns>Task.</returns>
        Task UpdateWorkflowObjectAsync(WorkflowObject workflowObject);

        /// <summary>
        /// Removes the workflow object.
        /// </summary>
        /// <param name="saveDb">if set to <c>true</c> [save database].</param>
        /// <param name="workflowObjects">The workflow objects.</param>
        void RemoveWorkflowObject(bool saveDb, params WorkflowObject[] workflowObjects);
        /// <summary>
        /// Removes the workflow object asynchronous.
        /// </summary>
        /// <param name="saveDb">if set to <c>true</c> [save database].</param>
        /// <param name="workflowObjects">The workflow objects.</param>
        /// <returns>Task.</returns>
        Task RemoveWorkflowObjectAsync(bool saveDb, params WorkflowObject[] workflowObjects);
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
    public partial class BusinessLayer : IWorkflowObjectBL
    {
        #region workflowObjects

        /// <summary>
        /// Gets all workflow objects.
        /// </summary>
        /// <returns>IList&lt;WorkflowObject&gt;.</returns>
        public IList<WorkflowObject> GetAllWorkflowObjects()
        {
            return _unitOfWork.WorkflowObjectRepository.GetAll();
        }

        /// <summary>
        /// get all workflow objects as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;WorkflowObject&gt;.</returns>
        public async Task<IList<WorkflowObject>> GetAllWorkflowObjectsAsync()
        {
            return await _unitOfWork.WorkflowObjectRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the workflow objects.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;WorkflowObject&gt;.</returns>
        public IPagedList<WorkflowObject> SearchWorkflowObjects(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<WorkflowObject>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _unitOfWork.WorkflowObjectRepository.GetPagedList(page, pageSize, ParseJSONSearchString<WorkflowObject>(where), sortExpression, b => b.Workflow);
        }

        /// <summary>
        /// search workflow objects as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;WorkflowObject&gt;.</returns>
        public async Task<IPagedList<WorkflowObject>> SearchWorkflowObjectsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<WorkflowObject>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _unitOfWork.WorkflowObjectRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<WorkflowObject>(where), sortExpression, b => b.Workflow);
        }

        /// <summary>
        /// Gets the workflow object by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>WorkflowObject.</returns>
        public WorkflowObject GetWorkflowObjectById(int id)
        {
            return _unitOfWork.WorkflowObjectRepository.GetSingle(a => a.Id == id, a => a.Workflow);
        }

        /// <summary>
        /// get workflow object by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>WorkflowObject.</returns>
        public async Task<WorkflowObject> GetWorkflowObjectByIdAsync(int id)
        {
            return await _unitOfWork.WorkflowObjectRepository.GetSingleAsync(a => a.Id == id, a => a.Workflow);
        }

        /// <summary>
        /// Gets the workflow object by entity.
        /// </summary>
        /// <param name="entityAssembly">The entity assembly.</param>
        /// <param name="entityClass">The entity class.</param>
        /// <param name="entityId">The entity identifier.</param>
        /// <returns>WorkflowObject.</returns>
        public WorkflowObject GetWorkflowObjectByEntity(string entityAssembly, string entityClass, int entityId)
        {
            return _unitOfWork.WorkflowObjectRepository.GetSingle(a => a.BapEntityAssembly == entityAssembly && a.BapEntityClass == entityClass && a.BapEntityId == entityId, a => a.Workflow);
        }

        /// <summary>
        /// get workflow object by entity as an asynchronous operation.
        /// </summary>
        /// <param name="entityAssembly">The entity assembly.</param>
        /// <param name="entityClass">The entity class.</param>
        /// <param name="entityId">The entity identifier.</param>
        /// <returns>WorkflowObject.</returns>
        public async Task<WorkflowObject> GetWorkflowObjectByEntityAsync(string entityAssembly, string entityClass, int entityId)
        {
            return await _unitOfWork.WorkflowObjectRepository.GetSingleAsync(a => a.BapEntityAssembly == entityAssembly && a.BapEntityClass == entityClass && a.BapEntityId == entityId, a => a.Workflow);
        }

        /// <summary>
        /// Adds the workflow object.
        /// </summary>
        /// <param name="workflowObject">The workflow object.</param>
        public void AddWorkflowObject(WorkflowObject workflowObject)
        {
            WorkflowClass wfClass = null;
            if(workflowObject.Workflow != null)
            {
                wfClass = workflowObject.Workflow;
                workflowObject.Workflow = null;
            }

            _unitOfWork.WorkflowObjectRepository.Add(workflowObject);            
            _unitOfWork.Save();

            if (wfClass != null)
                workflowObject.Workflow = wfClass;
        }

        /// <summary>
        /// add workflow object as an asynchronous operation.
        /// </summary>
        /// <param name="workflowObject">The workflow object.</param>
        public async Task AddWorkflowObjectAsync(WorkflowObject workflowObject)
        {
            WorkflowClass wfClass = null;
            if (workflowObject.Workflow != null)
            {
                wfClass = workflowObject.Workflow;
                workflowObject.Workflow = null;
            }

            _unitOfWork.WorkflowObjectRepository.Add(workflowObject);
            await _unitOfWork.SaveAsync();

            if (wfClass != null)
                workflowObject.Workflow = wfClass;
        }

        /// <summary>
        /// Updates the workflow object.
        /// </summary>
        /// <param name="workflowObject">The workflow object.</param>
        public void UpdateWorkflowObject(WorkflowObject workflowObject)
        {
            WorkflowClass wfClass = null;
            if (workflowObject.Workflow != null)
            {
                wfClass = workflowObject.Workflow;
                workflowObject.Workflow = null;
            }

            _unitOfWork.WorkflowObjectRepository.Update(workflowObject);            
            _unitOfWork.Save();

            if (wfClass != null)
                workflowObject.Workflow = wfClass;
        }

        /// <summary>
        /// update workflow object as an asynchronous operation.
        /// </summary>
        /// <param name="workflowObject">The workflow object.</param>
        public async Task UpdateWorkflowObjectAsync(WorkflowObject workflowObject)
        {
            WorkflowClass wfClass = null;
            if (workflowObject.Workflow != null)
            {
                wfClass = workflowObject.Workflow;
                workflowObject.Workflow = null;
            }

            _unitOfWork.WorkflowObjectRepository.Update(workflowObject);
            await _unitOfWork.SaveAsync();

            if (wfClass != null)
                workflowObject.Workflow = wfClass;
        }

        /// <summary>
        /// Removes the workflow object.
        /// </summary>
        /// <param name="saveDb">if set to <c>true</c> [save database].</param>
        /// <param name="workflowObjects">The workflow objects.</param>
        public void RemoveWorkflowObject(bool saveDb, params WorkflowObject[] workflowObjects)
        {
            foreach(var wo in workflowObjects)
            {
                wo.Workflow = null;
            }

            _unitOfWork.WorkflowObjectRepository.Remove(workflowObjects);

            if(saveDb)
                _unitOfWork.Save();
        }

        /// <summary>
        /// remove workflow object as an asynchronous operation.
        /// </summary>
        /// <param name="saveDb">if set to <c>true</c> [save database].</param>
        /// <param name="workflowObjects">The workflow objects.</param>
        public async Task RemoveWorkflowObjectAsync(bool saveDb, params WorkflowObject[] workflowObjects)
        {
            foreach (var wo in workflowObjects)
            {
                wo.Workflow = null;
            }

            _unitOfWork.WorkflowObjectRepository.Remove(workflowObjects);

            if (saveDb)
                await _unitOfWork.SaveAsync();
        }

        #endregion
    }
}
