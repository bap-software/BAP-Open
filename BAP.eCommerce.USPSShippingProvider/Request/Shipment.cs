// ***********************************************************************
// Assembly         : BAP.eCommerce.USPSShippingProvider
// Author           : Victor Mamray
// Created          : 05-30-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="Shipment.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BAP.eCommerce.USPSShippingProvider.Request
{
    /// <summary>
    /// Class Shipment.
    /// </summary>
    [Serializable]
    public class Shipment
    {
        #region Properties

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the shipper.
        /// </summary>
        /// <value>The shipper.</value>
        public Shipper Shipper { get; set; }

        /// <summary>
        /// Gets or sets the ship to.
        /// </summary>
        /// <value>The ship to.</value>
        public ShipTo ShipTo { get; set; }

        /// <summary>
        /// Gets or sets the ship from.
        /// </summary>
        /// <value>The ship from.</value>
        public ShipFrom ShipFrom { get; set; }

        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        /// <value>The service.</value>
        public Service Service { get; set; }

        /// <summary>
        /// Gets or sets the package.
        /// </summary>
        /// <value>The package.</value>
        public Package Package { get; set; }

        /// <summary>
        /// Gets or sets the shipment service options.
        /// </summary>
        /// <value>The shipment service options.</value>
        public ShipmentServiceOptions ShipmentServiceOptions { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Shipment"/> class.
        /// </summary>
        public Shipment()
        {
            Description = "Rate Shopping - Domestic";
            Shipper = new Shipper();
            ShipTo = new ShipTo();
            ShipFrom = new ShipFrom();
            Service = new Service();
            Package = new Package();
            ShipmentServiceOptions = new ShipmentServiceOptions();
        }
    }
}
