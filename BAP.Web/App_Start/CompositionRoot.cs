using System;
using System.Web.Http;

using Autofac;
using Autofac.Integration.WebApi;

using BAP.Common;
using BAP.Lookups;
using BAP.DAL;
using BAP.Email;
using BAP.FileSystem;
using BAP.Log;
using BAP.BL.Registration;

using BAP.Web.DI;
using BAP.Web.DI.Autofac;
using BAP.Web.DI.Autofac.Modules;
using BAP.Resources;
using BAP.DAL.ResourceUtils;
using System.Resources;

public class CompositionRoot
{
    public static IDependencyInjectionContainer Compose()
    {
        // Create a container builder
        var builder = new ContainerBuilder();
        
        try
        {
            RegisterAppDependencies(builder);
        }
        catch
        {
            // ignore
        }

        // Create the DI container
        var container = builder.Build();

        // Get your HttpConfiguration.
        var config = GlobalConfiguration.Configuration;
        config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        // Return our DI container wrapper instance
        return new AutofacDependencyInjectionContainer(container);
    }

    private static void RegisterAppDependencies(ContainerBuilder builder)
    {
        builder.RegisterModule(new MvcSiteMapProviderModule());
        builder.RegisterModule(new MvcModule());

        //Register settings instance
        var settings = new ConfigHelper("DefaultConnection", "worker@app.bap-software.com");
        builder.RegisterInstance(settings).As<IConfigHelper>();

        //Register custom resource manager
        var resourceManager = new BapResourceManager(settings);
        builder.RegisterInstance(resourceManager).As<ResourceManager>();

        //Register reporsitory filter (localization, but can be anything else)
        var localizationFilter = new RepositoryLocalizationFilter(resourceManager);
        builder.RegisterInstance(localizationFilter).As<IRepositoryFilter>();

        //Register authorization context
        var authContext = new AuthorizationContext(settings);
        authContext.RepositoryFilter = localizationFilter; //Property injection
        builder.RegisterInstance(authContext).As<IAuthorizationContext>();

        //Register logger
        //var logger = new Logger(settings, authContext);
        var logger = new BAP.Log4Net.Logger(settings, authContext);
        //var logger = new Logger(settings, authContext);
        builder.RegisterInstance(logger).As<ILogger>();

        //Register mailer 
        builder.RegisterType<Mailer>().As<IMailer>();

        //Register file processor
        builder.RegisterType<FileProcessorLocal>().As<IFileProcessor>();

        //Register lookup engine
        var lookupEngine = new LookupEngine(logger, settings, authContext);
        builder.RegisterInstance(lookupEngine).As<ILookupEngine>();

        //Register registration helper
        builder.RegisterType<RegistrationHelper>().As<IRegistrationHelper>();        
    }
}

