// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="PaymentOptionBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using PagedList;

using BAP.Common;
using BAP.eCommerce.DAL.Entities;
using BAP.eCommerce.Common.Exceptions;
using BAP.eCommerce.BL.DataContracts;
using BAP.DAL;
using BAP.Log;

namespace BAP.eCommerce.BL
{
    /// <summary>
    /// Class AccountInfo.
    /// </summary>
    public class AccountInfo
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        public string Notes { get; set; }
    }

    /// <summary>
    /// Class PaymentPassInfo.
    /// </summary>
    public class PaymentPassInfo
    {
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>The order identifier.</value>
        public int OrderId { get; set; }
        /// <summary>
        /// Gets or sets the payment identifier.
        /// </summary>
        /// <value>The payment identifier.</value>
        public string PaymentId { get; set; }
        /// <summary>
        /// Gets or sets the payment status.
        /// </summary>
        /// <value>The payment status.</value>
        public PaymentStatus PaymentStatus { get; set; }
        /// <summary>
        /// Gets or sets the total paid.
        /// </summary>
        /// <value>The total paid.</value>
        public decimal TotalPaid { get; set; }
        /// <summary>
        /// Gets or sets the start date time.
        /// </summary>
        /// <value>The start date time.</value>
        public DateTime StartDateTime { get; set; }
        /// <summary>
        /// Gets or sets the process date time.
        /// </summary>
        /// <value>The process date time.</value>
        public DateTime ProcessDateTime { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is error.
        /// </summary>
        /// <value><c>true</c> if this instance is error; otherwise, <c>false</c>.</value>
        public bool IsError { get; set; }
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>The error code.</value>
        public string ErrorCode { get; set; }
        /// <summary>
        /// Gets or sets the error description.
        /// </summary>
        /// <value>The error description.</value>
        public string ErrorDescription { get; set; }
        /// <summary>
        /// Gets or sets the payment intent.
        /// </summary>
        /// <value>The payment intent.</value>
        public PaymentIntent PaymentIntent { get; set; }
        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        public string Notes { get; set; }
    }

    /// <summary>
    /// Enum PaymentPageContentType
    /// </summary>
    public enum PaymentPageContentType
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,
        /// <summary>
        /// The HTML
        /// </summary>
        Html,
        /// <summary>
        /// The URL
        /// </summary>
        Url
    }

    /// <summary>
    /// Class PaymentPageInfo.
    /// </summary>
    public class PaymentPageInfo
    {
        /// <summary>
        /// Gets or sets the type of the payment page content.
        /// </summary>
        /// <value>The type of the payment page content.</value>
        public PaymentPageContentType PaymentPageContentType { get; set; }
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }
        /// <summary>
        /// Gets or sets the content of the head.
        /// </summary>
        /// <value>The content of the head.</value>
        public string HeadContent { get; set; }
        /// <summary>
        /// Gets or sets the java script.
        /// </summary>
        /// <value>The java script.</value>
        public string JavaScript { get; set; }
        /// <summary>
        /// Gets or sets the content of the HTML.
        /// </summary>
        /// <value>The content of the HTML.</value>
        public string HtmlContent { get; set; }
    }

    /// <summary>
    /// Interface to describe behavior of the particular payment gateway provider
    /// </summary>
    public interface IPaymentOptionProvider
    {
        /// <summary>
        /// Identify is account registration is supportable
        /// </summary>
        /// <returns>boolean, true is supported</returns>
        bool SupportRegister();

        /// <summary>
        /// Register payment account on the gateway based on the customer info given and internal login of the given gateway
        /// </summary>
        /// <param name="customer">customer object</param>
        /// <returns>Account reference id</returns>
        string RegisterAccount(Customer customer);

        /// <summary>
        /// Returns account information
        /// </summary>
        /// <param name="accountRefId">account reference id</param>
        /// <returns>AccountInfo.</returns>
        AccountInfo GetAccountInfo(string accountRefId);

        /// <summary>
        /// Give information about payment page to be shown. It can be either embedded html/javascript content, our internal page or exaternal page.
        /// If external or internal page is given application does redirect to it.
        /// </summary>
        /// <param name="order">Instance of CustomerOrder class</param>
        /// <param name="callBackUrl">URL to be called back by payment gateway when payment is processed</param>
        /// <param name="containerCss">Master CSS class name to be applied if html content is returned</param>
        /// <param name="accountRefId">Account reference id, optional, only if account is registered and reference is available on eCommerce side</param>
        /// <param name="iFrameCallbackUrl">The i frame callback URL.</param>
        /// <returns>PaymentPageInfo class instance</returns>
        PaymentPageInfo GetPaymentPage(CustomerOrder order, string callBackUrl, string containerCss = "", string accountRefId = "", string iFrameCallbackUrl = "");

        /// <summary>
        /// Method to be called by the callback page on our side. This method is responsible to parse/process data returned by payment gateway via
        /// call back url parameters or possibly via form data if gateway does POST call.
        /// </summary>
        /// <param name="callBackUrl">Optional. We may pass this if callback page is called with extra parameters in url</param>
        /// <returns>PaymentPassInfo.</returns>
        PaymentPassInfo PaymentCallBack(string callBackUrl = "");

        /// <summary>
        /// Method to return HTML content of the communication page used by iFrame of some of the payment providers in order to send data back to the
        /// parent page
        /// </summary>
        /// <param name="order">Instance of CustomerOrder class</param>
        /// <returns>HTML content text</returns>
        string GetiFrameCallbackHtml(CustomerOrder order);
    }

    /// <summary>
    /// Interface IPaymentOptionBL
    /// </summary>
    public interface IPaymentOptionBL
    {
        /// <summary>
        /// Gets all payment options.
        /// </summary>
        /// <returns>IList&lt;PaymentOption&gt;.</returns>
        IList<PaymentOption> GetAllPaymentOptions();
        /// <summary>
        /// Gets all payment options asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;PaymentOption&gt;&gt;.</returns>
        Task<IList<PaymentOption>> GetAllPaymentOptionsAsync();

        /// <summary>
        /// Searches the payment options.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;PaymentOption&gt;.</returns>
        IPagedList<PaymentOption> SearchPaymentOptions(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the payment options asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;PaymentOption&gt;&gt;.</returns>
        Task<IPagedList<PaymentOption>> SearchPaymentOptionsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Searches the payment options.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;PaymentOption&gt;.</returns>
        IList<PaymentOption> SearchPaymentOptions(string where, string sort);
        /// <summary>
        /// Searches the payment options asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>Task&lt;IList&lt;PaymentOption&gt;&gt;.</returns>
        Task<IList<PaymentOption>> SearchPaymentOptionsAsync(string where, string sort);

        /// <summary>
        /// Gets the payment option by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>PaymentOption.</returns>
        PaymentOption GetPaymentOptionById(int id);
        /// <summary>
        /// Gets the payment option by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;PaymentOption&gt;.</returns>
        Task<PaymentOption> GetPaymentOptionByIdAsync(int id);

        /// <summary>
        /// Adds the payment option.
        /// </summary>
        /// <param name="paymentOptions">The payment options.</param>
        void AddPaymentOption(params PaymentOption[] paymentOptions);
        /// <summary>
        /// Adds the payment option asynchronous.
        /// </summary>
        /// <param name="paymentOptions">The payment options.</param>
        /// <returns>Task.</returns>
        Task AddPaymentOptionAsync(params PaymentOption[] paymentOptions);

        /// <summary>
        /// Updates the payment option.
        /// </summary>
        /// <param name="paymentOptions">The payment options.</param>
        void UpdatePaymentOption(params PaymentOption[] paymentOptions);
        /// <summary>
        /// Updates the payment option asynchronous.
        /// </summary>
        /// <param name="paymentOptions">The payment options.</param>
        /// <returns>Task.</returns>
        Task UpdatePaymentOptionAsync(params PaymentOption[] paymentOptions);

        /// <summary>
        /// Removes the payment option.
        /// </summary>
        /// <param name="paymentOptions">The payment options.</param>
        void RemovePaymentOption(params PaymentOption[] paymentOptions);
        /// <summary>
        /// Removes the payment option asynchronous.
        /// </summary>
        /// <param name="paymentOptions">The payment options.</param>
        /// <returns>Task.</returns>
        Task RemovePaymentOptionAsync(params PaymentOption[] paymentOptions);

        /// <summary>
        /// Gets the payment option provider.
        /// </summary>
        /// <param name="paymentOptionId">The payment option identifier.</param>
        /// <returns>IPaymentOptionProvider.</returns>
        IPaymentOptionProvider GetPaymentOptionProvider(int paymentOptionId);
        /// <summary>
        /// Gets the payment option provider asynchronous.
        /// </summary>
        /// <param name="paymentOptionId">The payment option identifier.</param>
        /// <returns>Task&lt;IPaymentOptionProvider&gt;.</returns>
        Task<IPaymentOptionProvider> GetPaymentOptionProviderAsync(int paymentOptionId);

        /// <summary>
        /// Gets the payment options.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        /// <param name="options">The options.</param>
        /// <returns>IEnumerable&lt;PaymentOtionDC&gt;.</returns>
        IEnumerable<PaymentOtionDC> GetPaymentOptions(ShoppingCart shoppingCart, IList<PaymentOption> options = null);
        /// <summary>
        /// Gets the payment options asynchronous.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        /// <param name="options">The options.</param>
        /// <returns>Task&lt;IEnumerable&lt;PaymentOtionDC&gt;&gt;.</returns>
        Task<IEnumerable<PaymentOtionDC>> GetPaymentOptionsAsync(ShoppingCart shoppingCart, IList<PaymentOption> options = null);

        /// <summary>
        /// Checks the custom configuration support.
        /// </summary>
        /// <param name="paymentOption">The payment option.</param>
        /// <returns>CustomConfigSupport.</returns>
        CustomConfigSupport CheckCustomConfigSupport(PaymentOption paymentOption);
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
    public partial class eCommerceBusinessLayer : IPaymentOptionBL, ILocalizedBL<PaymentOption>
    {
        #region paymentOptions

        /// <summary>
        /// Gets all payment options.
        /// </summary>
        /// <returns>IList&lt;PaymentOption&gt;.</returns>
        public IList<PaymentOption> GetAllPaymentOptions()
        {
            return _eCommerceUnitOfWork.PaymentOptionRepository.GetAll();
        }

        /// <summary>
        /// get all payment options as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;PaymentOption&gt;.</returns>
        public async Task<IList<PaymentOption>> GetAllPaymentOptionsAsync()
        {
            return await _eCommerceUnitOfWork.PaymentOptionRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the payment options.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;PaymentOption&gt;.</returns>
        public IPagedList<PaymentOption> SearchPaymentOptions(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<PaymentOption>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _eCommerceUnitOfWork.PaymentOptionRepository.GetPagedList(page, pageSize, ParseJSONSearchString<PaymentOption>(where), sortExpression);
        }

        /// <summary>
        /// search payment options as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;PaymentOption&gt;.</returns>
        public async Task<IPagedList<PaymentOption>> SearchPaymentOptionsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<PaymentOption>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return await _eCommerceUnitOfWork.PaymentOptionRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<PaymentOption>(where), sortExpression);
        }

        /// <summary>
        /// Searches the payment options.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;PaymentOption&gt;.</returns>
        public IList<PaymentOption> SearchPaymentOptions(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<PaymentOption>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _eCommerceUnitOfWork.PaymentOptionRepository.GetList(ParseJSONSearchString<PaymentOption>(where), sortExpression);
        }

        /// <summary>
        /// search payment options as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;PaymentOption&gt;.</returns>
        public async Task<IList<PaymentOption>> SearchPaymentOptionsAsync(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<PaymentOption>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return await _eCommerceUnitOfWork.PaymentOptionRepository.GetListAsync(ParseJSONSearchString<PaymentOption>(where), sortExpression);
        }

        /// <summary>
        /// Gets the payment option by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>PaymentOption.</returns>
        public PaymentOption GetPaymentOptionById(int id)
        {
            return _eCommerceUnitOfWork.PaymentOptionRepository.GetSingle(a => a.Id == id);
        }

        /// <summary>
        /// get payment option by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>PaymentOption.</returns>
        public async Task<PaymentOption> GetPaymentOptionByIdAsync(int id)
        {
            return await _eCommerceUnitOfWork.PaymentOptionRepository.GetSingleAsync(a => a.Id == id);
        }

        /// <summary>
        /// Adds the payment option.
        /// </summary>
        /// <param name="paymentOptions">The payment options.</param>
        public void AddPaymentOption(params PaymentOption[] paymentOptions)
        {
            _eCommerceUnitOfWork.PaymentOptionRepository.Add(paymentOptions);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// add payment option as an asynchronous operation.
        /// </summary>
        /// <param name="paymentOptions">The payment options.</param>
        public async Task AddPaymentOptionAsync(params PaymentOption[] paymentOptions)
        {
            _eCommerceUnitOfWork.PaymentOptionRepository.Add(paymentOptions);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the payment option.
        /// </summary>
        /// <param name="paymentOptions">The payment options.</param>
        public void UpdatePaymentOption(params PaymentOption[] paymentOptions)
        {
            _eCommerceUnitOfWork.PaymentOptionRepository.Update(paymentOptions);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// update payment option as an asynchronous operation.
        /// </summary>
        /// <param name="paymentOptions">The payment options.</param>
        public async Task UpdatePaymentOptionAsync(params PaymentOption[] paymentOptions)
        {
            _eCommerceUnitOfWork.PaymentOptionRepository.Update(paymentOptions);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the payment option.
        /// </summary>
        /// <param name="paymentOptions">The payment options.</param>
        public void RemovePaymentOption(params PaymentOption[] paymentOptions)
        {
            _eCommerceUnitOfWork.PaymentOptionRepository.Remove(paymentOptions);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// remove payment option as an asynchronous operation.
        /// </summary>
        /// <param name="paymentOptions">The payment options.</param>
        public async Task RemovePaymentOptionAsync(params PaymentOption[] paymentOptions)
        {
            _eCommerceUnitOfWork.PaymentOptionRepository.Remove(paymentOptions);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Gets the payment option provider.
        /// </summary>
        /// <param name="paymentOptionId">The payment option identifier.</param>
        /// <returns>IPaymentOptionProvider.</returns>
        /// <exception cref="PaymentException">Payment option cannot be found with the given id = {paymentOptionId}</exception>
        public IPaymentOptionProvider GetPaymentOptionProvider(int paymentOptionId)
        {
            IPaymentOptionProvider result = null;
            var paymentOption = GetPaymentOptionById(paymentOptionId);
            if (paymentOption == null)
                throw new PaymentException($"Payment option cannot be found with the given id = {paymentOptionId}");

            if (!string.IsNullOrEmpty(paymentOption.AsssemblyName) && !string.IsNullOrEmpty(paymentOption.ClassName))
            {
                var assembly = Assembly.Load(paymentOption.AsssemblyName);
                if (assembly != null)
                {
                    var type = assembly.GetType(paymentOption.ClassName);
                    if (type != null && typeof(IPaymentOptionProvider).IsAssignableFrom(type))
                    {
                        object[] constructorParams = new object[3];
                        constructorParams[0] = _logger;
                        constructorParams[1] = paymentOption.CustomConfigJson;
                        constructorParams[2] = this;
                        object classInstance = Activator.CreateInstance(type, constructorParams);
                        result = (IPaymentOptionProvider)classInstance;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// get payment option provider as an asynchronous operation.
        /// </summary>
        /// <param name="paymentOptionId">The payment option identifier.</param>
        /// <returns>IPaymentOptionProvider.</returns>
        /// <exception cref="PaymentException">Payment option cannot be found with the given id = {paymentOptionId}</exception>
        public async Task<IPaymentOptionProvider> GetPaymentOptionProviderAsync(int paymentOptionId)
        {
            IPaymentOptionProvider result = null;
            var paymentOption = await GetPaymentOptionByIdAsync(paymentOptionId);
            if (paymentOption == null)
                throw new PaymentException($"Payment option cannot be found with the given id = {paymentOptionId}");

            if (!string.IsNullOrEmpty(paymentOption.AsssemblyName) && !string.IsNullOrEmpty(paymentOption.ClassName))
            {
                var assembly = Assembly.Load(paymentOption.AsssemblyName);
                if (assembly != null)
                {
                    var type = assembly.GetType(paymentOption.ClassName);
                    if (type != null && typeof(IPaymentOptionProvider).IsAssignableFrom(type))
                    {
                        object[] constructorParams = new object[3];
                        constructorParams[0] = _logger;
                        constructorParams[1] = paymentOption.CustomConfigJson;
                        constructorParams[2] = this;
                        object classInstance = Activator.CreateInstance(type, constructorParams);
                        result = (IPaymentOptionProvider)classInstance;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the payment options.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        /// <param name="options">The options.</param>
        /// <returns>IEnumerable&lt;PaymentOtionDC&gt;.</returns>
        public IEnumerable<PaymentOtionDC> GetPaymentOptions(ShoppingCart shoppingCart, IList<PaymentOption> options = null)
        {
            var isAnythingSelected = false;
            if (options == null || !options.Any())
                options = GetAllPaymentOptions();
            var result = (from option in options
                          orderby option.Name
                          where option.Enabled
                          select new PaymentOtionDC
                          {
                              Id = option.Id,
                              Name = option.Name,
                              ShortDescription = option.ShortDescription,
                              Description = option.Description
                          }).ToList();

            //Extra processing here in order to get preferred payment option of the given customer (it will be phase 2, not essential for a moment)            

            //Do extra processing using current shopping cart
            if (shoppingCart != null)
            {
                //Filter by shipping option to be added here:
                if (shoppingCart.ShippingOptionId != null && shoppingCart.ShippingOptionId > 0 && result.Count > 0)
                {
                    var shippingOption = ((IShippingOptionBL)this).GetShippingOptionById(shoppingCart.ShippingOptionId.Value);
                    if (shippingOption?.AllowedPaymentOptions != null && shippingOption.AllowedPaymentOptions.Count > 0)
                    {
                        var indexesToRemove = new List<int>();
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (shippingOption.AllowedPaymentOptions.All(a => a.Id != result[i].Id))
                                indexesToRemove.Add(i);
                        }
                        foreach (var index in indexesToRemove)
                        {
                            result.RemoveAt(index);
                        }
                    }
                }

                // Chose currently selected option by shopping cart
                if (shoppingCart.PaymentOptionId > 0)
                {
                    var item = result.SingleOrDefault(a => a.Id == shoppingCart.PaymentOptionId);
                    if (item != null)
                    {
                        item.Selected = true;
                        isAnythingSelected = true;
                    }
                }
            }
            if (!isAnythingSelected && result.Count > 0)
            {
                result[0].Selected = true;
            }

            return result.ToArray();
        }

        /// <summary>
        /// get payment options as an asynchronous operation.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        /// <param name="options">The options.</param>
        /// <returns>IEnumerable&lt;PaymentOtionDC&gt;.</returns>
        public async Task<IEnumerable<PaymentOtionDC>> GetPaymentOptionsAsync(ShoppingCart shoppingCart, IList<PaymentOption> options = null)
        {
            var isAnythingSelected = false;
            if (options == null)
                options = await GetAllPaymentOptionsAsync();
            var result = (from option in options
                          orderby option.Name
                          where option.Enabled
                          select new PaymentOtionDC
                          {
                              Id = option.Id,
                              Name = option.Name,
                              ShortDescription = option.ShortDescription,
                              Description = option.Description
                          }).ToList();

            //Extra processing here in order to get preferred payment option of the given customer (it will be phase 2, not essential for a moment)            

            //Do extra processing using current shopping cart
            if (shoppingCart != null)
            {
                //Filter by shipping option to be added here:
                if (shoppingCart.ShippingOptionId != null && shoppingCart.ShippingOptionId > 0 && result.Count > 0)
                {
                    var shippingOption = await ((IShippingOptionBL)this).GetShippingOptionByIdAsync(shoppingCart.ShippingOptionId.Value);
                    if (shippingOption?.AllowedPaymentOptions != null && shippingOption.AllowedPaymentOptions.Count > 0)
                    {
                        var indexesToRemove = new List<int>();
                        for (int i = 0; i < result.Count; i++)
                        {
                            if (shippingOption.AllowedPaymentOptions.All(a => a.Id != result[i].Id))
                                indexesToRemove.Add(i);
                        }
                        foreach (var index in indexesToRemove)
                        {
                            result.RemoveAt(index);
                        }
                    }
                }

                // Chose currently selected option by shopping cart
                if (shoppingCart.PaymentOptionId > 0)
                {
                    var item = result.SingleOrDefault(a => a.Id == shoppingCart.PaymentOptionId);
                    if (item != null)
                    {
                        item.Selected = true;
                        isAnythingSelected = true;
                    }
                }
            }
            if (!isAnythingSelected && result.Count > 0)
            {
                result[0].Selected = true;
            }

            return result.ToArray();
        }

        /// <summary>
        /// Checks the custom configuration support.
        /// </summary>
        /// <param name="paymentOption">The payment option.</param>
        /// <returns>CustomConfigSupport.</returns>
        public CustomConfigSupport CheckCustomConfigSupport(PaymentOption paymentOption)
        {
            if (paymentOption == null || string.IsNullOrEmpty(paymentOption.AsssemblyName) || string.IsNullOrEmpty(paymentOption.ClassName))
                return null;

            bool configSupport = false;
            string exampleText = "";

            try
            {
                var assembly = Assembly.Load(paymentOption.AsssemblyName);
                if (assembly != null)
                {
                    var type = assembly.GetType(paymentOption.ClassName);
                    if (type != null && typeof(IPaymentOptionProvider).IsAssignableFrom(type))
                    {
                        object classInstance = GetPaymentProviderClassInstance(type, paymentOption.CustomConfigJson);
                        PropertyInfo property = type.GetProperty("SupportsCustomConfig");
                        if (property != null)
                        {
                            configSupport = (bool)property.GetValue(classInstance, null);
                        }

                        if (configSupport)
                        {
                            property = type.GetProperty("CustomConfigJsonExample");
                            if (property != null)
                            {
                                exampleText = property.GetValue(classInstance, null) as string;
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                _logger.LogException("PaymentOptionBL", "CheckCustomConfigSupport", new ShippingException("Error checking configuration support for the given shipping provider: " + paymentOption.Name, exc));
                configSupport = false;
                exampleText = "";
            }

            return new CustomConfigSupport
            {
                SupportsCustomConfig = configSupport,
                CustomConfigExample = exampleText
            };
        }

        #region ILocalizedBL
        /// <summary>
        /// Get full details of the single entity
        /// </summary>
        /// <param name="ofEntity">Passed entity is used as filter, method implementing ths feature should treat this oject apropriatly to call some method of BL class to read full details.</param>
        /// <returns>Entity instance</returns>
        public PaymentOption GetDetails(PaymentOption ofEntity)
        {
            if (ofEntity == null)
                return null;

            if (ofEntity.Id > 0)
                return GetPaymentOptionById(ofEntity.Id);
            
            return null;
        }

        /// <summary>
        /// Inserts given entity into DB
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        public void AddSingleEntity(PaymentOption entity)
        {
            _eCommerceUnitOfWork.PaymentOptionRepository.Add(entity);
            _eCommerceUnitOfWork.Save();
        }
        #endregion

        /// <summary>
        /// Gets the payment provider class instance.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="customConfigJson">The custom configuration json.</param>
        /// <returns>System.Object.</returns>
        private object GetPaymentProviderClassInstance(Type type, string customConfigJson)
        {
            object[] constructorParams = new object[2];
            constructorParams[0] = _logger;
            constructorParams[1] = customConfigJson;
            return Activator.CreateInstance(type, constructorParams);
        }

        #endregion
    }

    /// <summary>
    /// Class PaymentOptionBL.
    /// Implements the <see cref="BAP.eCommerce.BL.eCommerceBusinessLayer" />
    /// Implements the <see cref="BAP.Common.ISupportLookup" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.BL.eCommerceBusinessLayer" />
    /// <seealso cref="BAP.Common.ISupportLookup" />
    public class PaymentOptionBL : eCommerceBusinessLayer, ISupportLookup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentOptionBL"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public PaymentOptionBL(IConfigHelper settings, IAuthorizationContext context, ILogger logger) : base(null, null, settings, context, logger)
        {

        }

        /// <summary>
        /// Gets the lookup items.
        /// </summary>
        /// <param name="valueField">The value field.</param>
        /// <param name="textField">The text field.</param>
        /// <param name="descriptionField">The description field.</param>
        /// <param name="extraFilter">The extra filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="roles">The roles.</param>
        /// <param name="setCurrentUserAsSelected">if set to <c>true</c> [set current user as selected].</param>
        /// <returns>IList&lt;LookupItem&gt;.</returns>
        public IList<LookupItem> GetLookupItems(string valueField, string textField, string descriptionField, string extraFilter, string orderBy, List<string> roles = null, bool setCurrentUserAsSelected = false)
        {
            List<LookupItem> result = new List<LookupItem>();
            var paymentOptions = SearchPaymentOptions(extraFilter, orderBy);
            foreach (var shippingOption in paymentOptions)
            {
                var val = shippingOption.GetType().GetProperty(valueField).GetValue(shippingOption, null);
                var text = shippingOption.GetType().GetProperty(textField).GetValue(shippingOption, null);
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = shippingOption.GetType().GetProperty(descriptionField).GetValue(shippingOption, null);
                }
                result.Add(new LookupItem { Key = val.ToString(), Text = text.ToString(), Description = descr.ToString() });
            }

            return result;
        }

        /// <summary>
        /// get lookup items as an asynchronous operation.
        /// </summary>
        /// <param name="valueField">The value field.</param>
        /// <param name="textField">The text field.</param>
        /// <param name="descriptionField">The description field.</param>
        /// <param name="extraFilter">The extra filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="roles">The roles.</param>
        /// <param name="setCurrentUserAsSelected">if set to <c>true</c> [set current user as selected].</param>
        /// <returns>IList&lt;LookupItem&gt;.</returns>
        public async Task<IList<LookupItem>> GetLookupItemsAsync(string valueField, string textField, string descriptionField = "", string extraFilter = "",
            string orderBy = "", List<string> roles = null, bool setCurrentUserAsSelected = false)
        {
            List<LookupItem> result = new List<LookupItem>();
            var paymentOptions = await SearchPaymentOptionsAsync(extraFilter, orderBy);
            foreach (var shippingOption in paymentOptions)
            {
                var val = shippingOption.GetType().GetProperty(valueField).GetValue(shippingOption, null);
                var text = shippingOption.GetType().GetProperty(textField).GetValue(shippingOption, null);
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = shippingOption.GetType().GetProperty(descriptionField).GetValue(shippingOption, null);
                }
                result.Add(new LookupItem { Key = val.ToString(), Text = text.ToString(), Description = descr.ToString() });
            }

            return result;
        }
    }
}
