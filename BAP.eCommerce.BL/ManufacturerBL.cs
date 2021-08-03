// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="ManufacturerBL.cs" company="BAP Software Ltd.">
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
using System.Linq.Expressions;

namespace BAP.eCommerce.BL
{
    /// <summary>
    /// Interface IManufacturerBL
    /// </summary>
    public interface IManufacturerBL
    {
        /// <summary>
        /// Gets all manufacturers.
        /// </summary>
        /// <returns>IList&lt;Manufacturer&gt;.</returns>
        IList<Manufacturer> GetAllManufacturers();
        /// <summary>
        /// Gets all manufacturers asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;Manufacturer&gt;&gt;.</returns>
        Task<IList<Manufacturer>> GetAllManufacturersAsync();

        /// <summary>
        /// Searches the manufacturers.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;Manufacturer&gt;.</returns>
        IList<Manufacturer> SearchManufacturers(string where, string sort = "");

        /// <summary>
        /// Searches the manufacturers.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>IList&lt;Manufacturer&gt;.</returns>
        IList<Manufacturer> SearchManufacturers(Expression<Func<Manufacturer, bool>> where);

        /// <summary>
        /// Searches the manufacturers asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>Task&lt;IList&lt;Manufacturer&gt;&gt;.</returns>
        Task<IList<Manufacturer>> SearchManufacturersAsync(string where, string sort = "");

        /// <summary>
        /// Searches the manufacturers asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>Task&lt;IList&lt;Manufacturer&gt;&gt;.</returns>
        Task<IList<Manufacturer>> SearchManufacturersAsync(Expression<Func<Manufacturer, bool>> where);

        /// <summary>
        /// Searches the manufacturers.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Manufacturer&gt;.</returns>
        IPagedList<Manufacturer> SearchManufacturers(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the manufacturers asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;Manufacturer&gt;&gt;.</returns>
        Task<IPagedList<Manufacturer>> SearchManufacturersAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the manufacturer by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Manufacturer.</returns>
        Manufacturer GetManufacturerById(int id);
        /// <summary>
        /// Gets the manufacturer by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Manufacturer&gt;.</returns>
        Task<Manufacturer> GetManufacturerByIdAsync(int id);

        /// <summary>
        /// Adds the manufacturer.
        /// </summary>
        /// <param name="manufacturers">The manufacturers.</param>
        void AddManufacturer(params Manufacturer[] manufacturers);
        /// <summary>
        /// Adds the manufacturer asynchronous.
        /// </summary>
        /// <param name="manufacturers">The manufacturers.</param>
        /// <returns>Task.</returns>
        Task AddManufacturerAsync(params Manufacturer[] manufacturers);

        /// <summary>
        /// Updates the manufacturer.
        /// </summary>
        /// <param name="manufacturers">The manufacturers.</param>
        void UpdateManufacturer(params Manufacturer[] manufacturers);
        /// <summary>
        /// Updates the manufacturer asynchronous.
        /// </summary>
        /// <param name="manufacturers">The manufacturers.</param>
        /// <returns>Task.</returns>
        Task UpdateManufacturerAsync(params Manufacturer[] manufacturers);

        /// <summary>
        /// Removes the manufacturer.
        /// </summary>
        /// <param name="manufacturers">The manufacturers.</param>
        void RemoveManufacturer(params Manufacturer[] manufacturers);
        /// <summary>
        /// Removes the manufacturer asynchronous.
        /// </summary>
        /// <param name="manufacturers">The manufacturers.</param>
        /// <returns>Task.</returns>
        Task RemoveManufacturerAsync(params Manufacturer[] manufacturers);
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
    public partial class eCommerceBusinessLayer : IManufacturerBL, ILocalizedBL<Manufacturer>
    {
        #region manufacturers

        /// <summary>
        /// Gets all manufacturers.
        /// </summary>
        /// <returns>IList&lt;Manufacturer&gt;.</returns>
        public IList<Manufacturer> GetAllManufacturers()
        {
            return _eCommerceUnitOfWork.ManufacturerRepository.GetAll();
        }

        /// <summary>
        /// get all manufacturers as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;Manufacturer&gt;.</returns>
        public async Task<IList<Manufacturer>> GetAllManufacturersAsync()
        {
            return await _eCommerceUnitOfWork.ManufacturerRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the manufacturers.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;Manufacturer&gt;.</returns>
        public IList<Manufacturer> SearchManufacturers(string where, string sort = "")
        {
            return _eCommerceUnitOfWork.ManufacturerRepository.GetList(where, sort);
        }


        public IList<Manufacturer> SearchManufacturers(Expression<Func<Manufacturer, bool>> where)
        {
            return _eCommerceUnitOfWork.ManufacturerRepository.GetList(where);
        }

        public async Task<IList<Manufacturer>> SearchManufacturersAsync(Expression<Func<Manufacturer, bool>> where)
        {
            return await _eCommerceUnitOfWork.ManufacturerRepository.GetListAsync(where);
        }



        /// <summary>
        /// search manufacturers as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>Task&lt;IList&lt;Manufacturer&gt;&gt;.</returns>
        public async Task<IList<Manufacturer>> SearchManufacturersAsync(string where, string sort = "")
        {
            return await _eCommerceUnitOfWork.ManufacturerRepository.GetListAsync(where, sort);
        }

        /// <summary>
        /// Searches the manufacturers.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Manufacturer&gt;.</returns>
        public IPagedList<Manufacturer> SearchManufacturers(string where, string sort, int page = 1, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<Manufacturer>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _eCommerceUnitOfWork.ManufacturerRepository.GetPagedList(page, pageSize, ParseJSONSearchString<Manufacturer>(where), sortExpression);
        }

        /// <summary>
        /// search manufacturers as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Manufacturer&gt;.</returns>
        public async Task<IPagedList<Manufacturer>> SearchManufacturersAsync(string where, string sort, int page = 1, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<Manufacturer>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _eCommerceUnitOfWork.ManufacturerRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<Manufacturer>(where), sortExpression);
        }

        /// <summary>
        /// Gets the manufacturer by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Manufacturer.</returns>
        public Manufacturer GetManufacturerById(int id)
        {
            var manufacturer = _eCommerceUnitOfWork.ManufacturerRepository.GetSingle(a => a.Id == id);
            if (manufacturer != null && manufacturer.Id > 0)
            {
                manufacturer.Attachments = _eCommerceUnitOfWork.AttachmentRepository.GetList(a => a.Object == "Manufacturer" && a.ObjectId == manufacturer.Id);
            }
            return manufacturer;
        }

        /// <summary>
        /// get manufacturer by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Manufacturer.</returns>
        public async Task<Manufacturer> GetManufacturerByIdAsync(int id)
        {
            var manufacturer = await _eCommerceUnitOfWork.ManufacturerRepository.GetSingleAsync(a => a.Id == id);
            if (manufacturer != null && manufacturer.Id > 0)
            {
                manufacturer.Attachments = await _eCommerceUnitOfWork.AttachmentRepository.GetListAsync(a => a.Object == "Manufacturer" && a.ObjectId == manufacturer.Id);
            }
            return manufacturer;
        }

        /// <summary>
        /// Adds the manufacturer.
        /// </summary>
        /// <param name="manufacturers">The manufacturers.</param>
        public void AddManufacturer(params Manufacturer[] manufacturers)
        {
            _eCommerceUnitOfWork.ManufacturerRepository.Add(manufacturers);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// add manufacturer as an asynchronous operation.
        /// </summary>
        /// <param name="manufacturers">The manufacturers.</param>
        public async Task AddManufacturerAsync(params Manufacturer[] manufacturers)
        {
            _eCommerceUnitOfWork.ManufacturerRepository.Add(manufacturers);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the manufacturer.
        /// </summary>
        /// <param name="manufacturers">The manufacturers.</param>
        public void UpdateManufacturer(params Manufacturer[] manufacturers)
        {
            _eCommerceUnitOfWork.ManufacturerRepository.Update(manufacturers);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// update manufacturer as an asynchronous operation.
        /// </summary>
        /// <param name="manufacturers">The manufacturers.</param>
        public async Task UpdateManufacturerAsync(params Manufacturer[] manufacturers)
        {
            _eCommerceUnitOfWork.ManufacturerRepository.Update(manufacturers);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the manufacturer.
        /// </summary>
        /// <param name="manufacturers">The manufacturers.</param>
        public void RemoveManufacturer(params Manufacturer[] manufacturers)
        {
            _eCommerceUnitOfWork.ManufacturerRepository.Remove(manufacturers);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// remove manufacturer as an asynchronous operation.
        /// </summary>
        /// <param name="manufacturers">The manufacturers.</param>
        public async Task RemoveManufacturerAsync(params Manufacturer[] manufacturers)
        {
            _eCommerceUnitOfWork.ManufacturerRepository.Remove(manufacturers);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        #region ILocalizedBL
        /// <summary>
        /// Get full details of the single entity
        /// </summary>
        /// <param name="ofEntity">Passed entity is used as filter, method implementing ths feature should treat this oject apropriatly to call some method of BL class to read full details.</param>
        /// <returns>Entity instance</returns>
        public Manufacturer GetDetails(Manufacturer ofEntity)
        {
            if (ofEntity == null)
                return null;

            if (ofEntity.Id > 0)
                return GetManufacturerById(ofEntity.Id);
            
            return null;
        }

        /// <summary>
        /// Adds the single entity.
        /// </summary>
        /// <param name="manufacturer">The manufacturer.</param>
        public void AddSingleEntity(Manufacturer manufacturer)
        {            
            _eCommerceUnitOfWork.ManufacturerRepository.Add(manufacturer);
            _eCommerceUnitOfWork.Save();
        }
        #endregion

        #endregion
    }

    /// <summary>
    /// Class ManufacturerBL.
    /// Implements the <see cref="BAP.eCommerce.BL.eCommerceBusinessLayer" />
    /// Implements the <see cref="BAP.Common.ISupportLookup" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.BL.eCommerceBusinessLayer" />
    /// <seealso cref="BAP.Common.ISupportLookup" />
    public class ManufacturerBL : eCommerceBusinessLayer, ISupportLookup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManufacturerBL"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public ManufacturerBL(IConfigHelper settings, IAuthorizationContext context, ILogger logger) : base(null, null, settings, context, logger)
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
            var manufacturers = SearchManufacturers(extraFilter, orderBy);
            foreach (var manufacturer in manufacturers)
            {
                var val = manufacturer.GetType().GetProperty(valueField).GetValue(manufacturer, null);
                var text = manufacturer.GetType().GetProperty(textField).GetValue(manufacturer, null);
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = manufacturer.GetType().GetProperty(descriptionField).GetValue(manufacturer, null);
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
            var manufacturers = await SearchManufacturersAsync(extraFilter, orderBy);
            foreach (var manufacturer in manufacturers)
            {
                var val = manufacturer.GetType().GetProperty(valueField).GetValue(manufacturer, null);
                var text = manufacturer.GetType().GetProperty(textField).GetValue(manufacturer, null);
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = manufacturer.GetType().GetProperty(descriptionField).GetValue(manufacturer, null);
                }
                result.Add(new LookupItem { Key = val.ToString(), Text = text.ToString(), Description = descr.ToString() });
            }

            return result;
        }
    }
}
