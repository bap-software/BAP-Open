// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="IEntityContent.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.Common
{
    /// <summary>
    /// Interface indicates whether given entity content is available for customaztion via Content Management
    /// </summary>
    public interface IEntityContent
    {

        /// <summary>
        /// List of entities customization is allowed
        /// </summary>
        /// <value><c>true</c> if [list customized]; otherwise, <c>false</c>.</value>
        bool ListCustomized { get; }

        /// <summary>
        /// Entitty details page customization is allowed
        /// </summary>
        /// <value><c>true</c> if [details customized]; otherwise, <c>false</c>.</value>
        bool DetailsCustomized { get; }

        /// <summary>
        /// Relative Url of the custom page to show entity details
        /// </summary>
        /// <value>The custom details URL.</value>
        string CustomDetailsUrl { get; set; }
    }
}
