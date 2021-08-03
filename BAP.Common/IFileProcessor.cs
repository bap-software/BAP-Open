// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="IFileProcessor.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace BAP.FileSystem
{
    /// <summary>
    /// Class BAPFileInfo.
    /// </summary>
    public class BAPFileInfo
    {
        /// <summary>
        /// Gets or sets the attachment identifier.
        /// </summary>
        /// <value>The attachment identifier.</value>
        public int AttachmentId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is attachment history.
        /// </summary>
        /// <value><c>true</c> if this instance is attachment history; otherwise, <c>false</c>.</value>
        public bool IsAttachmentHistory { get; set; }
        /// <summary>
        /// Gets or sets the attachment history identifier.
        /// </summary>
        /// <value>The attachment history identifier.</value>
        public int AttachmentHistoryId { get; set; }
        /// <summary>
        /// Gets or sets the type of the MIME.
        /// </summary>
        /// <value>The type of the MIME.</value>
        public string MimeType { get; set; }

        /// <summary>
        /// Indicates whether it's possible to use insystem text editor for this type of file.
        /// </summary>
        public bool TextEditAllowed { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName { get; set; }
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path { get; set; }
        /// <summary>
        /// Gets or sets the path aliases.
        /// </summary>
        /// <value>The path aliases.</value>
        public string[] PathAliases { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the alt text.
        /// </summary>
        /// <value>The alt text.</value>
        public string AltText { get; set; }
        /// <summary>
        /// Gets or sets the title text.
        /// </summary>
        /// <value>The title text.</value>
        public string TitleText { get; set; }
        /// <summary>
        /// Gets or sets the keywords.
        /// </summary>
        /// <value>The keywords.</value>
        public string Keywords { get; set; }
        /// <summary>
        /// Gets or sets the file stream.
        /// </summary>
        /// <value>The file stream.</value>
        public FileStream FileStream { get; set; }
        /// <summary>
        /// Gets or sets the last modified.
        /// </summary>
        /// <value>The last modified.</value>
        public DateTime LastModified { get; set; }
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public long Size { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets the parent folder.
        /// </summary>
        /// <value>The parent folder.</value>
        public BAPFolderInfo ParentFolder { get; set; }
    }

    /// <summary>
    /// Class BAPFolderInfo.
    /// </summary>
    public class BAPFolderInfo
    {
        /// <summary>
        /// Gets or sets the name of the folder.
        /// </summary>
        /// <value>The name of the folder.</value>
        public string FolderName { get; set; }
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path { get; set; }
        /// <summary>
        /// Gets or sets the last modified.
        /// </summary>
        /// <value>The last modified.</value>
        public DateTime LastModified { get; set; }
        /// <summary>
        /// Gets or sets the parent folder.
        /// </summary>
        /// <value>The parent folder.</value>
        public BAPFolderInfo ParentFolder { get; set; }
        /// <summary>
        /// Gets or sets the child folders.
        /// </summary>
        /// <value>The child folders.</value>
        public List<BAPFolderInfo> ChildFolders { get; set; }
        /// <summary>
        /// Gets or sets the files.
        /// </summary>
        /// <value>The files.</value>
        public List<BAPFileInfo> Files { get; set; }
    }

    /// <summary>
    /// Interface IFileProcessor
    /// </summary>
    public interface IFileProcessor
    {
        /// <summary>
        /// Gets the base folder.
        /// </summary>
        /// <value>The base folder.</value>
        string BaseFolder { get; }
        /// <summary>
        /// Gets the file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="isAdmin">if set to <c>true</c> [is admin].</param>
        /// <returns>BAPFileInfo.</returns>
        BAPFileInfo GetFile(string filePath, bool isAdmin = false);
        /// <summary>
        /// Gets the attachment file by identifier.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <param name="isAdmin">if set to <c>true</c> [is admin].</param>
        /// <returns>BAPFileInfo.</returns>
        BAPFileInfo GetAttachmentFileById(int attachmentId, bool isAdmin = false);
        /// <summary>
        /// Reads the attachment data.
        /// </summary>
        /// <param name="files">The files.</param>
        void ReadAttachmentData(List<BAPFileInfo> files);

        /// <summary>
        /// Uploads the file.
        /// </summary>
        /// <param name="targetFolder">The target folder.</param>
        /// <param name="file">The file.</param>
        /// <returns>System.String.</returns>
        string UploadFile(string targetFolder, HttpPostedFileBase file);
        /// <summary>
        /// Uploads the file.
        /// </summary>
        /// <param name="targetFolder">The target folder.</param>
        /// <param name="file">The file.</param>
        /// <returns>System.String.</returns>
        string UploadFile(string targetFolder, BAPFileInfo file);

        /// <summary>
        /// Saves file of the text kind following given relative path.
        /// </summary>
        /// <param name="path">The path.</param>
        void SaveTextFile(string path, string content);

        /// <summary>
        /// Deletes the file.
        /// </summary>
        /// <param name="path">The path.</param>
        void DeleteFile(string path);
        
        /// <summary>
        /// Saves the attachment file.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="objId">The object identifier.</param>
        /// <param name="attachment">The attachment.</param>
        /// <returns>System.String.</returns>
        string SaveAttachmentFile(string obj, int objId, HttpPostedFileBase attachment);
        /// <summary>
        /// Deletes the attachment files.
        /// </summary>
        /// <param name="mainFile">The main file.</param>
        /// <param name="historyFiles">The history files.</param>
        void DeleteAttachmentFiles(string mainFile, List<string> historyFiles);

        /// <summary>
        /// Gets the root folder.
        /// </summary>
        /// <param name="startingFolder">The starting folder.</param>
        /// <returns>BAPFolderInfo.</returns>
        BAPFolderInfo GetRootFolder(string startingFolder = "");
        /// <summary>
        /// Creates the folder.
        /// </summary>
        /// <param name="startingFolder">The starting folder.</param>
        /// <param name="newFolderName">New name of the folder.</param>
        void CreateFolder(string startingFolder, string newFolderName);
        /// <summary>
        /// Deletes the folder.
        /// </summary>
        /// <param name="folderPath">The folder path.</param>
        void DeleteFolder(string folderPath);               
    }
}
