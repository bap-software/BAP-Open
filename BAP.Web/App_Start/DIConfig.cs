using System;
using System.Data.Entity;
using System.Web.Mvc;
using BAP.Web.DI;
using System.Web;
using BAP.DB.eCommerce;
using BAP.DB.eCommerce.Migrations;
using BAP.eCommerce.SupplierEngine;
using BAP.SelfSetup;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DIConfig), "Register")]



public class DIConfig
{
    public static void Register()
    {
        var httpContext = HttpContext.Current;
        var container = CompositionRoot.Compose();
        var dependencyResolver = new InjectableDependencyResolver(container, DependencyResolver.Current);
        DependencyResolver.SetResolver(dependencyResolver);
        
        // Provide dependency resolver to Supplier Engine to be able use it when creating instances. 
        SupplierEngineTool.RegisterDependencyResolver(dependencyResolver);
        
        // Setup self-installer for BAP app
        BapInstaller.Setup(x =>
        {
            x.DbProvider = () => dependencyResolver.GetService<DB>();
            x.DbContextType = typeof(DB);
            x.DbMigrationConfigProvider = () => new Configuration();
            x.DbConnectionName = "DefaultConnection";
            x.ContentRootPath = "/bin/"; // Uses to show path where all external content will be placed after build. 
        });
        
        MvcSiteMapProviderConfig.Register(container);
    }
}

