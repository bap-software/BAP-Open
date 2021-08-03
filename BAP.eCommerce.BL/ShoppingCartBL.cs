// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ShoppingCartBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;

using PagedList;

using BAP.eCommerce.DAL.Entities;
using BAP.Common;
using System.Linq;
using System.Threading.Tasks;
using BAP.BL;
using BAP.DAL.Entities;
using BAP.eCommerce.Common.Exceptions;
using BAP.DAL;
using BAP.eCommerce.BL.DataContracts;
using BAP.eCommerce.DAL;
using Newtonsoft.Json;

namespace BAP.eCommerce.BL
{
    /// <summary>
    /// Interface IShoppingCartBL
    /// </summary>
    public interface IShoppingCartBL
    {
        /// <summary>
        /// Gets all shopping carts.
        /// </summary>
        /// <returns>IList&lt;ShoppingCart&gt;.</returns>
        IList<ShoppingCart> GetAllShoppingCarts();
        /// <summary>
        /// Gets all shopping carts asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;ShoppingCart&gt;&gt;.</returns>
        Task<IList<ShoppingCart>> GetAllShoppingCartsAsync();

        /// <summary>
        /// Searches the shopping carts.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ShoppingCart&gt;.</returns>
        IPagedList<ShoppingCart> SearchShoppingCarts(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the shopping carts asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;ShoppingCart&gt;&gt;.</returns>
        Task<IPagedList<ShoppingCart>> SearchShoppingCartsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Searches the admin shopping carts.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ShoppingCart&gt;.</returns>
        IPagedList<ShoppingCart> SearchAdminShoppingCarts(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the admin shopping carts asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;ShoppingCart&gt;&gt;.</returns>
        Task<IPagedList<ShoppingCart>> SearchAdminShoppingCartsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Searches the API shopping carts.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ShoppingCart&gt;.</returns>
        IPagedList<ShoppingCart> SearchApiShoppingCarts(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the API shopping carts asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;ShoppingCart&gt;&gt;.</returns>
        Task<IPagedList<ShoppingCart>> SearchApiShoppingCartsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the single shopping cart by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShoppingCart.</returns>
        ShoppingCart GetSingleShoppingCartById(int id);
        /// <summary>
        /// Gets the single shopping cart by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ShoppingCart&gt;.</returns>
        Task<ShoppingCart> GetSingleShoppingCartByIdAsync(int id);

        /// <summary>
        /// Gets the shopping cart with products by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShoppingCart.</returns>
        ShoppingCart GetShoppingCartWithProductsById(int id);
        /// <summary>
        /// Gets the shopping cart with products by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ShoppingCart&gt;.</returns>
        Task<ShoppingCart> GetShoppingCartWithProductsByIdAsync(int id);

        /// <summary>
        /// Gets the admin shopping cart by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShoppingCart.</returns>
        ShoppingCart GetAdminShoppingCartById(int id);
        /// <summary>
        /// Gets the admin shopping cart by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ShoppingCart&gt;.</returns>
        Task<ShoppingCart> GetAdminShoppingCartByIdAsync(int id);

        /// <summary>
        /// Gets the shopping cart by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShoppingCart.</returns>
        ShoppingCart GetShoppingCartById(int id);
        /// <summary>
        /// Gets the shopping cart by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ShoppingCart&gt;.</returns>
        Task<ShoppingCart> GetShoppingCartByIdAsync(int id);

        /// <summary>
        /// Gets the current shopping cart.
        /// </summary>
        /// <returns>ShoppingCart.</returns>
        ShoppingCart GetCurrentShoppingCart();
        /// <summary>
        /// Gets the current shopping cart asynchronous.
        /// </summary>
        /// <returns>Task&lt;ShoppingCart&gt;.</returns>
        Task<ShoppingCart> GetCurrentShoppingCartAsync();

        /// <summary>
        /// Gets the shopping carts older than.
        /// </summary>
        /// <param name="days">The days.</param>
        /// <returns>IList&lt;ShoppingCart&gt;.</returns>
        IList<ShoppingCart> GetShoppingCartsOlderThan(int days);
        /// <summary>
        /// Gets the shopping carts older than asynchronous.
        /// </summary>
        /// <param name="days">The days.</param>
        /// <returns>Task&lt;IList&lt;ShoppingCart&gt;&gt;.</returns>
        Task<IList<ShoppingCart>> GetShoppingCartsOlderThanAsync(int days);

        /// <summary>
        /// Pulls the address from user.
        /// </summary>
        /// <param name="cart">The cart.</param>
        void PullAddressFromUser(ShoppingCart cart);
        /// <summary>
        /// Pulls the address from user asynchronous.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>Task.</returns>
        Task PullAddressFromUserAsync(ShoppingCart cart);

        /// <summary>
        /// Gets the shipping cost.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        /// <returns>System.Decimal.</returns>
        decimal GetShippingCost(ShoppingCart shoppingCart);
        /// <summary>
        /// Gets the shipping cost asynchronous.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        /// <returns>Task&lt;System.Decimal&gt;.</returns>
        Task<decimal> GetShippingCostAsync(ShoppingCart shoppingCart);

        /// <summary>
        /// Adds the shopping cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        void AddShoppingCart(ShoppingCart cart);
        /// <summary>
        /// Adds the shopping cart asynchronous.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>Task.</returns>
        Task AddShoppingCartAsync(ShoppingCart cart);

        /// <summary>
        /// Updates the shopping cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        void UpdateShoppingCart(ShoppingCart cart);
        /// <summary>
        /// Updates the shopping cart asynchronous.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>Task.</returns>
        Task UpdateShoppingCartAsync(ShoppingCart cart);

        /// <summary>
        /// Removes the shopping cart.
        /// </summary>
        /// <param name="shoppingCarts">The shopping carts.</param>
        void RemoveShoppingCart(params ShoppingCart[] shoppingCarts);
        /// <summary>
        /// Removes the shopping cart asynchronous.
        /// </summary>
        /// <param name="shoppingCarts">The shopping carts.</param>
        /// <returns>Task.</returns>
        Task RemoveShoppingCartAsync(params ShoppingCart[] shoppingCarts);

        /// <summary>
        /// Adds the product to shopping cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="product">The product.</param>
        /// <param name="count">The count.</param>
        void AddProductToShoppingCart(ShoppingCart cart, Product product, int count);
        /// <summary>
        /// Adds the product to shopping cart asynchronous.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="product">The product.</param>
        /// <param name="count">The count.</param>
        /// <returns>Task.</returns>
        Task AddProductToShoppingCartAsync(ShoppingCart cart, Product product, int count);

        /// <summary>
        /// Removes the product from shopping cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="product">The product.</param>
        void RemoveProductFromShoppingCart(ShoppingCart cart, ShoppingCartProduct product);
        /// <summary>
        /// Removes the product from shopping cart asynchronous.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="product">The product.</param>
        /// <returns>Task.</returns>
        Task RemoveProductFromShoppingCartAsync(ShoppingCart cart, ShoppingCartProduct product);

        /// <summary>
        /// Updates the product count.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="shoppingCartProductId">The shopping cart product identifier.</param>
        /// <param name="count">The count.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool UpdateProductCount(ShoppingCart cart, int shoppingCartProductId, int count);

        /// <summary>
        /// Adds the product option.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="product">The product.</param>
        /// <param name="option">The option.</param>
        /// <param name="optionValue">The option value.</param>
        void AddProductOption(ShoppingCart cart, Product product, ProductOptionItem option, string optionValue);
        /// <summary>
        /// Adds the product option asynchronous.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="product">The product.</param>
        /// <param name="option">The option.</param>
        /// <param name="optionValue">The option value.</param>
        /// <returns>Task.</returns>
        Task AddProductOptionAsync(ShoppingCart cart, Product product, ProductOptionItem option, string optionValue);

        /// <summary>
        /// Applies the discount coupon.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="couponCode">The coupon code.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool ApplyDiscountCoupon(ShoppingCart cart, string couponCode);
        /// <summary>
        /// Applies the discount coupon asynchronous.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="couponCode">The coupon code.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> ApplyDiscountCouponAsync(ShoppingCart cart, string couponCode);

        /// <summary>
        /// Saves the addresses.
        /// </summary>
        /// <param name="cart">The cart.</param>
        void SaveAddresses(ShoppingCart cart);
        /// <summary>
        /// Saves the addresses asynchronous.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>Task.</returns>
        Task SaveAddressesAsync(ShoppingCart cart);

        /// <summary>
        /// Sets the shipping option.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="shippingOptionId">The shipping option identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool SetShippingOption(ShoppingCart cart, int shippingOptionId);
        /// <summary>
        /// Sets the shipping option asynchronous.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="shippingOptionId">The shipping option identifier.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> SetShippingOptionAsync(ShoppingCart cart, int shippingOptionId);

        /// <summary>
        /// Sets the payment option.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="paymentOptionId">The payment option identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool SetPaymentOption(ShoppingCart cart, int paymentOptionId);
        /// <summary>
        /// Sets the payment option asynchronous.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="paymentOptionId">The payment option identifier.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> SetPaymentOptionAsync(ShoppingCart cart, int paymentOptionId);

        /// <summary>
        /// Converts to order.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>CustomerOrder.</returns>
        CustomerOrder ConvertToOrder(ShoppingCart cart);
        /// <summary>
        /// Converts to order asynchronous.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>Task&lt;CustomerOrder&gt;.</returns>
        Task<CustomerOrder> ConvertToOrderAsync(ShoppingCart cart);

        /// <summary>
        /// Sets the shopping cart custom data.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="data">The data.</param>
        void SetShoppingCartCustomData(ShoppingCart cart, ShoppingCartCustomData data);

        /// <summary>
        /// Gets the shopping cart custom data.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns></returns>
        ShoppingCartCustomData GetShoppingCartCustomData(ShoppingCart cart);

        /// <summary>
        /// Find any related products suppliers in shopping cart and execute them
        /// </summary>
        List<SupplierProductsPairDC> MergeSuppliers(ShoppingCart cart);
    }

    /// <summary>
    /// Class eCommerceBusinessLayer.
    /// Implements the <see cref="BAP.BL.BusinessLayer" />
    /// Implements the <see cref="BAP.eCommerce.BL.IProductOptionBL" />
    /// Implements the <see cref="ProductOption" />
    /// Implements the <see cref="BAP.eCommerce.BL.ICustomerOrderBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.ICustomerOrderWorkflow" />
    /// Implements the <see cref="BAP.eCommerce.BL.IStoreBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.IOrderItemBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.ISupplierBL" />
    /// Implements the <see cref="Supplier" />
    /// Implements the <see cref="System.IDisposable" />
    /// Implements the <see cref="BAP.eCommerce.BL.IProductCategoryBL" />
    /// Implements the <see cref="ProductCategory" />
    /// Implements the <see cref="BAP.eCommerce.BL.IPaymentOptionBL" />
    /// Implements the <see cref="PaymentOption" />
    /// Implements the <see cref="BAP.eCommerce.BL.IProductBL" />
    /// Implements the <see cref="Product" />
    /// Implements the <see cref="BAP.eCommerce.BL.IManufacturerBL" />
    /// Implements the <see cref="Manufacturer" />
    /// Implements the <see cref="BAP.eCommerce.BL.IShippingOptionBL" />
    /// Implements the <see cref="ShippingOption" />
    /// Implements the <see cref="BAP.eCommerce.BL.IProductOptionItemBL" />
    /// Implements the <see cref="ProductOptionItem" />
    /// Implements the <see cref="BAP.eCommerce.BL.IShoppingCartBL" />
    /// Implements the <see cref="ShoppingCart" />
    /// Implements the <see cref="BAP.eCommerce.BL.IShippingCarrierBL" />
    /// Implements the <see cref="ShippingCarrier" />
    /// Implements the <see cref="BAP.eCommerce.BL.ICustomerPaymentBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.ICustomerOrderPaymentBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.IDiscountCouponBL" />
    /// Implements the <see cref="DiscountCoupon" />
    /// Implements the <see cref="BAP.eCommerce.BL.IAddressBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.IShoppingCartProductBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.ICustomerBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.IRelatedProductBL" />
    /// </summary>
    /// <seealso cref="BAP.BL.BusinessLayer" />
    /// <seealso cref="BAP.eCommerce.BL.IProductOptionBL" />
    /// <seealso cref="ProductOption" />
    /// <seealso cref="BAP.eCommerce.BL.ICustomerOrderBL" />
    /// <seealso cref="BAP.eCommerce.BL.ICustomerOrderWorkflow" />
    /// <seealso cref="BAP.eCommerce.BL.IStoreBL" />
    /// <seealso cref="BAP.eCommerce.BL.IOrderItemBL" />
    /// <seealso cref="BAP.eCommerce.BL.ISupplierBL" />
    /// <seealso cref="Supplier" />
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="BAP.eCommerce.BL.IProductCategoryBL" />
    /// <seealso cref="ProductCategory" />
    /// <seealso cref="BAP.eCommerce.BL.IPaymentOptionBL" />
    /// <seealso cref="PaymentOption" />
    /// <seealso cref="BAP.eCommerce.BL.IProductBL" />
    /// <seealso cref="Product" />
    /// <seealso cref="BAP.eCommerce.BL.IManufacturerBL" />
    /// <seealso cref="Manufacturer" />
    /// <seealso cref="BAP.eCommerce.BL.IShippingOptionBL" />
    /// <seealso cref="ShippingOption" />
    /// <seealso cref="BAP.eCommerce.BL.IProductOptionItemBL" />
    /// <seealso cref="ProductOptionItem" />
    /// <seealso cref="BAP.eCommerce.BL.IShoppingCartBL" />
    /// <seealso cref="ShoppingCart" />
    /// <seealso cref="BAP.eCommerce.BL.IShippingCarrierBL" />
    /// <seealso cref="ShippingCarrier" />
    /// <seealso cref="BAP.eCommerce.BL.ICustomerPaymentBL" />
    /// <seealso cref="BAP.eCommerce.BL.ICustomerOrderPaymentBL" />
    /// <seealso cref="BAP.eCommerce.BL.IDiscountCouponBL" />
    /// <seealso cref="DiscountCoupon" />
    /// <seealso cref="BAP.eCommerce.BL.IAddressBL" />
    /// <seealso cref="BAP.eCommerce.BL.IShoppingCartProductBL" />
    /// <seealso cref="BAP.eCommerce.BL.ICustomerBL" />
    /// <seealso cref="BAP.eCommerce.BL.IRelatedProductBL" />
    public partial class eCommerceBusinessLayer : IShoppingCartBL, ICriteriaSupport<ShoppingCart>
    {
        /// <summary>
        /// Gets all shopping carts.
        /// </summary>
        /// <returns>IList&lt;ShoppingCart&gt;.</returns>
        public IList<ShoppingCart> GetAllShoppingCarts()
        {
            return _eCommerceUnitOfWork.ShoppingCartRepository.GetAll().ToList();
        }

        /// <summary>
        /// get all shopping carts as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;ShoppingCart&gt;.</returns>
        public async Task<IList<ShoppingCart>> GetAllShoppingCartsAsync()
        {
            return await _eCommerceUnitOfWork.ShoppingCartRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the shopping carts.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ShoppingCart&gt;.</returns>
        public IPagedList<ShoppingCart> SearchShoppingCarts(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<ShoppingCart>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            var result = _eCommerceUnitOfWork.ShoppingCartRepository.GetPagedList(page, pageSize, ParseJSONSearchString<ShoppingCart>(where), sortExpression, a => a.User, a => a.ShoppingCartProducts);
            foreach (var cart in result)
            {
                RecalculateCart(cart);
            }
            return result;
        }

        /// <summary>
        /// search shopping carts as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ShoppingCart&gt;.</returns>
        public async Task<IPagedList<ShoppingCart>> SearchShoppingCartsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<ShoppingCart>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            var result = await _eCommerceUnitOfWork.ShoppingCartRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<ShoppingCart>(where), sortExpression, a => a.User, a => a.ShoppingCartProducts);
            foreach (var cart in result)
            {
                RecalculateCart(cart);
            }
            return result;
        }

        /// <summary>
        /// Searches the admin shopping carts.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ShoppingCart&gt;.</returns>
        public IPagedList<ShoppingCart> SearchAdminShoppingCarts(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<ShoppingCart>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            var result = _eCommerceUnitOfWork.ShoppingCartRepository.GetPagedList(page, pageSize, ParseJSONSearchString<ShoppingCart>(where), sortExpression, a => a.User, a => a.ShoppingCartProducts);
            return result;
        }

        /// <summary>
        /// search admin shopping carts as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ShoppingCart&gt;.</returns>
        public async Task<IPagedList<ShoppingCart>> SearchAdminShoppingCartsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<ShoppingCart>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            var result = await _eCommerceUnitOfWork.ShoppingCartRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<ShoppingCart>(where), sortExpression, a => a.User, a => a.ShoppingCartProducts);
            return result;
        }

        /// <summary>
        /// Searches the API shopping carts.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ShoppingCart&gt;.</returns>
        public IPagedList<ShoppingCart> SearchApiShoppingCarts(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<ShoppingCart>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            var result = _eCommerceUnitOfWork.ShoppingCartRepository.GetPagedList(page, pageSize, ParseJSONSearchString<ShoppingCart>(where), sortExpression);
            return result;
        }

        /// <summary>
        /// search API shopping carts as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ShoppingCart&gt;.</returns>
        public async Task<IPagedList<ShoppingCart>> SearchApiShoppingCartsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<ShoppingCart>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            var result = await _eCommerceUnitOfWork.ShoppingCartRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<ShoppingCart>(where), sortExpression);
            return result;
        }

        /// <summary>
        /// Gets the single shopping cart by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShoppingCart.</returns>
        public ShoppingCart GetSingleShoppingCartById(int id)
        {
            var shoppingCart = _eCommerceUnitOfWork.ShoppingCartRepository.GetSingle(a => a.Id == id);
            return shoppingCart;
        }

        /// <summary>
        /// get single shopping cart by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShoppingCart.</returns>
        public async Task<ShoppingCart> GetSingleShoppingCartByIdAsync(int id)
        {
            var shoppingCart = await _eCommerceUnitOfWork.ShoppingCartRepository.GetSingleAsync(a => a.Id == id);
            return shoppingCart;
        }

        /// <summary>
        /// Gets the shopping cart with products by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShoppingCart.</returns>
        public ShoppingCart GetShoppingCartWithProductsById(int id)
        {
            var shoppingCart = _eCommerceUnitOfWork.ShoppingCartRepository.GetSingle(a => a.Id == id, a => a.User, a => a.ShoppingCartProducts);
            return shoppingCart;
        }

        /// <summary>
        /// get shopping cart with products by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShoppingCart.</returns>
        public async Task<ShoppingCart> GetShoppingCartWithProductsByIdAsync(int id)
        {
            var shoppingCart = await _eCommerceUnitOfWork.ShoppingCartRepository.GetSingleAsync(a => a.Id == id, a => a.User, a => a.ShoppingCartProducts);
            return shoppingCart;
        }

        /// <summary>
        /// Gets the admin shopping cart by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShoppingCart.</returns>
        public ShoppingCart GetAdminShoppingCartById(int id)
        {
            var shoppingCart = _eCommerceUnitOfWork.ShoppingCartRepository.GetSingle(a => a.Id == id, a => a.User, a => a.ShoppingCartProducts, a => a.ShoppingCartProducts.Select(p => p.Product), a => a.BillingAddress, a => a.ShippingAddress, a => a.PaymentOption, a => a.ShippingOption, a => a.ShippingOption.ShippingCarrier, a => a.Currency, a => a.DiscountCoupon);
            if (shoppingCart != null)
                PullDiscountProductIds(shoppingCart.DiscountCoupon);
            return shoppingCart;
        }

        /// <summary>
        /// get admin shopping cart by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShoppingCart.</returns>
        public async Task<ShoppingCart> GetAdminShoppingCartByIdAsync(int id)
        {
            var shoppingCart = await _eCommerceUnitOfWork.ShoppingCartRepository.GetSingleAsync(a => a.Id == id, a => a.User, a => a.ShoppingCartProducts, a => a.ShoppingCartProducts.Select(p => p.Product), a => a.BillingAddress, a => a.ShippingAddress, a => a.PaymentOption, a => a.ShippingOption, a => a.ShippingOption.ShippingCarrier, a => a.Currency, a => a.DiscountCoupon);
            if (shoppingCart != null)
                PullDiscountProductIds(shoppingCart.DiscountCoupon);
            return shoppingCart;
        }

        /// <summary>
        /// Gets the shopping cart by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShoppingCart.</returns>
        public ShoppingCart GetShoppingCartById(int id)
        {
            var shoppingCart = _eCommerceUnitOfWork.ShoppingCartRepository.GetSingle(a => a.Id == id, a => a.User, a => a.ShoppingCartProducts, a => a.ShoppingCartProducts.Select(p => p.Product), a => a.ShoppingCartProducts.Select(p => p.Product.Supplier), a => a.ShoppingCartProducts.Select(p => p.Product.ProductSupplierData), a => a.BillingAddress, a => a.ShippingAddress, a => a.PaymentOption, a => a.ShippingOption, a => a.ShippingOption.ShippingCarrier, a => a.Currency, a => a.DiscountCoupon);
            if (shoppingCart != null)
                PullDiscountProductIds(shoppingCart.DiscountCoupon);
            return shoppingCart;
        }

        /// <summary>
        /// get shopping cart by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShoppingCart.</returns>
        public async Task<ShoppingCart> GetShoppingCartByIdAsync(int id)
        {
            var shoppingCart = await _eCommerceUnitOfWork.ShoppingCartRepository.GetSingleAsync(a => a.Id == id, a => a.User, a => a.ShoppingCartProducts, a => a.ShoppingCartProducts.Select(p => p.Product), a => a.BillingAddress, a => a.ShippingAddress, a => a.PaymentOption, a => a.ShippingOption, a => a.ShippingOption.ShippingCarrier, a => a.Currency, a => a.DiscountCoupon);
            if (shoppingCart != null)
                PullDiscountProductIds(shoppingCart.DiscountCoupon);
            return shoppingCart;
        }

        /// <summary>
        /// Gets the shopping carts older than.
        /// </summary>
        /// <param name="days">The days.</param>
        /// <returns>IList&lt;ShoppingCart&gt;.</returns>
        public IList<ShoppingCart> GetShoppingCartsOlderThan(int days)
        {
            var date = DateTime.Now.AddDays(days * -1);
            return _eCommerceUnitOfWork.ShoppingCartRepository.GetList(a => a.CreateDate <= date, null, a => a.ShoppingCartProducts);
        }

        /// <summary>
        /// get shopping carts older than as an asynchronous operation.
        /// </summary>
        /// <param name="days">The days.</param>
        /// <returns>IList&lt;ShoppingCart&gt;.</returns>
        public async Task<IList<ShoppingCart>> GetShoppingCartsOlderThanAsync(int days)
        {
            var date = DateTime.Now.AddDays(days * -1);
            return await _eCommerceUnitOfWork.ShoppingCartRepository.GetListAsync(a => a.CreateDate <= date, a => a.ShoppingCartProducts);
        }

        /// <summary>
        /// Gets the current shopping cart.
        /// </summary>
        /// <returns>ShoppingCart.</returns>
        /// <exception cref="BAP.Common.Exceptions.BAPUserException">Invalid user is in system</exception>
        public ShoppingCart GetCurrentShoppingCart()
        {
            var cookieName = ShoppingCartCookieName();
            var userId = _authContext.GetCurrentUserId();
            ShoppingCart result;
            // authenticated user
            if (!string.IsNullOrEmpty(userId))
            {
                var scPublic = GetShoppingCartFromCookie();
                var orgUserBl = (IOrganizationUserBL)this;
                var orgUser = orgUserBl.GetOrganizationUserByAspNetId(userId);
                if (orgUser == null)
                    throw new BAP.Common.Exceptions.BAPUserException("Invalid user is in system");

                result = _eCommerceUnitOfWork.ShoppingCartRepository.GetList(a => a.UserId == orgUser.Id, a => a.OrderByDescending(s => s.LastModifiedDate), a => a.User, a => a.ShoppingCartProducts, a => a.ShoppingCartProducts.Select(p => p.Product), a => a.ShoppingCartProducts.Select(p => p.Product.Supplier), a => a.BillingAddress, a => a.ShippingAddress, a => a.PaymentOption, a => a.ShippingOption, a => a.ShippingOption.ShippingCarrier, a => a.Currency, a => a.DiscountCoupon).Take(1).FirstOrDefault();
                if (result != null)
                    PullDiscountProductIds(result.DiscountCoupon);

                // if current authenticated user does not have shopping cart yet - use public or create new empty one
                if (result != null && scPublic?.ShoppingCartProducts != null && scPublic.ShoppingCartProducts.Count > 0)
                {
                    RemoveShoppingCart(result);
                    result = AssingCartToUser(scPublic, orgUser);
                }
                else if (result == null && scPublic?.ShoppingCartProducts != null && scPublic.ShoppingCartProducts.Count > 0)
                {
                    result = AssingCartToUser(scPublic, orgUser);
                }
                else if (scPublic != null && (scPublic.ShoppingCartProducts == null || scPublic.ShoppingCartProducts.Count == 0))
                {
                    RemoveShoppingCart(scPublic);
                }

                if (result == null)
                {
                    result = CreateEmptyCart(orgUser);
                }

                // Unset cookie
                _authContext.RemoveCookie(cookieName);
            }
            else // Public user
            {
                result = GetShoppingCartFromCookie() ?? CreateEmptyCart();

                // If no shopping cart found - create new empty one

                // Overwrite cookie with shopping cart id
                _authContext.SaveCookie(cookieName, result.Id.ToString());
            }

            return result;
        }

        /// <summary>
        /// get current shopping cart as an asynchronous operation.
        /// </summary>
        /// <returns>ShoppingCart.</returns>
        /// <exception cref="BAP.Common.Exceptions.BAPUserException">Invalid user is in system</exception>
        public async Task<ShoppingCart> GetCurrentShoppingCartAsync()
        {
            var cookieName = ShoppingCartCookieName();
            var userId = _authContext.GetCurrentUserId();
            ShoppingCart result;
            // authenticated user
            if (!string.IsNullOrEmpty(userId))
            {
                var scPublic = GetShoppingCartFromCookie();
                var orgUserBl = (IOrganizationUserBL)this;
                var orgUser = await orgUserBl.GetOrganizationUserByAspNetIdAsync(userId);
                if (orgUser == null)
                    throw new BAP.Common.Exceptions.BAPUserException("Invalid user is in system");

                result = (await _eCommerceUnitOfWork.ShoppingCartRepository.GetListAsync(a => a.UserId == orgUser.Id, a => a.OrderByDescending(s => s.LastModifiedDate), a => a.User, a => a.ShoppingCartProducts, a => a.ShoppingCartProducts.Select(p => p.Product), a => a.ShoppingCartProducts.Select(p => p.Product.Supplier), a => a.BillingAddress, a => a.ShippingAddress, a => a.PaymentOption, a => a.ShippingOption, a => a.ShippingOption.ShippingCarrier, a => a.Currency, a => a.DiscountCoupon)).Take(1).FirstOrDefault();
                if (result != null)
                    PullDiscountProductIds(result.DiscountCoupon);

                // if current authenticated user does not have shopping cart yet - use public or create new empty one
                if (result != null && scPublic?.ShoppingCartProducts != null && scPublic.ShoppingCartProducts.Count > 0)
                {
                    await RemoveShoppingCartAsync(result);
                    result = AssingCartToUser(scPublic, orgUser);
                }
                else if (result == null && scPublic?.ShoppingCartProducts != null && scPublic.ShoppingCartProducts.Count > 0)
                {
                    result = AssingCartToUser(scPublic, orgUser);
                }
                else if (scPublic != null && (scPublic.ShoppingCartProducts == null || scPublic.ShoppingCartProducts.Count == 0))
                {
                    await RemoveShoppingCartAsync(scPublic);
                }

                if (result == null)
                {
                    result = CreateEmptyCart(orgUser);
                }

                // Unset cookie
                _authContext.RemoveCookie(cookieName);
            }
            else // Public user
            {
                result = GetShoppingCartFromCookie() ?? CreateEmptyCart();

                // If no shopping cart found - create new empty one

                // Overwrite cookie with shopping cart id
                _authContext.SaveCookie(cookieName, result.Id.ToString());
            }

            return result;
        }

        /// <summary>
        /// Gets the shipping cost.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        /// <returns>System.Decimal.</returns>
        public decimal GetShippingCost(ShoppingCart shoppingCart)
        {
            decimal result = 0;            
            if (shoppingCart?.ShippingOption != null)
            {
                IShippingOptionBL sobl = (IShippingOptionBL)this;
                IShippingCarrierBL providerBl = this;
                
                var delivery = sobl.DeliveryFromSC(shoppingCart, shoppingCart.ShippingOption);
                result = providerBl.GetQuote(delivery);
            }

            return result;
        }

        /// <summary>
        /// get shipping cost as an asynchronous operation.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        /// <returns>System.Decimal.</returns>
        public async Task<decimal> GetShippingCostAsync(ShoppingCart shoppingCart)
        {
            decimal result = 0;
            if (shoppingCart?.ShippingOption != null)
            {
                IShippingOptionBL sobl = (IShippingOptionBL)this;
                IShippingCarrierBL providerBl = this;                

                var delivery = sobl.DeliveryFromSC(shoppingCart, shoppingCart.ShippingOption);
                result = providerBl.GetQuote(delivery);
            }

            return result;
        }

        /// <summary>
        /// Adds the shopping cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        public void AddShoppingCart(ShoppingCart cart)
        {
            // Making sure cart is calculated correctly
            cart = RecalculateCart(cart);

            // Save changes to DB
            _eCommerceUnitOfWork.ShoppingCartRepository.Add(cart);
            _eCommerceUnitOfWork.FixEntityStates();
#if DEBUG
            var result = _eCommerceUnitOfWork.GetEntityStates();
#endif

            _eCommerceUnitOfWork.Save();

            // Set state to unchanged
            cart.EntityState = BAPEntityState.Unchanged;
            if (cart.ShoppingCartProducts != null)
                cart.ShoppingCartProducts.ForEach(a => a.EntityState = BAPEntityState.Unchanged);
        }

        /// <summary>
        /// add shopping cart as an asynchronous operation.
        /// </summary>
        /// <param name="cart">The cart.</param>
        public async Task AddShoppingCartAsync(ShoppingCart cart)
        {
            // Making sure cart is calculated correctly
            cart = RecalculateCart(cart);

            // Save changes to DB
            _eCommerceUnitOfWork.ShoppingCartRepository.Add(cart);
            _eCommerceUnitOfWork.FixEntityStates();
#if DEBUG
            var result = _eCommerceUnitOfWork.GetEntityStates();
#endif

            await _eCommerceUnitOfWork.SaveAsync();

            // Set state to unchanged
            cart.EntityState = BAPEntityState.Unchanged;
            if (cart.ShoppingCartProducts != null)
                cart.ShoppingCartProducts.ForEach(a => a.EntityState = BAPEntityState.Unchanged);
        }

        /// <summary>
        /// Updates the shopping cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        public void UpdateShoppingCart(ShoppingCart cart)
        {
            // Making sure cart is calculated correctly
            cart = RecalculateCart(cart);

            // Process products
            if (cart.ShoppingCartProducts != null)
            {
                foreach (var product in cart.ShoppingCartProducts)
                {
                    if (product.EntityState == BAPEntityState.Unchanged)
                        continue;

                    if (product.Id == 0)
                    {
                        _eCommerceUnitOfWork.ShoppingCartProductRepository.Add(product);
                    }
                    else
                    {
                        if (product.EntityState == BAPEntityState.Modified)
                            _eCommerceUnitOfWork.ShoppingCartProductRepository.InitEntityData(product);
                    }
                }
            }
            // Save changes to DB
            _eCommerceUnitOfWork.ShoppingCartRepository.Update(cart);
            _eCommerceUnitOfWork.FixEntityStates();
#if DEBUG
            var result2 = _eCommerceUnitOfWork.GetEntityStates();
#endif
            _eCommerceUnitOfWork.Save();

            // Set state to unchanged
            cart.EntityState = BAPEntityState.Unchanged;
            if (cart.ShoppingCartProducts != null)
                cart.ShoppingCartProducts.ForEach(a => a.EntityState = BAPEntityState.Unchanged);
        }

        /// <summary>
        /// update shopping cart as an asynchronous operation.
        /// </summary>
        /// <param name="cart">The cart.</param>
        public async Task UpdateShoppingCartAsync(ShoppingCart cart)
        {
            // Making sure cart is calculated correctly
            cart = RecalculateCart(cart);

            // Process products
            if (cart.ShoppingCartProducts != null)
            {
                foreach (var product in cart.ShoppingCartProducts)
                {
                    if (product.EntityState == BAPEntityState.Unchanged)
                        continue;

                    if (product.Id == 0)
                    {
                        _eCommerceUnitOfWork.ShoppingCartProductRepository.Add(product);
                    }
                    else
                    {
                        if (product.EntityState == BAPEntityState.Modified)
                            _eCommerceUnitOfWork.ShoppingCartProductRepository.InitEntityData(product);
                    }
                }
            }
            // Save changes to DB
            _eCommerceUnitOfWork.ShoppingCartRepository.Update(cart);
            _eCommerceUnitOfWork.FixEntityStates();
#if DEBUG
            var result2 = _eCommerceUnitOfWork.GetEntityStates();
#endif
            await _eCommerceUnitOfWork.SaveAsync();

            // Set state to unchanged
            cart.EntityState = BAPEntityState.Unchanged;
            if (cart.ShoppingCartProducts != null)
                cart.ShoppingCartProducts.ForEach(a => a.EntityState = BAPEntityState.Unchanged);
        }

        /// <summary>
        /// Removes the shopping cart.
        /// </summary>
        /// <param name="shoppingCarts">The shopping carts.</param>
        public void RemoveShoppingCart(params ShoppingCart[] shoppingCarts)
        {
            if (shoppingCarts == null || !shoppingCarts.Any())
                return;

            foreach (var cart in shoppingCarts)
            {
                cart.EntityState = BAPEntityState.Deleted;
                if (cart.ShoppingCartProducts != null)
                {
                    foreach (var product in cart.ShoppingCartProducts)
                    {
                        product.EntityState = BAPEntityState.Deleted;
                    }
                    _eCommerceUnitOfWork.ShoppingCartProductRepository.Remove(cart.ShoppingCartProducts.ToArray());
                }
            }
            _eCommerceUnitOfWork.ShoppingCartRepository.Remove(shoppingCarts);
            _eCommerceUnitOfWork.FixEntityStates();
#if DEBUG
            var result = _eCommerceUnitOfWork.GetEntityStates();
#endif
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// remove shopping cart as an asynchronous operation.
        /// </summary>
        /// <param name="shoppingCarts">The shopping carts.</param>
        public async Task RemoveShoppingCartAsync(params ShoppingCart[] shoppingCarts)
        {
            if (shoppingCarts == null || !shoppingCarts.Any())
                return;

            foreach (var cart in shoppingCarts)
            {
                cart.EntityState = BAPEntityState.Deleted;
                if (cart.ShoppingCartProducts != null)
                {
                    foreach (var product in cart.ShoppingCartProducts)
                    {
                        product.EntityState = BAPEntityState.Deleted;
                    }
                    _eCommerceUnitOfWork.ShoppingCartProductRepository.Remove(cart.ShoppingCartProducts.ToArray());
                }

                if(cart.BillingAddress != null)
                {
                    cart.BillingAddress.EntityState = BAPEntityState.Deleted;
                    _eCommerceUnitOfWork.AddressRepository.Remove(cart.BillingAddress);
                }

                if(cart.ShippingAddress != null && cart.BillingAddressId != cart.ShippingAddressId)
                {
                    cart.ShippingAddress.EntityState = BAPEntityState.Deleted;
                    _eCommerceUnitOfWork.AddressRepository.Remove(cart.ShippingAddress);
                }
            }
            _eCommerceUnitOfWork.ShoppingCartRepository.Remove(shoppingCarts);
            _eCommerceUnitOfWork.FixEntityStates();
#if DEBUG
            var result = _eCommerceUnitOfWork.GetEntityStates();
#endif
            await _eCommerceUnitOfWork.SaveAsync();
        }
        
        /// <summary>
        /// Adds the product to shopping cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="product">The product.</param>
        /// <param name="count">The count.</param>
        public void AddProductToShoppingCart(ShoppingCart cart, Product product, int count)
        {
            if (PrepareProductForTheShoppingCart(cart, product, count))                
                UpdateShoppingCart(cart);
        }

        /// <summary>
        /// add product to shopping cart as an asynchronous operation.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="product">The product.</param>
        /// <param name="count">The count.</param>
        public async Task AddProductToShoppingCartAsync(ShoppingCart cart, Product product, int count)
        {
            if (PrepareProductForTheShoppingCart(cart, product, count))
                await UpdateShoppingCartAsync(cart);
        }

        private bool PrepareProductForTheShoppingCart(ShoppingCart cart, Product product, int count)
        {
            if (cart == null || product == null || count < 1)
                return false;

            if (cart.ShoppingCartProducts != null && cart.ShoppingCartProducts.Any(a => a.ProductId == product.Id))
            {
                var cartProduct = cart.ShoppingCartProducts.SingleOrDefault(a => a.ProductId == product.Id);
                if (cartProduct != null)
                {
                    cartProduct.Count += count;
                    cartProduct.Subtotal = cartProduct.Count * product.SalesPrice;

                    cartProduct.EntityState = BAPEntityState.Modified;
                }
            }
            else
            {
                if (cart.ShoppingCartProducts == null)
                    cart.ShoppingCartProducts = new List<ShoppingCartProduct>();

                var cartProduct = new ShoppingCartProduct
                {
                    ShoppingCart = cart,
                    ShoppingCartId = cart.Id,
                    ProductId = product.Id,
                    Count = count,
                    Price = product.SalesPrice,
                    Subtotal = count * product.SalesPrice,
                    EntityState = BAPEntityState.Added
                };
                cart.ShoppingCartProducts.Add(cartProduct);
            }

            return true;
        }


        /// <summary>
        /// Removes the product from shopping cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="product">The product.</param>
        public void RemoveProductFromShoppingCart(ShoppingCart cart, ShoppingCartProduct product)
        {
            if (cart.ShoppingCartProducts != null && cart.ShoppingCartProducts.Any(a => a.Id == product.Id))
            {
                var productBl = (IShoppingCartProductBL)this;
                product.EntityState = BAPEntityState.Deleted;
                productBl.RemoveShoppingCartProduct(product);
                UpdateShoppingCart(cart);
            }
        }

        /// <summary>
        /// remove product from shopping cart as an asynchronous operation.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="product">The product.</param>
        public async Task RemoveProductFromShoppingCartAsync(ShoppingCart cart, ShoppingCartProduct product)
        {
            if (cart.ShoppingCartProducts != null && cart.ShoppingCartProducts.Any(a => a.Id == product.Id))
            {
                var productBl = (IShoppingCartProductBL)this;
                product.EntityState = BAPEntityState.Deleted;
                await productBl.RemoveShoppingCartProductAsync(product);
                await UpdateShoppingCartAsync(cart);
            }
        }

        /// <summary>
        /// Updates the product count.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="shoppingCartProductId">The shopping cart product identifier.</param>
        /// <param name="count">The count.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool UpdateProductCount(ShoppingCart cart, int shoppingCartProductId, int count)
        {
            bool result = false;
            if (cart?.ShoppingCartProducts == null || cart.ShoppingCartProducts.Count == 0)
                return false;

            var product = cart.ShoppingCartProducts.SingleOrDefault(a => a.Id == shoppingCartProductId);
            if (product != null && product.Count != count)
            {
                product.Count = count;
                product.EntityState = BAPEntityState.Modified;
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Adds the product option.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="product">The product.</param>
        /// <param name="option">The option.</param>
        /// <param name="optionValue">The option value.</param>
        public void AddProductOption(ShoppingCart cart, Product product, ProductOptionItem option, string optionValue)
        {
            if (cart == null || product == null || option == null || cart.ShoppingCartProducts.All(a => a.ProductId != product.Id))
                return;

            var productToUpdate = cart.ShoppingCartProducts.SingleOrDefault(a => a.ProductId == product.Id);
            if (productToUpdate != null)
            {
                if (!productToUpdate.OptionsData.IsNullOrEmpty())
                    productToUpdate.OptionsData += ", ";
                productToUpdate.OptionsData += option.Name;
                if (!optionValue.IsNullOrEmpty())
                    productToUpdate.OptionsData += " : " + optionValue;
                if (option.PriceAdded > 0)
                {
                    productToUpdate.OptionsData += " (+" + cart.Currency.Symbol + option.PriceAdded + ")";
                }

                productToUpdate.OptionsAddedPrice += option.PriceAdded;
                productToUpdate.EntityState = BAPEntityState.Modified;

                UpdateShoppingCart(cart);
            }
        }

        /// <summary>
        /// add product option as an asynchronous operation.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="product">The product.</param>
        /// <param name="option">The option.</param>
        /// <param name="optionValue">The option value.</param>
        public async Task AddProductOptionAsync(ShoppingCart cart, Product product, ProductOptionItem option, string optionValue)
        {
            if (cart == null || product == null || option == null || cart.ShoppingCartProducts.All(a => a.ProductId != product.Id))
                return;

            var productToUpdate = cart.ShoppingCartProducts.SingleOrDefault(a => a.ProductId == product.Id);
            if (productToUpdate != null)
            {
                if (!productToUpdate.OptionsData.IsNullOrEmpty())
                    productToUpdate.OptionsData += ", ";
                productToUpdate.OptionsData += option.Name;
                if (!optionValue.IsNullOrEmpty())
                    productToUpdate.OptionsData += " : " + optionValue;
                if (option.PriceAdded > 0)
                {
                    productToUpdate.OptionsData += " (+" + cart.Currency.Symbol + option.PriceAdded + ")";
                }

                productToUpdate.OptionsAddedPrice += option.PriceAdded;
                productToUpdate.EntityState = BAPEntityState.Modified;

                await UpdateShoppingCartAsync(cart);
            }
        }

        /// <summary>
        /// Applies the discount coupon.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="couponCode">The coupon code.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ApplyDiscountCoupon(ShoppingCart cart, string couponCode)
        {
            if (cart == null)
                return false;

            var result = false;
            if (cart.DiscountCoupon != null && couponCode.IsNullOrEmpty())
            {
                cart.DiscountCoupon = null;
                cart.DiscountCouponId = null;
                result = true;
                RecalculateCart(cart);
            }
            else if (cart.DiscountCoupon == null || cart.DiscountCoupon.Code != couponCode)
            {
                var discount = ((IDiscountCouponBL)this).GetDiscountCouponByCode(couponCode);
                var today = DateTime.Now;
                if (discount != null && discount.Enabled && discount.ValidFrom < today && discount.ValidTo > today)
                {
                    PullDiscountProductIds(discount);
                    // check if any product suitable
                    if (discount.DiscountType == DiscountType.ProductCoupon)
                    {
                        if (discount.ProductAppliedIds != null && cart.ShoppingCartProducts != null && cart.ShoppingCartProducts.Count > 0)
                        {
                            foreach (var id in discount.ProductAppliedIds)
                            {
                                if (cart.ShoppingCartProducts.Any(a => a.ProductId == id))
                                {
                                    cart.DiscountCoupon = discount;
                                    cart.DiscountCouponId = discount.Id;
                                    result = true;
                                    break;
                                }
                            }
                        }
                    }
                    else if (discount.DiscountType == DiscountType.FreeShipping || discount.DiscountType == DiscountType.VolumeDiscount)
                    {
                        if (discount.ApplyCriteria != null && MeetCriteria(cart, discount.ApplyCriteria))
                        {
                            cart.DiscountCoupon = discount;
                            cart.DiscountCouponId = discount.Id;
                            result = true;
                        }
                    }
                    else if (discount.DiscountType != DiscountType.None)//other types of discounts are applied as is
                    {
                        cart.DiscountCoupon = discount;
                        cart.DiscountCouponId = discount.Id;
                        result = true;
                    }
                    // discount changed - need to recalculate cart
                    //if (result)
                    //    RecalculateCart(cart);
                }
            }

            return result;
        }

        /// <summary>
        /// apply discount coupon as an asynchronous operation.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="couponCode">The coupon code.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public async Task<bool> ApplyDiscountCouponAsync(ShoppingCart cart, string couponCode)
        {
            if (cart == null)
                return false;

            var result = false;
            if (cart.DiscountCoupon != null && couponCode.IsNullOrEmpty())
            {
                cart.DiscountCoupon = null;
                cart.DiscountCouponId = null;
                result = true;
                RecalculateCart(cart);
            }
            else if (cart.DiscountCoupon == null || cart.DiscountCoupon.Code != couponCode)
            {
                var discount = await ((IDiscountCouponBL)this).GetDiscountCouponByCodeAsync(couponCode);
                var today = DateTime.Now;
                if (discount != null && discount.Enabled && discount.ValidFrom < today && discount.ValidTo > today)
                {
                    PullDiscountProductIds(discount);
                    // check if any product suitable
                    if (discount.DiscountType == DiscountType.ProductCoupon)
                    {
                        if (discount.ProductAppliedIds != null && cart.ShoppingCartProducts != null && cart.ShoppingCartProducts.Count > 0)
                        {
                            foreach (var id in discount.ProductAppliedIds)
                            {
                                if (cart.ShoppingCartProducts.Any(a => a.ProductId == id))
                                {
                                    cart.DiscountCoupon = discount;
                                    cart.DiscountCouponId = discount.Id;
                                    result = true;
                                    break;
                                }
                            }
                        }
                    }
                    else if (discount.DiscountType == DiscountType.FreeShipping || discount.DiscountType == DiscountType.VolumeDiscount)
                    {
                        if (discount.ApplyCriteria != null && MeetCriteria(cart, discount.ApplyCriteria))
                        {
                            cart.DiscountCoupon = discount;
                            cart.DiscountCouponId = discount.Id;
                            result = true;
                        }
                    }
                    else if (discount.DiscountType != DiscountType.None)//other types of discounts are applied as is
                    {
                        cart.DiscountCoupon = discount;
                        cart.DiscountCouponId = discount.Id;
                        result = true;
                    }
                    // discount changed - need to recalculate cart
                    //if (result)
                    //    RecalculateCart(cart);
                }
            }

            return result;
        }

        /// <summary>
        /// Saves the addresses.
        /// </summary>
        /// <param name="cart">The cart.</param>
        public void SaveAddresses(ShoppingCart cart)
        {
            if (cart.BillingAddress == null)
            {
                cart.BillingAddress = new Address
                {
                    EntityState = BAPEntityState.Added
                };
            }
            else
            {
                cart.BillingAddress.EntityState = cart.BillingAddress.Id > 0 ? BAPEntityState.Modified : BAPEntityState.Added;
            }

            if (cart.ShippingAddress == null)
            {
                cart.ShippingAddress = new Address
                {
                    EntityState = BAPEntityState.Added
                };
            }
            else
            {
                cart.ShippingAddress.EntityState = cart.ShippingAddress.Id > 0 ? BAPEntityState.Modified : BAPEntityState.Added;
            }

            if (cart.ShippingAsBilling)
            {
                var uniqueSuffix = Guid.NewGuid().ToString();
                var copy = cart.BillingAddress;
                cart.ShippingAddress.Name = copy.FirstName + " " + copy.MiddleName + " " + copy.LastName + " " + copy.Zip + " " + uniqueSuffix;
                cart.ShippingAddress.AddressLine1 = copy.AddressLine1;
                cart.ShippingAddress.AddressLine2 = copy.AddressLine2;
                cart.ShippingAddress.CellNumber = copy.CellNumber;
                cart.ShippingAddress.City = copy.City;
                cart.ShippingAddress.ContactEmail = copy.ContactEmail;
                cart.ShippingAddress.Country = copy.Country;
                cart.ShippingAddress.County = copy.County;
                cart.ShippingAddress.Description = copy.Description;
                cart.ShippingAddress.FaxNumber = copy.FaxNumber;
                cart.ShippingAddress.FirstName = copy.FirstName;
                cart.ShippingAddress.LastName = copy.LastName;
                cart.ShippingAddress.MiddleName = copy.MiddleName;
                cart.ShippingAddress.PhoneExtension = copy.PhoneExtension;
                cart.ShippingAddress.PhoneNumber = copy.PhoneNumber;
                cart.ShippingAddress.State = copy.State;
                cart.ShippingAddress.Zip = copy.Zip;
            }

            bool isAnyAddressAdded = false;
            if (cart.BillingAddress.EntityState == BAPEntityState.Added)
            {
                _eCommerceUnitOfWork.AddressRepository.Add(cart.BillingAddress);
                isAnyAddressAdded = true;
            }
            if (cart.ShippingAddress.EntityState == BAPEntityState.Added)
            {
                _eCommerceUnitOfWork.AddressRepository.Add(cart.ShippingAddress);
                isAnyAddressAdded = true;
            }
            if (isAnyAddressAdded)
            {
                _eCommerceUnitOfWork.Save();
                if (cart.BillingAddress.EntityState == BAPEntityState.Added)
                    cart.BillingAddress.EntityState = BAPEntityState.Unchanged;
                if (cart.ShippingAddress.EntityState == BAPEntityState.Added)
                    cart.ShippingAddress.EntityState = BAPEntityState.Unchanged;
                cart.BillingAddressId = cart.BillingAddress.Id;
                cart.ShippingAddressId = cart.ShippingAddress.Id;
            }

            cart.EntityState = BAPEntityState.Modified;
            UpdateShoppingCart(cart);
        }

        /// <summary>
        /// save addresses as an asynchronous operation.
        /// </summary>
        /// <param name="cart">The cart.</param>
        public async Task SaveAddressesAsync(ShoppingCart cart)
        {
            if (cart.BillingAddress == null)
            {
                cart.BillingAddress = new Address
                {
                    EntityState = BAPEntityState.Added
                };
            }
            else
            {
                cart.BillingAddress.EntityState = cart.BillingAddress.Id > 0 ? BAPEntityState.Modified : BAPEntityState.Added;
            }

            if (cart.ShippingAddress == null)
            {
                cart.ShippingAddress = new Address
                {
                    EntityState = BAPEntityState.Added
                };
            }
            else
            {
                cart.ShippingAddress.EntityState = cart.ShippingAddress.Id > 0 ? BAPEntityState.Modified : BAPEntityState.Added;
            }

            if (cart.ShippingAsBilling)
            {
                var uniqueSuffix = Guid.NewGuid().ToString();
                var copy = cart.BillingAddress;
                cart.ShippingAddress.Name = copy.FirstName + " " + copy.MiddleName + " " + copy.LastName + " " + copy.Zip + " " + uniqueSuffix;
                cart.ShippingAddress.AddressLine1 = copy.AddressLine1;
                cart.ShippingAddress.AddressLine2 = copy.AddressLine2;
                cart.ShippingAddress.CellNumber = copy.CellNumber;
                cart.ShippingAddress.City = copy.City;
                cart.ShippingAddress.ContactEmail = copy.ContactEmail;
                cart.ShippingAddress.Country = copy.Country;
                cart.ShippingAddress.County = copy.County;
                cart.ShippingAddress.Description = copy.Description;
                cart.ShippingAddress.FaxNumber = copy.FaxNumber;
                cart.ShippingAddress.FirstName = copy.FirstName;
                cart.ShippingAddress.LastName = copy.LastName;
                cart.ShippingAddress.MiddleName = copy.MiddleName;
                cart.ShippingAddress.PhoneExtension = copy.PhoneExtension;
                cart.ShippingAddress.PhoneNumber = copy.PhoneNumber;
                cart.ShippingAddress.State = copy.State;
                cart.ShippingAddress.Zip = copy.Zip;
            }

            bool isAnyAddressAdded = false;
            if (cart.BillingAddress.EntityState == BAPEntityState.Added)
            {
                _eCommerceUnitOfWork.AddressRepository.Add(cart.BillingAddress);
                isAnyAddressAdded = true;
            }
            if (cart.ShippingAddress.EntityState == BAPEntityState.Added)
            {
                _eCommerceUnitOfWork.AddressRepository.Add(cart.ShippingAddress);
                isAnyAddressAdded = true;
            }
            if (isAnyAddressAdded)
            {
                await _eCommerceUnitOfWork.SaveAsync();
                if (cart.BillingAddress.EntityState == BAPEntityState.Added)
                    cart.BillingAddress.EntityState = BAPEntityState.Unchanged;
                if (cart.ShippingAddress.EntityState == BAPEntityState.Added)
                    cart.ShippingAddress.EntityState = BAPEntityState.Unchanged;
                cart.BillingAddressId = cart.BillingAddress.Id;
                cart.ShippingAddressId = cart.ShippingAddress.Id;
            }

            cart.EntityState = BAPEntityState.Modified;
            await UpdateShoppingCartAsync(cart);
        }

        /// <summary>
        /// Sets the shipping option.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="shippingOptionId">The shipping option identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SetShippingOption(ShoppingCart cart, int shippingOptionId)
        {
            bool result = false;
            var shippingOptionBl = (IShippingOptionBL)this;
            var shippingOption = shippingOptionBl.GetShippingOptionById(shippingOptionId);
            if (shippingOption != null)
            {
                cart.ShippingOption = null;
                cart.ShippingOptionId = shippingOptionId;
                cart.EntityState = BAPEntityState.Modified;
                UpdateShoppingCart(cart);
                cart.ShippingOption = shippingOption;
                result = true;
            }

            return result;
        }

        /// <summary>
        /// set shipping option as an asynchronous operation.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="shippingOptionId">The shipping option identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public async Task<bool> SetShippingOptionAsync(ShoppingCart cart, int shippingOptionId)
        {
            bool result = false;
            var shippingOptionBl = (IShippingOptionBL)this;
            var shippingOption = await shippingOptionBl.GetShippingOptionByIdAsync(shippingOptionId);
            if (shippingOption != null)
            {
                cart.ShippingOption = null;
                cart.ShippingOptionId = shippingOptionId;
                cart.EntityState = BAPEntityState.Modified;
                await UpdateShoppingCartAsync(cart);
                cart.ShippingOption = shippingOption;
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Sets the payment option.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="paymentOptionId">The payment option identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SetPaymentOption(ShoppingCart cart, int paymentOptionId)
        {
            bool result = false;
            var paymentOptionBl = (IPaymentOptionBL)this;
            var paymentOption = paymentOptionBl.GetPaymentOptionById(paymentOptionId);

            if (paymentOption != null)
            {
                cart.PaymentOption = null;
                cart.PaymentOptionId = paymentOptionId;
                cart.EntityState = BAPEntityState.Modified;
                UpdateShoppingCart(cart);
                cart.PaymentOption = paymentOption;
                result = true;
            }

            return result;
        }

        /// <summary>
        /// set payment option as an asynchronous operation.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="paymentOptionId">The payment option identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public async Task<bool> SetPaymentOptionAsync(ShoppingCart cart, int paymentOptionId)
        {
            bool result = false;
            var paymentOptionBl = (IPaymentOptionBL)this;
            var paymentOption = await paymentOptionBl.GetPaymentOptionByIdAsync(paymentOptionId);

            if (paymentOption != null)
            {
                cart.PaymentOption = null;
                cart.PaymentOptionId = paymentOptionId;
                cart.EntityState = BAPEntityState.Modified;
                await UpdateShoppingCartAsync(cart);
                cart.PaymentOption = paymentOption;
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Converts to order.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>CustomerOrder.</returns>
        public CustomerOrder ConvertToOrder(ShoppingCart cart)
        {
            if (cart == null)
                return null;

            UpdateUserFromShoppingCart(cart);
            return ((ICustomerOrderBL)this).CreateOrderFromShoppingCart(cart);
        }

        /// <summary>
        /// convert to order as an asynchronous operation.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>CustomerOrder.</returns>
        public async Task<CustomerOrder> ConvertToOrderAsync(ShoppingCart cart)
        {
            if (cart == null)
                return null;

            UpdateUserFromShoppingCart(cart);
            return await ((ICustomerOrderBL)this).CreateOrderFromShoppingCartAsync(cart);
        }

        /// <summary>
        /// Searches the by criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IList<ShoppingCart> SearchByCriteria(ICriteria<ShoppingCart> criteria)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Meets the criteria.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="criteria">The criteria.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool MeetCriteria(ShoppingCart entity, ICriteria<ShoppingCart> criteria)
        {
            if (entity == null || criteria == null)
                return false;

            return MeetCriteriaIterator(entity, criteria.Fields, criteria);
        }

        /// <summary>
        /// Sets the shopping cart custom data.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="data">The data.</param>
        public void SetShoppingCartCustomData(ShoppingCart cart, ShoppingCartCustomData data)
        {
            if (cart == null || data == null)
                return;
            cart.CustomData = JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// Gets the shopping cart custom data.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns></returns>
        public ShoppingCartCustomData GetShoppingCartCustomData(ShoppingCart cart)
        {
            if (cart == null || string.IsNullOrEmpty(cart.CustomData))
                return null;

            return JsonConvert.DeserializeObject<ShoppingCartCustomData>(cart.CustomData);
        }

        public List<SupplierProductsPairDC> MergeSuppliers(ShoppingCart cart)
        {

            var supplierProducts = new Dictionary<int, SupplierProductsPairDC>();

            var shoppingCartProducts = cart.ShoppingCartProducts?.Where(x => x.Product.SupplierId != null) 
                                       ?? new List<ShoppingCartProduct>();
            
            // Merge all suppliers and related to them all products from shopping cart
            foreach (var shoppingCartProduct in shoppingCartProducts)
            {
                var supplierId = shoppingCartProduct.Product.SupplierId.Value;
                
                if (supplierProducts.ContainsKey(supplierId))
                {
                    supplierProducts[supplierId].ShoppingCartProducts.Add(shoppingCartProduct);
                }
                else
                {
                    supplierProducts.Add(supplierId, new SupplierProductsPairDC
                    {
                        Supplier = shoppingCartProduct.Product.Supplier,
                        ShoppingCartProducts = new List<ShoppingCartProduct> {shoppingCartProduct}
                    });
                }
            }

            return supplierProducts.Values.ToList();
        }


        #region private methods   

        /// <summary>
        /// Meets the criteria iterator.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="fields">The fields.</param>
        /// <param name="criteria">The criteria.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool MeetCriteriaIterator(IBapEntity entity, List<CriteriaField> fields, ICriteria<ShoppingCart> criteria)
        {
            if (entity == null || fields == null)
                return false;

            bool result = true;
            foreach (var field in fields)
            {
                if (field.FieldType == CriteriaFieldType.Array && field.ChildFields != null && field.ChildFields.Count > 0)
                {
                    if (field.EntityField.GetValue(entity) is IEnumerable list)
                    {
                        var countCriteria = field.ChildFields.FirstOrDefault(f => f.Name.ToLowerInvariant() == "count");
                        if (countCriteria != null && !criteria.Compare(field, list))
                        {
                            result = false;
                            break;
                        }

                        //Assuming array objects do not meet criteria, but if at least one meets criteria - overall result is true
                        result = false;
                        foreach (var obj in list)
                        {
                            var tmpResult = MeetCriteriaIterator((IBapEntity)obj, field.ChildFields.Where(f => f.Name.ToLowerInvariant() != "count").ToList(), criteria);
                            if (tmpResult)
                            {
                                result = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    var entityVal = field.EntityField.GetValue(entity);

                    if (!criteria.Compare(field, entityVal))
                    {
                        result = false;
                        break;
                    }
                    if (field.ChildFields != null && field.ChildFields.Count > 0)
                    {
                        result = MeetCriteriaIterator((IBapEntity)entityVal, field.ChildFields, criteria);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Updates the user from shopping cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <exception cref="BAP.Common.Exceptions.BAPUserException">Invalid user is in system</exception>
        private void UpdateUserFromShoppingCart(ShoppingCart cart)
        {
            // No cart or/and billing address - nothing to do
            if (cart?.BillingAddress == null || cart.User == null)
                return;

            bool isAnyUpdate = false;
            var orgUser = cart.User;
            if (orgUser == null)
                throw new BAP.Common.Exceptions.BAPUserException("Invalid user is in system");

            // update name if no any
            if ((orgUser.FirstName.IsNullOrEmpty() || orgUser.LastName.IsNullOrEmpty())
                && !cart.BillingAddress.FirstName.IsNullOrEmpty() && !cart.BillingAddress.LastName.IsNullOrEmpty())
            {
                orgUser.FirstName = cart.BillingAddress.FirstName;
                orgUser.LastName = cart.BillingAddress.LastName;
                orgUser.MiddleName = cart.BillingAddress.MiddleName;
                isAnyUpdate = true;
            }


            // update address if no any
            if ((orgUser.AddressLine1.IsNullOrEmpty() || orgUser.City.IsNullOrEmpty() || orgUser.State.IsNullOrEmpty() || orgUser.Country.IsNullOrEmpty() || orgUser.Zip.IsNullOrEmpty())
                && !cart.BillingAddress.AddressLine1.IsNullOrEmpty() && !cart.BillingAddress.City.IsNullOrEmpty() && !cart.BillingAddress.State.IsNullOrEmpty() && !cart.BillingAddress.Country.IsNullOrEmpty() && !cart.BillingAddress.Zip.IsNullOrEmpty())
            {
                orgUser.AddressLine1 = cart.BillingAddress.AddressLine1;
                orgUser.AddressLine2 = cart.BillingAddress.AddressLine2;
                orgUser.City = cart.BillingAddress.City;
                orgUser.County = cart.BillingAddress.County;
                orgUser.State = cart.BillingAddress.State;
                orgUser.Country = cart.BillingAddress.Country;
                orgUser.Zip = cart.BillingAddress.Zip;
                isAnyUpdate = true;
            }

            if (orgUser.PhoneNumber.IsNullOrEmpty() && !cart.BillingAddress.PhoneNumber.IsNullOrEmpty())
            {
                orgUser.PhoneNumber = cart.BillingAddress.PhoneNumber;
                isAnyUpdate = true;
            }

            if (orgUser.CellNumber.IsNullOrEmpty() && !cart.BillingAddress.CellNumber.IsNullOrEmpty())
            {
                orgUser.CellNumber = cart.BillingAddress.CellNumber;
                isAnyUpdate = true;
            }

            if (orgUser.Email.IsNullOrEmpty() && !cart.BillingAddress.ContactEmail.IsNullOrEmpty())
            {
                orgUser.Email = cart.BillingAddress.ContactEmail;
                isAnyUpdate = true;
            }

            //telling repository to persist changes to DB
            if (isAnyUpdate)
                orgUser.EntityState = BAPEntityState.Modified;
        }

        /// <summary>
        /// Gets the shopping cart from cookie.
        /// </summary>
        /// <returns>ShoppingCart.</returns>
        private ShoppingCart GetShoppingCartFromCookie()
        {
            var cookieName = ShoppingCartCookieName();
            var cookieValue = _authContext.ReadCookie(cookieName);
            ShoppingCart sc = null;
            if (!string.IsNullOrEmpty(cookieValue))
            {
                if (int.TryParse(cookieValue, out var scId))
                {
                    sc = GetShoppingCartById(scId);
                    // Making sure shopping cart belonged to the user is not returned to the public
                    if (sc?.User != null)
                    {
                        sc = null;
                        _authContext.SaveCookie(cookieName, string.Empty);
                    }
                }
            }

            return sc;
        }

        /// <summary>
        /// Shoppings the name of the cart cookie.
        /// </summary>
        /// <returns>System.String.</returns>
        private string ShoppingCartCookieName()
        {
            return _authContext.GetCurrentOrganization(_configHelper).Name.Replace(" ", "_").ToLower() + "_shopping_cart_id";
        }

        /// <summary>
        /// Recalculates the cart.
        /// </summary>
        /// <param name="newCart">The new cart.</param>
        /// <returns>ShoppingCart.</returns>
        private ShoppingCart RecalculateCart(ShoppingCart newCart)
        {
            // No cart - go out
            if (newCart == null)
                return null;

            // Recalculate totals
            if (newCart.ShoppingCartProducts != null)
            {
                DiscountCoupon discount = null;
                if (newCart.DiscountCouponId.HasValue)
                    discount = GetDiscountCouponById(newCart.DiscountCouponId.Value);

                // calculate products
                foreach (var product in newCart.ShoppingCartProducts)
                {
                    if (product.Product != null)
                        product.Price = product.Product.SalesPrice;

                    if (product.OptionsAddedPrice > 0)
                        product.Price += product.OptionsAddedPrice;

                    if (discount != null && discount.DiscountType == DiscountType.ProductCoupon
                        && discount.ProductAppliedIds != null && discount.ProductAppliedIds.Any(a => a == product.ProductId))
                    {
                        if (discount.IsPercent)
                        {
                            product.TotalDiscount = product.Price * product.Count * discount.Amount / 100;
                        }
                        else
                        {
                            product.TotalDiscount = product.Count * discount.Amount;
                        }
                        product.DiscountCouponId = discount.Id;
                    }
                    else
                    {
                        product.TotalDiscount = 0;
                    }
                    product.Subtotal = product.Price * product.Count - product.TotalDiscount;

                    if (product.EntityState == BAPEntityState.Unchanged)
                        product.EntityState = BAPEntityState.Modified;
                }
                newCart.Subtotal = newCart.ShoppingCartProducts.Sum(a => a.Subtotal);

                // process discounts
                newCart.TotalDiscounts = 0;
                newCart.Total = newCart.Subtotal;
                if (discount != null && discount.DiscountType == DiscountType.ProductCoupon)
                {
                    newCart.TotalDiscounts = newCart.ShoppingCartProducts.Sum(a => a.TotalDiscount);
                }
                else if (discount != null && discount.DiscountType == DiscountType.FreeShipping)
                {
                    newCart.TotalDiscounts = newCart.ShippingCost;
                }
                else if (discount != null)
                {
                    // check if discount is still valid
                    if (discount.ApplyCriteria != null)
                    {
                        if (!MeetCriteria(newCart, discount.ApplyCriteria))
                        {
                            discount = null;
                            newCart.DiscountCoupon = null;
                            newCart.DiscountCouponId = null;
                            newCart.AddMessage(Resources.ResObject.UIText_CouponRemoved);
                        }
                    }

                    if (discount != null && discount.DiscountType != DiscountType.FreeShipping)
                    {
                        if (discount.IsPercent)
                        {
                            newCart.TotalDiscounts = newCart.ShoppingCartProducts.Sum(a => a.Price * a.Count) * discount.Amount / 100;
                        }
                        else
                        {
                            if (discount.Amount <= newCart.Subtotal)
                                newCart.TotalDiscounts = discount.Amount;
                        }
                        if (discount.DiscountType == DiscountType.BuyXGetY)
                        {
                            var product = newCart.ShoppingCartProducts.OrderByDescending(p => p.Count).FirstOrDefault();
                            if (product != null)
                            {
                                if (product.Count >= discount.BuyXAmount)
                                {
                                    var newAmount = product.Count + product.Count / discount.BuyXAmount * (discount.GetYAmount - discount.BuyXAmount);
                                    newCart.TotalDiscounts = product.Subtotal - product.Subtotal / newAmount * product.Count;
                                }
                            }
                        }
                    }
                }

                // calculate shipping cost, taking discount into account
                newCart.ShippingCost = 0;
                if (newCart.ShippingOptionId > 0)
                {
                    var cost = GetShippingCost(newCart);
                    if (cost > 0)
                    {
                        newCart.ShippingCost = cost;
                        if (discount != null && discount.Amount > 0)
                        {
                            if (discount.DiscountType == DiscountType.FreeShipping)
                            {
                                newCart.TotalDiscounts = newCart.ShippingCost;
                            }
                            else
                            {
                                decimal discountValue = cost;
                                if (discountValue > 0)
                                {
                                    newCart.ShippingCost -= discountValue;
                                    newCart.TotalDiscounts += discountValue;
                                }
                            }
                        }
                    }
                }

                // calculate total
                newCart.Total = 0;
                if (newCart.Subtotal.HasValue && newCart.Subtotal.Value > 0)
                    newCart.Total += newCart.Subtotal.Value;
                if (newCart.TaxTotal.HasValue && newCart.TaxTotal.Value > 0)
                    newCart.Total += newCart.TaxTotal.Value;
                if (newCart.ShippingCost.Value > 0)
                    newCart.Total += newCart.ShippingCost.Value;
                if (newCart.TotalDiscounts.HasValue && newCart.TotalDiscounts.Value > 0 && newCart.Total >= newCart.TotalDiscounts.Value)
                    newCart.Total -= newCart.TotalDiscounts.Value;

                // set entity state to changed
                if (newCart.EntityState == BAPEntityState.Unchanged)
                    newCart.EntityState = BAPEntityState.Modified;
            }
            return newCart;
        }

        /// <summary>
        /// Creates the empty cart.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>ShoppingCart.</returns>
        /// <exception cref="CurrencyException">Main currency is not configured in the system</exception>
        private ShoppingCart CreateEmptyCart(OrganizationUser user = null)
        {
            var currency = ((ICurrencyBL)this).GetMainCurrency();
            if (currency == null)
                throw new CurrencyException("Main currency is not configured in the system");

            var sc = new ShoppingCart
            {
                Total = 0,
                Subtotal = 0,
                TaxTotal = 0,
                TotalDiscounts = 0,
                CurrencyId = currency.Id,
                ShippingAsBilling = true,
                EntityState = BAPEntityState.Added
            };
            if (user != null)
            {
                sc.UserId = user.Id;
            }
            AddShoppingCart(sc);
            return sc;
        }

        /// <summary>
        /// Pulls the address from user.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <exception cref="BAP.Common.Exceptions.BAPUserException">Invalid user is in system</exception>
        public void PullAddressFromUser(ShoppingCart cart)
        {
            if (cart == null)
                return;

            var userId = _authContext.GetCurrentUserId();
            if (!string.IsNullOrEmpty(userId))
            {
                var orgUserBl = (IOrganizationUserBL)this;
                var user = orgUserBl.GetOrganizationUserByAspNetId(userId);
                if (user == null)
                    throw new BAP.Common.Exceptions.BAPUserException("Invalid user is in system");
                var customerBl = (ICustomerBL)this;
                var customer = customerBl.GetCustomerByUserId(user.Id);

                if (cart.BillingAddress == null)
                {
                    var uniqueSuffix = Guid.NewGuid().ToString();
                    cart.BillingAddress = new Address()
                    {
                        Name = user.FullName + ' ' + user.Zip + ' ' + uniqueSuffix,
                        EntityState = BAPEntityState.Added,
                        AddressLine1 = user.AddressLine1,
                        AddressLine2 = user.AddressLine2,
                        City = user.City,
                        ContactEmail = (user.Email.AsNullIfEmpty() ?? user.UserName).AsNullIfEmpty() ?? _authContext.GetCurrentUserName(),
                        Country = user.Country,
                        County = user.County,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        MiddleName = user.MiddleName,
                        PhoneNumber = user.PhoneNumber,
                        CellNumber = user.CellNumber,
                        State = user.State,
                        Zip = user.Zip,
                        CompanyName = ""
                    };

                    if (customer != null)
                    {
                        cart.BillingAddress.CompanyName = customer.CompanyName;
                        if (!customer.PhoneNumber.IsNullOrEmpty())
                        {
                            cart.BillingAddress.PhoneNumber = customer.PhoneNumber;
                            cart.BillingAddress.PhoneExtension = customer.PhoneExtension;
                        }
                        if (!customer.FaxNumber.IsNullOrEmpty())
                            cart.BillingAddress.FaxNumber = customer.FaxNumber;
                        if (!customer.CellNumber.IsNullOrEmpty())
                            cart.BillingAddress.CellNumber = customer.CellNumber;
                    }

                    var addrs = ((IAddressBL)this).AddAddress(cart.BillingAddress);
                    if (addrs != null)
                    {
                        cart.BillingAddressId = cart.BillingAddress.Id;
                        cart.BillingAddress.EntityState = BAPEntityState.Unchanged;
                        cart.EntityState = BAPEntityState.Modified;
                    }
                }

                if (cart.ShippingAddress == null && cart.BillingAddress != null)
                {
                    cart.ShippingAddress = new Address(cart.BillingAddress) { EntityState = BAPEntityState.Added };
                    var addrs = ((IAddressBL)this).AddAddress(cart.ShippingAddress);
                    if (addrs != null)
                    {
                        cart.ShippingAddressId = cart.ShippingAddress.Id;
                        cart.ShippingAddress.EntityState = BAPEntityState.Unchanged;
                        cart.EntityState = BAPEntityState.Modified;
                    }
                }

                if (cart.EntityState == BAPEntityState.Modified)
                    UpdateShoppingCart(cart);
            }
        }

        /// <summary>
        /// pull address from user as an asynchronous operation.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <exception cref="BAP.Common.Exceptions.BAPUserException">Invalid user is in system</exception>
        public async Task PullAddressFromUserAsync(ShoppingCart cart)
        {
            if (cart == null)
                return;

            var userId = _authContext.GetCurrentUserId();
            if (!string.IsNullOrEmpty(userId))
            {
                var orgUserBl = (IOrganizationUserBL)this;
                var user = await orgUserBl.GetOrganizationUserByAspNetIdAsync(userId);
                if (user == null)
                    throw new BAP.Common.Exceptions.BAPUserException("Invalid user is in system");
                var customerBl = (ICustomerBL)this;
                var customer = await customerBl.GetCustomerByUserIdAsync(user.Id);

                if (cart.BillingAddress == null)
                {
                    var uniqueSuffix = Guid.NewGuid().ToString();
                    cart.BillingAddress = new Address
                    {
                        Name = user.FullName + ' ' + user.Zip + ' ' + uniqueSuffix,
                        EntityState = BAPEntityState.Added,
                        AddressLine1 = user.AddressLine1,
                        AddressLine2 = user.AddressLine2,
                        City = user.City,
                        ContactEmail = (user.Email.AsNullIfEmpty() ?? user.UserName).AsNullIfEmpty() ?? _authContext.GetCurrentUserName(),
                        Country = user.Country,
                        County = user.County,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        MiddleName = user.MiddleName,
                        PhoneNumber = user.PhoneNumber,
                        CellNumber = user.CellNumber,
                        State = user.State,
                        Zip = user.Zip,
                        CompanyName = ""
                    };

                    if (customer != null)
                    {
                        cart.BillingAddress.CompanyName = customer.CompanyName;
                        if (!customer.PhoneNumber.IsNullOrEmpty())
                        {
                            cart.BillingAddress.PhoneNumber = customer.PhoneNumber;
                            cart.BillingAddress.PhoneExtension = customer.PhoneExtension;
                        }
                        if (!customer.FaxNumber.IsNullOrEmpty())
                            cart.BillingAddress.FaxNumber = customer.FaxNumber;
                        if (!customer.CellNumber.IsNullOrEmpty())
                            cart.BillingAddress.CellNumber = customer.CellNumber;
                    }

                    var addrs = ((IAddressBL)this).AddAddress(cart.BillingAddress);
                    if (addrs != null)
                    {
                        cart.BillingAddressId = cart.BillingAddress.Id;
                        cart.BillingAddress.EntityState = BAPEntityState.Unchanged;
                        cart.EntityState = BAPEntityState.Modified;
                    }
                }

                if (cart.ShippingAddress == null && cart.BillingAddress != null)
                {
                    cart.ShippingAddress = new Address(cart.BillingAddress) { EntityState = BAPEntityState.Added };
                    var addrs = ((IAddressBL)this).AddAddress(cart.ShippingAddress);
                    if (addrs != null)
                    {
                        cart.ShippingAddressId = cart.ShippingAddress.Id;
                        cart.ShippingAddress.EntityState = BAPEntityState.Unchanged;
                        cart.EntityState = BAPEntityState.Modified;
                    }
                }

                if (cart.EntityState == BAPEntityState.Modified)
                    await UpdateShoppingCartAsync(cart);
            }
        }

        /// <summary>
        /// Pulls the discount product ids.
        /// </summary>
        /// <param name="coupon">The coupon.</param>
        private void PullDiscountProductIds(DiscountCoupon coupon)
        {
            if (coupon == null)
                return;

            IeCommerceUnitOfWork tmpUnitOfWork = new eCommerceUnitOfWork(_configHelper, _authContext);
            var tmpDiscount = tmpUnitOfWork.DiscountCouponRepository.GetSingle(a => a.Id == coupon.Id, a => a.ProductsApplied);
            if (tmpDiscount?.ProductsApplied != null)
                coupon.ProductAppliedIds = tmpDiscount.ProductsApplied.Select(a => a.Id).ToList();
        }

        /// <summary>
        /// Assings the cart to user.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="orgUser">The org user.</param>
        /// <returns>ShoppingCart.</returns>
        private ShoppingCart AssingCartToUser(ShoppingCart cart, OrganizationUser orgUser)
        {
            cart.UserId = orgUser.Id;
            cart.User = null;
            cart.ShoppingCartProducts = null;
            cart.DiscountCoupon = null;
            cart.Currency = null;
            cart.BillingAddress = null;
            cart.ShippingAddress = null;
            cart.PaymentOption = null;
            cart.ShippingOption = null;
            cart.ShippingAsBilling = true;

            // No longer available for public access
            _eCommerceUnitOfWork.ShoppingCartRepository.UnsetPermission(cart, AuthorizationConstants.PublicReadPermission);
            _eCommerceUnitOfWork.ShoppingCartRepository.UnsetPermission(cart, AuthorizationConstants.PublicWritePermission);
            _eCommerceUnitOfWork.ShoppingCartRepository.UnsetPermission(cart, AuthorizationConstants.PublicDeletePermission);

            cart.EntityState = BAPEntityState.Modified;

            // Save changes to DB
            UpdateShoppingCart(cart);
            _eCommerceUnitOfWork.DetachAll();

            return GetShoppingCartById(cart.Id);
        }        
        #endregion
    }
}
