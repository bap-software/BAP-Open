// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="ShippingOptionBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Linq;

using PagedList;

using BAP.Common;
using BAP.eCommerce.DAL.Entities;
using BAP.eCommerce.BL.DataContracts;
using BAP.DAL;
using BAP.Log;
using System;
using System.Threading.Tasks;

namespace BAP.eCommerce.BL
{
    /// <summary>
    /// Interface IShippingOptionBL
    /// </summary>
    public interface IShippingOptionBL
    {
        /// <summary>
        /// Gets all shipping options.
        /// </summary>
        /// <returns>IList&lt;ShippingOption&gt;.</returns>
        IList<ShippingOption> GetAllShippingOptions();
        /// <summary>
        /// Gets all shipping options asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;ShippingOption&gt;&gt;.</returns>
        Task<IList<ShippingOption>> GetAllShippingOptionsAsync();

        /// <summary>
        /// Searches the shipping options.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ShippingOption&gt;.</returns>
        IPagedList<ShippingOption> SearchShippingOptions(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the shipping options asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;ShippingOption&gt;&gt;.</returns>
        Task<IPagedList<ShippingOption>> SearchShippingOptionsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Searches the shipping options.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;ShippingOption&gt;.</returns>
        IList<ShippingOption> SearchShippingOptions(string where, string sort);
        /// <summary>
        /// Searches the shipping options asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>Task&lt;IList&lt;ShippingOption&gt;&gt;.</returns>
        Task<IList<ShippingOption>> SearchShippingOptionsAsync(string where, string sort);

        /// <summary>
        /// Gets the shipping option by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShippingOption.</returns>
        ShippingOption GetShippingOptionById(int id);
        /// <summary>
        /// Gets the shipping option by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ShippingOption&gt;.</returns>
        Task<ShippingOption> GetShippingOptionByIdAsync(int id);

        /// <summary>
        /// Adds the shipping option.
        /// </summary>
        /// <param name="shippingOptions">The shipping options.</param>
        void AddShippingOption(params ShippingOption[] shippingOptions);
        /// <summary>
        /// Adds the shipping option asynchronous.
        /// </summary>
        /// <param name="shippingOptions">The shipping options.</param>
        /// <returns>Task.</returns>
        Task AddShippingOptionAsync(params ShippingOption[] shippingOptions);

        /// <summary>
        /// Updates the shipping option.
        /// </summary>
        /// <param name="shippingOptions">The shipping options.</param>
        void UpdateShippingOption(params ShippingOption[] shippingOptions);
        /// <summary>
        /// Updates the shipping option asynchronous.
        /// </summary>
        /// <param name="shippingOptions">The shipping options.</param>
        /// <returns>Task.</returns>
        Task UpdateShippingOptionAsync(params ShippingOption[] shippingOptions);

        /// <summary>
        /// Removes the shipping option.
        /// </summary>
        /// <param name="shippingOptions">The shipping options.</param>
        void RemoveShippingOption(params ShippingOption[] shippingOptions);
        /// <summary>
        /// Removes the shipping option asynchronous.
        /// </summary>
        /// <param name="shippingOptions">The shipping options.</param>
        /// <returns>Task.</returns>
        Task RemoveShippingOptionAsync(params ShippingOption[] shippingOptions);

        /// <summary>
        /// Adds the payment option.
        /// </summary>
        /// <param name="shippingOption">The shipping option.</param>
        /// <param name="paymentOption">The payment option.</param>
        void AddPaymentOption(ShippingOption shippingOption, PaymentOption paymentOption);
        /// <summary>
        /// Adds the payment option asynchronous.
        /// </summary>
        /// <param name="shippingOption">The shipping option.</param>
        /// <param name="paymentOption">The payment option.</param>
        /// <returns>Task.</returns>
        Task AddPaymentOptionAsync(ShippingOption shippingOption, PaymentOption paymentOption);

        /// <summary>
        /// Removes the payment option.
        /// </summary>
        /// <param name="shippingOption">The shipping option.</param>
        /// <param name="paymentOption">The payment option.</param>
        void RemovePaymentOption(ShippingOption shippingOption, PaymentOption paymentOption);
        /// <summary>
        /// Removes the payment option asynchronous.
        /// </summary>
        /// <param name="shippingOption">The shipping option.</param>
        /// <param name="paymentOption">The payment option.</param>
        /// <returns>Task.</returns>
        Task RemovePaymentOptionAsync(ShippingOption shippingOption, PaymentOption paymentOption);

        /// <summary>
        /// Gets the shipping options.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        /// <param name="shippingOptions">The shipping options.</param>
        /// <returns>IEnumerable&lt;ShippingOptionDC&gt;.</returns>
        IEnumerable<ShippingOptionDC> GetShippingOptions(ShoppingCart shoppingCart, IList<ShippingOption> shippingOptions = null);
        /// <summary>
        /// Gets the shipping options asynchronous.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        /// <param name="shippingOptions">The shipping options.</param>
        /// <returns>Task&lt;IEnumerable&lt;ShippingOptionDC&gt;&gt;.</returns>
        Task<IEnumerable<ShippingOptionDC>> GetShippingOptionsAsync(ShoppingCart shoppingCart, IList<ShippingOption> shippingOptions = null);

        /// <summary>
        /// Delivery object from the shopping cart.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        Delivery DeliveryFromSC(ShoppingCart shoppingCart, ShippingOption source = null);

        /// <summary>
        /// Searches the avalilable branches from the chosen shipping provider.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        /// <param name="shippingOptions">The shipping options.</param>
        /// <returns></returns>
        IEnumerable<BranchInfo> SearchAvalilableBranches(ShoppingCart shoppingCart);

        /// <summary>
        /// Initiates the delivery.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        /// <returns></returns>
        DeliveryResult InitiateDelivery(ShoppingCart shoppingCart);
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
    public partial class eCommerceBusinessLayer : IShippingOptionBL, ILocalizedBL<ShippingOption>
    {

        #region ShippingOptions

        /// <summary>
        /// Gets all shipping options.
        /// </summary>
        /// <returns>IList&lt;ShippingOption&gt;.</returns>
        public IList<ShippingOption> GetAllShippingOptions()
        {
            return _eCommerceUnitOfWork.ShippingOptionRepository.GetAll(a => a.ShippingCarrier, a => a.AllowedPaymentOptions);
        }

        /// <summary>
        /// get all shipping options as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;ShippingOption&gt;.</returns>
        public async Task<IList<ShippingOption>> GetAllShippingOptionsAsync()
        {
            return await _eCommerceUnitOfWork.ShippingOptionRepository.GetAllAsync(a => a.ShippingCarrier, a => a.AllowedPaymentOptions);
        }

        /// <summary>
        /// Searches the shipping options.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ShippingOption&gt;.</returns>
        public IPagedList<ShippingOption> SearchShippingOptions(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<ShippingOption>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _eCommerceUnitOfWork.ShippingOptionRepository.GetPagedList(page, pageSize, ParseJSONSearchString<ShippingOption>(where), sortExpression, a => a.ShippingCarrier, a => a.AllowedPaymentOptions);
        }

        /// <summary>
        /// search shipping options as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ShippingOption&gt;.</returns>
        public async Task<IPagedList<ShippingOption>> SearchShippingOptionsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<ShippingOption>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return await _eCommerceUnitOfWork.ShippingOptionRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<ShippingOption>(where), sortExpression, a => a.ShippingCarrier, a => a.AllowedPaymentOptions);
        }

        /// <summary>
        /// Searches the shipping options.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;ShippingOption&gt;.</returns>
        public IList<ShippingOption> SearchShippingOptions(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<ShippingOption>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _eCommerceUnitOfWork.ShippingOptionRepository.GetList(ParseJSONSearchString<ShippingOption>(where), sortExpression, a => a.ShippingCarrier, a => a.AllowedPaymentOptions);
        }

        /// <summary>
        /// search shipping options as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;ShippingOption&gt;.</returns>
        public async Task<IList<ShippingOption>> SearchShippingOptionsAsync(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<ShippingOption>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return await _eCommerceUnitOfWork.ShippingOptionRepository.GetListAsync(ParseJSONSearchString<ShippingOption>(where), sortExpression, a => a.ShippingCarrier, a => a.AllowedPaymentOptions);
        }

        /// <summary>
        /// Gets the shipping option by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShippingOption.</returns>
        public ShippingOption GetShippingOptionById(int id)
        {
            return _eCommerceUnitOfWork.ShippingOptionRepository.GetSingle(a => a.Id == id, a => a.ShippingCarrier, a => a.AllowedPaymentOptions);
        }

        /// <summary>
        /// get shipping option by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ShippingOption.</returns>
        public async Task<ShippingOption> GetShippingOptionByIdAsync(int id)
        {
            return await _eCommerceUnitOfWork.ShippingOptionRepository.GetSingleAsync(a => a.Id == id, a => a.ShippingCarrier, a => a.AllowedPaymentOptions);
        }

        /// <summary>
        /// Adds the shipping option.
        /// </summary>
        /// <param name="shippingOptions">The shipping options.</param>
        public void AddShippingOption(params ShippingOption[] shippingOptions)
        {
            _eCommerceUnitOfWork.ShippingOptionRepository.Add(shippingOptions);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// add shipping option as an asynchronous operation.
        /// </summary>
        /// <param name="shippingOptions">The shipping options.</param>
        public async Task AddShippingOptionAsync(params ShippingOption[] shippingOptions)
        {
            _eCommerceUnitOfWork.ShippingOptionRepository.Add(shippingOptions);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the shipping option.
        /// </summary>
        /// <param name="shippingOptions">The shipping options.</param>
        public void UpdateShippingOption(params ShippingOption[] shippingOptions)
        {
            _eCommerceUnitOfWork.ShippingOptionRepository.Update(shippingOptions);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// update shipping option as an asynchronous operation.
        /// </summary>
        /// <param name="shippingOptions">The shipping options.</param>
        public async Task UpdateShippingOptionAsync(params ShippingOption[] shippingOptions)
        {
            _eCommerceUnitOfWork.ShippingOptionRepository.Update(shippingOptions);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the shipping option.
        /// </summary>
        /// <param name="shippingOptions">The shipping options.</param>
        public void RemoveShippingOption(params ShippingOption[] shippingOptions)
        {
            _eCommerceUnitOfWork.ShippingOptionRepository.Remove(shippingOptions);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// remove shipping option as an asynchronous operation.
        /// </summary>
        /// <param name="shippingOptions">The shipping options.</param>
        public async Task RemoveShippingOptionAsync(params ShippingOption[] shippingOptions)
        {
            _eCommerceUnitOfWork.ShippingOptionRepository.Remove(shippingOptions);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Adds the payment option.
        /// </summary>
        /// <param name="shippingOption">The shipping option.</param>
        /// <param name="paymentOption">The payment option.</param>
        public void AddPaymentOption(ShippingOption shippingOption, PaymentOption paymentOption)
        {
            if (shippingOption == null || paymentOption == null)
                return;

            if (shippingOption.AllowedPaymentOptions != null && shippingOption.AllowedPaymentOptions.All(a => a.Id != paymentOption.Id))
            {
                _eCommerceUnitOfWork.ShippingOptionRepository.AttachIfDetached(shippingOption);
                _eCommerceUnitOfWork.PaymentOptionRepository.AttachIfDetached(paymentOption);
                shippingOption.AllowedPaymentOptions.Add(paymentOption);
                _eCommerceUnitOfWork.Save();
            }
        }

        /// <summary>
        /// add payment option as an asynchronous operation.
        /// </summary>
        /// <param name="shippingOption">The shipping option.</param>
        /// <param name="paymentOption">The payment option.</param>
        public async Task AddPaymentOptionAsync(ShippingOption shippingOption, PaymentOption paymentOption)
        {
            if (shippingOption == null || paymentOption == null)
                return;

            if (shippingOption.AllowedPaymentOptions != null && shippingOption.AllowedPaymentOptions.All(a => a.Id != paymentOption.Id))
            {
                _eCommerceUnitOfWork.ShippingOptionRepository.AttachIfDetached(shippingOption);
                _eCommerceUnitOfWork.PaymentOptionRepository.AttachIfDetached(paymentOption);
                shippingOption.AllowedPaymentOptions.Add(paymentOption);
                await _eCommerceUnitOfWork.SaveAsync();
            }
        }

        /// <summary>
        /// Removes the payment option.
        /// </summary>
        /// <param name="shippingOption">The shipping option.</param>
        /// <param name="paymentOption">The payment option.</param>
        public void RemovePaymentOption(ShippingOption shippingOption, PaymentOption paymentOption)
        {
            if (shippingOption == null || paymentOption == null)
                return;

            if (shippingOption.AllowedPaymentOptions != null && shippingOption.AllowedPaymentOptions.Any(a => a.Id == paymentOption.Id))
            {
                _eCommerceUnitOfWork.ShippingOptionRepository.AttachIfDetached(shippingOption);
                var itemToRemove = shippingOption.AllowedPaymentOptions.SingleOrDefault(a => a.Id == paymentOption.Id);
                shippingOption.AllowedPaymentOptions.Remove(itemToRemove);
                _eCommerceUnitOfWork.Save();
            }
        }

        /// <summary>
        /// remove payment option as an asynchronous operation.
        /// </summary>
        /// <param name="shippingOption">The shipping option.</param>
        /// <param name="paymentOption">The payment option.</param>
        public async Task RemovePaymentOptionAsync(ShippingOption shippingOption, PaymentOption paymentOption)
        {
            if (shippingOption == null || paymentOption == null)
                return;

            if (shippingOption.AllowedPaymentOptions != null && shippingOption.AllowedPaymentOptions.Any(a => a.Id == paymentOption.Id))
            {
                _eCommerceUnitOfWork.ShippingOptionRepository.AttachIfDetached(shippingOption);
                var itemToRemove = shippingOption.AllowedPaymentOptions.SingleOrDefault(a => a.Id == paymentOption.Id);
                shippingOption.AllowedPaymentOptions.Remove(itemToRemove);
                await _eCommerceUnitOfWork.SaveAsync();
            }
        }

        /// <summary>
        /// Gets the shipping options.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        /// <param name="shippingOptions">The shipping options.</param>
        /// <returns>IEnumerable&lt;ShippingOptionDC&gt;.</returns>
        public IEnumerable<ShippingOptionDC> GetShippingOptions(ShoppingCart shoppingCart, IList<ShippingOption> shippingOptions = null)
        {
            // Get list of shipping options 
            if (shippingOptions == null || !shippingOptions.Any())
                shippingOptions = GetAllShippingOptions();
            var result =
                from item in shippingOptions
                where item.Enabled
                orderby item.Name
                select InitDataContract(item);
            var ret = result.ToArray();

            bool isChecked = false;
            if (shoppingCart != null)
            {
                foreach (var option in shippingOptions.Where(a => a.Enabled))
                {
                    var retItem = ret.SingleOrDefault(a => a.Id == option.Id);
                    CalculateShippingCost(shoppingCart, option, retItem);
                    if (shoppingCart.ShippingOptionId > 0)
                    {
                        var currentId = shoppingCart.ShippingOptionId;
                        if (!isChecked && (currentId == 0 || currentId == option.Id))
                        {
                            if (retItem != null) retItem.Selected = true;
                            isChecked = true;
                        }
                    }
                }
            }

            // If nothing selected just choose 1st one
            if (!isChecked && ret.Length > 0)
            {
                ret[0].Selected = true;
            }

            return ret;
        }

        /// <summary>
        /// get shipping options as an asynchronous operation.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        /// <param name="shippingOptions">The shipping options.</param>
        /// <returns>IEnumerable&lt;ShippingOptionDC&gt;.</returns>
        public async Task<IEnumerable<ShippingOptionDC>> GetShippingOptionsAsync(ShoppingCart shoppingCart, IList<ShippingOption> shippingOptions = null)
        {
            // Get list of shipping options 
            if (shippingOptions == null)
                shippingOptions = await GetAllShippingOptionsAsync();
            var result =
                from item in shippingOptions
                where item.Enabled
                orderby item.Name
                select InitDataContract(item);
            var ret = result.ToArray();

            bool isChecked = false;

            if (shoppingCart != null)
            {
                foreach (var option in shippingOptions.Where(a => a.Enabled))
                {
                    var retItem = ret.SingleOrDefault(a => a.Id == option.Id);
                    CalculateShippingCost(shoppingCart, option, retItem);
                    if (shoppingCart.ShippingOptionId > 0)
                    {
                        var currentId = shoppingCart.ShippingOptionId;
                        if (!isChecked && (currentId == 0 || currentId == option.Id))
                        {
                            if (retItem != null) retItem.Selected = true;
                            isChecked = true;
                        }
                    }
                }
            }

            // If nothing selected just choose 1st one
            if (!isChecked && ret.Length > 0)
            {
                ret[0].Selected = true;
            }

            return ret;
        }

        public IEnumerable<BranchInfo> SearchAvalilableBranches(ShoppingCart shoppingCart)
        {
            if(shoppingCart != null && shoppingCart.ShippingOption != null && shoppingCart.ShippingOption.ShippingCarrier != null)
            {
                IShippingCarrierBL providerBl = this;
                if (providerBl.SupportBranchListing(shoppingCart.ShippingOption.ShippingCarrier))
                {
                    var delivery = DeliveryFromSC(shoppingCart);
                    return providerBl.SearchBranches(delivery);
                }
                    
            }
            return null;
        }

        public DeliveryResult InitiateDelivery(ShoppingCart shoppingCart)
        {
            if (shoppingCart != null && shoppingCart.ShippingOption != null && shoppingCart.ShippingOption.ShippingCarrier != null)
            {
                IShippingCarrierBL providerBl = this;
                var delivery = DeliveryFromSC(shoppingCart);
                return providerBl.InitiateDelivery(delivery);
            }

            return new DeliveryResult {
                Success = false,
                Message = "Incorrect input parameters of the call."
            };
        }

        #endregion

        #region ILocalizedBL
        /// <summary>
        /// Get full details of the single entity
        /// </summary>
        /// <param name="ofEntity">Passed entity is used as filter, method implementing ths feature should treat this oject apropriatly to call some method of BL class to read full details.</param>
        /// <returns>Entity instance</returns>
        public ShippingOption GetDetails(ShippingOption ofEntity)
        {
            if (ofEntity == null)
                return null;

            if (ofEntity.Id > 0)
                return GetShippingOptionById(ofEntity.Id);
            
            return null;
        }

        /// <summary>
        /// Inserts given entity into DB
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        public void AddSingleEntity(ShippingOption entity)
        {
            _eCommerceUnitOfWork.ShippingOptionRepository.Add(entity);
            _eCommerceUnitOfWork.Save();
        }
        #endregion

        #region private methods
        /// <summary>
        /// Initializes the data contract.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>ShippingOptionDC.</returns>
        private ShippingOptionDC InitDataContract(ShippingOption item)
        {
            ShippingOptionDC ret = null;
            if (item?.ShippingCarrier != null)
            {
                ret = new ShippingOptionDC
                {
                    Code = item.OptionCode,
                    Description = item.Description,
                    Enabled = item.Enabled,
                    Icon = item.TeaserImage,
                    Id = item.Id,
                    Name = item.Name,
                    ShippingCarrierId = item.ShippingCarrier.Id,
                    ShippingCarrierName = item.ShippingCarrier.Name,
                    ShortDescription = item.ShortDescription
                };
            }
            return ret;
        }

        /// <summary>
        /// Calculates the shipping cost.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        private void CalculateShippingCost(ShoppingCart shoppingCart, ShippingOption source, ShippingOptionDC target)
        {
            IShippingCarrierBL providerBl = this;            
            var delivery = DeliveryFromSC(shoppingCart, source);            
            target.BasicCost = providerBl.GetQuote(delivery);
        }

        /// <summary>
        /// Initiate Delivery instance from the given shopping cart and some extra shipping option.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public Delivery DeliveryFromSC(ShoppingCart shoppingCart, ShippingOption source = null)
        {
            IStoreBL storeBl = this;
            IShoppingCartBL scBL = this;
            var store = storeBl.GetDefaultStore();
            Address fromAddress = null;
            if (store != null)
            {
                fromAddress = store.ShippingAddress ?? store.BillingAddress;
            }

            var delivery = new Delivery
            {
                ShippingOption = source ?? shoppingCart.ShippingOption,
                FromAddress = fromAddress,
                ShipToAddress = shoppingCart.ShippingAddress ?? shoppingCart.BillingAddress,
                Items = new List<DeliveryItem>(),
                ProductsTotal = (decimal)(shoppingCart.Total ?? 0)
            };

            var customData = scBL.GetShoppingCartCustomData(shoppingCart);
            if(customData != null)
            {
                delivery.ShipToBranchRef = customData.ShipToBranchCode;
            }

            foreach (var scProduct in shoppingCart.ShoppingCartProducts)
            {
                var product = scProduct.Product;
                if (product == null && scProduct.ProductId > 0)
                {
                    product = ((IProductBL)this).GetProductById(scProduct.ProductId.Value);
                }
                if (product == null)
                    continue;

                delivery.Items.Add(new DeliveryItem
                {
                    Product = product,
                    Count = scProduct.Count
                });                
            }

            return delivery;
        }
        #endregion
    }

    /// <summary>
    /// Class ShippingOptionBL.
    /// Implements the <see cref="BAP.eCommerce.BL.eCommerceBusinessLayer" />
    /// Implements the <see cref="BAP.Common.ISupportLookup" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.BL.eCommerceBusinessLayer" />
    /// <seealso cref="BAP.Common.ISupportLookup" />
    public class ShippingOptionBL : eCommerceBusinessLayer, ISupportLookup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShippingOptionBL"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public ShippingOptionBL(IConfigHelper settings, IAuthorizationContext context, ILogger logger) : base(null, null, settings, context, logger)
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
            var shippingOptions = SearchShippingOptions(extraFilter, orderBy);
            foreach (var shippingOption in shippingOptions)
            {
                var val = shippingOption.GetType().GetProperty(valueField).GetValue(shippingOption, null);
                var text = shippingOption.GetType().GetProperty(textField).GetValue(shippingOption, null);
                if (shippingOption.ShippingCarrier != null)
                {
                    text = shippingOption.ShippingCarrier.Name + " " + text;
                }
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
            var shippingOptions = await SearchShippingOptionsAsync(extraFilter, orderBy);
            foreach (var shippingOption in shippingOptions)
            {
                var val = shippingOption.GetType().GetProperty(valueField).GetValue(shippingOption, null);
                var text = shippingOption.GetType().GetProperty(textField).GetValue(shippingOption, null);
                if (shippingOption.ShippingCarrier != null)
                {
                    text = shippingOption.ShippingCarrier.Name + " " + text;
                }
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
