using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using System.Linq;

using BAP.Common;
using BAP.Lookups;
using BAP.FileSystem;
using BAP.Log;
using BAP.DAL;
using BAP.DAL.Entities;
using BAP.UI.Controllers;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BAP.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator,ContentManager")]
    public class AttachmentsController : BaseController<Attachment>
    {

        public AttachmentsController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<Attachment>(configHelper, context), null, fileProc)
        {                        
        }

        // GET: Attachments
        public async Task<ActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int rowsPerPage = GetRealPageSize(pageSize);

            InitIndexViewData(sortOrder, currentFilter);

            return View(await _bl.SearchAttachmentsAsync(searchString, sortOrder, pageNumber, rowsPerPage));
        }
        
        // GET: Attachments/Details/5
        public ActionResult Details(int? id, string parentType = @"", int parentId = 0, string parentView = @"")
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = _bl.GetAttachmentById(id.Value);
            if (attachment == null)
            {
                return HttpNotFound();
            }
            InitParentData(parentType, parentId, parentView);

            return View(attachment);
        }

        // GET: Attachments/Create
        public ActionResult Create(string parentType = "", int parentId = 0, string parentView = @"")
        {
            if(!string.IsNullOrEmpty(parentType) && parentId > 0)
            {
                var attachment = new Attachment()
                {
                    Object = parentType,
                    ObjectId = parentId                    
                };
                return View(attachment);
            }
            else
                return View();
        }

        // POST: Attachments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,AttachmentType,Object,ObjectId,PathUrl,Status,StatusDate,Published,PublishFrom,PublishTo,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,File,Length,OwnerGroup,OwnerPermissions,IsExternalUpdate")] Attachment attachment, int? childObjectId)
        {
            return ProcessAddOrUpdate(attachment, (att) => { _bl.AddAttachment(att); return 0; }, childObjectId);
        }        

        // GET: Attachments/Edit/5
        public ActionResult Edit(int? id, string parentType = @"", int parentId = 0, string parentView = @"")
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = _bl.GetAttachmentById(id.Value);
            if (attachment == null)
            {
                return HttpNotFound();
            }

            //saving parent info
            InitParentData(parentType, parentId, parentView);

            return View(attachment);
        }

        // POST: Attachments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,AttachmentType,Object,ObjectId,PathUrl,Status,StatusDate,Published,PublishFrom,PublishTo,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,File,Length,OwnerGroup,OwnerPermissions,IsExternalUpdate")] Attachment attachment)
        {
            return ProcessAddOrUpdate(attachment, (att) => { _bl.UpdateAttachment(att); return 0; });
        }

        // GET: Attachments/Delete/5
        public ActionResult Delete(int? id, string parentType = @"", int parentId = 0, string parentView = @"")
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = _bl.GetAttachmentById(id.Value);
            if (attachment == null)
            {
                return HttpNotFound();
            }

            InitParentData(parentType, parentId, parentView);
            return View(attachment);
        }

        // POST: Attachments/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attachment attachment = _bl.GetAttachmentById(id);

            //remove files
            if (_fileProcessor != null && attachment != null)
            {
                var histFiles = attachment.History != null ? attachment.History.Select(a => a.FilePath).ToList() : new List<string>();
                _fileProcessor.DeleteAttachmentFiles(attachment.PathUrl, histFiles);
            }
                            
            //remove attachment
            _bl.RemoveAttachment(attachment);

            TempData["CurrentTab"] = "attachments";

            //redirect logic 
            var result = RedirectToParent();
            if (result != null)
                return result;

            if (attachment != null && !string.IsNullOrEmpty(attachment.Object) && attachment.ObjectId > 0)
                return RedirectToAction("AdminDetails", GetControllerByEntity(attachment.Object), new { Id = attachment.ObjectId });
            return RedirectToAction("Index");
        }

        private ActionResult ProcessAddOrUpdate(Attachment attachment, Func<Attachment, int> func, int? childObjectId = null)
        {
            if (_fileProcessor == null)
            {
                throw new ArgumentNullException("_fileProcessor");
            }

            if(attachment == null)
            {
                throw new ArgumentNullException("attachment");
            }

            bool isError = true;
            bool isExternalCall = attachment.IsExternalUpdate;
            if (isExternalCall)
            {
                TempData["CurrentTab"] = "attachments";
            }
            if (attachment.Id == 0 && attachment.File == null)
            {
                ClientNotify(Resources.Resources.UIText_ErrorNoFileNoAttachment, Resources.Resources.ErrorText_Error);
            }
            else if (ModelState.IsValid)
            {
                isError = false;
                if(attachment.File != null)
                {
                    var path = _fileProcessor.SaveAttachmentFile(attachment.Object, attachment.ObjectId, attachment.File);
                    if (!string.IsNullOrEmpty(path))
                        attachment.PathUrl = path;

                    attachment.MimeType = attachment.File.ContentType;
                }
                
                if(string.IsNullOrEmpty(attachment.Description))
                    attachment.Description = attachment.Name;

                func(attachment);
            }
            else
            {
                if (isExternalCall)
                {
                    var errorMessage = "";
                    foreach (var st in ModelState)
                    {
                        if (st.Value.Errors.Any())
                        {
                            foreach (var err in st.Value.Errors)
                            {
                                errorMessage += err.ErrorMessage + "\r\n";
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        ClientNotify(errorMessage, Resources.Resources.ErrorText_Error);
                    }
                }
            }

            var result = RedirectToParent();
            if (result != null)
                return result;

            if (isExternalCall)
            {
                return childObjectId.HasValue ? RedirectToAction("AdminDetails", GetControllerByEntity(attachment.Object), new { Id = attachment.ObjectId, childObjectId, attachmentId = attachment.Id }) :
                    RedirectToAction("AdminDetails", GetControllerByEntity(attachment.Object), new { Id = attachment.ObjectId });
            }
            else
            {
                if (isError)
                    return View(attachment);
                else
                    return RedirectToAction("Index");
            }
        }

        private bool IsSortingEnabled()
        {
            var type = typeof(DbSet<Attachment>);
            return type.GetMethod("Sorted") != null;
        }
        
        private void InitParentData(string parentType, int parentId, string parentView)
        {
            if (!string.IsNullOrEmpty(parentType) && parentId > 0 && !string.IsNullOrEmpty(parentView))
            {
                TempData[@"ParentType"] = parentType;
                TempData[@"ParentId"] = parentId;
                TempData[@"ParentView"] = parentView;

                ViewData[@"ParentType"] = parentType;
                ViewData[@"ParentId"] = parentId;
                ViewData[@"ParentView"] = parentView;
            }
        }

        private ActionResult RedirectToParent()
        {
            if (TempData.ContainsKey(@"ParentType") && TempData.ContainsKey(@"ParentId") &&
                    TempData.ContainsKey(@"ParentView"))
            {
                var parentType = TempData[@"ParentType"].ToString();
                var parentView = TempData[@"ParentView"].ToString();
                var parentId = (int)TempData[@"ParentId"];

                return RedirectToAction(parentView, parentType, new { Id = parentId });
            }

            return null;
        }
    }
}
