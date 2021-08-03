// ***********************************************************************
// Assembly         : BAP.eCommerce.BL
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="RelatedProductBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedList;

using BAP.Common;
using BAP.eCommerce.DAL.Entities;
using BAP.eCommerce.Resources;
using BAP.eCommerce.Common.Exceptions;

namespace BAP.eCommerce.BL
{
    /// <summary>
    /// Interface IRelatedProductBL
    /// </summary>
    public interface IRelatedProductBL
    {
        /// <summary>
        /// Gets all related products.
        /// </summary>
        /// <returns>IList&lt;RelatedProduct&gt;.</returns>
        IList<RelatedProduct> GetAllRelatedProducts();
        /// <summary>
        /// Gets all related products asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;RelatedProduct&gt;&gt;.</returns>
        Task<IList<RelatedProduct>> GetAllRelatedProductsAsync();

        /// <summary>
        /// Searches the related products.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;RelatedProduct&gt;.</returns>
        IPagedList<RelatedProduct> SearchRelatedProducts(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the related products asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;RelatedProduct&gt;&gt;.</returns>
        Task<IPagedList<RelatedProduct>> SearchRelatedProductsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the related product by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>RelatedProduct.</returns>
        RelatedProduct GetRelatedProductById(int id);
        /// <summary>
        /// Gets the related product by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;RelatedProduct&gt;.</returns>
        Task<RelatedProduct> GetRelatedProductByIdAsync(int id);

        /// <summary>
        /// Adds the related product.
        /// </summary>
        /// <param name="relatedProducts">The related products.</param>
        void AddRelatedProduct(params RelatedProduct[] relatedProducts);
        /// <summary>
        /// Adds the related product asynchronous.
        /// </summary>
        /// <param name="relatedProducts">The related products.</param>
        /// <returns>Task.</returns>
        Task AddRelatedProductAsync(params RelatedProduct[] relatedProducts);

        /// <summary>
        /// Updates the related product.
        /// </summary>
        /// <param name="relatedProducts">The related products.</param>
        void UpdateRelatedProduct(params RelatedProduct[] relatedProducts);
        /// <summary>
        /// Updates the related product asynchronous.
        /// </summary>
        /// <param name="relatedProducts">The related products.</param>
        /// <returns>Task.</returns>
        Task UpdateRelatedProductAsync(params RelatedProduct[] relatedProducts);

        /// <summary>
        /// Removes the related product.
        /// </summary>
        /// <param name="relatedProducts">The related products.</param>
        void RemoveRelatedProduct(params RelatedProduct[] relatedProducts);
        /// <summary>
        /// Removes the related product asynchronous.
        /// </summary>
        /// <param name="relatedProducts">The related products.</param>
        /// <returns>Task.</returns>
        Task RemoveRelatedProductAsync(params RelatedProduct[] relatedProducts);

        /// <summary>
        /// Adds the product to related.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="productId">The product identifier.</param>
        void AddProductToRelated(Product product, params int[] productId);
        /// <summary>
        /// Adds the product to related asynchronous.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="productId">The product identifier.</param>
        /// <returns>Task.</returns>
        Task AddProductToRelatedAsync(Product product, params int[] productId);

        /// <summary>
        /// Removes the product from related.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="productId">The product identifier.</param>
        void RemoveProductFromRelated(Product product, params int[] productId);
        /// <summary>
        /// Removes the product from related asynchronous.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="productId">The product identifier.</param>
        /// <returns>Task.</returns>
        Task RemoveProductFromRelatedAsync(Product product, params int[] productId);
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
    public partial class eCommerceBusinessLayer : IRelatedProductBL
    {
        #region relatedProducts

        /// <summary>
        /// Gets all related products.
        /// </summary>
        /// <returns>IList&lt;RelatedProduct&gt;.</returns>
        public IList<RelatedProduct> GetAllRelatedProducts()
        {
            return _eCommerceUnitOfWork.RelatedProductRepository.GetAll();
        }

        /// <summary>
        /// get all related products as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;RelatedProduct&gt;.</returns>
        public async Task<IList<RelatedProduct>> GetAllRelatedProductsAsync()
        {
            return await _eCommerceUnitOfWork.RelatedProductRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the related products.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;RelatedProduct&gt;.</returns>
        public IPagedList<RelatedProduct> SearchRelatedProducts(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<RelatedProduct>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _eCommerceUnitOfWork.RelatedProductRepository.GetPagedList(page, pageSize, ParseJSONSearchString<RelatedProduct>(where), sortExpression, a => a.Product, a => a.SimilarProduct);
        }

        /// <summary>
        /// search related products as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;RelatedProduct&gt;.</returns>
        public async Task<IPagedList<RelatedProduct>> SearchRelatedProductsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<RelatedProduct>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _eCommerceUnitOfWork.RelatedProductRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<RelatedProduct>(where), sortExpression, a => a.Product, a => a.SimilarProduct);
        }

        /// <summary>
        /// Gets the related product by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>RelatedProduct.</returns>
        public RelatedProduct GetRelatedProductById(int id)
        {
            return _eCommerceUnitOfWork.RelatedProductRepository.GetSingle(a => a.Id == id, a => a.Product, a => a.SimilarProduct);
        }

        /// <summary>
        /// get related product by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>RelatedProduct.</returns>
        public async Task<RelatedProduct> GetRelatedProductByIdAsync(int id)
        {
            return await _eCommerceUnitOfWork.RelatedProductRepository.GetSingleAsync(a => a.Id == id, a => a.Product, a => a.SimilarProduct);
        }

        /// <summary>
        /// Adds the related product.
        /// </summary>
        /// <param name="relatedProducts">The related products.</param>
        public void AddRelatedProduct(params RelatedProduct[] relatedProducts)
        {
            _eCommerceUnitOfWork.RelatedProductRepository.Add(relatedProducts);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// add related product as an asynchronous operation.
        /// </summary>
        /// <param name="relatedProducts">The related products.</param>
        public async Task AddRelatedProductAsync(params RelatedProduct[] relatedProducts)
        {
            _eCommerceUnitOfWork.RelatedProductRepository.Add(relatedProducts);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the related product.
        /// </summary>
        /// <param name="relatedProducts">The related products.</param>
        public void UpdateRelatedProduct(params RelatedProduct[] relatedProducts)
        {
            _eCommerceUnitOfWork.RelatedProductRepository.Update(relatedProducts);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// update related product as an asynchronous operation.
        /// </summary>
        /// <param name="relatedProducts">The related products.</param>
        public async Task UpdateRelatedProductAsync(params RelatedProduct[] relatedProducts)
        {
            _eCommerceUnitOfWork.RelatedProductRepository.Update(relatedProducts);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the related product.
        /// </summary>
        /// <param name="relatedProducts">The related products.</param>
        public void RemoveRelatedProduct(params RelatedProduct[] relatedProducts)
        {
            _eCommerceUnitOfWork.RelatedProductRepository.Remove(relatedProducts);
            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// remove related product as an asynchronous operation.
        /// </summary>
        /// <param name="relatedProducts">The related products.</param>
        public async Task RemoveRelatedProductAsync(params RelatedProduct[] relatedProducts)
        {
            _eCommerceUnitOfWork.RelatedProductRepository.Remove(relatedProducts);
            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Adds the product to related.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="productId">The product identifier.</param>
        /// <exception cref="ProductException"></exception>
        /// <exception cref="ProductException"></exception>
        public void AddProductToRelated(Product product, params int[] productId)
        {
            if (product == null || productId == null)
                return;

            foreach (var id in productId)
            {
                var itemProduct = product.RelatedProducts.SingleOrDefault(a => a.SimilarProductId == id);
                if (itemProduct != null)
                    throw new ProductException(string.Format(ResObject.ErrorText_ProductAlreadyRelatedProduct, itemProduct.SimilarProduct.Name));
                if (product.Id == id)
                    throw new ProductException(string.Format(ResObject.ErrorText_ProductAlreadyRelatedProduct, product.Name));
            }

            if (product.RelatedProducts == null)
                product.RelatedProducts = new List<RelatedProduct>();

            foreach (var id in productId)
            {
                if (product.RelatedProducts.Any(a => a.SimilarProductId == id))
                    continue;

                var productToAdd = ((IProductBL)this).GetSingleProductById(id);
                if (productToAdd != null)
                {
                    var relatedProduct = new RelatedProduct
                    {
                        ProductId = product.Id,
                        SimilarProductId = id
                    };
                    _eCommerceUnitOfWork.RelatedProductRepository.Add(relatedProduct);
                }
            }

            _eCommerceUnitOfWork.Save();
        }

        /// <summary>
        /// add product to related as an asynchronous operation.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="productId">The product identifier.</param>
        /// <exception cref="ProductException"></exception>
        /// <exception cref="ProductException"></exception>
        public async Task AddProductToRelatedAsync(Product product, params int[] productId)
        {
            if (product == null || productId == null)
                return;

            foreach (var id in productId)
            {
                var itemProduct = product.RelatedProducts.SingleOrDefault(a => a.SimilarProductId == id);
                if (itemProduct != null)
                    throw new ProductException(string.Format(ResObject.ErrorText_ProductAlreadyRelatedProduct, itemProduct.SimilarProduct.Name));
                if (product.Id == id)
                    throw new ProductException(string.Format(ResObject.ErrorText_ProductAlreadyRelatedProduct, product.Name));
            }

            if (product.RelatedProducts == null)
                product.RelatedProducts = new List<RelatedProduct>();

            foreach (var id in productId)
            {
                if (product.RelatedProducts.Any(a => a.SimilarProductId == id))
                    continue;

                var productToAdd = await ((IProductBL)this).GetSingleProductByIdAsync(id);
                if (productToAdd != null)
                {
                    var relatedProduct = new RelatedProduct
                    {
                        ProductId = product.Id,
                        SimilarProductId = id
                    };
                    _eCommerceUnitOfWork.RelatedProductRepository.Add(relatedProduct);
                }
            }

            await _eCommerceUnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the product from related.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="productId">The product identifier.</param>
        public void RemoveProductFromRelated(Product product, params int[] productId)
        {
            if (product == null || productId == null)
                return;

            if (product.RelatedProducts != null)
            {
                foreach (var id in productId)
                {
                    var relatedProduct = GetRelatedProductById(id);
                    _eCommerceUnitOfWork.RelatedProductRepository.Remove(relatedProduct);
                }
                _eCommerceUnitOfWork.Save();
            }
        }

        /// <summary>
        /// remove product from related as an asynchronous operation.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="productId">The product identifier.</param>
        public async Task RemoveProductFromRelatedAsync(Product product, params int[] productId)
        {
            if (product == null || productId == null)
                return;

            if (product.RelatedProducts != null)
            {
                foreach (var id in productId)
                {
                    var relatedProduct = await GetRelatedProductByIdAsync(id);
                    _eCommerceUnitOfWork.RelatedProductRepository.Remove(relatedProduct);
                }
                await _eCommerceUnitOfWork.SaveAsync();
            }
        }

        #endregion
    }
}
