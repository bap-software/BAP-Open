// ***********************************************************************
// Assembly         : BAP.ContentManagement
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="PageSettings.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace BAP.ContentManagement.DesignerSettings
{
    /// <summary>
    /// Class PageSettings.
    /// </summary>
    public class PageSettings
    {
        /// <summary>
        /// Gets or sets the current design group.
        /// </summary>
        /// <value>The current design group.</value>
        public string CurrentDesignGroup { get; set; }
        /// <summary>
        /// Gets or sets the current settings pane.
        /// </summary>
        /// <value>The current settings pane.</value>
        public string CurrentSettingsPane { get; set; }
        /// <summary>
        /// Gets or sets the current page tab.
        /// </summary>
        /// <value>The current page tab.</value>
        public string CurrentPageTab { get; set; }
        /// <summary>
        /// Gets or sets the recently used controls.
        /// </summary>
        /// <value>The recently used controls.</value>
        public List<string> RecentlyUsedControls { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [show design pane].
        /// </summary>
        /// <value><c>true</c> if [show design pane]; otherwise, <c>false</c>.</value>
        public bool ShowDesignPane { get; set; }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns>PageSettings.</returns>
        public PageSettings Init()
        {
            CurrentDesignGroup = "PageContent";
            CurrentSettingsPane = "General";
            CurrentPageTab = "preview";
            RecentlyUsedControls = new List<string>();
            ShowDesignPane = true;
            return this;
        }
    }
}
