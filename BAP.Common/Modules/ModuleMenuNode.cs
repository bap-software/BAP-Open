// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-17-2020
// ***********************************************************************
// <copyright file="ModuleMenuNode.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace BAP.Common.Modules
{
    /// <summary>
    /// Single module menu item class.
    /// </summary>
    public class ModuleMenuNode
    {
        /// <summary>
        /// The key
        /// </summary>
        private string _key;

        /// <summary>
        /// Uniqueue key of the menu item
        /// </summary>
        /// <value>The key.</value>
        public string Key
        {
            get
            {
                var result = _key;
                if(string.IsNullOrWhiteSpace(result))
                {
                    result = string.Format("{0}{1}{2}_Menu", Controller, Action, Alias);
                    if (!string.IsNullOrWhiteSpace(Area))
                        result = Area + "_" + result;					
                }
                return result;
            }
            set
            {
                _key = value;
            }
        }

        /// <summary>
        /// Menu title, shown by the UI. Can be text or a reference to resource string.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Description of the menu item
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Name of the MVC controller
        /// </summary>
        /// <value>The controller.</value>
        public string Controller { get; set; }

        /// <summary>
        /// Name of the MVC Area
        /// </summary>
        /// <value>The area.</value>
        public string Area { get; set; }

        /// <summary>
        /// Name of the MVC action
        /// </summary>
        /// <value>The action.</value>
        public string Action { get; set; }

        /// <summary>
        /// URL alias
        /// </summary>
        /// <value>The alias.</value>
        public string Alias { get; set; }

        /// <summary>
        /// Additional MVC routing values to be passed
        /// </summary>
        /// <value>The routing values.</value>
        public Dictionary<string, object> RoutingValues { get; set; }

        /// <summary>
        /// Additional HTML attributes to be applied on the menu item
        /// </summary>
        /// <value>The HTML attributes.</value>
        public IDictionary<string,object> HtmlAttributes { get; set; }

        /// <summary>
        /// Indicates is this horizontal line separator
        /// </summary>
        /// <value><c>true</c> if this instance is separator; otherwise, <c>false</c>.</value>
        public bool IsSeparator { get; set; }

        /// <summary>
        /// Indicates if this supports mouse click
        /// </summary>
        /// <value><c>true</c> if clickable; otherwise, <c>false</c>.</value>
        public bool Clickable { get; set; }

        /// <summary>
        /// Order number in the sequence of others
        /// </summary>
        /// <value>The sort order.</value>
        public int? SortOrder { get; set; }

        /// <summary>
        /// User roles having access to the menu item, if empty - allowed to all
        /// </summary>
        /// <value>The roles.</value>
        public string[] Roles { get; set; }

        /// <summary>
        /// Alternative URL to be assosiated with the menu
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }

        /// <summary>
        /// HTML target (e.g. _blank)
        /// </summary>
        /// <value>The target.</value>
        public string Target { get; set; }

        /// <summary>
        /// HTTP method (e.g. GET, POST)
        /// </summary>
        /// <value>The HTTP method.</value>
        public string HttpMethod { get; set; }

        /// <summary>
        /// Is available under Administration area only
        /// </summary>
        /// <value><c>true</c> if this instance is admin; otherwise, <c>false</c>.</value>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Array of child menu items
        /// </summary>
        /// <value>The child nodes.</value>
        public ModuleMenuNode[] ChildNodes { get; set; }

        /// <summary>
        /// Route parameters to be saved between calls to the server
        /// </summary>
        /// <value>The preserved route parameters.</value>
        public List<string> PreservedRouteParameters { get; set; }

        /// <summary>
        /// CSS class to describe icon to be shown with the Title
        /// </summary>
        /// <value>The icon.</value>
        public string Icon { get; set; }
    }
}
