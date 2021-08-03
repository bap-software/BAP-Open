// ***********************************************************************
// Assembly         : BAP.eCommerce.AuthorizeNetPaymentProvider
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="AuthorizeNetConfig.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.eCommerce.AuthorizeNetPaymentProvider
{
    /// <summary>
    /// Class AuthorizeNetConfig.
    /// </summary>
    class AuthorizeNetConfig
    {
        /// <summary>
        /// Gets or sets the environment.
        /// </summary>
        /// <value>The environment.</value>
        public string Environment { get; set; } = "sandbox | live";
        /// <summary>
        /// Gets or sets the API login identifier.
        /// </summary>
        /// <value>The API login identifier.</value>
        public string ApiLoginId { get; set; } = "6wrrcJ2g9Nk";
        /// <summary>
        /// Gets or sets the API transaction key.
        /// </summary>
        /// <value>The API transaction key.</value>
        public string ApiTransactionKey { get; set; } = "2x4CG7QduJs529QE";
        /// <summary>
        /// Gets or sets a net form URL.
        /// </summary>
        /// <value>a net form URL.</value>
        public string ANetFormUrl { get; set; } = "https://test.authorize.net/payment/payment";
    }
}
