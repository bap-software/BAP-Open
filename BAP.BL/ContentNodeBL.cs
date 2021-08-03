// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="ContentNodeBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedList;

using BAP.Common;
using BAP.DAL.Entities;

namespace BAP.BL
{
    /// <summary>
    /// Interface IContentNodeBL
    /// </summary>
    public interface IContentNodeBL
    {
        /// <summary>
        /// Determines whether [is any node].
        /// </summary>
        /// <returns><c>true</c> if [is any node]; otherwise, <c>false</c>.</returns>
        bool IsAnyNode();
        /// <summary>
        /// Determines whether [is any node asynchronous].
        /// </summary>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> IsAnyNodeAsync();

        /// <summary>
        /// Gets all content nodes.
        /// </summary>
        /// <returns>IList&lt;ContentNode&gt;.</returns>
        IList<ContentNode> GetAllContentNodes();
        /// <summary>
        /// Gets all content nodes asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;ContentNode&gt;&gt;.</returns>
        Task<IList<ContentNode>> GetAllContentNodesAsync();

        /// <summary>
        /// Searches the content nodes.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ContentNode&gt;.</returns>
        IPagedList<ContentNode> SearchContentNodes(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the content nodes asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;ContentNode&gt;&gt;.</returns>
        Task<IPagedList<ContentNode>> SearchContentNodesAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the home node.
        /// </summary>
        /// <returns>ContentNode.</returns>
        ContentNode GetHomeNode();
        /// <summary>
        /// Gets the home node asynchronous.
        /// </summary>
        /// <returns>Task&lt;ContentNode&gt;.</returns>
        Task<ContentNode> GetHomeNodeAsync();

        /// <summary>
        /// Gets the content node by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ContentNode.</returns>
        ContentNode GetContentNodeById(int id);
        /// <summary>
        /// Gets the content node by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ContentNode&gt;.</returns>
        Task<ContentNode> GetContentNodeByIdAsync(int id);

        /// <summary>
        /// Gets the single content node by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ContentNode.</returns>
        ContentNode GetSingleContentNodeById(int id);
        /// <summary>
        /// Gets the single content node by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ContentNode&gt;.</returns>
        Task<ContentNode> GetSingleContentNodeByIdAsync(int id);

        /// <summary>
        /// Gets the content node by alias.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <returns>ContentNode.</returns>
        ContentNode GetContentNodeByAlias(string alias);
        /// <summary>
        /// Gets the content node by alias asynchronous.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <returns>Task&lt;ContentNode&gt;.</returns>
        Task<ContentNode> GetContentNodeByAliasAsync(string alias);

        /// <summary>
        /// Gets the name of the content node by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>ContentNode.</returns>
        ContentNode GetContentNodeByName(string name);
        /// <summary>
        /// Gets the content node by name asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Task&lt;ContentNode&gt;.</returns>
        Task<ContentNode> GetContentNodeByNameAsync(string name);

        /// <summary>
        /// Gets the content node by controller.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="action">The action.</param>
        /// <param name="view">The view.</param>
        /// <returns>ContentNode.</returns>
        ContentNode GetContentNodeByController(string area, string controller, string action, string view);
        /// <summary>
        /// Gets the content node by controller asynchronous.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="action">The action.</param>
        /// <param name="view">The view.</param>
        /// <returns>Task&lt;ContentNode&gt;.</returns>
        Task<ContentNode> GetContentNodeByControllerAsync(string area, string controller, string action, string view);

        /// <summary>
        /// Gets the content node by route.
        /// </summary>
        /// <param name="routeUrl">The route URL.</param>
        /// <returns>ContentNode.</returns>
        ContentNode GetContentNodeByRoute(string routeUrl);
        /// <summary>
        /// Gets the content node by route asynchronous.
        /// </summary>
        /// <param name="routeUrl">The route URL.</param>
        /// <returns>Task&lt;ContentNode&gt;.</returns>
        Task<ContentNode> GetContentNodeByRouteAsync(string routeUrl);

        /// <summary>
        /// Gets the content node by view.
        /// </summary>
        /// <param name="viewPath">The view path.</param>
        /// <returns>ContentNode.</returns>
        ContentNode GetContentNodeByView(string viewPath);
        /// <summary>
        /// Gets the content node by view asynchronous.
        /// </summary>
        /// <param name="viewPath">The view path.</param>
        /// <returns>Task&lt;ContentNode&gt;.</returns>
        Task<ContentNode> GetContentNodeByViewAsync(string viewPath);

        /// <summary>
        /// Adds the content node.
        /// </summary>
        /// <param name="contentNodes">The content nodes.</param>
        void AddContentNode(params ContentNode[] contentNodes);
        /// <summary>
        /// Adds the content node asynchronous.
        /// </summary>
        /// <param name="contentNodes">The content nodes.</param>
        /// <returns>Task.</returns>
        Task AddContentNodeAsync(params ContentNode[] contentNodes);

        /// <summary>
        /// Updates the content node.
        /// </summary>
        /// <param name="contentNode">The content node.</param>
        void UpdateContentNode(ContentNode contentNode);
        /// <summary>
        /// Updates the content node asynchronous.
        /// </summary>
        /// <param name="contentNode">The content node.</param>
        /// <returns>Task.</returns>
        Task UpdateContentNodeAsync(ContentNode contentNode);

        /// <summary>
        /// Removes the content node.
        /// </summary>
        /// <param name="contentNodes">The content nodes.</param>
        void RemoveContentNode(params ContentNode[] contentNodes);
        /// <summary>
        /// Removes the content node asynchronous.
        /// </summary>
        /// <param name="contentNodes">The content nodes.</param>
        /// <returns>Task.</returns>
        Task RemoveContentNodeAsync(params ContentNode[] contentNodes);

        /// <summary>
        /// Removes the content node view by identifier.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="viewId">The view identifier.</param>
        void RemoveContentNodeViewById(ContentNode node, int viewId);
        /// <summary>
        /// Removes the content node view by identifier asynchronous.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="viewId">The view identifier.</param>
        /// <returns>Task.</returns>
        Task RemoveContentNodeViewByIdAsync(ContentNode node, int viewId);

        /// <summary>
        /// Adds the views.
        /// </summary>
        /// <param name="contentNode">The content node.</param>
        /// <param name="views">The views.</param>
        void AddViews(ContentNode contentNode, params ContentView[] views);
        /// <summary>
        /// Adds the views asynchronous.
        /// </summary>
        /// <param name="contentNode">The content node.</param>
        /// <param name="views">The views.</param>
        /// <returns>Task.</returns>
        Task AddViewsAsync(ContentNode contentNode, params ContentView[] views);

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
    public partial class BusinessLayer : IContentNodeBL, ILocalizedBL<ContentNode>
    {

        #region contentNodes

        /// <summary>
        /// Determines whether [is any node].
        /// </summary>
        /// <returns><c>true</c> if [is any node]; otherwise, <c>false</c>.</returns>
        public bool IsAnyNode()
        {
            return _unitOfWork.ContentNodeRepository.GetAll().Any();
        }

        /// <summary>
        /// is any node as an asynchronous operation.
        /// </summary>
        /// <returns><c>true</c> if [is any node asynchronous]; otherwise, <c>false</c>.</returns>
        public async Task<bool> IsAnyNodeAsync()
        {
            return await _unitOfWork.ContentNodeRepository.IsAnyAsync();
        }

        /// <summary>
        /// Gets all content nodes.
        /// </summary>
        /// <returns>IList&lt;ContentNode&gt;.</returns>
        public IList<ContentNode> GetAllContentNodes()
        {
            return _unitOfWork.ContentNodeRepository.GetAll(a => a.ParentNode, a => a.ChildNodes, a => a.Views);
        }

        /// <summary>
        /// get all content nodes as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;ContentNode&gt;.</returns>
        public async Task<IList<ContentNode>> GetAllContentNodesAsync()
        {
            return await _unitOfWork.ContentNodeRepository.GetAllAsync(a => a.ParentNode, a => a.ChildNodes, a => a.Views);
        }

        /// <summary>
        /// Searches the content nodes.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ContentNode&gt;.</returns>
        public IPagedList<ContentNode> SearchContentNodes(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<ContentNode>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _unitOfWork.ContentNodeRepository.GetPagedList(page, pageSize, ParseJSONSearchString<ContentNode>(where), sortExpression, a => a.ParentNode, a => a.ChildNodes, a => a.Views);
        }

        /// <summary>
        /// search content nodes as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ContentNode&gt;.</returns>
        public async Task<IPagedList<ContentNode>> SearchContentNodesAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<ContentNode>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _unitOfWork.ContentNodeRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<ContentNode>(where), sortExpression, a => a.ParentNode, a => a.ChildNodes, a => a.Views);
        }

        /// <summary>
        /// Gets the home node.
        /// </summary>
        /// <returns>ContentNode.</returns>
        public ContentNode GetHomeNode()
        {
            return _unitOfWork.ContentNodeRepository.GetSingle(a => a.IsHome, a => a.ChildNodes, a => a.Views);
        }

        /// <summary>
        /// get home node as an asynchronous operation.
        /// </summary>
        /// <returns>ContentNode.</returns>
        public async Task<ContentNode> GetHomeNodeAsync()
        {
            return await _unitOfWork.ContentNodeRepository.GetSingleAsync(a => a.IsHome, a => a.ChildNodes, a => a.Views);
        }

        /// <summary>
        /// Gets the content node by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ContentNode.</returns>
        public ContentNode GetContentNodeById(int id)
        {
            return _unitOfWork.ContentNodeRepository.GetSingle(a => a.Id == id, a => a.ParentNode, a => a.ChildNodes, a => a.Views);
        }

        /// <summary>
        /// get content node by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ContentNode.</returns>
        public async Task<ContentNode> GetContentNodeByIdAsync(int id)
        {
            return await _unitOfWork.ContentNodeRepository.GetSingleAsync(a => a.Id == id, a => a.ParentNode, a => a.ChildNodes, a => a.Views);
        }

        /// <summary>
        /// Gets the single content node by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ContentNode.</returns>
        public ContentNode GetSingleContentNodeById(int id)
        {
            return _unitOfWork.ContentNodeRepository.GetSingle(a => a.Id == id);
        }

        /// <summary>
        /// get single content node by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ContentNode.</returns>
        public async Task<ContentNode> GetSingleContentNodeByIdAsync(int id)
        {
            return await _unitOfWork.ContentNodeRepository.GetSingleAsync(a => a.Id == id);
        }

        /// <summary>
        /// Gets the content node by alias.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <returns>ContentNode.</returns>
        public ContentNode GetContentNodeByAlias(string alias)
        {
            return _unitOfWork.ContentNodeRepository.GetSingle(a => a.Alias.ToLower() == alias.ToLower(), a => a.ParentNode, a => a.ChildNodes, a => a.Views);
        }

        /// <summary>
        /// get content node by alias as an asynchronous operation.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <returns>ContentNode.</returns>
        public async Task<ContentNode> GetContentNodeByAliasAsync(string alias)
        {
            return await _unitOfWork.ContentNodeRepository.GetSingleAsync(a => a.Alias.ToLower() == alias.ToLower(), a => a.ParentNode, a => a.ChildNodes, a => a.Views);
        }

        /// <summary>
        /// Gets the name of the content node by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>ContentNode.</returns>
        public ContentNode GetContentNodeByName(string name)
        {
            return _unitOfWork.ContentNodeRepository.GetSingle(a => a.Name.ToLower() == name.ToLower(), a => a.ParentNode, a => a.ChildNodes, a => a.Views);
        }

        /// <summary>
        /// get content node by name as an asynchronous operation.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>ContentNode.</returns>
        public async Task<ContentNode> GetContentNodeByNameAsync(string name)
        {
            return await _unitOfWork.ContentNodeRepository.GetSingleAsync(a => a.Name.ToLower() == name.ToLower(), a => a.ParentNode, a => a.ChildNodes, a => a.Views);
        }

        /// <summary>
        /// Gets the content node by controller.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="action">The action.</param>
        /// <param name="view">The view.</param>
        /// <returns>ContentNode.</returns>
        public ContentNode GetContentNodeByController(string area, string controller, string action, string view)
        {
            return _unitOfWork.ContentNodeRepository.GetSingle(a => ((string.IsNullOrEmpty(area) && string.IsNullOrEmpty(a.Area)) || a.Area.Equals(area, StringComparison.InvariantCultureIgnoreCase)) && a.Controller == controller && a.Action == action && (string.IsNullOrEmpty(view) || a.View.Equals(view, StringComparison.InvariantCultureIgnoreCase)), a => a.ParentNode, a => a.Views);
        }

        /// <summary>
        /// get content node by controller as an asynchronous operation.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="action">The action.</param>
        /// <param name="view">The view.</param>
        /// <returns>ContentNode.</returns>
        public async Task<ContentNode> GetContentNodeByControllerAsync(string area, string controller, string action, string view)
        {
            return await _unitOfWork.ContentNodeRepository.GetSingleAsync(a => (string.IsNullOrEmpty(area) || a.Area == area) && a.Controller == controller && a.Action == action && (string.IsNullOrEmpty(view) || a.View.Equals(view, StringComparison.InvariantCultureIgnoreCase)), a => a.ParentNode, a => a.Views);
        }

        /// <summary>
        /// Gets the content node by route.
        /// </summary>
        /// <param name="routeUrl">The route URL.</param>
        /// <returns>ContentNode.</returns>
        public ContentNode GetContentNodeByRoute(string routeUrl)
        {
            return _unitOfWork.ContentNodeRepository.GetSingle(a => a.AliasPath.TrimStart("/".ToCharArray()) == routeUrl || a.RouteUrl == routeUrl, a => a.ParentNode, a => a.Views);
        }

        /// <summary>
        /// get content node by route as an asynchronous operation.
        /// </summary>
        /// <param name="routeUrl">The route URL.</param>
        /// <returns>ContentNode.</returns>
        public async Task<ContentNode> GetContentNodeByRouteAsync(string routeUrl)
        {
            return await _unitOfWork.ContentNodeRepository.GetSingleAsync(a => a.AliasPath.TrimStart("/".ToCharArray()) == routeUrl || a.RouteUrl == routeUrl, a => a.ParentNode, a => a.Views);
        }

        /// <summary>
        /// Gets the content node by view.
        /// </summary>
        /// <param name="viewPath">The view path.</param>
        /// <returns>ContentNode.</returns>
        public ContentNode GetContentNodeByView(string viewPath)
        {
            if (viewPath.IsNullOrEmpty())
                return null;

            var path = viewPath.Replace("~", "");
            return _unitOfWork.ContentNodeRepository.GetSingle(a => a.AliasPath == path || a.Views.Any(b => b.ViewPath == path), a => a.ParentNode, a => a.Views);
        }

        /// <summary>
        /// get content node by view as an asynchronous operation.
        /// </summary>
        /// <param name="viewPath">The view path.</param>
        /// <returns>ContentNode.</returns>
        public async Task<ContentNode> GetContentNodeByViewAsync(string viewPath)
        {
            if (viewPath.IsNullOrEmpty())
                return null;

            var path = viewPath.Replace("~", "");
            return await _unitOfWork.ContentNodeRepository.GetSingleAsync(a => a.AliasPath == path || a.Views.Any(b => b.ViewPath == path), a => a.ParentNode, a => a.Views);
        }

        /// <summary>
        /// Adds the content node.
        /// </summary>
        /// <param name="contentNodes">The content nodes.</param>
        public void AddContentNode(params ContentNode[] contentNodes)
        {
            foreach (var node in contentNodes)
            {
                if (node.Views != null && node.Views.Count > 0)
                {
                    foreach (var view in node.Views)
                    {
                        _unitOfWork.ContentViewRepository.InitEntityData(view);
                    }
                }
            }
            _unitOfWork.ContentNodeRepository.Add(contentNodes);
            _unitOfWork.FixEntityStates();
            _unitOfWork.Save();
        }

        /// <summary>
        /// add content node as an asynchronous operation.
        /// </summary>
        /// <param name="contentNodes">The content nodes.</param>
        public async Task AddContentNodeAsync(params ContentNode[] contentNodes)
        {
            foreach (var node in contentNodes)
            {
                if (node.Views != null && node.Views.Count > 0)
                {
                    foreach (var view in node.Views)
                    {
                        _unitOfWork.ContentViewRepository.InitEntityData(view);
                    }
                }
            }
            _unitOfWork.ContentNodeRepository.Add(contentNodes);
            _unitOfWork.FixEntityStates();
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the content node view by identifier.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="viewId">The view identifier.</param>
        public void RemoveContentNodeViewById(ContentNode node, int viewId)
        {
            var view = node.Views.SingleOrDefault(a => a.Id == viewId);
            if (view != null)
            {
                view.EntityState = BAPEntityState.Deleted;
                this.UpdateContentNode(node);
            }
        }

        /// <summary>
        /// remove content node view by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="viewId">The view identifier.</param>
        public async Task RemoveContentNodeViewByIdAsync(ContentNode node, int viewId)
        {
            var view = node.Views.SingleOrDefault(a => a.Id == viewId);
            if (view != null)
            {
                view.EntityState = BAPEntityState.Deleted;
                await this.UpdateContentNodeAsync(node);
            }
        }

        /// <summary>
        /// Adds the views.
        /// </summary>
        /// <param name="contentNode">The content node.</param>
        /// <param name="views">The views.</param>
        public void AddViews(ContentNode contentNode, params ContentView[] views)
        {
            if (contentNode == null || views == null || contentNode.Views == null)
                return;

            _unitOfWork.ContentNodeRepository.AttachIfDetached(contentNode);
            foreach (var view in views)
            {
                var stab = new ContentView
                {
                    ComplexDescription = view.ComplexDescription,
                    CreateDate = view.CreateDate,
                    CreatedBy = view.CreatedBy,
                    Enabled = view.Enabled,
                    EntityState = view.EntityState,
                    Id = view.Id,
                    IsLayout = view.IsLayout,
                    IsMain = view.IsMain,
                    IsPartial = view.IsPartial,
                    IsShared = view.IsShared,
                    LastModifiedBy = view.LastModifiedBy,
                    LastModifiedDate = view.LastModifiedDate,
                    LayoutPath = view.LayoutPath,
                    Name = view.Name,
                    OwnerGroup = view.OwnerGroup,
                    OwnerPermissions = view.OwnerPermissions,
                    Roles = view.Roles,
                    TenantUnit = view.TenantUnit,
                    TenantUnitId = view.TenantUnitId,
                    ViewContent = view.ViewContent,
                    ViewName = view.ViewName,
                    ViewPath = view.ViewPath
                };
                _unitOfWork.ContentViewRepository.AttachIfDetached(stab);
                contentNode.Views.Add(stab);
            }

            _unitOfWork.FixEntityStates();
            _unitOfWork.Save();
        }

        /// <summary>
        /// add views as an asynchronous operation.
        /// </summary>
        /// <param name="contentNode">The content node.</param>
        /// <param name="views">The views.</param>
        public async Task AddViewsAsync(ContentNode contentNode, params ContentView[] views)
        {
            if (contentNode == null || views == null || contentNode.Views == null)
                return;

            _unitOfWork.ContentNodeRepository.AttachIfDetached(contentNode);
            foreach (var view in views)
            {
                var stab = new ContentView
                {
                    ComplexDescription = view.ComplexDescription,
                    CreateDate = view.CreateDate,
                    CreatedBy = view.CreatedBy,
                    Enabled = view.Enabled,
                    EntityState = view.EntityState,
                    Id = view.Id,
                    IsLayout = view.IsLayout,
                    IsMain = view.IsMain,
                    IsPartial = view.IsPartial,
                    IsShared = view.IsShared,
                    LastModifiedBy = view.LastModifiedBy,
                    LastModifiedDate = view.LastModifiedDate,
                    LayoutPath = view.LayoutPath,
                    Name = view.Name,
                    OwnerGroup = view.OwnerGroup,
                    OwnerPermissions = view.OwnerPermissions,
                    Roles = view.Roles,
                    TenantUnit = view.TenantUnit,
                    TenantUnitId = view.TenantUnitId,
                    ViewContent = view.ViewContent,
                    ViewName = view.ViewName,
                    ViewPath = view.ViewPath
                };
                _unitOfWork.ContentViewRepository.AttachIfDetached(stab);
                contentNode.Views.Add(stab);
            }

            _unitOfWork.FixEntityStates();
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the content node.
        /// </summary>
        /// <param name="contentNode">The content node.</param>
        public void UpdateContentNode(ContentNode contentNode)
        {
            if (contentNode.Views != null)
            {
                foreach (var view in contentNode.Views)
                {
                    if (view.EntityState == BAPEntityState.Unchanged)
                        continue;

                    if (view.Id == 0)
                        _unitOfWork.ContentViewRepository.Add(view);
                    else if (view.EntityState == BAPEntityState.Modified)
                        _unitOfWork.ContentViewRepository.InitEntityData(view);
                }
            }
            _unitOfWork.ContentNodeRepository.Update(contentNode);

            _unitOfWork.ContentNodeRepository.DisallowModify(contentNode, "Name");
            _unitOfWork.ContentNodeRepository.DisallowModify(contentNode, "NavigationType");
            _unitOfWork.ContentNodeRepository.DisallowModify(contentNode, "Area");
            _unitOfWork.ContentNodeRepository.DisallowModify(contentNode, "Controller");
            _unitOfWork.ContentNodeRepository.DisallowModify(contentNode, "Action");
            _unitOfWork.ContentNodeRepository.DisallowModify(contentNode, "RouteUrl");

            _unitOfWork.FixEntityStates();
            _unitOfWork.Save();
        }

        /// <summary>
        /// update content node as an asynchronous operation.
        /// </summary>
        /// <param name="contentNode">The content node.</param>
        public async Task UpdateContentNodeAsync(ContentNode contentNode)
        {
            if (contentNode.Views != null)
            {
                foreach (var view in contentNode.Views)
                {
                    if (view.EntityState == BAPEntityState.Unchanged)
                        continue;

                    if (view.Id == 0)
                        _unitOfWork.ContentViewRepository.Add(view);
                    else if (view.EntityState == BAPEntityState.Modified)
                        _unitOfWork.ContentViewRepository.InitEntityData(view);
                }
            }
            _unitOfWork.ContentNodeRepository.Update(contentNode);

            _unitOfWork.ContentNodeRepository.DisallowModify(contentNode, "Name");
            _unitOfWork.ContentNodeRepository.DisallowModify(contentNode, "NavigationType");
            _unitOfWork.ContentNodeRepository.DisallowModify(contentNode, "Area");
            _unitOfWork.ContentNodeRepository.DisallowModify(contentNode, "Controller");
            _unitOfWork.ContentNodeRepository.DisallowModify(contentNode, "Action");
            _unitOfWork.ContentNodeRepository.DisallowModify(contentNode, "RouteUrl");

            _unitOfWork.FixEntityStates();
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the content node.
        /// </summary>
        /// <param name="contentNodes">The content nodes.</param>
        public void RemoveContentNode(params ContentNode[] contentNodes)
        {
            foreach (var node in contentNodes)
            {
                if (node.Views != null && node.Views.Count > 0)
                {
                    node.Views.ForEach(a => a.EntityState = BAPEntityState.Deleted);
                    _unitOfWork.ContentViewRepository.Remove(node.Views.ToArray());
                }

            }

            _unitOfWork.ContentNodeRepository.Remove(contentNodes);
            _unitOfWork.FixEntityStates();
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove content node as an asynchronous operation.
        /// </summary>
        /// <param name="contentNodes">The content nodes.</param>
        public async Task RemoveContentNodeAsync(params ContentNode[] contentNodes)
        {
            foreach (var node in contentNodes)
            {
                if (node.Views != null && node.Views.Count > 0)
                {
                    node.Views.ForEach(a => a.EntityState = BAPEntityState.Deleted);
                    _unitOfWork.ContentViewRepository.Remove(node.Views.ToArray());
                }

            }

            _unitOfWork.ContentNodeRepository.Remove(contentNodes);
            _unitOfWork.FixEntityStates();
            await _unitOfWork.SaveAsync();
        }

        #region ILocalizedBL
        /// <summary>
        /// Get full details of the single entity
        /// </summary>
        /// <param name="ofEntity">Passed entity is used as filter, method implementing ths feature should treat this oject apropriatly to call some method of BL class to read full details.</param>
        /// <returns>Entity instance</returns>
        public ContentNode GetDetails(ContentNode ofEntity)
        {
            if (ofEntity == null)
                return null;

            if (ofEntity.Id > 0)
                return GetContentNodeById(ofEntity.Id);
            
            return null;
        }

        /// <summary>
        /// Adds the single entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void AddSingleEntity(ContentNode entity)
        {
            _unitOfWork.ContentNodeRepository.Add(entity);
            _unitOfWork.Save();
        }
        #endregion

        #endregion
    }
}
