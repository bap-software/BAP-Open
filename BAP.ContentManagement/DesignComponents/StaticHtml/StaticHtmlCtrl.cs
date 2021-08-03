// ***********************************************************************
// Assembly         : BAP.ContentManagement
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-08-2020
// ***********************************************************************
// <copyright file="StaticHtmlCtrl.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.Common;
using BAP.ContentManagement.DesignComponents.StaticHtml;

namespace BAP.ContentManagement.DesignComponents
{
    /// <summary>
    /// Class StaticHtmlCtrl.
    /// Implements the <see cref="BAP.Common.IContentComponent" />
    /// </summary>
    /// <seealso cref="BAP.Common.IContentComponent" />
    public class StaticHtmlCtrl : IContentComponent
    {
        /// <summary>
        /// If True, dialog uses CKEditor control for the main input control
        /// </summary>
        /// <value><c>true</c> if this instance has ck editor; otherwise, <c>false</c>.</value>
        public bool HasCKEditor => true;

        /// <summary>
        /// System name of the component
        /// </summary>
        /// <value>The name.</value>
        string IContentComponent.Name => "StaticHtml";

        /// <summary>
        /// Description of the component
        /// </summary>
        /// <value>The description.</value>
        string IContentComponent.Description => "Add piece of HTML";

        /// <summary>
        /// Short name shown on design panel
        /// </summary>
        /// <value>The display name.</value>
        string IContentComponent.DisplayName => "Static HTML";

        /// <summary>
        /// If True, designed will show additonal popup to configure inserted content
        /// </summary>
        /// <value><c>true</c> if this instance has dialog; otherwise, <c>false</c>.</value>
        bool IContentComponent.HasDialog => true;

        /// <summary>
        /// If specified, will be placed before main content on the page
        /// </summary>
        /// <value>The content before.</value>
        string IContentComponent.ContentBefore => "";

        /// <summary>
        /// If specified, will be placed after the main content on the page
        /// </summary>
        /// <value>The content after.</value>
        string IContentComponent.ContentAfter => "";

        /// <summary>
        /// In container tag is specified, this will be added as class to that
        /// </summary>
        /// <value>The main CSS.</value>
        string IContentComponent.MainCss => "";

        /// <summary>
        /// Icon to be used on design panel
        /// </summary>
        /// <value>The icon CSS.</value>
        string IContentComponent.IconCss => "fa fa-code";

        /// <summary>
        /// If specified main content will wrapped with this tag
        /// </summary>
        /// <value>The container tag.</value>
        string IContentComponent.ContainerTag => "";

        /// <summary>
        /// If has dialog, this will shown inside dialog, otherwise will be just placed on the page
        /// </summary>
        /// <value>The content of the dialog.</value>
        string IContentComponent.DialogContent
        {
            get
            {
                StaticHtmlTemplate template = new StaticHtmlTemplate();
                return template.TransformText();
            }            
        }

        /// <summary>
        /// Input control (can be hidden) used by dialog to store content to be placed on the page
        /// </summary>
        /// <value>The content holder field identifier.</value>
        string IContentComponent.ContentHolderFieldId => "StaticHtmlContent";

        /// <summary>
        /// Gets the content of the java script.
        /// </summary>
        /// <value>The content of the java script.</value>
        string IContentComponent.JavaScriptContent => "";
             
    }
}
