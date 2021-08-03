// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="OrderItemBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

using PagedList;

using BAP.Common;
using BAP.eCommerce.DAL.Entities;
using System.Threading.Tasks;

namespace BAP.eCommerce.BL
{
    /// <summary>
    /// Interface IOrderItemBL
    /// </summary>
    public interface IOrderItemBL
    {
        /// <summary>
        /// Gets all order items.
        /// </summary>
        /// <returns>IList&lt;OrderItem&gt;.</returns>
        IList<OrderItem> GetAllOrderItems();
        /// <summary>
        /// Gets all order items asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;OrderItem&gt;&gt;.</returns>
        Task<IList<OrderItem>> GetAllOrderItemsAsync();

        /// <summary>
        /// Searches the order items.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;OrderItem&gt;.</returns>
        IPagedList<OrderItem> SearchOrderItems(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the order items asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;OrderItem&gt;&gt;.</returns>
        Task<IPagedList<OrderItem>> SearchOrderItemsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the order item by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>OrderItem.</returns>
        OrderItem GetOrderItemById(int id);
        /// <summary>
        /// Gets the order item by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;OrderItem&gt;.</returns>
        Task<OrderItem> GetOrderItemByIdAsync(int id);

        /// <summary>
        /// Adds the order item.
        /// </summary>
        /// <param name="orderItems">The order items.</param>
        void AddOrderItem(params OrderItem[] orderItems);
        /// <summary>
        /// Adds the order item asynchronous.
        /// </summary>
        /// <param name="orderItems">The order items.</param>
        /// <returns>Task.</returns>
        Task AddOrderItemAsync(params OrderItem[] orderItems);

        /// <summary>
        /// Updates the order item.
        /// </summary>
        /// <param name="orderItems">The order items.</param>
        void UpdateOrderItem(params OrderItem[] orderItems);
        /// <summary>
        /// Updates the order item asynchronous.
        /// </summary>
        /// <param name="orderItems">The order items.</param>
        /// <returns>Task.</returns>
        Task UpdateOrderItemAsync(params OrderItem[] orderItems);

        /// <summary>
        /// Removes the order item.
        /// </summary>
        /// <param name="orderItems">The order items.</param>
        void RemoveOrderItem(params OrderItem[] orderItems);
        /// <summary>
        /// Removes the order item asynchronous.
        /// </summary>
        /// <param name="orderItems">The order items.</param>
        /// <returns>Task.</returns>
        Task RemoveOrderItemAsync(params OrderItem[] orderItems);
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
    public partial class eCommerceBusinessLayer : IOrderItemBL
    {
        #region orderItems

        /// <summary>
        /// Gets all order items.
        /// </summary>
        /// <returns>IList&lt;OrderItem&gt;.</returns>
        public IList<OrderItem> GetAllOrderItems()
        {
            return _eCommerceUnitOfWork.OrderItemRepository.GetAll();
        }

        /// <summary>
        /// get all order items as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;OrderItem&gt;.</returns>
        public async Task<IList<OrderItem>> GetAllOrderItemsAsync()
        {
            return await _eCommerceUnitOfWork.OrderItemRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the order items.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;OrderItem&gt;.</returns>
        public IPagedList<OrderItem> SearchOrderItems(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<OrderItem>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _eCommerceUnitOfWork.OrderItemRepository.GetPagedList(page, pageSize, ParseJSONSearchString<OrderItem>(where), sortExpression, a => a.Product, a => a.CustomerOrder, a => a.DiscountCoupon);
        }

        /// <summary>
        /// search order items as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;OrderItem&gt;.</returns>
        public async Task<IPagedList<OrderItem>> SearchOrderItemsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<OrderItem>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _eCommerceUnitOfWork.OrderItemRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<OrderItem>(where), sortExpression, a => a.Product, a => a.CustomerOrder, a => a.DiscountCoupon);
        }

        /// <summary>
        /// Gets the order item by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>OrderItem.</returns>
        public OrderItem GetOrderItemById(int id)
        {
            return _eCommerceUnitOfWork.OrderItemRepository.GetSingle(a => a.Id == id, a => a.Product, a => a.CustomerOrder, a => a.DiscountCoupon);
        }

        /// <summary>
        /// get order item by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>OrderItem.</returns>
        public async Task<OrderItem> GetOrderItemByIdAsync(int id)
        {
            return await _eCommerceUnitOfWork.OrderItemRepository.GetSingleAsync(a => a.Id == id, a => a.Product, a => a.CustomerOrder, a => a.DiscountCoupon);
        }

        /// <summary>
        /// Adds the order item.
        /// </summary>
        /// <param name="orderItems">The order items.</param>
        public void AddOrderItem(params OrderItem[] orderItems)
        {
            _eCommerceUnitOfWork.OrderItemRepository.Add(orderItems);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// add order item as an asynchronous operation.
        /// </summary>
        /// <param name="orderItems">The order items.</param>
        public async Task AddOrderItemAsync(params OrderItem[] orderItems)
        {
            _eCommerceUnitOfWork.OrderItemRepository.Add(orderItems);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the order item.
        /// </summary>
        /// <param name="orderItems">The order items.</param>
        public void UpdateOrderItem(params OrderItem[] orderItems)
        {
            _eCommerceUnitOfWork.OrderItemRepository.Update(orderItems);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// update order item as an asynchronous operation.
        /// </summary>
        /// <param name="orderItems">The order items.</param>
        public async Task UpdateOrderItemAsync(params OrderItem[] orderItems)
        {
            _eCommerceUnitOfWork.OrderItemRepository.Update(orderItems);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the order item.
        /// </summary>
        /// <param name="orderItems">The order items.</param>
        public void RemoveOrderItem(params OrderItem[] orderItems)
        {
            _eCommerceUnitOfWork.OrderItemRepository.Remove(orderItems);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// remove order item as an asynchronous operation.
        /// </summary>
        /// <param name="orderItems">The order items.</param>
        public async Task RemoveOrderItemAsync(params OrderItem[] orderItems)
        {
            _eCommerceUnitOfWork.OrderItemRepository.Remove(orderItems);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        #endregion
    }
}
