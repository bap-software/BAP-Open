﻿// ***********************************************************************
// Assembly         : BAP.ContentManagement
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="YouTube.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.Common;

namespace BAP.ContentManagement.DesignComponents.YouTubeCtrl
{
    /// <summary>
    /// Class YouTube.
    /// Implements the <see cref="BAP.Common.IContentComponent" />
    /// </summary>
    /// <seealso cref="BAP.Common.IContentComponent" />
    public class YouTube : IContentComponent
    {
        /// <summary>
        /// The configuration helper
        /// </summary>
        private readonly IConfigHelper _configHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="YouTube"/> class.
        /// </summary>
        /// <param name="configHelper">The configuration helper.</param>
        public YouTube(IConfigHelper configHelper)
        {
            _configHelper = configHelper;
        }

        /// <summary>
        /// System name of the component
        /// </summary>
        /// <value>The name.</value>
        public string Name => "YouTube";

        /// <summary>
        /// Description of the component
        /// </summary>
        /// <value>The description.</value>
        public string Description => "YouTube block";

        /// <summary>
        /// Short name shown on design panel
        /// </summary>
        /// <value>The display name.</value>
        public string DisplayName => "YouTube";

        /// <summary>
        /// If True, designed will show additonal popup to configure inserted content
        /// </summary>
        /// <value><c>true</c> if this instance has dialog; otherwise, <c>false</c>.</value>
        public bool HasDialog => true;

        /// <summary>
        /// If True, dialog uses CKEditor control for the main input control
        /// </summary>
        /// <value><c>true</c> if this instance has ck editor; otherwise, <c>false</c>.</value>
        public bool HasCKEditor => false;

        /// <summary>
        /// If specified, will be placed before main content on the page
        /// </summary>
        /// <value>The content before.</value>
        public string ContentBefore => "";

        /// <summary>
        /// If specified, will be placed after the main content on the page
        /// </summary>
        /// <value>The content after.</value>
        public string ContentAfter => "";

        /// <summary>
        /// In container tag is specified, this will be added as class to that
        /// </summary>
        /// <value>The main CSS.</value>
        public string MainCss => "";

        /// <summary>
        /// Icon to be used on design panel
        /// </summary>
        /// <value>The icon CSS.</value>
        public string IconCss => "fa fa-youtube";

        /// <summary>
        /// If specified main content will wrapped with this tag
        /// </summary>
        /// <value>The container tag.</value>
        public string ContainerTag => "";

        /// <summary>
        /// If has dialog, this will shown inside dialog, otherwise will be just placed on the page
        /// </summary>
        /// <value>The content of the dialog.</value>
        public string DialogContent
        {
            get
            {
                var template = new YouTubeTemplate();
                return template.TransformText();
            }
        }

        /// <summary>
        /// Input control (can be hidden) used by dialog to store content to be placed on the page
        /// </summary>
        /// <value>The content holder field identifier.</value>
        public string ContentHolderFieldId => "hdnYouTubeContent";

        /// <summary>
        /// Gets the content of the java script.
        /// </summary>
        /// <value>The content of the java script.</value>
        public string JavaScriptContent
        {
            get
            {
                var template = new YouTubeJavaScript
                {
                    YouTubeContent = "<iframe src=\"<%0%>\" width=\"<%1%>\" height=\"<%2%>\" frameborder=\"0\" allow=\"accelerometer; autoplay; encrypted - media; gyroscope; picture -in-picture\" allowfullscreen></iframe>"
                };
                return template.TransformText();
            }
        }
    }
}
