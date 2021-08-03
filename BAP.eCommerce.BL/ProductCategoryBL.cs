// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="ProductCategoryBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Linq;

using PagedList;

using BAP.Common;
using BAP.eCommerce.DAL.Entities;
using BAP.DAL;
using BAP.Log;
using BAP.eCommerce.Common.Exceptions;
using BAP.eCommerce.Resources;
using System;
using System.Threading.Tasks;
using BAP.eCommerce.BL.ProductCategoryNodes;

namespace BAP.eCommerce.BL
{
    /// <summary>
    /// Interface IProductCategoryBL
    /// </summary>
    public interface IProductCategoryBL
    {
        /// <summary>
        /// Gets all product categories.
        /// </summary>
        /// <returns>IList&lt;ProductCategory&gt;.</returns>
        IList<ProductCategory> GetAllProductCategories();
        /// <summary>
        /// Gets all product categories asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;ProductCategory&gt;&gt;.</returns>
        Task<IList<ProductCategory>> GetAllProductCategoriesAsync();

        /// <summary>
        /// Gets the product categories tree.
        /// </summary>
        /// <param name="selectedCategory">The selected category.</param>
        /// <returns>IList&lt;ProductCategory&gt;.</returns>
        IList<ProductCategory> GetProductCategoriesTree(int selectedCategory = 0);
        /// <summary>
        /// Gets the product categories tree asynchronous.
        /// </summary>
        /// <param name="selectedCategory">The selected category.</param>
        /// <returns>Task&lt;IList&lt;ProductCategory&gt;&gt;.</returns>
        Task<IList<ProductCategory>> GetProductCategoriesTreeAsync(int selectedCategory = 0);

        /// <summary>
        /// Searches the product categories.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ProductCategory&gt;.</returns>
        IPagedList<ProductCategory> SearchProductCategories(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the product categories asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;ProductCategory&gt;&gt;.</returns>
        Task<IPagedList<ProductCategory>> SearchProductCategoriesAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the product category by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ProductCategory.</returns>
        ProductCategory GetProductCategoryById(int id);
        /// <summary>
        /// Gets the product category by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ProductCategory&gt;.</returns>
        Task<ProductCategory> GetProductCategoryByIdAsync(int id);

        /// <summary>
        /// Gets the product category by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>ProductCategory.</returns>
        ProductCategory GetProductCategoryByName(string name);
        /// <summary>
        /// Gets the product category by name asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Task&lt;ProductCategory&gt;.</returns>
        Task<ProductCategory> GetProductCategoryByNameAsync(string name);

        /// <summary>
        /// Gets the product category by public identifier.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>ProductCategory.</returns>
        ProductCategory GetProductCategoryByPublicId(string pid);
        /// <summary>
        /// Gets the product category by public identifier asynchronous.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>Task&lt;ProductCategory&gt;.</returns>
        Task<ProductCategory> GetProductCategoryByPublicIdAsync(string pid);

        /// <summary>
        /// Adds the product category.
        /// </summary>
        /// <param name="productCategories">The product categories.</param>
        void AddProductCategory(params ProductCategory[] productCategories);
        /// <summary>
        /// Adds the product category asynchronous.
        /// </summary>
        /// <param name="productCategories">The product categories.</param>
        /// <returns>Task.</returns>
        Task AddProductCategoryAsync(params ProductCategory[] productCategories);

        /// <summary>
        /// Updates the product category.
        /// </summary>
        /// <param name="productCategories">The product categories.</param>
        void UpdateProductCategory(params ProductCategory[] productCategories);
        /// <summary>
        /// Updates the product category asynchronous.
        /// </summary>
        /// <param name="productCategories">The product categories.</param>
        /// <returns>Task.</returns>
        Task UpdateProductCategoryAsync(params ProductCategory[] productCategories);

        /// <summary>
        /// Removes the product category.
        /// </summary>
        /// <param name="productCategories">The product categories.</param>
        void RemoveProductCategory(params ProductCategory[] productCategories);
        /// <summary>
        /// Removes the product category asynchronous.
        /// </summary>
        /// <param name="productCategories">The product categories.</param>
        /// <returns>Task.</returns>
        Task RemoveProductCategoryAsync(params ProductCategory[] productCategories);

        /// <summary>
        /// Gets the product category tree.
        /// </summary>
        /// <param name="categories">The categories.</param>
        /// <returns>ProductCategoryNode.</returns>
        ProductCategoryNode GetProductCategoryTree(IList<ProductCategory> categories);        
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
    public partial class eCommerceBusinessLayer : IProductCategoryBL, ILocalizedBL<ProductCategory>
    {
        #region productCategories

        /// <summary>
        /// Gets all product categories.
        /// </summary>
        /// <returns>IList&lt;ProductCategory&gt;.</returns>
        public IList<ProductCategory> GetAllProductCategories()
        {
            return _eCommerceUnitOfWork.ProductCategoryRepository.GetAll(a => a.ParentCategory).OrderBy(a => a.Order).ToList();
        }

        /// <summary>
        /// get all product categories as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;ProductCategory&gt;.</returns>
        public async Task<IList<ProductCategory>> GetAllProductCategoriesAsync()
        {
            return await _eCommerceUnitOfWork.ProductCategoryRepository.GetAllAsync(a => a.ParentCategory);
        }

        /// <summary>
        /// Gets the product categories tree.
        /// </summary>
        /// <param name="selectedCategory">The selected category.</param>
        /// <returns>IList&lt;ProductCategory&gt;.</returns>
        public IList<ProductCategory> GetProductCategoriesTree(int selectedCategory = 0)
        {
            var categories = GetAllProductCategories();
            var result = new List<ProductCategory>();
            var index = new List<int>();
            var products = GetAllProducts();
            foreach (var product in products)
                product.ProductCategory = GetProductCategory(categories, product.ProductCategoryId);
            foreach (var cat in categories)
            {
                cat.ChildCategories = new List<ProductCategory>();
                if (cat.Id == selectedCategory)
                    cat.Selected = true;

                var productsByCategory = products.Where(p => p.ProductCategory != null && p.ProductCategory.IsDescendant(cat.Id));
                cat.ProductCount = productsByCategory.Any() ? productsByCategory.Count() : 0;
            }

            for (int i = 0; i < categories.Count; i++)
            {
                var cat = categories[i];
                if (index.Any(a => a == cat.Id))
                    continue;

                if (cat.ParentCategory == null)
                {
                    result.Add(cat);
                    index.Add(cat.Id);
                }
                else
                {
                    AddToParentCategory(ref cat, categories, result, index);
                }
            }

            return result;
        }

        /// <summary>
        /// get product categories tree as an asynchronous operation.
        /// </summary>
        /// <param name="selectedCategory">The selected category.</param>
        /// <returns>IList&lt;ProductCategory&gt;.</returns>
        public async Task<IList<ProductCategory>> GetProductCategoriesTreeAsync(int selectedCategory = 0)
        {
            var categories = await GetAllProductCategoriesAsync();
            var result = new List<ProductCategory>();
            var index = new List<int>();
            var products = await GetAllProductsAsync();
            foreach (var product in products)
                product.ProductCategory = GetProductCategory(categories, product.ProductCategoryId);
            foreach (var cat in categories)
            {
                cat.ChildCategories = new List<ProductCategory>();
                if (cat.Id == selectedCategory)
                    cat.Selected = true;

                var productsByCategory = products.Where(p => p.ProductCategory != null && p.ProductCategory.IsDescendant(cat.Id));
                cat.ProductCount = productsByCategory.Any() ? productsByCategory.Count() : 0;
            }

            for (int i = 0; i < categories.Count; i++)
            {
                var cat = categories[i];
                if (index.Any(a => a == cat.Id))
                    continue;

                if (cat.ParentCategory == null)
                {
                    result.Add(cat);
                    index.Add(cat.Id);
                }
                else
                {
                    AddToParentCategory(ref cat, categories, result, index);
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the product category.
        /// </summary>
        /// <param name="categories">The categories.</param>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>ProductCategory.</returns>
        private ProductCategory GetProductCategory(IList<ProductCategory> categories, int? categoryId)
        {
            var category = categories.FirstOrDefault(c => c.Id == categoryId);
            if (category != null && category.ParentCategoryId > 0)
                category.ParentCategory = GetProductCategory(categories, category.ParentCategoryId);
            return category;
        }

        /// <summary>
        /// Adds to parent category.
        /// </summary>
        /// <param name="cat">The cat.</param>
        /// <param name="list">The list.</param>
        /// <param name="result">The result.</param>
        /// <param name="index">The index.</param>
        private void AddToParentCategory(ref ProductCategory cat, IList<ProductCategory> list, IList<ProductCategory> result, List<int> index)
        {
            var parent = cat.ParentCategory;
            if (parent != null)
            {
                parent = list.SingleOrDefault(a => a.Id == parent.Id);
                parent?.ChildCategories.Add(cat);
                index.Add(cat.Id);
            }
            else
            {
                result.Add(cat);
                index.Add(cat.Id);
            }
        }

        /// <summary>
        /// Searches the product categories.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;ProductCategory&gt;.</returns>
        public IList<ProductCategory> SearchProductCategories(string where, string sort)
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

            return _eCommerceUnitOfWork.ProductCategoryRepository.GetList(ParseJSONSearchString<ProductCategory>(where), sortExpression);
        }

        /// <summary>
        /// Searches the product categories.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ProductCategory&gt;.</returns>
        public IPagedList<ProductCategory> SearchProductCategories(string where, string sort, int page, int pageSize = 20)
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

            return _eCommerceUnitOfWork.ProductCategoryRepository.GetPagedList(page, pageSize, ParseJSONSearchString<ProductCategory>(where), sortExpression, a => a.ParentCategory);
        }

        /// <summary>
        /// search product categories as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ProductCategory&gt;.</returns>
        public async Task<IPagedList<ProductCategory>> SearchProductCategoriesAsync(string where, string sort, int page = 1, int pageSize = 20)
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

            return await _eCommerceUnitOfWork.ProductCategoryRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<ProductCategory>(where), sortExpression, a => a.ParentCategory);
        }

        /// <summary>
        /// Gets the product category by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ProductCategory.</returns>
        public ProductCategory GetProductCategoryById(int id)
        {
            return _eCommerceUnitOfWork.ProductCategoryRepository.GetSingle(a => a.Id == id, a => a.ParentCategory);
        }

        /// <summary>
        /// get product category by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ProductCategory.</returns>
        public async Task<ProductCategory> GetProductCategoryByIdAsync(int id)
        {
            return await _eCommerceUnitOfWork.ProductCategoryRepository.GetSingleAsync(a => a.Id == id, a => a.ParentCategory);
        }

        /// <summary>
        /// Gets the product category by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>ProductCategory.</returns>
        public ProductCategory GetProductCategoryByName(string name)
        {
            return _eCommerceUnitOfWork.ProductCategoryRepository.GetSingle(a => a.Name == name, a => a.ParentCategory);
        }

        /// <summary>
        /// get product category by name as an asynchronous operation.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>ProductCategory.</returns>
        public async Task<ProductCategory> GetProductCategoryByNameAsync(string name)
        {
            return await _eCommerceUnitOfWork.ProductCategoryRepository.GetSingleAsync(a => a.Name == name, a => a.ParentCategory);
        }

        /// <summary>
        /// Gets the product category by public identifier.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>ProductCategory.</returns>
        public ProductCategory GetProductCategoryByPublicId(string pid)
        {
            ISEOFriendly<ProductCategory> seoProduct = new ProductCategory();
            var productCategory = _eCommerceUnitOfWork.ProductCategoryRepository.GetSingle(seoProduct.ByPublicIdExpression(pid), a => a.ParentCategory);
            return productCategory;
        }

        /// <summary>
        /// get product category by public identifier as an asynchronous operation.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>ProductCategory.</returns>
        public async Task<ProductCategory> GetProductCategoryByPublicIdAsync(string pid)
        {
            ISEOFriendly<ProductCategory> seoProduct = new ProductCategory();
            var productCategory = await _eCommerceUnitOfWork.ProductCategoryRepository.GetSingleAsync(seoProduct.ByPublicIdExpression(pid), a => a.ParentCategory);
            return productCategory;
        }

        /// <summary>
        /// Adds the product category.
        /// </summary>
        /// <param name="productCategories">The product categories.</param>
        public void AddProductCategory(params ProductCategory[] productCategories)
        {
            CheckParentCategory(productCategories);
            _eCommerceUnitOfWork.ProductCategoryRepository.Add(productCategories);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// add product category as an asynchronous operation.
        /// </summary>
        /// <param name="productCategories">The product categories.</param>
        public async Task AddProductCategoryAsync(params ProductCategory[] productCategories)
        {
            CheckParentCategory(productCategories);
            _eCommerceUnitOfWork.ProductCategoryRepository.Add(productCategories);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the product category.
        /// </summary>
        /// <param name="productCategories">The product categories.</param>
        public void UpdateProductCategory(params ProductCategory[] productCategories)
        {
            CheckParentCategory(productCategories);
            _eCommerceUnitOfWork.ProductCategoryRepository.Update(productCategories);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// update product category as an asynchronous operation.
        /// </summary>
        /// <param name="productCategories">The product categories.</param>
        public async Task UpdateProductCategoryAsync(params ProductCategory[] productCategories)
        {
            CheckParentCategory(productCategories);
            _eCommerceUnitOfWork.ProductCategoryRepository.Update(productCategories);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the product category.
        /// </summary>
        /// <param name="productCategories">The product categories.</param>
        public void RemoveProductCategory(params ProductCategory[] productCategories)
        {
            _eCommerceUnitOfWork.ProductCategoryRepository.Remove(productCategories);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// remove product category as an asynchronous operation.
        /// </summary>
        /// <param name="productCategories">The product categories.</param>
        public async Task RemoveProductCategoryAsync(params ProductCategory[] productCategories)
        {
            _eCommerceUnitOfWork.ProductCategoryRepository.Remove(productCategories);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Gets the product category tree.
        /// </summary>
        /// <param name="categories">The categories.</param>
        /// <returns>ProductCategoryNode.</returns>
        public ProductCategoryNode GetProductCategoryTree(IList<ProductCategory> categories)
        {
            // create root node
            var rootNode = new ProductCategoryNode
            {
                NodeId = -1,
                IsRoot = true,
                Title = ResObject.UIText_Product_Categories,
                Children = new List<ProductCategoryNode>()
            };            
            rootNode.Children.AddRange(ProcessNode(categories, null));
            return rootNode;
        }

        /// <summary>
        /// Processes the node.
        /// </summary>
        /// <param name="categories">The categories.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <returns>IList&lt;ProductCategoryNode&gt;.</returns>
        private IList<ProductCategoryNode> ProcessNode(IList<ProductCategory> categories, int? parentId)
        {
            var children = new List<ProductCategoryNode>();
            var childCategories = categories.Where(c => c.ParentCategoryId == parentId).ToList();
            if (!childCategories.Any() && !parentId.HasValue)
                childCategories.AddRange(categories);
            foreach (var category in childCategories)
            {
                var categoryNode = new ProductCategoryNode
                {
                    NodeId = category.Id,
                    Title = category.Name,
                    Children = new List<ProductCategoryNode>()
                };
                var childNodes = ProcessNode(categories, category.Id);
                categoryNode.Children.AddRange(childNodes);
                categoryNode.IsLeaf = !childNodes.Any();
                children.Add(categoryNode);
            }
            return children;
        }

        /// <summary>
        /// Checks the parent category.
        /// </summary>
        /// <param name="productCategories">The product categories.</param>
        /// <exception cref="ProductCategoryException"></exception>
        private void CheckParentCategory(params ProductCategory[] productCategories)
        {
            if (productCategories.Any(a => a.ParentCategoryId > 0))
            {
                var list = _eCommerceUnitOfWork.ProductCategoryRepository.GetAll(a => a.ParentCategory).OrderBy(a => a.Name).ToList();
                foreach (var cat in productCategories)
                {
                    bool isCatFound = false;
                    var checkCat = cat;
                    while (checkCat.ParentCategoryId > 0)
                    {
                        // Temporary limitation - allow 2 levels only
                        //if (level > 1)
                        //   throw new ProductCategoryException(ResObject.ErrorText_ProductCategory2LevelOnly);

                        var parentCat = list.SingleOrDefault(a => a.Id == checkCat.ParentCategoryId);
                        if (parentCat != null)
                        {
                            if (parentCat.Id == cat.Id)
                            {
                                isCatFound = true;
                                break;
                            }
                            else
                            {
                                checkCat = parentCat;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    while (list.Any(a => checkCat != null && a.ParentCategoryId == checkCat.Id))
                    {
                        // Temporary limitation - allow 2 levels only
                        //if (level > 1)
                        //    throw new ProductCategoryException(ResObject.ErrorText_ProductCategory2LevelOnly);

                        checkCat = list.FirstOrDefault(a => checkCat != null && a.ParentCategoryId == checkCat.Id);
                    }

                    if (isCatFound)
                    {
                        throw new ProductCategoryException(ResObject.ErrorText_InvalidParentProductCategory);
                    }
                }


            }
        }

        #region ILocalizedBL
        /// <summary>
        /// Get full details of the single entity
        /// </summary>
        /// <param name="ofEntity">Passed entity is used as filter, method implementing ths feature should treat this oject apropriatly to call some method of BL class to read full details.</param>
        /// <returns>Entity instance</returns>
        public ProductCategory GetDetails(ProductCategory ofEntity)
        {
            if (ofEntity == null)
                return null;

            if (ofEntity.Id > 0)
                return GetProductCategoryById(ofEntity.Id);
            
            return null;
        }

        /// <summary>
        /// Inserts given entity into DB
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        public void AddSingleEntity(ProductCategory entity)
        {
            _eCommerceUnitOfWork.ProductCategoryRepository.Add(entity);
            _eCommerceUnitOfWork.Save();
        }

        #endregion

        #endregion
    }

    /// <summary>
    /// Class ProductCategoryBL.
    /// Implements the <see cref="BAP.eCommerce.BL.eCommerceBusinessLayer" />
    /// Implements the <see cref="BAP.Common.ISupportLookup" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.BL.eCommerceBusinessLayer" />
    /// <seealso cref="BAP.Common.ISupportLookup" />
    public class ProductCategoryBL : eCommerceBusinessLayer, ISupportLookup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCategoryBL"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public ProductCategoryBL(IConfigHelper settings, IAuthorizationContext context, ILogger logger) : base(null, null, settings, context, logger)
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
            var productCategories = SearchProductCategories(extraFilter, orderBy);
            foreach (var productCategory in productCategories)
            {
                var val = productCategory.GetType().GetProperty(valueField).GetValue(productCategory, null);
                var text = productCategory.GetType().GetProperty(textField).GetValue(productCategory, null);
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = productCategory.GetType().GetProperty(descriptionField).GetValue(productCategory, null);
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
            var productCategories = await SearchProductCategoriesAsync(extraFilter, orderBy);
            foreach (var productCategory in productCategories)
            {
                var val = productCategory.GetType().GetProperty(valueField).GetValue(productCategory, null);
                var text = productCategory.GetType().GetProperty(textField).GetValue(productCategory, null);
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = productCategory.GetType().GetProperty(descriptionField).GetValue(productCategory, null);
                }
                result.Add(new LookupItem { Key = val.ToString(), Text = text.ToString(), Description = descr.ToString() });
            }

            return result;
        }
    }
}
