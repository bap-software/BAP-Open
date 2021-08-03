// ***********************************************************************
// Assembly         : BAP.ContentManagement
// Author           : Victor Mamray
// Created          : 07-06-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-06-2020
// ***********************************************************************
// <copyright file="CMSEngineConfig.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.Common
{
    /// <summary>
    /// Class CMSEngineConfig.
    /// </summary>
    public class CMSEngineConfig
    {
        /// <summary>
        /// Gets or sets the nodes cache key prefix.
        /// </summary>
        /// <value>The nodes cache key prefix.</value>
        public string NodesCacheKeyPrefix { get; set; } = "cms_nodes_org_";

        /// <summary>
        /// Gets or sets the tree cache key prefix.
        /// </summary>
        /// <value>The tree cache key prefix.</value>
        public string TreeCacheKeyPrefix { get; set; } = "cms_tree_org_";

        /// <summary>
        /// Gets or sets the base file folder.
        /// </summary>
        /// <value>The base file folder.</value>
        public string BaseFileFolder { get; set; } = "/";

        /// <summary>
        /// Gets or sets the default route URL format.
        /// </summary>
        /// <value>The default route URL format.</value>
        public string DefaultRouteUrlFormat { get; set; } = "{controller}/{action}/{id}";

        /// <summary>
        /// Gets or sets the default name of the node.
        /// </summary>
        /// <value>The default name of the node.</value>
        public string DefaultNodeName { get; set; } = "Default";

        /// <summary>
        /// Gets or sets the temporary node URL format.
        /// </summary>
        /// <value>The temporary node URL format.</value>
        public string TempNodeUrlFormat { get; set; } = "temp://{0}/{1}";

        /// <summary>
        /// Gets or sets the save content view path format.
        /// </summary>
        /// <value>The save content view path format.</value>
        public string SaveContentViewPathFormat { get; set; } = "/Views/{0}/{1}-{2}.cshtml";

        /// <summary>
        /// Gets or sets the get layout path ending.
        /// </summary>
        /// <value>The get layout path ending.</value>
        public string GetLayoutPathEnding { get; set; } = "\\..\\_ViewStart.cshtml";

        /// <summary>
        /// Gets or sets the name of the system method.
        /// </summary>
        /// <value>The name of the system method.</value>
        public string SystemMethodName { get; set; } = "get_ViewBag";

        /// <summary>
        /// Gets or sets the name of the modules.
        /// </summary>
        /// <value>The name of the modules.</value>
        public string ModulesName { get; set; } = "Modules";

        /// <summary>
        /// Gets or sets the name of the areas.
        /// </summary>
        /// <value>The name of the areas.</value>
        public string AreasName { get; set; } = "Areas";

        /// <summary>
        /// Gets or sets the name of the views.
        /// </summary>
        /// <value>The name of the views.</value>
        public string ViewsName { get; set; } = "Views";
        /// <summary>
        /// Gets or sets the static content extensions.
        /// </summary>
        /// <value>The static content extensions.</value>
        public string StaticContentExtensions { get; set; } = "html,txt,htm,css,json,js";
    }
}
