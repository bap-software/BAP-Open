// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="CustomerPaymentBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using PagedList;

using BAP.Common;
using BAP.eCommerce.DAL.Entities;

namespace BAP.eCommerce.BL
{
    /// <summary>
    /// Interface ICustomerPaymentBL
    /// </summary>
    public interface ICustomerPaymentBL
    {
        /// <summary>
        /// Gets all customer payments.
        /// </summary>
        /// <returns>IList&lt;CustomerPayment&gt;.</returns>
        IList<CustomerPayment> GetAllCustomerPayments();
        /// <summary>
        /// Gets all customer payments asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;CustomerPayment&gt;&gt;.</returns>
        Task<IList<CustomerPayment>> GetAllCustomerPaymentsAsync();

        /// <summary>
        /// Searches the customer payments.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;CustomerPayment&gt;.</returns>
        IPagedList<CustomerPayment> SearchCustomerPayments(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the customer payments asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;CustomerPayment&gt;&gt;.</returns>
        Task<IPagedList<CustomerPayment>> SearchCustomerPaymentsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the customer payment by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CustomerPayment.</returns>
        CustomerPayment GetCustomerPaymentById(int id);
        /// <summary>
        /// Gets the customer payment by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;CustomerPayment&gt;.</returns>
        Task<CustomerPayment> GetCustomerPaymentByIdAsync(int id);

        /// <summary>
        /// Adds the customer payment.
        /// </summary>
        /// <param name="customerPayments">The customer payments.</param>
        void AddCustomerPayment(params CustomerPayment[] customerPayments);
        /// <summary>
        /// Adds the customer payment asynchronous.
        /// </summary>
        /// <param name="customerPayments">The customer payments.</param>
        /// <returns>Task.</returns>
        Task AddCustomerPaymentAsync(params CustomerPayment[] customerPayments);

        /// <summary>
        /// Updates the customer payment.
        /// </summary>
        /// <param name="customerPayments">The customer payments.</param>
        void UpdateCustomerPayment(params CustomerPayment[] customerPayments);
        /// <summary>
        /// Updates the customer payment asynchronous.
        /// </summary>
        /// <param name="customerPayments">The customer payments.</param>
        /// <returns>Task.</returns>
        Task UpdateCustomerPaymentAsync(params CustomerPayment[] customerPayments);

        /// <summary>
        /// Removes the customer payment.
        /// </summary>
        /// <param name="customerPayments">The customer payments.</param>
        void RemoveCustomerPayment(params CustomerPayment[] customerPayments);
        /// <summary>
        /// Removes the customer payment asynchronous.
        /// </summary>
        /// <param name="customerPayments">The customer payments.</param>
        /// <returns>Task.</returns>
        Task RemoveCustomerPaymentAsync(params CustomerPayment[] customerPayments);
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
    public partial class eCommerceBusinessLayer : ICustomerPaymentBL
    {
        #region customerPayments

        /// <summary>
        /// Gets all customer payments.
        /// </summary>
        /// <returns>IList&lt;CustomerPayment&gt;.</returns>
        public IList<CustomerPayment> GetAllCustomerPayments()
        {
            return _eCommerceUnitOfWork.CustomerPaymentRepository.GetAll();
        }

        /// <summary>
        /// get all customer payments as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;CustomerPayment&gt;.</returns>
        public async Task<IList<CustomerPayment>> GetAllCustomerPaymentsAsync()
        {
            return await _eCommerceUnitOfWork.CustomerPaymentRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the customer payments.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;CustomerPayment&gt;.</returns>
        public IPagedList<CustomerPayment> SearchCustomerPayments(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<CustomerPayment>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _eCommerceUnitOfWork.CustomerPaymentRepository.GetPagedList(page, pageSize, ParseJSONSearchString<CustomerPayment>(where), sortExpression, a => a.Customer, a => a.PaymentOption);
        }

        /// <summary>
        /// search customer payments as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;CustomerPayment&gt;.</returns>
        public async Task<IPagedList<CustomerPayment>> SearchCustomerPaymentsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<CustomerPayment>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _eCommerceUnitOfWork.CustomerPaymentRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<CustomerPayment>(where), sortExpression, a => a.Customer, a => a.PaymentOption);
        }

        /// <summary>
        /// Gets the customer payment by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CustomerPayment.</returns>
        public CustomerPayment GetCustomerPaymentById(int id)
        {
            return _eCommerceUnitOfWork.CustomerPaymentRepository.GetSingle(a => a.Id == id, a => a.Customer, a => a.PaymentOption);
        }

        /// <summary>
        /// get customer payment by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CustomerPayment.</returns>
        public async Task<CustomerPayment> GetCustomerPaymentByIdAsync(int id)
        {
            return await _eCommerceUnitOfWork.CustomerPaymentRepository.GetSingleAsync(a => a.Id == id, a => a.Customer, a => a.PaymentOption);
        }

        /// <summary>
        /// Adds the customer payment.
        /// </summary>
        /// <param name="customerPayments">The customer payments.</param>
        public void AddCustomerPayment(params CustomerPayment[] customerPayments)
        {            
            _eCommerceUnitOfWork.CustomerPaymentRepository.Add(customerPayments);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// add customer payment as an asynchronous operation.
        /// </summary>
        /// <param name="customerPayments">The customer payments.</param>
        public async Task AddCustomerPaymentAsync(params CustomerPayment[] customerPayments)
        {
            _eCommerceUnitOfWork.CustomerPaymentRepository.Add(customerPayments);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the customer payment.
        /// </summary>
        /// <param name="customerPayments">The customer payments.</param>
        public void UpdateCustomerPayment(params CustomerPayment[] customerPayments)
        {            
            _eCommerceUnitOfWork.CustomerPaymentRepository.Update(customerPayments);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// update customer payment as an asynchronous operation.
        /// </summary>
        /// <param name="customerPayments">The customer payments.</param>
        public async Task UpdateCustomerPaymentAsync(params CustomerPayment[] customerPayments)
        {
            _eCommerceUnitOfWork.CustomerPaymentRepository.Update(customerPayments);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the customer payment.
        /// </summary>
        /// <param name="customerPayments">The customer payments.</param>
        public void RemoveCustomerPayment(params CustomerPayment[] customerPayments)
        {
            _eCommerceUnitOfWork.CustomerPaymentRepository.Remove(customerPayments);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// remove customer payment as an asynchronous operation.
        /// </summary>
        /// <param name="customerPayments">The customer payments.</param>
        public async Task RemoveCustomerPaymentAsync(params CustomerPayment[] customerPayments)
        {
            _eCommerceUnitOfWork.CustomerPaymentRepository.Remove(customerPayments);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        #endregion
    }
}
