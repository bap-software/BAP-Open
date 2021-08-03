using System;
using System.Net;
using System.Web.Mvc;

using BAP.Common;
using BAP.Lookups;
using BAP.Log;
using BAP.DAL.Entities;
using BAP.BL;
using BAP.UI.Controllers;
using BAP.FileSystem;
using BAP.DAL;


namespace BAP.Web.Areas.Blog.Controllers
{
    //Every controller is created with restricted access be default. Any public action has to be created explicitly.
    [Authorize(Roles = "Administrator")]
    public class BlogPostsController : BaseController<BlogPost>
    {
		public BlogPostsController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<BlogPost>(configHelper, context))
        {                    
        }

        // GET: Content/BlogPosts
        [AllowAnonymous]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            int pageNumber = 1;
            int pageSize = _configHelper.FakeMaxPageSize;
            
            EntityPagingAttribute pageAttr = (EntityPagingAttribute)Attribute.GetCustomAttribute(typeof(BlogPost), typeof(EntityPagingAttribute));
            if (pageAttr != null && pageAttr.Applied && pageAttr.PageSize > 0)
            {
                ViewBag.CurrentSort = sortOrder;
                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }
                ViewBag.CurrentFilter = searchString;

                pageNumber = (page ?? 1);                
                pageSize = pageAttr.PageSize;                
            }
            
            return View(_bl.SearchBlogPosts(searchString, sortOrder, pageNumber, pageSize));
        }

        // GET: Content/BlogPosts/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = _bl.GetBlogPostById(id.Value);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // GET: Content/BlogPosts/Create
        public ActionResult Create()
        {
            //ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Name");
            return View();
        }

        // POST: Content/BlogPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ShortDescription,Text,MainImageUrl,BlogId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                                
                _bl.AddBlogPost(blogPost);
                return RedirectToAction("Index");
            }

            //ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Name", blogPost.BlogId);
            return View(blogPost);
        }

        // GET: Content/BlogPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = _bl.GetBlogPostById(id.Value);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            //ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Name", blogPost.BlogId);
            return View(blogPost);
        }

        // POST: Content/BlogPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ShortDescription,Text,MainImageUrl,BlogId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {            
                _bl.UpdateBlogPost(blogPost);
                return RedirectToAction("Index");
            }
            //ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Name", blogPost.BlogId);
            return View(blogPost);
        }

        // GET: Content/BlogPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = _bl.GetBlogPostById(id.Value);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: Content/BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPost blogPost = _bl.GetBlogPostById(id);
            
            _bl.RemoveBlogPost(blogPost);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
			    ((System.IDisposable)_bl).Dispose();
		    }
            base.Dispose(disposing);
        }        
    }
}
