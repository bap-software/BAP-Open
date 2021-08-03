// ***********************************************************************
// Assembly         : BAP.eCommerce.InStoreShippingProvider
// Author           : Victor Mamray
// Created          : 05-30-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ShippingProvider.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using BAP.BL;
using BAP.Common;
using BAP.DAL;
using BAP.eCommerce.BL;
using BAP.eCommerce.DAL.Entities;
using BAP.FileSystem;
using BAP.Log;
using BAP.Lookups;


namespace BAP.eCommerce.InStoreShippingProvider
{
    /// <summary>
    /// Class ShippingProvider.
    /// Implements the <see cref="BAP.eCommerce.BL.BaseShippingProvider" />
    /// Implements the <see cref="BAP.eCommerce.BL.IShippingCarrierProvider" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.BL.BaseShippingProvider" />
    /// <seealso cref="BAP.eCommerce.BL.IShippingCarrierProvider" />
    public class ShippingProvider : BaseShippingProvider, IShippingCarrierProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShippingProvider"/> class.
        /// </summary>
        /// <param name="lookupEngine">The lookup engine.</param>
        /// <param name="fileProc">The file proc.</param>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="customConfigJson">The custom configuration json.</param>
        /// <param name="bl">The bl.</param>
        public ShippingProvider(ILookupEngine lookupEngine, IFileProcessor fileProc, IConfigHelper configHelper, IAuthorizationContext context, ILogger logger, string customConfigJson, BusinessLayer bl) 
            : base(lookupEngine, fileProc, configHelper, context, logger, customConfigJson, bl)
        {
        }

        /// <summary>
        /// Gets the name of the provider.
        /// </summary>
        /// <value>The name of the provider.</value>
        public string ProviderName => "InStore";

        /// <summary>
        /// Gets a value indicating whether [supports option custom configuration].
        /// </summary>
        /// <value><c>true</c> if [supports option custom configuration]; otherwise, <c>false</c>.</value>
        public bool SupportsOptionCustomConfig => false;

        /// <summary>
        /// Gets the custom option configuration json example.
        /// </summary>
        /// <value>The custom option configuration json example.</value>
        public string CustomOptionConfigJsonExample => "";

        /// <summary>
        /// Gets a value indicating whether [support branch listing].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [support branch listing]; otherwise, <c>false</c>.
        /// </value>
        public bool SupportBranchListing => false;
        
        /// <summary>
        /// Determines whether this instance can deliver the specified delivery.
        /// </summary>
        /// <param name="delivery">The delivery.</param>
        /// <returns><c>true</c> if this instance can deliver the specified delivery; otherwise, <c>false</c>.</returns>
        public bool CanDeliver(Delivery delivery)
        {
            return true;
        }

        /// <summary>
        /// Gets the quote.
        /// </summary>
        /// <param name="delivery">The delivery.</param>
        /// <returns>System.Decimal.</returns>
        public decimal GetQuote(Delivery delivery)
        {
            //For in-store shipping we do not know price but we can set some constant one - so using MaxPrice of the shipping option for that
            if (delivery.ShippingOption?.MaxPrice != null )
            {
                return (decimal)delivery.ShippingOption.MaxPrice.Value;
            }
            else
            {                
                return 0;
            }
        }

        /// <summary>
        /// Initiates the delivery estimation.
        /// </summary>
        /// <param name="delivery">The delivery.</param>
        /// <returns></returns>
        public DeliveryResult InitiateDelivery(Delivery delivery)
        {
            //TODO: can be implemented later
            return null;
        }

        /// <summary>
        /// Searches the branches by the given address.
        /// </summary>
        /// <param name="shipToAddress">The ship to address.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IList<BranchInfo> SearchBranches(Delivery delivery)
        {
            throw new NotImplementedException();
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
        /// <exception cref="NotImplementedException"></exception>
        protected override decimal Formula(decimal width, decimal height, decimal depth, decimal weight, decimal cost, Address fromAddress, Address shipToAddress, string optionCode, string customConfigJson = "")
        {
            //This in in-house shipping provider, it does not have any logic to calculate shipping cost, so no need to use this method.
            throw new NotImplementedException();
        }
    }
}
