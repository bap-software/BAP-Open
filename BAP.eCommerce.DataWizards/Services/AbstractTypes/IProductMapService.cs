// ***********************************************************************
// Assembly         : BAP.eCommerce.DataWizards
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="IProductMapService.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.eCommerce.DAL.Entities;
using BAP.eCommerce.DataWizards.Models;
using BAP.FileSystem;

namespace BAP.eCommerce.DataWizards.Services.AbstractTypes
{
    /// <summary>
    /// Interface IProductMapService
    /// </summary>
    public interface IProductMapService
    {
        /// <summary>
        /// Casts to product.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="category">The category.</param>
        /// <param name="fileProcessor">The file processor.</param>
        /// <returns>Product.</returns>
        Product CastToProduct(ProductUploadModel model, ProductCategory category, IFileProcessor fileProcessor);
    }
}
