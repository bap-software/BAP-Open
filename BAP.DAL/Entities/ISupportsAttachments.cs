// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ISupportsAttachments.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.DAL.Entities;
using System.Collections.Generic;

namespace BAP.Common
{
    /// <summary>
    /// Interface indicates that entity supports list of documents (attachments)
    /// </summary>
    public interface ISupportsAttachments
    {
        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        /// <value>The attachments.</value>
        IList<Attachment> Attachments { get; set; }
    }
}
