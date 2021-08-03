// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="ProductOptionItemBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PagedList;

using BAP.Common;
using BAP.eCommerce.DAL.Entities;

namespace BAP.eCommerce.BL
{
    /// <summary>
    /// Interface IProductOptionItemBL
    /// </summary>
    public interface IProductOptionItemBL
    {
        /// <summary>
        /// Gets all product option items.
        /// </summary>
        /// <returns>IList&lt;ProductOptionItem&gt;.</returns>
        IList<ProductOptionItem> GetAllProductOptionItems();
        /// <summary>
        /// Gets all product option items asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;ProductOptionItem&gt;&gt;.</returns>
        Task<IList<ProductOptionItem>> GetAllProductOptionItemsAsync();

        /// <summary>
        /// Searches the product option items.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ProductOptionItem&gt;.</returns>
        IPagedList<ProductOptionItem> SearchProductOptionItems(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the product option items asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;ProductOptionItem&gt;&gt;.</returns>
        Task<IPagedList<ProductOptionItem>> SearchProductOptionItemsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the product option item by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ProductOptionItem.</returns>
        ProductOptionItem GetProductOptionItemById(int id);
        /// <summary>
        /// Gets the product option item by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ProductOptionItem&gt;.</returns>
        Task<ProductOptionItem> GetProductOptionItemByIdAsync(int id);

        /// <summary>
        /// Adds the product option item.
        /// </summary>
        /// <param name="productOptionItems">The product option items.</param>
        void AddProductOptionItem(params ProductOptionItem[] productOptionItems);
        /// <summary>
        /// Adds the product option item asynchronous.
        /// </summary>
        /// <param name="productOptionItems">The product option items.</param>
        /// <returns>Task.</returns>
        Task AddProductOptionItemAsync(params ProductOptionItem[] productOptionItems);

        /// <summary>
        /// Updates the product option item.
        /// </summary>
        /// <param name="productOptionItems">The product option items.</param>
        void UpdateProductOptionItem(params ProductOptionItem[] productOptionItems);
        /// <summary>
        /// Updates the product option item asynchronous.
        /// </summary>
        /// <param name="productOptionItems">The product option items.</param>
        /// <returns>Task.</returns>
        Task UpdateProductOptionItemAsync(params ProductOptionItem[] productOptionItems);

        /// <summary>
        /// Removes the product option item.
        /// </summary>
        /// <param name="productOptionItems">The product option items.</param>
        void RemoveProductOptionItem(params ProductOptionItem[] productOptionItems);
        /// <summary>
        /// Removes the product option item asynchronous.
        /// </summary>
        /// <param name="productOptionItems">The product option items.</param>
        /// <returns>Task.</returns>
        Task RemoveProductOptionItemAsync(params ProductOptionItem[] productOptionItems);
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
    public partial class eCommerceBusinessLayer : IProductOptionItemBL, ILocalizedBL<ProductOptionItem>
    {
        #region productOptionItems

        /// <summary>
        /// Gets all product option items.
        /// </summary>
        /// <returns>IList&lt;ProductOptionItem&gt;.</returns>
        public IList<ProductOptionItem> GetAllProductOptionItems()
        {
            return _eCommerceUnitOfWork.ProductOptionItemRepository.GetAll();
        }

        /// <summary>
        /// get all product option items as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;ProductOptionItem&gt;.</returns>
        public async Task<IList<ProductOptionItem>> GetAllProductOptionItemsAsync()
        {
            return await _eCommerceUnitOfWork.ProductOptionItemRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the product option items.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ProductOptionItem&gt;.</returns>
        public IPagedList<ProductOptionItem> SearchProductOptionItems(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<ProductOptionItem>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _eCommerceUnitOfWork.ProductOptionItemRepository.GetPagedList(page, pageSize, ParseJSONSearchString<ProductOptionItem>(where), sortExpression, a => a.ProductOption);
        }

        /// <summary>
        /// search product option items as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ProductOptionItem&gt;.</returns>
        public async Task<IPagedList<ProductOptionItem>> SearchProductOptionItemsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<ProductOptionItem>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _eCommerceUnitOfWork.ProductOptionItemRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<ProductOptionItem>(where), sortExpression, a => a.ProductOption);
        }

        /// <summary>
        /// Gets the product option item by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ProductOptionItem.</returns>
        public ProductOptionItem GetProductOptionItemById(int id)
        {
            return _eCommerceUnitOfWork.ProductOptionItemRepository.GetSingle(a => a.Id == id, a => a.ProductOption);
        }

        /// <summary>
        /// get product option item by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ProductOptionItem.</returns>
        public async Task<ProductOptionItem> GetProductOptionItemByIdAsync(int id)
        {
            return await _eCommerceUnitOfWork.ProductOptionItemRepository.GetSingleAsync(a => a.Id == id, a => a.ProductOption);
        }

        /// <summary>
        /// Adds the product option item.
        /// </summary>
        /// <param name="productOptionItems">The product option items.</param>
        public void AddProductOptionItem(params ProductOptionItem[] productOptionItems)
        {
            _eCommerceUnitOfWork.ProductOptionItemRepository.Add(productOptionItems);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// add product option item as an asynchronous operation.
        /// </summary>
        /// <param name="productOptionItems">The product option items.</param>
        public async Task AddProductOptionItemAsync(params ProductOptionItem[] productOptionItems)
        {
            _eCommerceUnitOfWork.ProductOptionItemRepository.Add(productOptionItems);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the product option item.
        /// </summary>
        /// <param name="productOptionItems">The product option items.</param>
        public void UpdateProductOptionItem(params ProductOptionItem[] productOptionItems)
        {
            _eCommerceUnitOfWork.ProductOptionItemRepository.Update(productOptionItems);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// update product option item as an asynchronous operation.
        /// </summary>
        /// <param name="productOptionItems">The product option items.</param>
        public async Task UpdateProductOptionItemAsync(params ProductOptionItem[] productOptionItems)
        {
            _eCommerceUnitOfWork.ProductOptionItemRepository.Update(productOptionItems);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the product option item.
        /// </summary>
        /// <param name="productOptionItems">The product option items.</param>
        public void RemoveProductOptionItem(params ProductOptionItem[] productOptionItems)
        {
            _eCommerceUnitOfWork.ProductOptionItemRepository.Remove(productOptionItems);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// remove product option item as an asynchronous operation.
        /// </summary>
        /// <param name="productOptionItems">The product option items.</param>
        public async Task RemoveProductOptionItemAsync(params ProductOptionItem[] productOptionItems)
        {
            _eCommerceUnitOfWork.ProductOptionItemRepository.Remove(productOptionItems);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        #region ILocalizedBL
        /// <summary>
        /// Get full details of the single entity
        /// </summary>
        /// <param name="ofEntity">Passed entity is used as filter, method implementing ths feature should treat this oject apropriatly to call some method of BL class to read full details.</param>
        /// <returns>Entity instance</returns>
        public ProductOptionItem GetDetails(ProductOptionItem ofEntity)
        {
            if (ofEntity == null)
                return null;

            if (ofEntity.Id > 0)
                return GetProductOptionItemById(ofEntity.Id);
            
            return null;
        }

        /// <summary>
        /// Adds the single entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void AddSingleEntity(ProductOptionItem entity)
        {
            _eCommerceUnitOfWork.ProductOptionItemRepository.Add(entity);
            _eCommerceUnitOfWork.Save();
        }
        #endregion

        #endregion
    }
}
