// ***********************************************************************
// Assembly         : BAP.UI
// Author           : Victor Mamray
// Created          : 06-25-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-20-2020
// ***********************************************************************
// <copyright file="PluginsDynamicNodeProvider.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;

using MvcSiteMapProvider;

using BAP.DAL;
using BAP.Log;
using BAP.Common;
using BAP.Common.Modules;
using BAP.ContentManagement;

namespace BAP.UI
{
    /// <summary>
    /// Class PluginsDynamicNodeProvider.
    /// Implements the <see cref="MvcSiteMapProvider.IDynamicNodeProvider" />
    /// </summary>
    /// <seealso cref="MvcSiteMapProvider.IDynamicNodeProvider" />
    public class PluginsDynamicNodeProvider : IDynamicNodeProvider
    {
        /// <summary>
        /// Determines whether the provider instance matches the name
        /// </summary>
        /// <param name="providerName">The name of the dynamic node provider. This can be any string, but for backward compatibility the type name can be used.</param>
        /// <returns>True if the provider name matches.</returns>
        public bool AppliesTo(string providerName)
        {
            if (string.IsNullOrEmpty(providerName))
                return false;

            return this.GetType().Equals(Type.GetType(providerName, false));
        }

        /// <summary>
        /// Gets the dynamic node collection.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <returns>A dynamic node collection.</returns>
        public IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            //init CMS engine
            var configHelper = DependencyResolver.Current.GetService<IConfigHelper>();
            var authContext = DependencyResolver.Current.GetService<IAuthorizationContext>();
            var logger = DependencyResolver.Current.GetService<ILogger>();
            using (var cmsEngine = new CMSEngine(configHelper, authContext, logger))
            {
                // get menu from CMS
                var rootmenuNodes = new List<ModuleMenuNode>();
                var cmsMenu = cmsEngine.GetMenu();
                if (cmsMenu != null && cmsMenu.Length > 0)
                {
                    rootmenuNodes.AddRange(cmsMenu);
                }
                else // if no menu found - scan assemblies to get menu
                {
                    foreach (var assembly in PluginAreaBootstrapper.PluginAssemblies.Where(a => a.FullName.Contains("BAP.")))
                    {
                        var type = typeof(IModuleMenu);
                        IModuleMenu menu = null;
                        try
                        {
                            var types = assembly.GetTypes().Where(p => type.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract).ToArray();
                            // we allow only one menu per assembly
                            if (types.Length != 1)
                                continue;
                            menu = (IModuleMenu)Activator.CreateInstance(types[0]);
                        }
                        catch (Exception ex)
                        {
                            if (DependencyResolver.Current != null)
                            {
                                if (logger != null)
                                    logger.LogException("PluginsDynamicNodeProvider", "GetDynamicNodeCollection", new Exception("Unable to get types of asssembly " + assembly.FullName, ex));
                            }
                        }

                        if (menu == null || menu.GetMenu() == null)
                            continue;
                        var nodes = menu.GetMenu();
                        if (nodes.Length > 0)
                            rootmenuNodes.AddRange(nodes);
                    }
                }

                // transform menu into dynamic
                foreach (var rootNode in rootmenuNodes)
                {
                    DynamicNode dynamicNode = PluginsActionDynamicNodeProvider.GetDynamicModeFromMenuNode(rootNode, "HomeKey");
                    UI.DynamicNodeData.MenuNodes.Add(rootNode);
                    yield return dynamicNode;
                }
            }                         
        }
    }

    /// <summary>
    /// Class PluginsActionDynamicNodeProvider.
    /// Implements the <see cref="MvcSiteMapProvider.IDynamicNodeProvider" />
    /// </summary>
    /// <seealso cref="MvcSiteMapProvider.IDynamicNodeProvider" />
    public class PluginsActionDynamicNodeProvider : IDynamicNodeProvider
    {
        /// <summary>
        /// Determines whether the provider instance matches the name
        /// </summary>
        /// <param name="providerName">The name of the dynamic node provider. This can be any string, but for backward compatibility the type name can be used.</param>
        /// <returns>True if the provider name matches.</returns>
        public bool AppliesTo(string providerName)
        {
            if (string.IsNullOrEmpty(providerName))
                return false;

            return this.GetType().Equals(Type.GetType(providerName, false));
        }

        /// <summary>
        /// Gets the dynamic node collection.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <returns>A dynamic node collection.</returns>
        public IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            List<DynamicNode> result = new List<DynamicNode>();
            foreach (var rootNode in UI.DynamicNodeData.MenuNodes)
            {
                if (rootNode.ChildNodes != null)
                {
                    foreach (var childNode in rootNode.ChildNodes)
                    {
                        DynamicNode dynamicNode = GetDynamicModeFromMenuNode(childNode, rootNode.Key);
                        if (childNode.ChildNodes != null && childNode.ChildNodes.Length > 0)
                        {
                            foreach (var anotherChild in childNode.ChildNodes)
                            {
                                DynamicNode anotherDynamicNode = GetDynamicModeFromMenuNode(anotherChild, dynamicNode.Key);
                                if (!result.Any(a => a.Key == anotherDynamicNode.Key))
                                    result.Add(anotherDynamicNode);
                            }
                        }
						else if(childNode.IsAdmin) //If admin - adding fake nokes for Add/Update/Delete
						{
							DynamicNode anotherDynamicNode = new DynamicNode
							{
								Key = string.Format("{0}_{1}_Create_Menu", childNode.Area, childNode.Controller),
								Action = "Create",
								Area = childNode.Area,
								PreservedRouteParameters = new List<string> { "id" },								
								Controller = childNode.Controller,
								Title = Resources.Resources.UIText_Create,
								ParentKey = dynamicNode.Key,
								Roles = dynamicNode.Roles
							};
							if (!result.Any(a => a.Key == anotherDynamicNode.Key))
								result.Add(anotherDynamicNode);

							anotherDynamicNode = new DynamicNode
							{
								Key = string.Format("{0}_{1}_Details_Menu", childNode.Area, childNode.Controller),
								Action = childNode.Action == "Index" ? "Details" : "AdminDetails",
								Area = childNode.Area,
								PreservedRouteParameters = new List<string> { "id" },								
								Controller = childNode.Controller,
								Title = Resources.Resources.UIText_Details,
								ParentKey = dynamicNode.Key,
								Roles = dynamicNode.Roles
							};
							if (!result.Any(a => a.Key == anotherDynamicNode.Key))
								result.Add(anotherDynamicNode);

							anotherDynamicNode = new DynamicNode
							{
								Key = string.Format("{0}_{1}_Edit_Menu", childNode.Area, childNode.Controller),
								Action = "Edit",
								Area = childNode.Area,
								PreservedRouteParameters = new List<string> { "id" },								
								Controller = childNode.Controller,
								Title = Resources.Resources.UIText_Edit,
								ParentKey = dynamicNode.Key,
								Roles = dynamicNode.Roles
							};
							if (!result.Any(a => a.Key == anotherDynamicNode.Key))
								result.Add(anotherDynamicNode);

							anotherDynamicNode = new DynamicNode
							{
								Key = string.Format("{0}_{1}_Delete_Menu", childNode.Area, childNode.Controller),
								Action = "Delete",
								Area = childNode.Area,
								PreservedRouteParameters = new List<string> { "id" },								
								Controller = childNode.Controller,
								Title = Resources.Resources.UIText_Delete,
								ParentKey = dynamicNode.Key,
								Roles = dynamicNode.Roles
							};
							if (!result.Any(a => a.Key == anotherDynamicNode.Key))
								result.Add(anotherDynamicNode);

						}
                        if (!result.Any(a => a.Key == dynamicNode.Key))
                            result.Add(dynamicNode);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the dynamic mode from menu node.
        /// </summary>
        /// <param name="childNode">The child node.</param>
        /// <param name="parentKey">The parent key.</param>
        /// <returns>DynamicNode.</returns>
        public static DynamicNode GetDynamicModeFromMenuNode(ModuleMenuNode childNode, string parentKey)
        {
            DynamicNode dynamicNode = new DynamicNode();
            dynamicNode.Key = childNode.Key;
            dynamicNode.Title = childNode.Title;
            dynamicNode.ParentKey = parentKey;
            dynamicNode.Controller = childNode.Controller;
            dynamicNode.Action = childNode.Action;
            dynamicNode.Area = childNode.Area;
            dynamicNode.TargetFrame = childNode.Target;
            dynamicNode.Clickable = childNode.Clickable;            

            if (childNode.HtmlAttributes != null && childNode.HtmlAttributes.Count > 0)
                dynamicNode.Attributes = childNode.HtmlAttributes;

            if (childNode.PreservedRouteParameters != null && childNode.PreservedRouteParameters.Count > 0)
                dynamicNode.PreservedRouteParameters = childNode.PreservedRouteParameters;

            if (childNode.RoutingValues != null)
                dynamicNode.RouteValues = childNode.RoutingValues;

            dynamicNode.HttpMethod = childNode.HttpMethod;
            dynamicNode.Order = childNode.SortOrder;
			dynamicNode.Url = childNode.Url;
            if (childNode.Roles != null)
                dynamicNode.Roles = childNode.Roles;

            if (childNode.IsAdmin || (childNode.ChildNodes != null && childNode.ChildNodes.Any(a => a.IsAdmin)))
            {
                dynamicNode.Attributes.Add("isadmin", "true");
            }

            if (!string.IsNullOrWhiteSpace(childNode.Icon))
            {
                dynamicNode.Attributes.Add("icon", childNode.Icon);
            }

            return dynamicNode;
        }
    }
}