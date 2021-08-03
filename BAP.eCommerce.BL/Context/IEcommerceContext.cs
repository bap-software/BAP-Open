// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="IEcommerceContext.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using BAP.DAL.Entities;
using BAP.eCommerce.DAL.Entities;

namespace BAP.eCommerce.BL.Context
{
    /// <summary>
    /// Interface IEcommerceContext
    /// </summary>
    public interface IEcommerceContext
    {
        /// <summary>
        /// Gets the currencies.
        /// </summary>
        /// <value>The currencies.</value>
        IList<Currency> Currencies { get; }
        /// <summary>
        /// Gets or sets the current currency.
        /// </summary>
        /// <value>The current currency.</value>
        Currency CurrentCurrency { get; set; }
        /// <summary>
        /// Gets the manufacturers.
        /// </summary>
        /// <value>The manufacturers.</value>
        IList<Manufacturer> Manufacturers { get; }
        /// <summary>
        /// Gets the suppliers.
        /// </summary>
        /// <value>The suppliers.</value>
        IList<Supplier> Suppliers { get; }
        /// <summary>
        /// Gets the product categories.
        /// </summary>
        /// <value>The product categories.</value>
        IList<ProductCategory> ProductCategories { get; }
        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <value>The products.</value>
        IList<Product> Products { get; }
        /// <summary>
        /// Gets the product options.
        /// </summary>
        /// <value>The product options.</value>
        IList<ProductOption> ProductOptions { get; }
        /// <summary>
        /// Gets the shipping carriers.
        /// </summary>
        /// <value>The shipping carriers.</value>
        IList<ShippingCarrier> ShippingCarriers { get; }
        /// <summary>
        /// Gets the shipping options.
        /// </summary>
        /// <value>The shipping options.</value>
        IList<ShippingOption> ShippingOptions { get; }
        /// <summary>
        /// Gets the payment options.
        /// </summary>
        /// <value>The payment options.</value>
        IList<PaymentOption> PaymentOptions { get; }
        /// <summary>
        /// Gets the discount coupons.
        /// </summary>
        /// <value>The discount coupons.</value>
        IList<DiscountCoupon> DiscountCoupons { get; }
        /// <summary>
        /// Gets the customers.
        /// </summary>
        /// <value>The customers.</value>
        IList<Customer> Customers { get; }
        /// <summary>
        /// Gets the orders.
        /// </summary>
        /// <value>The orders.</value>
        IList<CustomerOrder> Orders { get; }

        /// <summary>
        /// Gets the default store.
        /// </summary>
        /// <value>The default store.</value>
        Store DefaultStore { get; }
        /// <summary>
        /// Gets the current shopping cart.
        /// </summary>
        /// <value>The current shopping cart.</value>
        ShoppingCart CurrentShoppingCart { get; }
        /// <summary>
        /// Gets the current customer.
        /// </summary>
        /// <value>The current customer.</value>
        Customer CurrentCustomer { get; }
    }
}
