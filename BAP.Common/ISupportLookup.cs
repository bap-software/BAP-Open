// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ISupportLookup.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BAP.Common
{
    /// <summary>
    /// Interface indicates that class supporting it return list of items to be used in lookup
    /// </summary>
    public interface ISupportLookup
    {
        /// <summary>
        /// Gets the lookup items.
        /// </summary>
        /// <param name="valueField">The value field.</param>
        /// <param name="textField">The text field.</param>
        /// <param name="descriptionField">The description field.</param>
        /// <param name="extraFilter">The extra filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="roles">The roles.</param>
        /// <param name="setCurrentUserAsSelected">if set to <c>true</c> [set current user as selected].</param>
        /// <returns>IList&lt;LookupItem&gt;.</returns>
        IList<LookupItem> GetLookupItems(string valueField, string textField, string descriptionField = "", string extraFilter = "", string orderBy = "", List<string> roles = null, bool setCurrentUserAsSelected = false);

        /// <summary>
        /// Gets the lookup items asynchronous.
        /// </summary>
        /// <param name="valueField">The value field.</param>
        /// <param name="textField">The text field.</param>
        /// <param name="descriptionField">The description field.</param>
        /// <param name="extraFilter">The extra filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="roles">The roles.</param>
        /// <param name="setCurrentUserAsSelected">if set to <c>true</c> [set current user as selected].</param>
        /// <returns>Task&lt;IList&lt;LookupItem&gt;&gt;.</returns>
        Task<IList<LookupItem>> GetLookupItemsAsync(string valueField, string textField, string descriptionField = "", string extraFilter = "", string orderBy = "", List<string> roles = null, bool setCurrentUserAsSelected = false);
    }
}
