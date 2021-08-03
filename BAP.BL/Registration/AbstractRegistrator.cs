// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-17-2020
// ***********************************************************************
// <copyright file="AbstractRegistrator.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.Common;
using BAP.DAL;
using BAP.Log;

namespace BAP.BL.Registration
{
    /// <summary>
    /// Base abstarct class of any registration engine in the system
    /// </summary>
    public abstract class AbstractRegistrator
    {
        /// <summary>
        /// The configuration helper
        /// </summary>
        protected IConfigHelper _configHelper;
        /// <summary>
        /// The authentication context
        /// </summary>
        protected IAuthorizationContext _authContext;
        /// <summary>
        /// The logger
        /// </summary>
        protected ILogger _logger;

        /// <summary>
        /// Prevents a default instance of the <see cref="AbstractRegistrator"/> class from being created.
        /// </summary>
        private AbstractRegistrator()
        {
            _configHelper = null;           
            _authContext = null;
            _logger = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractRegistrator"/> class.
        /// </summary>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        protected AbstractRegistrator(IConfigHelper configHelper, IAuthorizationContext context, ILogger logger)
        {
            _logger = logger;
            _configHelper = configHelper;            
            _authContext = context;
        }
    }
}
