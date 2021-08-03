// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 06-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-24-2020
// ***********************************************************************
// <copyright file="WorkflowActionAttributeBL.cs" company="BAP Software Ltd.">
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
    /// Class AttributeTypeItem.
    /// </summary>
    public class AttributeTypeItem
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
    /// Interface IWorkflowActionAttributeBL
    /// </summary>
    public interface IWorkflowActionAttributeBL
    {
        /// <summary>
        /// Gets all workflow action attributes.
        /// </summary>
        /// <returns>IList&lt;WorkflowActionAttribute&gt;.</returns>
        IList<WorkflowActionAttribute> GetAllWorkflowActionAttributes();
        /// <summary>
        /// Gets all workflow action attributes asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;WorkflowActionAttribute&gt;&gt;.</returns>
        Task<IList<WorkflowActionAttribute>> GetAllWorkflowActionAttributesAsync();

        /// <summary>
        /// Searches the workflow action attributes.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;WorkflowActionAttribute&gt;.</returns>
        IPagedList<WorkflowActionAttribute> SearchWorkflowActionAttributes(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the workflow action attributes asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;WorkflowActionAttribute&gt;&gt;.</returns>
        Task<IPagedList<WorkflowActionAttribute>> SearchWorkflowActionAttributesAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the workflow action attribute by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>WorkflowActionAttribute.</returns>
        WorkflowActionAttribute GetWorkflowActionAttributeById(int id);
        /// <summary>
        /// Gets the workflow action attribute by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;WorkflowActionAttribute&gt;.</returns>
        Task<WorkflowActionAttribute> GetWorkflowActionAttributeByIdAsync(int id);

        /// <summary>
        /// Adds the workflow action attributes.
        /// </summary>
        /// <param name="workflowActionAttributes">The workflow action attributes.</param>
        void AddWorkflowActionAttributes(params WorkflowActionAttribute[] workflowActionAttributes);
        /// <summary>
        /// Adds the workflow action attributes asynchronous.
        /// </summary>
        /// <param name="workflowActionAttributes">The workflow action attributes.</param>
        /// <returns>Task.</returns>
        Task AddWorkflowActionAttributesAsync(params WorkflowActionAttribute[] workflowActionAttributes);

        /// <summary>
        /// Updates the workflow action attributes.
        /// </summary>
        /// <param name="workflowActionAttributes">The workflow action attributes.</param>
        void UpdateWorkflowActionAttributes(params WorkflowActionAttribute[] workflowActionAttributes);
        /// <summary>
        /// Updates the workflow action attributes asynchronous.
        /// </summary>
        /// <param name="workflowActionAttributes">The workflow action attributes.</param>
        /// <returns>Task.</returns>
        Task UpdateWorkflowActionAttributesAsync(params WorkflowActionAttribute[] workflowActionAttributes);

        /// <summary>
        /// Removes the workflow action attributes.
        /// </summary>
        /// <param name="workflowActionAttributes">The workflow action attributes.</param>
        void RemoveWorkflowActionAttributes(params WorkflowActionAttribute[] workflowActionAttributes);
        /// <summary>
        /// Removes the workflow action attributes asynchronous.
        /// </summary>
        /// <param name="workflowActionAttributes">The workflow action attributes.</param>
        /// <returns>Task.</returns>
        Task RemoveWorkflowActionAttributesAsync(params WorkflowActionAttribute[] workflowActionAttributes);

        /// <summary>
        /// Gets the attribute types.
        /// </summary>
        /// <returns>IList&lt;AttributeTypeItem&gt;.</returns>
        IList<AttributeTypeItem> GetAttributeTypes();
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
    public partial class BusinessLayer : IWorkflowActionAttributeBL
    {
        #region workflowActionAttributes

        /// <summary>
        /// Gets all workflow action attributes.
        /// </summary>
        /// <returns>IList&lt;WorkflowActionAttribute&gt;.</returns>
        public IList<WorkflowActionAttribute> GetAllWorkflowActionAttributes()
        {
            return _unitOfWork.WorkflowActionAttributeRepository.GetAll();
        }

        /// <summary>
        /// get all workflow action attributes as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;WorkflowActionAttribute&gt;.</returns>
        public async Task<IList<WorkflowActionAttribute>> GetAllWorkflowActionAttributesAsync()
        {
            return await _unitOfWork.WorkflowActionAttributeRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the workflow action attributes.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;WorkflowActionAttribute&gt;.</returns>
        public IPagedList<WorkflowActionAttribute> SearchWorkflowActionAttributes(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<WorkflowActionAttribute>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _unitOfWork.WorkflowActionAttributeRepository.GetPagedList(page, pageSize, ParseJSONSearchString<WorkflowActionAttribute>(where), sortExpression, a => a.WorkflowAction);
        }

        /// <summary>
        /// search workflow action attributes as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;WorkflowActionAttribute&gt;.</returns>
        public async Task<IPagedList<WorkflowActionAttribute>> SearchWorkflowActionAttributesAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<WorkflowActionAttribute>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _unitOfWork.WorkflowActionAttributeRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<WorkflowActionAttribute>(where), sortExpression, a => a.WorkflowAction);
        }

        /// <summary>
        /// Gets the workflow action attribute by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>WorkflowActionAttribute.</returns>
        public WorkflowActionAttribute GetWorkflowActionAttributeById(int id)
        {
            return _unitOfWork.WorkflowActionAttributeRepository.GetSingle(a => a.Id == id, a => a.WorkflowAction);
        }

        /// <summary>
        /// get workflow action attribute by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>WorkflowActionAttribute.</returns>
        public async Task<WorkflowActionAttribute> GetWorkflowActionAttributeByIdAsync(int id)
        {
            return await _unitOfWork.WorkflowActionAttributeRepository.GetSingleAsync(a => a.Id == id, a => a.WorkflowAction);
        }

        /// <summary>
        /// Adds the workflow action attributes.
        /// </summary>
        /// <param name="workflowActionAttributes">The workflow action attributes.</param>
        public void AddWorkflowActionAttributes(params WorkflowActionAttribute[] workflowActionAttributes)
        {            
            _unitOfWork.WorkflowActionAttributeRepository.Add(workflowActionAttributes);            
            _unitOfWork.Save();
        }

        /// <summary>
        /// add workflow action attributes as an asynchronous operation.
        /// </summary>
        /// <param name="workflowActionAttributes">The workflow action attributes.</param>
        public async Task AddWorkflowActionAttributesAsync(params WorkflowActionAttribute[] workflowActionAttributes)
        {
            _unitOfWork.WorkflowActionAttributeRepository.Add(workflowActionAttributes);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the workflow action attributes.
        /// </summary>
        /// <param name="workflowActionAttributes">The workflow action attributes.</param>
        public void UpdateWorkflowActionAttributes(params WorkflowActionAttribute[] workflowActionAttributes)
        {            
            _unitOfWork.WorkflowActionAttributeRepository.Update(workflowActionAttributes);            
            _unitOfWork.Save();
        }

        /// <summary>
        /// update workflow action attributes as an asynchronous operation.
        /// </summary>
        /// <param name="workflowActionAttributes">The workflow action attributes.</param>
        public async Task UpdateWorkflowActionAttributesAsync(params WorkflowActionAttribute[] workflowActionAttributes)
        {
            _unitOfWork.WorkflowActionAttributeRepository.Update(workflowActionAttributes);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the workflow action attributes.
        /// </summary>
        /// <param name="workflowActionAttributes">The workflow action attributes.</param>
        public void RemoveWorkflowActionAttributes(params WorkflowActionAttribute[] workflowActionAttributes)
        {
            _unitOfWork.WorkflowActionAttributeRepository.Remove(workflowActionAttributes);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove workflow action attributes as an asynchronous operation.
        /// </summary>
        /// <param name="workflowActionAttributes">The workflow action attributes.</param>
        public async Task RemoveWorkflowActionAttributesAsync(params WorkflowActionAttribute[] workflowActionAttributes)
        {
            _unitOfWork.WorkflowActionAttributeRepository.Remove(workflowActionAttributes);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Gets the attribute types.
        /// </summary>
        /// <returns>IList&lt;AttributeTypeItem&gt;.</returns>
        public IList<AttributeTypeItem> GetAttributeTypes()
        {
            var result = new List<AttributeTypeItem>()
            {
                new AttributeTypeItem { Id = 0, Name = "None" },
                new AttributeTypeItem { Id = 1, Name = "Text"},
                new AttributeTypeItem { Id = 2, Name = "Number"},
                new AttributeTypeItem { Id = 3, Name = "Currency"},
                new AttributeTypeItem { Id = 4, Name = "Date"},
                new AttributeTypeItem { Id = 5, Name = "Time"},
                new AttributeTypeItem { Id = 6, Name = "DateTime"},
                new AttributeTypeItem { Id = 7, Name = "File"},
                new AttributeTypeItem { Id = 8, Name = "Url"},
                new AttributeTypeItem { Id = 9, Name = "Email"}
            };

            return result;
        }

        /// <summary>
        /// Gets the attribute directions.
        /// </summary>
        /// <returns>IList&lt;AttributeTypeItem&gt;.</returns>
        public IList<AttributeTypeItem> GetAttributeDirections()
        {
            var result = new List<AttributeTypeItem>()
            {
                new AttributeTypeItem { Id = 0, Name = "None" },
                new AttributeTypeItem { Id = 1, Name = "Input"},
                new AttributeTypeItem { Id = 2, Name = "Output"},
                new AttributeTypeItem { Id = 3, Name = "Both"}
            };

            return result;
        }

        #endregion
    }
}
