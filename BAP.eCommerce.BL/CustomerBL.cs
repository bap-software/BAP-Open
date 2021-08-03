// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="CustomerBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using PagedList;

using BAP.Common;
using BAP.Workflow;
using BAP.eCommerce.DAL.Entities;
using BAP.DAL.Entities;

namespace BAP.eCommerce.BL
{
    /// <summary>
    /// Interface to make Customer service supporting workflows
    /// </summary>
    /// <seealso cref="BAP.Workflow.ISupportWorkflow{BAP.eCommerce.DAL.Entities.Customer}" />
    public interface ICustomerWorkflow : ISupportWorkflow<Customer>
    {
    }

    /// <summary>
    /// Interface ICustomerBL
    /// </summary>
    public interface ICustomerBL
    {
        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns>IList&lt;Customer&gt;.</returns>
        IList<Customer> GetAllCustomers();
        /// <summary>
        /// Gets all customers asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;Customer&gt;&gt;.</returns>
        Task<IList<Customer>> GetAllCustomersAsync();

        /// <summary>
        /// Searches the customers.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Customer&gt;.</returns>
        IPagedList<Customer> SearchCustomers(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the customers asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;Customer&gt;&gt;.</returns>
        Task<IPagedList<Customer>> SearchCustomersAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the customer by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Customer.</returns>
        Customer GetCustomerById(int id);
        /// <summary>
        /// Gets the customer by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Customer&gt;.</returns>
        Task<Customer> GetCustomerByIdAsync(int id);


        /// <summary>
        /// Generate customer name out of cart name
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        string GenerateCustomerName(ShoppingCart cart);

        /// <summary>
        /// Gets the customer by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Customer.</returns>
        Customer GetCustomerByName(string name);
        /// <summary>
        /// Gets the customer by name asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Task&lt;Customer&gt;.</returns>
        Task<Customer> GetCustomerByNameAsync(string name);

        /// <summary>
        /// Gets the customer by user identifier.
        /// </summary>
        /// <param name="orgUserId">The org user identifier.</param>
        /// <returns>Customer.</returns>
        Customer GetCustomerByUserId(int orgUserId);
        /// <summary>
        /// Gets the customer by user identifier asynchronous.
        /// </summary>
        /// <param name="orgUserId">The org user identifier.</param>
        /// <returns>Task&lt;Customer&gt;.</returns>
        Task<Customer> GetCustomerByUserIdAsync(int orgUserId);

        /// <summary>
        /// Adds the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        void AddCustomer(Customer customer);
        /// <summary>
        /// Adds the customer asynchronous.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns>Task.</returns>
        Task AddCustomerAsync(Customer customer);

        /// <summary>
        /// Creates the customer from shopping cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>Customer.</returns>
        Customer CreateCustomerFromShoppingCart(ShoppingCart cart);
        /// <summary>
        /// Creates the customer from shopping cart asynchronous.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>Task&lt;Customer&gt;.</returns>
        Task<Customer> CreateCustomerFromShoppingCartAsync(ShoppingCart cart);

        /// <summary>
        /// Updates the customer payment from shopping cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="customer">The customer.</param>
        void UpdateCustomerPaymentFromShoppingCart(ShoppingCart cart, Customer customer);

        /// <summary>
        /// Updates the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        void UpdateCustomer(Customer customer);
        /// <summary>
        /// Updates the customer asynchronous.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns>Task.</returns>
        Task UpdateCustomerAsync(Customer customer);

        /// <summary>
        /// Removes the customer.
        /// </summary>
        /// <param name="customers">The customers.</param>
        void RemoveCustomer(params Customer[] customers);
        /// <summary>
        /// Removes the customer asynchronous.
        /// </summary>
        /// <param name="customers">The customers.</param>
        /// <returns>Task.</returns>
        Task RemoveCustomerAsync(params Customer[] customers);

        /// <summary>
        /// Removes the customer payment.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <param name="customerPayment">The customer payment.</param>
        void RemoveCustomerPayment(Customer customer, CustomerPayment customerPayment);
        /// <summary>
        /// Removes the customer payment asynchronous.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <param name="customerPayment">The customer payment.</param>
        /// <returns>Task.</returns>
        Task RemoveCustomerPaymentAsync(Customer customer, CustomerPayment customerPayment);

        /// <summary>
        /// Initializes the subordinate entities.
        /// </summary>
        /// <param name="customer">The customer.</param>
        void InitSubordinateEntities(Customer customer);
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
    public partial class eCommerceBusinessLayer : ICustomerBL, ICustomerWorkflow
    {

        #region Customers

        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns>IList&lt;Customer&gt;.</returns>
        public IList<Customer> GetAllCustomers()
        {
            return _eCommerceUnitOfWork.CustomerRepository.GetAll();
        }

        /// <summary>
        /// get all customers as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;Customer&gt;.</returns>
        public async Task<IList<Customer>> GetAllCustomersAsync()
        {
            return await _eCommerceUnitOfWork.CustomerRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the customers.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Customer&gt;.</returns>
        public IPagedList<Customer> SearchCustomers(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<Customer>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _eCommerceUnitOfWork.CustomerRepository.GetPagedList(page, pageSize, ParseJSONSearchString<Customer>(where), sortExpression, a => a.LoginUser, a => a.BillingAddress, a => a.ShippingAddress, a => a.CompanyAddress, a => a.PrefferedCurrency, a => a.PrefferedShippingOption);
        }

        /// <summary>
        /// search customers as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Customer&gt;.</returns>
        public async Task<IPagedList<Customer>> SearchCustomersAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<Customer>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _eCommerceUnitOfWork.CustomerRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<Customer>(where), sortExpression, a => a.LoginUser, a => a.BillingAddress, a => a.ShippingAddress, a => a.CompanyAddress, a => a.PrefferedCurrency, a => a.PrefferedShippingOption);
        }

        /// <summary>
        /// Gets the customer by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Customer.</returns>
        public Customer GetCustomerById(int id)
        {
            var customer = _eCommerceUnitOfWork.CustomerRepository.GetSingle(a => a.Id == id, a => a.LoginUser, a => a.BillingAddress, a => a.ShippingAddress, a => a.CompanyAddress, a => a.CustomerPayments, a => a.PrefferedCurrency, a => a.PrefferedShippingOption);
            if (customer != null && customer.Id > 0)
            {
                customer.Attachments = _eCommerceUnitOfWork.AttachmentRepository.GetList(a => a.Object == "Customer" && a.ObjectId == customer.Id);
            }
            return customer;
        }

        /// <summary>
        /// get customer by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Customer.</returns>
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var customer = await _eCommerceUnitOfWork.CustomerRepository.GetSingleAsync(a => a.Id == id, a => a.LoginUser, a => a.BillingAddress, a => a.ShippingAddress, a => a.CompanyAddress, a => a.CustomerPayments, a => a.PrefferedCurrency, a => a.PrefferedShippingOption);
            if (customer != null && customer.Id > 0)
            {
                customer.Attachments = await _eCommerceUnitOfWork.AttachmentRepository.GetListAsync(a => a.Object == "Customer" && a.ObjectId == customer.Id);
            }
            return customer;
        }

        /// <summary>
        /// Gets the customer by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Customer.</returns>
        public Customer GetCustomerByName(string name)
        {
            var customer = _eCommerceUnitOfWork.CustomerRepository.GetSingle(a => a.Name == name, a => a.LoginUser, a => a.BillingAddress, a => a.ShippingAddress, a => a.CompanyAddress, a => a.CustomerPayments, a => a.PrefferedCurrency, a => a.PrefferedShippingOption);
            if (customer != null && customer.Id > 0)
            {
                customer.Attachments = _eCommerceUnitOfWork.AttachmentRepository.GetList(a => a.Object == "Customer" && a.ObjectId == customer.Id);
            }
            return customer;
        }

        /// <summary>
        /// Gets the customer by name asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Task&lt;Customer&gt;.</returns>
        public async Task<Customer> GetCustomerByNameAsync(string name)
        {
            var customer = await _eCommerceUnitOfWork.CustomerRepository.GetSingleAsync(a => a.Name == name, a => a.LoginUser, a => a.BillingAddress, a => a.ShippingAddress, a => a.CompanyAddress, a => a.CustomerPayments, a => a.PrefferedCurrency, a => a.PrefferedShippingOption);
            if (customer != null && customer.Id > 0)
            {
                customer.Attachments = await _eCommerceUnitOfWork.AttachmentRepository.GetListAsync(a => a.Object == "Customer" && a.ObjectId == customer.Id);
            }
            return customer;
        }

        /// <summary>
        /// Gets the customer by user identifier.
        /// </summary>
        /// <param name="orgUserId">The org user identifier.</param>
        /// <returns>Customer.</returns>
        public Customer GetCustomerByUserId(int orgUserId)
        {
            return _eCommerceUnitOfWork.CustomerRepository.GetSingle(a => a.LoginUserId == orgUserId, a => a.LoginUser, a => a.BillingAddress, a => a.ShippingAddress, a => a.CompanyAddress, a => a.CustomerPayments, a => a.PrefferedCurrency, a => a.PrefferedShippingOption);
        }

        /// <summary>
        /// get customer by user identifier as an asynchronous operation.
        /// </summary>
        /// <param name="orgUserId">The org user identifier.</param>
        /// <returns>Customer.</returns>
        public async Task<Customer> GetCustomerByUserIdAsync(int orgUserId)
        {
            return await _eCommerceUnitOfWork.CustomerRepository.GetSingleAsync(a => a.LoginUserId == orgUserId, a => a.LoginUser, a => a.BillingAddress, a => a.ShippingAddress, a => a.CompanyAddress, a => a.CustomerPayments, a => a.PrefferedCurrency, a => a.PrefferedShippingOption);
        }

        /// <summary>
        /// Adds the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public void AddCustomer(Customer customer)
        {
            if (customer.CustomerPayments != null)
            {
                customer.CustomerPayments = customer.CustomerPayments.Select(c => { c.EntityState = BAPEntityState.Added; return c; }).ToList();
                foreach (var payment in customer.CustomerPayments)
                {
                    _eCommerceUnitOfWork.CustomerPaymentRepository.Add(payment);
                }
            }

            _eCommerceUnitOfWork.CustomerRepository.Add(customer);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// add customer as an asynchronous operation.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public async Task AddCustomerAsync(Customer customer)
        {
            if (customer.CustomerPayments != null)
            {
                customer.CustomerPayments = customer.CustomerPayments.Select(c => { c.EntityState = BAPEntityState.Added; return c; }).ToList();
                foreach (var payment in customer.CustomerPayments)
                {
                    _eCommerceUnitOfWork.CustomerPaymentRepository.Add(payment);
                }
            }

            _eCommerceUnitOfWork.CustomerRepository.Add(customer);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public void UpdateCustomer(Customer customer)
        {
            if (customer.CustomerPayments != null)
            {
                foreach (var payment in customer.CustomerPayments)
                {
                    if (payment.Id > 0)
                    {
                        if (payment.EntityState != BAPEntityState.Modified)
                        {
                            _eCommerceUnitOfWork.CustomerPaymentRepository.Update(payment);
                        }
                    }
                    else
                    {
                        _eCommerceUnitOfWork.CustomerPaymentRepository.Add(payment);
                    }
                }
            }

            if(customer.BillingAddress != null)
            {
                if (customer.BillingAddress.Id > 0)
                {
                    if (customer.BillingAddress.EntityState != BAPEntityState.Modified)
                    {
                        _eCommerceUnitOfWork.AddressRepository.Update(customer.BillingAddress);
                    }
                }
                else
                {
                    _eCommerceUnitOfWork.AddressRepository.Add(customer.BillingAddress);
                }
            }
            
            if(customer.ShippingAddress != null)
            {
                if (customer.ShippingAddress.Id > 0)
                {
                    if (customer.ShippingAddress.EntityState != BAPEntityState.Modified)
                    {
                        _eCommerceUnitOfWork.AddressRepository.Update(customer.ShippingAddress);
                    }
                }
                else
                {
                    _eCommerceUnitOfWork.AddressRepository.Add(customer.ShippingAddress);
                }
            }            

            if (customer.CompanyAddress.Id > 0)
            {
                if (customer.CompanyAddress.Id != customer.BillingAddressId)
                {
                    if (customer.CompanyAddress.EntityState != BAPEntityState.Modified)
                    {
                        _eCommerceUnitOfWork.AddressRepository.Update(customer.CompanyAddress);
                    }
                }
                else
                {
                    if (customer.CompanyAddress != null && customer.BillingAddress != null && customer.BillingAddress.Equals(customer.CompanyAddress))
                    {
                        customer.CompanyAddress = null;
                    }
                    else
                    {
                        customer.CompanyAddressId = null;
                        customer.CompanyAddress.Id = 0;
                        _eCommerceUnitOfWork.AddressRepository.Add(customer.CompanyAddress);
                    }
                }
            }
            else
            {
                _eCommerceUnitOfWork.AddressRepository.Add(customer.CompanyAddress);
            }

            _eCommerceUnitOfWork.CustomerRepository.Update(customer);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// update customer as an asynchronous operation.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public async Task UpdateCustomerAsync(Customer customer)
        {
            if (customer.CustomerPayments != null)
            {
                foreach (var payment in customer.CustomerPayments)
                {
                    if (payment.Id > 0)
                    {
                        if (payment.EntityState != BAPEntityState.Modified)
                        {
                            _eCommerceUnitOfWork.CustomerPaymentRepository.Update(payment);
                        }
                    }
                    else
                    {
                        _eCommerceUnitOfWork.CustomerPaymentRepository.Add(payment);
                    }
                }
            }

            if (customer.BillingAddress.Id > 0)
            {
                if (customer.BillingAddress.EntityState != BAPEntityState.Modified)
                {
                    _eCommerceUnitOfWork.AddressRepository.Update(customer.BillingAddress);
                }
            }
            else
            {
                _eCommerceUnitOfWork.AddressRepository.Add(customer.BillingAddress);
            }

            if (customer.ShippingAddress.Id > 0)
            {
                if (customer.ShippingAddress.EntityState != BAPEntityState.Modified)
                {
                    _eCommerceUnitOfWork.AddressRepository.Update(customer.ShippingAddress);
                }
            }
            else
            {
                _eCommerceUnitOfWork.AddressRepository.Add(customer.ShippingAddress);
            }

            if (customer.CompanyAddress.Id > 0)
            {
                if (customer.CompanyAddress.Id != customer.BillingAddressId)
                {
                    if (customer.CompanyAddress.EntityState != BAPEntityState.Modified)
                    {
                        _eCommerceUnitOfWork.AddressRepository.Update(customer.CompanyAddress);
                    }
                }
                else
                {
                    if (customer.CompanyAddress != null && customer.BillingAddress != null && customer.BillingAddress.Equals(customer.CompanyAddress))
                    {
                        customer.CompanyAddress = null;
                    }
                    else
                    {
                        customer.CompanyAddressId = null;
                        customer.CompanyAddress.Id = 0;
                        _eCommerceUnitOfWork.AddressRepository.Add(customer.CompanyAddress);
                    }
                }
            }
            else
            {
                _eCommerceUnitOfWork.AddressRepository.Add(customer.CompanyAddress);
            }

            _eCommerceUnitOfWork.CustomerRepository.Update(customer);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the customer.
        /// </summary>
        /// <param name="customers">The customers.</param>
        public void RemoveCustomer(params Customer[] customers)
        {
            foreach (var customer in customers)
            {
                if (customer.CompanyAddress != null && customer.CompanyAddress.Id > 0 && customer.CompanyAddress.Id == customer.BillingAddressId)
                {
                    customer.CompanyAddress = null;
                }
            }
            _eCommerceUnitOfWork.CustomerRepository.Remove(customers);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// remove customer as an asynchronous operation.
        /// </summary>
        /// <param name="customers">The customers.</param>
        public async Task RemoveCustomerAsync(params Customer[] customers)
        {
            foreach (var customer in customers)
            {
                if (customer.CompanyAddress != null && customer.CompanyAddress.Id > 0 && customer.CompanyAddress.Id == customer.BillingAddressId)
                {
                    customer.CompanyAddress = null;
                }
            }
            _eCommerceUnitOfWork.CustomerRepository.Remove(customers);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        public string GenerateCustomerName(ShoppingCart cart)
        {
            string customerName = string.Empty;
            if (cart.User != null)
            {
                customerName = cart.User.FullName.AsNullIfEmpty() ?? $"{cart.User.FirstName} {cart.User.MiddleName} {cart.User.LastName} {cart.User.Email}";
            }
            else
            {
                customerName = $"{cart.BillingAddress.FirstName} {cart.BillingAddress.MiddleName} {cart.BillingAddress.LastName} {cart.BillingAddress.ContactEmail}";
            }
            return customerName;
        }

        private Customer InitCustomerObjectFromCart(ShoppingCart cart)
        {
            string customerName = GenerateCustomerName(cart);
            string firstName, lastName, middleName, cellNumber, email, phoneNumber;
            if (cart.User != null)
            {
                firstName = cart.User.FirstName;
                lastName = cart.User.LastName;
                middleName = cart.User.MiddleName;
                cellNumber = cart.User.CellNumber;
                email = cart.User.Email;
                phoneNumber = cart.User.PhoneNumber;
            }
            else
            {
                firstName = cart.BillingAddress.FirstName;
                lastName = cart.BillingAddress.LastName;
                middleName = cart.BillingAddress.MiddleName;
                cellNumber = cart.BillingAddress.CellNumber;
                email = cart.BillingAddress.ContactEmail;
                phoneNumber = cart.BillingAddress.PhoneNumber;
            }

            var customer = new Customer
            {
                BillingAddress = new Address(cart.BillingAddress),
                CompanyAddress = new Address(cart.BillingAddress),
                ShippingAddress = new Address(cart.ShippingAddress),
                CellNumber = cellNumber,                
                CompanyName = customerName + " Customer",
                Email = (email.AsNullIfEmpty() ?? cart.BillingAddress.ContactEmail).AsNullIfEmpty() ?? _authContext.GetCurrentUserName(),
                FirstName = firstName,
                LastName = lastName,
                LoginUserId = cart.UserId,
                MiddleName = middleName,
                Name = customerName,
                PhoneNumber = phoneNumber,                
                PrefferedCurrencyId = cart.CurrencyId,
                PrefferedShippingOptionId = cart.ShippingOptionId,
                EntityState = BAPEntityState.Added
            };
            _eCommerceUnitOfWork.AddressRepository.Add(customer.BillingAddress);
            _eCommerceUnitOfWork.AddressRepository.Add(customer.CompanyAddress);
            _eCommerceUnitOfWork.AddressRepository.Add(customer.ShippingAddress);
            
            return customer;
        }

        /// <summary>
        /// Creates the customer from shopping cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>Customer.</returns>
        public Customer CreateCustomerFromShoppingCart(ShoppingCart cart)
        {

            var customer = InitCustomerObjectFromCart(cart);
            _eCommerceUnitOfWork.CustomerRepository.InitEntityData(customer);

            AddPaymentToCustomer(cart.PaymentOption, customer);

            _eCommerceUnitOfWork.Save();
            return customer;
        }

        /// <summary>
        /// create customer from shopping cart as an asynchronous operation.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>Customer.</returns>
        public async Task<Customer> CreateCustomerFromShoppingCartAsync(ShoppingCart cart)
        {
            var customer = InitCustomerObjectFromCart(cart);
            _eCommerceUnitOfWork.CustomerRepository.InitEntityData(customer);

            AddPaymentToCustomer(cart.PaymentOption, customer);

            await _eCommerceUnitOfWork.SaveAsync();
            return customer;
        }

        /// <summary>
        /// Updates the customer payment from shopping cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="customer">The customer.</param>
        public void UpdateCustomerPaymentFromShoppingCart(ShoppingCart cart, Customer customer)
        {
            if (cart == null || customer == null)
                return;

            if (customer.CustomerPayments.All(a => a.PaymentOptionId != cart.PaymentOptionId))
            {
                AddPaymentToCustomer(cart.PaymentOption, customer);
                customer.EntityState = BAPEntityState.Modified;
            }
            else
            {
                var payment = customer.CustomerPayments.SingleOrDefault(a => a.PaymentOptionId == cart.PaymentOptionId);
                if (payment != null)
                {
                    payment.LastUsed = DateTime.Now;
                    payment.EntityState = BAPEntityState.Modified;
                }
            }
        }

        /// <summary>
        /// Adds the payment to customer.
        /// </summary>
        /// <param name="paymentOption">The payment option.</param>
        /// <param name="customer">The customer.</param>
        private void AddPaymentToCustomer(PaymentOption paymentOption, Customer customer)
        {
            if (customer == null || paymentOption == null)
                return;

            var suffix = DateTime.Now.ToString("yyMMddhhmiss");
            if (customer.CustomerPayments == null)
                customer.CustomerPayments = new List<CustomerPayment>();

            var custPayment = new CustomerPayment
            {
                Description = paymentOption.Name + " payment of customer " + customer.Name,
                Name = customer.Name + " " + paymentOption.Name + " " + suffix,
                PaymentOptionId = paymentOption.Id,
                ShortDescription = paymentOption.Name + " payment of customer " + customer.Name,
                LastUsed = DateTime.Now,
                EntityState = BAPEntityState.Added
            };
            _eCommerceUnitOfWork.CustomerPaymentRepository.InitEntityData(custPayment);
            if (customer.Id > 0)
                custPayment.CustomerId = customer.Id;
            else
                custPayment.Customer = customer;

            IPaymentOptionProvider provider = ((IPaymentOptionBL)this).GetPaymentOptionProvider(paymentOption.Id);
            if (provider != null)
            {
                if (provider.SupportRegister())
                {
                    custPayment.AccountReferenceId = provider.RegisterAccount(customer);
                }
            }

            _eCommerceUnitOfWork.CustomerPaymentRepository.Add(custPayment);
            customer.CustomerPayments.Add(custPayment);
            customer.EntityState = customer.Id > 0 ? BAPEntityState.Modified : BAPEntityState.Added;
        }

        /// <summary>
        /// Removes the customer payment.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <param name="customerPayment">The customer payment.</param>
        public void RemoveCustomerPayment(Customer customer, CustomerPayment customerPayment)
        {
            if (customer == null || customerPayment == null)
                return;

            if (customer.CustomerPayments != null && customer.CustomerPayments.Any(a => a.Id == customerPayment.Id))
            {
                var thisCustomer = _eCommerceUnitOfWork.CustomerRepository.GetSingle(a => a.Id == customer.Id, a => a.CustomerPayments);
                var itemToRemove = thisCustomer.CustomerPayments.SingleOrDefault(a => a.Id == customerPayment.Id);
                if (itemToRemove != null)
                {
                    itemToRemove.EntityState = BAPEntityState.Deleted;
                    thisCustomer.CustomerPayments.Remove(itemToRemove);
                    thisCustomer.EntityState = BAPEntityState.Modified;
                    _eCommerceUnitOfWork.CustomerPaymentRepository.Remove(itemToRemove);
                    _eCommerceUnitOfWork.Save();
                }
            }
        }

        /// <summary>
        /// remove customer payment as an asynchronous operation.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <param name="customerPayment">The customer payment.</param>
        public async Task RemoveCustomerPaymentAsync(Customer customer, CustomerPayment customerPayment)
        {
            if (customer == null || customerPayment == null)
                return;

            if (customer.CustomerPayments != null && customer.CustomerPayments.Any(a => a.Id == customerPayment.Id))
            {
                var thisCustomer = await _eCommerceUnitOfWork.CustomerRepository.GetSingleAsync(a => a.Id == customer.Id, a => a.CustomerPayments);
                var itemToRemove = thisCustomer.CustomerPayments.SingleOrDefault(a => a.Id == customerPayment.Id);
                if (itemToRemove != null)
                {
                    itemToRemove.EntityState = BAPEntityState.Deleted;
                    thisCustomer.CustomerPayments.Remove(itemToRemove);
                    thisCustomer.EntityState = BAPEntityState.Modified;
                    _eCommerceUnitOfWork.CustomerPaymentRepository.Remove(itemToRemove);
                    await _eCommerceUnitOfWork.SaveAsync();
                }
            }
        }

        /// <summary>
        /// Initializes the subordinate entities.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public void InitSubordinateEntities(Customer customer)
        {
            if (customer.BillingAddress == null)
            {
                customer.BillingAddress = new Address();
                _eCommerceUnitOfWork.AddressRepository.InitEntityData(customer.BillingAddress);
            }
            if (customer.ShippingAddress == null)
            {
                customer.ShippingAddress = new Address();
                _eCommerceUnitOfWork.AddressRepository.InitEntityData(customer.ShippingAddress);
            }
            if (customer.CompanyAddress == null)
            {
                customer.CompanyAddress = new Address();
                _eCommerceUnitOfWork.AddressRepository.InitEntityData(customer.CompanyAddress);
            }
        }
        #endregion

        #region Workflows support
        public List<WorkflowClass> GetAvailableFlows(Customer entity)
        {
            var implementer = new SupportWorkflowImplementer<Customer>(_logger, _configHelper, _authContext, _lookupEngine, _fileProcessor, this);
            return implementer.GetAvailableFlows(entity);
        }
        
        public void RemoveCurrentWorkflow(Customer entity)
        {
            var implementer = new SupportWorkflowImplementer<Customer>(_logger, _configHelper, _authContext, _lookupEngine, _fileProcessor, this);
            implementer.RemoveCurrentWorkflow(entity);
        }

        public Workflow<Customer> ChooseWorkflow(Customer entity, int workflowId)
        {
            var implementer = new SupportWorkflowImplementer<Customer>(_logger, _configHelper, _authContext, _lookupEngine, _fileProcessor, this);
            return implementer.ChooseWorkflow(entity, workflowId);
        }

        public Workflow<Customer> GetCurrentWorkflow(Customer entity, int? metaId = null, int? attachmentId = null)
        {
            var implementer = new SupportWorkflowImplementer<Customer>(_logger, _configHelper, _authContext, _lookupEngine, _fileProcessor, this);
            return implementer.GetCurrentWorkflow(entity, metaId, attachmentId);
        }

        public bool ChooseTransition(Workflow<Customer> workflow, int metaTranstionId, string comment)
        {
            var implementer = new SupportWorkflowImplementer<Customer>(_logger, _configHelper, _authContext, _lookupEngine, _fileProcessor, this);
            return implementer.ChooseTransition(workflow, metaTranstionId, comment);
        }

        public string DoAction(Workflow<Customer> workflow, int metaActionId, string attributesJson)
        {
            var implementer = new SupportWorkflowImplementer<Customer>(_logger, _configHelper, _authContext, _lookupEngine, _fileProcessor, this);
            return implementer.DoAction(workflow, metaActionId, attributesJson);
        }

        public void SaveWorkflow(Workflow<Customer> workflow)
        {
            var implementer = new SupportWorkflowImplementer<Customer>(_logger, _configHelper, _authContext, _lookupEngine, _fileProcessor, this);
            implementer.SaveWorkflow(workflow);
        }

        #endregion
    }
}
