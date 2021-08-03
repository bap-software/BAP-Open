// ***********************************************************************
// Assembly         : BAP.eCommerce.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="eCommDbMigrationConfig.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data.Entity;
using System.Linq;

using BAP.DAL;
using BAP.eCommerce.DAL.Entities;

namespace BAP.eCommerce.DAL
{
    /// <summary>
    /// Class eCommDbMigrationConfig.
    /// Implements the <see cref="BAP.DAL.BAPBaseMigrationConfiguration{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="BAP.DAL.BAPBaseMigrationConfiguration{T}" />
    public abstract class eCommDbMigrationConfig<T> : BAPBaseMigrationConfiguration<T> where T : DbContext
    {
        /// <summary>
        /// Upserts the productcategory.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="orgId">The org identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="shortDescription">The short description.</param>
        /// <param name="description">The description.</param>
        /// <param name="order">The order.</param>
        /// <param name="upsertUserId">The upsert user identifier.</param>
        /// <param name="parentCategoryId">The parent category identifier.</param>
        /// <returns>ProductCategory.</returns>
        protected ProductCategory UpsertProductcategory(T context, int orgId, string name, string shortDescription, string description, int order, string upsertUserId, int parentCategoryId = 0)
        {
            ProductCategory prodCat = null;
            if (!context.Set<ProductCategory>().Any(a => a.Name == name))
            {
                DateTime createDateTime = DateTime.Now;
                prodCat = new ProductCategory
                {
                    Name = name,
                    Description = description,
                    ShortDescription = shortDescription,
                    ParentCategoryId = parentCategoryId > 0 ? (int?)parentCategoryId : null,
                    Order = order,
                    OwnerGroup = 27,
                    OwnerPermissions = 7695,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = createDateTime,
                    CreatedBy = upsertUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = upsertUserId
                };
                context.Set<ProductCategory>().Add(prodCat);
            }
            else
            {
                prodCat = context.Set<ProductCategory>().First(a => a.Name == name);
                DateTime updateDateTime = DateTime.Now;
                if (prodCat != null)
                {
                    prodCat.Description = description;
                    prodCat.ShortDescription = shortDescription;
                    prodCat.ParentCategoryId = parentCategoryId > 0 ? (int?)parentCategoryId : null;
                    prodCat.TenantUnitId = orgId;
                    prodCat.LastModifiedBy = upsertUserId;
                    prodCat.LastModifiedDate = updateDateTime;
                }
            }

            return prodCat;
        }

        /// <summary>
        /// Upserts the product.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="orgId">The org identifier.</param>
        /// <param name="sku">The sku.</param>
        /// <param name="name">The name.</param>
        /// <param name="shortDescription">The short description.</param>
        /// <param name="description">The description.</param>
        /// <param name="upsertUserId">The upsert user identifier.</param>
        /// <param name="parentCategoryId">The parent category identifier.</param>
        /// <param name="manufacturerId">The manufacturer identifier.</param>
        /// <param name="imageUrl">The image URL.</param>
        /// <param name="price">The price.</param>
        /// <param name="listPrice">The list price.</param>
        /// <param name="featured">if set to <c>true</c> [featured].</param>
        /// <param name="intStatus">The int status.</param>
        /// <returns>Product.</returns>
        protected Product UpsertProduct(T context, int orgId, string sku, string name, string shortDescription, string description, string upsertUserId, int parentCategoryId, int manufacturerId, string imageUrl, decimal price, decimal listPrice = 0, bool featured = false, string intStatus = "")
        {
            Product prod = null;
            DateTime currDateTime = DateTime.Now;
            if (!context.Set<Product>().Any(a => a.SKU == sku))
            {
                prod = new Product
                {
                    UID = Guid.NewGuid(),
                    SKU = sku,
                    Name = name,
                    ShortDescription = shortDescription,
                    Description = description,
                    Price = price,
                    ListPrice = listPrice,
                    Enabled = true,
                    ImagePath = imageUrl,
                    ProductType = "main",
                    ProductCategoryId = parentCategoryId > 0 ? (int?)parentCategoryId : null,
                    ManufacturerId = manufacturerId > 0 ? (int?)manufacturerId : null,
                    OwnerGroup = 27,
                    OwnerPermissions = 7695,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = currDateTime,
                    CreatedBy = upsertUserId,
                    LastModifiedDate = currDateTime,
                    LastModifiedBy = upsertUserId,
                    PublishFrom = currDateTime,
                    PublishTo = currDateTime.AddYears(10),
                    InStoreFrom = currDateTime,
                    ReorderAt = currDateTime.AddYears(10),
                    IsFeatured = featured,
                    InternalStatus = intStatus
                };
                context.Set<Product>().Add(prod);
            }
            else
            {
                prod = context.Set<Product>().First(a => a.SKU == sku);
                prod.Name = name;
                prod.ShortDescription = shortDescription;
                prod.Description = description;
                prod.ProductCategoryId = parentCategoryId > 0 ? (int?)parentCategoryId : null;
                prod.ManufacturerId = manufacturerId > 0 ? (int?)manufacturerId : null;
                prod.Price = price;
                prod.ListPrice = listPrice;
                prod.ImagePath = imageUrl;
                prod.LastModifiedBy = upsertUserId;
                prod.LastModifiedDate = currDateTime;
                prod.IsFeatured = featured;
                prod.InternalStatus = intStatus;
            }

            return prod;
        }

        /// <summary>
        /// Adds the manufacturer.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="orgId">The org identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="logo">The logo.</param>
        /// <returns>Manufacturer.</returns>
        protected Manufacturer AddManufacturer(T context, string name, string description, int orgId, string userId, string logo)
        {
            var manufacturer = context.Set<Manufacturer>().FirstOrDefault(a => a.Name == name && a.TenantUnit == "Organization" && a.TenantUnitId == orgId);
            if (manufacturer == null)
            {
                var dateTime = DateTime.Now;
                manufacturer = new Manufacturer
                {
                    Name = name,
                    ShortDescription = description,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = userId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = userId,
                    OwnerGroup = 31,
                    OwnerPermissions = 7695,
                    LogoImage = logo
                };
                context.Set<Manufacturer>().Add(manufacturer);
            }
            else
            {
                manufacturer.Name = name;
                manufacturer.ShortDescription = description;
                manufacturer.Description = string.Empty;
                manufacturer.LogoImage = logo;                
            }
            context.SaveChanges();
            return manufacturer;
        }
    }
}
