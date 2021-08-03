// ***********************************************************************
// Assembly         : BAP.ContentManagement
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="CMSAction.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Reflection;

namespace BAP.ContentManagement
{
    /// <summary>
    /// Class CMSAction.
    /// </summary>
    public class CMSAction
    {
        /// <summary>
        /// Gets or sets the controller.
        /// </summary>
        /// <value>The controller.</value>
        public CMSController Controller { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        public ParameterInfo[] Parameters { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance has parameters.
        /// </summary>
        /// <value><c>true</c> if this instance has parameters; otherwise, <c>false</c>.</value>
        public bool HasParameters { get; set; }
    }
}
