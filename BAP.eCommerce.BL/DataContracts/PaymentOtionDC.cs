// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="PaymentOtionDC.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.eCommerce.BL.DataContracts
{
    /// <summary>
    /// Class PaymentOtionDC.
    /// </summary>
    public class PaymentOtionDC
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
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
        /// Gets or sets a value indicating whether this instance is prefered.
        /// </summary>
        /// <value><c>true</c> if this instance is prefered; otherwise, <c>false</c>.</value>
        public bool IsPrefered { get; set; }
        /// <summary>
        /// Gets or sets the customer payment identifier.
        /// </summary>
        /// <value>The customer payment identifier.</value>
        public int CustomerPaymentId { get; set; }
        /// <summary>
        /// Gets or sets the customer payment description.
        /// </summary>
        /// <value>The customer payment description.</value>
        public string CustomerPaymentDescription { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PaymentOtionDC"/> is selected.
        /// </summary>
        /// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
        public bool Selected { get; set; }
    }
}