// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="StoreBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

using PagedList;

using BAP.Common;
using BAP.eCommerce.DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace BAP.eCommerce.BL
{
    /// <summary>
    /// Interface IStoreBL
    /// </summary>
    public interface IStoreBL
    {
        /// <summary>
        /// Gets all stores.
        /// </summary>
        /// <returns>IList&lt;Store&gt;.</returns>
        IList<Store> GetAllStores();
        /// <summary>
        /// Gets all stores asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;Store&gt;&gt;.</returns>
        Task<IList<Store>> GetAllStoresAsync();

        /// <summary>
        /// Searches the stores.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Store&gt;.</returns>
        IPagedList<Store> SearchStores(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the stores asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;Store&gt;&gt;.</returns>
        Task<IPagedList<Store>> SearchStoresAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Searches the stores.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;Store&gt;.</returns>
        IList<Store> SearchStores(string where, string sort);
        /// <summary>
        /// Searches the stores asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>Task&lt;IList&lt;Store&gt;&gt;.</returns>
        Task<IList<Store>> SearchStoresAsync(string where, string sort);

        /// <summary>
        /// Gets the store by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Store.</returns>
        Store GetStoreById(int id);
        /// <summary>
        /// Gets the store by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Store&gt;.</returns>
        Task<Store> GetStoreByIdAsync(int id);

        /// <summary>
        /// Gets the default store.
        /// </summary>
        /// <returns>Store.</returns>
        Store GetDefaultStore();
        /// <summary>
        /// Gets the default store asynchronous.
        /// </summary>
        /// <returns>Task&lt;Store&gt;.</returns>
        Task<Store> GetDefaultStoreAsync();

        /// <summary>
        /// Adds the store.
        /// </summary>
        /// <param name="stores">The stores.</param>
        void AddStore(params Store[] stores);
        /// <summary>
        /// Adds the store asynchronous.
        /// </summary>
        /// <param name="stores">The stores.</param>
        /// <returns>Task.</returns>
        Task AddStoreAsync(params Store[] stores);

        /// <summary>
        /// Updates the store.
        /// </summary>
        /// <param name="stores">The stores.</param>
        void UpdateStore(params Store[] stores);
        /// <summary>
        /// Updates the store asynchronous.
        /// </summary>
        /// <param name="stores">The stores.</param>
        /// <returns>Task.</returns>
        Task UpdateStoreAsync(params Store[] stores);

        /// <summary>
        /// Removes the store.
        /// </summary>
        /// <param name="stores">The stores.</param>
        void RemoveStore(params Store[] stores);
        /// <summary>
        /// Removes the store asynchronous.
        /// </summary>
        /// <param name="stores">The stores.</param>
        /// <returns>Task.</returns>
        Task RemoveStoreAsync(params Store[] stores);

        /// <summary>
        /// Initializes the subordinate entities.
        /// </summary>
        /// <param name="store">The store.</param>
        void InitSubordinateEntities(Store store);

        /// <summary>
        /// Adds the payment option.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="paymentOption">The payment option.</param>
        void AddPaymentOption(Store store, PaymentOption paymentOption);
        /// <summary>
        /// Adds the payment option asynchronous.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="paymentOption">The payment option.</param>
        /// <returns>Task.</returns>
        Task AddPaymentOptionAsync(Store store, PaymentOption paymentOption);

        /// <summary>
        /// Removes the payment option.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="paymentOption">The payment option.</param>
        void RemovePaymentOption(Store store, PaymentOption paymentOption);
        /// <summary>
        /// Removes the payment option asynchronous.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="paymentOption">The payment option.</param>
        /// <returns>Task.</returns>
        Task RemovePaymentOptionAsync(Store store, PaymentOption paymentOption);

        /// <summary>
        /// Adds the shipping option.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="shippingOption">The shipping option.</param>
        void AddShippingOption(Store store, ShippingOption shippingOption);
        /// <summary>
        /// Adds the shipping option asynchronous.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="shippingOption">The shipping option.</param>
        /// <returns>Task.</returns>
        Task AddShippingOptionAsync(Store store, ShippingOption shippingOption);

        /// <summary>
        /// Removes the shipping option.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="shippingOption">The shipping option.</param>
        void RemoveShippingOption(Store store, ShippingOption shippingOption);
        /// <summary>
        /// Removes the shipping option asynchronous.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="shippingOption">The shipping option.</param>
        /// <returns>Task.</returns>
        Task RemoveShippingOptionAsync(Store store, ShippingOption shippingOption);

        /// <summary>
        /// Adds the product category.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="productCategory">The product category.</param>
        void AddProductCategory(Store store, ProductCategory productCategory);
        /// <summary>
        /// Adds the product category asynchronous.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="productCategory">The product category.</param>
        /// <returns>Task.</returns>
        Task AddProductCategoryAsync(Store store, ProductCategory productCategory);

        /// <summary>
        /// Removes the product category.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="productCategory">The product category.</param>
        void RemoveProductCategory(Store store, ProductCategory productCategory);
        /// <summary>
        /// Removes the product category asynchronous.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="productCategory">The product category.</param>
        /// <returns>Task.</returns>
        Task RemoveProductCategoryAsync(Store store, ProductCategory productCategory);

        /// <summary>
        /// Adds the discount coupon.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="discountCoupon">The discount coupon.</param>
        void AddDiscountCoupon(Store store, DiscountCoupon discountCoupon);
        /// <summary>
        /// Adds the discount coupon asynchronous.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="discountCoupon">The discount coupon.</param>
        /// <returns>Task.</returns>
        Task AddDiscountCouponAsync(Store store, DiscountCoupon discountCoupon);

        /// <summary>
        /// Removes the discount coupon.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="discountCoupon">The discount coupon.</param>
        void RemoveDiscountCoupon(Store store, DiscountCoupon discountCoupon);
        /// <summary>
        /// Removes the discount coupon asynchronous.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="discountCoupon">The discount coupon.</param>
        /// <returns>Task.</returns>
        Task RemoveDiscountCouponAsync(Store store, DiscountCoupon discountCoupon);
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
    public partial class eCommerceBusinessLayer : IStoreBL
    {
        #region Stores

        /// <summary>
        /// Gets all stores.
        /// </summary>
        /// <returns>IList&lt;Store&gt;.</returns>
        public IList<Store> GetAllStores()
        {
            return _eCommerceUnitOfWork.StoreRepository.GetAll(s => s.AdminUser, s => s.Organization, s => s.BillingAddress, s => s.ShippingAddress);
        }

        /// <summary>
        /// get all stores as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;Store&gt;.</returns>
        public async Task<IList<Store>> GetAllStoresAsync()
        {
            return await _eCommerceUnitOfWork.StoreRepository.GetAllAsync(s => s.AdminUser, s => s.Organization, s => s.BillingAddress, s => s.ShippingAddress);
        }

        /// <summary>
        /// Searches the stores.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Store&gt;.</returns>
        public IPagedList<Store> SearchStores(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Store>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _eCommerceUnitOfWork.StoreRepository.GetPagedList(page, pageSize, ParseJSONSearchString<Store>(where), sortExpression,
                s => s.AdminUser, s => s.Organization, s => s.BillingAddress, s => s.ShippingAddress);
        }

        /// <summary>
        /// search stores as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Store&gt;.</returns>
        public async Task<IPagedList<Store>> SearchStoresAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Store>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return await _eCommerceUnitOfWork.StoreRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<Store>(where), sortExpression,
                s => s.AdminUser, s => s.Organization, s => s.BillingAddress, s => s.ShippingAddress);
        }

        /// <summary>
        /// Searches the stores.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;Store&gt;.</returns>
        public IList<Store> SearchStores(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Store>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _eCommerceUnitOfWork.StoreRepository.GetList(ParseJSONSearchString<Store>(where), sortExpression,
                s => s.AdminUser, s => s.Organization, s => s.BillingAddress, s => s.ShippingAddress);
        }

        /// <summary>
        /// search stores as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;Store&gt;.</returns>
        public async Task<IList<Store>> SearchStoresAsync(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Store>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return await _eCommerceUnitOfWork.StoreRepository.GetListAsync(ParseJSONSearchString<Store>(where), sortExpression,
                s => s.AdminUser, s => s.Organization, s => s.BillingAddress, s => s.ShippingAddress);
        }

        /// <summary>
        /// Gets the store by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Store.</returns>
        public Store GetStoreById(int id)
        {
            var store = _eCommerceUnitOfWork.StoreRepository.GetSingle(a => a.Id == id, s => s.AdminUser, s => s.Organization, s => s.BillingAddress, 
                s => s.ShippingAddress, s => s.StorePaymentOptions, s => s.StoreShippingOptions, s => s.StoreProductCategories, s => s.StoreDiscountCoupons);            
            return ProcessOnSelect(store);
        }

        /// <summary>
        /// get store by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Store.</returns>
        public async Task<Store> GetStoreByIdAsync(int id)
        {
            var store = await _eCommerceUnitOfWork.StoreRepository.GetSingleAsync(a => a.Id == id, s => s.AdminUser, s => s.Organization, s => s.BillingAddress,
                s => s.ShippingAddress, s => s.StorePaymentOptions, s => s.StoreShippingOptions, s => s.StoreProductCategories, s => s.StoreDiscountCoupons);
            
            return await ProcessOnSelectAsync(store);
        }

        /// <summary>
        /// Gets the single store by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Store.</returns>
        public Store GetSingleStoreById(int id)
        {
            return ProcessOnSelect(_eCommerceUnitOfWork.StoreRepository.GetSingle(a => a.Id == id));
        }

        /// <summary>
        /// Gets the default store.
        /// </summary>
        /// <returns>Store.</returns>
        public Store GetDefaultStore()
        {
            var currOrgId = _authContext.GetCurrentOrganizationId(_configHelper);
            var key = "ECOMM_DEFAULT_STORE_KEY_" + currOrgId.ToString();
            Store store = (Store)_cache[key];
            if(store == null)
            {
                store = _eCommerceUnitOfWork.StoreRepository.GetSingle(a => a.OrganizationId == currOrgId && a.IsDefault, a => a.AdminUser, a => a.BillingAddress, a => a.ShippingAddress, a => a.StoreDiscountCoupons, a => a.StorePaymentOptions, a => a.StoreProductCategories, a => a.StoreShippingOptions);
                store = ProcessOnSelect(store);
                _cache[key] = store;
            }
            return store;
        }

        /// <summary>
        /// get default store as an asynchronous operation.
        /// </summary>
        /// <returns>Store.</returns>
        public async Task<Store> GetDefaultStoreAsync()
        {
            var currOrgId = _authContext.GetCurrentOrganizationId(_configHelper);
            var store = await _eCommerceUnitOfWork.StoreRepository.GetSingleAsync(a => a.OrganizationId == currOrgId && a.IsDefault, a => a.AdminUser, a => a.BillingAddress, a => a.ShippingAddress, a => a.StoreDiscountCoupons, a => a.StorePaymentOptions, a => a.StoreProductCategories, a => a.StoreShippingOptions);            
            return await ProcessOnSelectAsync(store);
        }

        /// <summary>
        /// Initializes the subordinate entities.
        /// </summary>
        /// <param name="store">The store.</param>
        public void InitSubordinateEntities(Store store)
        {
            if (store.BillingAddress == null)
            {
                store.BillingAddress = new Address();
                _eCommerceUnitOfWork.AddressRepository.InitEntityData(store.BillingAddress);
            }
            if (store.ShippingAddress == null)
            {
                store.ShippingAddress = new Address();
                _eCommerceUnitOfWork.AddressRepository.InitEntityData(store.ShippingAddress);
            }
        }

        /// <summary>
        /// Processes the on select.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <returns>Store.</returns>
        private Store ProcessOnSelect(Store store)
        {
            if (store != null)
                store.InvoiceTemplateInstance = GetDocumentTemplateByName(store.InvoiceTemplate);
            return store;
        }


        /// <summary>
        /// process on select as an asynchronous operation.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <returns>Store.</returns>
        private async Task<Store> ProcessOnSelectAsync(Store store)
        {
            if (store != null)
                store.InvoiceTemplateInstance = await GetDocumentTemplateByNameAsync(store.InvoiceTemplate);
            return store;
        }

        /// <summary>
        /// Resets the is default.
        /// </summary>
        /// <param name="stores">The stores.</param>
        private void ResetIsDefault(params Store[] stores)
        {
            var isDefaultChanged = stores.Any(s => s.IsDefault);
            if (isDefaultChanged)
            {
                var allStores = _eCommerceUnitOfWork.StoreRepository.GetAll();
                foreach (var store in allStores)
                {
                    if (stores.Any(s => s.Id == store.Id))
                        continue;
                    store.IsDefault = false;
                    _eCommerceUnitOfWork.StoreRepository.Update(store);
                    _eCommerceUnitOfWork.Save();
                }
            }
        }

        /// <summary>
        /// Adds the store.
        /// </summary>
        /// <param name="stores">The stores.</param>
        public void AddStore(params Store[] stores)
        {
            ResetIsDefault(stores);
            _eCommerceUnitOfWork.StoreRepository.Add(stores);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// add store as an asynchronous operation.
        /// </summary>
        /// <param name="stores">The stores.</param>
        public async Task AddStoreAsync(params Store[] stores)
        {
            ResetIsDefault(stores);
            _eCommerceUnitOfWork.StoreRepository.Add(stores);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the store.
        /// </summary>
        /// <param name="stores">The stores.</param>
        public void UpdateStore(params Store[] stores)
        {
            ResetIsDefault(stores);
            foreach (var store in stores)
            {
                if (store.BillingAddress.Id > 0)
                {
                    store.BillingAddress.EntityState = BAPEntityState.Modified;
                    _eCommerceUnitOfWork.AddressRepository.Update(store.BillingAddress);
                }
                else
                {
                    store.BillingAddress.EntityState = BAPEntityState.Added;
                    _eCommerceUnitOfWork.AddressRepository.Add(store.BillingAddress);
                    _eCommerceUnitOfWork.Save();
                    store.BillingAddressId = store.BillingAddress.Id;
                }
                if (store.ShippingAddress.Id > 0)
                {
                    store.ShippingAddress.EntityState = BAPEntityState.Modified;
                    _eCommerceUnitOfWork.AddressRepository.Update(store.ShippingAddress);
                }
                else
                {
                    store.ShippingAddress.EntityState = BAPEntityState.Added;
                    _eCommerceUnitOfWork.AddressRepository.Add(store.ShippingAddress);
                    _eCommerceUnitOfWork.Save();
                    store.ShippingAddressId = store.ShippingAddress.Id;
                }
            }
            _eCommerceUnitOfWork.StoreRepository.Update(stores);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// update store as an asynchronous operation.
        /// </summary>
        /// <param name="stores">The stores.</param>
        public async Task UpdateStoreAsync(params Store[] stores)
        {
            ResetIsDefault(stores);
            foreach (var store in stores)
            {
                if (store.BillingAddress.Id > 0)
                {
                    store.BillingAddress.EntityState = BAPEntityState.Modified;
                    _eCommerceUnitOfWork.AddressRepository.Update(store.BillingAddress);
                }
                else
                {
                    store.BillingAddress.EntityState = BAPEntityState.Added;
                    _eCommerceUnitOfWork.AddressRepository.Add(store.BillingAddress);
                    await _eCommerceUnitOfWork.SaveAsync();
                    store.BillingAddressId = store.BillingAddress.Id;
                }
                if (store.ShippingAddress.Id > 0)
                {
                    store.ShippingAddress.EntityState = BAPEntityState.Modified;
                    _eCommerceUnitOfWork.AddressRepository.Update(store.ShippingAddress);
                }
                else
                {
                    store.ShippingAddress.EntityState = BAPEntityState.Added;
                    _eCommerceUnitOfWork.AddressRepository.Add(store.ShippingAddress);
                    await _eCommerceUnitOfWork.SaveAsync();
                    store.ShippingAddressId = store.ShippingAddress.Id;
                }
            }
            _eCommerceUnitOfWork.StoreRepository.Update(stores);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the store.
        /// </summary>
        /// <param name="stores">The stores.</param>
        public void RemoveStore(params Store[] stores)
        {
            _eCommerceUnitOfWork.StoreRepository.Remove(stores);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// remove store as an asynchronous operation.
        /// </summary>
        /// <param name="stores">The stores.</param>
        public async Task RemoveStoreAsync(params Store[] stores)
        {
            _eCommerceUnitOfWork.StoreRepository.Remove(stores);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Adds the payment option.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="paymentOption">The payment option.</param>
        public void AddPaymentOption(Store store, PaymentOption paymentOption)
        {
            if (store == null || paymentOption == null)
                return;

            if (store.StorePaymentOptions == null)
                store.StorePaymentOptions = new List<PaymentOption>();

            if (store.StorePaymentOptions.All(a => a.Id != paymentOption.Id))
            {
                _eCommerceUnitOfWork.StoreRepository.AttachIfDetached(store);
                _eCommerceUnitOfWork.PaymentOptionRepository.AttachIfDetached(paymentOption);
                store.StorePaymentOptions.Add(paymentOption);
                _eCommerceUnitOfWork.Save();
            }
        }

        /// <summary>
        /// add payment option as an asynchronous operation.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="paymentOption">The payment option.</param>
        public async Task AddPaymentOptionAsync(Store store, PaymentOption paymentOption)
        {
            if (store == null || paymentOption == null)
                return;

            if (store.StorePaymentOptions == null)
                store.StorePaymentOptions = new List<PaymentOption>();

            if (store.StorePaymentOptions.All(a => a.Id != paymentOption.Id))
            {
                _eCommerceUnitOfWork.StoreRepository.AttachIfDetached(store);
                _eCommerceUnitOfWork.PaymentOptionRepository.AttachIfDetached(paymentOption);
                store.StorePaymentOptions.Add(paymentOption);
                await _eCommerceUnitOfWork.SaveAsync();
            }

        }

        /// <summary>
        /// Removes the payment option.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="paymentOption">The payment option.</param>
        public void RemovePaymentOption(Store store, PaymentOption paymentOption)
        {
            if (store == null || paymentOption == null)
                return;

            if (store.StorePaymentOptions != null && store.StorePaymentOptions.Any(a => a.Id == paymentOption.Id))
            {
                _eCommerceUnitOfWork.StoreRepository.AttachIfDetached(store);
                var itemToRemove = store.StorePaymentOptions.SingleOrDefault(a => a.Id == paymentOption.Id);
                store.StorePaymentOptions.Remove(itemToRemove);
                _eCommerceUnitOfWork.Save();
            }
        }

        /// <summary>
        /// remove payment option as an asynchronous operation.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="paymentOption">The payment option.</param>
        public async Task RemovePaymentOptionAsync(Store store, PaymentOption paymentOption)
        {
            if (store == null || paymentOption == null)
                return;

            if (store.StorePaymentOptions != null && store.StorePaymentOptions.Any(a => a.Id == paymentOption.Id))
            {
                _eCommerceUnitOfWork.StoreRepository.AttachIfDetached(store);
                var itemToRemove = store.StorePaymentOptions.SingleOrDefault(a => a.Id == paymentOption.Id);
                store.StorePaymentOptions.Remove(itemToRemove);
                await _eCommerceUnitOfWork.SaveAsync();
            }
        }

        /// <summary>
        /// Adds the shipping option.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="shippingOption">The shipping option.</param>
        public void AddShippingOption(Store store, ShippingOption shippingOption)
        {
            if (store == null || shippingOption == null)
                return;

            if (store.StoreShippingOptions == null)
                store.StoreShippingOptions = new List<ShippingOption>();

            if (store.StoreShippingOptions.All(a => a.Id != shippingOption.Id))
            {
                _eCommerceUnitOfWork.StoreRepository.AttachIfDetached(store);
                _eCommerceUnitOfWork.ShippingOptionRepository.AttachIfDetached(shippingOption);
                store.StoreShippingOptions.Add(shippingOption);
                _eCommerceUnitOfWork.Save();
            }
        }

        /// <summary>
        /// add shipping option as an asynchronous operation.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="shippingOption">The shipping option.</param>
        public async Task AddShippingOptionAsync(Store store, ShippingOption shippingOption)
        {
            if (store == null || shippingOption == null)
                return;

            if (store.StoreShippingOptions == null)
                store.StoreShippingOptions = new List<ShippingOption>();

            if (store.StoreShippingOptions.All(a => a.Id != shippingOption.Id))
            {
                _eCommerceUnitOfWork.StoreRepository.AttachIfDetached(store);
                _eCommerceUnitOfWork.ShippingOptionRepository.AttachIfDetached(shippingOption);
                store.StoreShippingOptions.Add(shippingOption);
                await _eCommerceUnitOfWork.SaveAsync();
            }
        }

        /// <summary>
        /// Removes the shipping option.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="shippingOption">The shipping option.</param>
        public void RemoveShippingOption(Store store, ShippingOption shippingOption)
        {
            if (store == null || shippingOption == null)
                return;

            if (store.StorePaymentOptions != null && store.StorePaymentOptions.Any(a => a.Id == shippingOption.Id))
            {
                _eCommerceUnitOfWork.StoreRepository.AttachIfDetached(store);
                var itemToRemove = store.StoreShippingOptions.SingleOrDefault(a => a.Id == shippingOption.Id);
                store.StoreShippingOptions.Remove(itemToRemove);
                _eCommerceUnitOfWork.Save();
            }
        }

        /// <summary>
        /// remove shipping option as an asynchronous operation.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="shippingOption">The shipping option.</param>
        public async Task RemoveShippingOptionAsync(Store store, ShippingOption shippingOption)
        {
            if (store == null || shippingOption == null)
                return;

            if (store.StorePaymentOptions != null && store.StorePaymentOptions.Any(a => a.Id == shippingOption.Id))
            {
                _eCommerceUnitOfWork.StoreRepository.AttachIfDetached(store);
                var itemToRemove = store.StoreShippingOptions.SingleOrDefault(a => a.Id == shippingOption.Id);
                store.StoreShippingOptions.Remove(itemToRemove);
                await _eCommerceUnitOfWork.SaveAsync();
            }
        }

        /// <summary>
        /// Adds the product category.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="productCategory">The product category.</param>
        public void AddProductCategory(Store store, ProductCategory productCategory)
        {
            if (store == null || productCategory == null)
                return;

            if (store.StoreProductCategories == null)
                store.StoreProductCategories = new List<ProductCategory>();

            if (store.StoreProductCategories.All(a => a.Id != productCategory.Id))
            {
                var thisStore = GetSingleStoreById(store.Id);
                thisStore.StoreProductCategories = new List<ProductCategory>();
                _eCommerceUnitOfWork.StoreRepository.AttachIfDetached(thisStore);
                _eCommerceUnitOfWork.ProductCategoryRepository.AttachIfDetached(productCategory);
                thisStore.StoreProductCategories.Add(productCategory);
                _eCommerceUnitOfWork.Save();
            }
        }

        /// <summary>
        /// add product category as an asynchronous operation.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="productCategory">The product category.</param>
        public async Task AddProductCategoryAsync(Store store, ProductCategory productCategory)
        {
            if (store == null || productCategory == null)
                return;

            if (store.StoreProductCategories == null)
                store.StoreProductCategories = new List<ProductCategory>();

            if (store.StoreProductCategories.All(a => a.Id != productCategory.Id))
            {
                var thisStore = GetSingleStoreById(store.Id);
                thisStore.StoreProductCategories = new List<ProductCategory>();
                _eCommerceUnitOfWork.StoreRepository.AttachIfDetached(thisStore);
                _eCommerceUnitOfWork.ProductCategoryRepository.AttachIfDetached(productCategory);
                thisStore.StoreProductCategories.Add(productCategory);
                await _eCommerceUnitOfWork.SaveAsync();
            }
        }

        /// <summary>
        /// Removes the product category.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="productCategory">The product category.</param>
        public void RemoveProductCategory(Store store, ProductCategory productCategory)
        {
            if (store == null || productCategory == null)
                return;

            if (store.StoreProductCategories != null && store.StoreProductCategories.Any(a => a.Id == productCategory.Id))
            {
                _eCommerceUnitOfWork.StoreRepository.AttachIfDetached(store);
                var itemToRemove = store.StoreProductCategories.SingleOrDefault(a => a.Id == productCategory.Id);
                store.StoreProductCategories.Remove(itemToRemove);
                _eCommerceUnitOfWork.Save();
            }
        }

        /// <summary>
        /// remove product category as an asynchronous operation.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="productCategory">The product category.</param>
        public async Task RemoveProductCategoryAsync(Store store, ProductCategory productCategory)
        {
            if (store == null || productCategory == null)
                return;

            if (store.StoreProductCategories != null && store.StoreProductCategories.Any(a => a.Id == productCategory.Id))
            {
                _eCommerceUnitOfWork.StoreRepository.AttachIfDetached(store);
                var itemToRemove = store.StoreProductCategories.SingleOrDefault(a => a.Id == productCategory.Id);
                store.StoreProductCategories.Remove(itemToRemove);
                await _eCommerceUnitOfWork.SaveAsync();
            }
        }

        /// <summary>
        /// Adds the discount coupon.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="discountCoupon">The discount coupon.</param>
        public void AddDiscountCoupon(Store store, DiscountCoupon discountCoupon)
        {
            if (store == null || discountCoupon == null)
                return;

            if (store.StoreDiscountCoupons == null)
                store.StoreDiscountCoupons = new List<DiscountCoupon>();

            if (store.StoreDiscountCoupons.All(a => a.Id != discountCoupon.Id))
            {
                _eCommerceUnitOfWork.StoreRepository.AttachIfDetached(store);
                _eCommerceUnitOfWork.DiscountCouponRepository.AttachIfDetached(discountCoupon);
                store.StoreDiscountCoupons.Add(discountCoupon);
                _eCommerceUnitOfWork.Save();
            }
        }

        /// <summary>
        /// add discount coupon as an asynchronous operation.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="discountCoupon">The discount coupon.</param>
        public async Task AddDiscountCouponAsync(Store store, DiscountCoupon discountCoupon)
        {
            if (store == null || discountCoupon == null)
                return;

            if (store.StoreDiscountCoupons == null)
                store.StoreDiscountCoupons = new List<DiscountCoupon>();

            if (store.StoreDiscountCoupons.All(a => a.Id != discountCoupon.Id))
            {
                _eCommerceUnitOfWork.StoreRepository.AttachIfDetached(store);
                _eCommerceUnitOfWork.DiscountCouponRepository.AttachIfDetached(discountCoupon);
                store.StoreDiscountCoupons.Add(discountCoupon);
                await _eCommerceUnitOfWork.SaveAsync();
            }
        }

        /// <summary>
        /// Removes the discount coupon.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="discountCoupon">The discount coupon.</param>
        public void RemoveDiscountCoupon(Store store, DiscountCoupon discountCoupon)
        {
            if (store == null || discountCoupon == null)
                return;

            if (store.StoreDiscountCoupons != null && store.StoreDiscountCoupons.Any(a => a.Id == discountCoupon.Id))
            {
                _eCommerceUnitOfWork.StoreRepository.AttachIfDetached(store);
                var itemToRemove = store.StoreDiscountCoupons.SingleOrDefault(a => a.Id == discountCoupon.Id);
                store.StoreDiscountCoupons.Remove(itemToRemove);
                _eCommerceUnitOfWork.Save();
            }
        }

        /// <summary>
        /// remove discount coupon as an asynchronous operation.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="discountCoupon">The discount coupon.</param>
        public async Task RemoveDiscountCouponAsync(Store store, DiscountCoupon discountCoupon)
        {
            if (store == null || discountCoupon == null)
                return;

            if (store.StoreDiscountCoupons != null && store.StoreDiscountCoupons.Any(a => a.Id == discountCoupon.Id))
            {
                _eCommerceUnitOfWork.StoreRepository.AttachIfDetached(store);
                var itemToRemove = store.StoreDiscountCoupons.SingleOrDefault(a => a.Id == discountCoupon.Id);
                store.StoreDiscountCoupons.Remove(itemToRemove);
                await _eCommerceUnitOfWork.SaveAsync();
            }
        }

        #endregion
    }
}
