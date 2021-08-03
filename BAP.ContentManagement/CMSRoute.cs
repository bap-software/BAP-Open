// ***********************************************************************
// Assembly         : BAP.ContentManagement
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="CMSRoute.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAP.ContentManagement
{
    /// <summary>
    /// Class CMSRoute.
    /// </summary>
    public class CMSRoute
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is home.
        /// </summary>
        /// <value><c>true</c> if this instance is home; otherwise, <c>false</c>.</value>
        public bool IsHome { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }
        /// <summary>
        /// Gets or sets the defaults.
        /// </summary>
        /// <value>The defaults.</value>
        public object Defaults { get; set; }
        /// <summary>
        /// Gets or sets the namespaces.
        /// </summary>
        /// <value>The namespaces.</value>
        public string[] Namespaces { get; set; }
        /// <summary>
        /// Gets or sets the constraints.
        /// </summary>
        /// <value>The constraints.</value>
        public object Constraints { get; set; }
        /// <summary>
        /// Gets or sets the data tokens.
        /// </summary>
        /// <value>The data tokens.</value>
        public Dictionary<string, object> DataTokens { get; set; }
    }
}
