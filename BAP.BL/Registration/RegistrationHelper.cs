// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-17-2020
// ***********************************************************************
// <copyright file="RegistrationHelper.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Collections.Generic;

using BAP.DAL;
using BAP.Log;
using BAP.Common;
using BAP.Common.Registration;

namespace BAP.BL.Registration
{
    /// <summary>
    /// Registration helper implementation
    /// </summary>
    public sealed class RegistrationHelper : IRegistrationHelper
    {
        /// <summary>
        /// The lock
        /// </summary>
        private readonly object _lock = new object();
        /// <summary>
        /// The engines
        /// </summary>
        private List<IRegistrationEngine> _engines = null;

        /// <summary>
        /// Goes over BAP assemblies searches and instantiates classes suporting IRegistrationEngine interface
        /// </summary>
        /// <param name="configHelper">Cinfig helper instance</param>
        /// <param name="context">AuthorizationContext instance</param>
        /// <param name="logger">Loggeerr instance</param>
        private void Initialize(IConfigHelper configHelper, IAuthorizationContext context, ILogger logger)
        {
            if(_engines == null)
            {
                lock(_lock)
                {
                    if(_engines == null)
                    {
                        _engines = new List<IRegistrationEngine>();
                        var type = typeof(IRegistrationEngine);
                        IEnumerable<Type> types = null;
                        try
                        {
                            types = AppDomain.CurrentDomain.GetAssemblies()
                                .Where(a => a.FullName.Contains("BAP"))
                                .SelectMany(s => s.GetTypes())
                                .Where(p => type.IsAssignableFrom(p) && p.IsClass)
                                .ToList();
                        }
                        catch {
                            //Do nothing - if cannot read assemblies that we do not search over them
                        }

                        if (types != null && types.Any())
                        {
                            foreach (var t in types)
                            {
                                IRegistrationEngine engine = (IRegistrationEngine)Activator.CreateInstance(t, configHelper, context, logger);
                                if (engine != null)
                                {
                                    _engines.Add(engine);
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationHelper"/> class.
        /// </summary>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public RegistrationHelper(IConfigHelper configHelper, IAuthorizationContext context, ILogger logger)
        {
            Initialize(configHelper, context, logger);
        }

        /// <summary>
        /// Implementation of the GetRegistrationEngine interface method, looks over list of found and instantiated engines and gives 1st one found by the name of the class.
        /// </summary>
        /// <param name="registrationType">Full or part of the name of the class</param>
        /// <returns>Instance of the class supporting IRegistrationEngine</returns>
        public IRegistrationEngine GetRegistrationEngine(string registrationType)
        {
            IRegistrationEngine result = null;
            if (_engines != null && _engines.Any(a => a.GetType().Name.ToLower().Contains(registrationType.ToLower())))
            {
                result = _engines.FirstOrDefault(a => a.GetType().Name.ToLower().Contains(registrationType.ToLower()));
            }
                        
            return result;
        }
    }
}
