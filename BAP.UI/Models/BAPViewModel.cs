// ***********************************************************************
// Assembly         : BAP.UI
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="BAPViewModel.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

using PagedList;

using BAP.Common;
using BAP.DAL;
using BAP.Log;
using BAP.Lookups;

namespace BAP.UI.Models
{
    /// <summary>
    /// Class BAPViewModel.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BAPViewModel<T> where T : class, IBapEntity
    {
        /// <summary>
        /// Gets or sets the lookup engine.
        /// </summary>
        /// <value>The lookup engine.</value>
        public ILookupEngine LookupEngine { get; set; }
        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        /// <value>The logger.</value>
        public ILogger Logger { get; set; }
        /// <summary>
        /// Gets or sets the configuration helper.
        /// </summary>
        /// <value>The configuration helper.</value>
        public IConfigHelper ConfigHelper { get; set; }
        /// <summary>
        /// Gets or sets the authentication context.
        /// </summary>
        /// <value>The authentication context.</value>
        public IAuthorizationContext AuthContext { get; set; }
        /// <summary>
        /// Gets or sets the authentication helper.
        /// </summary>
        /// <value>The authentication helper.</value>
        public IAuthorizationHelper<T> AuthHelper { get; set; }

        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>The entity.</value>
        public T Entity { get; set; }
        /// <summary>
        /// Gets or sets the data list.
        /// </summary>
        /// <value>The data list.</value>
        public IEnumerable<T> DataList { get; set; }
        /// <summary>
        /// Gets or sets the paged list.
        /// </summary>
        /// <value>The paged list.</value>
        public IPagedList<T> PagedList { get; set; }
    }
}