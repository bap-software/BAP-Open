// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 05-20-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="WorkflowStageBL.cs" company="BAP Software Ltd.">
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
    /// Interface IWorkflowStageBL
    /// </summary>
    public interface IWorkflowStageBL
    {
        /// <summary>
        /// Gets all workflow stages.
        /// </summary>
        /// <returns>IList&lt;WorkflowStage&gt;.</returns>
        IList<WorkflowStage> GetAllWorkflowStages();
        /// <summary>
        /// Gets all workflow stages asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;WorkflowStage&gt;&gt;.</returns>
        Task<IList<WorkflowStage>> GetAllWorkflowStagesAsync();

        /// <summary>
        /// Searches the workflow stages.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;WorkflowStage&gt;.</returns>
        IPagedList<WorkflowStage> SearchWorkflowStages(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the workflow stages asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;WorkflowStage&gt;&gt;.</returns>
        Task<IPagedList<WorkflowStage>> SearchWorkflowStagesAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the workflow stage by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>WorkflowStage.</returns>
        WorkflowStage GetWorkflowStageById(int id);
        /// <summary>
        /// Gets the workflow stage by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;WorkflowStage&gt;.</returns>
        Task<WorkflowStage> GetWorkflowStageByIdAsync(int id);

        /// <summary>
        /// Adds the workflow stages.
        /// </summary>
        /// <param name="workflowStages">The workflow stages.</param>
        void AddWorkflowStages(params WorkflowStage[] workflowStages);
        /// <summary>
        /// Adds the workflow stages asynchronous.
        /// </summary>
        /// <param name="workflowStages">The workflow stages.</param>
        /// <returns>Task.</returns>
        Task AddWorkflowStagesAsync(params WorkflowStage[] workflowStages);

        /// <summary>
        /// Updates the workflow stages.
        /// </summary>
        /// <param name="workflowStages">The workflow stages.</param>
        void UpdateWorkflowStages(params WorkflowStage[] workflowStages);
        /// <summary>
        /// Updates the workflow stages asynchronous.
        /// </summary>
        /// <param name="workflowStages">The workflow stages.</param>
        /// <returns>Task.</returns>
        Task UpdateWorkflowStagesAsync(params WorkflowStage[] workflowStages);

        /// <summary>
        /// Removes the workflow stages.
        /// </summary>
        /// <param name="workflowStages">The workflow stages.</param>
        void RemoveWorkflowStages(params WorkflowStage[] workflowStages);
        /// <summary>
        /// Removes the workflow stages asynchronous.
        /// </summary>
        /// <param name="workflowStages">The workflow stages.</param>
        /// <returns>Task.</returns>
        Task RemoveWorkflowStagesAsync(params WorkflowStage[] workflowStages);

        /// <summary>
        /// Gets the stage types.
        /// </summary>
        /// <returns>IList&lt;StageTypeItem&gt;.</returns>
        IList<StageTypeItem> GetStageTypes();
    }

    /// <summary>
    /// Class StageTypeItem.
    /// </summary>
    public class StageTypeItem
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
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
    public partial class BusinessLayer : IWorkflowStageBL
    {
        #region WorkflowStages

        /// <summary>
        /// Gets all workflow stages.
        /// </summary>
        /// <returns>IList&lt;WorkflowStage&gt;.</returns>
        public IList<WorkflowStage> GetAllWorkflowStages()
        {
            return _unitOfWork.WorkflowStageRepository.GetAll();
        }

        /// <summary>
        /// get all workflow stages as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;WorkflowStage&gt;.</returns>
        public async Task<IList<WorkflowStage>> GetAllWorkflowStagesAsync()
        {
            return await _unitOfWork.WorkflowStageRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the workflow stages.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;WorkflowStage&gt;.</returns>
        public IPagedList<WorkflowStage> SearchWorkflowStages(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<WorkflowStage>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _unitOfWork.WorkflowStageRepository.GetPagedList(page, pageSize, ParseJSONSearchString<WorkflowStage>(where), sortExpression, b => b.Workflow);
        }

        /// <summary>
        /// search workflow stages as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;WorkflowStage&gt;.</returns>
        public async Task<IPagedList<WorkflowStage>> SearchWorkflowStagesAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<WorkflowStage>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _unitOfWork.WorkflowStageRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<WorkflowStage>(where), sortExpression, b => b.Workflow);
        }

        /// <summary>
        /// Gets the workflow stage by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>WorkflowStage.</returns>
        public WorkflowStage GetWorkflowStageById(int id)
        {
            return _unitOfWork.WorkflowStageRepository.GetSingle(a => a.Id == id, a => a.Workflow);
        }

        /// <summary>
        /// get workflow stage by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>WorkflowStage.</returns>
        public async Task<WorkflowStage> GetWorkflowStageByIdAsync(int id)
        {
            return await _unitOfWork.WorkflowStageRepository.GetSingleAsync(a => a.Id == id, a => a.Workflow);
        }

        /// <summary>
        /// Adds the workflow stages.
        /// </summary>
        /// <param name="workflowStages">The workflow stages.</param>
        public void AddWorkflowStages(params WorkflowStage[] workflowStages)
        {            
            _unitOfWork.WorkflowStageRepository.Add(workflowStages);            
            _unitOfWork.Save();
        }

        /// <summary>
        /// add workflow stages as an asynchronous operation.
        /// </summary>
        /// <param name="workflowStages">The workflow stages.</param>
        public async Task AddWorkflowStagesAsync(params WorkflowStage[] workflowStages)
        {
            _unitOfWork.WorkflowStageRepository.Add(workflowStages);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the workflow stages.
        /// </summary>
        /// <param name="workflowStages">The workflow stages.</param>
        public void UpdateWorkflowStages(params WorkflowStage[] workflowStages)
        {            
            _unitOfWork.WorkflowStageRepository.Update(workflowStages);            
            _unitOfWork.Save();
        }

        /// <summary>
        /// update workflow stages as an asynchronous operation.
        /// </summary>
        /// <param name="workflowStages">The workflow stages.</param>
        public async Task UpdateWorkflowStagesAsync(params WorkflowStage[] workflowStages)
        {
            _unitOfWork.WorkflowStageRepository.Update(workflowStages);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the workflow stages.
        /// </summary>
        /// <param name="workflowStages">The workflow stages.</param>
        public void RemoveWorkflowStages(params WorkflowStage[] workflowStages)
        {
            _unitOfWork.WorkflowStageRepository.Remove(workflowStages);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove workflow stages as an asynchronous operation.
        /// </summary>
        /// <param name="workflowStages">The workflow stages.</param>
        public async Task RemoveWorkflowStagesAsync(params WorkflowStage[] workflowStages)
        {
            _unitOfWork.WorkflowStageRepository.Remove(workflowStages);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Gets the stage types.
        /// </summary>
        /// <returns>IList&lt;StageTypeItem&gt;.</returns>
        public IList<StageTypeItem> GetStageTypes()
        {
            var result = new List<StageTypeItem>
            {
                new StageTypeItem { Id = 0, Name = "None" },
                new StageTypeItem { Id = 1, Name = "Initial"},
                new StageTypeItem { Id = 2, Name = "Work"},
                new StageTypeItem { Id = 3, Name = "Cancel"},
                new StageTypeItem { Id = 4, Name = "Finish"}
            };
            
            return result;
        }

        #endregion
    }
}
