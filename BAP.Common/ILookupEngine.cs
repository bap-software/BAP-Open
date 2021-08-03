// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="ILookupEngine.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using BAP.Common;
using System;

namespace BAP.Lookups
{
    /// <summary>
    /// Interface ILookupEngine
    /// </summary>
    public interface ILookupEngine
    {
        /// <summary>
        /// Gets the lookup.
        /// </summary>
        /// <param name="lookup">The lookup.</param>
        /// <param name="required">if set to <c>true</c> [required].</param>
        /// <returns>List&lt;LookupItem&gt;.</returns>
        List<LookupItem> GetLookup(string lookup, bool required = true);

        /// <summary>
        /// Gets the lookup.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="idField">The identifier field.</param>
        /// <param name="nameField">The name field.</param>
        /// <param name="descriptionField">The description field.</param>
        /// <param name="required">if set to <c>true</c> [required].</param>
        /// <param name="roles">The roles.</param>
        /// <param name="setCurrentUserAsSelected">if set to <c>true</c> [set current user as selected].</param>
        /// <returns>List&lt;LookupItem&gt;.</returns>
        List<LookupItem> GetLookup(Type entityType, string idField, string nameField, string descriptionField, bool required = true, List<string> roles = null, bool setCurrentUserAsSelected = false);

        /// <summary>
        /// Gets the first item.
        /// </summary>
        /// <param name="lookup">The lookup.</param>
        /// <returns>LookupItem.</returns>
        LookupItem GetFirstItem(string lookup);

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="lookup">The lookup.</param>
        /// <param name="value">The value.</param>
        /// <returns>LookupItem.</returns>
        LookupItem GetItem(string lookup, string value);

        /// <summary>
        /// Gets the item text.
        /// </summary>
        /// <param name="lookup">The lookup.</param>
        /// <param name="value">The value.</param>
        /// <param name="emptyText">The empty text.</param>
        /// <returns>System.String.</returns>
        string GetItemText(string lookup, string value, string emptyText = "");

        /// <summary>
        /// Gets the currency symbol.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns>System.String.</returns>
        string GetCurrencySymbol(string currency);

        /// <summary>
        /// Gets the lookups.
        /// </summary>
        /// <returns>List&lt;LookupItem&gt;.</returns>
        List<LookupItem> GetLookups();
    }    
}
