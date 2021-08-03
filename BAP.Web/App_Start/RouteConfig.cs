﻿using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using BAP.Common;
using BAP.ContentManagement;
using BAP.ContentManagement.HttpHandlers;
using BAP.DAL;
using BAP.Log;
using BAP.SelfSetup;

namespace BAP.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // ignore resource routes
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // adding routes to read files and attachments
            routes.MapRoute(
                name: "Files",
                url: "file/{*path}",
                defaults: new { controller = "Home", action = "File" },
                namespaces: new[] { "BAP.Web.Controllers", BapInstaller.ControllerNamespace }
            );

            routes.MapRoute(
                name: "AttachmentById",
                url: "attachment/{attachmentId}",
                defaults: new { controller = "Home", action = "GetAttachmentById", attachmentId = UrlParameter.Optional },
                namespaces: new[] { "BAP.Web.Controllers", BapInstaller.ControllerNamespace }
            );

            // aliasing 
            routes.MapRoute(
            name: "IUrlRouteHandler",
            url: "{*urlRouteHandler}",
            defaults: null,
            constraints: new { urlRouteHandler = new BAPAliasConstraint() }
            ).RouteHandler = new BAPAliasRouteHandler();            

            routes.MapMvcAttributeRoutes();

            //adding default route
            /*routes.MapRoute(
					name: "Default",
					url: "{controller}/{action}/{id}",
					defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
					namespaces: new[] { "BAP.Web.Controllers" }
				);
                */
			#region advanced, alternative home routing
			
            // read other routes from CMS engine
            var configHelper = DependencyResolver.Current.GetService<IConfigHelper>();
            var authContext = DependencyResolver.Current.GetService<IAuthorizationContext>();
            var logger = DependencyResolver.Current.GetService<ILogger>();
            using (var cmsEngine = new CMSEngine(configHelper, authContext, logger))
            {
                CMSRoute anotherHome = null;
                
                try
                {
                    anotherHome = cmsEngine.GetAnotherHomeRoute();
                }
                catch
                {
                    // ignore
                }
                
                if (anotherHome != null)
                {
                    // trying to add another home route
                    bool applied = false;
                    try
                    {
                        var route = routes.MapRoute(
                        name: anotherHome.Name,
                        url: anotherHome.Url,
                        defaults: anotherHome.Defaults,
                        namespaces: anotherHome.Namespaces,
                        constraints: anotherHome.Constraints
                        );
                        if (anotherHome.DataTokens != null && anotherHome.DataTokens.Count > 0)
                        {
                            foreach (var k in anotherHome.DataTokens.Keys)
                            {
                                route.DataTokens.Add(k, anotherHome.DataTokens[k]);
                            }
                        }
                        applied = true;
                    }
                    catch (Exception exc)
                    {
                        logger.LogException("app_start", "RegisterRoutes", exc);
                    }

                    // if the route returned by CMS is not default app one - we add it
                    if (applied && !(anotherHome.DataTokens == null && anotherHome.Url == "{controller}/{action}/{id}" && !anotherHome.Namespaces.Any(b => b == "BAP.Web.Controllers" && (anotherHome.Defaults == null && ((dynamic)anotherHome.Defaults).controller != "Home" && ((dynamic)anotherHome.Defaults).action != "Index"))))
                    {
                        routes.MapRoute(
                            name: "BapHome",
                            url: "{controller}/{action}/{id}",
                            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                            namespaces: new[] { "BAP.Web.Controllers", BapInstaller.ControllerNamespace }
                        );
                    }
                }
                else // taking default home page of the app
                {
                    routes.MapRoute(
                        name: "Default",
                        url: "{controller}/{action}/{id}",
                        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                        namespaces: new[] { "BAP.Web.Controllers", BapInstaller.ControllerNamespace }
                    );
                }
            }
                
			#endregion
		}
    }
}
