// ***********************************************************************
// Assembly         : BAP.ContentManagement
// Author           : Victor Mamray
// Created          : 07-06-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-20-2020
// ***********************************************************************
// <copyright file="CMSEngine.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Newtonsoft.Json;

using BAP.BL;
using BAP.Log;
using BAP.Common;
using BAP.Common.Exceptions;
using BAP.Common.Modules;
using BAP.ContentManagement.DesignComponents;
using BAP.ContentManagement.DesignerSettings;
using BAP.DAL;
using BAP.DAL.Entities;

namespace BAP.ContentManagement
{

    /// <summary>
    /// Class CurrentViewData.
    /// </summary>
    public class CurrentViewData
    {
        /// <summary>
        /// Gets or sets the view identifier.
        /// </summary>
        /// <value>The view identifier.</value>
        public int ViewId { get; set; }
        /// <summary>
        /// Gets or sets the content of the view.
        /// </summary>
        /// <value>The content of the view.</value>
        public string ViewContent { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is published.
        /// </summary>
        /// <value><c>true</c> if this instance is published; otherwise, <c>false</c>.</value>
        public bool IsPublished { get; set; }
    }

    /// <summary>
    /// Class CMSEngine.
    /// Implements the <see cref="BAP.Common.ISupportCustomConfig" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="BAP.Common.ISupportCustomConfig" />
    /// <seealso cref="System.IDisposable" />
    public class CMSEngine : ISupportCustomConfig, IDisposable
    {
        #region members and constants        
        /// <summary>
        /// The configuration helper
        /// </summary>
        private readonly IConfigHelper _configHelper;
        /// <summary>
        /// The authentication context
        /// </summary>
        private IAuthorizationContext _authContext;
        /// <summary>
        /// The content node bl
        /// </summary>
        private IContentNodeBL _contentNodeBL;
        /// <summary>
        /// The logger
        /// </summary>
        private ILogger _logger;
        /// <summary>
        /// The cache
        /// </summary>
        private ApplicationCache _cache;
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly CMSEngineConfig _config;
        /// <summary>
        /// The bl
        /// </summary>
        private readonly ICustomConfigurationBL _bl;
        /// <summary>
        /// The custom configuration
        /// </summary>
        private CustomConfiguration _customConfiguration;
        /// <summary>
        /// The maximum recently used controls count
        /// </summary>
        private readonly int _maxRecentlyUsedControlsCount = 5;

        private readonly string _menuCacheKey;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CMSEngine"/> class.
        /// </summary>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="authContext">The authentication context.</param>
        /// <param name="logger">The logger.</param>
        public CMSEngine(IConfigHelper configHelper, IAuthorizationContext authContext, ILogger logger)
        {
            _authContext = authContext;
            _configHelper = configHelper;
            _logger = logger;
            _contentNodeBL = new BusinessLayer(_configHelper, _authContext, _logger);
            _bl = new BusinessLayer(_configHelper, _authContext, _logger);
            _cache = new ApplicationCache(configHelper);
            var type = typeof(CMSEngine);
            try
            {
                _customConfiguration = _bl.GetCustomConfigurationByName($"{type.Assembly.GetName().Name}_{type.Name}");
            }
            catch (Exception e)
            {
                logger?.LogException(nameof(CMSEngine), "Ctor", e);
            }
            if (_customConfiguration != null && !string.IsNullOrWhiteSpace(_customConfiguration.CurrentConfiguration))
                _config = JsonConvert.DeserializeObject<CMSEngineConfig>(_customConfiguration.CurrentConfiguration);
            if (_config == null)
                _config = new CMSEngineConfig();

            _menuCacheKey = "APPLICATION_MENU_CACHE_KEY_" + (authContext?.GetCurrentUserFullName() ?? "public");
        }

        /// <summary>
        /// Gets the maximum recently used controls count.
        /// </summary>
        /// <value>The maximum recently used controls count.</value>
        public int MaxRecentlyUsedControlsCount
        {
            get
            {
                return _maxRecentlyUsedControlsCount;
            }
        }


        /// <summary>
        /// Gets the nodes cache key.
        /// </summary>
        /// <value>The nodes cache key.</value>
        protected string NodesCacheKey
        {
            get
            {
                return _config.NodesCacheKeyPrefix + _authContext?.GetCurrentOrganizationId(_configHelper).ToString();
            }
        }

        /// <summary>
        /// Gets the tree cache key.
        /// </summary>
        /// <value>The tree cache key.</value>
        protected string TreeCacheKey
        {
            get
            {
                return _config.TreeCacheKeyPrefix + _authContext.GetCurrentOrganizationId(_configHelper).ToString();
            }
        }

        /// <summary>
        /// Gets the base file folder.
        /// </summary>
        /// <value>The base file folder.</value>
        protected string BaseFileFolder
        {
            get
            {
                return HttpContext.Current.Server.MapPath(_config.BaseFileFolder);
            }
        }

        /// <summary>
        /// Gets a value indicating whether [supports custom configuration].
        /// </summary>
        /// <value><c>true</c> if [supports custom configuration]; otherwise, <c>false</c>.</value>
        public bool SupportsCustomConfig => true;

        /// <summary>
        /// Gets the custom configuration json example.
        /// </summary>
        /// <value>The custom configuration json example.</value>
        public string CustomConfigJsonExample => JsonConvert.SerializeObject(new CMSEngineConfig());

        /// <summary>
        /// Gets the type of the custom configuration.
        /// </summary>
        /// <value>The type of the custom configuration.</value>
        public Type CustomConfigType => typeof(CMSEngineConfig);

        /// <summary>
        /// Gets the current custom configuration json.
        /// </summary>
        /// <value>The current custom configuration json.</value>
        public string CurrentCustomConfigJson => _customConfiguration.CurrentConfiguration;

        /// <summary>
        /// Gets the menu.
        /// </summary>
        /// <returns>ModuleMenuNode[].</returns>
        public ModuleMenuNode[] GetMenu()
        {
            List<ModuleMenuNode> menu = (List<ModuleMenuNode>)_cache[_menuCacheKey];//new List<ModuleMenuNode>();     
            if(menu == null)
            {
                menu = new List<ModuleMenuNode>();     
                var contentNodes = GetAllContentNodes();
                if (contentNodes != null && contentNodes.Count > 0)
                {
                    ScanDataForMenu(contentNodes, menu);
                }
                _cache[_menuCacheKey] = menu;
            }
            
            return menu.ToArray();
        }

        /// <summary>
        /// Gets the content node.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="action">The action.</param>
        /// <param name="view">The view.</param>
        /// <returns>ContentNode.</returns>
        public ContentNode GetContentNode(string area, string controller, string action, string view)
        {
            var contentNode = _contentNodeBL.GetContentNodeByController(area, controller, action, view);
            return contentNode;
        }

        /// <summary>
        /// Gets the content node by URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public ContentNode GetContentNodeByUrl(string url)
        {
            var contentNode = _contentNodeBL.GetContentNodeByView(url);
            return contentNode;
        }

        /// <summary>
        /// Method to be used during run of RouteConfig. Iy may return replacement for the default route in the case we need some area to become home of the application.
        /// Data returned here cannot be changed during runtime. Restart of the application is required in order new home take place OR it has to be supplied along with
        /// new installation of the application.
        /// </summary>
        /// <returns>CMSRoute.</returns>
        public CMSRoute GetAnotherHomeRoute()
        {
            CMSRoute result = null;
            var contentNodes = GetAllContentNodes();
            if (contentNodes == null || contentNodes.Count == 0)
                return result;
            if (contentNodes.Any(a => a.IsHome && a.NavigationType == NavigationType.MvcRoute))
            {
                var homeNode = contentNodes.Where(a => a.IsHome && a.NavigationType == NavigationType.MvcRoute).First();
                if (homeNode != null)
                {
                    result = RouteFromNode(_config.DefaultNodeName, homeNode);
                    result.IsHome = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Views the exists.
        /// </summary>
        /// <param name="viewPath">The view path.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ViewExists(string viewPath)
        {
            if (viewPath.IsNullOrEmpty())
                return false;

            var view = GetViewByPath(viewPath);
            return view != null;

        }

        /// <summary>
        /// Views the content.
        /// </summary>
        /// <param name="viewPath">The view path.</param>
        /// <returns>System.String.</returns>
        public string ViewContent(string viewPath)
        {
            if (viewPath.IsNullOrEmpty())
                return null;

            var view = GetViewByPath(viewPath);
            if (view != null)
                return view.ViewContent ?? "";
            else
                return null;
        }

        /// <summary>
        /// Views the hash.
        /// </summary>
        /// <param name="viewPath">The view path.</param>
        /// <returns>System.Byte[].</returns>
        public byte[] ViewHash(string viewPath)
        {
            if (viewPath.IsNullOrEmpty())
                return null;

            var content = ViewContent(viewPath);
            RIPEMD160 hashAlgorythm = RIPEMD160Managed.Create();
            byte[] hashValue = null;
            using (Stream s = GenerateStreamFromString(content))
            {
                s.Position = 0;
                hashValue = hashAlgorythm.ComputeHash(s);
                s.Close();
            }
            return hashValue;
        }

        /// <summary>
        /// Aliases the present.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool AliasPresent(string alias)
        {
            return GetNodeByAlias(alias) != null;
        }

        /// <summary>
        /// Finds the node by alias.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <returns>ContentNode.</returns>
        public ContentNode FindNodeByAlias(string alias)
        {
            return GetNodeByAlias(alias);
        }

        /// <summary>
        /// Gets the tree.
        /// </summary>
        /// <param name="assebliesToScan">The asseblies to scan.</param>
        /// <returns>CMSNode.</returns>
        public CMSNode GetTree(List<Assembly> assebliesToScan = null)
        {
            CMSNode result = (CMSNode)_cache[TreeCacheKey];
            if (result != null)
                return result;

            // create root node
            var rootNode = new CMSNode
            {
                NodeId = -1,
                IsRoot = true,
                Title = Resources.Resources.UIText_WebSiteRoot,
                IsSerialized = false
            };
            rootNode.Children = new List<CMSNode>();

            // read content tree from DB
            var contentNodes = _contentNodeBL.GetAllContentNodes();
            if (contentNodes != null && contentNodes.Count > 0)
            {
                Dictionary<int, CMSNode> addedNodes = new Dictionary<int, CMSNode>();
                ScanData(rootNode, contentNodes, addedNodes);
            }
            
            var authHelper = new AuthorizationHelper<OrganizationUser>(_configHelper, _authContext);            
            // read extra data from assemblies here 
            var modulesNode = new CMSNode
            {
                NodeId = 0,
                Parent = rootNode,
                IsHome = false,
                IsSerialized = false,
                IsApplication = true,
                Title = Resources.Resources.UIText_ApplicationTitle,
                Expanded = false,
                Children = new List<CMSNode>(),
                Url = SiteUrl()
            };

            rootNode.Controllers = ScanForControllers(modulesNode, assebliesToScan);
            // allowed for Administrators and ContentManagers only
            if (_authContext.IsCurrentUserInRole(authHelper.BapAdminRoleName) || 
                _authContext.IsCurrentUserInRole(authHelper.BapContentManagerRoleName))
            {
                rootNode.Children.Add(modulesNode);
            }

            //Assosiate controllers with pages
            AssosiateControllers(rootNode);
            _cache[TreeCacheKey] = rootNode;

            return rootNode;
        }

        /// <summary>
        /// Gets the single node by identifier.
        /// </summary>
        /// <param name="nodeId">The node identifier.</param>
        /// <param name="assembliesToScan">The assemblies to scan.</param>
        /// <returns>CMSNode.</returns>
        public CMSNode GetSingleNodeById(int nodeId, List<Assembly> assembliesToScan)
        {
            var tree = GetTree(assembliesToScan);
            if (tree == null)
                return null;
           
            return FindCMSNodeByNodeId(tree, nodeId);
        }

        /// <summary>
        /// Updates the node action parameters values.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="valuesJson">The values json.</param>
        public void UpdateNodeActionParametersValues(ContentNode node, string valuesJson)
        {
            if (node == null || string.IsNullOrEmpty(valuesJson))
                return;

            node.ActionParams = valuesJson;
            _contentNodeBL.UpdateContentNode(node);
        }



        /// <summary>
        /// Updates the node settings.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="viewId">The view identifier.</param>
        /// <param name="pageTab">The page tab.</param>
        /// <param name="designGroup">The design group.</param>
        /// <param name="settingsPane">The settings pane.</param>
        /// <param name="controlUsed">The control used.</param>
        /// <param name="showDesignPane">if set to <c>true</c> [show design pane].</param>
        public void UpdateNodeSettings(ContentNode node, int viewId, string pageTab, string designGroup, string settingsPane, string controlUsed, bool? showDesignPane = null)
        {
            if (node == null)
                return;

            PageSettings settings = null;
            if (!string.IsNullOrEmpty(node.PageSettingsJson))
            {
                try
                {
                    settings = JsonConvert.DeserializeObject<PageSettings>(node.PageSettingsJson);
                }
                catch (Exception exc)
                {
                    _logger.LogException("ContentManagementController", "UpdateNodeSettings", exc);
                    settings = (new PageSettings()).Init();
                }
            }
            else
            {
                settings = (new PageSettings()).Init();
            }

            bool anythingChanged = false;
            if (!string.IsNullOrEmpty(designGroup))
            {
                settings.CurrentDesignGroup = designGroup;
                anythingChanged = true;
            }
            if (!string.IsNullOrEmpty(pageTab))
            {
                settings.CurrentPageTab = pageTab;
                anythingChanged = true;
            }
            if (!string.IsNullOrEmpty(settingsPane))
            {
                settings.CurrentSettingsPane = settingsPane;
                anythingChanged = true;
            }
            if (!string.IsNullOrEmpty(controlUsed))
            {
                if (settings.RecentlyUsedControls != null && settings.RecentlyUsedControls.Any())
                {
                    if (settings.RecentlyUsedControls.Any(a => a == controlUsed))
                    {
                        settings.RecentlyUsedControls.Remove(controlUsed);
                    }
                    else if (settings.RecentlyUsedControls.Count == MaxRecentlyUsedControlsCount)
                    {
                        settings.RecentlyUsedControls.Remove(settings.RecentlyUsedControls[settings.RecentlyUsedControls.Count - 1]);
                    }
                    var tmpList = new List<string>();
                    tmpList.Add(controlUsed);
                    tmpList.AddRange(settings.RecentlyUsedControls);
                    settings.RecentlyUsedControls = tmpList;
                }
                else
                {
                    if (settings.RecentlyUsedControls == null)
                        settings.RecentlyUsedControls = new List<string>();
                    settings.RecentlyUsedControls.Add(controlUsed);
                }
                anythingChanged = true;
            }

            if(showDesignPane.HasValue)
            {
                settings.ShowDesignPane = showDesignPane.Value;
                anythingChanged = true;
            }

            if (anythingChanged)
            {
                node.PageSettingsJson = JsonConvert.SerializeObject(settings);
                node.EntityState = BAPEntityState.Modified;
                _contentNodeBL.UpdateContentNode(node);
            }
        }
        /// <summary>
        /// Updates the node settings.
        /// </summary>
        /// <param name="nodeId">The node identifier.</param>
        /// <param name="viewId">The view identifier.</param>
        /// <param name="pageTab">The page tab.</param>
        /// <param name="designGroup">The design group.</param>
        /// <param name="settingsPane">The settings pane.</param>
        /// <param name="controlUsed">The control used.</param>
        /// <param name="showDesignPane">if set to <c>true</c> [show design pane].</param>
        public void UpdateNodeSettings(int nodeId, int viewId, string pageTab, string designGroup, string settingsPane, string controlUsed, bool? showDesignPane = null)
        {
            var node = _contentNodeBL.GetSingleContentNodeById(nodeId);
            UpdateNodeSettings(node, viewId, pageTab, designGroup, settingsPane, controlUsed, showDesignPane);
        }

        /// <summary>
        /// Assosiates the controllers.
        /// </summary>
        /// <param name="rootNode">The root node.</param>
        private void AssosiateControllers(CMSNode rootNode)
        {
            if (rootNode == null || rootNode.Controllers == null || !rootNode.Controllers.Any())
                return;

            AssosiateSngleNodeWithController(rootNode, rootNode);
        }
        /// <summary>
        /// Assosiates the sngle node with controller.
        /// </summary>
        /// <param name="rootNode">The root node.</param>
        /// <param name="currentNode">The current node.</param>
        void AssosiateSngleNodeWithController(CMSNode rootNode, CMSNode currentNode)
        {
            if (!currentNode.IsController && currentNode.Content != null && !string.IsNullOrEmpty(currentNode.Content.Controller))
            {
                var ctrl = rootNode.Controllers.SingleOrDefault(a => a.Name == currentNode.Content.Controller && a.Area == currentNode.Content.Area);
                if (ctrl != null)
                    currentNode.ThisController = ctrl;
            }
            if (currentNode.Children != null && currentNode.Children.Any())
            {
                foreach (var child in currentNode.Children)
                {
                    AssosiateSngleNodeWithController(rootNode, child);
                }
            }
        }

        /// <summary>
        /// Gets the view path.
        /// </summary>
        /// <param name="viewPath">The view path.</param>
        /// <param name="area">The area.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="action">The action.</param>
        /// <param name="view">The view.</param>
        /// <param name="url">The URL.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="BAPCmsException">User is not allowed to get any page view. Area: {area}, controller: {controller}, action: {action}, view: {view}, path: {viewPath}, url: {url}.</exception>
        public string GetViewPath(string viewPath, string area, string controller, string action, string view, string url)
        {
            var result = viewPath;
            var localViewName = view;
            if (localViewName.IsNullOrEmpty())
                localViewName = GetViewNameFromPath(viewPath);

            ContentNode node = null;
            if (!url.IsNullOrEmpty())
            {
                node = GetNodeByAlias(url);
                if (node != null && node.Action != action)
                    node = null;
            }

            bool foundByAlias = node != null;

            if (node == null)
                node = GetContentNodeByController(area, controller, action, localViewName);

            if (node != null && node.Views != null && node.Views.Any())
            {
                var roles = _authContext.GetCurrentRoleNames(_authContext.GetCurrentUserId(), _configHelper);
                // if view roles is empty - view is allowed, otherwise check if at least one current role is in list of view roles
                var allowedViews = node.Views.Where(v => string.IsNullOrEmpty(v.Roles) 
                    || v.Roles.Split(',').Any(r => roles.Any(r1 => r1.Equals(r, StringComparison.InvariantCultureIgnoreCase)))).ToList();

                // given role is not allowed to get any view - raising exception
                if (allowedViews == null || !allowedViews.Any())
                    throw new BAPCmsException($"User is not allowed to get any page view. Area: {area}, controller: {controller}, action: {action}, view: {view}, path: {viewPath}, url: {url}.");

                ContentView viewObj = null;
                if (view.IsNullOrEmpty() || foundByAlias)
                    viewObj = allowedViews.FirstOrDefault(a => a.Enabled && a.IsMain && !a.IsPartial);
                else
                    viewObj = allowedViews.FirstOrDefault(a => a.Enabled && a.ViewName.Equals(view, StringComparison.InvariantCultureIgnoreCase));

                if (viewObj != null)
                    result = viewObj.ViewPath;                
            }

            return result;
        }

        /// <summary>
        /// Gets the partial view path.
        /// </summary>
        /// <param name="viewPath">The view path.</param>
        /// <returns>System.String.</returns>
        public string GetPartialViewPath(string viewPath)
        {
            string result = viewPath;
            string localPath = viewPath.Replace("~", "");
            var viewName = GetViewNameFromPath(localPath);
            var node = GetAllContentNodes().SingleOrDefault(a => a.Views.Any(b => b.IsPartial && b.ViewName.ToLower() == viewName.ToLower()));
            if (node != null && node.Views != null)
            {
                var targetView = node.Views.SingleOrDefault(view => view.Enabled && view.IsPartial && view.Name.Equals(viewName, StringComparison.InvariantCultureIgnoreCase) && view.ComplexDescription.SourceViewPath.Equals(localPath, StringComparison.InvariantCultureIgnoreCase));
                if(targetView != null)                
                    result = targetView.ViewPath;                
            }
            return result;
        }

        /// <summary>
        /// Determines whether [is new static page] [the specified page name].
        /// </summary>
        /// <param name="pageName">Name of the page.</param>
        /// <returns><c>true</c> if [is new static page] [the specified page name]; otherwise, <c>false</c>.</returns>
        private bool IsNewStaticPage(string pageName)
        {
            if (string.IsNullOrEmpty(pageName))
                return false;

            var extensions = _config.StaticContentExtensions.Split(",".ToCharArray()).ToList();
            var nameParts = pageName.Split(".".ToCharArray()).ToList();
            return nameParts.Count > 1 && extensions.Any(a => a.Equals(nameParts[nameParts.Count - 1], StringComparison.InvariantCultureIgnoreCase));
        }

        public CMSNode AddNewFile(string name, CMSNode parent)
        {
            if (name.IsNullOrEmpty() || parent == null)
                return null;
            var startPath = parent.ViewPath;
            if (startPath.StartsWith("/Shared"))
                startPath = "/Views" + startPath;
            var filePath = FullViewFilePath(startPath + "/" + name + ".cshtml");
            File.WriteAllText(filePath, "<!-- Put your code and HTML here -->");
            var isLayout = name.ToLower().Contains("layout");
            var isPartial = !isLayout && name.StartsWith("_");

            var result = new CMSNode
            {
                IsApplication = true,
                IsLeaf = true,
                IsSerialized = false,
                Parent = parent,
                Title = name,
                Url = parent.ViewPath + "/" + name,
                ViewPath = filePath,
                IsPartialView = isPartial
            };
            parent.Children.Add(result);
            return result;
        }

        /// <summary>
        /// Adds the new node.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="parent">The parent.</param>
        /// <returns>CMSNode.</returns>
        public CMSNode AddNewNode(string name, CMSNode parent)
        {
            if (name.IsNullOrEmpty() || parent == null)
                return null;

            bool isStatic = IsNewStaticPage(name);
            bool isHome = !_contentNodeBL.IsAnyNode();
            string nodeName = GetUniqueName(name);
            string nodeAlias = isHome ? "" : GetUniqueAlias(isStatic ? name : NameToUrl(name));
            string aliasPath = isHome ? "/" : ((parent.Content != null ? parent.Content.AliasPath.TrimEnd("/".ToCharArray()) : "") + "/" + nodeAlias);

            string newAction = "Index"; 
            var actions = GetAavailableActions(parent);
            if (actions != null && actions.Contains("Content"))
                newAction = "Content";
            else
                newAction = (parent.Content != null) ? parent.Content.Action : "";
            var node = new CMSNode
            {
                Title = name,
                IsSerialized = false,
                IsLeaf = true,
                Parent = parent,
                Url = string.Format(_config.TempNodeUrlFormat, parent.Url, NameToUrl(name)),
                Content = new ContentNode
                {
                    Name = nodeName,
                    IsHome = isHome,
                    ParentNode = parent.Content,
                    ParentNodeId = (parent.Content != null) ? parent.Content.Id : 0,
                    Alias = nodeAlias,
                    AliasPath = aliasPath,
                    Rating = 1,
                    Enabled = true,
                    AllowChildren = !isStatic,
                    MenuCaption = name,
                    MenuClicable = true,
                    ShowInMenu = !isStatic,
                    ShowInSitemap = !isStatic,
                    Area = (parent.Content != null) ? parent.Content.Area : "",
                    Controller = (parent.Content != null) ? parent.Content.Controller : "",
                    Action = newAction,
                    NameSpaces = (parent.Content != null) ? parent.Content.NameSpaces : "",
                    LayoutPath = (parent.Content != null && !isStatic) ? parent.Content.LayoutPath : "",
                    Culture = (parent.Content != null) ? parent.Content.Culture : "",
                    DefaultCss = (parent.Content != null && !isStatic) ? parent.Content.DefaultCss : "",
                    Roles = (parent.Content != null) ? parent.Content.Roles : "",
                    NavigationType = isStatic ? NavigationType.StaticHtml : (parent.Content != null) ? parent.Content.NavigationType : NavigationType.MvcRoute,
                    SitemapPriority = SitemapPriority.Normal,
                    SitemapChangeFrequency = SitemapChangeFrequency.Monthly
                }
            };
            if (parent.Children == null)
                parent.Children = new List<CMSNode>();
            parent.Children.Add(node);

            return node;
        }

        private List<string> GetAavailableActions(CMSNode node)
        {
            if (node.Content == null || node.Content.NavigationType != NavigationType.MvcRoute || string.IsNullOrEmpty(node.Content.Controller))
                return null;

            List<string> result = null;
            var tmpNode = node;
            while(tmpNode.Parent != null)
            {
                tmpNode = tmpNode.Parent;
            }

            if(tmpNode.Controllers != null)
            {
                CMSController controller = null;
                if(node.Content.Area == null)
                    controller = tmpNode.Controllers.FirstOrDefault(a => string.IsNullOrEmpty(a.Area) && a.Name.Equals(node.Content.Controller));
                else
                    controller = tmpNode.Controllers.FirstOrDefault(a => a.Area.Equals(node.Content.Area, StringComparison.CurrentCultureIgnoreCase) && a.Name.Equals(node.Content.Controller));
                if (controller != null)
                    result = controller.Actions.Select(a => a.Name).ToList<string>();
            }

            return result;
        }

        /// <summary>
        /// Pulls the view data.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="viewId">The view identifier.</param>
        /// <returns>CurrentViewData.</returns>
        public CurrentViewData PullViewData(CMSNode node, int? viewId)
        {
            if (node == null)
                return null;

            CurrentViewData result = null;
            if (node.Content != null && node.Content.Views != null && node.Content.Views.Count > 0)
            {
                ContentView view = null;
                if (viewId != null)
                    view = node.Content.Views.FirstOrDefault(a => a.Id == viewId.Value);

                if (view == null)
                    view = node.Content.Views.FirstOrDefault(a => a.IsMain);

                if (view != null)
                {
                    result = new CurrentViewData
                    {
                        ViewId = view.Id,
                        ViewContent = view.ViewContent,
                        IsPublished = view.Enabled
                    };
                }
            }
            else
            {
                if (!node.ViewPath.IsNullOrEmpty() && File.Exists(node.ViewPath))
                {
                    result = new CurrentViewData
                    {
                        ViewContent = File.ReadAllText(node.ViewPath)
                    };
                }
            }
            return result;
        }

        /// <summary>
        /// Creates the new view.
        /// </summary>
        /// <param name="cmsNode">The CMS node.</param>
        /// <param name="newPageView">The new page view.</param>
        /// <param name="content">The content.</param>
        public void CreateNewView(CMSNode cmsNode, string newPageView, string content)
        {
            var viewName = newPageView;
            bool isPartial = viewName.StartsWith("_");
            var newView = new ContentView
            {
                Enabled = false,
                IsMain = false,
                IsPartial = isPartial,
                Name = viewName,
                ViewName = viewName,
                ViewPath = string.Format(_config.SaveContentViewPathFormat, cmsNode.Content.Controller, cmsNode.Content.Action, cmsNode.Content.View),
                EntityState = BAPEntityState.Added,
                ViewContent = content,
                ComplexDescription = new ContentViewDescription
                {
                    SourceViewPath = ""
                }
            };
            cmsNode.Content.Views.Add(newView);
            _contentNodeBL.UpdateContentNode(cmsNode.Content);
            ClearCache();
        }

        /// <summary>
        /// Publishes the view.
        /// </summary>
        /// <param name="cmsNode">The CMS node.</param>
        /// <param name="content">The content.</param>
        /// <param name="currentViewId">The current view identifier.</param>
        public void PublishView(CMSNode cmsNode, string content, int? currentViewId)
        {
            SaveContent(cmsNode, content, currentViewId, true);
        }

        /// <summary>
        /// Saves the content.
        /// </summary>
        /// <param name="cmsNode">The CMS node.</param>
        /// <param name="content">The content.</param>
        /// <param name="currentViewId">The current view identifier.</param>
        /// <param name="publish">if set to <c>true</c> [publish].</param>
        public void SaveContent(CMSNode cmsNode, string content, int? currentViewId, bool publish = false)
        {
            if (cmsNode == null)
                return;
            if (cmsNode.Content != null && cmsNode.Content.Views != null)
            {
                if (currentViewId != null && currentViewId.Value != 0)
                {
                    var view = cmsNode.Content.Views.SingleOrDefault(a => a.Id == currentViewId);
                    if (view != null)
                    {
                        view.ViewContent = content;
                        view.Enabled = publish;
                        view.EntityState = BAPEntityState.Modified;
                        _contentNodeBL.UpdateContentNode(cmsNode.Content);

                        BAPViewCacheDependencyManager.Instance.Invalidate(view.ViewPath);
                        ClearCache();
                    }
                }
                else if (cmsNode.Content.NavigationType == NavigationType.MvcRoute)
                {
                    if(cmsNode.Content.KeepViewFile)
                    {
                        File.WriteAllText(FullViewFilePath(cmsNode.ViewPath), content);
                    }
                    else
                    {
                        var viewName = $"{cmsNode.Content.Controller}-{cmsNode.Content.View}";
                        var layoutPath = GetLayoutPath(cmsNode.ViewPath);
                        var newView = new ContentView
                        {
                            Enabled = publish,
                            IsMain = true,
                            IsPartial = false,
                            LayoutPath = layoutPath,
                            Name = viewName,
                            ViewName = viewName,
                            ViewPath = string.Format(_config.SaveContentViewPathFormat, cmsNode.Content.Controller, cmsNode.Content.Action, cmsNode.Content.View),
                            ViewContent = content,
                            EntityState = BAPEntityState.Added,
                            ComplexDescription = new ContentViewDescription
                            {
                                SourceViewPath = cmsNode.ViewPath.Replace(BaseFileFolder, "")
                            }
                        };
                        cmsNode.Content.Views.Add(newView);
                        _contentNodeBL.UpdateContentNode(cmsNode.Content);
                    }
                    
                    ClearCache();
                }
            }
            else if (cmsNode.Content == null) // direct write to the original file view - to be used by Administrators only
            {
                File.WriteAllText(FullViewFilePath(cmsNode.ViewPath), content);
            }
        }

        /// <summary>
        /// Deletes the content.
        /// </summary>
        /// <param name="cmsNode">The CMS node.</param>
        /// <param name="currentViewId">The current view identifier.</param>
        public void DeleteContent(CMSNode cmsNode, int? currentViewId)
        {
            if (cmsNode == null || !currentViewId.HasValue || cmsNode.Content == null)
                return;
            var viewPath = string.Empty;
            var view = cmsNode.Content.Views.SingleOrDefault(a => a.Id == currentViewId);
            if (view != null)
            {
                viewPath = view.ViewPath;
            }
            _contentNodeBL.RemoveContentNodeViewById(cmsNode.Content, currentViewId.Value);
            if (!string.IsNullOrEmpty(viewPath))
            {
                BAPViewCacheDependencyManager.Instance.Invalidate(view.ViewPath);
            }
            ClearCache();
        }


        /// <summary>
        /// Saves the content settings.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <exception cref="BAPCmsException"></exception>
        public void SaveContentSettings(CMSNode node)
        {
            if (node == null || node.Content == null)
                return;

            ContentNode parentNode = null;
            if (node.Content.ParentNodeId.HasValue)
                parentNode = _contentNodeBL.GetContentNodeById(node.Content.ParentNodeId.Value);

            node.Content.ParentNode = null;
            node.Content.ChildNodes = null;
            if (!node.IsSerialized)
            {
                node.Content.IsHome = !_contentNodeBL.IsAnyNode();
                // get unique alias & name for the node
                node.Content.Alias = GetUniqueAlias(node.Content.Alias);
                node.Content.Name = GetUniqueName(node.Content.Name);

                // this is new page - it has to have it's own view - construction it's name and path           
                var viewName = "";
                var viewPath = "";
                var viewRelativePath = "";
                var sourceViewPath = "";
                var sourceViewFound = false;

                #region calculate paths
                if (node.Content.NavigationType == NavigationType.MvcRoute)
                {
                    viewName = !node.Content.View.IsNullOrEmpty() ? node.Content.View : (node.Content.Action + "-" + (node.Content.Alias.IsNullOrEmpty() ? NameToUrl(node.Content.Name) : node.Content.Alias));
                    viewPath = GetDefaultViewPath(node.Content.Area, node.Content.Controller, node.Content.Action, viewName);
                    viewRelativePath = viewPath.Replace(BaseFileFolder, "");
                    // trying to find view from which to clone view for the this new page
                    sourceViewPath = GetDefaultViewPath(node.Content.Area, node.Content.Controller, node.Content.Action, node.Content.View);
                    sourceViewFound = false;
                    if (!File.Exists(sourceViewPath))
                    {
                        sourceViewPath = GetDefaultViewPath(node.Content.Area, node.Content.Controller, node.Content.Action);
                        if (!File.Exists(sourceViewPath) && parentNode != null)
                        {
                            sourceViewPath = GetDefaultViewPath(parentNode);
                            sourceViewFound = File.Exists(sourceViewPath);
                        }
                        else
                        {
                            sourceViewFound = true;
                        }
                    }
                    else
                    {
                        sourceViewFound = true;
                    }
                }
                else if (node.Content.NavigationType == NavigationType.StaticHtml)
                {

                    if (parentNode == null)
                        parentNode = _contentNodeBL.GetHomeNode();

                    if (parentNode == null)
                        throw new BAPCmsException(Resources.Resources.ErrorText_NoStaticHtmlAllowed);

                    viewName = node.Content.Alias;
                    node.Content.Controller = parentNode.Controller;
                    node.Content.Action = "Content";
                    node.Content.View = node.Content.Alias;
                    node.Content.Area = parentNode.Area;
                    node.Content.NameSpaces = parentNode.NameSpaces;
                    viewRelativePath = "/";
                    if (!node.Content.Area.IsNullOrEmpty())
                        viewRelativePath += _config.AreasName + "/" + node.Content.Area + "/";
                    viewRelativePath += _config.ViewsName + "/" + node.Content.Controller + "/" + viewName + ".cshtml";
                }
                else if (node.Content.NavigationType == NavigationType.ExternalUrl)
                {
                    viewName = node.Content.Alias;
                    viewRelativePath = node.Content.AliasPath;
                }
                #endregion

                // init node view and save to DB
                if (node.Content.ParentNode == null && node.Content.ParentNodeId == 0)
                    node.Content.ParentNodeId = null;

                // assign values to View
                var layoutPath = sourceViewFound ? GetLayoutPath(sourceViewPath) : "";
                node.Content.View = viewName;
                if(node.Content.KeepViewFile)
                {
                    File.WriteAllText(FullViewFilePath(viewRelativePath), "@{ }\r\n<!--Put your HTML content here-->");
                }
                else
                {
                    node.Content.Views = new List<ContentView>();
                    var mainView = new ContentView
                    {
                        ContentNodes = new List<ContentNode>() { node.Content },
                        Enabled = true,
                        IsMain = true,
                        LayoutPath = layoutPath,
                        Name = viewName,
                        ViewName = viewName,
                        ViewPath = viewRelativePath,
                        EntityState = BAPEntityState.Added,
                        ComplexDescription = new ContentViewDescription
                        {
                            SourceViewPath = sourceViewPath.Replace(BaseFileFolder, "")
                        }
                    };
                    node.Content.Views.Add(mainView);

                    // read content of the base view provided in code
                    if (node.Content.NavigationType == NavigationType.MvcRoute && sourceViewFound)
                    {
                        mainView.ViewContent = File.ReadAllText(sourceViewPath);
                    }                    
                    BAPViewCacheDependencyManager.Instance.Invalidate(mainView.ViewPath);
                }
                // save to DB                    
                _contentNodeBL.AddContentNode(node.Content);
            }
            else
            {
                // only certain settings are saved - not allowed to change type of node, routing and alias settings                
                _contentNodeBL.UpdateContentNode(node.Content);
            }
            ClearCache();
        }

        private string FullViewFilePath(string relativeViewPath)
        {
            if (string.IsNullOrEmpty(relativeViewPath))
                throw new ArgumentException("Relative view file path cannot be empty");
            if (relativeViewPath.StartsWith(BaseFileFolder))
                return relativeViewPath;

            return Path.Combine(BaseFileFolder.TrimEnd('\\'), relativeViewPath.TrimStart('/').Replace("/", "\\"));
        }

        /// <summary>
        /// Assigns the extra views.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="currentViewId">The current view identifier.</param>
        public void AssignExtraViews(CMSNode node, int? currentViewId)
        {
            if (node == null || node.Content == null || !node.IsSerialized || node.Content.Views == null)
                return;

            var nodeViews = node.Content.Views;
            ContentView currentView = null;
            if (currentViewId.HasValue)
                currentView = nodeViews.SingleOrDefault(a => a.Id == currentViewId);
            if (currentView == null)
                currentView = nodeViews.FirstOrDefault(a => a.IsMain);
            if (currentView == null)
                return;

            var isAnyChange = false;
            //adding layout view first
            if (!currentView.IsLayout && !nodeViews.Any(a => a.IsLayout))
            {
                var layoutPath = currentView.LayoutPath;
                if (string.IsNullOrEmpty(layoutPath))
                    layoutPath = GetLayoutPath(BaseFileFolder + currentView.ComplexDescription.SourceViewPath);
                if (!string.IsNullOrEmpty(layoutPath))
                {
                    var layoutView = CreateLayoutView(layoutPath);
                    if (layoutView != null)
                    {
                        if (layoutView.ContentNodes == null)
                            layoutView.ContentNodes = new List<ContentNode>();

                        if (layoutView.EntityState == BAPEntityState.Added)
                        {
                            node.Content.Views.Add(layoutView);
                            _contentNodeBL.UpdateContentNode(node.Content);
                        }
                        else
                        {
                            _contentNodeBL.AddViews(node.Content, layoutView);
                        }
                        isAnyChange = true;
                    }
                }
            }

            // assigning others, it only makes sense if this is view cloned from file, so we can parse it to find other related files
            if (currentView.ComplexDescription != null && !string.IsNullOrEmpty(currentView.ComplexDescription.SourceViewPath))
            {
                var views = FindExtraViews(currentView.ViewContent, BaseFileFolder + currentView.ComplexDescription.SourceViewPath);
                if (views != null && views.Count > 0)
                {
                    /*var uniqueViews = views.Where(a => !nodeViews.Any(b => b.ViewPath == a.ViewPath)).ToArray();
					if(uniqueViews != null && uniqueViews.Length > 0)
					{
						_contentNodeBL.AddViews(node.Node, uniqueViews);
						isAnyChange = true;
					}*/

                    //TODO: has to be implved to work via one single call of AddViews
                    foreach (var view in views)
                    {
                        if (nodeViews.Any(a => a.ViewPath == view.ViewPath))
                            continue;

                        if (view.EntityState == BAPEntityState.Added)
                        {
                            node.Content.Views.Add(view);
                            _contentNodeBL.UpdateContentNode(node.Content);
                        }
                        else
                        {
                            _contentNodeBL.AddViews(node.Content, view);
                        }
                        isAnyChange = true;
                    }
                }
            }

            // if any changes done - clearing views cache
            if (isAnyChange)
                ClearCache();
        }

        /// <summary>
        /// Gets the layout path.
        /// </summary>
        /// <param name="viewPath">The view path.</param>
        /// <returns>System.String.</returns>
        private string GetLayoutPath(string viewPath)
        {
            var result = string.Empty;
            var finfo = new FileInfo(viewPath);
            var viewStartFile = finfo.Directory.FullName + _config.GetLayoutPathEnding;
            if (!File.Exists(viewStartFile))
                viewStartFile = viewPath;

            if (File.Exists(viewStartFile))
            {
                var lines = File.ReadAllLines(viewStartFile);
                var layoutPath = string.Empty;
                foreach (var line in lines)
                {
                    var tmp = line.Trim().Replace(" ", "");
                    if (tmp.Contains("Layout="))
                    {
                        if (!tmp.ToLower().Contains("layout=null;"))
                        {
                            var ext1 = tmp.IndexOf("Layout=\"") + 8;
                            var ext2 = tmp.IndexOf("\"", ext1);
                            layoutPath = tmp.Substring(ext1, ext2 - ext1).TrimStart("~".ToCharArray());
                        }
                        break;
                    }
                }

                result = layoutPath;
            }
            return result;
        }

        /// <summary>
        /// Creates the layout view.
        /// </summary>
        /// <param name="layoutViewPath">The layout view path.</param>
        /// <returns>ContentView.</returns>
        private ContentView CreateLayoutView(string layoutViewPath)
        {
            if (string.IsNullOrEmpty(layoutViewPath))
                return null;

            var layoutView = GetViewByPath(layoutViewPath);
            if (layoutView == null)
            {
                var fileInfo = new FileInfo(BaseFileFolder + layoutViewPath);
                layoutView = new ContentView
                {
                    Enabled = true,
                    IsLayout = true,
                    IsShared = true,
                    Name = fileInfo.Name.Replace(".cshtml", ""),
                    ViewName = fileInfo.Name.Replace(".cshtml", ""),
                    ViewPath = layoutViewPath,
                    ViewContent = File.ReadAllText(fileInfo.FullName),
                    EntityState = BAPEntityState.Added,
                    CreateDate = DateTime.Now,
                    ComplexDescription = new ContentViewDescription
                    {
                        SourceViewPath = layoutViewPath
                    }
                };
            }

            return layoutView;
        }

        /// <summary>
        /// Method to find extra view related to the given one
        /// </summary>
        /// <param name="viewContent">View content text</param>
        /// <param name="sourceFilePath">File path of the original view</param>
        /// <returns>List&lt;ContentView&gt;.</returns>
        private List<ContentView> FindExtraViews(string viewContent, string sourceFilePath)
        {
            List<ContentView> views = new List<ContentView>();
            // get partial views
            var finfo = new FileInfo(sourceFilePath);
            var searchStr = "@Html.Partial(\"";
            var startIndex = 0;
            while (startIndex < viewContent.Length && viewContent.IndexOf(searchStr, startIndex) > 0)
            {
                var ext1 = viewContent.IndexOf(searchStr, startIndex) + searchStr.Length;
                var ext2 = viewContent.IndexOf("\"", ext1);
                var partialPath = viewContent.Substring(ext1, ext2 - ext1).TrimStart("~".ToCharArray());
                if (!partialPath.IsNullOrEmpty())
                {
                    var tryPartialPath = partialPath.TrimStart("~".ToCharArray());
                    var i1 = partialPath.LastIndexOf("/");
                    var i2 = partialPath.LastIndexOf(".cshtml");
                    if (i1 == -1)
                    {
                        tryPartialPath = "";
                        i1 = 0;
                    }

                    if (i2 == -1)
                    {
                        tryPartialPath = "";
                        i2 = partialPath.Length;
                        partialPath += ".cshtml";
                    }

                    var viewName = partialPath.Substring(i1, i2 - i1);
                    if (tryPartialPath.IsNullOrEmpty())
                    {
                        tryPartialPath = finfo.Directory.FullName + "\\" + partialPath;
                        if (File.Exists(tryPartialPath))
                        {
                            partialPath = "/" + tryPartialPath.Replace(BaseFileFolder, "").Replace("\\", "/").TrimStart("/".ToCharArray());
                        }
                        else
                        {
                            tryPartialPath = finfo.Directory.FullName + "\\..\\Shared\\" + partialPath;
                            if (File.Exists(tryPartialPath))
                            {
                                partialPath = (new FileInfo(tryPartialPath)).FullName.Replace(BaseFileFolder, "").Replace("\\", "/");
                            }
                            else
                            {
                                partialPath = "";
                            }
                        }
                    }

                    if (!partialPath.IsNullOrEmpty())
                    {
                        var partialView = GetViewByPath(partialPath);
                        if (partialView != null)
                        {
                            views.Add(partialView);
                        }
                        else
                        {
                            views.Add(new ContentView
                            {
                                Enabled = true,
                                IsPartial = true,
                                IsShared = true,
                                Name = viewName,
                                ViewName = viewName,
                                ViewPath = partialPath,
                                ViewContent = File.ReadAllText(BaseFileFolder + partialPath),
                                EntityState = BAPEntityState.Added,
                                ComplexDescription = new ContentViewDescription
                                {
                                    SourceViewPath = partialPath
                                }
                            });
                        }
                    }
                }
                startIndex = ext2 + 1;
            }

            return views;
        }

        /// <summary>
        /// Removes the node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RemoveNode(CMSNode node)
        {
            if (node == null || node.Content == null)
                return false;
            node.Content.EntityState = BAPEntityState.Deleted;
            _contentNodeBL.RemoveContentNode(node.Content);
            return true;
        }

        /// <summary>
        /// Renames the node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="newName">The new name.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RenameNode(CMSNode node, string newName)
        {
            if (node == null || node.Content == null || string.IsNullOrEmpty(newName))
                return false;
            node.Content.Name = newName;
            node.Content.ContentTitle = newName;
            node.Title = newName;

            node.Content.EntityState = BAPEntityState.Modified;
            _contentNodeBL.UpdateContentNode(node.Content);
            return true;
        }

        /// <summary>
        /// Gets the design components.
        /// </summary>
        /// <param name="currentNode">The current node.</param>
        /// <returns>DesignComponentsCollection.</returns>
        public DesignComponentsCollection GetDesignComponents(CMSNode currentNode)
        {
            var contentCtrlBL = (IContentControlBL)_contentNodeBL;
            var controls = contentCtrlBL.GetAllContentControls();

            return new DesignComponentsCollection(currentNode, controls.Select(a => (IContentComponent)a).ToList(), _configHelper);
        }

        /// <summary>
        /// Determines whether [is relevant view path] [the specified view path].
        /// </summary>
        /// <param name="viewPath">The view path.</param>
        /// <returns><c>true</c> if [is relevant view path] [the specified view path]; otherwise, <c>false</c>.</returns>
        public bool IsRelevantViewPath(string viewPath)
        {
            return !viewPath.IsNullOrEmpty() && GetViewByPath(viewPath) != null;
        }

        #region private methods

        /// <summary>
        /// Generates the stream from string.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>Stream.</returns>
        private Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        /// <summary>
        /// Gets all content nodes.
        /// </summary>
        /// <returns>IList&lt;ContentNode&gt;.</returns>
        private IList<ContentNode> GetAllContentNodes()
        {
            IList<ContentNode> result = null;
            result = (IList<ContentNode>)_cache[NodesCacheKey];
            if (result == null)
            {
                result = _contentNodeBL.GetAllContentNodes();
                _cache[NodesCacheKey] = result;
            }

            return result;
        }

        /// <summary>
        /// Gets the node by alias.
        /// </summary>
        /// <param name="aliasPath">The alias path.</param>
        /// <returns>ContentNode.</returns>
        private ContentNode GetNodeByAlias(string aliasPath)
        {
            if (aliasPath.IsNullOrEmpty())
                return null;

            var alias = aliasPath.Replace("~", "").ToLower().TrimStart("/".ToCharArray());
            return GetAllContentNodes().FirstOrDefault(a => a.AliasPath.ToLower().TrimStart("/".ToCharArray()) == alias);
        }
        /// <summary>
        /// Gets the view by path.
        /// </summary>
        /// <param name="viewPath">The view path.</param>
        /// <returns>ContentView.</returns>
        private ContentView GetViewByPath(string viewPath)
        {
            if (viewPath.IsNullOrEmpty())
                return null;

            var path = viewPath.Replace("~", "");
            var node = GetAllContentNodes().FirstOrDefault(a => a.Views.Any(b => b.ViewPath.Replace("~", "") == path));
            if (node != null)
            {
                return node.Views.FirstOrDefault(a => a.ViewPath == path);
            }
            /*else
			{
				node = GetAllContentNodes().FirstOrDefault(a => a.AliasPath.ToLower() == path.ToLower());
				if(node != null)
				{
					return node.Views.FirstOrDefault(a => a.IsMain);
				}
			}*/
            return null;
        }

        /// <summary>
        /// Gets the content node by controller.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="action">The action.</param>
        /// <param name="view">The view.</param>
        /// <returns>ContentNode.</returns>
        private ContentNode GetContentNodeByController(string area, string controller, string action, string view)
        {
            if (!view.IsNullOrEmpty())
                return GetAllContentNodes().SingleOrDefault(a => ((string.IsNullOrEmpty(area) && string.IsNullOrEmpty(a.Area)) || a.Area == area) && a.Controller == controller && a.Action == action && (a.View.Equals(view, StringComparison.InvariantCultureIgnoreCase) || a.Views.Any(b => b.ViewName.Equals(view, StringComparison.InvariantCultureIgnoreCase))));
            else
                return GetAllContentNodes().SingleOrDefault(a => ((string.IsNullOrEmpty(area) && string.IsNullOrEmpty(a.Area)) || a.Area == area) && a.Controller == controller && a.Action == action);
        }

        /// <summary>
        /// Sites the URL.
        /// </summary>
        /// <returns>System.String.</returns>
        private string SiteUrl()
        {
            var Request = HttpContext.Current.Request;
            return Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/');
        }

        /// <summary>
        /// Parses the alias path.
        /// </summary>
        /// <param name="aliasPath">The alias path.</param>
        /// <param name="aliasFolder">The alias folder.</param>
        /// <param name="aliasFile">The alias file.</param>
        private void ParseAliasPath(string aliasPath, out string aliasFolder, out string aliasFile)
        {
            var tmp = aliasPath;
            aliasFile = tmp;
            aliasFolder = "";
            if (!tmp.EndsWith(".html"))
                tmp += ".html";

            tmp = tmp.Replace("/", "\\").TrimStart("\\".ToCharArray());
            var tmps = tmp.Split("\\".ToCharArray());
            var fileName = tmp;
            if (tmps.Length > 1)
            {
                aliasFolder = "\\" + tmp.Replace(tmps[tmps.Length - 1], "");
                fileName = tmps[tmps.Length - 1];
            }
        }

        /// <summary>
        /// Gets the unique alias.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <returns>System.String.</returns>
        private string GetUniqueAlias(string alias)
        {
            var isStatic = IsNewStaticPage(alias);
            var result = alias;
            var aliasExists = true;
            int index = 1;
            while (aliasExists)
            {
                var node = _contentNodeBL.GetContentNodeByAlias(result);
                if (node == null)
                {
                    aliasExists = false;
                }
                else
                {
                    if(isStatic)
                    {
                        var lastIndex = alias.LastIndexOf(".");
                        result = alias.Substring(0, lastIndex) + "." + index.ToString() + alias.Substring(lastIndex);
                    }
                    else
                    {
                        result = alias + "-" + index.ToString();
                    }
                        
                    index++;
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the name of the unique.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.String.</returns>
        private string GetUniqueName(string name)
        {
            var isStatic = IsNewStaticPage(name);
            var result = name;
            var aliasExists = true;
            int index = 1;
            while (aliasExists)
            {
                var node = _contentNodeBL.GetContentNodeByName(result);
                if (node == null)
                {
                    aliasExists = false;
                }
                else
                {
                    if (isStatic)
                    {
                        var lastIndex = name.LastIndexOf(".");
                        result = name.Substring(0, lastIndex) + "." + index.ToString() + name.Substring(lastIndex);
                    }
                    else
                    {
                        result = name + " " + index.ToString();
                    }
                        
                    index++;
                }
            }
            return result;
        }

        /// <summary>
        /// Names to URL.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.String.</returns>
        private string NameToUrl(string name)
        {
            return name.Replace(" ", "-").Replace(".", "-");
        }

        /// <summary>
        /// Routes from node.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="node">The node.</param>
        /// <returns>CMSRoute.</returns>
        private CMSRoute RouteFromNode(string name, ContentNode node)
        {
            if (node == null)
                return null;
            string[] namespaces = null;
            if (!node.NameSpaces.IsNullOrEmpty())
                namespaces = node.NameSpaces.Split(",".ToCharArray());
            string routeUrl = node.RouteUrl;
            if (!node.RouteUrl.IsNullOrEmpty())
                routeUrl = _config.DefaultRouteUrlFormat;

            // simple defaults object for a moment - need to have someting better based RouteUrl and ActionParams fields
            object defaults;
            if (routeUrl.Contains("{id}"))
                defaults = new { controller = node.Controller, action = node.Action, id = UrlParameter.Optional };
            else
                defaults = new { controller = node.Controller, action = node.Action };

            var route = new CMSRoute
            {
                Name = name,
                Url = routeUrl,
                Defaults = defaults,
                Namespaces = namespaces
            };
            if (!node.Area.IsNullOrEmpty())
            {
                route.DataTokens = new Dictionary<string, object>
                {
                    { "area", node.Area }
                };
            }

            return route;
        }

        /// <summary>
        /// Gets the view name from path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.String.</returns>
        private string GetViewNameFromPath(string path)
        {
            if (string.IsNullOrEmpty(path))
                return "";

            string[] parts = path.Split("/".ToCharArray());
            string[] names = parts[parts.Length - 1].Split(".".ToCharArray());
            return names[0];
        }

        /// <summary>
        /// Scans the data for menu.
        /// </summary>
        /// <param name="contentNodes">The content nodes.</param>
        /// <param name="menu">The menu.</param>
        /// <param name="nodesToProcess">The nodes to process.</param>
        /// <param name="processedNodes">The processed nodes.</param>
        /// <param name="parentNode">The parent node.</param>
        private void ScanDataForMenu(IList<ContentNode> contentNodes, List<ModuleMenuNode> menu, List<ContentNode> nodesToProcess = null, HashSet<ContentNode> processedNodes = null, ModuleMenuNode parentNode = null)
        {
            var childNodes = new List<ModuleMenuNode>();
            if (nodesToProcess == null)
                nodesToProcess = contentNodes.Where(a => a.ShowInMenu).ToList();
            if (nodesToProcess == null)
                return;
            if (processedNodes == null)
                processedNodes = new HashSet<ContentNode>();

            foreach (var contentNode in nodesToProcess)
            {
                if (processedNodes.Contains(contentNode))
                    continue;

                var menuNode = new ModuleMenuNode
                {
                    Clickable = contentNode.MenuClicable,
                    Description = contentNode.Description,
                    Icon = contentNode.MenuIcon,
                    IsAdmin = !contentNode.Roles.IsNullOrEmpty() && contentNode.Roles.ToLower().Contains("administrator"),
                    Title = contentNode.MenuCaption,
                    Target = contentNode.UrlTarget,
                    SortOrder = contentNode.MenuSortOrder,
                    HttpMethod = contentNode.HttpMethod,
                    Roles = !contentNode.Roles.IsNullOrEmpty() ? contentNode.Roles.Split(",".ToCharArray()) : null,
                    Url = contentNode.AliasPath,
                    Alias = contentNode.Alias
                };

                if (!contentNode.MenuExtraAttributes.IsNullOrEmpty())
                {
                    var pairs = contentNode.MenuExtraAttributes.Split("|".ToCharArray());
                    Dictionary<string, object> attributes = null;
                    foreach (var pair in pairs)
                    {
                        var pairParts = pair.Split("=".ToCharArray());
                        if (pairParts.Length == 2)
                        {
                            if (attributes == null)
                                attributes = new Dictionary<string, object>();
                            attributes.Add(pairParts[0], pairParts[1]);
                        }
                    }
                    if (attributes != null)
                        menuNode.HtmlAttributes = attributes;
                }

                if (contentNode.NavigationType == NavigationType.MvcRoute || contentNode.NavigationType == NavigationType.StaticHtml)
                {
                    menuNode.Area = contentNode.Area;
                    menuNode.Controller = contentNode.Controller;
                    menuNode.Action = contentNode.Action;

                    if (contentNode.NavigationType == NavigationType.StaticHtml)
                        menuNode.Action += "_" + contentNode.Alias;

                    if (!contentNode.RouteUrl.IsNullOrEmpty() && contentNode.RouteUrl.Contains("{id}"))
                        menuNode.PreservedRouteParameters = new List<string> { "id" };

                }
                else
                {
                    menuNode.Url = contentNode.AliasPath;
                }

                if (parentNode != null)
                {
                    childNodes.Add(menuNode);
                }
                else
                {
                    menu.Add(menuNode);
                }

                processedNodes.Add(contentNode);
                if (contentNodes.Any(a => a.ParentNodeId == contentNode.Id && a.ShowInMenu))
                {
                    var thisChildNodes = contentNodes.Where(a => a.ParentNodeId == contentNode.Id && a.ShowInMenu);
                    ScanDataForMenu(contentNodes, menu, thisChildNodes.ToList(), processedNodes, menuNode);
                }
            }

            if (parentNode != null)
            {
                parentNode.ChildNodes = childNodes.ToArray();
            }
        }

        /// <summary>
        /// Scans the data.
        /// </summary>
        /// <param name="rootNode">The root node.</param>
        /// <param name="nodes">The nodes.</param>
        /// <param name="addedNodes">The added nodes.</param>
        private void ScanData(CMSNode rootNode, IList<ContentNode> nodes, Dictionary<int, CMSNode> addedNodes)
        {
            foreach (var node in nodes)
            {
                if (addedNodes.Any(a => a.Key == node.Id))
                {
                    continue;
                }

                var parentNode = rootNode;
                if (node.ParentNode != null)
                {
                    parentNode = GetParentNodeFromData(node.ParentNode.Id, nodes, addedNodes, rootNode);
                }

                var cmsNode = new CMSNode
                {
                    NodeId = node.Id,
                    Content = node,
                    IsSerialized = true,
                    Parent = parentNode,
                    Title = node.Name,
                    Url = node.AliasPath,
                    IsLeaf = true,
                    ViewPath = GetDefaultViewPath(node)
                };

                addedNodes.Add(node.Id, cmsNode);
                parentNode.Children.Add(cmsNode);
            }
        }

        /// <summary>
        /// Gets the default view path.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="action">The action.</param>
        /// <param name="view">The view.</param>
        /// <param name="extension">The extension.</param>
        /// <returns>System.String.</returns>
        private string GetDefaultViewPath(string area, string controller, string action, string view = "", string extension = ".cshtml")
        {
            string result = BaseFileFolder;
            if (!string.IsNullOrEmpty(area))
                result += "/" + _config.AreasName + "/" + area;
            result += "/" + _config.ViewsName + "/" + controller + "/";
            if (!view.IsNullOrEmpty())
                result += view + extension;
            else
                result += action + extension;

            return result;
        }

        /// <summary>
        /// Gets the default view path.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>System.String.</returns>
        private string GetDefaultViewPath(ContentNode node)
        {
            string result = "";

            if (node.Views != null && node.Views.Any(a => a.IsMain))
            {
                var view = node.Views.Where(a => a.IsMain).First();
                result = BaseFileFolder + view.ViewPath;
            }
            else if (node.NavigationType == NavigationType.MvcRoute)
                result = GetDefaultViewPath(node.Area, node.Controller, node.Action, node.View);

            return result;
        }

        /// <summary>
        /// Gets the parent node from data.
        /// </summary>
        /// <param name="parentNodeId">The parent node identifier.</param>
        /// <param name="nodes">The nodes.</param>
        /// <param name="addedNodes">The added nodes.</param>
        /// <param name="rootNode">The root node.</param>
        /// <returns>CMSNode.</returns>
        private CMSNode GetParentNodeFromData(int parentNodeId, IList<ContentNode> nodes, Dictionary<int, CMSNode> addedNodes, CMSNode rootNode)
        {
            CMSNode result = null;
            if (addedNodes.ContainsKey(parentNodeId))
            {
                result = addedNodes[parentNodeId];
                if (result.Children == null)
                {
                    result.Children = new List<CMSNode>();
                }
                result.IsLeaf = false;
            }
            else
            {
                CMSNode parent = rootNode;
                var node = nodes.SingleOrDefault(a => a.Id == parentNodeId);
                if (node.ParentNode != null)
                {
                    parent = GetParentNodeFromData(node.ParentNode.Id, nodes, addedNodes, rootNode);
                }

                var parentNode = new CMSNode
                {
                    NodeId = node.Id,
                    Content = node,
                    IsSerialized = true,
                    Parent = parent,
                    Title = node.Name,
                    Url = node.AliasPath,
                    IsLeaf = false,
                    Children = new List<CMSNode>()
                };
                if (parent.Children == null)
                {
                    parent.Children = new List<CMSNode>();
                }
                parent.Children.Add(parentNode);
                addedNodes.Add(parentNodeId, parentNode);
                result = parentNode;
            }

            return result;
        }

        /// <summary>
        /// Scans for controllers.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="assebliesToScan">The asseblies to scan.</param>
        /// <returns>List&lt;CMSController&gt;.</returns>
        private List<CMSController> ScanForControllers(CMSNode parent, List<Assembly> assebliesToScan)
        {
            List<CMSController> result = null;
            //before assemblies scan - do shared views scan
            var sharedViewsPath = HttpContext.Current.Server.MapPath(@"/Views/Shared");
            if (Directory.Exists(sharedViewsPath))
            {
                var sharedNode = new CMSNode
                {
                    IsApplication = true,
                    Parent = parent,
                    Title = "Shared",
                    IsSerialized = false,
                    Children = new List<CMSNode>(),
                    Url = parent.Url + "/",
                    ViewPath = "/Shared"
                };
                parent.Children.Add(sharedNode);

                var viewFiles = Directory.GetFiles(sharedViewsPath, "*.cshtml", SearchOption.AllDirectories);
                foreach (var filePath in viewFiles)
                {
                    if (!parent.Children.Any(a => a.ViewPath.ToLower() == filePath.ToLower()))
                    {
                        var fInfo = new FileInfo(filePath);
                        var viewNode = new CMSNode
                        {
                            IsApplication = true,
                            IsLeaf = true,
                            IsSerialized = false,
                            Parent = sharedNode,
                            Title = fInfo.Name.Replace(fInfo.Extension, ""),
                            Url = sharedNode.Url + "/" + fInfo.Name.Replace(fInfo.Extension, ""),
                            ViewPath = fInfo.FullName,
                            IsPartialView = fInfo.Name.StartsWith("_")
                        };
                        sharedNode.Children.Add(viewNode);
                    }
                }
            }

            if (assebliesToScan != null)
            {
                result = new List<CMSController>();
                // loop over assemblies
                foreach (var assembly in assebliesToScan)
                {
                    try
                    {
                        var type = typeof(Controller);
                        var types = assembly.GetTypes().Where(p => type.IsAssignableFrom(p)).ToArray();
                        if (types.Length == 0)
                            continue;

                        // loop over controllers of the given assembly
                        foreach (var ctrl in types)
                        {
                            // if not allowed for content management - bypass
                            var ctrlAllowedAttribute = ctrl.GetCustomAttributes(typeof(ContentManagementAttribute), true).Cast<ContentManagementAttribute>().FirstOrDefault();
                            if (ctrlAllowedAttribute != null && !ctrlAllowedAttribute.Allowed)
                                continue;

                            var controllerParentNode = parent;
                            var nameParts = ctrl.FullName.Split(".".ToCharArray());
                            var areaName = "";
                            if (nameParts.Any(a => a == _config.AreasName) || nameParts.Any(a => a.EndsWith("Plugin")))
                            {
                                controllerParentNode = GetParentNodeFromAreas(ctrl.FullName, parent);
                                // some strange controller - cannot add then
                                if (controllerParentNode == null)
                                    continue;

                                areaName = controllerParentNode.Title;

                                // get shared folder content of the area
                                var sharedTitle = controllerParentNode.Title + " Shared";
                                if (!controllerParentNode.Children.Any(a => a.Title == sharedTitle))
                                {
                                    var areaSharedViewsPath = HttpContext.Current.Server.MapPath(controllerParentNode.ViewPath + "/Views/Shared");
                                    if (Directory.Exists(areaSharedViewsPath))
                                    {
                                        var sharedNode = new CMSNode
                                        {
                                            IsApplication = true,
                                            Parent = controllerParentNode,
                                            Title = sharedTitle,
                                            IsSerialized = false,
                                            Children = new List<CMSNode>(),
                                            Url = controllerParentNode.Url + "/",
                                            ViewPath = controllerParentNode.ViewPath + "/Shared"
                                        };
                                        controllerParentNode.Children.Add(sharedNode);

                                        var viewFiles = Directory.GetFiles(areaSharedViewsPath, "*.cshtml", SearchOption.AllDirectories);
                                        foreach (var filePath in viewFiles)
                                        {
                                            if (!parent.Children.Any(a => a.ViewPath.ToLower() == filePath.ToLower()))
                                            {
                                                var fInfo = new FileInfo(filePath);
                                                var viewNode = new CMSNode
                                                {
                                                    IsApplication = true,
                                                    IsLeaf = true,
                                                    IsSerialized = false,
                                                    Parent = sharedNode,
                                                    Title = fInfo.Name.Replace(fInfo.Extension, ""),
                                                    Url = sharedNode.Url + "/" + fInfo.Name.Replace(fInfo.Extension, ""),
                                                    ViewPath = fInfo.FullName,
                                                    IsPartialView = fInfo.Name.StartsWith("_")
                                                };
                                                sharedNode.Children.Add(viewNode);
                                            }
                                        }
                                    }
                                }
                            }

                            // adding actual controller's node
                            var controllerNode = new CMSNode
                            {
                                IsController = true,
                                IsSerialized = false,
                                IsApplication = true,
                                Children = new List<CMSNode>(),
                                Parent = controllerParentNode,
                                Title = ctrl.Name.Replace("Controller", ""),
                                Expanded = false,
                                Url = controllerParentNode.Url + "/" + ctrl.Name.Replace("Controller", ""),
                                ViewPath = controllerParentNode.ViewPath + "/" +_config.ViewsName + "/" + ctrl.Name.Replace("Controller", "")
                            };

                            var cmsController = new CMSController
                            {
                                Name = ctrl.Name.Replace("Controller", ""),
                                Area = areaName,
                                Namespace = ctrl.Namespace,
                                IsContentExtendable = ctrl.GetInterfaces().Any(a => a == typeof(IContentExtendable)),
                                Actions = new List<CMSAction>(),
                                ControllerClassType = ctrl
                            };

                            //Identifiing whether it's BAP entity controller
                            if (ctrl.BaseType != null && ctrl.BaseType.IsConstructedGenericType)
                            {
                                var isBap = (ctrl.BaseType.GenericTypeArguments != null && ctrl.BaseType.GenericTypeArguments.Any(a => a.GetInterfaces().Any(b => b == typeof(IBapEntity))));
                                if (isBap)
                                {
                                    var entityType = ctrl.BaseType.GenericTypeArguments.SingleOrDefault(a => a.GetInterfaces().Any(b => b == typeof(IBapEntity)));
                                    if (entityType != null)
                                    {
                                        cmsController.BapEntityType = entityType;
                                        if (entityType.GetInterfaces().Any(a => a == typeof(IEntityContent)))
                                        {
                                            var entityObject = Activator.CreateInstance(entityType) as IEntityContent;
                                            if (entityObject != null)
                                            {
                                                cmsController.EntityDetailsCustomizable = entityObject.DetailsCustomized;
                                                cmsController.EntityListCustomizable = entityObject.ListCustomized;
                                            }
                                        }
                                    }
                                }
                            }
                            //Assign controller to CMSNode
                            controllerNode.ThisController = cmsController;


                            // loop over methods of the controller
                            var actionMethods = ctrl.GetMethods().Where(method => method.IsPublic && !method.IsDefined(typeof(NonActionAttribute)));
                            var firstMethod = "";
                            foreach (var method in actionMethods)
                            {
                                // we do not care about system method
                                if (method.Name == _config.SystemMethodName)
                                    continue;

                                // we take care of real action methods only
                                if (!(method.ReturnType.IsAssignableFrom(typeof(ActionResult)) || method.ReturnType.IsAssignableFrom(typeof(Task<ActionResult>))))
                                    continue;

                                // we take of GET methods only
                                var httpMethodAttribute = method.GetCustomAttributes(typeof(ActionMethodSelectorAttribute), true).Cast<ActionMethodSelectorAttribute>().FirstOrDefault();
                                if (httpMethodAttribute != null && (httpMethodAttribute is HttpPostAttribute || httpMethodAttribute is HttpPutAttribute || httpMethodAttribute is HttpDeleteAttribute))
                                    continue;

                                // if not allowed for content management - bypass
                                var allowedAttribute = method.GetCustomAttributes(typeof(ContentManagementAttribute), true).Cast<ContentManagementAttribute>().FirstOrDefault();
                                if (allowedAttribute != null && !allowedAttribute.Allowed)
                                    continue;

                                // identifying local path of the view joined with this action
                                var viewPath = BaseFileFolder + controllerNode.ViewPath + "/" + method.Name + ".cshtml";
                                // if no file exists - no sense to show such action, this can be some service action which does not have visual presentation
                                // and that could be even dangerous to show such action
                                if (!File.Exists(viewPath))
                                    continue;

                                var actionNode = new CMSNode
                                {
                                    IsApplication = true,
                                    IsLeaf = true,
                                    IsSerialized = false,
                                    Parent = controllerNode,
                                    Title = method.Name,
                                    Url = controllerNode.Url + "/" + method.Name,
                                    ViewPath = FixFilePath(viewPath)
                                };
                                controllerNode.Children.Add(actionNode);

                                var cmsAction = new CMSAction
                                {
                                    Name = method.Name,
                                    Controller = cmsController,
                                    Parameters = method.GetParameters()//these have to be used to build popup to ask for values                                    
                                };
                                cmsAction.HasParameters = cmsAction.Parameters != null && cmsAction.Parameters.Length > 0;                               
                                cmsController.Actions.Add(cmsAction);

                                if (firstMethod.IsNullOrEmpty())
                                    firstMethod = method.Name;
                            }
                            // looking extra view files in controller's view folder
                            var controllerViewFolder = FixDirectoryPath(BaseFileFolder + controllerNode.ViewPath);
                            if (controllerViewFolder != null)
                            {
                                var viewFiles = Directory.GetFiles(controllerViewFolder, "*.cshtml", SearchOption.AllDirectories);
                                foreach (var filePath in viewFiles)
                                {
                                    if (!controllerNode.Children.Any(a => a.ViewPath.ToLower() == filePath.ToLower()))
                                    {
                                        var fInfo = new FileInfo(filePath);
                                        var viewNode = new CMSNode
                                        {
                                            IsApplication = true,
                                            IsLeaf = true,
                                            IsSerialized = false,
                                            Parent = controllerNode,
                                            Title = fInfo.Name.Replace(fInfo.Extension, ""),
                                            Url = controllerNode.Url + "/" + firstMethod + "_" + fInfo.Name.Replace(fInfo.Extension, ""),
                                            ViewPath = fInfo.FullName,
                                            IsPartialView = fInfo.Name.StartsWith("_")
                                        };
                                        controllerNode.Children.Add(viewNode);
                                    }
                                }
                            }
                            controllerParentNode.Children.Add(controllerNode);
                            result.Add(cmsController);
                        }
                    }
                    catch (Exception exc)
                    {
                        _logger.LogException("ContentManagement", "ScanForControllers", new Exception("Cannot read types from " + assembly.FullName + " assembly.", exc));
                    }

                }
            }

            return result;
        }

        /// <summary>
        /// Fixes the file path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.String.</returns>
        private string FixFilePath(string path)
        {
            if (File.Exists(path))
            {
                var info = new FileInfo(path);
                return info.FullName;
            }

            return null;
        }

        /// <summary>
        /// Fixes the directory path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.String.</returns>
        private string FixDirectoryPath(string path)
        {
            if (Directory.Exists(path))
            {
                var info = new DirectoryInfo(path);
                return info.FullName;
            }

            return null;
        }

        /// <summary>
        /// Gets the parent node from areas.
        /// </summary>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="parentNode">The parent node.</param>
        /// <returns>CMSNode.</returns>
        private CMSNode GetParentNodeFromAreas(string controllerName, CMSNode parentNode)
        {
            CMSNode areasNode = parentNode.Children.SingleOrDefault(a => a.Title == _config.ModulesName);
            if (areasNode == null)
            {
                areasNode = new CMSNode
                {
                    IsApplication = true,
                    Parent = parentNode,
                    Title = _config.ModulesName,
                    IsSerialized = false,
                    Children = new List<CMSNode>(),
                    Url = parentNode.Url + "/",
                    ViewPath = "/" + _config.AreasName
                };
                parentNode.Children.Add(areasNode);
            }
            var nameParts = controllerName.Split(".".ToCharArray());
            var areaName = "";
            for (int i = 0; i < nameParts.Length; i++)
            {
                if (nameParts[i] == _config.AreasName && i < (nameParts.Length - 1))
                {
                    areaName = nameParts[i + 1];
                    break;
                }
                else if (nameParts[i].EndsWith("Plugin"))
                {
                    areaName = nameParts[i];
                    break;
                }
            }
            if (!string.IsNullOrEmpty(areaName))
            {
                areaName = areaName.Replace("Plugin", "");
                var areaNode = areasNode.Children.SingleOrDefault(a => a.Title == areaName);
                if (areaNode == null)
                {
                    areaNode = new CMSNode
                    {
                        IsApplication = true,
                        Parent = areasNode,
                        Title = areaName,
                        IsSerialized = false,
                        Children = new List<CMSNode>(),
                        Url = parentNode.Url + "/" + areaName,
                        ViewPath = "/" + _config.AreasName + "/" + areaName,
                        Expanded = false
                    };
                    areasNode.Children.Add(areaNode);
                }

                return areaNode;
            }

            return null;
        }

        /// <summary>
        /// Clears the cache.
        /// </summary>
        public void ClearCache()
        {
            _cache.Clear(NodesCacheKey);
            _cache.Clear(TreeCacheKey);
        }

        /// <summary>
        /// Finds the CMS node by node identifier.
        /// </summary>
        /// <param name="startNode">The start node.</param>
        /// <param name="nodeId">The node identifier.</param>
        /// <returns>CMSNode.</returns>
        private CMSNode FindCMSNodeByNodeId(CMSNode startNode, int nodeId)
        {
            if (startNode.NodeId == nodeId)
                return startNode;

            if (startNode.Children == null || startNode.Children.Count == 0)
                return null;

            foreach (var node in startNode.Children)
            {
                var result = FindCMSNodeByNodeId(node, nodeId);
                if (result != null)
                    return result;
            }

            return null;
        }

        /// <summary>
        /// Updates the configuration.
        /// </summary>
        /// <param name="json">The json.</param>
        public void UpdateConfig(string json)
        {
            _customConfiguration.CurrentConfiguration = json;
            _bl.UpdateCustomConfiguration(_customConfiguration);
        }

        /// <summary>
        /// Resets to default.
        /// </summary>
        public void ResetToDefault()
        {
            _customConfiguration.CurrentConfiguration = _customConfiguration.DefaultConfiguration;
            _bl.UpdateCustomConfiguration(_customConfiguration);
        }

        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed = false;
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    if(_bl != null)
                        ((IDisposable)_bl).Dispose();
                    if (_cache != null)
                        _cache.Dispose();
                }
            }
            this._disposed = true;
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
