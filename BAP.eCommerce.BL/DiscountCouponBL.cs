// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="DiscountCouponBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedList;

using BAP.Common;
using BAP.eCommerce.DAL.Entities;
using BAP.BL.CriteriaEngine;

namespace BAP.eCommerce.BL
{
    /// <summary>
    /// Interface IDiscountCouponBL
    /// </summary>
    public interface IDiscountCouponBL
    {
        /// <summary>
        /// Gets all discount coupons.
        /// </summary>
        /// <returns>IList&lt;DiscountCoupon&gt;.</returns>
        IList<DiscountCoupon> GetAllDiscountCoupons();
        /// <summary>
        /// Gets all discount coupons asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;DiscountCoupon&gt;&gt;.</returns>
        Task<IList<DiscountCoupon>> GetAllDiscountCouponsAsync();

        /// <summary>
        /// Searches the discount coupons.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;DiscountCoupon&gt;.</returns>
        IPagedList<DiscountCoupon> SearchDiscountCoupons(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the discount coupons asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;DiscountCoupon&gt;&gt;.</returns>
        Task<IPagedList<DiscountCoupon>> SearchDiscountCouponsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the discount coupon by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>DiscountCoupon.</returns>
        DiscountCoupon GetDiscountCouponById(int id);
        /// <summary>
        /// Gets the discount coupon by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;DiscountCoupon&gt;.</returns>
        Task<DiscountCoupon> GetDiscountCouponByIdAsync(int id);

        /// <summary>
        /// Gets the discount coupon by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>DiscountCoupon.</returns>
        DiscountCoupon GetDiscountCouponByCode(string code);
        /// <summary>
        /// Gets the discount coupon by code asynchronous.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;DiscountCoupon&gt;.</returns>
        Task<DiscountCoupon> GetDiscountCouponByCodeAsync(string code);

        /// <summary>
        /// Adds the discount coupon.
        /// </summary>
        /// <param name="discountCoupons">The discount coupons.</param>
        void AddDiscountCoupon(params DiscountCoupon[] discountCoupons);
        /// <summary>
        /// Adds the discount coupon asynchronous.
        /// </summary>
        /// <param name="discountCoupons">The discount coupons.</param>
        /// <returns>Task.</returns>
        Task AddDiscountCouponAsync(params DiscountCoupon[] discountCoupons);

        /// <summary>
        /// Updates the discount coupon.
        /// </summary>
        /// <param name="discountCoupons">The discount coupons.</param>
        void UpdateDiscountCoupon(params DiscountCoupon[] discountCoupons);
        /// <summary>
        /// Updates the discount coupon asynchronous.
        /// </summary>
        /// <param name="discountCoupons">The discount coupons.</param>
        /// <returns>Task.</returns>
        Task UpdateDiscountCouponAsync(params DiscountCoupon[] discountCoupons);

        /// <summary>
        /// Removes the discount coupon.
        /// </summary>
        /// <param name="discountCoupons">The discount coupons.</param>
        void RemoveDiscountCoupon(params DiscountCoupon[] discountCoupons);
        /// <summary>
        /// Removes the discount coupon asynchronous.
        /// </summary>
        /// <param name="discountCoupons">The discount coupons.</param>
        /// <returns>Task.</returns>
        Task RemoveDiscountCouponAsync(params DiscountCoupon[] discountCoupons);

        /// <summary>
        /// Adds the product to coupon.
        /// </summary>
        /// <param name="discountCoupon">The discount coupon.</param>
        /// <param name="productId">The product identifier.</param>
        void AddProductToCoupon(DiscountCoupon discountCoupon, params int[] productId);
        /// <summary>
        /// Adds the product to coupon asynchronous.
        /// </summary>
        /// <param name="discountCoupon">The discount coupon.</param>
        /// <param name="productId">The product identifier.</param>
        /// <returns>Task.</returns>
        Task AddProductToCouponAsync(DiscountCoupon discountCoupon, params int[] productId);

        /// <summary>
        /// Removes the product from coupon.
        /// </summary>
        /// <param name="discountCoupon">The discount coupon.</param>
        /// <param name="productId">The product identifier.</param>
        void RemoveProductFromCoupon(DiscountCoupon discountCoupon, params int[] productId);
        /// <summary>
        /// Removes the product from coupon asynchronous.
        /// </summary>
        /// <param name="discountCoupon">The discount coupon.</param>
        /// <param name="productId">The product identifier.</param>
        /// <returns>Task.</returns>
        Task RemoveProductFromCouponAsync(DiscountCoupon discountCoupon, params int[] productId);
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
    public partial class eCommerceBusinessLayer : IDiscountCouponBL, ILocalizedBL<DiscountCoupon>
    {
        #region Public interface methods
        /// <summary>
        /// Gets all discount coupons.
        /// </summary>
        /// <returns>IList&lt;DiscountCoupon&gt;.</returns>
        public IList<DiscountCoupon> GetAllDiscountCoupons()
        {
            return _eCommerceUnitOfWork.DiscountCouponRepository.GetAll();
        }

        /// <summary>
        /// get all discount coupons as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;DiscountCoupon&gt;.</returns>
        public async Task<IList<DiscountCoupon>> GetAllDiscountCouponsAsync()
        {
            return await _eCommerceUnitOfWork.DiscountCouponRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the discount coupons.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;DiscountCoupon&gt;.</returns>
        public IPagedList<DiscountCoupon> SearchDiscountCoupons(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<ProductCategory>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _eCommerceUnitOfWork.DiscountCouponRepository.GetPagedList(page, pageSize, ParseJSONSearchString<DiscountCoupon>(where), sortExpression);
        }

        /// <summary>
        /// search discount coupons as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;DiscountCoupon&gt;.</returns>
        public async Task<IPagedList<DiscountCoupon>> SearchDiscountCouponsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<ProductCategory>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return await _eCommerceUnitOfWork.DiscountCouponRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<DiscountCoupon>(where), sortExpression);
        }

        /// <summary>
        /// Gets the discount coupon by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>DiscountCoupon.</returns>
        public DiscountCoupon GetDiscountCouponById(int id)
        {
            var result = _eCommerceUnitOfWork.DiscountCouponRepository.GetSingle(a => a.Id == id, a => a.ProductsApplied);
            if (!ParseApplyCriteria(result))
                InitApplyCriteria(result);

            return result;
        }

        /// <summary>
        /// get discount coupon by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>DiscountCoupon.</returns>
        public async Task<DiscountCoupon> GetDiscountCouponByIdAsync(int id)
        {
            var result = await _eCommerceUnitOfWork.DiscountCouponRepository.GetSingleAsync(a => a.Id == id, a => a.ProductsApplied);
            if (!ParseApplyCriteria(result))
                InitApplyCriteria(result);

            return result;
        }

        /// <summary>
        /// Gets the discount coupon by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>DiscountCoupon.</returns>
        public DiscountCoupon GetDiscountCouponByCode(string code)
        {
            var result = _eCommerceUnitOfWork.DiscountCouponRepository.GetSingle(a => a.Code == code);
            if (!ParseApplyCriteria(result))
                InitApplyCriteria(result);

            return result;
        }

        /// <summary>
        /// get discount coupon by code as an asynchronous operation.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>DiscountCoupon.</returns>
        public async Task<DiscountCoupon> GetDiscountCouponByCodeAsync(string code)
        {
            var result = await _eCommerceUnitOfWork.DiscountCouponRepository.GetSingleAsync(a => a.Code == code);
            if (!ParseApplyCriteria(result))
                InitApplyCriteria(result);

            return result;
        }

        /// <summary>
        /// Adds the discount coupon.
        /// </summary>
        /// <param name="discountCoupons">The discount coupons.</param>
        public void AddDiscountCoupon(params DiscountCoupon[] discountCoupons)
        {
            discountCoupons.ToList().ForEach(SerializeApplyCriteria);
            _eCommerceUnitOfWork.DiscountCouponRepository.Add(discountCoupons);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// add discount coupon as an asynchronous operation.
        /// </summary>
        /// <param name="discountCoupons">The discount coupons.</param>
        public async Task AddDiscountCouponAsync(params DiscountCoupon[] discountCoupons)
        {
            discountCoupons.ToList().ForEach(SerializeApplyCriteria);
            _eCommerceUnitOfWork.DiscountCouponRepository.Add(discountCoupons);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the discount coupon.
        /// </summary>
        /// <param name="discountCoupons">The discount coupons.</param>
        public void UpdateDiscountCoupon(params DiscountCoupon[] discountCoupons)
        {
            discountCoupons.ToList().ForEach(SerializeApplyCriteria);
            _eCommerceUnitOfWork.DiscountCouponRepository.Update(discountCoupons);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// update discount coupon as an asynchronous operation.
        /// </summary>
        /// <param name="discountCoupons">The discount coupons.</param>
        public async Task UpdateDiscountCouponAsync(params DiscountCoupon[] discountCoupons)
        {
            discountCoupons.ToList().ForEach(SerializeApplyCriteria);
            _eCommerceUnitOfWork.DiscountCouponRepository.Update(discountCoupons);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the discount coupon.
        /// </summary>
        /// <param name="discountCoupons">The discount coupons.</param>
        public void RemoveDiscountCoupon(params DiscountCoupon[] discountCoupons)
        {
            _eCommerceUnitOfWork.DiscountCouponRepository.Remove(discountCoupons);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// remove discount coupon as an asynchronous operation.
        /// </summary>
        /// <param name="discountCoupons">The discount coupons.</param>
        public async Task RemoveDiscountCouponAsync(params DiscountCoupon[] discountCoupons)
        {
            _eCommerceUnitOfWork.DiscountCouponRepository.Remove(discountCoupons);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Adds the product to coupon.
        /// </summary>
        /// <param name="discountCoupon">The discount coupon.</param>
        /// <param name="productId">The product identifier.</param>
        public void AddProductToCoupon(DiscountCoupon discountCoupon, params int[] productId)
        {
            if (discountCoupon == null || productId == null)
                return;

            _eCommerceUnitOfWork.DiscountCouponRepository.AttachIfDetached(discountCoupon);
            if (discountCoupon.ProductsApplied == null)
                discountCoupon.ProductsApplied = new List<Product>();
            
            foreach(var id in productId)
            {
                if (discountCoupon.ProductsApplied.Any(a => a.Id == id))
                    continue;

                var product = ((IProductBL)this).GetSingleProductById(id);
                if (product != null)
                {
                    _eCommerceUnitOfWork.ProductRepository.AttachIfDetached(product);
                    discountCoupon.ProductsApplied.Add(product);
                }                    
            }

            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// add product to coupon as an asynchronous operation.
        /// </summary>
        /// <param name="discountCoupon">The discount coupon.</param>
        /// <param name="productId">The product identifier.</param>
        public async Task AddProductToCouponAsync(DiscountCoupon discountCoupon, params int[] productId)
        {
            if (discountCoupon == null || productId == null)
                return;

            _eCommerceUnitOfWork.DiscountCouponRepository.AttachIfDetached(discountCoupon);
            if (discountCoupon.ProductsApplied == null)
                discountCoupon.ProductsApplied = new List<Product>();

            foreach (var id in productId)
            {
                if (discountCoupon.ProductsApplied.Any(a => a.Id == id))
                    continue;

                var product = await ((IProductBL)this).GetSingleProductByIdAsync(id);
                if (product != null)
                {
                    _eCommerceUnitOfWork.ProductRepository.AttachIfDetached(product);
                    discountCoupon.ProductsApplied.Add(product);
                }
            }

            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the product from coupon.
        /// </summary>
        /// <param name="discountCoupon">The discount coupon.</param>
        /// <param name="productId">The product identifier.</param>
        public void RemoveProductFromCoupon(DiscountCoupon discountCoupon, params int[] productId)
        {
            if (discountCoupon == null || productId == null)
                return;

            if (discountCoupon.ProductsApplied != null)
            {
                _eCommerceUnitOfWork.DiscountCouponRepository.AttachIfDetached(discountCoupon);
                foreach(var id in productId)
                {
                    var itemToRemove = discountCoupon.ProductsApplied.SingleOrDefault(a => a.Id == id);
                    discountCoupon.ProductsApplied.Remove(itemToRemove);
                }                
                _eCommerceUnitOfWork.Save();
            }
        }

        /// <summary>
        /// remove product from coupon as an asynchronous operation.
        /// </summary>
        /// <param name="discountCoupon">The discount coupon.</param>
        /// <param name="productId">The product identifier.</param>
        public async Task RemoveProductFromCouponAsync(DiscountCoupon discountCoupon, params int[] productId)
        {
            if (discountCoupon == null || productId == null)
                return;

            if (discountCoupon.ProductsApplied != null)
            {
                _eCommerceUnitOfWork.DiscountCouponRepository.AttachIfDetached(discountCoupon);
                foreach (var id in productId)
                {
                    var itemToRemove = discountCoupon.ProductsApplied.SingleOrDefault(a => a.Id == id);
                    discountCoupon.ProductsApplied.Remove(itemToRemove);
                }
                await _eCommerceUnitOfWork.SaveAsync();
            }
        }

        /// <summary>
        /// Initializes the apply criteria.
        /// </summary>
        /// <param name="discountCoupon">The discount coupon.</param>
        public void InitApplyCriteria(DiscountCoupon discountCoupon)
        {
            // application criteria is only available for BuyXGetY, FreeShipping and VolumeDiscount types of discount
            if (discountCoupon == null || discountCoupon.ApplyCriteria != null || !MayHaveApplyCriteria(discountCoupon))
                return;

            // Create criteria as is
            discountCoupon.ApplyCriteria = new Criteria<ShoppingCart>(_configHelper, _authContext, _logger, true);

            // get list of criteria fields from configuration, data should have text format like <FieldName1>|<CompareOperator1>;<FieldName2>|<CompareOperator2>...|<FieldNameN>|<CompareOperatorN>
            var fieldsText = _configHelper.ReadString("BAP.eCommerce.BL.DiscountCoupon." + discountCoupon.DiscountType + ".CriteriaFields");

            if(!fieldsText.IsNullOrEmpty())
            {                
                var fieldsData = fieldsText.Split(";".ToCharArray());
                foreach(var f in fieldsData)
                {
                    var fieldData = f.Split("|".ToCharArray());
                    if(fieldData.Length == 2)
                    {
                        var field = discountCoupon.ApplyCriteria[fieldData[0]];
                        if(field != null)
                        {
                            Enum.TryParse(fieldData[1], out CriteriaCompareOperator val);
                            if (val != CriteriaCompareOperator.None)
                                field.CompareOperator = val;
                        }                            
                    }
                }
            }
        }

        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>DiscountCoupon.</returns>
        public DiscountCoupon Details(int id)
        {
            return GetDiscountCouponById(id);
        }

        /// <summary>
        /// Lists the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IList&lt;DiscountCoupon&gt;.</returns>
        public IList<DiscountCoupon> List(string where, string sort, int page, int pageSize)
        {
            if (string.IsNullOrEmpty(where) && string.IsNullOrEmpty(sort) && page == 0)
                return GetAllDiscountCoupons();

            return SearchDiscountCoupons(where, sort, page, pageSize).ToList();
        }

        #region ILocalizedBL
        /// <summary>
        /// Get full details of the single entity
        /// </summary>
        /// <param name="ofEntity">Passed entity is used as filter, method implementing ths feature should treat this oject apropriatly to call some method of BL class to read full details.</param>
        /// <returns>Entity instance</returns>
        public DiscountCoupon GetDetails(DiscountCoupon ofEntity)
        {
            if (ofEntity == null)
                return null;

            if (ofEntity.Id > 0)
                return GetDiscountCouponById(ofEntity.Id);
            
            return null;
        }

        /// <summary>
        /// Adds the single entity.
        /// </summary>
        /// <param name="coupon">The coupon.</param>
        public void AddSingleEntity(DiscountCoupon coupon)
        {
            _eCommerceUnitOfWork.DiscountCouponRepository.Add(coupon);
            _eCommerceUnitOfWork.Save();
        }
        #endregion

        #endregion

        #region Private methods
        /// <summary>
        /// Mays the have apply criteria.
        /// </summary>
        /// <param name="discountCoupon">The discount coupon.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool MayHaveApplyCriteria(DiscountCoupon discountCoupon)
        {
            return discountCoupon != null && (discountCoupon.DiscountType == DiscountType.BuyXGetY || discountCoupon.DiscountType == DiscountType.FreeShipping || discountCoupon.DiscountType == DiscountType.VolumeDiscount);
        }
        /// <summary>
        /// Parses the apply criteria.
        /// </summary>
        /// <param name="discountCoupon">The discount coupon.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ParseApplyCriteria(DiscountCoupon discountCoupon)
        {
            if (discountCoupon == null || discountCoupon.CustomData.IsNullOrEmpty() || !MayHaveApplyCriteria(discountCoupon))
                return false;

            bool result = true;
            try
            {
                discountCoupon.ApplyCriteria = Criteria<ShoppingCart>.FromString(_configHelper, _authContext, _logger, discountCoupon.CustomData);       
            }
            catch(Exception exc)
            {
                _logger.LogException("DiscountCouponBL", "ParseApplyCriteria", new Exception("Could not parse custom data field into ApplyCriteria object", exc));
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Serializes the apply criteria.
        /// </summary>
        /// <param name="discountCoupon">The discount coupon.</param>
        private void SerializeApplyCriteria(DiscountCoupon discountCoupon)
        {
            if (discountCoupon?.ApplyCriteria == null || !MayHaveApplyCriteria(discountCoupon))
                return;

            discountCoupon.CustomData = discountCoupon.ApplyCriteria.ToString();
        }
       
        #endregion
    }
}
