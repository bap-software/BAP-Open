// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="CustomerOrderPaymentBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedList;

using BAP.Common;
using BAP.eCommerce.DAL.Entities;

namespace BAP.eCommerce.BL
{
    /// <summary>
    /// Interface ICustomerOrderPaymentBL
    /// </summary>
    public interface ICustomerOrderPaymentBL
    {
        /// <summary>
        /// Gets all customer order payments.
        /// </summary>
        /// <returns>IList&lt;CustomerOrderPayment&gt;.</returns>
        IList<CustomerOrderPayment> GetAllCustomerOrderPayments();
        /// <summary>
        /// Gets all customer order payments asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;CustomerOrderPayment&gt;&gt;.</returns>
        Task<IList<CustomerOrderPayment>> GetAllCustomerOrderPaymentsAsync();

        /// <summary>
        /// Gets the customer order payments by order identifier.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>IList&lt;CustomerOrderPayment&gt;.</returns>
        IList<CustomerOrderPayment> GetCustomerOrderPaymentsByOrderId(int orderId);
        /// <summary>
        /// Gets the customer order payments by order identifier asynchronous.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>Task&lt;IList&lt;CustomerOrderPayment&gt;&gt;.</returns>
        Task<IList<CustomerOrderPayment>> GetCustomerOrderPaymentsByOrderIdAsync(int orderId);

        /// <summary>
        /// Searches the customer order payments.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;CustomerOrderPayment&gt;.</returns>
        IPagedList<CustomerOrderPayment> SearchCustomerOrderPayments(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the customer order payments asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;CustomerOrderPayment&gt;&gt;.</returns>
        Task<IPagedList<CustomerOrderPayment>> SearchCustomerOrderPaymentsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the customer order payment by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CustomerOrderPayment.</returns>
        CustomerOrderPayment GetCustomerOrderPaymentById(int id);
        /// <summary>
        /// Gets the customer order payment by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;CustomerOrderPayment&gt;.</returns>
        Task<CustomerOrderPayment> GetCustomerOrderPaymentByIdAsync(int id);

        /// <summary>
        /// Adds the customer order payment.
        /// </summary>
        /// <param name="customerOrderPayments">The customer order payments.</param>
        void AddCustomerOrderPayment(params CustomerOrderPayment[] customerOrderPayments);
        /// <summary>
        /// Adds the customer order payment asynchronous.
        /// </summary>
        /// <param name="customerOrderPayments">The customer order payments.</param>
        /// <returns>Task.</returns>
        Task AddCustomerOrderPaymentAsync(params CustomerOrderPayment[] customerOrderPayments);

        /// <summary>
        /// Updates the customer order payment.
        /// </summary>
        /// <param name="customerOrderPayments">The customer order payments.</param>
        void UpdateCustomerOrderPayment(params CustomerOrderPayment[] customerOrderPayments);
        /// <summary>
        /// Updates the customer order payment asynchronous.
        /// </summary>
        /// <param name="customerOrderPayments">The customer order payments.</param>
        /// <returns>Task.</returns>
        Task UpdateCustomerOrderPaymentAsync(params CustomerOrderPayment[] customerOrderPayments);

        /// <summary>
        /// Removes the customer order payment.
        /// </summary>
        /// <param name="customerOrderPayments">The customer order payments.</param>
        void RemoveCustomerOrderPayment(params CustomerOrderPayment[] customerOrderPayments);
        /// <summary>
        /// Removes the customer order payment asynchronous.
        /// </summary>
        /// <param name="customerOrderPayments">The customer order payments.</param>
        /// <returns>Task.</returns>
        Task RemoveCustomerOrderPaymentAsync(params CustomerOrderPayment[] customerOrderPayments);

        /// <summary>
        /// Removes the customer order payments.
        /// </summary>
        /// <param name="customerOrderId">The customer order identifier.</param>
        /// <param name="saveDb">if set to <c>true</c> [save database].</param>
        void RemoveCustomerOrderPayments(int customerOrderId, bool saveDb = true);
        /// <summary>
        /// Removes the customer order payments asynchronous.
        /// </summary>
        /// <param name="customerOrderId">The customer order identifier.</param>
        /// <param name="saveDb">if set to <c>true</c> [save database].</param>
        /// <returns>Task.</returns>
        Task RemoveCustomerOrderPaymentsAsync(int customerOrderId, bool saveDb = true);
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
    public partial class eCommerceBusinessLayer : ICustomerOrderPaymentBL
    {
        #region CustomerOrderPayments

        /// <summary>
        /// Gets all customer order payments.
        /// </summary>
        /// <returns>IList&lt;CustomerOrderPayment&gt;.</returns>
        public IList<CustomerOrderPayment> GetAllCustomerOrderPayments()
        {
            return _eCommerceUnitOfWork.CustomerOrderPaymentRepository.GetAll();
        }

        /// <summary>
        /// get all customer order payments as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;CustomerOrderPayment&gt;.</returns>
        public async Task<IList<CustomerOrderPayment>> GetAllCustomerOrderPaymentsAsync()
        {
            return await _eCommerceUnitOfWork.CustomerOrderPaymentRepository.GetAllAsync();
        }

        /// <summary>
        /// Gets the customer order payments by order identifier.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>IList&lt;CustomerOrderPayment&gt;.</returns>
        public IList<CustomerOrderPayment> GetCustomerOrderPaymentsByOrderId(int orderId)
        {
            return _eCommerceUnitOfWork.CustomerOrderPaymentRepository.GetList(a => a.CustomerOrderId == orderId, a => a.Currency);
        }

        /// <summary>
        /// get customer order payments by order identifier as an asynchronous operation.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>IList&lt;CustomerOrderPayment&gt;.</returns>
        public async Task<IList<CustomerOrderPayment>> GetCustomerOrderPaymentsByOrderIdAsync(int orderId)
        {
            return await _eCommerceUnitOfWork.CustomerOrderPaymentRepository.GetListAsync(a => a.CustomerOrderId == orderId, a => a.Currency);
        }

        /// <summary>
        /// Searches the customer order payments.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;CustomerOrderPayment&gt;.</returns>
        public IPagedList<CustomerOrderPayment> SearchCustomerOrderPayments(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<CustomerOrderPayment>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _eCommerceUnitOfWork.CustomerOrderPaymentRepository.GetPagedList(page, pageSize, ParseJSONSearchString<CustomerOrderPayment>(where), sortExpression, a => a.Currency, a => a.PaymentOption, a => a.CustomerPayment, a => a.CustomerOrder);
        }

        /// <summary>
        /// search customer order payments as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;CustomerOrderPayment&gt;.</returns>
        public async Task<IPagedList<CustomerOrderPayment>> SearchCustomerOrderPaymentsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<CustomerOrderPayment>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _eCommerceUnitOfWork.CustomerOrderPaymentRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<CustomerOrderPayment>(where), sortExpression, a => a.Currency, a => a.PaymentOption, a => a.CustomerPayment, a => a.CustomerOrder);
        }

        /// <summary>
        /// Gets the customer order payment by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CustomerOrderPayment.</returns>
        public CustomerOrderPayment GetCustomerOrderPaymentById(int id)
        {
            return _eCommerceUnitOfWork.CustomerOrderPaymentRepository.GetSingle(a => a.Id == id, a => a.Currency, a => a.PaymentOption, a => a.CustomerPayment, a => a.CustomerOrder);
        }

        /// <summary>
        /// get customer order payment by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CustomerOrderPayment.</returns>
        public async Task<CustomerOrderPayment> GetCustomerOrderPaymentByIdAsync(int id)
        {
            return await _eCommerceUnitOfWork.CustomerOrderPaymentRepository.GetSingleAsync(a => a.Id == id, a => a.Currency, a => a.PaymentOption, a => a.CustomerPayment, a => a.CustomerOrder);
        }

        /// <summary>
        /// Adds the customer order payment.
        /// </summary>
        /// <param name="customerOrderPayments">The customer order payments.</param>
        public void AddCustomerOrderPayment(params CustomerOrderPayment[] customerOrderPayments)
        {
            foreach(var payment in customerOrderPayments)
            {
                CleanFKs(payment);
            }
            _eCommerceUnitOfWork.CustomerOrderPaymentRepository.Add(customerOrderPayments);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// add customer order payment as an asynchronous operation.
        /// </summary>
        /// <param name="customerOrderPayments">The customer order payments.</param>
        public async Task AddCustomerOrderPaymentAsync(params CustomerOrderPayment[] customerOrderPayments)
        {
            foreach (var payment in customerOrderPayments)
            {
                CleanFKs(payment);
            }
            _eCommerceUnitOfWork.CustomerOrderPaymentRepository.Add(customerOrderPayments);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the customer order payment.
        /// </summary>
        /// <param name="customerOrderPayments">The customer order payments.</param>
        public void UpdateCustomerOrderPayment(params CustomerOrderPayment[] customerOrderPayments)
        {
            foreach (var payment in customerOrderPayments)
            {
                CleanFKs(payment);
            }
            _eCommerceUnitOfWork.CustomerOrderPaymentRepository.Update(customerOrderPayments);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// update customer order payment as an asynchronous operation.
        /// </summary>
        /// <param name="customerOrderPayments">The customer order payments.</param>
        public async Task UpdateCustomerOrderPaymentAsync(params CustomerOrderPayment[] customerOrderPayments)
        {
            foreach (var payment in customerOrderPayments)
            {
                CleanFKs(payment);
            }
            _eCommerceUnitOfWork.CustomerOrderPaymentRepository.Update(customerOrderPayments);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the customer order payment.
        /// </summary>
        /// <param name="customerOrderPayments">The customer order payments.</param>
        public void RemoveCustomerOrderPayment(params CustomerOrderPayment[] customerOrderPayments)
        {
            foreach (var payment in customerOrderPayments)
            {
                CleanFKs(payment);
            }
            _eCommerceUnitOfWork.CustomerOrderPaymentRepository.Remove(customerOrderPayments);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// remove customer order payment as an asynchronous operation.
        /// </summary>
        /// <param name="customerOrderPayments">The customer order payments.</param>
        public async Task RemoveCustomerOrderPaymentAsync(params CustomerOrderPayment[] customerOrderPayments)
        {
            foreach (var payment in customerOrderPayments)
            {
                CleanFKs(payment);
            }
            _eCommerceUnitOfWork.CustomerOrderPaymentRepository.Remove(customerOrderPayments);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the customer order payments.
        /// </summary>
        /// <param name="customerOrderId">The customer order identifier.</param>
        /// <param name="saveDb">if set to <c>true</c> [save database].</param>
        public void RemoveCustomerOrderPayments(int customerOrderId, bool saveDb = true)
        {
            var payments = _eCommerceUnitOfWork.CustomerOrderPaymentRepository.GetList(a => a.CustomerOrderId == customerOrderId);
            if(payments != null && payments.Count > 0)
            {
                foreach (var payment in payments)
                {
                    CleanFKs(payment);
                }
                _eCommerceUnitOfWork.CustomerOrderPaymentRepository.Remove(payments.ToArray());

                if(saveDb)
                    _eCommerceUnitOfWork.Save();
            }
        }

        /// <summary>
        /// remove customer order payments as an asynchronous operation.
        /// </summary>
        /// <param name="customerOrderId">The customer order identifier.</param>
        /// <param name="saveDb">if set to <c>true</c> [save database].</param>
        public async Task RemoveCustomerOrderPaymentsAsync(int customerOrderId, bool saveDb = true)
        {
            var payments = _eCommerceUnitOfWork.CustomerOrderPaymentRepository.GetList(a => a.CustomerOrderId == customerOrderId);
            if (payments != null && payments.Count > 0)
            {
                foreach (var payment in payments)
                {
                    CleanFKs(payment);
                }
                _eCommerceUnitOfWork.CustomerOrderPaymentRepository.Remove(payments.ToArray());

                if (saveDb)
                    await _eCommerceUnitOfWork.SaveAsync();
            }
        }

        /// <summary>
        /// Cleans the f ks.
        /// </summary>
        /// <param name="customerOrderPayment">The customer order payment.</param>
        private void CleanFKs(CustomerOrderPayment customerOrderPayment)
        {
            if (customerOrderPayment.Currency != null)
                customerOrderPayment.Currency = null;
            if (customerOrderPayment.CurrencyId == 0)
                customerOrderPayment.CurrencyId = null;

            if (customerOrderPayment.CustomerOrder != null)
                customerOrderPayment.CustomerOrder = null;
            if (customerOrderPayment.CustomerOrderId == 0)
                customerOrderPayment.CustomerOrderId = null;

            if (customerOrderPayment.CustomerPayment != null)
                customerOrderPayment.CustomerPayment = null;
            if (customerOrderPayment.CustomerPaymentId == 0)
                customerOrderPayment.CustomerPaymentId = null;

            if (customerOrderPayment.PaymentOption != null)
                customerOrderPayment.PaymentOption = null;
            if (customerOrderPayment.PaymentOptionId == 0)
                customerOrderPayment.PaymentOptionId = null;
        }

        #endregion
    }
}
