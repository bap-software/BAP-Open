// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ShoppingCartProductBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using PagedList;

using BAP.eCommerce.DAL.Entities;
using BAP.Common;

namespace BAP.eCommerce.BL
{
    /// <summary>
    /// Interface IShoppingCartProductBL
    /// </summary>
    public interface IShoppingCartProductBL
    {
        /// <summary>
        /// Gets all shopping cart products.
        /// </summary>
        /// <returns>IList&lt;ShoppingCartProduct&gt;.</returns>
        IList<ShoppingCartProduct> GetAllShoppingCartProducts();
        /// <summary>
        /// Gets all shopping cart products asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;ShoppingCartProduct&gt;&gt;.</returns>
        Task<IList<ShoppingCartProduct>> GetAllShoppingCartProductsAsync();

        /// <summary>
        /// Searches the shopping cart products.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ShoppingCartProduct&gt;.</returns>
        IPagedList<ShoppingCartProduct> SearchShoppingCartProducts(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the shopping cart products asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;ShoppingCartProduct&gt;&gt;.</returns>
        Task<IPagedList<ShoppingCartProduct>> SearchShoppingCartProductsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the shopping cart product by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShoppingCartProduct.</returns>
        ShoppingCartProduct GetShoppingCartProductById(int id);
        /// <summary>
        /// Gets the shopping cart product by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ShoppingCartProduct&gt;.</returns>
        Task<ShoppingCartProduct> GetShoppingCartProductByIdAsync(int id);

        /// <summary>
        /// Removes the shopping cart product.
        /// </summary>
        /// <param name="shoppingCartProducts">The shopping cart products.</param>
        void RemoveShoppingCartProduct(params ShoppingCartProduct[] shoppingCartProducts);
        /// <summary>
        /// Removes the shopping cart product asynchronous.
        /// </summary>
        /// <param name="shoppingCartProducts">The shopping cart products.</param>
        /// <returns>Task.</returns>
        Task RemoveShoppingCartProductAsync(params ShoppingCartProduct[] shoppingCartProducts);
    }

    /// <summary>
    /// Class eCommerceBusinessLayer.
    /// Implements the <see cref="BAP.BL.BusinessLayer" />
    /// Implements the <see cref="BAP.eCommerce.BL.IProductOptionBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.eCommerce.DAL.Entities.ProductOption}" />
    /// Implements the <see cref="BAP.eCommerce.BL.ICustomerOrderBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.ICustomerOrderWorkflow" />
    /// Implements the <see cref="BAP.eCommerce.BL.IStoreBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.IOrderItemBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.ISupplierBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.eCommerce.DAL.Entities.Supplier}" />
    /// Implements the <see cref="System.IDisposable" />
    /// Implements the <see cref="BAP.eCommerce.BL.IProductCategoryBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.eCommerce.DAL.Entities.ProductCategory}" />
    /// Implements the <see cref="BAP.eCommerce.BL.IPaymentOptionBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.eCommerce.DAL.Entities.PaymentOption}" />
    /// Implements the <see cref="BAP.eCommerce.BL.IProductBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.eCommerce.DAL.Entities.Product}" />
    /// Implements the <see cref="BAP.eCommerce.BL.IManufacturerBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.eCommerce.DAL.Entities.Manufacturer}" />
    /// Implements the <see cref="BAP.eCommerce.BL.IShippingOptionBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.eCommerce.DAL.Entities.ShippingOption}" />
    /// Implements the <see cref="BAP.eCommerce.BL.IProductOptionItemBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.eCommerce.DAL.Entities.ProductOptionItem}" />
    /// Implements the <see cref="BAP.eCommerce.BL.IShoppingCartBL" />
    /// Implements the <see cref="BAP.Common.ICriteriaSupport{BAP.eCommerce.DAL.Entities.ShoppingCart}" />
    /// Implements the <see cref="BAP.eCommerce.BL.IShippingCarrierBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.eCommerce.DAL.Entities.ShippingCarrier}" />
    /// Implements the <see cref="BAP.eCommerce.BL.ICustomerPaymentBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.ICustomerOrderPaymentBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.IDiscountCouponBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.eCommerce.DAL.Entities.DiscountCoupon}" />
    /// Implements the <see cref="BAP.eCommerce.BL.IAddressBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.IShoppingCartProductBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.ICustomerBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.IRelatedProductBL" />
    /// </summary>
    /// <seealso cref="BAP.BL.BusinessLayer" />
    /// <seealso cref="BAP.eCommerce.BL.IProductOptionBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.eCommerce.DAL.Entities.ProductOption}" />
    /// <seealso cref="BAP.eCommerce.BL.ICustomerOrderBL" />
    /// <seealso cref="BAP.eCommerce.BL.ICustomerOrderWorkflow" />
    /// <seealso cref="BAP.eCommerce.BL.IStoreBL" />
    /// <seealso cref="BAP.eCommerce.BL.IOrderItemBL" />
    /// <seealso cref="BAP.eCommerce.BL.ISupplierBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.eCommerce.DAL.Entities.Supplier}" />
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="BAP.eCommerce.BL.IProductCategoryBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.eCommerce.DAL.Entities.ProductCategory}" />
    /// <seealso cref="BAP.eCommerce.BL.IPaymentOptionBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.eCommerce.DAL.Entities.PaymentOption}" />
    /// <seealso cref="BAP.eCommerce.BL.IProductBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.eCommerce.DAL.Entities.Product}" />
    /// <seealso cref="BAP.eCommerce.BL.IManufacturerBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.eCommerce.DAL.Entities.Manufacturer}" />
    /// <seealso cref="BAP.eCommerce.BL.IShippingOptionBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.eCommerce.DAL.Entities.ShippingOption}" />
    /// <seealso cref="BAP.eCommerce.BL.IProductOptionItemBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.eCommerce.DAL.Entities.ProductOptionItem}" />
    /// <seealso cref="BAP.eCommerce.BL.IShoppingCartBL" />
    /// <seealso cref="BAP.Common.ICriteriaSupport{BAP.eCommerce.DAL.Entities.ShoppingCart}" />
    /// <seealso cref="BAP.eCommerce.BL.IShippingCarrierBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.eCommerce.DAL.Entities.ShippingCarrier}" />
    /// <seealso cref="BAP.eCommerce.BL.ICustomerPaymentBL" />
    /// <seealso cref="BAP.eCommerce.BL.ICustomerOrderPaymentBL" />
    /// <seealso cref="BAP.eCommerce.BL.IDiscountCouponBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.eCommerce.DAL.Entities.DiscountCoupon}" />
    /// <seealso cref="BAP.eCommerce.BL.IAddressBL" />
    /// <seealso cref="BAP.eCommerce.BL.IShoppingCartProductBL" />
    /// <seealso cref="BAP.eCommerce.BL.ICustomerBL" />
    /// <seealso cref="BAP.eCommerce.BL.IRelatedProductBL" />
    public partial class eCommerceBusinessLayer : IShoppingCartProductBL
    {
        /// <summary>
        /// Gets all shopping cart products.
        /// </summary>
        /// <returns>IList&lt;ShoppingCartProduct&gt;.</returns>
        public IList<ShoppingCartProduct> GetAllShoppingCartProducts()
        {
            return _eCommerceUnitOfWork.ShoppingCartProductRepository.GetAll(a => a.DiscountCoupon, a => a.Product, a => a.ShoppingCart);
        }

        /// <summary>
        /// get all shopping cart products as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;ShoppingCartProduct&gt;.</returns>
        public async Task<IList<ShoppingCartProduct>> GetAllShoppingCartProductsAsync()
        {
            return await _eCommerceUnitOfWork.ShoppingCartProductRepository.GetAllAsync(a => a.DiscountCoupon, a => a.Product, a => a.ShoppingCart);
        }

        /// <summary>
        /// Searches the shopping cart products.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ShoppingCartProduct&gt;.</returns>
        public IPagedList<ShoppingCartProduct> SearchShoppingCartProducts(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<ShoppingCartProduct>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _eCommerceUnitOfWork.ShoppingCartProductRepository.GetPagedList(page, pageSize, ParseJSONSearchString<ShoppingCartProduct>(where), sortExpression);
        }

        /// <summary>
        /// search shopping cart products as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ShoppingCartProduct&gt;.</returns>
        public async Task<IPagedList<ShoppingCartProduct>> SearchShoppingCartProductsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<ShoppingCartProduct>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _eCommerceUnitOfWork.ShoppingCartProductRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<ShoppingCartProduct>(where), sortExpression);
        }

        /// <summary>
        /// Gets the shopping cart product by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShoppingCartProduct.</returns>
        public ShoppingCartProduct GetShoppingCartProductById(int id)
        {
            var shoppingCartProduct = _eCommerceUnitOfWork.ShoppingCartProductRepository.GetSingle(a => a.Id == id, a => a.ShoppingCart);            

            return shoppingCartProduct;
        }

        /// <summary>
        /// get shopping cart product by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShoppingCartProduct.</returns>
        public async Task<ShoppingCartProduct> GetShoppingCartProductByIdAsync(int id)
        {
            var shoppingCartProduct = await _eCommerceUnitOfWork.ShoppingCartProductRepository.GetSingleAsync(a => a.Id == id, a => a.ShoppingCart);

            return shoppingCartProduct;
        }

        /// <summary>
        /// Gets the single shopping cart product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShoppingCartProduct.</returns>
        public ShoppingCartProduct GetSingleShoppingCartProduct(int id)
        {
            var shoppingCartProduct = _eCommerceUnitOfWork.ShoppingCartProductRepository.GetSingle(a => a.Id == id);

            return shoppingCartProduct;
        }

        /// <summary>
        /// Removes the shopping cart product.
        /// </summary>
        /// <param name="shoppingCartProducts">The shopping cart products.</param>
        public void RemoveShoppingCartProduct(params ShoppingCartProduct[] shoppingCartProducts)
        {
            _eCommerceUnitOfWork.ShoppingCartProductRepository.Remove(shoppingCartProducts);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// remove shopping cart product as an asynchronous operation.
        /// </summary>
        /// <param name="shoppingCartProducts">The shopping cart products.</param>
        public async Task RemoveShoppingCartProductAsync(params ShoppingCartProduct[] shoppingCartProducts)
        {
            _eCommerceUnitOfWork.ShoppingCartProductRepository.Remove(shoppingCartProducts);
            await _eCommerceUnitOfWork.SaveAsync();
        }
    }
}
