// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="SortingField.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Reflection;

namespace BAP.Common
{
    /// <summary>
    /// Class SortingField.
    /// </summary>
    public class SortingField
    {
        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>The label.</value>
        public string Label { get; set; }
        /// <summary>
        /// Gets or sets the attribute.
        /// </summary>
        /// <value>The attribute.</value>
        public SortingFieldAttribute Attribute { get; set; }
        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        /// <value>The field.</value>
        public PropertyInfo Field { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [sort descending value].
        /// </summary>
        /// <value><c>true</c> if [sort descending value]; otherwise, <c>false</c>.</value>
        public bool SortDescendingValue { get; set; }
    }
}
