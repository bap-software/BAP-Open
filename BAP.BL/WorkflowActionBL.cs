// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 06-01-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-09-2020
// ***********************************************************************
// <copyright file="WorkflowActionBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using PagedList;

using BAP.Common;
using BAP.DAL;
using BAP.DAL.Entities;
using BAP.Log;
using System;
using System.Reflection;

namespace BAP.BL
{

    /// <summary>
    /// Class ActionTypeItem.
    /// </summary>
    public class ActionTypeItem
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
    /// Class ActionAttributesSupport.
    /// </summary>
    public class ActionAttributesSupport
    {
        /// <summary>
        /// Gets or sets a value indicating whether [attributes required].
        /// </summary>
        /// <value><c>true</c> if [attributes required]; otherwise, <c>false</c>.</value>
        public bool AttributesRequired { get; set; }
        /// <summary>
        /// Gets or sets the attributes json example.
        /// </summary>
        /// <value>The attributes json example.</value>
        public string AttributesJsonExample { get; set; }
    }

    /// <summary>
    /// Interface IWorkflowActionBL
    /// </summary>
    public interface IWorkflowActionBL
    {
        /// <summary>
        /// Gets all workflow actions.
        /// </summary>
        /// <returns>IList&lt;WorkflowAction&gt;.</returns>
        IList<WorkflowAction> GetAllWorkflowActions();
        /// <summary>
        /// Gets all workflow actions asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;WorkflowAction&gt;&gt;.</returns>
        Task<IList<WorkflowAction>> GetAllWorkflowActionsAsync();

        /// <summary>
        /// Searches the workflow actions.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;WorkflowAction&gt;.</returns>
        IPagedList<WorkflowAction> SearchWorkflowActions(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the workflow actions asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;WorkflowAction&gt;&gt;.</returns>
        Task<IPagedList<WorkflowAction>> SearchWorkflowActionsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Searches the workflow actions.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;WorkflowAction&gt;.</returns>
        IList<WorkflowAction> SearchWorkflowActions(string where, string sort);
        /// <summary>
        /// Searches the workflow actions asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>Task&lt;IList&lt;WorkflowAction&gt;&gt;.</returns>
        Task<IList<WorkflowAction>> SearchWorkflowActionsAsync(string where, string sort);

        /// <summary>
        /// Gets the workflow action by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>WorkflowAction.</returns>
        WorkflowAction GetWorkflowActionById(int id);
        /// <summary>
        /// Gets the workflow action by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;WorkflowAction&gt;.</returns>
        Task<WorkflowAction> GetWorkflowActionByIdAsync(int id);

        /// <summary>
        /// Adds the workflow actions.
        /// </summary>
        /// <param name="workflowActions">The workflow actions.</param>
        void AddWorkflowActions(params WorkflowAction[] workflowActions);
        /// <summary>
        /// Adds the workflow actions asynchronous.
        /// </summary>
        /// <param name="workflowActions">The workflow actions.</param>
        /// <returns>Task.</returns>
        Task AddWorkflowActionsAsync(params WorkflowAction[] workflowActions);

        /// <summary>
        /// Updates the workflow actions.
        /// </summary>
        /// <param name="workflowActions">The workflow actions.</param>
        void UpdateWorkflowActions(params WorkflowAction[] workflowActions);
        /// <summary>
        /// Updates the workflow actions asynchronous.
        /// </summary>
        /// <param name="workflowActions">The workflow actions.</param>
        /// <returns>Task.</returns>
        Task UpdateWorkflowActionsAsync(params WorkflowAction[] workflowActions);

        /// <summary>
        /// Removes the workflow actions.
        /// </summary>
        /// <param name="workflowActions">The workflow actions.</param>
        void RemoveWorkflowActions(params WorkflowAction[] workflowActions);
        /// <summary>
        /// Removes the workflow actions asynchronous.
        /// </summary>
        /// <param name="workflowActions">The workflow actions.</param>
        /// <returns>Task.</returns>
        Task RemoveWorkflowActionsAsync(params WorkflowAction[] workflowActions);

        /// <summary>
        /// Gets the action types.
        /// </summary>
        /// <returns>IList&lt;ActionTypeItem&gt;.</returns>
        IList<ActionTypeItem> GetActionTypes();

        /// <summary>
        /// Checks the attributes support.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>ActionAttributesSupport.</returns>
        ActionAttributesSupport CheckAttributesSupport(WorkflowAction action);
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
    public partial class BusinessLayer : IWorkflowActionBL
    {
        #region workflowActions

        /// <summary>
        /// Gets all workflow actions.
        /// </summary>
        /// <returns>IList&lt;WorkflowAction&gt;.</returns>
        public IList<WorkflowAction> GetAllWorkflowActions()
        {
            return _unitOfWork.WorkflowActionRepository.GetAll();
        }

        /// <summary>
        /// get all workflow actions as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;WorkflowAction&gt;.</returns>
        public async Task<IList<WorkflowAction>> GetAllWorkflowActionsAsync()
        {
            return await _unitOfWork.WorkflowActionRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the workflow actions.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;WorkflowAction&gt;.</returns>
        public IPagedList<WorkflowAction> SearchWorkflowActions(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<WorkflowAction>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _unitOfWork.WorkflowActionRepository.GetPagedList(page, pageSize, ParseJSONSearchString<WorkflowAction>(where), sortExpression, a => a.Workflow, a => a.Attributes);
        }

        /// <summary>
        /// search workflow actions as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;WorkflowAction&gt;.</returns>
        public async Task<IPagedList<WorkflowAction>> SearchWorkflowActionsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<WorkflowAction>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _unitOfWork.WorkflowActionRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<WorkflowAction>(where), sortExpression, a => a.Workflow, a => a.Attributes);
        }

        /// <summary>
        /// Searches the workflow actions.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;WorkflowAction&gt;.</returns>
        public IList<WorkflowAction> SearchWorkflowActions(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<WorkflowAction>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _unitOfWork.WorkflowActionRepository.GetList(ParseJSONSearchString<WorkflowAction>(where), sortExpression);
        }

        /// <summary>
        /// search workflow actions as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;WorkflowAction&gt;.</returns>
        public async Task<IList<WorkflowAction>> SearchWorkflowActionsAsync(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<WorkflowAction>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return await _unitOfWork.WorkflowActionRepository.GetListAsync(ParseJSONSearchString<WorkflowAction>(where), sortExpression);
        }

        /// <summary>
        /// Gets the workflow action by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>WorkflowAction.</returns>
        public WorkflowAction GetWorkflowActionById(int id)
        {
            return _unitOfWork.WorkflowActionRepository.GetSingle(a => a.Id == id, a => a.Workflow, a => a.Attributes);
        }

        /// <summary>
        /// get workflow action by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>WorkflowAction.</returns>
        public async Task<WorkflowAction> GetWorkflowActionByIdAsync(int id)
        {
            return await _unitOfWork.WorkflowActionRepository.GetSingleAsync(a => a.Id == id, a => a.Workflow, a => a.Attributes);
        }

        /// <summary>
        /// Adds the workflow actions.
        /// </summary>
        /// <param name="workflowActions">The workflow actions.</param>
        public void AddWorkflowActions(params WorkflowAction[] workflowActions)
        {            
            _unitOfWork.WorkflowActionRepository.Add(workflowActions);            
            _unitOfWork.Save();
        }

        /// <summary>
        /// add workflow actions as an asynchronous operation.
        /// </summary>
        /// <param name="workflowActions">The workflow actions.</param>
        public async Task AddWorkflowActionsAsync(params WorkflowAction[] workflowActions)
        {
            _unitOfWork.WorkflowActionRepository.Add(workflowActions);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the workflow actions.
        /// </summary>
        /// <param name="workflowActions">The workflow actions.</param>
        public void UpdateWorkflowActions(params WorkflowAction[] workflowActions)
        {            
            _unitOfWork.WorkflowActionRepository.Update(workflowActions);            
            _unitOfWork.Save();
        }

        /// <summary>
        /// update workflow actions as an asynchronous operation.
        /// </summary>
        /// <param name="workflowActions">The workflow actions.</param>
        public async Task UpdateWorkflowActionsAsync(params WorkflowAction[] workflowActions)
        {
            _unitOfWork.WorkflowActionRepository.Update(workflowActions);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the workflow actions.
        /// </summary>
        /// <param name="workflowActions">The workflow actions.</param>
        public void RemoveWorkflowActions(params WorkflowAction[] workflowActions)
        {
            _unitOfWork.WorkflowActionRepository.Remove(workflowActions);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove workflow actions as an asynchronous operation.
        /// </summary>
        /// <param name="workflowActions">The workflow actions.</param>
        public async Task RemoveWorkflowActionsAsync(params WorkflowAction[] workflowActions)
        {
            _unitOfWork.WorkflowActionRepository.Remove(workflowActions);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Gets the action types.
        /// </summary>
        /// <returns>IList&lt;ActionTypeItem&gt;.</returns>
        public IList<ActionTypeItem> GetActionTypes()
        {
            var result = new List<ActionTypeItem>
            {
                new ActionTypeItem { Id = 0, Name = "None" },
                new ActionTypeItem { Id = 1, Name = "Initialize"},
                new ActionTypeItem { Id = 2, Name = "Work"},
                new ActionTypeItem { Id = 3, Name = "Complete"},
                new ActionTypeItem { Id = 4, Name = "Cancel"}
            };

            return result;
        }

        /// <summary>
        /// Checks the attributes support.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>ActionAttributesSupport.</returns>
        public ActionAttributesSupport CheckAttributesSupport(WorkflowAction action)
        {
            ActionAttributesSupport result = new ActionAttributesSupport();
            if(action != null && !string.IsNullOrEmpty(action.ActionAssembly) && !string.IsNullOrEmpty(action.ActionClass))
            {
                try
                {
                    var assembly = Assembly.Load(action.ActionAssembly);
                    if (assembly != null)
                    {
                        var type = assembly.GetType(action.ActionClass);
                        if (type != null && typeof(IWorkflowAction).IsAssignableFrom(type))
                        {
                            object[] constructorParams = new object[5];
                            constructorParams[0] = _lookupEngine;
                            constructorParams[1] = _fileProcessor;
                            constructorParams[2] = _configHelper;
                            constructorParams[3] = _authContext;
                            constructorParams[4] = _logger;
                            
                            object classInstance = Activator.CreateInstance(type, constructorParams);
                            PropertyInfo property = type.GetProperty("RequireCustomAttributes");
                            if (property != null)
                            {
                                result.AttributesRequired = (bool)property.GetValue(classInstance, null);
                            }

                            if (result.AttributesRequired)
                            {
                                property = type.GetProperty("AttributesExampleJson");
                                if (property != null)
                                {
                                    result.AttributesJsonExample = property.GetValue(classInstance, null) as string;
                                }
                            }
                        }
                    }
                }
                catch(Exception exc)
                {
                    _logger.LogException("WorkflowActionBL", "CheckAttributesSupport", exc);
                }
            }
            return result;
        }

        #endregion
    }

    /// <summary>
    /// Class WorkflowActionBL.
    /// Implements the <see cref="BAP.BL.BusinessLayer" />
    /// Implements the <see cref="BAP.Common.ISupportLookup" />
    /// </summary>
    /// <seealso cref="BAP.BL.BusinessLayer" />
    /// <seealso cref="BAP.Common.ISupportLookup" />
    public class WorkflowActionBL : BusinessLayer, ISupportLookup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowActionBL"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public WorkflowActionBL(IConfigHelper settings, IAuthorizationContext context, ILogger logger) : base(settings, context, logger)
        {

        }

        #region ISupportLookup

        /// <summary>
        /// Gets the lookup items.
        /// </summary>
        /// <param name="valueField">The value field.</param>
        /// <param name="textField">The text field.</param>
        /// <param name="descriptionField">The description field.</param>
        /// <param name="extraFilter">The extra filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="roles">The roles.</param>
        /// <param name="setCurrentUserAsSelected">if set to <c>true</c> [set current user as selected].</param>
        /// <returns>IList&lt;LookupItem&gt;.</returns>
        public IList<LookupItem> GetLookupItems(string valueField, string textField, string descriptionField, string extraFilter, string orderBy, List<string> roles = null, bool setCurrentUserAsSelected = false)
        {
            List<LookupItem> result = new List<LookupItem>();
            var workflowActions = SearchWorkflowActions(extraFilter, orderBy);
            foreach (var controlType in workflowActions)
            {
                var val = controlType.GetType().GetProperty(valueField).GetValue(controlType, null);
                var text = controlType.GetType().GetProperty(textField).GetValue(controlType, null);
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = controlType.GetType().GetProperty(descriptionField).GetValue(controlType, null) ?? "";
                }
                result.Add(new LookupItem { Key = val.ToString(), Text = text.ToString(), Description = descr.ToString() });
            }

            return result;
        }

        /// <summary>
        /// get lookup items as an asynchronous operation.
        /// </summary>
        /// <param name="valueField">The value field.</param>
        /// <param name="textField">The text field.</param>
        /// <param name="descriptionField">The description field.</param>
        /// <param name="extraFilter">The extra filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="roles">The roles.</param>
        /// <param name="setCurrentUserAsSelected">if set to <c>true</c> [set current user as selected].</param>
        /// <returns>IList&lt;LookupItem&gt;.</returns>
        public async Task<IList<LookupItem>> GetLookupItemsAsync(string valueField, string textField, string descriptionField = "", string extraFilter = "",
            string orderBy = "", List<string> roles = null, bool setCurrentUserAsSelected = false)
        {
            List<LookupItem> result = new List<LookupItem>();
            var workflowActions = await SearchWorkflowActionsAsync(extraFilter, orderBy);
            foreach (var controlType in workflowActions)
            {
                var val = controlType.GetType().GetProperty(valueField).GetValue(controlType, null);
                var text = controlType.GetType().GetProperty(textField).GetValue(controlType, null);
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = controlType.GetType().GetProperty(descriptionField).GetValue(controlType, null) ?? "";
                }
                result.Add(new LookupItem { Key = val.ToString(), Text = text.ToString(), Description = descr.ToString() });
            }

            return result;
        }

        #endregion
    }
}
