using System;
using System.Web.Mvc;

using BAP.Common;
using BAP.Lookups;
using BAP.Log;
using BAP.DAL;
using BAP.DAL.Entities;
using BAP.FileSystem;
using BAP.UI.Controllers;


namespace BAP.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator,ContentManager")]
    public class BlogCommentsController : BaseController<BlogComment>
    {        
        public BlogCommentsController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context, IFileProcessor fileProc) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<BlogComment>(configHelper, context), null, fileProc)
        {
        }

        // POST: BlogComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize(Roles = "Administrator,ContentManager")]
        public ActionResult Create([Bind(Include = "Id,Title,Author,Text,BlogId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] BlogComment blogComment)
        {
            if (ModelState.IsValid)
            {
                _bl.AddBlogComment(blogComment);
            }
            TempData["CurrentTab"] = "comments";
            return RedirectToAction("Details", "Blogs", new { id = blogComment.BlogId });
        }

        // POST: BlogComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize(Roles = "Administrator,ContentManager")]
        public ActionResult Edit([Bind(Include = "Id,Title,Author,Text,BlogId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] BlogComment blogComment)
        {
            if (ModelState.IsValid)
            {
                _bl.UpdateBlogComment(blogComment);
            }
            TempData["CurrentTab"] = "comments";
            return RedirectToAction("Details", "Blogs", new { id = blogComment.BlogId });
        }

        // POST: BlogComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,ContentManager")]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogComment blogComment = _bl.GetBlogCommentById(id);
            var blogId = blogComment.BlogId;
            _bl.RemoveBlogComment(blogComment);
            TempData["CurrentTab"] = "comments";
            return RedirectToAction("Details", "Blogs", new { id = blogId });
        }
    }
}
