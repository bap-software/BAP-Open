// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="SupplierBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

using PagedList;

using BAP.Common;
using BAP.eCommerce.DAL.Entities;
using BAP.DAL;
using BAP.Log;
using System;
using System.Threading.Tasks;

namespace BAP.eCommerce.BL
{
    /// <summary>
    /// Interface ISupplierBL
    /// </summary>
    public interface ISupplierBL
    {
        /// <summary>
        /// Gets all suppliers.
        /// </summary>
        /// <returns>IList&lt;Supplier&gt;.</returns>
        IList<DAL.Entities.Supplier> GetAllSuppliers();
        /// <summary>
        /// Gets all suppliers asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;Supplier&gt;&gt;.</returns>
        Task<IList<DAL.Entities.Supplier>> GetAllSuppliersAsync();

        /// <summary>
        /// Searches the suppliers.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Supplier&gt;.</returns>
        IPagedList<DAL.Entities.Supplier> SearchSuppliers(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the suppliers asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;Supplier&gt;&gt;.</returns>
        Task<IPagedList<DAL.Entities.Supplier>> SearchSuppliersAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the supplier by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Supplier.</returns>
        DAL.Entities.Supplier GetSupplierById(int id);
        /// <summary>
        /// Gets the supplier by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Supplier&gt;.</returns>
        Task<DAL.Entities.Supplier> GetSupplierByIdAsync(int id);

        /// <summary>
        /// Adds the supplier.
        /// </summary>
        /// <param name="suppliers">The suppliers.</param>
        void AddSupplier(params DAL.Entities.Supplier[] suppliers);
        /// <summary>
        /// Adds the supplier asynchronous.
        /// </summary>
        /// <param name="suppliers">The suppliers.</param>
        /// <returns>Task.</returns>
        Task AddSupplierAsync(params DAL.Entities.Supplier[] suppliers);

        /// <summary>
        /// Updates the supplier.
        /// </summary>
        /// <param name="suppliers">The suppliers.</param>
        void UpdateSupplier(params DAL.Entities.Supplier[] suppliers);
        /// <summary>
        /// Updates the supplier asynchronous.
        /// </summary>
        /// <param name="suppliers">The suppliers.</param>
        /// <returns>Task.</returns>
        Task UpdateSupplierAsync(params DAL.Entities.Supplier[] suppliers);

        /// <summary>
        /// Removes the supplier.
        /// </summary>
        /// <param name="suppliers">The suppliers.</param>
        void RemoveSupplier(params DAL.Entities.Supplier[] suppliers);
        /// <summary>
        /// Removes the supplier asynchronous.
        /// </summary>
        /// <param name="suppliers">The suppliers.</param>
        /// <returns>Task.</returns>
        Task RemoveSupplierAsync(params DAL.Entities.Supplier[] suppliers);
    }

    /// <summary>
    /// Class eCommerceBusinessLayer.
    /// Implements the <see cref="BAP.BL.BusinessLayer" />
    /// Implements the <see cref="BAP.eCommerce.BL.IProductOptionBL" />
    /// Implements the <see cref="ProductOption" />
    /// Implements the <see cref="BAP.eCommerce.BL.ICustomerOrderBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.ICustomerOrderWorkflow" />
    /// Implements the <see cref="BAP.eCommerce.BL.IStoreBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.IOrderItemBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.ISupplierBL" />
    /// Implements the <see cref="Supplier" />
    /// Implements the <see cref="System.IDisposable" />
    /// Implements the <see cref="BAP.eCommerce.BL.IProductCategoryBL" />
    /// Implements the <see cref="ProductCategory" />
    /// Implements the <see cref="BAP.eCommerce.BL.IPaymentOptionBL" />
    /// Implements the <see cref="PaymentOption" />
    /// Implements the <see cref="BAP.eCommerce.BL.IProductBL" />
    /// Implements the <see cref="Product" />
    /// Implements the <see cref="BAP.eCommerce.BL.IManufacturerBL" />
    /// Implements the <see cref="Manufacturer" />
    /// Implements the <see cref="BAP.eCommerce.BL.IShippingOptionBL" />
    /// Implements the <see cref="ShippingOption" />
    /// Implements the <see cref="BAP.eCommerce.BL.IProductOptionItemBL" />
    /// Implements the <see cref="ProductOptionItem" />
    /// Implements the <see cref="BAP.eCommerce.BL.IShoppingCartBL" />
    /// Implements the <see cref="ShoppingCart" />
    /// Implements the <see cref="BAP.eCommerce.BL.IShippingCarrierBL" />
    /// Implements the <see cref="ShippingCarrier" />
    /// Implements the <see cref="BAP.eCommerce.BL.ICustomerPaymentBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.ICustomerOrderPaymentBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.IDiscountCouponBL" />
    /// Implements the <see cref="DiscountCoupon" />
    /// Implements the <see cref="BAP.eCommerce.BL.IAddressBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.IShoppingCartProductBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.ICustomerBL" />
    /// Implements the <see cref="BAP.eCommerce.BL.IRelatedProductBL" />
    /// </summary>
    /// <seealso cref="BAP.BL.BusinessLayer" />
    /// <seealso cref="BAP.eCommerce.BL.IProductOptionBL" />
    /// <seealso cref="ProductOption" />
    /// <seealso cref="BAP.eCommerce.BL.ICustomerOrderBL" />
    /// <seealso cref="BAP.eCommerce.BL.ICustomerOrderWorkflow" />
    /// <seealso cref="BAP.eCommerce.BL.IStoreBL" />
    /// <seealso cref="BAP.eCommerce.BL.IOrderItemBL" />
    /// <seealso cref="BAP.eCommerce.BL.ISupplierBL" />
    /// <seealso cref="Supplier" />
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="BAP.eCommerce.BL.IProductCategoryBL" />
    /// <seealso cref="ProductCategory" />
    /// <seealso cref="BAP.eCommerce.BL.IPaymentOptionBL" />
    /// <seealso cref="PaymentOption" />
    /// <seealso cref="BAP.eCommerce.BL.IProductBL" />
    /// <seealso cref="Product" />
    /// <seealso cref="BAP.eCommerce.BL.IManufacturerBL" />
    /// <seealso cref="Manufacturer" />
    /// <seealso cref="BAP.eCommerce.BL.IShippingOptionBL" />
    /// <seealso cref="ShippingOption" />
    /// <seealso cref="BAP.eCommerce.BL.IProductOptionItemBL" />
    /// <seealso cref="ProductOptionItem" />
    /// <seealso cref="BAP.eCommerce.BL.IShoppingCartBL" />
    /// <seealso cref="ShoppingCart" />
    /// <seealso cref="BAP.eCommerce.BL.IShippingCarrierBL" />
    /// <seealso cref="ShippingCarrier" />
    /// <seealso cref="BAP.eCommerce.BL.ICustomerPaymentBL" />
    /// <seealso cref="BAP.eCommerce.BL.ICustomerOrderPaymentBL" />
    /// <seealso cref="BAP.eCommerce.BL.IDiscountCouponBL" />
    /// <seealso cref="DiscountCoupon" />
    /// <seealso cref="BAP.eCommerce.BL.IAddressBL" />
    /// <seealso cref="BAP.eCommerce.BL.IShoppingCartProductBL" />
    /// <seealso cref="BAP.eCommerce.BL.ICustomerBL" />
    /// <seealso cref="BAP.eCommerce.BL.IRelatedProductBL" />
    public partial class eCommerceBusinessLayer : ISupplierBL, ILocalizedBL<DAL.Entities.Supplier>
    {
        #region Suppliers

        /// <summary>
        /// Gets all suppliers.
        /// </summary>
        /// <returns>IList&lt;Supplier&gt;.</returns>
        public IList<DAL.Entities.Supplier> GetAllSuppliers()
        {
            return _eCommerceUnitOfWork.SupplierRepository.GetAll();
        }

        /// <summary>
        /// get all suppliers as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;Supplier&gt;.</returns>
        public async Task<IList<DAL.Entities.Supplier>> GetAllSuppliersAsync()
        {
            return await _eCommerceUnitOfWork.SupplierRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the suppliers.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Supplier&gt;.</returns>
        public IPagedList<DAL.Entities.Supplier> SearchSuppliers(string where, string sort, int page = 1, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<DAL.Entities.Supplier>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _eCommerceUnitOfWork.SupplierRepository.GetPagedList(page, pageSize, ParseJSONSearchString<DAL.Entities.Supplier>(where), sortExpression);
        }

        /// <summary>
        /// search suppliers as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Supplier&gt;.</returns>
        public async Task<IPagedList<DAL.Entities.Supplier>> SearchSuppliersAsync(string where, string sort, int page = 1, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<DAL.Entities.Supplier>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _eCommerceUnitOfWork.SupplierRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<DAL.Entities.Supplier>(where), sortExpression);
        }

        /// <summary>
        /// Gets the supplier by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Supplier.</returns>
        public DAL.Entities.Supplier GetSupplierById(int id)
        {
            var supplier = _eCommerceUnitOfWork.SupplierRepository.GetSingle(a => a.Id == id);
            if (supplier != null && supplier.Id > 0)
            {
                supplier.Attachments = _eCommerceUnitOfWork.AttachmentRepository.GetList(a => a.Object == "Supplier" && a.ObjectId == supplier.Id);
            }
            return supplier;
        }

        /// <summary>
        /// get supplier by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Supplier.</returns>
        public async Task<DAL.Entities.Supplier> GetSupplierByIdAsync(int id)
        {
            var supplier = await _eCommerceUnitOfWork.SupplierRepository.GetSingleAsync(a => a.Id == id);
            if (supplier != null && supplier.Id > 0)
            {
                supplier.Attachments = await _eCommerceUnitOfWork.AttachmentRepository.GetListAsync(a => a.Object == "Supplier" && a.ObjectId == supplier.Id);
            }
            return supplier;
        }

        /// <summary>
        /// Adds the supplier.
        /// </summary>
        /// <param name="suppliers">The suppliers.</param>
        public void AddSupplier(params DAL.Entities.Supplier[] suppliers)
        {
            _eCommerceUnitOfWork.SupplierRepository.Add(suppliers);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// add supplier as an asynchronous operation.
        /// </summary>
        /// <param name="suppliers">The suppliers.</param>
        public async Task AddSupplierAsync(params DAL.Entities.Supplier[] suppliers)
        {
            _eCommerceUnitOfWork.SupplierRepository.Add(suppliers);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the supplier.
        /// </summary>
        /// <param name="suppliers">The suppliers.</param>
        public void UpdateSupplier(params DAL.Entities.Supplier[] suppliers)
        {
            _eCommerceUnitOfWork.SupplierRepository.Update(suppliers);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// update supplier as an asynchronous operation.
        /// </summary>
        /// <param name="suppliers">The suppliers.</param>
        public async Task UpdateSupplierAsync(params DAL.Entities.Supplier[] suppliers)
        {
            _eCommerceUnitOfWork.SupplierRepository.Update(suppliers);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the supplier.
        /// </summary>
        /// <param name="suppliers">The suppliers.</param>
        public void RemoveSupplier(params DAL.Entities.Supplier[] suppliers)
        {
            _eCommerceUnitOfWork.SupplierRepository.Remove(suppliers);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// remove supplier as an asynchronous operation.
        /// </summary>
        /// <param name="suppliers">The suppliers.</param>
        public async Task RemoveSupplierAsync(params DAL.Entities.Supplier[] suppliers)
        {
            _eCommerceUnitOfWork.SupplierRepository.Remove(suppliers);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        #region ILocalizedBL
        /// <summary>
        /// Get full details of the single entity
        /// </summary>
        /// <param name="ofEntity">Passed entity is used as filter, method implementing ths feature should treat this oject apropriatly to call some method of BL class to read full details.</param>
        /// <returns>Entity instance</returns>
        public DAL.Entities.Supplier GetDetails(DAL.Entities.Supplier ofEntity)
        {
            if (ofEntity == null)
                return null;

            if (ofEntity.Id > 0)
                return GetSupplierById(ofEntity.Id);
            
            return null;
        }

        /// <summary>
        /// Inserts given entity into DB
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        public void AddSingleEntity(DAL.Entities.Supplier entity)
        {
            _eCommerceUnitOfWork.SupplierRepository.Add(entity);
            _eCommerceUnitOfWork.Save();
        }
        #endregion

        #endregion
    }

    /// <summary>
    /// Class SupplierBL.
    /// Implements the <see cref="BAP.eCommerce.BL.eCommerceBusinessLayer" />
    /// Implements the <see cref="BAP.Common.ISupportLookup" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.BL.eCommerceBusinessLayer" />
    /// <seealso cref="BAP.Common.ISupportLookup" />
    public class SupplierBL : eCommerceBusinessLayer, ISupportLookup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierBL"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public SupplierBL(IConfigHelper settings, IAuthorizationContext context, ILogger logger) : base(null, null, settings, context, logger)
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
            var suppliers = SearchSuppliers(extraFilter, orderBy);
            foreach (var supplier in suppliers)
            {
                var val = supplier.GetType().GetProperty(valueField).GetValue(supplier, null);
                var text = supplier.GetType().GetProperty(textField).GetValue(supplier, null);
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = supplier.GetType().GetProperty(descriptionField).GetValue(supplier, null);
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
            var suppliers = await SearchSuppliersAsync(extraFilter, orderBy);
            foreach (var supplier in suppliers)
            {
                var val = supplier.GetType().GetProperty(valueField).GetValue(supplier, null);
                var text = supplier.GetType().GetProperty(textField).GetValue(supplier, null);
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = supplier.GetType().GetProperty(descriptionField).GetValue(supplier, null);
                }
                result.Add(new LookupItem { Key = val.ToString(), Text = text.ToString(), Description = descr.ToString() });
            }

            return result;
        }
    }
}
