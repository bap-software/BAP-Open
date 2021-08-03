// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ShippingOptionDC.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.eCommerce.BL.DataContracts
{
    /// <summary>
    /// Class ShippingOptionDC.
    /// </summary>
    public class ShippingOptionDC
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }
        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        public string Icon { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        public string ShortDescription { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ShippingOptionDC"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public bool Enabled { get; set; }
        /// <summary>
        /// Gets or sets the shipping carrier identifier.
        /// </summary>
        /// <value>The shipping carrier identifier.</value>
        public int ShippingCarrierId { get; set; }
        /// <summary>
        /// Gets or sets the name of the shipping carrier.
        /// </summary>
        /// <value>The name of the shipping carrier.</value>
        public string ShippingCarrierName { get; set; }
        /// <summary>
        /// Gets or sets the basic cost.
        /// </summary>
        /// <value>The basic cost.</value>
        public decimal BasicCost { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ShippingOptionDC"/> is selected.
        /// </summary>
        /// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
        public bool Selected { get; set; }
    }
}