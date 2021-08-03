// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="ProductBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using PagedList;
using BAP.eCommerce.DAL.Entities;
using BAP.Common;
using BAP.BL;
using BAP.DAL;
using BAP.Log;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using BAP.eCommerce.DataWizards.Services.AbstractTypes;
using BAP.FileSystem;
using System.Web;
using BAP.DAL.Entities;

namespace BAP.eCommerce.BL
{
    /// <summary>
    /// Interface IProductBL
    /// </summary>
    public interface IProductBL
    {
        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>IList&lt;Product&gt;.</returns>
        IList<Product> GetAllProducts();
        /// <summary>
        /// Gets all products asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;Product&gt;&gt;.</returns>
        Task<IList<Product>> GetAllProductsAsync();

        /// <summary>
        /// Gets the featured products.
        /// </summary>
        /// <returns>IList&lt;Product&gt;.</returns>
        IList<Product> GetFeaturedProducts();
        /// <summary>
        /// Gets the featured products asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;Product&gt;&gt;.</returns>
        Task<IList<Product>> GetFeaturedProductsAsync();

        /// <summary>
        /// Searches the products.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>IPagedList&lt;Product&gt;.</returns>
        IPagedList<Product> SearchProducts(string where, string sort, int page, int pageSize = 20, int categoryId = 0);
        /// <summary>
        /// Searches the products asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>Task&lt;IPagedList&lt;Product&gt;&gt;.</returns>
        Task<IPagedList<Product>> SearchProductsAsync(string where, string sort, int page, int pageSize = 20, int categoryId = 0);

        /// <summary>
        /// Searches the products admin.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>IPagedList&lt;Product&gt;.</returns>
        IPagedList<Product> SearchProductsAdmin(string where, string sort, int page, int pageSize = 20, int categoryId = 0);
        /// <summary>
        /// Searches the products admin asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>Task&lt;IPagedList&lt;Product&gt;&gt;.</returns>
        Task<IPagedList<Product>> SearchProductsAdminAsync(string where, string sort, int page, int pageSize = 20, int categoryId = 0);

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Product.</returns>
        Product GetProductById(int id);
        /// <summary>
        /// Gets the product by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Product&gt;.</returns>
        Task<Product> GetProductByIdAsync(int id);

        /// <summary>
        /// Gets the single product by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Product.</returns>
        Product GetSingleProductById(int id);
        /// <summary>
        /// Gets the single product by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Product&gt;.</returns>
        Task<Product> GetSingleProductByIdAsync(int id);

        /// <summary>
        /// Gets the product by public identifier.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>Product.</returns>
        Product GetProductByPublicId(string pid);
        /// <summary>
        /// Gets the product by public identifier asynchronous.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>Task&lt;Product&gt;.</returns>
        Task<Product> GetProductByPublicIdAsync(string pid);

        /// <summary>
        /// Gets the product by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Product.</returns>
        Product GetProductByName(string name);
        /// <summary>
        /// Gets the product by name asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Task&lt;Product&gt;.</returns>
        Task<Product> GetProductByNameAsync(string name);

        /// <summary>
        /// Creates the product.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>Product.</returns>
        Product CreateProduct(int categoryId = -1);

        /// <summary>
        /// Find product by external Id that was imported from supplier
        /// </summary>
        /// <param name="externalId">External Id from supplier</param>
        /// <returns></returns>
        Product GetProductBySuppliersExternalId(int externalId);
        /// <summary>
        /// Creates the product asynchronous.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>Task&lt;Product&gt;.</returns>
        Task<Product> CreateProductAsync(int categoryId = -1);

        /// <summary>
        /// Assigns the currency to product.
        /// </summary>
        /// <param name="product">The product.</param>
        void AssignCurrencyToProduct(Product product);
        /// <summary>
        /// Assigns the currency to product asynchronous.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>Task.</returns>
        Task AssignCurrencyToProductAsync(Product product);

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="products">The products.</param>
        void AddProduct(params Product[] products);
        /// <summary>
        /// Adds the product asynchronous.
        /// </summary>
        /// <param name="products">The products.</param>
        /// <returns>Task.</returns>
        Task AddProductAsync(params Product[] products);

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="uploadFileService">The upload file service.</param>
        /// <param name="fileProcessor">The file processor.</param>
        /// <param name="products">The products.</param>
        void AddProduct(IUploadFileService uploadFileService, IFileProcessor fileProcessor, params Product[] products);

        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="products">The products.</param>
        void UpdateProduct(params Product[] products);


        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="uploadFileService">The upload file service.</param>
        /// <param name="fileProcessor">The file processor.</param>
        /// <param name="products">The products.</param>
        void UpdateProduct(IUploadFileService uploadFileService, IFileProcessor fileProcessor, params Product[] products);

        /// <summary>
        /// Updates the product asynchronous.
        /// </summary>
        /// <param name="products">The products.</param>
        /// <returns>Task.</returns>
        Task UpdateProductAsync(params Product[] products);

        /// <summary>
        /// Removes the product.
        /// </summary>
        /// <param name="products">The products.</param>
        void RemoveProduct(params Product[] products);
        /// <summary>
        /// Removes the product asynchronous.
        /// </summary>
        /// <param name="products">The products.</param>
        /// <returns>Task.</returns>
        Task RemoveProductAsync(params Product[] products);
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
    public partial class eCommerceBusinessLayer : IProductBL, ILocalizedBL<Product>
    {
        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>IList&lt;Product&gt;.</returns>
        public IList<Product> GetAllProducts()
        {
            var currency = ((ICurrencyBL)this).GetMainCurrency();
            var results = _eCommerceUnitOfWork.ProductRepository.GetAll(p => p.ProductCategory);
            foreach (var item in results)
            {
                item.Currency = currency;
            }

            return results;
        }

        /// <summary>
        /// get all products as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;Product&gt;.</returns>
        public async Task<IList<Product>> GetAllProductsAsync()
        {
            var currency = await ((ICurrencyBL)this).GetMainCurrencyAsync();
            var results = await _eCommerceUnitOfWork.ProductRepository.GetAllAsync(p => p.ProductCategory);
            foreach (var item in results)
            {
                item.Currency = currency;
            }

            return results;
        }

        /// <summary>
        /// Gets the featured products.
        /// </summary>
        /// <returns>IList&lt;Product&gt;.</returns>
        public IList<Product> GetFeaturedProducts()
        {
            var currency = ((ICurrencyBL)this).GetMainCurrency();
            var results = _eCommerceUnitOfWork.ProductRepository.GetList(a => a.IsFeatured);
            foreach (var item in results)
            {
                item.Currency = currency;
            }

            return results;
        }

        /// <summary>
        /// get featured products as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;Product&gt;.</returns>
        public async Task<IList<Product>> GetFeaturedProductsAsync()
        {
            var currency = await ((ICurrencyBL)this).GetMainCurrencyAsync();
            var results = await _eCommerceUnitOfWork.ProductRepository.GetListAsync(a => a.IsFeatured);
            foreach (var item in results)
            {
                item.Currency = currency;
            }

            return results;
        }

        /// <summary>
        /// Searches the products.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>IPagedList&lt;Product&gt;.</returns>
        public IPagedList<Product> SearchProducts(string where, string sort, int page, int pageSize = 20, int categoryId = 0)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Product>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }
            var results = _eCommerceUnitOfWork.ProductRepository.GetPagedList(page, pageSize, AttachCategoryToFilter(where, true, categoryId), sortExpression, a => a.ProductCategory);

            //Attaching currentcy
            var currency = ((ICurrencyBL)this).GetMainCurrency();
            foreach (var item in results)
            {
                item.Currency = currency;
            }

            return results;
        }

        /// <summary>
        /// search products as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>IPagedList&lt;Product&gt;.</returns>
        public async Task<IPagedList<Product>> SearchProductsAsync(string where, string sort, int page = 1, int pageSize = 20, int categoryId = 0)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Product>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }
            var results = await _eCommerceUnitOfWork.ProductRepository.GetPagedListAsync(page, pageSize, await AttachCategoryToFilterAsync(where, true, categoryId), sortExpression, a => a.ProductCategory);

            var currency = await ((ICurrencyBL)this).GetMainCurrencyAsync();
            foreach (var item in results)
            {
                item.Currency = currency;
            }

            return results;
        }

        /// <summary>
        /// Finds the category.
        /// </summary>
        /// <param name="categories">The categories.</param>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>ProductCategory.</returns>
        private ProductCategory FindCategory(IList<ProductCategory> categories, int categoryId)
        {
            var result = categories.FirstOrDefault(x => x.Id == categoryId);
            if (result != null) return result;

            foreach (var category in categories.Where(x => x.ChildCategories != null))
            {
                result = FindCategory(category.ChildCategories, categoryId);
                if (result != null) return result;
            }

            return null;
        }

        /// <summary>
        /// Parses the where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="forPublic">if set to <c>true</c> [for public].</param>
        /// <returns>System.String.</returns>
        private string ParseWhere(string where, bool forPublic = false)
        {
            string filter = ParseJSONSearchString<Product>(where);
            if (forPublic)
            {
                if (!string.IsNullOrEmpty(filter))
                    filter += " AND ";
                filter += "Enabled = True AND PublishFrom <= DateTime.Now and PublishTo >= DateTime.Now";

            }

            return filter;
        }
        /// <summary>
        /// Attaches the category to filter.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="forPublic">if set to <c>true</c> [for public].</param>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>System.String.</returns>
        private string AttachCategoryToFilter(string where, bool forPublic = false, int categoryId = 0)
        {
            string filter = ParseWhere(where, forPublic);
            if (categoryId > 0)
            {
                var categories = GetProductCategoriesTree();
                filter = CategoriesToFilter(filter, categories, categoryId);
            }

            return filter;
        }

        /// <summary>
        /// attach category to filter as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="forPublic">if set to <c>true</c> [for public].</param>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>System.String.</returns>
        private async Task<string> AttachCategoryToFilterAsync(string where, bool forPublic = false, int categoryId = 0)
        {
            string filter = ParseWhere(where, forPublic);
            if (categoryId > 0)
            {
                var categories = await GetProductCategoriesTreeAsync();
                filter = CategoriesToFilter(filter, categories, categoryId);
            }
            return filter;
        }

        /// <summary>
        /// Categorieses to filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="categories">The categories.</param>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>System.String.</returns>
        private string CategoriesToFilter(string filter, IList<ProductCategory> categories, int categoryId)
        {
            var currentCategory = FindCategory(categories, categoryId);
            if (currentCategory != null)
            {
                if (!string.IsNullOrEmpty(filter))
                    filter += " AND ";
                var categoryIds = new List<int>();
                GetChildIds(categoryIds, currentCategory);
                var orCondition = string.Join(" OR ", categoryIds.Select(x => $"ProductCategoryId = {x}"));
                filter += $" ({orCondition})";
            }

            return filter;
        }

        /// <summary>
        /// Gets the child ids.
        /// </summary>
        /// <param name="categoryIds">The category ids.</param>
        /// <param name="currentCategory">The current category.</param>
        private void GetChildIds(IList<int> categoryIds, ProductCategory currentCategory)
        {
            if (!categoryIds.Contains(currentCategory.Id))
                categoryIds.Add(currentCategory.Id);

            if (currentCategory.ChildCategories == null || !currentCategory.ChildCategories.Any())
                return;

            foreach (ProductCategory c in currentCategory.ChildCategories)
            {
                GetChildIds(categoryIds, c);
            }
        }

        /// <summary>
        /// Searches the products.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;Product&gt;.</returns>
        public IList<Product> SearchProducts(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Product>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _eCommerceUnitOfWork.ProductRepository.GetList(ParseJSONSearchString<Product>(where), sortExpression);
        }

        /// <summary>
        /// Searches the products admin.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>IPagedList&lt;Product&gt;.</returns>
        public IPagedList<Product> SearchProductsAdmin(string where, string sort, int page, int pageSize = 20, int categoryId = 0)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Product>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            var currency = ((ICurrencyBL)this).GetMainCurrency();
            var results = _eCommerceUnitOfWork.ProductRepository.GetPagedList(page, pageSize, AttachCategoryToFilter(where, false, categoryId), sortExpression, a => a.ProductCategory);

            foreach (var item in results)
            {
                item.Currency = currency;
            }

            return results;
        }

        /// <summary>
        /// search products admin as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>IPagedList&lt;Product&gt;.</returns>
        public async Task<IPagedList<Product>> SearchProductsAdminAsync(string where, string sort, int page, int pageSize = 20, int categoryId = 0)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Product>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            var currency = await ((ICurrencyBL)this).GetMainCurrencyAsync();
            var results = await _eCommerceUnitOfWork.ProductRepository.GetPagedListAsync(page, pageSize, await AttachCategoryToFilterAsync(where, false, categoryId), sortExpression, a => a.ProductCategory);

            foreach (var item in results)
            {
                item.Currency = currency;
            }

            return results;
        }

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Product.</returns>
        public Product GetProductById(int id)
        {
            var product = _eCommerceUnitOfWork.ProductRepository.GetSingle(a => a.Id == id, a => a.RelatedProducts, a => a.RelatedProducts.Select(b => b.SimilarProduct), a => a.ParentProduct, a => a.Supplier, a => a.ProductSupplierData, a => a.Manufacturer, a => a.ProductCategory, a => a.Discounts, a => a.Options, a => a.Options.Select(b => b.ProductOptionItems));
            if (product != null && product.Id > 0)
            {
                product.Currency = ((ICurrencyBL)this).GetMainCurrency();
                product.Attachments = _eCommerceUnitOfWork.AttachmentRepository.GetList(a => a.Object == "Product" && a.ObjectId == product.Id);
            }

            return product;
        }

        /// <summary>
        /// get product by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Product.</returns>
        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _eCommerceUnitOfWork.ProductRepository.GetSingleAsync(a => a.Id == id, a => a.RelatedProducts, a => a.RelatedProducts.Select(b => b.SimilarProduct), a => a.ParentProduct, a => a.Supplier, a => a.ProductSupplierData, a => a.Manufacturer, a => a.ProductCategory, a => a.Discounts, a => a.Options, a => a.Options.Select(b => b.ProductOptionItems));
            if (product != null && product.Id > 0)
            {
                product.Currency = await ((ICurrencyBL)this).GetMainCurrencyAsync();
                product.Attachments = await _eCommerceUnitOfWork.AttachmentRepository.GetListAsync(a => a.Object == "Product" && a.ObjectId == product.Id);
            }

            return product;
        }

        /// <summary>
        /// Gets the single product by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Product.</returns>
        public Product GetSingleProductById(int id)
        {
            return _eCommerceUnitOfWork.ProductRepository.GetSingle(a => a.Id == id);
        }

        /// <summary>
        /// get single product by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Product.</returns>
        public async Task<Product> GetSingleProductByIdAsync(int id)
        {
            return await _eCommerceUnitOfWork.ProductRepository.GetSingleAsync(a => a.Id == id);
        }

        /// <summary>
        /// Gets the product by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Product.</returns>
        public Product GetProductByName(string name)
        {
            var product = _eCommerceUnitOfWork.ProductRepository.GetSingle(a => a.Name == name, a => a.RelatedProducts, a => a.RelatedProducts.Select(b => b.SimilarProduct), a => a.ParentProduct, a => a.Supplier, a => a.ProductSupplierData, a => a.Manufacturer, a => a.ProductCategory, a => a.Discounts, a => a.Options, a => a.Options.Select(b => b.ProductOptionItems));
            if (product != null && product.Id > 0)
            {
                product.Currency = ((ICurrencyBL)this).GetMainCurrency();
                product.Attachments = _eCommerceUnitOfWork.AttachmentRepository.GetList(a => a.Object == "Product" && a.ObjectId == product.Id);
            }

            return product;
        }

        /// <summary>
        /// Get product by name as an asynchronous operation.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Product.</returns>
        public async Task<Product> GetProductByNameAsync(string name)
        {
            var product = await _eCommerceUnitOfWork.ProductRepository.GetSingleAsync(a => a.Name == name, a => a.RelatedProducts, a => a.RelatedProducts.Select(b => b.SimilarProduct), a => a.ParentProduct, a => a.Supplier, a => a.ProductSupplierData, a => a.Manufacturer, a => a.ProductCategory, a => a.Discounts, a => a.Options, a => a.Options.Select(b => b.ProductOptionItems));
            if (product != null && product.Id > 0)
            {
                product.Currency = await ((ICurrencyBL)this).GetMainCurrencyAsync();
                product.Attachments = await _eCommerceUnitOfWork.AttachmentRepository.GetListAsync(a => a.Object == "Product" && a.ObjectId == product.Id);
            }

            return product;
        }

        /// <summary>
        /// Gets the product by public identifier.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>Product.</returns>
        public Product GetProductByPublicId(string pid)
        {
            ISEOFriendly<Product> seoProduct = new Product();
            var product = _eCommerceUnitOfWork.ProductRepository.GetSingle(seoProduct.ByPublicIdExpression(pid), a => a.RelatedProducts, a => a.RelatedProducts.Select(b => b.SimilarProduct), a => a.ParentProduct, a => a.Supplier, a => a.ProductSupplierData, a => a.Manufacturer, a => a.ProductCategory, a => a.Discounts, a => a.Options, a => a.Options.Select(b => b.ProductOptionItems));

            if (product != null && product.Id > 0)
            {
                product.Currency = ((ICurrencyBL)this).GetMainCurrency();
                product.Attachments = _eCommerceUnitOfWork.AttachmentRepository.GetList(a => a.Object == "Product" && a.ObjectId == product.Id);
            }

            return product;
        }

        /// <summary>
        /// get product by public identifier as an asynchronous operation.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>Product.</returns>
        public async Task<Product> GetProductByPublicIdAsync(string pid)
        {
            ISEOFriendly<Product> seoProduct = new Product();
            var product = await _eCommerceUnitOfWork.ProductRepository.GetSingleAsync(seoProduct.ByPublicIdExpression(pid), a => a.RelatedProducts, a => a.RelatedProducts.Select(b => b.SimilarProduct), a => a.ParentProduct, a => a.Supplier, a => a.ProductSupplierData, a => a.Manufacturer, a => a.ProductCategory, a => a.Discounts, a => a.Options, a => a.Options.Select(b => b.ProductOptionItems));

            if (product != null && product.Id > 0)
            {
                product.Currency = await ((ICurrencyBL)this).GetMainCurrencyAsync();
                product.Attachments = await _eCommerceUnitOfWork.AttachmentRepository.GetListAsync(a => a.Object == "Product" && a.ObjectId == product.Id);
            }

            return product;
        }

        /// <summary>
        /// Creates the product.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>Product.</returns>
        public Product CreateProduct(int categoryId = -1)
        {
            var result = new Product { Currency = ((ICurrencyBL)this).GetMainCurrency() };
            if (categoryId > 0)
            {
                result.ProductCategory = this.GetProductCategoryById(categoryId);
                result.ProductCategoryId = categoryId;
            }
            return result;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public Product GetProductBySuppliersExternalId(int externalId)
        {
            var product = _eCommerceUnitOfWork.ProductRepository
                .GetSingle(x => x.ProductSupplierData != null && x.ProductSupplierData.ExternalProductId == externalId,
                    a => a.RelatedProducts, 
                    a => a.RelatedProducts.Select(b => b.SimilarProduct), 
                    a => a.ParentProduct,
                    a => a.Supplier, 
                    a => a.ProductSupplierData,
                    a => a.Manufacturer, 
                    a => a.ProductCategory, 
                    a => a.Discounts, 
                    a => a.Options, 
                    a => a.Options.Select(b => b.ProductOptionItems));

            return product;
        }

        /// <summary>
        /// create product as an asynchronous operation.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>Product.</returns>
        public async Task<Product> CreateProductAsync(int categoryId = -1)
        {
            var result = new Product { Currency = await ((ICurrencyBL)this).GetMainCurrencyAsync() };
            if (categoryId > 0)
            {
                result.ProductCategory = await this.GetProductCategoryByIdAsync(categoryId);
                result.ProductCategoryId = categoryId;
            }

            return result;
        }

        /// <summary>
        /// Assigns the currency to product.
        /// </summary>
        /// <param name="product">The product.</param>
        public void AssignCurrencyToProduct(Product product)
        {
            if (product != null)
            {
                product.Currency = ((ICurrencyBL)this).GetMainCurrency();
            }
        }

        /// <summary>
        /// assign currency to product as an asynchronous operation.
        /// </summary>
        /// <param name="product">The product.</param>
        public async Task AssignCurrencyToProductAsync(Product product)
        {
            if (product != null)
            {
                product.Currency = await ((ICurrencyBL)this).GetMainCurrencyAsync();
            }
        }

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="products">The products.</param>
        public void AddProduct(params Product[] products)
        {
            foreach (var product in products)
            {
                product.UID = Guid.NewGuid();
                FixDates(product);
                ProcessForeignKeys(product);
            }
            _eCommerceUnitOfWork.ProductRepository.Add(products);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// add product as an asynchronous operation.
        /// </summary>
        /// <param name="products">The products.</param>
        public async Task AddProductAsync(params Product[] products)
        {
            foreach (var product in products)
            {
                product.UID = Guid.NewGuid();
                FixDates(product);
                ProcessForeignKeys(product);
            }
            _eCommerceUnitOfWork.ProductRepository.Add(products);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="uploadFileService">The upload file service.</param>
        /// <param name="fileProcessor">The file processor.</param>
        /// <param name="products">The products.</param>
        public void AddProduct(IUploadFileService uploadFileService, IFileProcessor fileProcessor, params Product[] products)
        {
            foreach (var product in products)
            {
                product.UID = Guid.NewGuid();
                FixDates(product);
                ProcessForeignKeys(product);
                _eCommerceUnitOfWork.ProductRepository.Add(product);
                _eCommerceUnitOfWork.Save();
                ProcessImages(uploadFileService, fileProcessor, product);
            }
        }

        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="products">The products.</param>
        public void UpdateProduct(params Product[] products)
        {
            foreach (var product in products)
            {
                FixDates(product);
                ProcessForeignKeys(product);
            }
            _eCommerceUnitOfWork.ProductRepository.Update(products);
            _eCommerceUnitOfWork.Save();
        }


        /// <summary>
        /// Update the product.
        /// </summary>
        /// <param name="uploadFileService">The upload file service.</param>
        /// <param name="fileProcessor">The file processor.</param>
        /// <param name="products">The products.</param>
        public void UpdateProduct(IUploadFileService uploadFileService, IFileProcessor fileProcessor, params Product[] products)
        {
            foreach (var product in products)
            {
                FixDates(product);
                ProcessForeignKeys(product);
                _eCommerceUnitOfWork.ProductRepository.Update(product);
                _eCommerceUnitOfWork.Save();
                ProcessImages(uploadFileService, fileProcessor, product);
            }
        }

        /// <summary>
        /// update product as an asynchronous operation.
        /// </summary>
        /// <param name="products">The products.</param>
        public async Task UpdateProductAsync(params Product[] products)
        {
            foreach (var product in products)
            {
                FixDates(product);
                ProcessForeignKeys(product);
            }
            _eCommerceUnitOfWork.ProductRepository.Update(products);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the product.
        /// </summary>
        /// <param name="products">The products.</param>
        public void RemoveProduct(params Product[] products)
        {
            foreach (var product in products)
            {
                ProcessForeignKeys(product);
            }
            _eCommerceUnitOfWork.ProductRepository.Remove(products);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// remove product as an asynchronous operation.
        /// </summary>
        /// <param name="products">The products.</param>
        public async Task RemoveProductAsync(params Product[] products)
        {
            foreach (var product in products)
            {
                ProcessForeignKeys(product);
            }
            _eCommerceUnitOfWork.ProductRepository.Remove(products);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Determines whether [is external file] [the specified path].
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns><c>true</c> if [is external file] [the specified path]; otherwise, <c>false</c>.</returns>
        private bool IsExternalFile(string path)
        {
            return !string.IsNullOrWhiteSpace(path) && path.ToLowerInvariant().StartsWith("http:") || path.ToLowerInvariant().StartsWith("https:");
        }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>System.String.</returns>
        private string GetFileName(Uri uri)
        {
            return Path.GetFileName(uri.LocalPath);
        }

        /// <summary>
        /// Determines whether [is image valid] [the specified file].
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns><c>true</c> if [is image valid] [the specified file]; otherwise, <c>false</c>.</returns>
        private bool IsImageValid(HttpPostedFileBase file)
        {
            try
            {
                var img = System.Drawing.Image.FromStream(file.InputStream);
                return true;
            }
            catch
            {
                // bad image
                return false;
            }
        }

        /// <summary>
        /// Uploads the external file.
        /// </summary>
        /// <param name="uploadFileService">The upload file service.</param>
        /// <param name="fileProcessor">The file processor.</param>
        /// <param name="imagePath">The image path.</param>
        /// <returns>System.String.</returns>
        private string UploadExternalFile(IUploadFileService uploadFileService, IFileProcessor fileProcessor, string imagePath)
        {
            string uploadedPath = imagePath;
            if (IsExternalFile(imagePath))
            {
                using (var client = new WebClient())
                {
                    var uri = new Uri(imagePath);
                    var fileName = GetFileName(uri);
                    var bytes = client.DownloadData(uri);
                    string mimeType = MimeMapping.GetMimeMapping(fileName);
                    var objFile = (HttpPostedFileBase)new MemoryPostedFile(bytes, fileName, mimeType);
                    if (IsImageValid(objFile))
                        uploadedPath = uploadFileService.UploadFile(objFile, fileProcessor, true);
                }
            }
            return uploadedPath;
        }

        /// <summary>
        /// Processes the images.
        /// </summary>
        /// <param name="uploadFileService">The upload file service.</param>
        /// <param name="fileProcessor">The file processor.</param>
        /// <param name="product">The product.</param>
        private void ProcessImages(IUploadFileService uploadFileService, IFileProcessor fileProcessor, Product product)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            product.ImagePath = $"/file/{UploadExternalFile(uploadFileService, fileProcessor, product.ImagePath)}";

            if (product.ExtraImages != null && product.ExtraImages.Any())
                foreach (var extraImage in product.ExtraImages)
                {
                    var uploadedPath = UploadExternalFile(uploadFileService, fileProcessor, extraImage);
                    var bapFile = fileProcessor.GetFile(uploadedPath);
                    var attachment = new Attachment
                    {
                        Name = $"Attachment for {product.Name} at {DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss:fff")}",
                        Description = $"Attachment for {product.Name}",
                        Object = "Product",
                        ObjectId = product.Id,
                        AttachmentType = "photo",
                        Status = "new",
                        StatusDate = DateTime.Now,
                        Published = true,
                        PublishFrom = DateTime.Now,
                        PublishTo = DateTime.Now.AddYears(1),
                        MimeType = bapFile.MimeType,
                        PathUrl = bapFile.Path
                    };
                    AddAttachment(attachment);
                }
        }

        /// <summary>
        /// Processes the foreign keys.
        /// </summary>
        /// <param name="product">The product.</param>
        private void ProcessForeignKeys(Product product)
        {
            //temporary solution - has to be made smarter
            product.Attachments = null;
            product.Manufacturer = null;
            product.ParentProduct = null;
            product.ProductCategory = null;
            product.RelatedProducts = null;
            product.Supplier = null;
        }

        /// <summary>
        /// Fixes the dates.
        /// </summary>
        /// <param name="product">The product.</param>
        private void FixDates(Product product)
        {
            if (product == null)
                return;

            if (product.PublishFrom == DateTime.MinValue)
                product.PublishFrom = DateTime.Now;
            if (product.PublishTo == DateTime.MinValue)
                product.PublishTo = DateTime.Now.AddDays(30);
            if (product.InStoreFrom == DateTime.MinValue)
                product.InStoreFrom = DateTime.Now;
            if (product.ReorderAt == DateTime.MinValue)
                product.ReorderAt = DateTime.Now.AddDays(30);
        }

        #region ILocalizedBL
        /// <summary>
        /// Get full details of the single entity
        /// </summary>
        /// <param name="ofEntity">Passed entity is used as filter, method implementing ths feature should treat this oject apropriatly to call some method of BL class to read full details.</param>
        /// <returns>Entity instance</returns>
        public Product GetDetails(Product ofEntity)
        {
            if (ofEntity == null)
                return null;

            if (ofEntity.Id > 0)
                return GetProductById(ofEntity.Id);            

            return null;
        }

        /// <summary>
        /// Adds the single entity.
        /// </summary>
        /// <param name="product">The product.</param>
        public void AddSingleEntity(Product product)
        {
            product.UID = Guid.NewGuid();
            FixDates(product);
            ProcessForeignKeys(product);

            _eCommerceUnitOfWork.ProductRepository.Add(product);
            _eCommerceUnitOfWork.Save();
        }

        #endregion
    }

    /// <summary>
    /// Class ProductBL.
    /// Implements the <see cref="BAP.eCommerce.BL.eCommerceBusinessLayer" />
    /// Implements the <see cref="BAP.Common.ISupportLookup" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.BL.eCommerceBusinessLayer" />
    /// <seealso cref="BAP.Common.ISupportLookup" />
    public class ProductBL : eCommerceBusinessLayer, ISupportLookup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductBL"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public ProductBL(IConfigHelper settings, IAuthorizationContext context, ILogger logger) : base(null, null, settings, context, logger)
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
            var products = SearchProducts(extraFilter, orderBy);
            foreach (var product in products)
            {
                var val = product.GetType().GetProperty(valueField).GetValue(product, null);
                var text = product.GetType().GetProperty(textField).GetValue(product, null);
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = product.GetType().GetProperty(descriptionField).GetValue(product, null);
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
            var products = await SearchProductsAsync(extraFilter, orderBy);
            foreach (var product in products)
            {
                var val = product.GetType().GetProperty(valueField).GetValue(product, null);
                var text = product.GetType().GetProperty(textField).GetValue(product, null);
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = product.GetType().GetProperty(descriptionField).GetValue(product, null);
                }
                result.Add(new LookupItem { Key = val.ToString(), Text = text.ToString(), Description = descr.ToString() });
            }

            return result;
        }
    }
}
