// ***********************************************************************
// Assembly         : BAP.eCommerce.USPSShippingProvider
// Author           : Victor Mamray
// Created          : 05-30-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="TransactionReference.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BAP.eCommerce.USPSShippingProvider.Request
{
    /// <summary>
    /// Class TransactionReference.
    /// </summary>
    [Serializable]
    public class TransactionReference
    {
        /// <summary>
        /// Gets or sets the customer context.
        /// </summary>
        /// <value>The customer context.</value>
        public string CustomerContext { get; set; }

        /// <summary>
        /// Gets or sets the xpci version.
        /// </summary>
        /// <value>The xpci version.</value>
        public string XpciVersion { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionReference"/> class.
        /// </summary>
        public TransactionReference()
        {
            CustomerContext = "Rating and Service";
            XpciVersion = "1.0";
        }
    }
}
