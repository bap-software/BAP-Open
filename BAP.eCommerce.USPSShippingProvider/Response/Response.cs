// ***********************************************************************
// Assembly         : BAP.eCommerce.USPSShippingProvider
// Author           : Victor Mamray
// Created          : 05-30-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="Response.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BAP.eCommerce.USPSShippingProvider.Response
{
    /// <summary>
    /// Class Response.
    /// </summary>
    [Serializable]
    public class Response
    {
        #region Properties

        /// <summary>
        /// Gets or sets the response status code.
        /// </summary>
        /// <value>The response status code.</value>
        public int ResponseStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the response status description.
        /// </summary>
        /// <value>The response status description.</value>
        public string ResponseStatusDescription { get; set; }

        #endregion
    }
}
