// ***********************************************************************
// Assembly         : BAP.eCommerce.USPSShippingProvider
// Author           : Victor Mamray
// Created          : 05-30-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ShipFrom.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BAP.eCommerce.USPSShippingProvider.Request
{
    /// <summary>
    /// Class ShipFrom.
    /// Implements the <see cref="BAP.eCommerce.USPSShippingProvider.Request.ShipTo" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.USPSShippingProvider.Request.ShipTo" />
    [Serializable]
    public class ShipFrom : ShipTo
    {
        /// <summary>
        /// Gets or sets the fax number.
        /// </summary>
        /// <value>The fax number.</value>
        public string FaxNumber { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShipFrom"/> class.
        /// </summary>
        public ShipFrom()
        {
            Address = new Address();
        }
    }
}
