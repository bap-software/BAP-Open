// ***********************************************************************
// Assembly         : BAP.eCommerce.USPSShippingProvider
// Author           : Victor Mamray
// Created          : 05-30-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="Charges.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.eCommerce.USPSShippingProvider.Response
{
    /// <summary>
    /// Class Charges.
    /// </summary>
    public abstract class Charges
    {
        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>The currency code.</value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the monetary value.
        /// </summary>
        /// <value>The monetary value.</value>
        public double MonetaryValue { get; set; }
    }
}
