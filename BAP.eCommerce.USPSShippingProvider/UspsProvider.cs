// ***********************************************************************
// Assembly         : BAP.eCommerce.USPSShippingProvider
// Author           : Victor Mamray
// Created          : 06-08-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="UspsProvider.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;
using BAP.BL;
using BAP.Common;
using BAP.DAL;
using BAP.DAL.Entities;
using BAP.eCommerce.BL;
using BAP.eCommerce.Common.Exceptions;
using BAP.eCommerce.USPSShippingProvider.Request;
using BAP.eCommerce.USPSShippingProvider.Response;
using BAP.eCommerce.USPSShippingProvider.Utils;
using BAP.FileSystem;
using BAP.Log;
using BAP.Lookups;
using Address = BAP.eCommerce.DAL.Entities.Address;
using System.Collections.Generic;

namespace BAP.eCommerce.USPSShippingProvider
{
    /// <summary>
    /// Class UspsProvider.
    /// Implements the <see cref="BAP.eCommerce.BL.BaseShippingProvider" />
    /// Implements the <see cref="BAP.eCommerce.BL.IShippingCarrierProvider" />
    /// Implements the <see cref="BAP.Common.ISupportCustomConfig" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.BL.BaseShippingProvider" />
    /// <seealso cref="BAP.eCommerce.BL.IShippingCarrierProvider" />
    /// <seealso cref="BAP.Common.ISupportCustomConfig" />
    public class UspsProvider : BaseShippingProvider, IShippingCarrierProvider, ISupportCustomConfig
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly UspsConfig _config = null;
        /// <summary>
        /// The custom configuration
        /// </summary>
        private readonly CustomConfiguration _customConfiguration;
        /// <summary>
        /// Initializes a new instance of the <see cref="UspsProvider"/> class.
        /// </summary>
        /// <param name="lookupEngine">The lookup engine.</param>
        /// <param name="fileProc">The file proc.</param>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="config">The configuration.</param>
        /// <param name="bl">The bl.</param>
        public UspsProvider(ILookupEngine lookupEngine, IFileProcessor fileProc, IConfigHelper configHelper, IAuthorizationContext context, ILogger logger, string config, BusinessLayer bl)
            : base(lookupEngine, fileProc, configHelper, context, logger, config, bl)
        {
            try
            {
                var type = typeof(UspsProvider);
                _customConfiguration = _bl.GetCustomConfigurationByName($"{type.Assembly.GetName().Name}_{type.Name}");
                if (_customConfiguration != null && !string.IsNullOrWhiteSpace(_customConfiguration.CurrentConfiguration))
                    _config = JsonConvert.DeserializeObject<UspsConfig>(_customConfiguration.CurrentConfiguration);
                if (_config == null)
                    _config = JsonConvert.DeserializeObject<UspsConfig>(config);
            }
            catch (Exception exc)
            {
                LogException(new ShippingException("Could not read provided configuration from JSON text to Object", exc));
                _config = new UspsConfig();
            }
        }

        /// <summary>
        /// Gets the name of the provider.
        /// </summary>
        /// <value>The name of the provider.</value>
        public string ProviderName => "USPS";

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
        /// Determines whether this instance can deliver the specified delivery.
        /// </summary>
        /// <param name="delivery">The delivery.</param>
        /// <returns><c>true</c> if this instance can deliver the specified delivery; otherwise, <c>false</c>.</returns>
        public bool CanDeliver(Delivery delivery)
        {
            // More comprehensive logic has to be implemented
            return true;
        }

        /// <summary>
        /// Gets the quote.
        /// </summary>
        /// <param name="delivery">The delivery.</param>
        /// <returns>System.Decimal.</returns>
        public decimal GetQuote(Delivery delivery)
        {
            decimal result = 0;

            //Calculate shipping cost
            if (delivery?.Items != null && delivery.Items.Count > 0)
            {
                foreach (var item in delivery.Items)
                {
                    if (item == null)
                        continue;

                    result += Formula(item.Product.Width, item.Product.Height, item.Product.Depth, item.Product.Weight, item.Product.Price, delivery.FromAddress, delivery.ShipToAddress, delivery.ShippingOption.OptionCode, delivery.ShippingOption.CustomConfigJson);
                }
            }

            //Limit max price is that is required
            if (delivery != null && delivery.ShippingOption != null && delivery.ShippingOption.MaxPrice.HasValue && result > (decimal)delivery.ShippingOption.MaxPrice.Value)
            {
                result = (decimal)delivery.ShippingOption.MaxPrice.Value;
            }

            return result;
        }

        /// <summary>
        /// Initiates the delivery estimation.
        /// </summary>
        /// <param name="delivery">The delivery.</param>
        /// <returns></returns>        
        public DeliveryResult InitiateDelivery(Delivery delivery)
        {
            //TODO: it has to be implmeneted using real USPS API
            return null;
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
        /// <exception cref="ShippingException">Ship to address cannot be empty when calling rate service.</exception>
        protected override decimal Formula(decimal width, decimal height, decimal depth, decimal weight, decimal cost, Address fromAddress, Address shipToAddress, string optionCode, string customConfigJson = "")
        {
            double result = 0;
            var accRequest = new AccessRequest
            {
                AccessLicenseNumber = _config.AccessLicenseNumber,
                Password = _config.Password,
                UserId = _config.UserId
            };

            if(fromAddress == null)
            {
                //Not set - just return 0 shipping cost
                return 0;
            }

            if (shipToAddress == null)
            {
                throw new ShippingException("Ship to address cannot be empty when calling rate service.");
            }

            var ratingServiceSelectionRequest = new RatingServiceSelectionRequest
            {
                Shipment = new Shipment
                {
                    ShipFrom = new ShipFrom
                    {
                        Address = new Request.Address
                        {
                            AddressLine1 = fromAddress.AddressLine1,
                            AddressLine2 = fromAddress.AddressLine2,
                            City = fromAddress.City,
                            CountryCode = fromAddress.Country, //need conversion to country and get code
                            PostalCode = fromAddress.Zip
                        }
                    },
                    ShipTo = new ShipTo
                    {
                        Address = new Request.Address
                        {
                            AddressLine1 = shipToAddress.AddressLine1,
                            AddressLine2 = shipToAddress.AddressLine2,
                            City = shipToAddress.City,
                            CountryCode = shipToAddress.Country, //need conversion to country and get code
                            PostalCode = shipToAddress.Zip
                        }
                    },
                    Package = new Package
                    {
                        PackageWeight = new PackageWeight
                        {
                            Weight = weight
                        }
                    },
                    Service = new Service
                    {
                        Code = optionCode
                    }
                }
            };
            var request = new USPSRateRequest();
            var responseStr = request.Get(accRequest, ratingServiceSelectionRequest);
            var response = (RatingServiceSelectionResponse) SerializationHelper.DeserializeObj(responseStr, typeof(RatingServiceSelectionResponse));
            if (response != null && response.RatedShipment != null && response.RatedShipment.TotalCharges != null)
                result = response.RatedShipment.TotalCharges.MonetaryValue;

            return (decimal)result;
        }

        //Custom configuration members
        /// <summary>
        /// Gets a value indicating whether [supports custom configuration].
        /// </summary>
        /// <value><c>true</c> if [supports custom configuration]; otherwise, <c>false</c>.</value>
        public bool SupportsCustomConfig => true;
        /// <summary>
        /// Gets the type of the custom configuration.
        /// </summary>
        /// <value>The type of the custom configuration.</value>
        public Type CustomConfigType => typeof(UspsConfig);
        /// <summary>
        /// Gets the custom configuration json example.
        /// </summary>
        /// <value>The custom configuration json example.</value>
        public string CustomConfigJsonExample => JsonConvert.SerializeObject(new UspsConfig());
        /// <summary>
        /// Gets the current custom configuration json.
        /// </summary>
        /// <value>The current custom configuration json.</value>
        public string CurrentCustomConfigJson => _customConfiguration.CurrentConfiguration;

        /// <summary>
        /// Gets a value indicating whether [support branch listing].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [support branch listing]; otherwise, <c>false</c>.
        /// </value>
        public bool SupportBranchListing => false;

        /// <summary>
        /// Updates the configuration.
        /// </summary>
        /// <param name="json">The json.</param>
        public void UpdateConfig(string json)
        {
            _customConfiguration.CurrentConfiguration = json;
            _bl.UpdateCustomConfiguration(_customConfiguration);
        }
        /// <summary>
        /// Resets to default.
        /// </summary>
        public void ResetToDefault()
        {
            _customConfiguration.CurrentConfiguration = _customConfiguration.DefaultConfiguration;
            _bl.UpdateCustomConfiguration(_customConfiguration);
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
    }
}
