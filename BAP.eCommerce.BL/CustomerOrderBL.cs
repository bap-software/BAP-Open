// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 07-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-24-2020
// ***********************************************************************
// <copyright file="CustomerOrderBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList;

using BAP.Common;
using BAP.eCommerce.DAL.Entities;
using BAP.Workflow;
using BAP.BL;
using BAP.DAL.Entities;
using BAP.eCommerce.Resources;
using BAP.Email;
using SelectPdf;
using Newtonsoft.Json.Linq;
using BAP.DAL;
using Newtonsoft.Json;

namespace BAP.eCommerce.BL
{
    /// <summary>
    /// Class represents an external data (from Suppliers for example) such as External Order ID or External Recipient ID.
    /// Data can be used to track external order.
    /// </summary>
    public class ExternalOrderData
    {
        public int ExternalOrderId { get; set; }
        public int ExternalRecipientId { get; set; }
        public int ExternalAddressId { get; set; }
    }
    
    /// <summary>
    /// Interface ICustomerOrderWorkflow
    /// Implements the <see cref="BAP.Workflow.ISupportWorkflow{BAP.eCommerce.DAL.Entities.CustomerOrder}" />
    /// </summary>
    /// <seealso cref="BAP.Workflow.ISupportWorkflow{BAP.eCommerce.DAL.Entities.CustomerOrder}" />
    public interface ICustomerOrderWorkflow : ISupportWorkflow<CustomerOrder>
    {
    }

    /// <summary>
    /// Interface ICustomerOrderBL
    /// </summary>
    public interface ICustomerOrderBL
    {
        /// <summary>
        /// Gets all customer orders.
        /// </summary>
        /// <returns>IList&lt;CustomerOrder&gt;.</returns>
        IList<CustomerOrder> GetAllCustomerOrders();
        /// <summary>
        /// Gets all customer orders asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;CustomerOrder&gt;&gt;.</returns>
        Task<IList<CustomerOrder>> GetAllCustomerOrdersAsync();

        /// <summary>
        /// Searches the customer orders.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;CustomerOrder&gt;.</returns>
        IPagedList<CustomerOrder> SearchCustomerOrders(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the customer orders asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;CustomerOrder&gt;&gt;.</returns>
        Task<IPagedList<CustomerOrder>> SearchCustomerOrdersAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the customer order by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CustomerOrder.</returns>
        CustomerOrder GetCustomerOrderById(int id);
        /// <summary>
        /// Gets the customer order by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;CustomerOrder&gt;.</returns>
        Task<CustomerOrder> GetCustomerOrderByIdAsync(int id);

        /// <summary>
        /// Gets the single customer order by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CustomerOrder.</returns>
        CustomerOrder GetSingleCustomerOrderById(int id);
        /// <summary>
        /// Gets the single customer order by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;CustomerOrder&gt;.</returns>
        Task<CustomerOrder> GetSingleCustomerOrderByIdAsync(int id);

        /// <summary>
        /// Adds the customer order.
        /// </summary>
        /// <param name="customerOrder">The customer order.</param>
        void AddCustomerOrder(CustomerOrder customerOrder);
        /// <summary>
        /// Adds the customer order asynchronous.
        /// </summary>
        /// <param name="customerOrder">The customer order.</param>
        /// <returns>Task.</returns>
        Task AddCustomerOrderAsync(CustomerOrder customerOrder);

        /// <summary>
        /// Creates the order from shopping cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>CustomerOrder.</returns>
        CustomerOrder CreateOrderFromShoppingCart(ShoppingCart cart);
        /// <summary>
        /// Creates the order from shopping cart asynchronous.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>Task&lt;CustomerOrder&gt;.</returns>
        Task<CustomerOrder> CreateOrderFromShoppingCartAsync(ShoppingCart cart);

        /// <summary>
        /// Applies the payment on order.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool ApplyPaymentOnOrder(int orderId);

        /// <summary>
        /// Updates the customer order.
        /// </summary>
        /// <param name="customerOrder">The customer order.</param>
        void UpdateCustomerOrder(CustomerOrder customerOrder);
        /// <summary>
        /// Updates the customer order asynchronous.
        /// </summary>
        /// <param name="customerOrder">The customer order.</param>
        /// <returns>Task.</returns>
        Task UpdateCustomerOrderAsync(CustomerOrder customerOrder);

        /// <summary>
        /// Removes the customer order.
        /// </summary>
        /// <param name="customerOrders">The customer orders.</param>
        void RemoveCustomerOrder(params CustomerOrder[] customerOrders);
        /// <summary>
        /// Removes the customer order asynchronous.
        /// </summary>
        /// <param name="customerOrders">The customer orders.</param>
        /// <returns>Task.</returns>
        Task RemoveCustomerOrderAsync(params CustomerOrder[] customerOrders);

        /// <summary>
        /// Gets the invoice HTML.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>System.String.</returns>
        string GetInvoiceHtml(int orderId);
        /// <summary>
        /// Gets the invoice HTML asynchronous.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetInvoiceHtmlAsync(int orderId);

        /// <summary>
        /// Generates the invoice PDF.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        void GenerateInvoicePdf(int orderId);
        /// <summary>
        /// Generates the invoice PDF asynchronous.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>Task.</returns>
        Task GenerateInvoicePdfAsync(int orderId);

        /// <summary>
        /// Sends the order invoice to customer asynchronous.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>Task&lt;Message&gt;.</returns>
        Task<Message> SendOrderInvoiceToCustomerAsync(int orderId);

        /// <summary>
        /// Prepares the software products.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        void PrepareSoftwareProducts(int orderId);
        /// <summary>
        /// Prepares the software products asynchronous.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>Task.</returns>
        Task PrepareSoftwareProductsAsync(int orderId);

        /// <summary>
        /// Softwares the products paid.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        void SoftwareProductsPaid(int orderId);
        /// <summary>
        /// Softwares the products paid asynchronous.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>Task.</returns>
        Task SoftwareProductsPaidAsync(int orderId);
        
        /// <summary>
        /// Sets the shopping cart custom data.
        /// </summary>
        /// <param name="customerOrder">The cart.</param>
        /// <param name="data">The data.</param>
        void SetShoppingCartCustomData(CustomerOrder customerOrder, ShoppingCartCustomData data);

        /// <summary>
        /// Gets the shopping cart custom data.
        /// </summary>
        /// <param name="customerOrder">The cart.</param>
        /// <returns></returns>
        ShoppingCartCustomData GetShoppingCartCustomData(CustomerOrder customerOrder);
        
        /// <summary>
        /// Sets the shopping cart custom data.
        /// </summary>
        /// <param name="customerOrder">The cart.</param>
        /// <param name="data">The data.</param>
        void SetExternalOrderDataCustomData(CustomerOrder customerOrder, ExternalOrderData data);

        /// <summary>
        /// Gets the shopping cart custom data.
        /// </summary>
        /// <param name="customerOrder">The cart.</param>
        /// <returns></returns>
        ExternalOrderData GetExternalOrderDataCustomData(CustomerOrder customerOrder);
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
    public partial class eCommerceBusinessLayer : ICustomerOrderBL, ICustomerOrderWorkflow
    {

        #region CustomerOrders

        /// <summary>
        /// Gets all customer orders.
        /// </summary>
        /// <returns>IList&lt;CustomerOrder&gt;.</returns>
        public IList<CustomerOrder> GetAllCustomerOrders()
        {
            return _eCommerceUnitOfWork.CustomerOrderRepository.GetAll();
        }

        /// <summary>
        /// get all customer orders as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;CustomerOrder&gt;.</returns>
        public async Task<IList<CustomerOrder>> GetAllCustomerOrdersAsync()
        {
            return await _eCommerceUnitOfWork.CustomerOrderRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the customer orders.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;CustomerOrder&gt;.</returns>
        public IPagedList<CustomerOrder> SearchCustomerOrders(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<CustomerOrder>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            var result = _eCommerceUnitOfWork.CustomerOrderRepository.GetPagedList(page, pageSize, ParseJSONSearchString<CustomerOrder>(where), sortExpression, a => a.Items, a => a.User, a => a.Customer, a => a.CustomerPayment, a => a.Currency, a => a.ShippingOption, a => a.PaymentOption, a => a.DiscountCoupon, a => a.BillingAddress, a => a.ShippingAddress);
            foreach(var order in result)
            {
                order.Payments = ((ICustomerOrderPaymentBL)this).GetCustomerOrderPaymentsByOrderId(order.Id).ToList();
            }
            return result;
        }

        /// <summary>
        /// search customer orders as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;CustomerOrder&gt;.</returns>
        public async Task<IPagedList<CustomerOrder>> SearchCustomerOrdersAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<CustomerOrder>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            var result = await _eCommerceUnitOfWork.CustomerOrderRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<CustomerOrder>(where), sortExpression, a => a.Items, a => a.User, a => a.Customer, a => a.CustomerPayment, a => a.Currency, a => a.ShippingOption, a => a.PaymentOption, a => a.DiscountCoupon, a => a.BillingAddress, a => a.ShippingAddress);

            foreach (var order in result)
            {
                order.Payments = (await ((ICustomerOrderPaymentBL)this).GetCustomerOrderPaymentsByOrderIdAsync(order.Id)).ToList();
            }

            return result;
        }

        /// <summary>
        /// Gets the customer order by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CustomerOrder.</returns>
        public CustomerOrder GetCustomerOrderById(int id)
        {
            var order = _eCommerceUnitOfWork.CustomerOrderRepository.GetSingle(a => a.Id == id, a => a.Items, a => a.User, a => a.Customer, a => a.CustomerPayment, a => a.Currency, a => a.ShippingOption, a => a.ShippingOption.ShippingCarrier, a => a.PaymentOption, a => a.DiscountCoupon, a => a.BillingAddress, a => a.ShippingAddress, a => a.Items.Select(b => b.Product), a => a.Items.Select(b => b.Product.Supplier), a => a.Items.Select(b => b.Product.ProductSupplierData));
            if (order != null)
            {
                order.Payments = ((ICustomerOrderPaymentBL)this).GetCustomerOrderPaymentsByOrderId(order.Id).ToList();
                order.Attachments = _eCommerceUnitOfWork.AttachmentRepository.GetList(a => a.Object == "CustomerOrder" && a.ObjectId == order.Id);
            }
            return order;
        }

        /// <summary>
        /// get customer order by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CustomerOrder.</returns>
        public async Task<CustomerOrder> GetCustomerOrderByIdAsync(int id)
        {
            var order = await _eCommerceUnitOfWork.CustomerOrderRepository.GetSingleAsync(a => a.Id == id, a => a.Items, a => a.User, a => a.Customer, a => a.CustomerPayment, a => a.Currency, a => a.ShippingOption, a => a.ShippingOption.ShippingCarrier, a => a.PaymentOption, a => a.DiscountCoupon, a => a.BillingAddress, a => a.ShippingAddress, a => a.Items.Select(b => b.Product), a => a.Items.Select(b => b.Product.Supplier), a => a.Items.Select(b => b.Product.ProductSupplierData));
            if (order != null)
            {
                order.Payments = (await ((ICustomerOrderPaymentBL)this).GetCustomerOrderPaymentsByOrderIdAsync(order.Id)).ToList();
                order.Attachments = await _eCommerceUnitOfWork.AttachmentRepository.GetListAsync(a => a.Object == "CustomerOrder" && a.ObjectId == order.Id);
            }
            return order;
        }
        
        /// <summary>
        /// Sets the shopping cart custom data to Customer Order.
        /// </summary>
        /// <param name="customerOrder">The cart.</param>
        /// <param name="data">The data.</param>
        public void SetShoppingCartCustomData(CustomerOrder customerOrder, ShoppingCartCustomData data)
        {
            if (customerOrder == null || data == null)
                return;
            
            // Keep current data to be able to merge them
            var currentCustomData = JsonConvert.DeserializeObject<Dictionary<string, object>>(customerOrder.CustomData);
            var newCustomData = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));

            // Merge data
            var newData = MergeDictionaries(newCustomData, currentCustomData);
            
            customerOrder.CustomData = JsonConvert.SerializeObject(newData);
        }

        /// <summary>
        /// Gets the shopping cart custom data from Customer Order.
        /// </summary>
        /// <param name="customerOrder">The cart.</param>
        /// <returns></returns>
        public ShoppingCartCustomData GetShoppingCartCustomData(CustomerOrder customerOrder)
        {
            if (customerOrder == null || string.IsNullOrEmpty(customerOrder.CustomData))
                return null;

            return JsonConvert.DeserializeObject<ShoppingCartCustomData>(customerOrder.CustomData);
        }
        
        /// <summary>
        /// Sets the shopping cart custom data to Customer Order.
        /// </summary>
        /// <param name="customerOrder">The cart.</param>
        /// <param name="data">The data.</param>
        public void SetExternalOrderDataCustomData(CustomerOrder customerOrder, ExternalOrderData data)
        {
            if (customerOrder == null || data == null)
                return;

            // Keep current data to be able to merge them
            var currentCustomData = JsonConvert.DeserializeObject<Dictionary<string, object>>(customerOrder.CustomData);
            var newCustomData = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));

            // Merge data
            var newData = MergeDictionaries(newCustomData, currentCustomData);
            
            customerOrder.CustomData = JsonConvert.SerializeObject(newData);
        }

        /// <summary>
        /// Gets the shopping cart custom data from Customer Order.
        /// </summary>
        /// <param name="customerOrder">The cart.</param>
        /// <returns></returns>
        public ExternalOrderData GetExternalOrderDataCustomData(CustomerOrder customerOrder)
        {
            if (customerOrder == null || string.IsNullOrEmpty(customerOrder.CustomData))
                return null;

            return JsonConvert.DeserializeObject<ExternalOrderData>(customerOrder.CustomData);
        }

        /// <summary>
        /// Gets the single customer order by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CustomerOrder.</returns>
        public CustomerOrder GetSingleCustomerOrderById(int id)
        {
            return _eCommerceUnitOfWork.CustomerOrderRepository.GetSingle(a => a.Id == id, a => a.Items, a => a.Customer);
        }

        /// <summary>
        /// get single customer order by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CustomerOrder.</returns>
        public async Task<CustomerOrder> GetSingleCustomerOrderByIdAsync(int id)
        {
            return await _eCommerceUnitOfWork.CustomerOrderRepository.GetSingleAsync(a => a.Id == id, a => a.Items, a => a.Customer);
        }

        /// <summary>
        /// Creates the order from shopping cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>CustomerOrder.</returns>
        public CustomerOrder CreateOrderFromShoppingCart(ShoppingCart cart)
        {
            if (cart == null)
                return null;

            var userFullName = cart.User != null ? !string.IsNullOrWhiteSpace(cart.User.FullName) ? cart.User.FullName :
                cart.User.FirstName + " " + cart.User.LastName : cart.BillingAddress.FirstName + " " + cart.BillingAddress.LastName;
            var uniqueSuffix = Guid.NewGuid().ToString();
            // init main order object
            var order = new CustomerOrder
            {
                BillingAddress = new Address(cart.BillingAddress),
                ShippingAddress = new Address(cart.ShippingAddress),
                Coupon = cart.Coupon,
                CurrencyId = cart.CurrencyId,
                CustomData = cart.CustomData,
                Description = "Customer order of " + userFullName + " with notes: " + cart.Notes,
                DiscountCouponId = cart.DiscountCouponId,
                DiscountsTotal = cart.TotalDiscounts ?? 0,
                Notes = cart.Notes,
                PaymentOptionId = cart.PaymentOptionId,                
                ShippingCost = cart.ShippingCost ?? 0,
                ShippingOptionId = cart.ShippingOptionId,
                Subtotal = cart.Subtotal ?? 0,
                TaxTotal = cart.TaxTotal ?? 0,
                Total = cart.Total ?? 0,
                UserId = cart.UserId,
                User = cart.User,
                Name = "Customer order of " + userFullName + uniqueSuffix,
                ShortDescription = "Customer order of " + userFullName,
                EntityState = BAPEntityState.Added,
                Items = new List<OrderItem>()
            };
            _eCommerceUnitOfWork.AddressRepository.Add(order.BillingAddress);
            _eCommerceUnitOfWork.AddressRepository.Add(order.ShippingAddress);

            //add items
            foreach (var cartItem in cart.ShoppingCartProducts)
            {
                var orderItem = new OrderItem
                {
                    Count = cartItem.Count,
                    CustomData = cartItem.CustomData,
                    CustomerOrder = order,
                    Description = cartItem.Product.Description,
                    DiscountCouponId = cartItem.DiscountCouponId,
                    Name = cartItem.Product.Name + " " + uniqueSuffix,
                    Price = cartItem.Price,
                    ProductId = cartItem.ProductId,
                    Subtotal = cartItem.Subtotal,
                    TotalDiscounts = cartItem.TotalDiscount,
                    OptionsData = cartItem.OptionsData,
                    EntityState = BAPEntityState.Added
                    //TotalTax - to be calculated           
                };

                order.Items.Add(orderItem);
            }

            //creating customer if no any and authenticated
            var customerBL = (ICustomerBL)this;
            if (_authContext.IsAuthenticated && cart.UserId > 0)
            {
                var customer = customerBL.GetCustomerByUserId(cart.UserId.Value);
                if (customer == null)
                {
                    customer = customerBL.CreateCustomerFromShoppingCart(cart);
                    order.Customer = customer;
                    order.CustomerPayment = customer.CurrentPayment;
                }
                else
                {
                    customerBL.UpdateCustomerPaymentFromShoppingCart(cart, customer);
                    order.CustomerId = customer.Id;
                    var customerPayment = customer.CurrentPayment;
                    if (customerPayment != null)
                    {
                        if (customerPayment.Id > 0)
                            order.CustomerPaymentId = customerPayment.Id;
                        else
                            order.CustomerPayment = customerPayment;
                    }
                }
            }
            else
            {
                var customer = customerBL.GetCustomerByName(customerBL.GenerateCustomerName(cart));
                if(customer == null)
                    customer = customerBL.CreateCustomerFromShoppingCart(cart);
                
                order.CustomerId = customer.Id;
                order.CustomerPaymentId = customer.CurrentPayment.Id;
            }            

            // Save order to DB
            AddCustomerOrder(order);

            // Remove shopping cart
            ((IShoppingCartBL)this).RemoveShoppingCart(cart);

            // Return saved order
            return order;
        }

        /// <summary>
        /// create order from shopping cart as an asynchronous operation.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>CustomerOrder.</returns>
        public async Task<CustomerOrder> CreateOrderFromShoppingCartAsync(ShoppingCart cart)
        {
            if (cart == null)
                return null;

            var userFullName = cart.User != null ? !string.IsNullOrWhiteSpace(cart.User.FullName) ? cart.User.FullName :
                cart.User.FirstName + " " + cart.User.LastName : cart.BillingAddress.FirstName + " " + cart.BillingAddress.LastName;
            var uniqueSuffix = Guid.NewGuid().ToString();
            // init main order object
            var order = new CustomerOrder
            {
                BillingAddress = new Address(cart.BillingAddress),
                ShippingAddress = new Address(cart.ShippingAddress),
                Coupon = cart.Coupon,
                CurrencyId = cart.CurrencyId,
                CustomData = cart.CustomData,
                Description = "Customer order of " + userFullName + " with notes: " + cart.Notes,
                DiscountCouponId = cart.DiscountCouponId,
                DiscountsTotal = cart.TotalDiscounts ?? 0,
                Notes = cart.Notes,
                PaymentOptionId = cart.PaymentOptionId,                
                ShippingCost = cart.ShippingCost ?? 0,
                ShippingOptionId = cart.ShippingOptionId ?? 0,
                Subtotal = cart.Subtotal ?? 0,
                TaxTotal = cart.TaxTotal ?? 0,
                Total = cart.Total ?? 0,
                UserId = cart.UserId,
                User = cart.User,
                Name = "Customer order of " + userFullName + uniqueSuffix,
                ShortDescription = "Customer order of " + userFullName,
                EntityState = BAPEntityState.Added,
                Items = new List<OrderItem>()
            };
            _eCommerceUnitOfWork.AddressRepository.Add(order.BillingAddress);
            _eCommerceUnitOfWork.AddressRepository.Add(order.ShippingAddress);

            //add items
            foreach (var cartItem in cart.ShoppingCartProducts)
            {
                var orderItem = new OrderItem
                {
                    Count = cartItem.Count,
                    CustomData = cartItem.CustomData,
                    CustomerOrder = order,
                    Description = cartItem.Product.Description,
                    DiscountCouponId = cartItem.DiscountCouponId,
                    Name = cartItem.Product.Name + " " + uniqueSuffix,
                    Price = cartItem.Price,
                    ProductId = cartItem.ProductId,
                    Subtotal = cartItem.Subtotal,
                    TotalDiscounts = cartItem.TotalDiscount,
                    OptionsData = cartItem.OptionsData,
                    EntityState = BAPEntityState.Added
                    //TotalTax - to be calculated           
                };

                order.Items.Add(orderItem);
            }

            //creating customer if no any and authenticated          
            var customerBL = ((ICustomerBL)this);
            if (_authContext.IsAuthenticated && cart.UserId > 0)
            {
                var customer = await customerBL.GetCustomerByUserIdAsync(cart.UserId.Value);
                if (customer == null)
                {
                    customer = await customerBL.CreateCustomerFromShoppingCartAsync(cart);
                    order.Customer = customer;
                    order.CustomerPayment = customer.CurrentPayment;
                }
                else
                {
                    customerBL.UpdateCustomerPaymentFromShoppingCart(cart, customer);
                    order.CustomerId = customer.Id;
                    var customerPayment = customer.CurrentPayment;
                    if (customerPayment != null)
                    {
                        if (customerPayment.Id > 0)
                            order.CustomerPaymentId = customerPayment.Id;
                        else
                            order.CustomerPayment = customerPayment;
                    }
                }
            }
            else
            {
                var customer = customerBL.GetCustomerByName(customerBL.GenerateCustomerName(cart));
                if (customer == null)
                    customer = await customerBL.CreateCustomerFromShoppingCartAsync(cart);

                order.CustomerId = customer.Id;
                order.CustomerPaymentId = customer.CurrentPayment.Id;
            }

            //remove shopping cart
            await ((IShoppingCartBL)this).RemoveShoppingCartAsync(cart);

            // Save order to DB and return
            await AddCustomerOrderAsync(order);
            return order;
        }

        /// <summary>
        /// Applies the payment on order.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ApplyPaymentOnOrder(int orderId)
        {
            var order = GetCustomerOrderById(orderId);
            if (order == null)
                return false;

            IPaymentOptionProvider provider = GetPaymentOptionProvider(order.PaymentOptionId.Value);
            var info = provider?.PaymentCallBack();
            if (info != null)
            {               
                var orderPayment = new CustomerOrderPayment
                {
                    AttemptNo = 1,
                    CurrencyId = order.CurrencyId,
                    CustomerOrderId = order.Id,
                    CustomerPaymentId = order.CustomerPaymentId,
                    ErrorCode = info.ErrorCode,
                    ErrorDescription = info.ErrorDescription,
                    IsError = info.IsError,
                    Started = (info.StartDateTime == DateTime.MinValue ? DateTime.Now : info.StartDateTime),
                    Finished = (info.ProcessDateTime == DateTime.MinValue ? DateTime.Now : info.ProcessDateTime),
                    PaymentIntent = info.PaymentIntent,
                    PaymentOptionId = order.PaymentOptionId,
                    PaymentStatus = info.PaymentStatus,
                    ReferenceId = info.PaymentId,
                    Total = info.TotalPaid > 0 ? info.TotalPaid : order.Total,
                    PaymentNotes = info.Notes
                };

                AddCustomerOrderPayment(orderPayment);                
            }

            return true;
        }

        /// <summary>
        /// Gets the invoice HTML.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>System.String.</returns>
        public string GetInvoiceHtml(int orderId)
        {
            var invoiceTemplate = string.Empty;
            var defaultStore = GetDefaultStore();
            if (defaultStore != null)
            {
                var template = defaultStore.InvoiceTemplateInstance;
                if (template != null)
                    invoiceTemplate = template.TemplateBodyText;
            }

            var order = GetCustomerOrderById(orderId);
            if (order != null && !string.IsNullOrWhiteSpace(invoiceTemplate))
                invoiceTemplate = CreateInvoiceHtml(invoiceTemplate, order);
            
            return invoiceTemplate;
        }

        /// <summary>
        /// Creates the invoice HTML.
        /// </summary>
        /// <param name="invoiceTemplate">The invoice template.</param>
        /// <param name="order">The order.</param>
        /// <returns>System.String.</returns>
        private string CreateInvoiceHtml(string invoiceTemplate, CustomerOrder order)
        {
            if (!string.IsNullOrWhiteSpace(invoiceTemplate) && order != null)
            {
                var sb = new StringBuilder();
                var currency = order.Currency;
                foreach (var item in order.Items)
                {
                    sb.Append("<tr>");
                    sb.AppendFormat("<td>{0}</td>", item.Product.Name);
                    sb.AppendFormat("<td>{0}</td>", string.Format(currency.FormatString, item.Price));
                    sb.AppendFormat("<td>{0}</td>", item.Count);
                    sb.AppendFormat("<td>{0}</td>", string.Format(currency.FormatString, item.Subtotal));
                    sb.Append("</tr>");
                }

                invoiceTemplate = invoiceTemplate.Replace("{ROWS}", sb.ToString());
                invoiceTemplate = invoiceTemplate.Replace("{Total}", string.Format(currency.FormatString, order.Total));
                invoiceTemplate = TransformTemplate(invoiceTemplate, order, true);                                
            }
            return invoiceTemplate;
        }

        /// <summary>
        /// get invoice HTML as an asynchronous operation.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>System.String.</returns>
        public async Task<string> GetInvoiceHtmlAsync(int orderId)
        {
            var invoiceTemplate = string.Empty;
            var defaultStore = await GetDefaultStoreAsync();
            if (defaultStore != null)
            {
                var template = defaultStore.InvoiceTemplateInstance;
                if (template != null)
                    invoiceTemplate = template.TemplateBodyText;
            }

            var order = await GetCustomerOrderByIdAsync(orderId);
            if (order != null && !string.IsNullOrWhiteSpace(invoiceTemplate))
                invoiceTemplate = CreateInvoiceHtml(invoiceTemplate, order);            

            return invoiceTemplate;
        }

        /// <summary>
        /// Generates the invoice PDF.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        public void GenerateInvoicePdf(int orderId)
        {
            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument doc = converter.ConvertHtmlString(GetInvoiceHtml(orderId));
            _fileProcessor.CreateFolder("Public", "Invoices");
            doc.Save(Path.Combine(_fileProcessor.BaseFolder, "Public/Invoices", $"invoice{orderId}.pdf"));
            doc.Close();
        }

        /// <summary>
        /// generate invoice PDF as an asynchronous operation.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        public async Task GenerateInvoicePdfAsync(int orderId)
        {
            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument doc = converter.ConvertHtmlString(await GetInvoiceHtmlAsync(orderId));
            _fileProcessor.CreateFolder("Public", "Invoices");
            doc.Save(Path.Combine(_fileProcessor.BaseFolder, "Public/Invoices", $"invoice{orderId}.pdf"));
            doc.Close();
        }

        /// <summary>
        /// send order invoice to customer as an asynchronous operation.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>Message.</returns>
        /// <exception cref="NullReferenceException">Mailer cannot be null, it has to be properly configured</exception>
        public async Task<Message> SendOrderInvoiceToCustomerAsync(int orderId)
        {
            var customerOrder = await GetSingleCustomerOrderByIdAsync(orderId);
            var mailer = DependencyResolver.Current.GetService<IMailer>();
            if (mailer == null)
                throw new NullReferenceException("Mailer cannot be null, it has to be properly configured");
            var subject = ResObject.FieldLabel_YourInvoice;
            var body = await GetInvoiceHtmlAsync(orderId);
            await mailer.SendEmailAsync(mailer.DefaultFromAddress, customerOrder.Customer.Email, subject, body);
            var msg = new Message
            {
                FromAddress = mailer.DefaultFromAddress,
                ToAddress = customerOrder.Customer.Email,
                Subject = subject,
                Body = body,
                Object = "CustomerOrder",
                ObjectId = orderId,
                Sent = true,
                SentDate = DateTime.Now
            };
            await AddMessageAsync(msg);

            return msg;
        }

        /// <summary>
        /// Prepares the software products.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        public void PrepareSoftwareProducts(int orderId)
        {            
            var customerOrder = GetCustomerOrderById(orderId);
            if (customerOrder == null)
                return;

            var isAnyUpdate = false;
            var authHelper = new AuthorizationHelper<CustomerOrder>(_configHelper, _authContext);
            var isPaidOrder = customerOrder.Payments.Any();
            //If any downlodable
            if (customerOrder.Items.Any(a => a.Product.IsDownloadable))
            {
                foreach(var item in customerOrder.Items.Where(a => a.Product.IsDownloadable))
                {
                    var product = GetProductById(item.ProductId.GetValueOrDefault());
                    if(product != null && product.Attachments  != null && product.Attachments.Count(a => a.AttachmentTypeClassified == AttachmentType.Installation) == 1)
                    {
                        var productAttachment = product.Attachments.SingleOrDefault(a => a.AttachmentTypeClassified == AttachmentType.Installation);
                        MakeAttachmentSecured(productAttachment.Id, authHelper.BapAdminRoleName, authHelper.BapContentManagerRoleName, "Supervisor");
                        //Secure URL is only provided when order is paid, otherwise this URL will be set by the workflow action accepting payment
                        if(isPaidOrder)
                        {
                            item.DownloadUrl = ProvisionSecuredAttachment(productAttachment.Id, 10080/*one week*/);
                            ((IOrderItemBL)this).UpdateOrderItem(item);
                            isAnyUpdate = true;
                        }                        
                    }
                }
            }
            //Otherwise process online orders and only is order is paid at this stage
            else if (customerOrder.Items.Any(a => a.Product.IsOnline) && isPaidOrder)
            {
                foreach (var item in customerOrder.Items.Where(a => a.Product.IsOnline && !string.IsNullOrEmpty(a.Product.BaseOnlineUrl)))
                {
                    //TODO: logic has to be implroved in the future
                    item.OnlineProductUrl = item.Product.BaseOnlineUrl;
                    ((IOrderItemBL)this).UpdateOrderItem(item);
                    isAnyUpdate = true;
                }
            }

            //if we have anything to update - we save to DB
            if (isAnyUpdate)
                _unitOfWork.Save();
        }

        /// <summary>
        /// prepare software products as an asynchronous operation.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        public async Task PrepareSoftwareProductsAsync(int orderId)
        {
            var customerOrder = await GetCustomerOrderByIdAsync(orderId);
            if (customerOrder == null)
                return;

            var isAnyUpdate = false;
            var authHelper = new AuthorizationHelper<CustomerOrder>(_configHelper, _authContext);
            var isPaidOrder = customerOrder.Payments.Any();
            //If any downlodable
            if (customerOrder.Items.Any(a => a.Product.IsDownloadable))
            {
                foreach (var item in customerOrder.Items.Where(a => a.Product.IsDownloadable))
                {
                    var product = GetProductById(item.ProductId.GetValueOrDefault());
                    if (product != null && product.Attachments != null && product.Attachments.Count(a => a.AttachmentTypeClassified == AttachmentType.Installation) == 1)
                    {
                        var productAttachment = product.Attachments.SingleOrDefault(a => a.AttachmentTypeClassified == AttachmentType.Installation);
                        await MakeAttachmentSecuredAsync(productAttachment.Id, authHelper.BapAdminRoleName, authHelper.BapContentManagerRoleName, "Supervisor");
                        //Secure URL is only provided when order is paid, otherwise this URL will be set by the workflow action accepting payment
                        if (isPaidOrder)
                        {
                            item.DownloadUrl = await ProvisionSecuredAttachmentAsync(productAttachment.Id, 10080/*one week*/);
                            await ((IOrderItemBL)this).UpdateOrderItemAsync(item);
                            isAnyUpdate = true;
                        }
                    }
                }
            }
            //Otherwise process online orders and only is order is paid at this stage
            else if (customerOrder.Items.Any(a => a.Product.IsOnline) && isPaidOrder)
            {
                foreach (var item in customerOrder.Items.Where(a => a.Product.IsOnline && !string.IsNullOrEmpty(a.Product.BaseOnlineUrl)))
                {
                    //TODO: logic has to be implroved in the future
                    item.OnlineProductUrl = item.Product.BaseOnlineUrl;
                    await ((IOrderItemBL)this).UpdateOrderItemAsync(item);
                    isAnyUpdate = true;
                }
            }

            //if we have anything to update - we save to DB
            if (isAnyUpdate)
                await _unitOfWork.SaveAsync();

        }

        /// <summary>
        /// Softwares the products paid.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        public void SoftwareProductsPaid(int orderId)
        {
            var customerOrder = GetCustomerOrderById(orderId);
            if (customerOrder == null || !customerOrder.Payments.Any())
                return;

            var isAnyUpdate = false;
            List<OrderItem> subscribedItems = new List<OrderItem>();
            //If any downlodable
            if (customerOrder.Items.Any(a => a.Product.IsDownloadable))
            {
                foreach (var item in customerOrder.Items.Where(a => a.Product.IsDownloadable))
                {
                    var product = GetProductById(item.ProductId.GetValueOrDefault());
                    if (product != null && product.Attachments != null && product.Attachments.Any(a => a.AttachmentTypeClassified == AttachmentType.Installation && a.IsSecured.HasValue && a.IsSecured.Value))
                    {
                        var productAttachment = product.Attachments.SingleOrDefault(a => a.AttachmentTypeClassified == AttachmentType.Installation && a.IsSecured.HasValue && a.IsSecured.Value);
                        int provisioningPeriod = 10080/*one week*/;
                        if(product.IsTrial && product.FreeTrialTermTicks > 0)
                        {
                            provisioningPeriod = (int)product.FreeTrialTerm.TotalMinutes;
                        }
                        else if(product.InitialTermTicks > 0)
                        {
                            provisioningPeriod = (int)product.InitialTerm.TotalMinutes;
                        }
                        item.DownloadUrl = ProvisionSecuredAttachment(productAttachment.Id, provisioningPeriod);
                        subscribedItems.Add(item);
                        ((IOrderItemBL)this).UpdateOrderItem(item);
                        isAnyUpdate = true;
                    }
                }
            }
            //Otherwise process online orders
            else if (customerOrder.Items.Any(a => a.Product.IsOnline))
            {
                foreach (var item in customerOrder.Items.Where(a => a.Product.IsOnline && !string.IsNullOrEmpty(a.Product.BaseOnlineUrl)))
                {
                    //TODO: logic has to be improved in the future
                    item.OnlineProductUrl = item.Product.BaseOnlineUrl;
                    subscribedItems.Add(item);
                    ((IOrderItemBL)this).UpdateOrderItem(item);
                    isAnyUpdate = true;
                }
            }

            //if we have anything to update - we save to DB
            if (isAnyUpdate)
            {
                foreach (var item in subscribedItems)
                {
                    var termDays = item.Product.IsTrial ? item.Product.FreeTrialTerm.TotalDays : item.Product.InitialTerm.TotalDays;
                    var subscription = new Subscription
                    {
                        AutoRenew = item.Product.AllowToRenew,
                        ContractDate = DateTime.Today,
                        InitialTerm = (int)(termDays / 30),
                        Name = "",
                        Object = "OrderItem",
                        ObjectId = item.Id,
                        RenewalTerm = (int)(item.Product.AllowToRenew ? item.Product.RenewalTerm.TotalDays / 30 : 0),
                        SubscriptionType = "Product",
                        SubTotal = (decimal)item.Subtotal,
                        TermStart = DateTime.Today,
                        TermEnd = DateTime.Today.AddDays(termDays)
                    };
                    AddSubscription(subscription);
                    item.Subscription = subscription;
                }
                _unitOfWork.Save();
            }            
        }

        /// <summary>
        /// software products paid as an asynchronous operation.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        public async Task SoftwareProductsPaidAsync(int orderId)
        {
            var customerOrder = GetCustomerOrderById(orderId);
            if (customerOrder == null || !customerOrder.Payments.Any())
                return;

            var isAnyUpdate = false;
            List<OrderItem> subscribedItems = new List<OrderItem>();
            //If any downlodable
            if (customerOrder.Items.Any(a => a.Product.IsDownloadable))
            {
                foreach (var item in customerOrder.Items.Where(a => a.Product.IsDownloadable))
                {
                    var product = await GetProductByIdAsync(item.ProductId.GetValueOrDefault());
                    if (product != null && product.Attachments != null && product.Attachments.Any(a => a.AttachmentTypeClassified == AttachmentType.Installation && a.IsSecured.HasValue && a.IsSecured.Value))
                    {
                        var productAttachment = product.Attachments.SingleOrDefault(a => a.AttachmentTypeClassified == AttachmentType.Installation && a.IsSecured.HasValue && a.IsSecured.Value);
                        int provisioningPeriod = 10080/*one week*/;
                        if (product.IsTrial && product.FreeTrialTermTicks > 0)
                        {
                            provisioningPeriod = (int)product.FreeTrialTerm.TotalMinutes;
                        }
                        else if (product.InitialTermTicks > 0)
                        {
                            provisioningPeriod = (int)product.InitialTerm.TotalMinutes;
                        }
                        item.DownloadUrl = await ProvisionSecuredAttachmentAsync(productAttachment.Id, provisioningPeriod);
                        subscribedItems.Add(item);
                        await ((IOrderItemBL)this).UpdateOrderItemAsync(item);
                        isAnyUpdate = true;
                    }
                }
            }
            //Otherwise process online orders
            else if (customerOrder.Items.Any(a => a.Product.IsOnline))
            {
                foreach (var item in customerOrder.Items.Where(a => a.Product.IsOnline && !string.IsNullOrEmpty(a.Product.BaseOnlineUrl)))
                {
                    //TODO: logic has to be implroved in the future
                    item.OnlineProductUrl = item.Product.BaseOnlineUrl;
                    subscribedItems.Add(item);
                    await ((IOrderItemBL)this).UpdateOrderItemAsync(item);
                    isAnyUpdate = true;
                }
            }

            //if we have anything to update - we save to DB
            if (isAnyUpdate)
            {
                foreach(var item in subscribedItems)
                {
                    var termDays = item.Product.IsTrial ? item.Product.FreeTrialTerm.TotalDays : item.Product.InitialTerm.TotalDays;
                    var subscription = new Subscription
                    {
                        AutoRenew = item.Product.AllowToRenew,
                        ContractDate = DateTime.Today,
                        InitialTerm = (int)(termDays / 30),
                        Name = "",
                        Object = "OrderItem",
                        ObjectId = item.Id,
                        RenewalTerm = (int)(item.Product.AllowToRenew ? item.Product.RenewalTerm.TotalDays / 30 : 0),
                        SubscriptionType = "Product",
                        SubTotal = (decimal)item.Subtotal,
                        TermStart = DateTime.Today,
                        TermEnd = DateTime.Today.AddDays(termDays)
                    };
                    await AddSubscriptionAsync(subscription);
                    item.Subscription = subscription;
                }
                await _unitOfWork.SaveAsync();
            }                
        }

        /// <summary>
        /// Insert customer into repository and initialize workflow for it if any available
        /// </summary>
        /// <param name="customerOrder">Customer order instance</param>
        public void AddCustomerOrder(CustomerOrder customerOrder)
        {
            //No order - nothing to do
            if (customerOrder == null)
                return;

            //Init order items
            if (customerOrder.Items != null)
            {
                foreach (var item in customerOrder.Items)
                {
                    _eCommerceUnitOfWork.OrderItemRepository.Add(item);
                }
            }

            //Insert order and save it to DB
            _eCommerceUnitOfWork.CustomerOrderRepository.Add(customerOrder);
            _eCommerceUnitOfWork.Save();

            //Init Workflow this way
            try
            {
                var workflowEngine = new WorkflowEngine<CustomerOrder>(_configHelper, _authContext, _logger, _lookupEngine, _fileProcessor, this);
                var availableFlows = workflowEngine.GetAvailableWorkflowClasses(customerOrder);
                if (availableFlows != null && availableFlows.Count == 1)
                    workflowEngine.InitWorkflow(availableFlows[0], customerOrder);
            }
            catch(Exception exc)
            {
                _logger.LogException("CustomerOrderBL", "AddCustomerOrder", exc);
            }            
        }

        /// <summary>
        /// Insert customer into repository asynchronously and initialize workflow for it if any available
        /// </summary>
        /// <param name="customerOrder">Customer order instance</param>
        public async Task AddCustomerOrderAsync(CustomerOrder customerOrder)
        {
            //No order nothing to do
            if (customerOrder == null)
                return;

            //Process order items
            if (customerOrder.Items != null)
            {
                foreach (var item in customerOrder.Items)
                {
                    _eCommerceUnitOfWork.OrderItemRepository.Add(item);
                }
            }

            //Save order
            _eCommerceUnitOfWork.CustomerOrderRepository.Add(customerOrder);
            await _eCommerceUnitOfWork.SaveAsync();

            //Init Workflow this way
            GetCurrentWorkflow(customerOrder);
        }

        /// <summary>
        /// Updates the customer order.
        /// </summary>
        /// <param name="customerOrder">The customer order.</param>
        public void UpdateCustomerOrder(CustomerOrder customerOrder)
        {
            if (customerOrder == null)
                return;

            if (customerOrder.Items != null)
            {
                foreach (var item in customerOrder.Items)
                {
                    if (item.Id > 0)
                        _eCommerceUnitOfWork.OrderItemRepository.Update(item);
                    else
                        _eCommerceUnitOfWork.OrderItemRepository.Add(item);
                }
            }

            _eCommerceUnitOfWork.CustomerOrderRepository.Update(customerOrder);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// update customer order as an asynchronous operation.
        /// </summary>
        /// <param name="customerOrder">The customer order.</param>
        public async Task UpdateCustomerOrderAsync(CustomerOrder customerOrder)
        {
            if (customerOrder == null)
                return;

            if (customerOrder.Items != null)
            {
                foreach (var item in customerOrder.Items)
                {
                    if (item.Id > 0)
                        _eCommerceUnitOfWork.OrderItemRepository.Update(item);
                    else
                        _eCommerceUnitOfWork.OrderItemRepository.Add(item);
                }
            }

            _eCommerceUnitOfWork.CustomerOrderRepository.Update(customerOrder);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the customer order.
        /// </summary>
        /// <param name="customerOrders">The customer orders.</param>
        public void RemoveCustomerOrder(params CustomerOrder[] customerOrders)
        {
            foreach (var order in customerOrders)
            {
                // mark order items as removed
                if (order.Items != null && order.Items.Count > 0)
                {
                    _eCommerceUnitOfWork.OrderItemRepository.Remove(order.Items.ToArray());
                }

                // mark associated workflow as removed - if any
                var entityType = order.GetType();
                var workflowObject = ((IWorkflowObjectBL)this).GetWorkflowObjectByEntity(entityType.Assembly.FullName, entityType.FullName, order.Id);
                if (workflowObject != null)
                {
                    ((IWorkflowObjectBL)this).RemoveWorkflowObject(false, workflowObject);
                }

                // mark order payments as removed if any
                ((ICustomerOrderPaymentBL)this).RemoveCustomerOrderPayments(order.Id, false);
            }

            _eCommerceUnitOfWork.CustomerOrderRepository.Remove(customerOrders);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// remove customer order as an asynchronous operation.
        /// </summary>
        /// <param name="customerOrders">The customer orders.</param>
        public async Task RemoveCustomerOrderAsync(params CustomerOrder[] customerOrders)
        {
            foreach (var order in customerOrders)
            {
                // mark order items as removed
                if (order.Items != null && order.Items.Count > 0)
                {
                    _eCommerceUnitOfWork.OrderItemRepository.Remove(order.Items.ToArray());
                }

                // mark associated workflow as removed - if any
                var entityType = order.GetType();
                var workflowObject = await ((IWorkflowObjectBL)this).GetWorkflowObjectByEntityAsync(entityType.Assembly.FullName, entityType.FullName, order.Id);
                if (workflowObject != null)
                {
                    await ((IWorkflowObjectBL)this).RemoveWorkflowObjectAsync(false, workflowObject);
                }

                // mark order payments as removed if any
                await ((ICustomerOrderPaymentBL)this).RemoveCustomerOrderPaymentsAsync(order.Id, false);
            }

            _eCommerceUnitOfWork.CustomerOrderRepository.Remove(customerOrders);
            await _eCommerceUnitOfWork.SaveAsync();
        }
        #endregion

        #region Workflows support

        /// <summary>
        /// Gets the available flows.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>List&lt;WorkflowClass&gt;.</returns>
        public List<WorkflowClass> GetAvailableFlows(CustomerOrder entity)
        {
            var implementer = new SupportWorkflowImplementer<CustomerOrder>(_logger, _configHelper, _authContext, _lookupEngine, _fileProcessor, this);            
            return implementer.GetAvailableFlows(entity);
        }

        public void RemoveCurrentWorkflow(CustomerOrder entity)
        {
            var implementer = new SupportWorkflowImplementer<CustomerOrder>(_logger, _configHelper, _authContext, _lookupEngine, _fileProcessor, this);            
            implementer.RemoveCurrentWorkflow(entity);
        }

        /// <summary>
        /// Chooses the workflow.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="workflowId">The workflow identifier.</param>
        /// <returns>Workflow&lt;CustomerOrder&gt;.</returns>
        public Workflow<CustomerOrder> ChooseWorkflow(CustomerOrder entity, int workflowId)
        {
            var implementer = new SupportWorkflowImplementer<CustomerOrder>(_logger, _configHelper, _authContext, _lookupEngine, _fileProcessor, this);
            return implementer.ChooseWorkflow(entity, workflowId);
        }

        /// <summary>
        /// Gets the current workflow.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="metaId">The meta identifier.</param>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <returns>Workflow&lt;CustomerOrder&gt;.</returns>
        public Workflow<CustomerOrder> GetCurrentWorkflow(CustomerOrder entity, int? metaId = null, int? attachmentId = null)
        {
            var implementer = new SupportWorkflowImplementer<CustomerOrder>(_logger, _configHelper, _authContext, _lookupEngine, _fileProcessor, this);
            return implementer.GetCurrentWorkflow(entity, metaId, attachmentId);            
        }

        /// <summary>
        /// Chooses the transition.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <param name="metaTransitionId">The meta transition identifier.</param>
        /// <param name="comment">The comment.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ChooseTransition(Workflow<CustomerOrder> workflow, int metaTransitionId, string comment)
        {
            var implementer = new SupportWorkflowImplementer<CustomerOrder>(_logger, _configHelper, _authContext, _lookupEngine, _fileProcessor, this);
            return implementer.ChooseTransition(workflow, metaTransitionId, comment);
        }

        /// <summary>
        /// Perform action of the workflow
        /// </summary>
        /// <param name="workflow">Workflow instance</param>
        /// <param name="metaActionId">Meta identificator of the action</param>
        /// <param name="attributesJson">The attributes json.</param>
        /// <returns>JSON text holding results of the action, null if error</returns>
        public string DoAction(Workflow<CustomerOrder> workflow, int metaActionId, string attributesJson)
        {
            var implementer = new SupportWorkflowImplementer<CustomerOrder>(_logger, _configHelper, _authContext, _lookupEngine, _fileProcessor, this);
            return implementer.DoAction(workflow, metaActionId, attributesJson);            
        }

        /// <summary>
        /// Saves the workflow.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        public void SaveWorkflow(Workflow<CustomerOrder> workflow)
        {
            var implementer = new SupportWorkflowImplementer<CustomerOrder>(_logger, _configHelper, _authContext, _lookupEngine, _fileProcessor, this);
            implementer.SaveWorkflow(workflow);            
        }

        #endregion
        
        /// <summary>
        /// Merge dictionaries ignoring duplicate keys
        /// </summary>
        /// <returns>Merged dictionary</returns>
        private static Dictionary<string, object> MergeDictionaries(Dictionary<string, object> left, Dictionary<string, object> right)
        {
            foreach (var newPair in right.Where(newPair => !left.ContainsKey(newPair.Key)))
            {
                left.Add(newPair.Key, newPair.Value);
            }
            
            return left;
        }
    }
}
