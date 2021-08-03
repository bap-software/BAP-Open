// ***********************************************************************
// Assembly         : BAP.eCommerce.SchedulingTasks
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="AbandonedShoppingCartsData.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.eCommerce.SchedulingTasks
{
    /// <summary>
    /// Class AbandonedShoppingCartsData.
    /// </summary>
    public class AbandonedShoppingCartsData
    {
        /// <summary>
        /// Gets or sets the days to keep shopping carts.
        /// </summary>
        /// <value>The days to keep shopping carts.</value>
        public int DaysToKeepShoppingCarts { get; set; }
    }
}