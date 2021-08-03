using System.Web.Mvc;
using Autofac;
using MvcSiteMapProvider.Web.Mvc;
using System.Collections.Generic;
using Autofac.Integration.WebApi;

namespace BAP.Web.DI.Autofac.Modules
{
    public class MvcModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var currentAssembly = typeof(MvcModule).Assembly;
            List<System.Reflection.Assembly> assemblies = new List<System.Reflection.Assembly>();
            assemblies.Add(currentAssembly);
            assemblies.AddRange(BAP.UI.PluginAreaBootstrapper.PluginAssemblies);

            foreach(var assembly in assemblies)
            {
                builder.RegisterAssemblyTypes(assembly)
                .Where(t => typeof(IController).IsAssignableFrom(t))
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerDependency();

                builder.RegisterApiControllers(assembly);
            }            
        }
    }
}
