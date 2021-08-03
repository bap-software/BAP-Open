// ***********************************************************************
// Assembly         : BAP.ContentManagement
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="CMSNode.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using BAP.ContentManagement.DesignerSettings;
using BAP.DAL.Entities;

namespace BAP.ContentManagement
{
    /// <summary>
    /// Class CMSNode.
    /// </summary>
    public class CMSNode
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
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public ContentNode Content { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is root.
        /// </summary>
        /// <value><c>true</c> if this instance is root; otherwise, <c>false</c>.</value>
        public bool IsRoot { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is home.
        /// </summary>
        /// <value><c>true</c> if this instance is home; otherwise, <c>false</c>.</value>
        public bool IsHome { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is leaf.
        /// </summary>
        /// <value><c>true</c> if this instance is leaf; otherwise, <c>false</c>.</value>
        public bool IsLeaf { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is assembly.
        /// </summary>
        /// <value><c>true</c> if this instance is assembly; otherwise, <c>false</c>.</value>
        public bool IsAssembly { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is controller.
        /// </summary>
        /// <value><c>true</c> if this instance is controller; otherwise, <c>false</c>.</value>
        public bool IsController { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is application.
        /// </summary>
        /// <value><c>true</c> if this instance is application; otherwise, <c>false</c>.</value>
        public bool IsApplication { get; set; }
        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>The parent.</value>
        public CMSNode Parent { get; set; }
        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>The children.</value>
        public List<CMSNode> Children { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is serialized.
        /// </summary>
        /// <value><c>true</c> if this instance is serialized; otherwise, <c>false</c>.</value>
        public bool IsSerialized { get; set; }
        /// <summary>
        /// Gets or sets the view path.
        /// </summary>
        /// <value>The view path.</value>
        public string ViewPath { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CMSNode"/> is expanded.
        /// </summary>
        /// <value><c>true</c> if expanded; otherwise, <c>false</c>.</value>
        public bool Expanded { get; set; } = true;
        /// <summary>
        /// Gets or sets a value indicating whether this instance is partial view.
        /// </summary>
        /// <value><c>true</c> if this instance is partial view; otherwise, <c>false</c>.</value>
        public bool IsPartialView { get; set; }
        /// <summary>
        /// Gets or sets the controllers.
        /// </summary>
        /// <value>The controllers.</value>
        public List<CMSController> Controllers { get; set; }
        /// <summary>
        /// Gets or sets the this controller.
        /// </summary>
        /// <value>The this controller.</value>
        public CMSController ThisController { get; set; }
        /// <summary>
        /// Gets or sets the page settings.
        /// </summary>
        /// <value>The page settings.</value>
        public PageSettings PageSettings { get; set; }
    }
}
