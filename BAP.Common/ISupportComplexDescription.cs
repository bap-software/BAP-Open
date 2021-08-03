// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ISupportComplexDescription.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BAP.Common
{
    /// <summary>
    /// Interface indicates that entity uses Description field to keep complex JSON data, actual textual description can be part of that
    /// JSON data.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISupportComplexDescription<T> where T: class
	{
        /// <summary>
        /// Gets or sets the complex description.
        /// </summary>
        /// <value>The complex description.</value>
        T ComplexDescription { get; set; }	
	}
}
