// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 04-30-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="CustomConfigurationNode.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace BAP.BL.CustomConfigurationNodes
{
    /// <summary>
    /// Class CustomConfigurationNode.
    /// </summary>
    public class CustomConfigurationNode
    {
        /// <summary>
        /// Gets or sets the node identifier.
        /// </summary>
        /// <value>The node identifier.</value>
        public int NodeId { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the default configuration.
        /// </summary>
        /// <value>The default configuration.</value>
        public string DefaultConfiguration { get; set; }
        /// <summary>
        /// Gets or sets the current configuration.
        /// </summary>
        /// <value>The current configuration.</value>
        public string CurrentConfiguration { get; set; }
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }
        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>The children.</value>
        public List<CustomConfigurationNode> Children { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is root.
        /// </summary>
        /// <value><c>true</c> if this instance is root; otherwise, <c>false</c>.</value>
        public bool IsRoot { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is leaf.
        /// </summary>
        /// <value><c>true</c> if this instance is leaf; otherwise, <c>false</c>.</value>
        public bool IsLeaf { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CustomConfigurationNode"/> is expanded.
        /// </summary>
        /// <value><c>true</c> if expanded; otherwise, <c>false</c>.</value>
        public bool Expanded { get; set; } = true;
    }
}
