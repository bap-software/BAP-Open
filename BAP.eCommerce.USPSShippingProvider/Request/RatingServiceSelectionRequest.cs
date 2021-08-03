// ***********************************************************************
// Assembly         : BAP.eCommerce.USPSShippingProvider
// Author           : Victor Mamray
// Created          : 05-30-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="RatingServiceSelectionRequest.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BAP.eCommerce.USPSShippingProvider.Request
{
    /// <summary>
    /// Class RatingServiceSelectionRequest.
    /// </summary>
    [Serializable]
    public class RatingServiceSelectionRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the request.
        /// </summary>
        /// <value>The request.</value>
        public Request Request { get; set; }

        /// <summary>
        /// Gets or sets the type of the pickup.
        /// </summary>
        /// <value>The type of the pickup.</value>
        public PickupType PickupType { get; set; }

        /// <summary>
        /// Gets or sets the shipment.
        /// </summary>
        /// <value>The shipment.</value>
        public Shipment Shipment { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="RatingServiceSelectionRequest"/> class.
        /// </summary>
        public RatingServiceSelectionRequest()
        {
            Request = new Request();
            PickupType = new PickupType();
            Shipment = new Shipment();
        }
    }
}
