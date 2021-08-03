using System;
using System.Web.Mvc;
using BAP.Web.DI;
using System.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DIConfig), "Register")]



public class DIConfig
{
    public static void Register()
    {
        var httpContext = HttpContext.Current;
        var container = CompositionRoot.Compose();
        var dependencyResolver = new InjectableDependencyResolver(container, DependencyResolver.Current);
        DependencyResolver.SetResolver(dependencyResolver);
        MvcSiteMapProviderConfig.Register(container);
    }
}

