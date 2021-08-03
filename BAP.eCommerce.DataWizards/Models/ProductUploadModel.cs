// ***********************************************************************
// Assembly         : BAP.eCommerce.DataWizards
// Author           : Victor Mamray
// Created          : 06-11-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ProductUploadModel.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using BAP.eCommerce.DataWizards.Models.Interfaces;

namespace BAP.eCommerce.DataWizards.Models
{
    /// <summary>
    /// Class ProductUploadModel.
    /// Implements the <see cref="BAP.eCommerce.DataWizards.Models.Interfaces.IProductUploadModel" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.DataWizards.Models.Interfaces.IProductUploadModel" />
    public class ProductUploadModel : IProductUploadModel
    {
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        public string Category { get; set; }
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
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public decimal Price { get; set; }
        /// <summary>
        /// Gets or sets the list price.
        /// </summary>
        /// <value>The list price.</value>
        public decimal ListPrice { get; set; }
        /// <summary>
        /// Gets or sets the MSRP.
        /// </summary>
        /// <value>The MSRP.</value>
        public decimal MSRP { get; set; }
        /// <summary>
        /// Gets or sets the minimum price.
        /// </summary>
        /// <value>The minimum price.</value>
        public decimal MinPrice { get; set; }
        /// <summary>
        /// Gets or sets the maximum price.
        /// </summary>
        /// <value>The maximum price.</value>
        public decimal MaxPrice { get; set; }
        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public decimal Width { get; set; }
        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public decimal Height { get; set; }
        /// <summary>
        /// Gets or sets the depth.
        /// </summary>
        /// <value>The depth.</value>
        public decimal Depth { get; set; }
        /// <summary>
        /// Gets or sets the size measure.
        /// </summary>
        /// <value>The size measure.</value>
        public string SizeMeasure { get; set; }
        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>The weight.</value>
        public decimal Weight { get; set; }
        /// <summary>
        /// Gets or sets the weight measure.
        /// </summary>
        /// <value>The weight measure.</value>
        public string WeightMeasure { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IProductUploadModel" /> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public bool Enabled { get; set; }
        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        /// <value>The image path.</value>
        public string ImagePath { get; set; }
        /// <summary>
        /// Gets or sets the internal status.
        /// </summary>
        /// <value>The internal status.</value>
        public string InternalStatus { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is featured.
        /// </summary>
        /// <value><c>true</c> if this instance is featured; otherwise, <c>false</c>.</value>
        public bool IsFeatured { get; set; }
        /// <summary>
        /// Gets or sets the extra images.
        /// </summary>
        /// <value>The extra images.</value>
        public List<string> ExtraImages { get; set; }
    }
}
