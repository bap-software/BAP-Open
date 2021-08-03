// ***********************************************************************
// Assembly         : BAP.ContentManagement
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="IContentExtendable.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Web.Mvc;

namespace BAP.ContentManagement
{
    /// <summary>
    /// Interface to identify that particular controller supports content extension, like creating extra pages
    /// </summary>
    public interface IContentExtendable
    {
        /// <summary>
        /// Indexes all.
        /// </summary>
        /// <param name="sort">The sort.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>ActionResult.</returns>
        ActionResult IndexAll(string sort = "", string filter = "");
        /// <summary>
        /// Contents the specified view.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>ActionResult.</returns>
        ActionResult Content(string view = "", object[] parameters = null);        
    }
}
