// ***********************************************************************
// Assembly         : BAP.ContentManagement
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="DesignComponentGroup.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAP.Common;

namespace BAP.ContentManagement.DesignComponents
{
    /// <summary>
    /// Class DesignComponentGroup.
    /// </summary>
    public class DesignComponentGroup
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>The display name.</value>
        public string DisplayName { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DesignComponentGroup"/> is expandable.
        /// </summary>
        /// <value><c>true</c> if expandable; otherwise, <c>false</c>.</value>
        public bool Expandable { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DesignComponentGroup"/> is expanded.
        /// </summary>
        /// <value><c>true</c> if expanded; otherwise, <c>false</c>.</value>
        public bool Expanded { get; set; }
        /// <summary>
        /// Gets or sets the components.
        /// </summary>
        /// <value>The components.</value>
        public List<IContentComponent> Components { get; set; }
    }
}
