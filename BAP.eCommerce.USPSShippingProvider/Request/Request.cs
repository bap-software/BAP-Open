// ***********************************************************************
// Assembly         : BAP.eCommerce.USPSShippingProvider
// Author           : Victor Mamray
// Created          : 05-30-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="Request.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BAP.eCommerce.USPSShippingProvider.Request
{
    /// <summary>
    /// Class Request.
    /// </summary>
    [Serializable]
    public class Request
    {
        /// <summary>
        /// Gets or sets the transaction reference.
        /// </summary>
        /// <value>The transaction reference.</value>
        public TransactionReference TransactionReference { get; set; }

        /// <summary>
        /// Gets or sets the request action.
        /// </summary>
        /// <value>The request action.</value>
        public string RequestAction { get; set; }

        /// <summary>
        /// Gets or sets the request option.
        /// </summary>
        /// <value>The request option.</value>
        public string RequestOption { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Request"/> class.
        /// </summary>
        public Request()
        {
            TransactionReference = new TransactionReference();
            RequestAction = "Rate";
            RequestOption = "Rate";
        }
    }
}
