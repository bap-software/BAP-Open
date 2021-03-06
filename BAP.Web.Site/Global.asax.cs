using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using BAP.UI.ViewEngines;
using BAP.Web.App_Start;
using BAP.Common;
using BAP.DAL;
using BAP.Log;
using BAP.ContentManagement;

namespace BAP.Web
{
    
    public class MvcApplication : System.Web.HttpApplication
    {        
        // Make sure there is no any read of data as part of this method - all have to be done as part of 1st request - method down!
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);            
            BundleConfig.RegisterBundles(BundleTable.Bundles);            

            // register custom view engine
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new BAPRazorViewEngine());

            // register custom virtual path provider
            IConfigHelper confiHelper = DependencyResolver.Current.GetService<IConfigHelper>();
            IAuthorizationContext authHelper = DependencyResolver.Current.GetService<IAuthorizationContext>();
            ILogger logger = DependencyResolver.Current.GetService<ILogger>();
            System.Web.Hosting.HostingEnvironment.RegisterVirtualPathProvider(new BAPVirtualPathProvider(confiHelper, authHelper, logger));
        }

        void Application_BeginRequest(Object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            FirstRequestInitialisation.Initialise(app.Context);
        }

        static class FirstRequestInitialisation
        {
            private static string host = null;
            private static Object s_lock = new Object();

            // Initialise only on the first request
            public static void Initialise(HttpContext context)
            {
                if (string.IsNullOrEmpty(host))
                {
                    lock (s_lock)
                    {
                        if (string.IsNullOrEmpty(host))
                        {
                            var uri = context.Request.Url;
                            host = uri.GetLeftPart(UriPartial.Authority);

                            // do init based on current host
                            RouteConfig.RegisterRoutes(RouteTable.Routes);
                        }
                    }
                }                
            }
        }
    }
}
