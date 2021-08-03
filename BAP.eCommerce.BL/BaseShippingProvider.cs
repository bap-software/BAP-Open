// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 04-20-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="BaseShippingProvider.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.Common;
using BAP.DAL;
using BAP.FileSystem;
using BAP.Log;
using BAP.Lookups;

using BAP.eCommerce.DAL.Entities;
using BAP.BL;

namespace BAP.eCommerce.BL
{
    /// <summary>
    /// Class BaseShippingProvider.
    /// Implements the <see cref="BAP.Common.BAPBaseClassWithLogging" />
    /// </summary>
    /// <seealso cref="BAP.Common.BAPBaseClassWithLogging" />
    public abstract class BaseShippingProvider : BAPBaseClassWithLogging
    {
        /// <summary>
        /// The custom configuration json
        /// </summary>
        protected readonly string _customConfigJson;
        /// <summary>
        /// The lookup engine
        /// </summary>
        protected readonly ILookupEngine _lookupEngine;
        /// <summary>
        /// The file processor
        /// </summary>
        protected readonly IFileProcessor _fileProcessor;
        /// <summary>
        /// The configuration helper
        /// </summary>
        protected readonly IConfigHelper _configHelper;
        /// <summary>
        /// The authentication context
        /// </summary>
        protected readonly IAuthorizationContext _authContext;
        /// <summary>
        /// The bl
        /// </summary>
        protected readonly BusinessLayer _bl;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseShippingProvider"/> class.
        /// </summary>
        /// <param name="lookupEngine">The lookup engine.</param>
        /// <param name="fileProc">The file proc.</param>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="customConfigJson">The custom configuration json.</param>
        /// <param name="bl">The bl.</param>
        public BaseShippingProvider(ILookupEngine lookupEngine, IFileProcessor fileProc, IConfigHelper configHelper, IAuthorizationContext context, ILogger logger, string customConfigJson, BusinessLayer bl)
            : base(logger)
        {
            _lookupEngine = lookupEngine;
            _fileProcessor = fileProc;
            _configHelper = configHelper;
            _authContext = context;            
            _customConfigJson = customConfigJson;
            _bl = bl;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseShippingProvider"/> class.
        /// </summary>
        public BaseShippingProvider()
        {
        }

        /// <summary>
        /// Formulas the specified width.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="depth">The depth.</param>
        /// <param name="weight">The weight.</param>
        /// <param name="cost">The cost.</param>
        /// <param name="fromAddress">From address.</param>
        /// <param name="shipToAddress">The ship to address.</param>
        /// <param name="optionCode">The option code.</param>
        /// <param name="customConfigJson">The custom configuration json.</param>
        /// <returns>System.Decimal.</returns>
        protected abstract decimal Formula(decimal width, decimal height, decimal depth, decimal weight, decimal cost, Address fromAddress, Address shipToAddress, string optionCode, string customConfigJson = "");        
    }
}
