// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 06-02-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="WorkflowStageTransitionBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using PagedList;

using BAP.Common;
using BAP.Common.Exceptions;
using BAP.DAL.Entities;
using System.Linq;

namespace BAP.BL
{
    /// <summary>
    /// Interface IWorkflowStageTransitionBL
    /// </summary>
    public interface IWorkflowStageTransitionBL
    {
        /// <summary>
        /// Gets all workflow stage transitions.
        /// </summary>
        /// <returns>IList&lt;WorkflowStageTransition&gt;.</returns>
        IList<WorkflowStageTransition> GetAllWorkflowStageTransitions();
        /// <summary>
        /// Gets all workflow stage transitions asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;WorkflowStageTransition&gt;&gt;.</returns>
        Task<IList<WorkflowStageTransition>> GetAllWorkflowStageTransitionsAsync();

        /// <summary>
        /// Searches the workflow stage transitions.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;WorkflowStageTransition&gt;.</returns>
        IPagedList<WorkflowStageTransition> SearchWorkflowStageTransitions(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the workflow stage transitions asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;WorkflowStageTransition&gt;&gt;.</returns>
        Task<IPagedList<WorkflowStageTransition>> SearchWorkflowStageTransitionsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the workflow stage transition by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>WorkflowStageTransition.</returns>
        WorkflowStageTransition GetWorkflowStageTransitionById(int id);
        /// <summary>
        /// Gets the workflow stage transition by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;WorkflowStageTransition&gt;.</returns>
        Task<WorkflowStageTransition> GetWorkflowStageTransitionByIdAsync(int id);

        /// <summary>
        /// Adds the workflow stage transitions.
        /// </summary>
        /// <param name="workflowStageTransitions">The workflow stage transitions.</param>
        void AddWorkflowStageTransitions(params WorkflowStageTransition[] workflowStageTransitions);
        /// <summary>
        /// Adds the workflow stage transitions asynchronous.
        /// </summary>
        /// <param name="workflowStageTransitions">The workflow stage transitions.</param>
        /// <returns>Task.</returns>
        Task AddWorkflowStageTransitionsAsync(params WorkflowStageTransition[] workflowStageTransitions);

        /// <summary>
        /// Updates the workflow stage transitions.
        /// </summary>
        /// <param name="workflowStageTransitions">The workflow stage transitions.</param>
        void UpdateWorkflowStageTransitions(params WorkflowStageTransition[] workflowStageTransitions);
        /// <summary>
        /// Updates the workflow stage transitions asynchronous.
        /// </summary>
        /// <param name="workflowStageTransitions">The workflow stage transitions.</param>
        /// <returns>Task.</returns>
        Task UpdateWorkflowStageTransitionsAsync(params WorkflowStageTransition[] workflowStageTransitions);

        /// <summary>
        /// Removes the workflow stage transitions.
        /// </summary>
        /// <param name="workflowStageTransitions">The workflow stage transitions.</param>
        void RemoveWorkflowStageTransitions(params WorkflowStageTransition[] workflowStageTransitions);
        /// <summary>
        /// Removes the workflow stage transitions asynchronous.
        /// </summary>
        /// <param name="workflowStageTransitions">The workflow stage transitions.</param>
        /// <returns>Task.</returns>
        Task RemoveWorkflowStageTransitionsAsync(params WorkflowStageTransition[] workflowStageTransitions);

        /// <summary>
        /// Adds the workflow transtion action.
        /// </summary>
        /// <param name="workflowStageTransitionId">The workflow stage transition identifier.</param>
        /// <param name="workFlowActionId">The work flow action identifier.</param>
        void AddWorkflowTranstionAction(int workflowStageTransitionId, int workFlowActionId);
        /// <summary>
        /// Adds the workflow transtion action asynchronous.
        /// </summary>
        /// <param name="workflowStageTransitionId">The workflow stage transition identifier.</param>
        /// <param name="workFlowActionId">The work flow action identifier.</param>
        /// <returns>Task.</returns>
        Task AddWorkflowTranstionActionAsync(int workflowStageTransitionId, int workFlowActionId);

        /// <summary>
        /// Removes the workflow transtion action.
        /// </summary>
        /// <param name="workflowStageTransition">The workflow stage transition.</param>
        /// <param name="workflowAction">The workflow action.</param>
        void RemoveWorkflowTranstionAction(WorkflowStageTransition workflowStageTransition, WorkflowAction workflowAction);
        /// <summary>
        /// Removes the workflow transtion action asynchronous.
        /// </summary>
        /// <param name="workflowStageTransition">The workflow stage transition.</param>
        /// <param name="workflowAction">The workflow action.</param>
        /// <returns>Task.</returns>
        Task RemoveWorkflowTranstionActionAsync(WorkflowStageTransition workflowStageTransition, WorkflowAction workflowAction);
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
    public partial class BusinessLayer : IWorkflowStageTransitionBL
    {
        #region workflowStageTransitions

        /// <summary>
        /// Gets all workflow stage transitions.
        /// </summary>
        /// <returns>IList&lt;WorkflowStageTransition&gt;.</returns>
        public IList<WorkflowStageTransition> GetAllWorkflowStageTransitions()
        {
            return _unitOfWork.WorkflowStageTransitionRepository.GetAll();
        }

        /// <summary>
        /// get all workflow stage transitions as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;WorkflowStageTransition&gt;.</returns>
        public async Task<IList<WorkflowStageTransition>> GetAllWorkflowStageTransitionsAsync()
        {
            return await _unitOfWork.WorkflowStageTransitionRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the workflow stage transitions.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;WorkflowStageTransition&gt;.</returns>
        public IPagedList<WorkflowStageTransition> SearchWorkflowStageTransitions(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<WorkflowStageTransition>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _unitOfWork.WorkflowStageTransitionRepository.GetPagedList(page, pageSize, ParseJSONSearchString<WorkflowStageTransition>(where), sortExpression, a => a.Workflow, a => a.FromStage, a => a.ToStage, a => a.Actions);
        }

        /// <summary>
        /// search workflow stage transitions as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;WorkflowStageTransition&gt;.</returns>
        public async Task<IPagedList<WorkflowStageTransition>> SearchWorkflowStageTransitionsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<WorkflowStageTransition>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _unitOfWork.WorkflowStageTransitionRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<WorkflowStageTransition>(where), sortExpression, a => a.Workflow, a => a.FromStage, a => a.ToStage, a => a.Actions);
        }

        /// <summary>
        /// Gets the workflow stage transition by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>WorkflowStageTransition.</returns>
        public WorkflowStageTransition GetWorkflowStageTransitionById(int id)
        {
            var entity = _unitOfWork.WorkflowStageTransitionRepository.GetSingle(a => a.Id == id, a => a.Workflow, a => a.FromStage, a => a.ToStage, a => a.Actions);
            return entity;
        }

        /// <summary>
        /// get workflow stage transition by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>WorkflowStageTransition.</returns>
        public async Task<WorkflowStageTransition> GetWorkflowStageTransitionByIdAsync(int id)
        {
            var entity = await _unitOfWork.WorkflowStageTransitionRepository.GetSingleAsync(a => a.Id == id, a => a.Workflow, a => a.FromStage, a => a.ToStage, a => a.Actions);
            return entity;
        }

        /// <summary>
        /// Adds the workflow stage transitions.
        /// </summary>
        /// <param name="workflowStageTransitions">The workflow stage transitions.</param>
        public void AddWorkflowStageTransitions(params WorkflowStageTransition[] workflowStageTransitions)
        {
            _unitOfWork.WorkflowStageTransitionRepository.Add(workflowStageTransitions);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add workflow stage transitions as an asynchronous operation.
        /// </summary>
        /// <param name="workflowStageTransitions">The workflow stage transitions.</param>
        public async Task AddWorkflowStageTransitionsAsync(params WorkflowStageTransition[] workflowStageTransitions)
        {
            _unitOfWork.WorkflowStageTransitionRepository.Add(workflowStageTransitions);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the workflow stage transitions.
        /// </summary>
        /// <param name="workflowStageTransitions">The workflow stage transitions.</param>
        public void UpdateWorkflowStageTransitions(params WorkflowStageTransition[] workflowStageTransitions)
        {
            //Clean objects to prevent unnecessary updates
            foreach (var item in workflowStageTransitions)
            {
                item.FromStage = null;
                item.ToStage = null;
                item.Workflow = null;
            }
            _unitOfWork.WorkflowStageTransitionRepository.Update(workflowStageTransitions);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update workflow stage transitions as an asynchronous operation.
        /// </summary>
        /// <param name="workflowStageTransitions">The workflow stage transitions.</param>
        public async Task UpdateWorkflowStageTransitionsAsync(params WorkflowStageTransition[] workflowStageTransitions)
        {
            _unitOfWork.WorkflowStageTransitionRepository.Update(workflowStageTransitions);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the workflow stage transitions.
        /// </summary>
        /// <param name="workflowStageTransitions">The workflow stage transitions.</param>
        public void RemoveWorkflowStageTransitions(params WorkflowStageTransition[] workflowStageTransitions)
        {
            _unitOfWork.WorkflowStageTransitionRepository.Remove(workflowStageTransitions);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove workflow stage transitions as an asynchronous operation.
        /// </summary>
        /// <param name="workflowStageTransitions">The workflow stage transitions.</param>
        public async Task RemoveWorkflowStageTransitionsAsync(params WorkflowStageTransition[] workflowStageTransitions)
        {
            _unitOfWork.WorkflowStageTransitionRepository.Remove(workflowStageTransitions);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Adds the workflow transtion action.
        /// </summary>
        /// <param name="workflowStageTransitionId">The workflow stage transition identifier.</param>
        /// <param name="workFlowActionId">The work flow action identifier.</param>
        /// <exception cref="BAP.Common.Exceptions.BAPException"></exception>
        public void AddWorkflowTranstionAction(int workflowStageTransitionId, int workFlowActionId)
        {
            var workflowStageTransition = _unitOfWork.WorkflowStageTransitionRepository.GetSingle(wst => wst.Id == workflowStageTransitionId, wst => wst.Actions);

            if (workflowStageTransition == null)
                return;

            var action = workflowStageTransition.Actions.SingleOrDefault(a => a.Id == workFlowActionId);
            if (action != null)
                throw new BAPException(string.Format(Resources.Resources.ErrorText_WorkflowActionAlreadyWorkflowTranstionAction, action.Name));

            _unitOfWork.WorkflowStageTransitionRepository.AttachIfDetached(workflowStageTransition);
            if (workflowStageTransition.Actions == null)
                workflowStageTransition.Actions = new List<WorkflowAction>();

            if (workflowStageTransition.Actions.Any(a => a.Id == workFlowActionId))
                return;

            var workFlowAction = ((IWorkflowActionBL)this).GetWorkflowActionById(workFlowActionId);
            if (workFlowAction != null)
            {
                workflowStageTransition.Actions.Add(workFlowAction);
            }

            _unitOfWork.WorkflowStageTransitionRepository.Update(workflowStageTransition);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add workflow transtion action as an asynchronous operation.
        /// </summary>
        /// <param name="workflowStageTransitionId">The workflow stage transition identifier.</param>
        /// <param name="workFlowActionId">The work flow action identifier.</param>
        /// <exception cref="BAP.Common.Exceptions.BAPException"></exception>
        public async Task AddWorkflowTranstionActionAsync(int workflowStageTransitionId, int workFlowActionId)
        {
            var workflowStageTransition = await _unitOfWork.WorkflowStageTransitionRepository.GetSingleAsync(wst => wst.Id == workflowStageTransitionId, wst => wst.Actions);

            if (workflowStageTransition == null)
                return;

            var action = workflowStageTransition.Actions.SingleOrDefault(a => a.Id == workFlowActionId);
            if (action != null)
                throw new BAPException(string.Format(Resources.Resources.ErrorText_WorkflowActionAlreadyWorkflowTranstionAction, action.Name));

            _unitOfWork.WorkflowStageTransitionRepository.AttachIfDetached(workflowStageTransition);
            if (workflowStageTransition.Actions == null)
                workflowStageTransition.Actions = new List<WorkflowAction>();

            if (workflowStageTransition.Actions.Any(a => a.Id == workFlowActionId))
                return;

            var workFlowAction = await ((IWorkflowActionBL)this).GetWorkflowActionByIdAsync(workFlowActionId);
            if (workFlowAction != null)
            {
                workflowStageTransition.Actions.Add(workFlowAction);
            }

            _unitOfWork.WorkflowStageTransitionRepository.Update(workflowStageTransition);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the workflow transtion action.
        /// </summary>
        /// <param name="workflowStageTransition">The workflow stage transition.</param>
        /// <param name="workflowAction">The workflow action.</param>
        public void RemoveWorkflowTranstionAction(WorkflowStageTransition workflowStageTransition, WorkflowAction workflowAction)
        {
            if (workflowStageTransition == null || workflowAction == null)
                return;

            if (workflowStageTransition.Actions != null && workflowStageTransition.Actions.Any(a => a.Id == workflowAction.Id))
            {
                _unitOfWork.WorkflowStageTransitionRepository.AttachIfDetached(workflowStageTransition);
                var itemToRemove = workflowStageTransition.Actions.SingleOrDefault(a => a.Id == workflowAction.Id);
                workflowStageTransition.Actions.Remove(itemToRemove);
                _unitOfWork.Save();
            }
        }

        /// <summary>
        /// remove workflow transtion action as an asynchronous operation.
        /// </summary>
        /// <param name="workflowStageTransition">The workflow stage transition.</param>
        /// <param name="workflowAction">The workflow action.</param>
        public async Task RemoveWorkflowTranstionActionAsync(WorkflowStageTransition workflowStageTransition, WorkflowAction workflowAction)
        {
            if (workflowStageTransition == null || workflowAction == null)
                return;

            if (workflowStageTransition.Actions != null && workflowStageTransition.Actions.Any(a => a.Id == workflowAction.Id))
            {
                _unitOfWork.WorkflowStageTransitionRepository.AttachIfDetached(workflowStageTransition);
                var itemToRemove = workflowStageTransition.Actions.SingleOrDefault(a => a.Id == workflowAction.Id);
                workflowStageTransition.Actions.Remove(itemToRemove);
                await _unitOfWork.SaveAsync();
            }
        }

        #endregion
    }
}
