// ***********************************************************************
// Assembly         : BAP.ContentManagement
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="CMSController.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace BAP.ContentManagement
{
    /// <summary>
    /// Class CMSController.
    /// </summary>
    public class CMSController
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        /// <value>The area.</value>
        public string Area { get; set; }
        /// <summary>
        /// Gets or sets the namespace.
        /// </summary>
        /// <value>The namespace.</value>
        public string Namespace { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is content extendable.
        /// </summary>
        /// <value><c>true</c> if this instance is content extendable; otherwise, <c>false</c>.</value>
        public bool IsContentExtendable { get; set; }
        /// <summary>
        /// Gets or sets the actions.
        /// </summary>
        /// <value>The actions.</value>
        public List<CMSAction> Actions { get; set; }
        /// <summary>
        /// Gets or sets the type of the bap entity.
        /// </summary>
        /// <value>The type of the bap entity.</value>
        public Type BapEntityType { get; set; }
        /// <summary>
        /// Gets or sets the type of the controller class.
        /// </summary>
        /// <value>The type of the controller class.</value>
        public Type ControllerClassType { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [entity list customizable].
        /// </summary>
        /// <value><c>true</c> if [entity list customizable]; otherwise, <c>false</c>.</value>
        public bool EntityListCustomizable { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [entity details customizable].
        /// </summary>
        /// <value><c>true</c> if [entity details customizable]; otherwise, <c>false</c>.</value>
        public bool EntityDetailsCustomizable { get; set; }        
    }
}
