// ***********************************************************************
// Assembly         : BAP.eCommerce.USPSShippingProvider
// Author           : Victor Mamray
// Created          : 05-30-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="RatedPackage.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using BAP.eCommerce.USPSShippingProvider.Response;

namespace BAP.eCommerce.USPSShippingProvider.Request
{
    /// <summary>
    /// Class RatedPackage.
    /// </summary>
    [Serializable]
    public class RatedPackage
    {
        #region Properties

        /// <summary>
        /// Gets or sets the transportation charges.
        /// </summary>
        /// <value>The transportation charges.</value>
        public TransportationCharges TransportationCharges { get; set; }

        /// <summary>
        /// Gets or sets the service options charges.
        /// </summary>
        /// <value>The service options charges.</value>
        public ServiceOptionsCharges ServiceOptionsCharges { get; set; }

        /// <summary>
        /// Gets or sets the total charges.
        /// </summary>
        /// <value>The total charges.</value>
        public TotalCharges TotalCharges { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>The weight.</value>
        public double Weight { get; set; }

        /// <summary>
        /// Gets or sets the billing weight.
        /// </summary>
        /// <value>The billing weight.</value>
        public BillingWeight BillingWeight { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="RatedPackage"/> class.
        /// </summary>
        public RatedPackage()
        {
            TransportationCharges = new TransportationCharges();
            ServiceOptionsCharges = new ServiceOptionsCharges();
            TotalCharges = new TotalCharges();
        }
    }
}
