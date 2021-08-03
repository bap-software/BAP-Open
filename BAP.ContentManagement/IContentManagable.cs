// ***********************************************************************
// Assembly         : BAP.ContentManagement
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="IContentManagable.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.ContentManagement
{
    /// <summary>
    /// Inreface to identify controller as supporting content managament in core
    /// </summary>
    public interface IContentManagable
    {
        /// <summary>
        /// Gets the CMS context.
        /// </summary>
        /// <value>The CMS context.</value>
        CMSEngine CMSContext { get; }
    }
}
