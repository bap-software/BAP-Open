// ***********************************************************************
// Assembly         : BAP.FileSystem
// Author           : Victor Mamray
// Created          : 06-15-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-24-2020
// ***********************************************************************
// <copyright file="FileProcessorLocal.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Web;
using System.Linq;
using System.Collections.Generic;

using BAP.DAL;
using BAP.Common;
using BAP.Common.Exceptions;
using BAP.BL;
using BAP.DAL.Entities;
using BAP.Log;
using Newtonsoft.Json;
using System.Configuration;

namespace BAP.FileSystem
{
    /// <summary>
    /// Class FileProcessorLocal.
    /// Implements the <see cref="BAP.FileSystem.FileProcessorBase" />
    /// Implements the <see cref="BAP.FileSystem.IFileProcessor" />
    /// Implements the <see cref="BAP.Common.ISupportCustomConfig" />
    /// </summary>
    /// <seealso cref="BAP.FileSystem.FileProcessorBase" />
    /// <seealso cref="BAP.FileSystem.IFileProcessor" />
    /// <seealso cref="BAP.Common.ISupportCustomConfig" />
    public class FileProcessorLocal : FileProcessorBase, IFileProcessor, ISupportCustomConfig
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly FileProcessorLocalConfig _config;
        /// <summary>
        /// The bl
        /// </summary>
        private readonly ICustomConfigurationBL _bl;
        /// <summary>
        /// The custom configuration
        /// </summary>
        private CustomConfiguration _customConfiguration;

        /// <summary>
        /// Gets a value indicating whether [supports custom configuration].
        /// </summary>
        /// <value><c>true</c> if [supports custom configuration]; otherwise, <c>false</c>.</value>
        public bool SupportsCustomConfig => true;

        /// <summary>
        /// Gets the custom configuration json example.
        /// </summary>
        /// <value>The custom configuration json example.</value>
        public string CustomConfigJsonExample => JsonConvert.SerializeObject(new FileProcessorLocalConfig());

        /// <summary>
        /// Gets the type of the custom configuration.
        /// </summary>
        /// <value>The type of the custom configuration.</value>
        public Type CustomConfigType => typeof(FileProcessorLocalConfig);

        /// <summary>
        /// Gets the current custom configuration json.
        /// </summary>
        /// <value>The current custom configuration json.</value>
        public string CurrentCustomConfigJson => _customConfiguration.CurrentConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileProcessorLocal"/> class.
        /// </summary>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="authContext">The authentication context.</param>
        /// <param name="logger">The logger.</param>
        public FileProcessorLocal(IConfigHelper configHelper, IAuthorizationContext authContext, ILogger logger)
        {            
            // core BAP business logic init
            _authContext = authContext;
            _configHelper = configHelper;
            _logger = logger;
            _attachmentBL = new BusinessLayer(_configHelper, _authContext, _logger);
            _bl = new BusinessLayer(_configHelper, _authContext, _logger);

            var type = typeof(FileProcessorLocal);
            _customConfiguration = _bl.GetCustomConfigurationByName($"{type.Assembly.GetName().Name}_{type.Name}");
            if (_customConfiguration != null && !string.IsNullOrWhiteSpace(_customConfiguration.CurrentConfiguration))
                _config = JsonConvert.DeserializeObject<FileProcessorLocalConfig>(_customConfiguration.CurrentConfiguration);
            if (_config == null)
            {
                _config = new FileProcessorLocalConfig();
                var currOrg = _authContext.GetCurrentOrganization(_configHelper);
                if (currOrg != null)
                {
                    if (!string.IsNullOrEmpty(currOrg.BaseFolder))
                        _config.BaseFolder = currOrg.BaseFolder;
                    if (!string.IsNullOrEmpty(currOrg.PublicFolder))
                        _config.PublicFolder = currOrg.PublicFolder;
                }
            }


            // init base folder
            if (HttpContext.Current != null)
            {
                BaseFolder = HttpContext.Current.Server.MapPath(_config.BaseFolder);
                PublicFolder = HttpContext.Current.Server.MapPath(_config.PublicFolder);
            }
            else
            {
                var baseUrl = configHelper.ReadString("BAP.Common.BaseFileFolder");
                BaseFolder = PathToUrl(baseUrl + "/" + _config.BaseFolder);
                PublicFolder = PathToUrl(baseUrl + "/" + _config.PublicFolder);
            }
            if (!Directory.Exists(BaseFolder))
                Directory.CreateDirectory(BaseFolder);
            if (!Directory.Exists(PublicFolder))
                Directory.CreateDirectory(PublicFolder);
        }

        /// <summary>
        /// Gets the file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="isAdmin">if set to <c>true</c> [is admin].</param>
        /// <returns>BAPFileInfo.</returns>
        public BAPFileInfo GetFile(string filePath, bool isAdmin = false)
        {
            var fileInfo = new BAPFileInfo();
            var localFilePath = filePath;
            if (localFilePath.ToLower().StartsWith("/file/"))
                localFilePath = localFilePath.Substring(6);
            
            var fullPath = BaseFolder + localFilePath;            

            // if file is not from public folder - check access to it via Attachments table            
            if (!IsInPublicFolder(fullPath))
            {
                var attachment = _attachmentBL.GetAttachmentByUrl(localFilePath);
                
                if (attachment == null)
                {
                    var attHist = ((IAttachmentHistBL)_attachmentBL).GetAttachmentHistByPath(localFilePath);
                    if(attHist != null)
                    {
                        fileInfo.AttachmentId = attHist.Attachment.Id;
                        fullPath = BaseFolder + attHist.FilePath;
                    }
                    else
                        return new BAPFileInfo();
                }                    
                else
                {
                    fileInfo.AttachmentId = attachment.Id;
                    fullPath = BaseFolder + attachment.PathUrl;
                    if (!isAdmin && attachment.History != null && attachment.History.Count > 0)
                        fullPath = BaseFolder + attachment.History.OrderByDescending(a => a.LastModifiedDate).First().FilePath;
                }
            }

            // if file exists and allowed to read - return stream of it
            if (File.Exists(fullPath))
            {
                var systemFileInfo = new FileInfo(fullPath);
                fileInfo.FileName = systemFileInfo.Name;
                fileInfo.Path = localFilePath;
                fileInfo.MimeType = GetMimeType(systemFileInfo.Extension);
                fileInfo.FileStream = File.OpenRead(fullPath);
                fileInfo.Type = systemFileInfo.Extension;
                fileInfo.Size = systemFileInfo.Length;
                fileInfo.TextEditAllowed = FileAllowedForEdit(systemFileInfo.Name);
                return fileInfo;
            }

            return new BAPFileInfo();
        }

        /// <summary>
        /// Gets the attachment file by identifier.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <param name="isAdmin">if set to <c>true</c> [is admin].</param>
        /// <returns>BAPFileInfo.</returns>
        public BAPFileInfo GetAttachmentFileById(int attachmentId, bool isAdmin = false)
        {
            var attachment = _attachmentBL.GetAttachmentById(attachmentId);
            if(attachment != null)
            {
                var fileInfo = new BAPFileInfo
                {
                    AttachmentId = attachment.Id
                };

                var fullPath = BaseFolder + attachment.PathUrl;
                if(!isAdmin && attachment.History != null && attachment.History.Count > 0)
                    fullPath = BaseFolder + attachment.History.OrderByDescending(a => a.LastModifiedDate).First().FilePath;

                if (File.Exists(fullPath))
                {
                    var systemFileInfo = new FileInfo(fullPath);
                    
                    fileInfo.FileName = systemFileInfo.Name;
                    fileInfo.MimeType = GetMimeType(systemFileInfo.Extension);
                    fileInfo.FileStream = File.OpenRead(fullPath);
                    fileInfo.Type = systemFileInfo.Extension;
                    fileInfo.TextEditAllowed = FileAllowedForEdit(systemFileInfo.Name);
                    return fileInfo;
                }

            }
            return new BAPFileInfo();
        }

        /// <summary>
        /// Uploads the file.
        /// </summary>
        /// <param name="targetFolder">The target folder.</param>
        /// <param name="file">The file.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="BAPFileException">File cannot be uploaded into current folder</exception>
        /// <exception cref="BAPFileException">File cannot be uploaded into current folder</exception>
        public string UploadFile(string targetFolder, HttpPostedFileBase file)
        {
            var targetPath = BaseFolder + targetFolder;            
            var targetDirInfo = new DirectoryInfo(targetPath);
            string resultRelativePath;

            if (IsInPublicFolder(targetPath))
            {
                var pathToSave = GetSafeFilePath(targetDirInfo.FullName + "/" + file.FileName);
                file.SaveAs(pathToSave);
                resultRelativePath = GetRelativePath(pathToSave);
            }
            else
            {
                var obj = "Organization";
                var objId = _authContext.GetCurrentOrganizationId(_configHelper);
                string fullPath;                
                //check if Objects target folder - save in that specific one
                if (PathToUrl(targetDirInfo.FullName.ToLower()).Contains("/" + _objectsFolder.ToLower()))
                {
                    var objectPart = PathToUrl(targetDirInfo.FullName).Replace(AlignFolderPath(BaseFolder + _objectsFolder), "");
                    if (objectPart.StartsWith("/"))
                        objectPart = objectPart.Substring(1);
                    if (objectPart.EndsWith("/"))
                        objectPart = objectPart.Substring(0, objectPart.Length - 1);
                    var objectParts = objectPart.Split("/".ToCharArray());
                    if(objectParts.Length != 2)
                    {
                        throw new BAPFileException("File cannot be uploaded into current folder");
                    }
                   
                    obj = objectParts[0];
                    int.TryParse(objectParts[1], out var i);
                    if(i == 0)
                    {
                        throw new BAPFileException("File cannot be uploaded into current folder");
                    }
                    objId = i;

                    fullPath = BaseFolder + $"{_objectsFolder}/{obj}/{objId}/{file.FileName}";
                }
                else
                {
                    fullPath = PathToUrl(targetDirInfo.FullName + "/" + file.FileName);                    
                }
                
                // update attachment information
                var relativePath = GetRelativePath(fullPath);                                
                var attachment = _attachmentBL.GetAttachmentByUrl(relativePath);
                if (attachment != null)
                {
                    // save file       
                    var safePath = GetSafeFilePath(fullPath);                             
                    file.SaveAs(safePath);
                    var safeFileInfo = new FileInfo(safePath);
                    var attHistItem = new AttachmentHistory
                    {
                        Attachment = attachment,
                        FileName = safeFileInfo.Name,
                        FilePath = GetRelativePath(safePath),
                        Length = file.ContentLength                      
                    };
                    if (attachment.History == null)
                        attachment.History = new List<AttachmentHistory>();

                    attachment.History.Add(attHistItem);                    
                    _attachmentBL.UpdateAttachment(attachment);
                }
                else
                {
                    // save file                                    
                    file.SaveAs(fullPath);

                    // add attachment to DB
                    var systemFileInfo = new FileInfo(fullPath);
                    attachment = new Attachment
                    {
                        AttachmentType = _attachmentBL.GetAttachmentTypeByExtension(systemFileInfo.Extension),
                        File = file,
                        Length = file.ContentLength,
                        Name = file.FileName,
                        PathUrl = relativePath,
                        Object = obj,
                        ObjectId = objId,
                        Status = "New",
                        StatusDate = DateTime.Now,
                        MimeType = file.ContentType
                    };
                    _attachmentBL.AddAttachment(attachment);
                }

                resultRelativePath = relativePath;
            }

            return resultRelativePath;
        }

        /// <summary>
        /// Uploads the file.
        /// </summary>
        /// <param name="targetFolder">The target folder.</param>
        /// <param name="file">The file.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="BAPFileException">File cannot be uploaded into current folder</exception>
        /// <exception cref="BAPFileException">File cannot be uploaded into current folder</exception>
        public string UploadFile(string targetFolder, BAPFileInfo file)
        {
            var targetPath = BaseFolder + targetFolder;
            var targetDirInfo = new DirectoryInfo(targetPath);
            string resultRelativePath;

            if (IsInPublicFolder(targetPath))
            {
                var pathToSave = GetSafeFilePath($"{targetDirInfo.FullName}/{file.FileName}");
                CopyStream(pathToSave, file.FileStream);
                resultRelativePath = GetRelativePath(pathToSave);
            }
            else
            {
                var obj = "Organization";
                var objId = _authContext.GetCurrentOrganizationId(_configHelper);
                string fullPath;
                //check if Objects target folder - save in that specific one
                if (PathToUrl(targetDirInfo.FullName.ToLower()).Contains("/" + _objectsFolder.ToLower()))
                {
                    var objectPart = PathToUrl(targetDirInfo.FullName).Replace(AlignFolderPath(BaseFolder + _objectsFolder), "");
                    if (objectPart.StartsWith("/"))
                        objectPart = objectPart.Substring(1);
                    if (objectPart.EndsWith("/"))
                        objectPart = objectPart.Substring(0, objectPart.Length - 1);
                    var objectParts = objectPart.Split("/".ToCharArray());
                    if (objectParts.Length != 2)
                    {
                        throw new BAPFileException("File cannot be uploaded into current folder");
                    }

                    obj = objectParts[0];
                    int.TryParse(objectParts[1], out var i);
                    if (i == 0)
                    {
                        throw new BAPFileException("File cannot be uploaded into current folder");
                    }
                    objId = i;

                    fullPath = BaseFolder + $"{_objectsFolder}/{obj}/{objId}/{file.FileName}";
                }
                else
                {
                    fullPath = PathToUrl($"{targetDirInfo.FullName}/{file.FileName}");
                }

                // update attachment information
                var relativePath = GetRelativePath(fullPath);
                var attachment = _attachmentBL.GetAttachmentByUrl(relativePath);
                if (attachment != null)
                {
                    // save file       
                    var safePath = GetSafeFilePath(fullPath);
                    CopyStream(safePath, file.FileStream);
                    var safeFileInfo = new FileInfo(safePath);
                    var attHistItem = new AttachmentHistory
                    {
                        Attachment = attachment,
                        FileName = safeFileInfo.Name,
                        FilePath = GetRelativePath(safePath),
                        Length = file.Size
                    };
                    if (attachment.History == null)
                        attachment.History = new List<AttachmentHistory>();

                    attachment.History.Add(attHistItem);
                    _attachmentBL.UpdateAttachment(attachment);
                }
                else
                {
                    // save file     
                    CopyStream(fullPath, file.FileStream);

                    // add attachment to DB
                    var systemFileInfo = new FileInfo(fullPath);
                    attachment = new Attachment
                    {
                        AttachmentType = _attachmentBL.GetAttachmentTypeByExtension(systemFileInfo.Extension),
                        Length = file.Size,
                        Name = file.FileName,
                        PathUrl = relativePath,
                        Object = obj,
                        ObjectId = objId,
                        Status = "New",
                        StatusDate = DateTime.Now,
                        MimeType = file.MimeType
                    };
                    _attachmentBL.AddAttachment(attachment);
                }

                resultRelativePath = relativePath;
            }
            file.FileStream.Close();

            return resultRelativePath;
        }

        /// <summary>
        /// Copies the stream.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="stream">The stream.</param>
        private void CopyStream(string path, FileStream stream)
        {
            using (var fileStream = File.Create(path))
            {
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fileStream);
            }
        }

        /// <summary>
        /// Deletes the file.
        /// </summary>
        /// <param name="path">The path.</param>
        public void DeleteFile(string path)
        {
            List<string> historyFiles = null;
            var attachment = _attachmentBL.GetAttachmentByUrl(path);
            if(attachment != null)
            {
                if(attachment.History != null && attachment.History.Count > 0)
                {
                    historyFiles = attachment.History.Select(a => a.FilePath).ToList();
                }
                _attachmentBL.RemoveAttachment(attachment);
            }

            DeleteAttachmentFiles(path, historyFiles);
        }

        /// <summary>
        /// Saves file of the text kind following given relative path.
        /// </summary>
        /// <param name="path">The path.</param>
        public void SaveTextFile(string path, string content)
        {
            var fullPath = BaseFolder + path;
            File.WriteAllText(fullPath, content);
        }


        /// <summary>
        /// Saves the attachment file.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="objId">The object identifier.</param>
        /// <param name="attachment">The attachment.</param>
        /// <returns>System.String.</returns>
        public string SaveAttachmentFile(string obj, int objId, HttpPostedFileBase attachment)
        {
            string result = string.Empty;
            if (attachment != null && attachment.ContentLength > 0)
            {
                string directory;
                if (!string.IsNullOrEmpty(obj) && objId > 0)
                    directory = $"{_objectsFolder}/{obj}/{objId}/";
                else //just assign to the current organization
                    directory = $"{_objectsFolder}/Organization/{_authContext.GetCurrentOrganizationId(_configHelper)}/";

                var relativePath = $"{directory}{attachment.FileName}";
                if (!Directory.Exists(BaseFolder + directory))
                    Directory.CreateDirectory(BaseFolder + directory);

                attachment.SaveAs(BaseFolder + relativePath);
                result = relativePath;
            }

            return result;
        }

        /// <summary>
        /// Deletes the attachment files.
        /// </summary>
        /// <param name="mainFile">The main file.</param>
        /// <param name="historyFiles">The history files.</param>
        public void DeleteAttachmentFiles(string mainFile, List<string> historyFiles)
        {
            if (!string.IsNullOrEmpty(mainFile))
            {
                if (historyFiles != null && historyFiles.Count > 0)
                {
                    foreach (var hist in historyFiles)
                    {
                        var fPath = this.BaseFolder + hist;
                        if (File.Exists(fPath))
                            File.Delete(fPath);
                    }
                }

                var filePath = this.BaseFolder + mainFile;
                if (File.Exists(filePath))
                    File.Delete(filePath);
            }
        }

        /// <summary>
        /// Gets the root folder.
        /// </summary>
        /// <param name="startingFolder">The starting folder.</param>
        /// <returns>BAPFolderInfo.</returns>
        public BAPFolderInfo GetRootFolder(string startingFolder = "")
        {
            var fullPath = BaseFolder + startingFolder;
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            var result = ProcessDirectory(fullPath, null);
            return result;
        }

        /// <summary>
        /// Creates the folder.
        /// </summary>
        /// <param name="startingFolder">The starting folder.</param>
        /// <param name="newFolderName">New name of the folder.</param>
        /// <exception cref="BAPFileException">Objects folder cannot be created - this is reserved system folder</exception>
        public void CreateFolder(string startingFolder, string newFolderName)
        {
            if(newFolderName.ToLower() == _objectsFolder.ToLower())
            {
                throw new BAPFileException("Objects folder cannot be created - this is reserved system folder");
            }

            var fullPath = BaseFolder + startingFolder;
            if (Directory.Exists(fullPath))
            {
                var systemDirInfo = new DirectoryInfo(fullPath);
                systemDirInfo.CreateSubdirectory(newFolderName);
            }
        }

        /// <summary>
        /// Deletes the folder.
        /// </summary>
        /// <param name="folderPath">The folder path.</param>
        /// <exception cref="BAPFileException">Cannot remove root folder</exception>
        /// <exception cref="BAPFileException">Cannot remove system objects folder</exception>
        /// <exception cref="BAPFileException">Cannot remove system public folder</exception>
        /// <exception cref="BAPFileException">Cannot remove folder which is not empty</exception>
        public void DeleteFolder(string folderPath)
        {
            if(string.IsNullOrEmpty(folderPath))
            {
                throw new BAPFileException("Cannot remove root folder");
            }
            
            var fullPath = BaseFolder + folderPath;
            if (Directory.Exists(fullPath))
            {
                var publicDirInfo = new DirectoryInfo(PublicFolder);
                var systemDirInfo = new DirectoryInfo(fullPath);
                if (systemDirInfo.FullName.ToLower().Contains("\\" + _objectsFolder.ToLower()))
                {
                    throw new BAPFileException("Cannot remove system objects folder");
                }
                if(systemDirInfo.FullName.ToLower() == publicDirInfo.FullName.ToLower())
                {
                    throw new BAPFileException("Cannot remove system public folder");
                }
                if (systemDirInfo.EnumerateDirectories().Any() || systemDirInfo.EnumerateFiles().Any())
                {
                    throw new BAPFileException("Cannot remove folder which is not empty");
                }
                                
                systemDirInfo.Delete();
            }
        }

        #region private methods

        /// <summary>
        /// Gets the safe file path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.String.</returns>
        private string GetSafeFilePath(string path)
        {
            string result = path;
            int index = 1;
            while(File.Exists(result))
            {
                var systemFileInfo = new FileInfo(path);
                if (!string.IsNullOrEmpty(systemFileInfo.Extension))
                    result = path.Insert(path.IndexOf(systemFileInfo.Extension), "." + index);
                else
                    result = path + "." + index;
                index++;
            }
            return result;
        }

        /// <summary>
        /// Process all files in the directory passed in, recurse on any directories that are found, and process the files they contain.
        /// </summary>
        /// <param name="targetDirectory">The target directory.</param>
        /// <param name="parentDir">The parent dir.</param>
        /// <returns>BAPFolderInfo.</returns>
        private BAPFolderInfo ProcessDirectory(string targetDirectory, BAPFolderInfo parentDir)
        {
            var systemDirInfo = new DirectoryInfo(targetDirectory);
            var dirInfo = new BAPFolderInfo
            {
                ParentFolder = parentDir,
                FolderName = systemDirInfo.Name,
                Path = GetRelativePath(PathToUrl(systemDirInfo.FullName)),
                LastModified = systemDirInfo.LastWriteTime
            };

            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            if(fileEntries.Length > 0)
            {
                dirInfo.Files = new List<BAPFileInfo>();
                foreach (string fileName in fileEntries)
                {
                    var systemFileInfo = new FileInfo(fileName);
                    var fileInfo = new BAPFileInfo()
                    {
                        FileName = systemFileInfo.Name.Replace(systemFileInfo.Extension, ""),
                        MimeType = GetMimeType(systemFileInfo.Extension),
                        Path = GetRelativePath(PathToUrl(systemFileInfo.FullName)),
                        Size = systemFileInfo.Length,
                        LastModified = systemFileInfo.LastWriteTime,
                        ParentFolder = dirInfo,
                        Type = systemFileInfo.Extension,
                        TextEditAllowed = FileAllowedForEdit(systemFileInfo.Name)
                    };
                                        
                    dirInfo.Files.Add(fileInfo);
                }
            }
                           
            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            if(subdirectoryEntries.Length > 0)
            {
                dirInfo.ChildFolders = new List<BAPFolderInfo>();
                foreach (string subdirectory in subdirectoryEntries)
                {                                        
                    dirInfo.ChildFolders.Add(ProcessDirectory(subdirectory, dirInfo));
                }
            }

            return dirInfo;
        }

        /// <summary>
        /// Updates the configuration.
        /// </summary>
        /// <param name="json">The json.</param>
        public void UpdateConfig(string json)
        {
            _customConfiguration.CurrentConfiguration = json;
            _bl.UpdateCustomConfiguration(_customConfiguration);
        }

        /// <summary>
        /// Resets to default.
        /// </summary>
        public void ResetToDefault()
        {
            _customConfiguration.CurrentConfiguration = _customConfiguration.DefaultConfiguration;
            _bl.UpdateCustomConfiguration(_customConfiguration);
        }

        #endregion
    }
}
