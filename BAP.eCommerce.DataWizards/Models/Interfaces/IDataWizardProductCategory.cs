// ***********************************************************************
// Assembly         : BAP.eCommerce.DataWizards
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="IDataWizardProductCategory.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

using Newtonsoft.Json;

namespace BAP.eCommerce.DataWizards.Models.Interfaces
{
    /// <summary>
    /// Interface IDataWizardProductCategory
    /// Implements the <see cref="BAP.eCommerce.DataWizards.Models.Interfaces.IJsonModel" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.DataWizards.Models.Interfaces.IJsonModel" />
    public interface IDataWizardProductCategory : IJsonModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("Name")]
            string Name { get; set; }

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        [JsonProperty("ShortDescription")]
            string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("Description")]
            string Description { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        [JsonProperty("Order")]
            int Order { get; set; }

        /// <summary>
        /// Gets or sets the culture code.
        /// </summary>
        /// <value>The culture code.</value>
        [JsonProperty("CultureCode")]
            string CultureCode { get; set; }

        /// <summary>
        /// Gets or sets the child categories.
        /// </summary>
        /// <value>The child categories.</value>
        [JsonProperty("ChildCategories", NullValueHandling = NullValueHandling.Ignore)]
            List<DataWizardProductCategory> ChildCategories { get; set; }
    }
}
