// ***********************************************************************
// Assembly         : BAP.Workflow
// Author           : Victor Mamray
// Created          : 06-11-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-09-2020
// ***********************************************************************
// <copyright file="BaseWorkflowAction.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.Common;
using BAP.DAL;
using BAP.FileSystem;
using BAP.Log;
using BAP.Lookups;

namespace BAP.Workflow
{
    /// <summary>
    /// Class BaseWorkflowAction.
    /// </summary>
    public abstract class BaseWorkflowAction
    {
        /// <summary>
        /// The configuration helper
        /// </summary>
        protected readonly IConfigHelper _configHelper;
        /// <summary>
        /// The authentication context
        /// </summary>
        protected readonly IAuthorizationContext _authContext;
        /// <summary>
        /// The lookup engine
        /// </summary>
        protected readonly ILookupEngine _lookupEngine;
        /// <summary>
        /// The logger
        /// </summary>
        protected readonly ILogger _logger;

        /// <summary>
        /// The file processor
        /// </summary>
        protected IFileProcessor _fileProcessor;
        //Hiding default constructor
        /// <summary>
        /// Prevents a default instance of the <see cref="BaseWorkflowAction"/> class from being created.
        /// </summary>
        private BaseWorkflowAction()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseWorkflowAction"/> class.
        /// </summary>
        /// <param name="lookupEngine">The lookup engine.</param>
        /// <param name="fileProc">The file proc.</param>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public BaseWorkflowAction(ILookupEngine lookupEngine, IFileProcessor fileProc, IConfigHelper configHelper, IAuthorizationContext context, ILogger logger)
        {
            _fileProcessor = fileProc;
            _lookupEngine = lookupEngine;
            _configHelper = configHelper;
            _authContext = context;
            _logger = logger;
        }
    }
}
