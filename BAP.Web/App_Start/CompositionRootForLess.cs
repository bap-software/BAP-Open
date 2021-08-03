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
        builder.RegisterModule(new MvcSiteMapProviderModule());
        builder.RegisterModule(new MvcModule());
        
        //Register settings instance
        var settings = new ConfigHelper("ForLessConnection", "worker@app.bap-software.com");       
        builder.RegisterInstance(settings).As<IConfigHelper>();

        //Register authorization context
        var authContext = new AuthorizationContext(settings);
        builder.RegisterInstance(authContext).As<IAuthorizationContext>();

        //Register logger
        //var logger = new Logger(settings, authContext);
        var logger = new BAP.Log4Net.Logger(settings, authContext);
        //var logger = new Logger(settings, authContext);
        builder.RegisterInstance(logger).As<ILogger>();

        //Register custom resource manager
        var resourceManager = new BapResourceManager(settings);
        builder.RegisterInstance(resourceManager).As<ResourceManager>();

        //Register mailer 
        builder.RegisterType<Mailer>().As<IMailer>();

        //Register file processor
        builder.RegisterType<FileProcessorLocal>().As<IFileProcessor>();
        
        //Register lookup engine
        var lookupEngine = new LookupEngine(logger, settings, authContext);
        builder.RegisterInstance(lookupEngine).As<ILookupEngine>();

        //Register registration helper
        builder.RegisterType<RegistrationHelper>().As<IRegistrationHelper>();

        // Create the DI container
        var container = builder.Build();

        // Get your HttpConfiguration.
        var config = GlobalConfiguration.Configuration;
        config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        // Return our DI container wrapper instance
        return new AutofacDependencyInjectionContainer(container);
    }
}

