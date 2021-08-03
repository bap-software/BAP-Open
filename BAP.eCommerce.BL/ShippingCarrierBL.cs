// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="ShippingCarrierBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using PagedList;

using BAP.Common;
using BAP.DAL;
using BAP.Log;

using BAP.eCommerce.DAL.Entities;
using BAP.eCommerce.Common.Exceptions;

namespace BAP.eCommerce.BL
{
    /// <summary>
    /// Interface IShippingCarrierProvider
    /// </summary>
    public interface IShippingCarrierProvider
    {
        /// <summary>
        /// Gets the name of the provider.
        /// </summary>
        /// <value>The name of the provider.</value>
        string ProviderName { get; }
        /// <summary>
        /// Gets a value indicating whether [supports option custom configuration].
        /// </summary>
        /// <value><c>true</c> if [supports option custom configuration]; otherwise, <c>false</c>.</value>
        bool SupportsOptionCustomConfig { get; }
        /// <summary>
        /// Gets the custom option configuration json example.
        /// </summary>
        /// <value>The custom option configuration json example.</value>
        string CustomOptionConfigJsonExample { get; }
        /// <summary>
        /// Determines whether this instance can deliver the specified delivery.
        /// </summary>
        /// <param name="delivery">The delivery.</param>
        /// <returns><c>true</c> if this instance can deliver the specified delivery; otherwise, <c>false</c>.</returns>
        bool CanDeliver(Delivery delivery);
        /// <summary>
        /// Gets the quote.
        /// </summary>
        /// <param name="delivery">The delivery.</param>
        /// <returns>System.Decimal.</returns>
        decimal GetQuote(Delivery delivery);

        /// <summary>
        /// Initiates the delivery estimation.
        /// </summary>
        /// <param name="delivery">The delivery.</param>
        /// <returns></returns>
        DeliveryResult InitiateDelivery(Delivery delivery);

        /// <summary>
        /// Gets or sets a value indicating whether [support branch listing].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [support branch listing]; otherwise, <c>false</c>.
        /// </value>
        bool SupportBranchListing { get; }

        /// <summary>
        /// Searches the branches by the given delivery info, implementation can do search based on any of the attributes inside.
        /// </summary>
        /// <param name="shipToAddress">The ship to address.</param>
        /// <returns></returns>
        IList<BranchInfo> SearchBranches(Delivery delivery);
    }

    /// <summary>
    /// Information about shipping provider branch
    /// </summary>
    public class BranchInfo
    {
        public int Id { get; set; }
        public string ReferenceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public bool LimitedAccess { get; set; }
    }

    /// <summary>
    /// Item to deliver
    /// </summary>
    public sealed class DeliveryItem
    {
        public Product Product { get; set; }
        public int Count { get; set; }        
    }

    /// <summary>
    /// Class Delivery. This class cannot be inherited.
    /// </summary>
    public sealed class Delivery
    {
        /// <summary>
        /// Gets or sets the products total amount in local currency.
        /// </summary>
        /// <value>
        /// The products total.
        /// </value>
        public decimal ProductsTotal { get; set; }
        /// <summary>
        /// Get or sets the number or the name of the shipping provider branch we ship product from, optional.
        /// </summary>
        /// <value>
        /// From branch reference.
        /// </value>
        public string FromBranchRef { get; set; }
        /// <summary>
        /// Get or sets the number or the name of the shipping provider branch we ship product to, optional.
        /// </summary>
        /// <value>
        /// To branch reference.
        /// </value>
        public string ShipToBranchRef { get; set; }
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        public List<DeliveryItem> Items { get; set; }
        /// <summary>
        /// Gets or sets from address.
        /// </summary>
        /// <value>From address.</value>
        public Address FromAddress { get; set; }
        /// <summary>
        /// Gets or sets the ship to address.
        /// </summary>
        /// <value>The ship to address.</value>
        public Address ShipToAddress { get; set; }
        /// <summary>
        /// Gets or sets the shipping date.
        /// </summary>
        /// <value>The shipping date.</value>
        public DateTime ShippingDate { get; set; }
        /// <summary>
        /// Gets or sets the shipping option.
        /// </summary>
        /// <value>The shipping option.</value>
        public ShippingOption ShippingOption { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether shipping carrier should collect payment on deivery.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [pay ondelivery]; otherwise, <c>false</c>.
        /// </value>
        public bool PayOnDelivery { get; set; } = false;
        /// <summary>
        /// Gets or sets the payment to collect on delivery, if null, total cost of shipping items to be collected.
        /// </summary>
        /// <value>
        /// The payment to collect.
        /// </value>
        public decimal? PaymentToCollect { get; set; }
    }

    /// <summary>
    /// Result is given by shipment provider when we initiate delivery process on it. This is not the result of actual delivery, but rather result of intention to ship something.
    /// </summary>
    public sealed class DeliveryResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DeliveryResult"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }
        /// <summary>
        /// Gets or sets the message given by shipment provider.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets the reference identifier of the potential shippment.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public string ReferenceId { get; set; }
        /// <summary>
        /// Gets or sets the estimated delivery cost.
        /// </summary>
        /// <value>
        /// The delivery cost.
        /// </value>
        public decimal DeliveryCost { get; set; }
        /// <summary>
        /// Gets or sets the estimated delivery date and time.
        /// </summary>
        /// <value>
        /// The estimated delivery at.
        /// </value>
        public DateTime EstimatedDeliveryAt { get; set; }
        /// <summary>
        /// Gets or sets the reference document number.
        /// </summary>
        /// <value>
        /// The reference document number.
        /// </value>
        public string RefDocumentNumber { get; set; }
        /// <summary>
        /// Gets or sets the type of the reference document.
        /// </summary>
        /// <value>
        /// The type of the reference document.
        /// </value>
        public string RefDocumentType { get; set; }
        /// <summary>
        /// Gets or sets the extra data in JSON format.
        /// </summary>
        /// <value>
        /// The extra data json.
        /// </value>
        public string ExtraDataJson { get; set; }
    }

    /// <summary>
    /// Class CustomConfigSupport. This class cannot be inherited.
    /// </summary>
    public sealed class CustomConfigSupport
    {
        /// <summary>
        /// Gets or sets a value indicating whether [supports custom configuration].
        /// </summary>
        /// <value><c>true</c> if [supports custom configuration]; otherwise, <c>false</c>.</value>
        public bool SupportsCustomConfig { get; set; }
        /// <summary>
        /// Gets or sets the custom configuration example.
        /// </summary>
        /// <value>The custom configuration example.</value>
        public string CustomConfigExample { get; set; }
    }

    /// <summary>
    /// Interface IShippingCarrierBL
    /// </summary>
    public interface IShippingCarrierBL
    {
        /// <summary>
        /// Gets all shipping carriers.
        /// </summary>
        /// <returns>IList&lt;ShippingCarrier&gt;.</returns>
        IList<ShippingCarrier> GetAllShippingCarriers();
        /// <summary>
        /// Gets all shipping carriers asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;ShippingCarrier&gt;&gt;.</returns>
        Task<IList<ShippingCarrier>> GetAllShippingCarriersAsync();

        /// <summary>
        /// Searches the shipping carriers.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;ShippingCarrier&gt;.</returns>
        IList<ShippingCarrier> SearchShippingCarriers(string where, string sort);
        /// <summary>
        /// Searches the shipping carriers asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>Task&lt;IList&lt;ShippingCarrier&gt;&gt;.</returns>
        Task<IList<ShippingCarrier>> SearchShippingCarriersAsync(string where, string sort);

        /// <summary>
        /// Searches the shipping carriers.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ShippingCarrier&gt;.</returns>
        IPagedList<ShippingCarrier> SearchShippingCarriers(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the shipping carriers asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;ShippingCarrier&gt;&gt;.</returns>
        Task<IPagedList<ShippingCarrier>> SearchShippingCarriersAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the shipping carrier by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShippingCarrier.</returns>
        ShippingCarrier GetShippingCarrierById(int id);
        /// <summary>
        /// Gets the shipping carrier by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ShippingCarrier&gt;.</returns>
        Task<ShippingCarrier> GetShippingCarrierByIdAsync(int id);

        /// <summary>
        /// Gets the single shipping carrier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShippingCarrier.</returns>
        ShippingCarrier GetSingleShippingCarrier(int id);
        /// <summary>
        /// Gets the single shipping carrier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ShippingCarrier&gt;.</returns>
        Task<ShippingCarrier> GetSingleShippingCarrierAsync(int id);

        /// <summary>
        /// Adds the shipping carrier.
        /// </summary>
        /// <param name="shippingCarriers">The shipping carriers.</param>
        void AddShippingCarrier(params ShippingCarrier[] shippingCarriers);
        /// <summary>
        /// Adds the shipping carrier asynchronous.
        /// </summary>
        /// <param name="shippingCarriers">The shipping carriers.</param>
        /// <returns>Task.</returns>
        Task AddShippingCarrierAsync(params ShippingCarrier[] shippingCarriers);

        /// <summary>
        /// Updates the shipping carrier.
        /// </summary>
        /// <param name="shippingCarriers">The shipping carriers.</param>
        void UpdateShippingCarrier(params ShippingCarrier[] shippingCarriers);
        /// <summary>
        /// Updates the shipping carrier asynchronous.
        /// </summary>
        /// <param name="shippingCarriers">The shipping carriers.</param>
        /// <returns>Task.</returns>
        Task UpdateShippingCarrierAsync(params ShippingCarrier[] shippingCarriers);

        /// <summary>
        /// Removes the shipping carrier.
        /// </summary>
        /// <param name="shippingCarriers">The shipping carriers.</param>
        void RemoveShippingCarrier(params ShippingCarrier[] shippingCarriers);
        /// <summary>
        /// Removes the shipping carrier asynchronous.
        /// </summary>
        /// <param name="shippingCarriers">The shipping carriers.</param>
        /// <returns>Task.</returns>
        Task RemoveShippingCarrierAsync(params ShippingCarrier[] shippingCarriers);

        /// <summary>
        /// Gets the quote.
        /// </summary>
        /// <param name="delivery">The delivery.</param>
        /// <returns>System.Decimal.</returns>
        decimal GetQuote(Delivery delivery);

        /// <summary>
        /// Initiates the delivery estimation.
        /// </summary>
        /// <param name="delivery">The delivery.</param>
        /// <returns></returns>
        DeliveryResult InitiateDelivery(Delivery delivery);

        /// <summary>
        /// Gets or sets a value indicating whether [support branch listing].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [support branch listing]; otherwise, <c>false</c>.
        /// </value>
        bool SupportBranchListing(ShippingCarrier shippingCarrier);

        /// <summary>
        /// Searches the branches by the given address.
        /// </summary>
        /// <param name="shipToAddress">The ship to address.</param>
        /// <returns></returns>
        IList<BranchInfo> SearchBranches(Delivery delivery);

        /// <summary>
        /// Checks the custom configuration support.
        /// </summary>
        /// <param name="shippingCarrier">The shipping carrier.</param>
        /// <returns>CustomConfigSupport.</returns>
        CustomConfigSupport CheckCustomConfigSupport(ShippingCarrier shippingCarrier);

        /// <summary>
        /// Checks the custom option configuration support.
        /// </summary>
        /// <param name="shippingCarrier">The shipping carrier.</param>
        /// <returns>CustomConfigSupport.</returns>
        CustomConfigSupport CheckCustomOptionConfigSupport(ShippingCarrier shippingCarrier);
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
    public partial class eCommerceBusinessLayer : IShippingCarrierBL, ILocalizedBL<ShippingCarrier>
    {
        /// <summary>
        /// Gets all shipping carriers.
        /// </summary>
        /// <returns>IList&lt;ShippingCarrier&gt;.</returns>
        public IList<ShippingCarrier> GetAllShippingCarriers()
        {
            return _eCommerceUnitOfWork.ShippingCarrierRepository.GetAll();
        }

        /// <summary>
        /// get all shipping carriers as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;ShippingCarrier&gt;.</returns>
        public async Task<IList<ShippingCarrier>> GetAllShippingCarriersAsync()
        {
            return await _eCommerceUnitOfWork.ShippingCarrierRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the shipping carriers.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;ShippingCarrier&gt;.</returns>
        public IList<ShippingCarrier> SearchShippingCarriers(string where, string sort)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<ShippingCarrier>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _eCommerceUnitOfWork.ShippingCarrierRepository.GetList(ParseJSONSearchString<ShippingCarrier>(where), sortExpression);
        }

        /// <summary>
        /// search shipping carriers as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;ShippingCarrier&gt;.</returns>
        public async Task<IList<ShippingCarrier>> SearchShippingCarriersAsync(string where, string sort)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<ShippingCarrier>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _eCommerceUnitOfWork.ShippingCarrierRepository.GetListAsync(ParseJSONSearchString<ShippingCarrier>(where), sortExpression);
        }

        /// <summary>
        /// Searches the shipping carriers.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ShippingCarrier&gt;.</returns>
        public IPagedList<ShippingCarrier> SearchShippingCarriers(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<ShippingCarrier>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _eCommerceUnitOfWork.ShippingCarrierRepository.GetPagedList(page, pageSize, ParseJSONSearchString<ShippingCarrier>(where), sortExpression);
        }

        /// <summary>
        /// search shipping carriers as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ShippingCarrier&gt;.</returns>
        public async Task<IPagedList<ShippingCarrier>> SearchShippingCarriersAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<ShippingCarrier>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _eCommerceUnitOfWork.ShippingCarrierRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<ShippingCarrier>(where), sortExpression);
        }

        /// <summary>
        /// Gets the shipping carrier by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShippingCarrier.</returns>
        public ShippingCarrier GetShippingCarrierById(int id)
        {
            var shippingCarrier = _eCommerceUnitOfWork.ShippingCarrierRepository.GetSingle(a => a.Id == id, a => a.ShippingOptions);
            if (shippingCarrier != null && shippingCarrier.Id > 0)
            {
                shippingCarrier.Attachments = _eCommerceUnitOfWork.AttachmentRepository.GetList(a => a.Object == "ShippingCarrier" && a.ObjectId == shippingCarrier.Id);
            }
            return shippingCarrier;
        }

        /// <summary>
        /// get shipping carrier by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShippingCarrier.</returns>
        public async Task<ShippingCarrier> GetShippingCarrierByIdAsync(int id)
        {
            var shippingCarrier = await _eCommerceUnitOfWork.ShippingCarrierRepository.GetSingleAsync(a => a.Id == id, a => a.ShippingOptions);
            if (shippingCarrier != null && shippingCarrier.Id > 0)
            {
                shippingCarrier.Attachments = _eCommerceUnitOfWork.AttachmentRepository.GetList(a => a.Object == "ShippingCarrier" && a.ObjectId == shippingCarrier.Id);
            }
            return shippingCarrier;
        }

        /// <summary>
        /// Gets the single shipping carrier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShippingCarrier.</returns>
        public ShippingCarrier GetSingleShippingCarrier(int id)
        {
            var shippingCarrier = _eCommerceUnitOfWork.ShippingCarrierRepository.GetSingle(a => a.Id == id);

            return shippingCarrier;
        }

        /// <summary>
        /// get single shipping carrier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShippingCarrier.</returns>
        public async Task<ShippingCarrier> GetSingleShippingCarrierAsync(int id)
        {
            var shippingCarrier = await _eCommerceUnitOfWork.ShippingCarrierRepository.GetSingleAsync(a => a.Id == id);

            return shippingCarrier;
        }

        /// <summary>
        /// Adds the shipping carrier.
        /// </summary>
        /// <param name="shippingCarriers">The shipping carriers.</param>
        public void AddShippingCarrier(params ShippingCarrier[] shippingCarriers)
        {
            _eCommerceUnitOfWork.ShippingCarrierRepository.Add(shippingCarriers);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// add shipping carrier as an asynchronous operation.
        /// </summary>
        /// <param name="shippingCarriers">The shipping carriers.</param>
        public async Task AddShippingCarrierAsync(params ShippingCarrier[] shippingCarriers)
        {
            _eCommerceUnitOfWork.ShippingCarrierRepository.Add(shippingCarriers);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the shipping carrier.
        /// </summary>
        /// <param name="shippingCarriers">The shipping carriers.</param>
        public void UpdateShippingCarrier(params ShippingCarrier[] shippingCarriers)
        {
            _eCommerceUnitOfWork.ShippingCarrierRepository.Update(shippingCarriers);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// update shipping carrier as an asynchronous operation.
        /// </summary>
        /// <param name="shippingCarriers">The shipping carriers.</param>
        public async Task UpdateShippingCarrierAsync(params ShippingCarrier[] shippingCarriers)
        {
            _eCommerceUnitOfWork.ShippingCarrierRepository.Update(shippingCarriers);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the shipping carrier.
        /// </summary>
        /// <param name="shippingCarriers">The shipping carriers.</param>
        public void RemoveShippingCarrier(params ShippingCarrier[] shippingCarriers)
        {
            _eCommerceUnitOfWork.ShippingCarrierRepository.Remove(shippingCarriers);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// remove shipping carrier as an asynchronous operation.
        /// </summary>
        /// <param name="shippingCarriers">The shipping carriers.</param>
        public async Task RemoveShippingCarrierAsync(params ShippingCarrier[] shippingCarriers)
        {
            _eCommerceUnitOfWork.ShippingCarrierRepository.Remove(shippingCarriers);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Gets the quote.
        /// </summary>
        /// <param name="delivery">The delivery.</param>
        /// <returns>System.Decimal.</returns>
        /// <exception cref="ShippingException">Delivery object cannot be null</exception>
        /// <exception cref="ShippingException">Delivery shipping option object cannot be null</exception>
        /// <exception cref="ShippingException">Delivery shipping carrier object cannot be null</exception>
        public decimal GetQuote(Delivery delivery)
        {
            decimal result = -1;
            if (delivery == null)
                throw new ShippingException("Delivery object cannot be null");
            if (delivery.ShippingOption == null)
                throw new ShippingException("Delivery shipping option object cannot be null");
            if (delivery.ShippingOption.ShippingCarrier == null)
                throw new ShippingException("Delivery shipping carrier object cannot be null");
            
            MethodInfo method = GetShippingProviderMethod(delivery.ShippingOption.ShippingCarrier, "GetQuote");
            if (method != null)
            {
                object r = null;
                object classInstance = GetShippingProviderClassInstance(delivery.ShippingOption.ShippingCarrier);
                object[] parametersArray = { delivery };
                try
                {
                    r = method.Invoke(classInstance, parametersArray);
                }
                catch (Exception exc)
                {
                    _logger.LogException("ShippingCarrierBL", "GetQuote", new ShippingException("Error calculating shipping cost using given shipping provider: " + delivery.ShippingOption.ShippingCarrier.Name, exc));
                    result = 0;
                }

                if (r != null)
                {
                    result = (decimal)r;
                }
            }
                    
            return result;
        }

        /// <summary>
        /// Initiates the delivery estimation.
        /// </summary>
        /// <param name="delivery">The delivery.</param>
        /// <returns></returns>
        public DeliveryResult InitiateDelivery(Delivery delivery)
        {
            if (delivery == null)
                throw new ShippingException("Delivery object cannot be null");
            if (delivery.ShippingOption == null)
                throw new ShippingException("Delivery shipping option object cannot be null");
            if (delivery.ShippingOption.ShippingCarrier == null)
                throw new ShippingException("Delivery shipping carrier object cannot be null");

            MethodInfo method = GetShippingProviderMethod(delivery.ShippingOption.ShippingCarrier, "InitiateDelivery");
            if(method != null)
            {
                object r = null;
                object classInstance = GetShippingProviderClassInstance(delivery.ShippingOption.ShippingCarrier);
                object[] parametersArray = { delivery };
                try
                {
                    r = method.Invoke(classInstance, parametersArray);
                    return (DeliveryResult)r;
                }
                catch (Exception exc)
                {
                    _logger.LogException("ShippingCarrierBL", "InitiateDelivery", new ShippingException("Error calculating shipping cost using given shipping provider: " + delivery.ShippingOption.ShippingCarrier.Name, exc));                    
                }
            }

            return null;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [support branch listing].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [support branch listing]; otherwise, <c>false</c>.
        /// </value>
        public bool SupportBranchListing(ShippingCarrier shippingCarrier)
        {
            if (shippingCarrier == null)
                throw new ShippingException("Delivery shipping carrier object cannot be null");
            var property = GetShippingProviderProperty(shippingCarrier, "SupportBranchListing");
            if(property != null)
            {
                try
                {
                    object classInstance = GetShippingProviderClassInstance(shippingCarrier);
                    return (bool)property.GetValue(classInstance, null);
                }
                catch (Exception exc)
                {
                    _logger.LogException("ShippingCarrierBL", "SupportBranchListing", new ShippingException("Error calculating shipping cost using given shipping provider: " + shippingCarrier.Name, exc));
                }
            }
            return false;
        }

        /// <summary>
        /// Searches the branches by the given address.
        /// </summary>
        /// <param name="shipToAddress">The ship to address.</param>
        /// <returns></returns>
        public IList<BranchInfo> SearchBranches(Delivery delivery)
        {
            if (delivery == null)
                throw new ShippingException("Delivery object cannot be null");
            if (delivery.ShippingOption == null)
                throw new ShippingException("Delivery shipping option object cannot be null");
            if (delivery.ShippingOption.ShippingCarrier == null)
                throw new ShippingException("Delivery shipping carrier object cannot be null");

            MethodInfo method = GetShippingProviderMethod(delivery.ShippingOption.ShippingCarrier, "SearchBranches");
            if (method != null)
            {
                object r = null;
                object classInstance = GetShippingProviderClassInstance(delivery.ShippingOption.ShippingCarrier);
                object[] parametersArray = { delivery };
                try
                {
                    r = method.Invoke(classInstance, parametersArray);
                    return (IList<BranchInfo>)r;
                }
                catch (Exception exc)
                {
                    _logger.LogException("ShippingCarrierBL", "SearchBranches", new ShippingException("Error calculating shipping cost using given shipping provider: " + delivery.ShippingOption.ShippingCarrier.Name, exc));
                }
            }
            return null;
        }

        /// <summary>
        /// Checks the custom configuration support.
        /// </summary>
        /// <param name="shippingCarrier">The shipping carrier.</param>
        /// <returns>CustomConfigSupport.</returns>
        public CustomConfigSupport CheckCustomConfigSupport(ShippingCarrier shippingCarrier)
        {
            if (shippingCarrier == null || string.IsNullOrEmpty(shippingCarrier.ShippingProviderAssembly)
                || string.IsNullOrEmpty(shippingCarrier.ShippingProviderClass))
                return null;

            bool configSupport = false;
            string exampleText = "";

            try
            {                
                object classInstance = GetShippingProviderClassInstance(shippingCarrier);
                PropertyInfo property = GetShippingProviderProperty(shippingCarrier, "SupportsCustomConfig");
                if (property != null)
                {
                    configSupport = (bool)property.GetValue(classInstance, null);
                }

                if (configSupport)
                {
                    property = GetShippingProviderProperty(shippingCarrier, "CustomConfigJsonExample");
                    if (property != null)
                    {
                        exampleText = property.GetValue(classInstance, null) as string;
                    }                            
                }
            }
            catch (Exception exc)
            {
                _logger.LogException("ShippingCarrierBL", "CheckCustomConfigSupport", new ShippingException("Error checking configuration support for the given shipping provider: " + shippingCarrier.Name, exc));
                configSupport = false;
                exampleText = "";
            }

            return new CustomConfigSupport
            {
                SupportsCustomConfig = configSupport,
                CustomConfigExample = exampleText
            };
        }

        /// <summary>
        /// Checks the custom option configuration support.
        /// </summary>
        /// <param name="shippingCarrier">The shipping carrier.</param>
        /// <returns>CustomConfigSupport.</returns>
        public CustomConfigSupport CheckCustomOptionConfigSupport(ShippingCarrier shippingCarrier)
        {
            if (shippingCarrier == null || string.IsNullOrEmpty(shippingCarrier.ShippingProviderAssembly)
                || string.IsNullOrEmpty(shippingCarrier.ShippingProviderClass))
                return null;

            bool configSupport = false;
            string exampleText = "";

            try
            {                
                object classInstance = GetShippingProviderClassInstance(shippingCarrier);
                PropertyInfo property = GetShippingProviderProperty(shippingCarrier, "SupportsOptionCustomConfig");
                if (property != null)
                {
                    configSupport = (bool)property.GetValue(classInstance, null);
                }

                if (configSupport)
                {
                    property = GetShippingProviderProperty(shippingCarrier, "CustomOptionConfigJsonExample");
                    if (property != null)
                    {
                        exampleText = property.GetValue(classInstance, null) as string;
                    }
                }                                    
            }
            catch (Exception exc)
            {
                _logger.LogException("ShippingCarrierBL", "CheckCustomOptionConfigSupport", new ShippingException("Error checking option configuration support for the given shipping provider: " + shippingCarrier.Name, exc));
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
        public ShippingCarrier GetDetails(ShippingCarrier ofEntity)
        {
            if (ofEntity == null)
                return null;

            if (ofEntity.Id > 0)
                return GetShippingCarrierById(ofEntity.Id);
            
            return null;
        }

        /// <summary>
        /// Inserts given entity into DB
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        public void AddSingleEntity(ShippingCarrier entity)
        {
            _eCommerceUnitOfWork.ShippingCarrierRepository.Add(entity);
            _eCommerceUnitOfWork.Save();
        }
        #endregion

        private MethodInfo GetShippingProviderMethod(ShippingCarrier shippingCarrier, string methodName)
        {
            if (!string.IsNullOrWhiteSpace(shippingCarrier.ShippingProviderAssembly) && !string.IsNullOrWhiteSpace(shippingCarrier.ShippingProviderClass))
            {
                var assembly = Assembly.Load(shippingCarrier.ShippingProviderAssembly);
                if (assembly != null)
                {
                    var type = assembly.GetType(shippingCarrier.ShippingProviderClass);
                    if (type != null && typeof(IShippingCarrierProvider).IsAssignableFrom(type))
                    {
                        MethodInfo method = type.GetMethod(methodName);
                        if (method != null)
                        {
                            return method;
                        }
                    }
                }
            }

            return null;
        }

        private PropertyInfo GetShippingProviderProperty(ShippingCarrier shippingCarrier, string propertyName)
        {
            if (!string.IsNullOrWhiteSpace(shippingCarrier.ShippingProviderAssembly) && !string.IsNullOrWhiteSpace(shippingCarrier.ShippingProviderClass))
            {
                var assembly = Assembly.Load(shippingCarrier.ShippingProviderAssembly);
                if (assembly != null)
                {
                    var type = assembly.GetType(shippingCarrier.ShippingProviderClass);
                    if (type != null && typeof(IShippingCarrierProvider).IsAssignableFrom(type))
                    {
                        PropertyInfo property = type.GetProperty(propertyName);
                        if (property != null)
                        {
                            return property;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the shipping provider class instance.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="customConfigJson">The custom configuration json.</param>
        /// <returns>System.Object.</returns>
        private object GetShippingProviderClassInstance(ShippingCarrier shippingCarrier)
        {
            var assembly = Assembly.Load(shippingCarrier.ShippingProviderAssembly);
            if (assembly != null)
            {
                var type = assembly.GetType(shippingCarrier.ShippingProviderClass);
                if (type != null && typeof(IShippingCarrierProvider).IsAssignableFrom(type))
                {
                    object[] constructorParams = new object[7];
                    constructorParams[0] = _lookupEngine;
                    constructorParams[1] = _fileProcessor;
                    constructorParams[2] = _configHelper;
                    constructorParams[3] = _authContext;
                    constructorParams[4] = _logger;
                    constructorParams[5] = shippingCarrier.CustomConfigJson;
                    constructorParams[6] = this;
                    return Activator.CreateInstance(type, constructorParams);
                }
            }

            return null;
        }
    }
    /// <summary>
    /// Class ShippingCarrierBL.
    /// Implements the <see cref="BAP.eCommerce.BL.eCommerceBusinessLayer" />
    /// Implements the <see cref="BAP.Common.ISupportLookup" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.BL.eCommerceBusinessLayer" />
    /// <seealso cref="BAP.Common.ISupportLookup" />
    public class ShippingCarrierBL : eCommerceBusinessLayer, ISupportLookup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShippingCarrierBL"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public ShippingCarrierBL(IConfigHelper settings, IAuthorizationContext context, ILogger logger) : base(null, null, settings, context, logger)
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
            var shippingCarriers = SearchShippingCarriers(extraFilter, orderBy);
            foreach (var shippingCarrier in shippingCarriers)
            {
                var val = shippingCarrier.GetType().GetProperty(valueField).GetValue(shippingCarrier, null);
                var text = shippingCarrier.GetType().GetProperty(textField).GetValue(shippingCarrier, null);
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = shippingCarrier.GetType().GetProperty(descriptionField).GetValue(shippingCarrier, null);
                }
                result.Add(new LookupItem { Key = val.ToString(), Text = text.ToString(), Description = descr != null ? descr.ToString() : "" });
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
            var shippingCarriers = await SearchShippingCarriersAsync(extraFilter, orderBy);
            foreach (var shippingCarrier in shippingCarriers)
            {
                var val = shippingCarrier.GetType().GetProperty(valueField).GetValue(shippingCarrier, null);
                var text = shippingCarrier.GetType().GetProperty(textField).GetValue(shippingCarrier, null);
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = shippingCarrier.GetType().GetProperty(descriptionField).GetValue(shippingCarrier, null);
                }
                result.Add(new LookupItem { Key = val.ToString(), Text = text.ToString(), Description = descr.ToString() });
            }

            return result;
        }
    }
}
