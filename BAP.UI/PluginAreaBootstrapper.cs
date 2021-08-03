// ***********************************************************************
// Assembly         : BAP.UI
// Author           : Victor Mamray
// Created          : 06-25-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-25-2020
// ***********************************************************************
// <copyright file="PluginAreaBootstrapper.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;

namespace BAP.UI
{
    /// <summary>
    /// Class PluginAreaBootstrapper.
    /// </summary>
    public class PluginAreaBootstrapper
    {
        /// <summary>
        /// The plugin assemblies
        /// </summary>
        public static readonly List<Assembly> PluginAssemblies = new List<Assembly>();

        /// <summary>
        /// Plugins the names.
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        public static List<string> PluginNames()
        {
            return PluginAssemblies.Select(
                pluginAssembly => pluginAssembly.GetName().Name)
                .ToList();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Init()
        {
            var fullPluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Areas");
            if (!Directory.Exists(fullPluginPath))
                return;

            foreach (var file in Directory.EnumerateFiles(fullPluginPath, "*.dll", SearchOption.AllDirectories))
            {
                AssemblyName assemblyName = AssemblyName.GetAssemblyName(file);
                if (!AppDomain.CurrentDomain.GetAssemblies().Any(assembly => AssemblyName.ReferenceMatchesDefinition(assemblyName, assembly.GetName())))
                {
                    var assembly = Assembly.Load(assemblyName);
                    PluginAssemblies.Add(assembly);
                    AppDomain.CurrentDomain.Load(assemblyName);
                }
            }

            PluginAssemblies.ForEach(BuildManager.AddReferencedAssembly);

            // Add assembly handler for strongly-typed view models
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolve;
        }

        /// <summary>
        /// Assemblies the resolve.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="resolveArgs">The <see cref="ResolveEventArgs"/> instance containing the event data.</param>
        /// <returns>Assembly.</returns>
        private static Assembly AssemblyResolve(object sender, ResolveEventArgs resolveArgs)
        {
            var currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            // Check we don't already have the assembly loaded
            foreach (var assembly in currentAssemblies)
            {
                if (assembly.FullName == resolveArgs.Name || assembly.GetName().Name == resolveArgs.Name)
                {
                    return assembly;
                }
            }

            return null;
        }
    }
}