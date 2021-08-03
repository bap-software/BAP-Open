// ***********************************************************************
// Assembly         : BAP.eCommerce.DataWizards
// Author           : Victor Mamray
// Created          : 06-11-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="UploadFileService.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Web;

using BAP.FileSystem;
using BAP.eCommerce.DataWizards.Services.AbstractTypes;

namespace BAP.eCommerce.DataWizards.Services.ConcreteTypes
{
    /// <summary>
    /// Class UploadFileService.
    /// Implements the <see cref="BAP.eCommerce.DataWizards.Services.AbstractTypes.IUploadFileService" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.DataWizards.Services.AbstractTypes.IUploadFileService" />
    public class UploadFileService : IUploadFileService
    {
        /// <summary>
        /// The public folder name
        /// </summary>
        private const string PublicFolderName = "Public";
        /// <summary>
        /// The product cat folder name
        /// </summary>
        private const string ProductCatFolderName = "ProductCatData";
        /// <summary>
        /// The product folder name
        /// </summary>
        private const string ProductFolderName = "Products";
        // <summary> Gets file with fileName
        /// <summary>
        /// Gets the file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileProcessor">The file processor.</param>
        /// <param name="isProduct">if set to <c>true</c> [is product].</param>
        /// <returns>BAPFileInfo.</returns>
        public BAPFileInfo GetFile(string fileName, IFileProcessor fileProcessor, bool isProduct = false)
        {
            BAPFileInfo file = null;
            try
            {
                file = isProduct ? fileProcessor.GetFile($"{PublicFolderName}/{ProductFolderName}/" + fileName) : 
                    fileProcessor.GetFile($"{PublicFolderName}/{ProductCatFolderName}/" + fileName);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            return file;
        }

        // <summary> Creates Folder and saves file in it
        /// <summary>
        /// Uploads the file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="_fileProcessor">The file processor.</param>
        /// <param name="isProduct">if set to <c>true</c> [is product].</param>
        /// <returns>System.String.</returns>
        public string UploadFile(HttpPostedFileBase file, IFileProcessor _fileProcessor, bool isProduct = false)
        {
            string filePath, folder;
            if (isProduct)
            {
                _fileProcessor.CreateFolder(PublicFolderName, ProductFolderName);
                folder = $"{PublicFolderName}/{ProductFolderName}";
                filePath = _fileProcessor.UploadFile(folder, file);
            }
            else
            {
                _fileProcessor.CreateFolder(PublicFolderName, ProductCatFolderName);
                folder = $"{PublicFolderName}/{ProductCatFolderName}";
                filePath = _fileProcessor.UploadFile(folder, file);
            }
            return filePath;
        }
    }
}
