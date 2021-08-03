// ***********************************************************************
// Assembly         : BAP.eCommerce.DataWizards
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ICategoryMapService.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

using BAP.eCommerce.DAL.Entities;
using BAP.eCommerce.DataWizards.Models;

namespace BAP.eCommerce.DataWizards.Services.AbstractTypes
{
    /// <summary>
    /// Interface ICategoryMapService
    /// </summary>
    public interface ICategoryMapService
    {
        // <summary>  casts DataWizardProductCategory model to ProductCategory
        /// <summary>
        /// Casts to product category.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="parentCatecory">The parent catecory.</param>
        /// <returns>ProductCategory.</returns>
        ProductCategory CastToProductCategory(DataWizardProductCategory data, ProductCategory parentCatecory = null);

        // <summary>  get all categories from model including childCategories 
        /// <summary>
        /// Gets the separated categories.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="parentCatecory">The parent catecory.</param>
        /// <returns>IList&lt;ProductCategory&gt;.</returns>
        IList<ProductCategory> GetSeparatedCategories(DataWizardProductCategory data, ProductCategory parentCatecory = null);
    }
}
