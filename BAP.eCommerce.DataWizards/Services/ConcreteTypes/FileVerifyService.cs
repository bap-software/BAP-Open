// ***********************************************************************
// Assembly         : BAP.eCommerce.DataWizards
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="FileVerifyService.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Web;

using BAP.eCommerce.DataWizards.Services.AbstractTypes;

namespace BAP.eCommerce.DataWizards.Services.ConcreteTypes
{
    // <summary> Verifies if HttpPostedFileBase is null or empty
    /// <summary>
    /// Class FileVerifyService.
    /// Implements the <see cref="BAP.eCommerce.DataWizards.Services.AbstractTypes.IFileVerifyService" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.DataWizards.Services.AbstractTypes.IFileVerifyService" />
    public class FileVerifyService : IFileVerifyService
    {
        /// <summary>
        /// Files the is not null and empty.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool FileIsNotNullAndEmpty(HttpPostedFileBase file)
        {
             return (file != null && file.ContentLength > 0);
        }
    }
}





