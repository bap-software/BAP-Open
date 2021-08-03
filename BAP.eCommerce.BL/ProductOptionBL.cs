// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="ProductOptionBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;
using System.Collections.Generic;

using PagedList;

using BAP.Common;
using BAP.eCommerce.DAL.Entities;

using BAP.eCommerce.Resources;
using BAP.eCommerce.Common.Exceptions;
using System;
using System.Threading.Tasks;

namespace BAP.eCommerce.BL
{
    /// <summary>
    /// Interface IProductOptionBL
    /// </summary>
    public interface IProductOptionBL
    {
        /// <summary>
        /// Gets all product options.
        /// </summary>
        /// <returns>IList&lt;ProductOption&gt;.</returns>
        IList<ProductOption> GetAllProductOptions();
        /// <summary>
        /// Gets all product options asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;ProductOption&gt;&gt;.</returns>
        Task<IList<ProductOption>> GetAllProductOptionsAsync();

        /// <summary>
        /// Searches the product options.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ProductOption&gt;.</returns>
        IPagedList<ProductOption> SearchProductOptions(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the product options asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;ProductOption&gt;&gt;.</returns>
        Task<IPagedList<ProductOption>> SearchProductOptionsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the product option by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ProductOption.</returns>
        ProductOption GetProductOptionById(int id);
        /// <summary>
        /// Gets the product option by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ProductOption&gt;.</returns>
        Task<ProductOption> GetProductOptionByIdAsync(int id);

        /// <summary>
        /// Adds the product option.
        /// </summary>
        /// <param name="productOptions">The product options.</param>
        void AddProductOption(ProductOption productOptions);
        /// <summary>
        /// Adds the product option asynchronous.
        /// </summary>
        /// <param name="productOptions">The product options.</param>
        /// <returns>Task.</returns>
        Task AddProductOptionAsync(ProductOption productOptions);

        /// <summary>
        /// Updates the product option.
        /// </summary>
        /// <param name="productOptions">The product options.</param>
        void UpdateProductOption(ProductOption productOptions);
        /// <summary>
        /// Updates the product option asynchronous.
        /// </summary>
        /// <param name="productOptions">The product options.</param>
        /// <returns>Task.</returns>
        Task UpdateProductOptionAsync(ProductOption productOptions);

        /// <summary>
        /// Removes the product option.
        /// </summary>
        /// <param name="productOptions">The product options.</param>
        void RemoveProductOption(params ProductOption[] productOptions);
        /// <summary>
        /// Removes the product option asynchronous.
        /// </summary>
        /// <param name="productOptions">The product options.</param>
        /// <returns>Task.</returns>
        Task RemoveProductOptionAsync(params ProductOption[] productOptions);

        /// <summary>
        /// Removes the item from option.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        /// <param name="productId">The product identifier.</param>
        void RemoveItemFromOption(ProductOption productOption, params int[] productId);
        /// <summary>
        /// Removes the item from option asynchronous.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        /// <param name="productId">The product identifier.</param>
        /// <returns>Task.</returns>
        Task RemoveItemFromOptionAsync(ProductOption productOption, params int[] productId);

        /// <summary>
        /// Creates the single item.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        void CreateSingleItem(ProductOption productOption);
        /// <summary>
        /// Creates the single item asynchronous.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        /// <returns>Task.</returns>
        Task CreateSingleItemAsync(ProductOption productOption);

        /// <summary>
        /// Updates the option item.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="priceAdded">The price added.</param>
        /// <param name="itemShortDescription">The item short description.</param>
        /// <param name="itemRelatedProductId">The item related product identifier.</param>
        /// <param name="itemDescription">The item description.</param>
        void UpdateOptionItem(ProductOption productOption, int itemId, string itemName, decimal priceAdded, string itemShortDescription, int? itemRelatedProductId, string itemDescription);
        /// <summary>
        /// Updates the option item asynchronous.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="priceAdded">The price added.</param>
        /// <param name="itemShortDescription">The item short description.</param>
        /// <param name="itemRelatedProductId">The item related product identifier.</param>
        /// <param name="itemDescription">The item description.</param>
        /// <returns>Task.</returns>
        Task UpdateOptionItemAsync(ProductOption productOption, int itemId, string itemName, decimal priceAdded, string itemShortDescription, int? itemRelatedProductId, string itemDescription);

        /// <summary>
        /// Adds the product to option.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        /// <param name="productId">The product identifier.</param>
        void AddProductToOption(ProductOption productOption, params int[] productId);
        /// <summary>
        /// Adds the product to option asynchronous.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        /// <param name="productId">The product identifier.</param>
        /// <returns>Task.</returns>
        Task AddProductToOptionAsync(ProductOption productOption, params int[] productId);

        /// <summary>
        /// Removes the product from option.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        /// <param name="productId">The product identifier.</param>
        void RemoveProductFromOption(ProductOption productOption, params int[] productId);
        /// <summary>
        /// Removes the product from option asynchronous.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        /// <param name="productId">The product identifier.</param>
        /// <returns>Task.</returns>
        Task RemoveProductFromOptionAsync(ProductOption productOption, params int[] productId);
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
    public partial class eCommerceBusinessLayer : IProductOptionBL, ILocalizedBL<ProductOption>
    {
        #region productOptions

        /// <summary>
        /// Gets all product options.
        /// </summary>
        /// <returns>IList&lt;ProductOption&gt;.</returns>
        public IList<ProductOption> GetAllProductOptions()
        {
            return _eCommerceUnitOfWork.ProductOptionRepository.GetAll();
        }

        /// <summary>
        /// get all product options as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;ProductOption&gt;.</returns>
        public async Task<IList<ProductOption>> GetAllProductOptionsAsync()
        {
            return await _eCommerceUnitOfWork.ProductOptionRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the product options.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ProductOption&gt;.</returns>
        public IPagedList<ProductOption> SearchProductOptions(string where, string sort, int page, int pageSize = 20)
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

            return _eCommerceUnitOfWork.ProductOptionRepository.GetPagedList(page, pageSize, ParseJSONSearchString<ProductOption>(where), sortExpression, a => a.ProductOptionItems);
        }

        /// <summary>
        /// search product options as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ProductOption&gt;.</returns>
        public async Task<IPagedList<ProductOption>> SearchProductOptionsAsync(string where, string sort, int page, int pageSize = 20)
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

            return await _eCommerceUnitOfWork.ProductOptionRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<ProductOption>(where), sortExpression, a => a.ProductOptionItems);
        }

        /// <summary>
        /// Gets the product option by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ProductOption.</returns>
        public ProductOption GetProductOptionById(int id)
        {
            return _eCommerceUnitOfWork.ProductOptionRepository.GetSingle(a => a.Id == id, a => a.ProductOptionItems, a => a.Products, a => a.ProductOptionItems.Select(p => p.RelatedProduct));
        }

        /// <summary>
        /// get product option by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ProductOption.</returns>
        public async Task<ProductOption> GetProductOptionByIdAsync(int id)
        {
            return await _eCommerceUnitOfWork.ProductOptionRepository.GetSingleAsync(a => a.Id == id, a => a.ProductOptionItems, a => a.Products, a => a.ProductOptionItems.Select(p => p.RelatedProduct));
        }

        /// <summary>
        /// Adds the product option.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        public void AddProductOption(ProductOption productOption)
        {
            ValidateProductOptionBeforeSave(productOption);

            _eCommerceUnitOfWork.ProductOptionRepository.Add(productOption);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// add product option as an asynchronous operation.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        public async Task AddProductOptionAsync(ProductOption productOption)
        {
            ValidateProductOptionBeforeSave(productOption);

            _eCommerceUnitOfWork.ProductOptionRepository.Add(productOption);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the product option.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        public void UpdateProductOption(ProductOption productOption)
        {
            ValidateProductOptionBeforeSave(productOption);

            _eCommerceUnitOfWork.ProductOptionRepository.Update(productOption);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// update product option as an asynchronous operation.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        public async Task UpdateProductOptionAsync(ProductOption productOption)
        {
            ValidateProductOptionBeforeSave(productOption);

            _eCommerceUnitOfWork.ProductOptionRepository.Update(productOption);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Validates the product option before save.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        /// <exception cref="ProductOptionException"></exception>
        /// <exception cref="ProductOptionException"></exception>
        private void ValidateProductOptionBeforeSave(ProductOption productOption)
        {
            if ((productOption.Type == ProductOptionType.Attribute || productOption.Type == ProductOptionType.Product)
                && (productOption.UserControl == ProductOptionUserControl.Text || productOption.UserControl == ProductOptionUserControl.TextArea))
            {
                throw new ProductOptionException(ResObject.ErrorText_NotAcceptableUCForProductOptionAttrOrProduct);
            }

            if (productOption.Type == ProductOptionType.Text
                && productOption.UserControl != ProductOptionUserControl.Text && productOption.UserControl != ProductOptionUserControl.TextArea)
            {
                throw new ProductOptionException(ResObject.ErrorText_NotaAcceptableUCForProductOptionText);
            }
        }

        /// <summary>
        /// Removes the product option.
        /// </summary>
        /// <param name="productOptions">The product options.</param>
        public void RemoveProductOption(params ProductOption[] productOptions)
        {
            _eCommerceUnitOfWork.ProductOptionRepository.Remove(productOptions);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// remove product option as an asynchronous operation.
        /// </summary>
        /// <param name="productOptions">The product options.</param>
        public async Task RemoveProductOptionAsync(params ProductOption[] productOptions)
        {
            _eCommerceUnitOfWork.ProductOptionRepository.Remove(productOptions);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the item from option.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        /// <param name="productId">The product identifier.</param>
        public void RemoveItemFromOption(ProductOption productOption, params int[] productId)
        {
            if (productOption == null || productId == null)
                return;

            if (productOption.ProductOptionItems != null)
            {
                _eCommerceUnitOfWork.ProductOptionRepository.AttachIfDetached(productOption);
                foreach (var id in productId)
                {
                    var itemToRemove = productOption.ProductOptionItems.SingleOrDefault(a => a.Id == id);
                    productOption.ProductOptionItems.Remove(itemToRemove);
                    _eCommerceUnitOfWork.ProductOptionItemRepository.Remove(itemToRemove);
                }
                _eCommerceUnitOfWork.Save();
            }
        }

        /// <summary>
        /// remove item from option as an asynchronous operation.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        /// <param name="productId">The product identifier.</param>
        public async Task RemoveItemFromOptionAsync(ProductOption productOption, params int[] productId)
        {
            if (productOption == null || productId == null)
                return;

            if (productOption.ProductOptionItems != null)
            {
                _eCommerceUnitOfWork.ProductOptionRepository.AttachIfDetached(productOption);
                foreach (var id in productId)
                {
                    var itemToRemove = productOption.ProductOptionItems.SingleOrDefault(a => a.Id == id);
                    productOption.ProductOptionItems.Remove(itemToRemove);
                    _eCommerceUnitOfWork.ProductOptionItemRepository.Remove(itemToRemove);
                }
                await _eCommerceUnitOfWork.SaveAsync();
            }
        }

        /// <summary>
        /// Creates the single item.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        public void CreateSingleItem(ProductOption productOption)
        {
            if (productOption == null)
                return;

            _eCommerceUnitOfWork.ProductOptionRepository.AttachIfDetached(productOption);

            if (productOption.ProductOptionItems == null)
                productOption.ProductOptionItems = new List<ProductOptionItem>();

            var itemNumberText = (productOption.ProductOptionItems.Count + 1).ToString();
            var item = new ProductOptionItem
            {
                Name = productOption.Name + " " + BAP.Resources.Resources.UIText_Item.ToLower() + " #" + itemNumberText,
                ShortDescription = BAP.Resources.Resources.UIText_Description + " " + itemNumberText
            };
            productOption.ProductOptionItems.Add(item);
            _eCommerceUnitOfWork.ProductOptionItemRepository.Add(item);

            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// create single item as an asynchronous operation.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        public async Task CreateSingleItemAsync(ProductOption productOption)
        {
            if (productOption == null)
                return;

            _eCommerceUnitOfWork.ProductOptionRepository.AttachIfDetached(productOption);

            if (productOption.ProductOptionItems == null)
                productOption.ProductOptionItems = new List<ProductOptionItem>();

            var itemNumberText = (productOption.ProductOptionItems.Count + 1).ToString();
            var item = new ProductOptionItem
            {
                Name = productOption.Name + " " + BAP.Resources.Resources.UIText_Item.ToLower() + " #" + itemNumberText,
                ShortDescription = BAP.Resources.Resources.UIText_Description + " " + itemNumberText
            };
            productOption.ProductOptionItems.Add(item);
            _eCommerceUnitOfWork.ProductOptionItemRepository.Add(item);

            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the option item.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="priceAdded">The price added.</param>
        /// <param name="itemShortDescription">The item short description.</param>
        /// <param name="itemRelatedProductId">The item related product identifier.</param>
        /// <param name="itemDescription">The item description.</param>
        /// <exception cref="ProductOptionException"></exception>
        /// <exception cref="ProductOptionException"></exception>
        public void UpdateOptionItem(ProductOption productOption, int itemId, string itemName, decimal priceAdded, string itemShortDescription, int? itemRelatedProductId, string itemDescription)
        {
            if (productOption == null || itemId < 1)
                return;

            if (itemRelatedProductId != null)
            {
                var optionItemProduct = productOption.ProductOptionItems.SingleOrDefault(a => a.Id != itemId && a.RelatedProductId == itemRelatedProductId.Value);
                if (optionItemProduct != null)
                {
                    if (optionItemProduct.RelatedProductId > 0 && optionItemProduct.RelatedProduct == null)
                        optionItemProduct.RelatedProduct = GetProductById(optionItemProduct.RelatedProductId.Value);
                    throw new ProductOptionException(string.Format(ResObject.ErrorText_ProductItemAlreadyPresent, optionItemProduct.RelatedProduct.Name));
                }

                var optionProductListProduct = productOption.Products.SingleOrDefault(a => a.Id == itemRelatedProductId.Value);
                if (optionProductListProduct != null)
                {
                    throw new ProductOptionException(string.Format(ResObject.ErrorText_ProductItemAlreadyProduct, optionProductListProduct.Name));
                }
            }

            _eCommerceUnitOfWork.ProductOptionRepository.AttachIfDetached(productOption);
            var itemToUpdate = productOption.ProductOptionItems.SingleOrDefault(a => a.Id == itemId);
            if (itemToUpdate != null)
            {
                _eCommerceUnitOfWork.ProductOptionItemRepository.AttachIfDetached(itemToUpdate);
                itemToUpdate.Name = itemName;
                itemToUpdate.PriceAdded = priceAdded;
                itemToUpdate.ShortDescription = itemShortDescription;
                itemToUpdate.Description = itemDescription;
                if (itemRelatedProductId != null)
                    itemToUpdate.RelatedProductId = itemRelatedProductId;
                _eCommerceUnitOfWork.ProductOptionItemRepository.Update(itemToUpdate);

                _eCommerceUnitOfWork.Save();
            }
        }

        /// <summary>
        /// update option item as an asynchronous operation.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="priceAdded">The price added.</param>
        /// <param name="itemShortDescription">The item short description.</param>
        /// <param name="itemRelatedProductId">The item related product identifier.</param>
        /// <param name="itemDescription">The item description.</param>
        /// <exception cref="ProductOptionException"></exception>
        /// <exception cref="ProductOptionException"></exception>
        public async Task UpdateOptionItemAsync(ProductOption productOption, int itemId, string itemName, decimal priceAdded,
            string itemShortDescription, int? itemRelatedProductId, string itemDescription)
        {
            if (productOption == null || itemId < 1)
                return;

            if (itemRelatedProductId != null)
            {
                var optionItemProduct = productOption.ProductOptionItems.SingleOrDefault(a => a.Id != itemId && a.RelatedProductId == itemRelatedProductId.Value);
                if (optionItemProduct != null)
                {
                    if (optionItemProduct.RelatedProductId > 0 && optionItemProduct.RelatedProduct == null)
                        optionItemProduct.RelatedProduct = await GetProductByIdAsync(optionItemProduct.RelatedProductId.Value);
                    throw new ProductOptionException(string.Format(ResObject.ErrorText_ProductItemAlreadyPresent, optionItemProduct.RelatedProduct.Name));
                }

                var optionProductListProduct = productOption.Products.SingleOrDefault(a => a.Id == itemRelatedProductId.Value);
                if (optionProductListProduct != null)
                {
                    throw new ProductOptionException(string.Format(ResObject.ErrorText_ProductItemAlreadyProduct, optionProductListProduct.Name));
                }
            }

            _eCommerceUnitOfWork.ProductOptionRepository.AttachIfDetached(productOption);
            var itemToUpdate = productOption.ProductOptionItems.SingleOrDefault(a => a.Id == itemId);
            if (itemToUpdate != null)
            {
                _eCommerceUnitOfWork.ProductOptionItemRepository.AttachIfDetached(itemToUpdate);
                itemToUpdate.Name = itemName;
                itemToUpdate.PriceAdded = priceAdded;
                itemToUpdate.ShortDescription = itemShortDescription;
                itemToUpdate.Description = itemDescription;
                if (itemRelatedProductId != null)
                    itemToUpdate.RelatedProductId = itemRelatedProductId;
                _eCommerceUnitOfWork.ProductOptionItemRepository.Update(itemToUpdate);

                await _eCommerceUnitOfWork.SaveAsync();
            }
        }

        /// <summary>
        /// Adds the product to option.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        /// <param name="productId">The product identifier.</param>
        /// <exception cref="ProductOptionException"></exception>
        public void AddProductToOption(ProductOption productOption, params int[] productId)
        {
            if (productOption == null || productId == null)
                return;

            // check if no such product present as option item
            if (productOption.Type == ProductOptionType.Product)
            {
                foreach (var id in productId)
                {
                    var itemProduct = productOption.ProductOptionItems.SingleOrDefault(a => a.RelatedProductId == id);
                    if (itemProduct != null)
                        throw new ProductOptionException(string.Format(ResObject.ErrorText_ProductAlreadyOptionItem, itemProduct.RelatedProduct.Name));
                }
            }

            _eCommerceUnitOfWork.ProductOptionRepository.AttachIfDetached(productOption);
            if (productOption.Products == null)
                productOption.Products = new List<Product>();

            foreach (var id in productId)
            {
                if (productOption.Products.Any(a => a.Id == id))
                    continue;

                var product = ((IProductBL)this).GetSingleProductById(id);
                if (product != null)
                {
                    _eCommerceUnitOfWork.ProductRepository.AttachIfDetached(product);
                    productOption.Products.Add(product);
                }
            }

            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// add product to option as an asynchronous operation.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        /// <param name="productId">The product identifier.</param>
        /// <exception cref="ProductOptionException"></exception>
        public async Task AddProductToOptionAsync(ProductOption productOption, params int[] productId)
        {
            if (productOption == null || productId == null)
                return;

            // check if no such product present as option item
            if (productOption.Type == ProductOptionType.Product)
            {
                foreach (var id in productId)
                {
                    var itemProduct = productOption.ProductOptionItems.SingleOrDefault(a => a.RelatedProductId == id);
                    if (itemProduct != null)
                        throw new ProductOptionException(string.Format(ResObject.ErrorText_ProductAlreadyOptionItem, itemProduct.RelatedProduct.Name));
                }
            }

            _eCommerceUnitOfWork.ProductOptionRepository.AttachIfDetached(productOption);
            if (productOption.Products == null)
                productOption.Products = new List<Product>();

            foreach (var id in productId)
            {
                if (productOption.Products.Any(a => a.Id == id))
                    continue;

                var product = await ((IProductBL)this).GetSingleProductByIdAsync(id);
                if (product != null)
                {
                    _eCommerceUnitOfWork.ProductRepository.AttachIfDetached(product);
                    productOption.Products.Add(product);
                }
            }

            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the product from option.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        /// <param name="productId">The product identifier.</param>
        public void RemoveProductFromOption(ProductOption productOption, params int[] productId)
        {
            if (productOption == null || productId == null)
                return;

            if (productOption.Products != null)
            {
                _eCommerceUnitOfWork.ProductOptionRepository.AttachIfDetached(productOption);
                foreach (var id in productId)
                {
                    var itemToRemove = productOption.Products.SingleOrDefault(a => a.Id == id);
                    productOption.Products.Remove(itemToRemove);
                }
                _eCommerceUnitOfWork.Save();
            }
        }

        /// <summary>
        /// remove product from option as an asynchronous operation.
        /// </summary>
        /// <param name="productOption">The product option.</param>
        /// <param name="productId">The product identifier.</param>
        public async Task RemoveProductFromOptionAsync(ProductOption productOption, params int[] productId)
        {
            if (productOption == null || productId == null)
                return;

            if (productOption.Products != null)
            {
                _eCommerceUnitOfWork.ProductOptionRepository.AttachIfDetached(productOption);
                foreach (var id in productId)
                {
                    var itemToRemove = productOption.Products.SingleOrDefault(a => a.Id == id);
                    productOption.Products.Remove(itemToRemove);
                }
                await _eCommerceUnitOfWork.SaveAsync();
            }
        }

        #region ILocalizedBL
        /// <summary>
        /// Get full details of the single entity
        /// </summary>
        /// <param name="ofEntity">Passed entity is used as filter, method implementing ths feature should treat this oject apropriatly to call some method of BL class to read full details.</param>
        /// <returns>Entity instance</returns>
        public ProductOption GetDetails(ProductOption ofEntity)
        {
            if (ofEntity == null)
                return null;

            if (ofEntity.Id > 0)
                return GetProductOptionById(ofEntity.Id);
            
            return null;
        }

        /// <summary>
        /// Adds the single entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void AddSingleEntity(ProductOption entity)
        {
            _eCommerceUnitOfWork.ProductOptionRepository.Add(entity);
            _eCommerceUnitOfWork.Save();
        }
        #endregion

        #endregion
    }

}
