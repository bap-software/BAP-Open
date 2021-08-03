// ***********************************************************************
// Assembly         : BAP.eCommerce.USPSShippingProvider
// Author           : Victor Mamray
// Created          : 05-30-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="Shipper.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BAP.eCommerce.USPSShippingProvider.Request
{
    /// <summary>
    /// Class Shipper.
    /// </summary>
    [Serializable]
    public class Shipper
    {
        /// <summary>
        /// Gets or sets the shipper number.
        /// </summary>
        /// <value>The shipper number.</value>
        public string ShipperNumber { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public Address Address { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Shipper"/> class.
        /// </summary>
        public Shipper()
        {
            Address = new Address();
        }
    }
}
