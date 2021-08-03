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
    public class BlogPostsController : BaseController<BlogPost>
    {        
        public BlogPostsController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context, IFileProcessor fileProc) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<BlogPost>(configHelper, context), null, fileProc)
        {
        }

        // POST: BlogPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize(Roles = "Administrator,ContentManager")]
        public ActionResult Create([Bind(Include = "Id,Title,ShortDescription,Text,MainImageUrl,BlogId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,CultureCode,LocalizationId,File")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                ProcessImage(blogPost);
                _bl.AddBlogPost(blogPost);
            }
            TempData["CurrentTab"] = "posts";
            return RedirectToAction("Details", "Blogs", new { id = blogPost.BlogId });
        }

        // POST: BlogPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize(Roles = "Administrator,ContentManager")]
        public ActionResult Edit([Bind(Include = "Id,Title,ShortDescription,Text,MainImageUrl,BlogId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,CultureCode,LocalizationId,File")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                ProcessImage(blogPost);
                _bl.UpdateBlogPost(blogPost);
            }
            TempData["CurrentTab"] = "posts";
            return RedirectToAction("Details", "Blogs", new { id = blogPost.BlogId });
        }

        // POST: BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,ContentManager")]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPost blogPost = _bl.GetBlogPostById(id);
            var blogId = blogPost.BlogId;
            _bl.RemoveBlogPost(blogPost);
            TempData["CurrentTab"] = "posts";
            return RedirectToAction("Details", "Blogs", new { id = blogId });
        }

        private void ProcessImage(BlogPost blogPost)
        {
            if (blogPost.File != null)
            {
                _fileProcessor.CreateFolder("Public", "BlogPosts");
                _fileProcessor.UploadFile("Public/BlogPosts", blogPost.File);
                blogPost.MainImageUrl = "Public/BlogPosts/" + blogPost.File.FileName;
            }
        }
    }
}
