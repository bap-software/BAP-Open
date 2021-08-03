// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="AddressBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PagedList;

using BAP.Common;
using BAP.eCommerce.DAL.Entities;
using BAP.DAL;
using BAP.Log;

namespace BAP.eCommerce.BL
{
    /// <summary>
    /// Interface IAddressBL
    /// </summary>
    public interface IAddressBL
    {
        /// <summary>
        /// Gets all addresss.
        /// </summary>
        /// <returns>IList&lt;Address&gt;.</returns>
        IList<Address> GetAllAddresss();
        /// <summary>
        /// Searches the addresses.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Address&gt;.</returns>
        IPagedList<Address> SearchAddresses(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the addresses.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;Address&gt;.</returns>
        IList<Address> SearchAddresses(string where, string sort);
        /// <summary>
        /// Gets the address by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Address.</returns>
        Address GetAddressById(int id);
        /// <summary>
        /// Adds the address.
        /// </summary>
        /// <param name="Addresss">The addresss.</param>
        /// <returns>Address[].</returns>
        Address[] AddAddress(params Address[] Addresss);
        /// <summary>
        /// Updates the address.
        /// </summary>
        /// <param name="Addresss">The addresss.</param>
        /// <returns>Address[].</returns>
        Address[] UpdateAddress(params Address[] Addresss);
        /// <summary>
        /// Removes the address.
        /// </summary>
        /// <param name="Addresss">The addresss.</param>
        void RemoveAddress(params Address[] Addresss);
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
    public partial class eCommerceBusinessLayer : IAddressBL
    {
        #region Addresss

        /// <summary>
        /// Gets all addresss.
        /// </summary>
        /// <returns>IList&lt;Address&gt;.</returns>
        public IList<Address> GetAllAddresss()
        {
            return _eCommerceUnitOfWork.AddressRepository.GetAll();
        }

        /// <summary>
        /// Searches the addresses.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Address&gt;.</returns>
        public IPagedList<Address> SearchAddresses(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<Address>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _eCommerceUnitOfWork.AddressRepository.GetPagedList(page, pageSize, ParseJSONSearchString<Address>(where), sortExpression);
        }

        /// <summary>
        /// Searches the addresses.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;Address&gt;.</returns>
        public IList<Address> SearchAddresses(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Address>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }
            return _eCommerceUnitOfWork.AddressRepository.GetList(ParseJSONSearchString<Address>(where), sortExpression);
        }

        /// <summary>
        /// search addresses as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;Address&gt;.</returns>
        public async Task<IList<Address>> SearchAddressesAsync(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Address>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }
            return await _eCommerceUnitOfWork.AddressRepository.GetListAsync(ParseJSONSearchString<Address>(@where), sortExpression);
        }

        /// <summary>
        /// Gets the address by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Address.</returns>
        public Address GetAddressById(int id)
        {
            return _eCommerceUnitOfWork.AddressRepository.GetSingle(a => a.Id == id);
        }

        /// <summary>
        /// Adds the address.
        /// </summary>
        /// <param name="Addresss">The addresss.</param>
        /// <returns>Address[].</returns>
        public Address[] AddAddress(params Address[] Addresss)
        {
            try
            {
                _eCommerceUnitOfWork.AddressRepository.Add(Addresss);
                _eCommerceUnitOfWork.Save();
                return Addresss;
            }
            catch(Exception exc)
            {
                _logger.LogException("IAddressBL", "AddAddress", exc);
            }
            return null;            
        }

        /// <summary>
        /// Updates the address.
        /// </summary>
        /// <param name="Addresss">The addresss.</param>
        /// <returns>Address[].</returns>
        public Address[] UpdateAddress(params Address[] Addresss)
        {
            try
            {
                _eCommerceUnitOfWork.AddressRepository.Update(Addresss);
                _eCommerceUnitOfWork.Save();
                return Addresss;
            }
            catch (Exception exc)
            {
                _logger.LogException("IAddressBL", "UpdateAddress", exc);
            }
            return null;
        }

        /// <summary>
        /// Removes the address.
        /// </summary>
        /// <param name="Addresss">The addresss.</param>
        public void RemoveAddress(params Address[] Addresss)
        {
            _eCommerceUnitOfWork.AddressRepository.Remove(Addresss);
            _eCommerceUnitOfWork.Save();
        }

        #endregion
    }

    /// <summary>
    /// Class AddressBL.
    /// Implements the <see cref="BAP.eCommerce.BL.eCommerceBusinessLayer" />
    /// Implements the <see cref="BAP.Common.ISupportLookup" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.BL.eCommerceBusinessLayer" />
    /// <seealso cref="BAP.Common.ISupportLookup" />
    public class AddressBL : eCommerceBusinessLayer, ISupportLookup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBL"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public AddressBL(IConfigHelper settings, IAuthorizationContext context, ILogger logger) : base(null, null, settings, context, logger)
        {

        }

        #region ISupportLookup

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
            var addresses = SearchAddresses(extraFilter, orderBy);
            foreach (var address in addresses)
            {
                var val = address.GetType().GetProperty(valueField).GetValue(address, null);
                var text = address.GetType().GetProperty(textField).GetValue(address, null);
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = address.GetType().GetProperty(descriptionField).GetValue(address, null) ?? "";
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
            var addresses = await SearchAddressesAsync(extraFilter, orderBy);
            foreach (var address in addresses)
            {
                var val = address.GetType().GetProperty(valueField).GetValue(address, null);
                var text = address.GetType().GetProperty(textField).GetValue(address, null);
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = address.GetType().GetProperty(descriptionField).GetValue(address, null) ?? "";
                }
                result.Add(new LookupItem { Key = val.ToString(), Text = text.ToString(), Description = descr.ToString() });
            }

            return result;
        }

        #endregion
    }
}
