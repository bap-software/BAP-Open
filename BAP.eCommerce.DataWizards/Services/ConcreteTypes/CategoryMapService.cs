// ***********************************************************************
// Assembly         : BAP.eCommerce.DataWizards
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="CategoryMapService.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

using BAP.eCommerce.DAL.Entities;
using BAP.eCommerce.DataWizards.Models;
using BAP.eCommerce.DataWizards.Services.AbstractTypes;

namespace BAP.eCommerce.DataWizards.Services.ConcreteTypes
{
    /// <summary>
    /// Class CategoryMapService.
    /// Implements the <see cref="BAP.eCommerce.DataWizards.Services.AbstractTypes.ICategoryMapService" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.DataWizards.Services.AbstractTypes.ICategoryMapService" />
    public class CategoryMapService : ICategoryMapService
    {
        // <summary>  get all categories from model including childCategories 
        /// <summary>
        /// Gets the separated categories.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="parentCatecory">The parent catecory.</param>
        /// <returns>IList&lt;ProductCategory&gt;.</returns>
        public IList<ProductCategory> GetSeparatedCategories(DataWizardProductCategory data, ProductCategory parentCatecory = null)
        {
            if (data != null)
            {
                var DataToReturn = new List<ProductCategory>();

                var thisCategory = CastToProductCategory(data, parentCatecory);
                DataToReturn.Add(thisCategory);

                if (data.ChildCategories != null)
                {
                    foreach (var item in data.ChildCategories)
                    {
                        DataToReturn.AddRange(GetSeparatedCategories(item, thisCategory));
                    }
                }
                return DataToReturn;
            }
            else
                return null;
            
        }

        // <summary>  casts DataWizardProductCategory model to ProductCategory
        /// <summary>
        /// Casts to product category.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="parentCatecory">The parent catecory.</param>
        /// <returns>ProductCategory.</returns>
        public ProductCategory CastToProductCategory(DataWizardProductCategory data, ProductCategory parentCatecory = null)
        {
            if (data != null)
            {
                return new ProductCategory()
                {

                    Description = data.Description,
                    Name = data.Name,
                    Order = data.Order,
                    ShortDescription = data.ShortDescription,
                    ParentCategory = parentCatecory
                };
            }
            else
                return null;
           
        }
    }
}
