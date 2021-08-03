// ***********************************************************************
// Assembly         : BAP.eCommerce.USPSShippingProvider
// Author           : Victor Mamray
// Created          : 05-30-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="RatedShipment.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using BAP.eCommerce.USPSShippingProvider.Response;

namespace BAP.eCommerce.USPSShippingProvider.Request
{
    /// <summary>
    /// Class RatedShipment.
    /// </summary>
    [Serializable]
    public class RatedShipment
    {
        #region Properties

        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        /// <value>The service.</value>
        public Service Service { get; set; }

        /// <summary>
        /// Gets or sets the rated shipment warning.
        /// </summary>
        /// <value>The rated shipment warning.</value>
        public string RatedShipmentWarning { get; set; }

        /// <summary>
        /// Gets or sets the billing weight.
        /// </summary>
        /// <value>The billing weight.</value>
        public BillingWeight BillingWeight { get; set; }

        /// <summary>
        /// Gets or sets the transportation charges.
        /// </summary>
        /// <value>The transportation charges.</value>
        public TransportationCharges TransportationCharges { get; set; }

        /// <summary>
        /// Gets or sets the service options charges.
        /// </summary>
        /// <value>The service options charges.</value>
        public ServiceOptionsCharges ServiceOptionsCharges { get; set; }

        /// <summary>
        /// Gets or sets the total charges.
        /// </summary>
        /// <value>The total charges.</value>
        public TotalCharges TotalCharges { get; set; }

        /// <summary>
        /// Gets or sets the guaranteed days to delivery.
        /// </summary>
        /// <value>The guaranteed days to delivery.</value>
        public string GuaranteedDaysToDelivery { get; set; }

        /// <summary>
        /// Gets or sets the scheduled delivery time.
        /// </summary>
        /// <value>The scheduled delivery time.</value>
        public string ScheduledDeliveryTime { get; set; }

        /// <summary>
        /// Gets or sets the rated package.
        /// </summary>
        /// <value>The rated package.</value>
        public RatedPackage RatedPackage { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="RatedShipment"/> class.
        /// </summary>
        public RatedShipment()
        {
            BillingWeight = new BillingWeight();
            TransportationCharges = new TransportationCharges();
            ServiceOptionsCharges = new ServiceOptionsCharges();
            TotalCharges = new TotalCharges();
            RatedPackage = new RatedPackage();
        }
    }
}
