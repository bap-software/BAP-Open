// ***********************************************************************
// Assembly         : BAP.ContentManagement
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-08-2020
// ***********************************************************************
// <copyright file="EditableHtmlCtrl.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.Common;
using BAP.ContentManagement.DesignComponents.EditableHtml;

namespace BAP.ContentManagement.DesignComponents
{
    /// <summary>
    /// Class EditableHtmlCtrl.
    /// Implements the <see cref="BAP.Common.IContentComponent" />
    /// </summary>
    /// <seealso cref="BAP.Common.IContentComponent" />
    public class EditableHtmlCtrl : IContentComponent
    {
        /// <summary>
        /// If specified main content will wrapped with this tag
        /// </summary>
        /// <value>The container tag.</value>
        public string ContainerTag
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// If specified, will be placed after the main content on the page
        /// </summary>
        /// <value>The content after.</value>
        public string ContentAfter
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// If specified, will be placed before main content on the page
        /// </summary>
        /// <value>The content before.</value>
        public string ContentBefore
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// Input control (can be hidden) used by dialog to store content to be placed on the page
        /// </summary>
        /// <value>The content holder field identifier.</value>
        public string ContentHolderFieldId
        {
            get
            {
                return "hdnEditableHtmlContent";
            }
        }

        /// <summary>
        /// Description of the component
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get
            {
                return "Text area to keep some editable HTML to appear on page.";
            }
        }

        /// <summary>
        /// If has dialog, this will shown inside dialog, otherwise will be just placed on the page
        /// </summary>
        /// <value>The content of the dialog.</value>
        public string DialogContent
        {
            get
            {                
                EditableHtmlTemplate template = new EditableHtmlTemplate();                
                return template.TransformText();
            }
        }

        /// <summary>
        /// Short name shown on design panel
        /// </summary>
        /// <value>The display name.</value>
        public string DisplayName
        {
            get
            {
                return "Editable HTML";
            }
        }

        /// <summary>
        /// If True, designed will show additonal popup to configure inserted content
        /// </summary>
        /// <value><c>true</c> if this instance has dialog; otherwise, <c>false</c>.</value>
        public bool HasDialog
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Icon to be used on design panel
        /// </summary>
        /// <value>The icon CSS.</value>
        public string IconCss
        {
            get
            {
                return "fa fa-pencil";
            }
        }

        /// <summary>
        /// JavaScript to be used by dialog box, can be anything, but mainly manipulation and transformation of the content to be placed on the page
        /// </summary>
        /// <value>The content of the java script.</value>
        public string JavaScriptContent
        {
            get
            {
                EditableHtmlJavaScript template = new EditableHtmlJavaScript()
                {
                    CssClass = MainCss
                };
                return template.TransformText();
            }
        }

        /// <summary>
        /// In container tag is specified, this will be added as class to that
        /// </summary>
        /// <value>The main CSS.</value>
        public string MainCss
        {
            get
            {
                return "bap-editable-html";
            }
        }

        /// <summary>
        /// System name of the component
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "EditableHtml";
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has ck editor.
        /// </summary>
        /// <value><c>true</c> if this instance has ck editor; otherwise, <c>false</c>.</value>
        public bool HasCKEditor => false;
    }
}
