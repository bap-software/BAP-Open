// ***********************************************************************
// Assembly         : BAP.eCommerce.DataWizards
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="IProductUploadModel.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BAP.eCommerce.DataWizards.Models.Interfaces
{
    /// <summary>
    /// Interface IProductUploadModel
    /// Implements the <see cref="BAP.eCommerce.DataWizards.Models.Interfaces.IJsonModel" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.DataWizards.Models.Interfaces.IJsonModel" />
    public interface IProductUploadModel : IJsonModel
    {
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        [JsonProperty("Category", NullValueHandling = NullValueHandling.Ignore)]
        string Category { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("Name", NullValueHandling = NullValueHandling.Ignore)]
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        [JsonProperty("ShortDescription", NullValueHandling = NullValueHandling.Ignore)]
        string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("Description", NullValueHandling = NullValueHandling.Ignore)]
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [JsonProperty("Price", NullValueHandling = NullValueHandling.Ignore)]
        decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the list price.
        /// </summary>
        /// <value>The list price.</value>
        [JsonProperty("ListPrice", NullValueHandling = NullValueHandling.Ignore)]
        decimal ListPrice { get; set; }

        /// <summary>
        /// Gets or sets the MSRP.
        /// </summary>
        /// <value>The MSRP.</value>
        [JsonProperty("MSRP", NullValueHandling = NullValueHandling.Ignore)]
        decimal MSRP { get; set; }

        /// <summary>
        /// Gets or sets the minimum price.
        /// </summary>
        /// <value>The minimum price.</value>
        [JsonProperty("MinPrice", NullValueHandling = NullValueHandling.Ignore)]
        decimal MinPrice { get; set; }

        /// <summary>
        /// Gets or sets the maximum price.
        /// </summary>
        /// <value>The maximum price.</value>
        [JsonProperty("MaxPrice", NullValueHandling = NullValueHandling.Ignore)]
        decimal MaxPrice { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        [JsonProperty("Width", NullValueHandling = NullValueHandling.Ignore)]
        decimal Width { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        [JsonProperty("Height", NullValueHandling = NullValueHandling.Ignore)]
        decimal Height { get; set; }

        /// <summary>
        /// Gets or sets the depth.
        /// </summary>
        /// <value>The depth.</value>
        [JsonProperty("Depth", NullValueHandling = NullValueHandling.Ignore)]
        decimal Depth { get; set; }

        /// <summary>
        /// Gets or sets the size measure.
        /// </summary>
        /// <value>The size measure.</value>
        [JsonProperty("SizeMeasure", NullValueHandling = NullValueHandling.Ignore)]
        [RegularExpression("in|cm|m")]
        string SizeMeasure { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>The weight.</value>
        [JsonProperty("Weight", NullValueHandling = NullValueHandling.Ignore)]
        decimal Weight { get; set; }

        /// <summary>
        /// Gets or sets the weight measure.
        /// </summary>
        /// <value>The weight measure.</value>
        [JsonProperty("WeightMeasure", NullValueHandling = NullValueHandling.Ignore)]
        [RegularExpression("lb|kg")]
        string WeightMeasure { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IProductUploadModel"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        [JsonProperty("Enabled",NullValueHandling = NullValueHandling.Ignore)]
        bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        /// <value>The image path.</value>
        [JsonProperty("imagePath",NullValueHandling = NullValueHandling.Ignore)]
        string ImagePath { get; set; }
    }
}
