// ***********************************************************************
// Assembly         : BAP.eCommerce.USPSShippingProvider
// Author           : Victor Mamray
// Created          : 05-30-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="BillingWeight.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using BAP.eCommerce.USPSShippingProvider.Request;

namespace BAP.eCommerce.USPSShippingProvider.Response
{
    /// <summary>
    /// Class BillingWeight.
    /// </summary>
    [Serializable]
    public class BillingWeight
    {
        /// <summary>
        /// Gets or sets the unit of measurement.
        /// </summary>
        /// <value>The unit of measurement.</value>
        public UnitOfMeasurement UnitOfMeasurement { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>The weight.</value>
        public double Weight { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BillingWeight"/> class.
        /// </summary>
        public BillingWeight()
        {
            UnitOfMeasurement = new UnitOfMeasurement();
        }
    }
}
