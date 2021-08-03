// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="IEntityHelper.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Reflection;

namespace BAP.Common
{
    /// <summary>
    /// Interface IEntityHelper
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityHelper<T> where T : class, IBapEntity
    {
        /// <summary>
        /// Gets the entity fields.
        /// </summary>
        /// <returns>IList&lt;PropertyInfo&gt;.</returns>
        IList<PropertyInfo> GetEntityFields();
        /// <summary>
        /// Gets the sort fields.
        /// </summary>
        /// <returns>IList&lt;SortingField&gt;.</returns>
        IList<SortingField> GetSortFields();
        /// <summary>
        /// Gets the default sort expression.
        /// </summary>
        /// <returns>System.String.</returns>
        string GetDefaultSortExpression();
        /// <summary>
        /// Gets the size of the entity page.
        /// </summary>
        /// <returns>System.Int32.</returns>
        int GetEntityPageSize();
    }
}
