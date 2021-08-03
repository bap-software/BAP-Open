// ***********************************************************************
// Assembly         : BAP.eCommerce.DataWizards
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="IFileVerifyService.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Web;

namespace BAP.eCommerce.DataWizards.Services.AbstractTypes
{
    // <summary> Verifies if file is null or empty
    /// <summary>
    /// Interface IFileVerifyService
    /// </summary>
    public interface IFileVerifyService
    {
        /// <summary>
        /// Files the is not null and empty.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool FileIsNotNullAndEmpty(HttpPostedFileBase file);
    }
}
