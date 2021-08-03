// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 05-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="eCommerceContext.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

using BAP.DAL;
using BAP.Log;
using BAP.BL;
using BAP.Common;
using BAP.Lookups;
using BAP.FileSystem;
using BAP.DAL.Entities;
using BAP.eCommerce.DAL.Entities;


namespace BAP.eCommerce.BL.Context
{
    /// <summary>
    /// Class eCommerceContext.
    /// Implements the <see cref="BAP.Common.BAPBaseClassWithLogging" />
    /// Implements the <see cref="BAP.eCommerce.BL.Context.IEcommerceContext" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="BAP.Common.BAPBaseClassWithLogging" />
    /// <seealso cref="BAP.eCommerce.BL.Context.IEcommerceContext" />
    /// <seealso cref="System.IDisposable" />
    public class eCommerceContext : BAPBaseClassWithLogging, IEcommerceContext, IDisposable
    {
        /// <summary>
        /// The lazy
        /// </summary>
        private static readonly Lazy<IEcommerceContext>
        lazy = new Lazy<IEcommerceContext>
        (() => 
        {
            var result = DependencyResolver.Current.GetService<IEcommerceContext>();
            if (result == null)
            {
                ILookupEngine lookupEngine = DependencyResolver.Current.GetService<ILookupEngine>();
                IFileProcessor fileProc = DependencyResolver.Current.GetService<IFileProcessor>();
                IConfigHelper configHelper = DependencyResolver.Current.GetService<IConfigHelper>();
                IAuthorizationContext context = DependencyResolver.Current.GetService<IAuthorizationContext>();
                ILogger logger = DependencyResolver.Current.GetService<ILogger>();
                result = new eCommerceContext(lookupEngine, fileProc, configHelper, context, logger);
            }
            return result;
        });

        /// <summary>
        /// The bl
        /// </summary>
        private readonly eCommerceBusinessLayer _bl;
        /// <summary>
        /// The authentication context
        /// </summary>
        private readonly IAuthorizationContext _authContext;
        /// <summary>
        /// Initializes a new instance of the <see cref="eCommerceContext"/> class.
        /// </summary>
        /// <param name="lookupEngine">The lookup engine.</param>
        /// <param name="fileProc">The file proc.</param>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public eCommerceContext(ILookupEngine lookupEngine, IFileProcessor fileProc, IConfigHelper configHelper, IAuthorizationContext context, ILogger logger) : base(logger)
        {
            _authContext = context;
            _bl = new eCommerceBusinessLayer(lookupEngine, fileProc, configHelper, context, logger);
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static IEcommerceContext Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        /// <summary>
        /// Gets the currencies.
        /// </summary>
        /// <value>The currencies.</value>
        public IList<Currency> Currencies
        {
            get
            {
                return _bl.GetAllCurrencies();
            }
        }

        /// <summary>
        /// Gets or sets the current currency.
        /// </summary>
        /// <value>The current currency.</value>
        public Currency CurrentCurrency { get; set; }

        /// <summary>
        /// Gets the manufacturers.
        /// </summary>
        /// <value>The manufacturers.</value>
        public IList<Manufacturer> Manufacturers
        {
            get
            {
                return _bl.GetAllManufacturers();
            }
        }

        /// <summary>
        /// Gets the suppliers.
        /// </summary>
        /// <value>The suppliers.</value>
        public IList<Supplier> Suppliers
        {
            get
            {
                return _bl.GetAllSuppliers();
            }
        }

        /// <summary>
        /// Gets the product categories.
        /// </summary>
        /// <value>The product categories.</value>
        public IList<ProductCategory> ProductCategories
        {
            get
            {
                var store = _bl.GetDefaultStore();
                var result = _bl.GetAllProductCategories();
                if (store != null)
                {
                    var tmps = store.StoreProductCategories;
                    if (tmps != null)
                    {
                        var query = from category in result
                                    join tmp in tmps on category.Id equals tmp.Id
                                    select category;
                        result = query.ToList();
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <value>The products.</value>
        public IList<Product> Products
        {
            get
            {
                return _bl.GetAllProducts().Where(a => ProductCategories.Any(b => b.Id == a.ProductCategoryId)).ToList();
            }
        }

        /// <summary>
        /// Gets the product options.
        /// </summary>
        /// <value>The product options.</value>
        public IList<ProductOption> ProductOptions
        {
            get
            {
                return _bl.GetAllProductOptions();
            }
        }

        /// <summary>
        /// Gets the shipping carriers.
        /// </summary>
        /// <value>The shipping carriers.</value>
        public IList<ShippingCarrier> ShippingCarriers
        {
            get
            {
                return _bl.GetAllShippingCarriers().Where(a => ShippingOptions.Any(b => b.ShippingCarrierId == a.Id)).ToList();
            }
        }

        /// <summary>
        /// Gets the shipping options.
        /// </summary>
        /// <value>The shipping options.</value>
        public IList<ShippingOption> ShippingOptions
        {
            get
            {
                var store = _bl.GetDefaultStore();
                IList<ShippingOption> result = _bl.GetAllShippingOptions();
                if (store != null)
                {
                    var tmps = store.StoreShippingOptions;
                    if (tmps != null)
                    {
                        var query = from option in result
                                    join tmp in tmps on option.Id equals tmp.Id
                                    select option;
                        result = query.ToList();
                    }
                }


                return result;
            }
        }

        /// <summary>
        /// Gets the payment options.
        /// </summary>
        /// <value>The payment options.</value>
        public IList<PaymentOption> PaymentOptions
        {
            get
            {
                var store = _bl.GetDefaultStore();
                var result = _bl.GetAllPaymentOptions();
                if (store != null)
                {
                    var tmps = store.StorePaymentOptions;
                    if (tmps != null)
                    {
                        var query = from option in result
                                    join tmp in tmps on option.Id equals tmp.Id
                                    select option;
                        result = query.ToList();
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the discount coupons.
        /// </summary>
        /// <value>The discount coupons.</value>
        public IList<DiscountCoupon> DiscountCoupons
        {
            get
            {
                var store = _bl.GetDefaultStore();
                var result = _bl.GetAllDiscountCoupons();
                if (store != null)
                {
                    var tmps = store.StoreDiscountCoupons;
                    if (tmps != null)
                    {
                        var query = from coupon in result
                                    join tmp in tmps on coupon.Id equals tmp.Id
                                    select coupon;
                        result = query.ToList();
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the customers.
        /// </summary>
        /// <value>The customers.</value>
        public IList<Customer> Customers
        {
            get
            {
                return _bl.GetAllCustomers();
            }
        }

        /// <summary>
        /// Gets the orders.
        /// </summary>
        /// <value>The orders.</value>
        public IList<CustomerOrder> Orders
        {
            get
            {
                return _bl.GetAllCustomerOrders();
            }
        }

        /// <summary>
        /// Gets the default store.
        /// </summary>
        /// <value>The default store.</value>
        public Store DefaultStore
        {
            get
            {
                return _bl.GetDefaultStore();
            }
        }

        /// <summary>
        /// Gets the current shopping cart.
        /// </summary>
        /// <value>The current shopping cart.</value>
        public ShoppingCart CurrentShoppingCart
        {
            get
            {
                return _bl.GetCurrentShoppingCart();
            }
        }

        /// <summary>
        /// Gets the current customer.
        /// </summary>
        /// <value>The current customer.</value>
        public Customer CurrentCustomer
        {
            get
            {
                var userId = _authContext.GetCurrentUserId();
                if (!string.IsNullOrEmpty(userId))
                {
                    var orgUserBL = (IOrganizationUserBL)_bl;
                    var orgUser = orgUserBL.GetOrganizationUserByAspNetId(userId);
                    if (orgUserBL != null)
                        return _bl.GetCustomerByUserId(orgUser.Id);
                }

                return null;
            }
        }

        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed = false;
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _bl.Dispose();
                }
            }
            this._disposed = true;
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
