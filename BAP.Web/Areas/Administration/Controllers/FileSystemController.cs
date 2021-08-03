using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

using BAP.DAL;
using BAP.DAL.Entities;
using BAP.Log;
using BAP.Lookups;
using BAP.Email;
using BAP.FileSystem;
using BAP.UI.Controllers;
using BAP.Web.Areas.Administration.Models;
using BAP.Common;

namespace BAP.Web.Areas.Administration.Controllers
{
    public static class FileSystemExtensions
    {
        public static MvcHtmlString BapFolderTreeView(this HtmlHelper helper, BAPFileSystemData data, int treeViewId, string mode = "")
        {
            var result = "<ul class=\"jstree-container-ul jstree-children\" role=\"group\">";
            if (data != null && data.RootFolder != null)
            {
                int nodeIndex = 0;
                result += ProcessFileSystemFolderExtension(data, data.RootFolder, treeViewId, 1, ref nodeIndex, mode);
            }
            result += "</ul>";
            return MvcHtmlString.Create(result);
        }

        private static string ProcessFileSystemFolderExtension(BAPFileSystemData data, BAPFolder folder, int treeViewId, int level, ref int index, string mode = "")
        {
            index++;

            string liCss = "jstree-open";
            string selectedCss = "";
            if (folder.ChildFolders == null || folder.ChildFolders.Count == 0)
                liCss = "jstree-leaf";

            if (data.CurrentFolder == folder)
                selectedCss = " jstree-clicked";

            string routeValues = "?currentFolder=" + HttpUtility.UrlEncode(folder.FullRelativePath);
            routeValues += "&page=" + data.PageNumber;
            routeValues += "&pageSize=" + data.PageSize;
            if (!string.IsNullOrEmpty(data.CurrentFileFilter))
                routeValues += "&currentFilter=" + HttpUtility.UrlEncode(data.CurrentFileFilter);
            if (!string.IsNullOrEmpty(data.CurrentFileSort))
                routeValues += "&sortOrder=" + HttpUtility.UrlEncode(data.CurrentFileSort);
            if (!mode.IsNullOrEmpty())
                routeValues += "&mode=" + mode;

            string basicId = $"j{treeViewId}_{index}";
            string result = "<li role=\"treeitem\" data-jstree=\"{ &quot;opened&quot;:true}\" data-path-url=\"" + folder.FullRelativePath + "\" aria-selected=\"false\" aria-level=\"" + level + "\" aria-labelledby=\"" + basicId + "_anchor\" aria-expanded=\"true\" id=\"" + basicId + "\" class=\"jstree-node " + liCss + "\">";
            result += "<i class=\"jstree-icon\" role=\"presentation\"></i>";
            result += "<a class=\"jstree-anchor " + selectedCss + " \" href=\"/Administration/FileSystem/Index" + routeValues + "\" tabindex=\"-1\" id=\"" + basicId + "_anchor\">";
            result += "<i class=\"jstree-icon jstree-themeicon fa fa-folder text-warning fa-lg jstree-themeicon-custom\" role=\"presentation\"></i>";
            result += folder.Name;
            result += "</a>";
            if (folder.ChildFolders != null)
            {
                result += "<ul role=\"group\" class=\"jstree-children\">";
                for (int i = 0; i < folder.ChildFolders.Count; i++)
                {
                    result += ProcessFileSystemFolderExtension(data, folder.ChildFolders[i], treeViewId, level + 1, ref index, mode);
                }
                result += "</ul>";
            }
            return result;
        }
    }

    [Authorize(Roles = "Administrator,ContentManager")]
    public class FileSystemController : BaseController<Attachment>
    {
        public FileSystemController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IMailer mailer, IAuthorizationContext context, IFileProcessor fileProcessor) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<Attachment>(configHelper, context), mailer, fileProcessor)
        {
        }

        // GET: Administration/FileSystem
        public ActionResult Index(string sortOrder, string currentFilter, string currentFolder, int? page, int? pageSize, string mode = "")
        {
            ViewBag.Mode = mode;
            return View(GetFileFolder(sortOrder, currentFilter, currentFolder, page, pageSize, mode));
        }

        [HttpPost]
        public ActionResult FolderAction(string actionType, string newFolderPath, string sortOrder, string currentFilter, string currentFolder, int? page, int? pageSize)
        {
            try
            {
                switch (actionType.ToLower())
                {
                    case "create":
                        _fileProcessor.CreateFolder(currentFolder, newFolderPath);
                        break;
                    case "delete":
                        _fileProcessor.DeleteFolder(currentFolder);
                        break;
                }

            }
            catch (Exception exc)
            {
                _logger.LogException("FileSystem", "FolderAction", exc);
                ClientNotify(exc.Message, "Error");
            }

            return RedirectToAction("Index", new
            {
                sortOrder,
                currentFilter,
                currentFolder,
                page,
                pageSize
            });
        }

        [HttpPost]
        public ActionResult FileUpload(string currentFolder)
        {
            bool processedSuccessfully = true;
            string fName = "";
            string message = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    if (file != null)
                    {
                        fName = file.FileName;
                        _fileProcessor.UploadFile(currentFolder, file);
                    }
                }
            }
            catch (Exception exc)
            {
                _logger.LogException("FileSystem", "FileUpload", exc);
                processedSuccessfully = false;
                message = exc.Message;
            }

            if (processedSuccessfully)
                return Json(new { Success = true, Message = fName });

            return Json(new { Success = false, Message = message });
        }

        [HttpPut]
        public JsonResult Save(string path, string content)
        {
            try
            {
                _fileProcessor.SaveTextFile(path, content);
                return Json(new { Success = true, Message = "File has been saved." });
            }
            catch(Exception exc)
            {
                _logger.LogException("FileSystem", "Copy", exc);
                return Json(new { Success = false, Message = "File could not be saved." });
            }            
        }

        public ActionResult Copy(string target, string path, string sortOrder, string currentFilter, string currentFolder, int? page, int? pageSize)
        {
            var files = path.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                foreach (var file in files)
                {
                    var bapFile = _fileProcessor.GetFile(file);
                    _fileProcessor.UploadFile(target, bapFile);
                }
            }
            catch (Exception exc)
            {
                _logger.LogException("FileSystem", "Copy", exc);
                ClientNotify(exc.Message, "Error");
            }
            ClientNotify($"Processed {files.Length} files", "Info");
            return RedirectToAction("Index", new { sortOrder, currentFilter, currentFolder, page, pageSize });
        }

        public ActionResult Move(string target, string path, string sortOrder, string currentFilter, string currentFolder, int? page, int? pageSize)
        {
            var files = path.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                foreach (var file in files)
                {
                    var bapFile = _fileProcessor.GetFile(file);
                    _fileProcessor.UploadFile(target, bapFile);
                    _fileProcessor.DeleteFile(file);
                }
            }
            catch (Exception exc)
            {
                _logger.LogException("FileSystem", "Move", exc);
                ClientNotify(exc.Message, "Error");
            }
            ClientNotify($"Processed {files.Length} files", "Info");
            return RedirectToAction("Index", new { sortOrder, currentFilter, currentFolder, page, pageSize });
        }

        public ActionResult Delete(string path, string sortOrder, string currentFilter, string currentFolder, int? page, int? pageSize)
        {
            var files = path.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                foreach (var file in files)
                    _fileProcessor.DeleteFile(file);
            }
            catch (Exception exc)
            {
                _logger.LogException("FileSystem", "Delete", exc);
                ClientNotify(exc.Message, "Error");
            }
            ClientNotify($"Deleted {files.Length} files", "Info");
            return RedirectToAction("Index", new { sortOrder, currentFilter, currentFolder, page, pageSize });
        }

        #region private methods

        private BAPFileSystemData GetFileFolder(string sortOrder, string currentFilter, string currentFolderPath, int? page, int? pageSize, string mode = "")
        {
            List<BAPFile> files = null;
            BAPFolder currentFolder = null;
            var folder = _fileProcessor.GetRootFolder("");
            var rootFolder = ProcessFileFolder(folder, ref files, ref currentFolder, currentFolderPath);
            var data = new BAPFileSystemData(rootFolder, currentFolder, page ?? 1, pageSize ?? 20, currentFilter, sortOrder, files);
            if (data.CurrentFolderFiles != null && data.CurrentFolderFiles.Count > 0)
            {
                _fileProcessor.ReadAttachmentData(data.CurrentFolderFiles.Select(a => a.FileInfo).ToList());
            }

            return data;
        }

        private BAPFolder ProcessFileFolder(BAPFolderInfo folder, ref List<BAPFile> files, ref BAPFolder currentFolder, string currentFolderPath = "")
        {
            if (currentFolderPath == null)
                currentFolderPath = "";

            var result = new BAPFolder
            {
                Name = folder.FolderName,
                FullRelativePath = folder.Path,
                ParentFolder = null,
                Description = folder.FolderName + " " + folder.LastModified,
                IsCurrent = (folder.Path == currentFolderPath)
            };
            if (result.IsCurrent)
                currentFolder = result;

            if (folder.ChildFolders != null && folder.ChildFolders.Count > 0)
            {
                result.ChildFolders = new List<BAPFolder>();
                foreach (var childFolder in folder.ChildFolders)
                {
                    var childResult = ProcessFileFolder(childFolder, ref files, ref currentFolder, currentFolderPath);
                    childResult.ParentFolder = result;
                    result.ChildFolders.Add(childResult);
                }
            }

            //add files to the current folder if required
            if (result.FullRelativePath == currentFolderPath && folder.Files != null && folder.Files.Count > 0)
            {
                if (files == null)
                    files = new List<BAPFile>();

                foreach (var file in folder.Files)
                {
                    files.Add(new BAPFile
                    {
                        FileInfo = file,
                        Name = file.FileName,
                        Description = file.FileName + " " + file.MimeType + " " + file.LastModified,
                        LastModified = file.LastModified,
                        MimeType = file.MimeType,
                        Size = file.Size,
                        Type = file.Type,
                        PathUrl = file.Path,
                        TextEditAllowed = file.TextEditAllowed
                    });
                }
            }

            return result;
        }
        #endregion
    }
}
