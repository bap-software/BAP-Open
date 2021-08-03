using System.Web.Mvc;
using System.Web.Routing;
using BAP.ContentManagement;
using BAP.Common;
using BAP.DAL;
using System.Linq;
using BAP.Log;
using System;
using BAP.ContentManagement.HttpHandlers;

namespace BAP.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // ignore resource routes
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // aliasing 
            routes.MapRoute
            (
                name: "IUrlRouteHandler",
                url: "{*urlRouteHandler}",
                defaults: null,
                constraints: new { urlRouteHandler = new BAPAliasConstraint() },
                namespaces: new[] { "BAP.Web.Controllers" }
            ).RouteHandler = new BAPAliasRouteHandler();

            // adding routes to read files and attachments
            routes.MapRoute(
                name: "Files",
                url: "file/{*path}",
                defaults: new { controller = "Home", action = "File" },
                namespaces: new[] { "BAP.Web.Controllers" }
            );            

            routes.MapRoute(
                name: "AttachmentById",
                url: "attachment/{attachmentId}",
                defaults: new { controller = "Home", action = "GetAttachmentById", attachmentId = UrlParameter.Optional },
                namespaces: new[] { "BAP.Web.Controllers" }
            );

			routes.MapRoute(
				name: "SubscribersUnsubscribe",
				url: "Subscribers/unsubscribe/{publicId}",
				defaults: new { controller = "Home", action = "Unsubscribe", publicId = UrlParameter.Optional },
				namespaces: new[] { "BAP.Web.Controllers" }
			);

			//adding default route
			routes.MapRoute(
					name: "Default",
					url: "{controller}/{action}/{id}",
					defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
					namespaces: new[] { "BAP.Web.Controllers" }
				);

			/*
            // read other routes from CMS engine
            var configHelper = DependencyResolver.Current.GetService<IConfigHelper>();
            var authContext = DependencyResolver.Current.GetService<IAuthorizationContext>();
            var logger = DependencyResolver.Current.GetService<ILogger>();
            var cmsEngine = new CMSEngine(configHelper, authContext, logger);
            var anotherHome = cmsEngine.GetAnotherHomeRoute();
            if(anotherHome != null)
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
                catch(Exception exc)
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
                        namespaces: new[] { "BAP.Web.Controllers" }
                    );
                }                
            }
            else // taking default home page of the app
            {
                routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                    namespaces: new[] { "BAP.Web.Controllers" }
                );
            }  */
		}
    }
}
