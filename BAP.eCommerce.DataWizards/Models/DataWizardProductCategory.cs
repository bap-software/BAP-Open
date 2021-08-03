// ***********************************************************************
// Assembly         : BAP.eCommerce.DataWizards
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="DataWizardProductCategory.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

using BAP.eCommerce.DataWizards.Models.Interfaces;

namespace BAP.eCommerce.DataWizards.Models
{
    /// <summary>
    /// Class DataWizardProductCategory.
    /// Implements the <see cref="BAP.eCommerce.DataWizards.Models.Interfaces.IDataWizardProductCategory" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.DataWizards.Models.Interfaces.IDataWizardProductCategory" />
    public class DataWizardProductCategory : IDataWizardProductCategory
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        public string ShortDescription { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        public int Order { get; set; }
        /// <summary>
        /// Gets or sets the culture code.
        /// </summary>
        /// <value>The culture code.</value>
        public string CultureCode { get; set; }
        /// <summary>
        /// Gets or sets the child categories.
        /// </summary>
        /// <value>The child categories.</value>
        public List<DataWizardProductCategory> ChildCategories { get; set; }
    }
}
