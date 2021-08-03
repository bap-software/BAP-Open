// ***********************************************************************
// Assembly         : BAP.UI
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="Containers.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Web.Mvc;

namespace BAP.UI.HtmlHelpers
{
    /// <summary>
    /// Class ContainerExtensions.
    /// </summary>
    public static class ContainerExtensions
    {
        /// <summary>
        /// Class ControlContainer.
        /// Implements the <see cref="System.IDisposable" />
        /// </summary>
        /// <seealso cref="System.IDisposable" />
        private class ControlContainer : IDisposable
        {
            /// <summary>
            /// The tag
            /// </summary>
            private readonly string _tag;
            /// <summary>
            /// The writer
            /// </summary>
            private readonly TextWriter _writer;

            /// <summary>
            /// Initializes a new instance of the <see cref="ControlContainer"/> class.
            /// </summary>
            /// <param name="writer">The writer.</param>
            /// <param name="tag">The tag.</param>
            public ControlContainer(TextWriter writer, string tag)
            {
                _writer = writer;
                _tag = tag;
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                _writer.Write($"</{_tag}>");
            }
        }

        /// <summary>
        /// Begins the control.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="controlType">Type of the control.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="cssClass">The CSS class.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>IDisposable.</returns>
        public static IDisposable BeginControl(this HtmlHelper htmlHelper, string controlType, string id, string name, string tag = "div", string cssClass = "", object htmlAttributes = null)
        {
            var attributes = BaseHtmlExtensionUtils.AssemblyHtmlAttributes(htmlAttributes);
            var writer = htmlHelper.ViewContext.Writer;
            writer.WriteLine($"<{tag} id='{id}' name='{name}' class='{cssClass}' {attributes}>");
            return new ControlContainer(writer, tag);
        }
    }   
}
