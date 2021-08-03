// ***********************************************************************
// Assembly         : BAP.eCommerce.USPSShippingProvider
// Author           : Victor Mamray
// Created          : 05-30-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="PackageWeight.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BAP.eCommerce.USPSShippingProvider.Request
{
    /// <summary>
    /// Class PackageWeight.
    /// </summary>
    [Serializable]
    public class PackageWeight
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
        public decimal Weight { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PackageWeight"/> class.
        /// </summary>
        public PackageWeight()
        {
            UnitOfMeasurement = new UnitOfMeasurement();
            Weight = (decimal)1.0;
        }
    }
}
