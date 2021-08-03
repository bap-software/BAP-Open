// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 05-20-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="WorkflowClassBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

using PagedList;

using BAP.Common;
using BAP.DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace BAP.BL
{
    /// <summary>
    /// Interface IWorkflowClassBL
    /// </summary>
    public interface IWorkflowClassBL
    {
        /// <summary>
        /// Gets all workflow classes.
        /// </summary>
        /// <returns>IList&lt;WorkflowClass&gt;.</returns>
        IList<WorkflowClass> GetAllWorkflowClasses();
        /// <summary>
        /// Gets all workflow classes asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;WorkflowClass&gt;&gt;.</returns>
        Task<IList<WorkflowClass>> GetAllWorkflowClassesAsync();

        /// <summary>
        /// Searches the workflow classes.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;WorkflowClass&gt;.</returns>
        IPagedList<WorkflowClass> SearchWorkflowClasses(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the workflow classes asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;WorkflowClass&gt;&gt;.</returns>
        Task<IPagedList<WorkflowClass>> SearchWorkflowClassesAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the workflow class by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>WorkflowClass.</returns>
        WorkflowClass GetWorkflowClassById(int id);
        /// <summary>
        /// Gets the workflow class by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;WorkflowClass&gt;.</returns>
        Task<WorkflowClass> GetWorkflowClassByIdAsync(int id);

        /// <summary>
        /// Gets the workflow classes by entity.
        /// </summary>
        /// <param name="entityAssembly">The entity assembly.</param>
        /// <param name="entityClass">The entity class.</param>
        /// <returns>IList&lt;WorkflowClass&gt;.</returns>
        IList<WorkflowClass> GetWorkflowClassesByEntity(string entityAssembly, string entityClass);
        /// <summary>
        /// Gets the workflow classes by entity asynchronous.
        /// </summary>
        /// <param name="entityAssembly">The entity assembly.</param>
        /// <param name="entityClass">The entity class.</param>
        /// <returns>Task&lt;IList&lt;WorkflowClass&gt;&gt;.</returns>
        Task<IList<WorkflowClass>> GetWorkflowClassesByEntityAsync(string entityAssembly, string entityClass);

        /// <summary>
        /// Adds the workflow classes.
        /// </summary>
        /// <param name="workflowClasses">The workflow classes.</param>
        void AddWorkflowClasses(params WorkflowClass[] workflowClasses);
        /// <summary>
        /// Adds the workflow classes asynchronous.
        /// </summary>
        /// <param name="workflowClasses">The workflow classes.</param>
        /// <returns>Task.</returns>
        Task AddWorkflowClassesAsync(params WorkflowClass[] workflowClasses);

        /// <summary>
        /// Updates the workflow classes.
        /// </summary>
        /// <param name="workflowClasses">The workflow classes.</param>
        void UpdateWorkflowClasses(params WorkflowClass[] workflowClasses);
        /// <summary>
        /// Updates the workflow classes asynchronous.
        /// </summary>
        /// <param name="workflowClasses">The workflow classes.</param>
        /// <returns>Task.</returns>
        Task UpdateWorkflowClassesAsync(params WorkflowClass[] workflowClasses);

        /// <summary>
        /// Removes the workflow classes.
        /// </summary>
        /// <param name="workflowClasses">The workflow classes.</param>
        void RemoveWorkflowClasses(params WorkflowClass[] workflowClasses);
        /// <summary>
        /// Removes the workflow classes asynchronous.
        /// </summary>
        /// <param name="workflowClasses">The workflow classes.</param>
        /// <returns>Task.</returns>
        Task RemoveWorkflowClassesAsync(params WorkflowClass[] workflowClasses);
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
    public partial class BusinessLayer : IWorkflowClassBL
    {
        #region workflowClasses

        /// <summary>
        /// Gets all workflow classes.
        /// </summary>
        /// <returns>IList&lt;WorkflowClass&gt;.</returns>
        public IList<WorkflowClass> GetAllWorkflowClasses()
        {
            return _unitOfWork.WorkflowClassRepository.GetAll();
        }

        /// <summary>
        /// get all workflow classes as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;WorkflowClass&gt;.</returns>
        public async Task<IList<WorkflowClass>> GetAllWorkflowClassesAsync()
        {
            return await _unitOfWork.WorkflowClassRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the workflow classes.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;WorkflowClass&gt;.</returns>
        public IPagedList<WorkflowClass> SearchWorkflowClasses(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<WorkflowClass>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _unitOfWork.WorkflowClassRepository.GetPagedList(page, pageSize, ParseJSONSearchString<WorkflowClass>(where), sortExpression, b => b.Actions, b => b.Stages, b => b.Transitions);
        }

        /// <summary>
        /// search workflow classes as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;WorkflowClass&gt;.</returns>
        public async Task<IPagedList<WorkflowClass>> SearchWorkflowClassesAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<WorkflowClass>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _unitOfWork.WorkflowClassRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<WorkflowClass>(where), sortExpression, b => b.Actions, b => b.Stages, b => b.Transitions);
        }

        /// <summary>
        /// Gets the workflow classes by entity.
        /// </summary>
        /// <param name="entityAssembly">The entity assembly.</param>
        /// <param name="entityClass">The entity class.</param>
        /// <returns>IList&lt;WorkflowClass&gt;.</returns>
        public IList<WorkflowClass> GetWorkflowClassesByEntity(string entityAssembly, string entityClass)
        {
            return _unitOfWork.WorkflowClassRepository.GetList(a => a.BapEntityAssembly == entityAssembly && a.BapEntityClass == entityClass, b => b.Actions, b => b.Stages, b => b.Transitions, b => b.Actions.Select(c => c.Attributes), b => b.Transitions.Select(d => d.Actions));
        }

        /// <summary>
        /// get workflow classes by entity as an asynchronous operation.
        /// </summary>
        /// <param name="entityAssembly">The entity assembly.</param>
        /// <param name="entityClass">The entity class.</param>
        /// <returns>IList&lt;WorkflowClass&gt;.</returns>
        public async Task<IList<WorkflowClass>> GetWorkflowClassesByEntityAsync(string entityAssembly, string entityClass)
        {
            return await _unitOfWork.WorkflowClassRepository.GetListAsync(a => a.BapEntityAssembly == entityAssembly && a.BapEntityClass == entityClass, b => b.Actions, b => b.Stages, b => b.Transitions, b => b.Actions.Select(c => c.Attributes), b => b.Transitions.Select(d => d.Actions));
        }

        /// <summary>
        /// Gets the workflow class by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>WorkflowClass.</returns>
        public WorkflowClass GetWorkflowClassById(int id)
        {
            return _unitOfWork.WorkflowClassRepository.GetSingle(a => a.Id == id, b => b.Actions, b => b.Stages, b => b.Transitions, b => b.Actions.Select(c => c.Attributes), b => b.Transitions.Select(d => d.Actions));
        }

        /// <summary>
        /// get workflow class by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>WorkflowClass.</returns>
        public async Task<WorkflowClass> GetWorkflowClassByIdAsync(int id)
        {
            return await _unitOfWork.WorkflowClassRepository.GetSingleAsync(a => a.Id == id, b => b.Actions, b => b.Stages, b => b.Transitions, b => b.Actions.Select(c => c.Attributes), b => b.Transitions.Select(d => d.Actions));
        }

        /// <summary>
        /// Adds the workflow classes.
        /// </summary>
        /// <param name="workflowClasses">The workflow classes.</param>
        public void AddWorkflowClasses(params WorkflowClass[] workflowClasses)
        {            
            _unitOfWork.WorkflowClassRepository.Add(workflowClasses);            
            _unitOfWork.Save();
        }

        /// <summary>
        /// add workflow classes as an asynchronous operation.
        /// </summary>
        /// <param name="workflowClasses">The workflow classes.</param>
        public async Task AddWorkflowClassesAsync(params WorkflowClass[] workflowClasses)
        {
            _unitOfWork.WorkflowClassRepository.Add(workflowClasses);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the workflow classes.
        /// </summary>
        /// <param name="workflowClasses">The workflow classes.</param>
        public void UpdateWorkflowClasses(params WorkflowClass[] workflowClasses)
        {            
            _unitOfWork.WorkflowClassRepository.Update(workflowClasses);            
            _unitOfWork.Save();
        }

        /// <summary>
        /// update workflow classes as an asynchronous operation.
        /// </summary>
        /// <param name="workflowClasses">The workflow classes.</param>
        public async Task UpdateWorkflowClassesAsync(params WorkflowClass[] workflowClasses)
        {
            _unitOfWork.WorkflowClassRepository.Update(workflowClasses);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the workflow classes.
        /// </summary>
        /// <param name="workflowClasses">The workflow classes.</param>
        public void RemoveWorkflowClasses(params WorkflowClass[] workflowClasses)
        {
            _unitOfWork.WorkflowClassRepository.Remove(workflowClasses);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove workflow classes as an asynchronous operation.
        /// </summary>
        /// <param name="workflowClasses">The workflow classes.</param>
        public async Task RemoveWorkflowClassesAsync(params WorkflowClass[] workflowClasses)
        {
            _unitOfWork.WorkflowClassRepository.Remove(workflowClasses);
            await _unitOfWork.SaveAsync();
        }

        #endregion
    }
}
