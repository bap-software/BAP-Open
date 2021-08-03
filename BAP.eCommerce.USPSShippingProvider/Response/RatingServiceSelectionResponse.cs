// ***********************************************************************
// Assembly         : BAP.eCommerce.USPSShippingProvider
// Author           : Victor Mamray
// Created          : 05-30-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="RatingServiceSelectionResponse.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.eCommerce.USPSShippingProvider.Request;

namespace BAP.eCommerce.USPSShippingProvider.Response
{
    /// <summary>
    /// Class RatingServiceSelectionResponse.
    /// </summary>
    public class RatingServiceSelectionResponse
    {
        #region Properties

        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>The response.</value>
        public Response Response { get; set; }

        /// <summary>
        /// Gets or sets the rated shipment.
        /// </summary>
        /// <value>The rated shipment.</value>
        public RatedShipment RatedShipment { get; set; }

        #endregion
    }
}
