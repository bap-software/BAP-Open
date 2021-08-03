// ***********************************************************************
// Assembly         : BAP.eCommerce.DataWizards
// Author           : Victor Mamray
// Created          : 06-11-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ProductMapService.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;

using BAP.eCommerce.DAL.Entities;
using BAP.eCommerce.DataWizards.Models;
using BAP.eCommerce.DataWizards.Services.AbstractTypes;
using BAP.FileSystem;

namespace BAP.eCommerce.DataWizards.Services.ConcreteTypes
{
    /// <summary>
    /// Class ProductMapService.
    /// Implements the <see cref="BAP.eCommerce.DataWizards.Services.AbstractTypes.IProductMapService" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.DataWizards.Services.AbstractTypes.IProductMapService" />
    public class ProductMapService : IProductMapService
    {
        /// <summary>
        /// Casts to product.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="category">The category.</param>
        /// <param name="fileProcessor">The file processor.</param>
        /// <returns>Product.</returns>
        public Product CastToProduct(ProductUploadModel model, ProductCategory category, IFileProcessor fileProcessor)
        {
            return new Product
            {
                Name = model.Name,
                ShortDescription = model.ShortDescription,
                Description = model.Description,
                Price = model.Price,
                ListPrice = model.ListPrice,
                MsrpPrice = model.MSRP,
                MinPrice = model.MinPrice,
                MaxPrice = model.MaxPrice,
                Width = model.Width,
                Height = model.Height,
                Depth = model.Depth,
                SizeMeasure = model.SizeMeasure,
                Weight = model.Weight,
                WeightMeasure = model.WeightMeasure,
                SKU = SKUGenerator(model.Name),
                PublishFrom = DateTime.Now,
                PublishTo = DateTime.Now.AddYears(1),
                Enabled = model.Enabled,
                InStoreFrom = DateTime.Now,
                NeedsShipping = CheckShipping(model.Weight, model.Height),
                ProductCategory = category,
                ProductCategoryId = category.Id,
                ImagePath = SaveImage(model.ImagePath, fileProcessor),
                InternalStatus = model.InternalStatus,
                IsFeatured = model.IsFeatured,
                ExtraImages = model.ExtraImages
            };
            
        }

        /// <summary>
        /// Saves the image.
        /// </summary>
        /// <param name="imagePath">The image path.</param>
        /// <param name="fileProcessor">The file processor.</param>
        /// <returns>System.String.</returns>
        private string SaveImage(string imagePath, IFileProcessor fileProcessor)
        {
            //////
            return imagePath;
        }

        /// <summary>
        /// Skus the generator.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.String.</returns>
        string SKUGenerator(string name)
        {
            var returnString = name.ToUpper();
            for (int i = 0; i < returnString.Count(); i++)
            {
                if (returnString.ElementAt(i) == ' ' && returnString.ElementAt(i + 1) == ' ')
                {
                    returnString.Remove(i);
                }
            }
            return returnString.Replace(' ', '-');

        }
        /// <summary>
        /// Checks the shipping.
        /// </summary>
        /// <param name="weight">The weight.</param>
        /// <param name="width">The width.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool CheckShipping(decimal weight,decimal width)
        {
            if (weight > 0 && width > 0)
                return true;
            return false;
        }
        

    }
}

