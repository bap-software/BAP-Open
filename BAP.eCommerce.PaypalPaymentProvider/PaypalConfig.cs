// ***********************************************************************
// Assembly         : BAP.eCommerce.PaypalPaymentProvider
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="PayPalConfig.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.eCommerce.PaypalPaymentProvider
{
    /// <summary>
    /// Class PayPalConfig.
    /// </summary>
    class PayPalConfig
    {
        /// <summary>
        /// Gets or sets the environment.
        /// </summary>
        /// <value>The environment.</value>
        public string Environment { get; set; } = "sandbox | production";
        /// <summary>
        /// Gets or sets the production client identifier.
        /// </summary>
        /// <value>The production client identifier.</value>
        public string ProductionClientId { get; set; } = "<input product client id>";
        /// <summary>
        /// Gets or sets the sandbox client identifier.
        /// </summary>
        /// <value>The sandbox client identifier.</value>
        public string SandboxClientId { get; set; } = "AZDxjDScFpQtjWTOUtWKbyN_bDt4OgqaF4eYXlewfBP4-8aqX3PiV8e1GWU6liB2CUXlkA59kJXE7M6R";
        /// <summary>
        /// Gets or sets the java script URL.
        /// </summary>
        /// <value>The java script URL.</value>
        public string JavaScriptUrl { get; set; } = "https://www.paypalobjects.com/api/checkout.js";
    }
}
