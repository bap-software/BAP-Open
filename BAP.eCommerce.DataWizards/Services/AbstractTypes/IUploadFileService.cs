// ***********************************************************************
// Assembly         : BAP.eCommerce.DataWizards
// Author           : Victor Mamray
// Created          : 06-11-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="IUploadFileService.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Web;

using BAP.FileSystem;

namespace BAP.eCommerce.DataWizards.Services.AbstractTypes
{
    /// <summary>
    /// Interface IUploadFileService
    /// </summary>
    public interface IUploadFileService
    {
        // <summary> Creates Folder and saves file in it
        /// <summary>
        /// Uploads the file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="_fileProcessor">The file processor.</param>
        /// <param name="isProduct">if set to <c>true</c> [is product].</param>
        /// <returns>System.String.</returns>
        string UploadFile(HttpPostedFileBase file, IFileProcessor _fileProcessor, bool isProduct = false);

        // <summary> Gets file with fileName
        /// <summary>
        /// Gets the file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileProcessor">The file processor.</param>
        /// <param name="isProduct">if set to <c>true</c> [is product].</param>
        /// <returns>BAPFileInfo.</returns>
        BAPFileInfo GetFile(string fileName, IFileProcessor fileProcessor, bool isProduct = false);
    }
}
