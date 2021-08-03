using System;
using System.Net;
using System.Web.Mvc;

using BAP.Common;
using BAP.Lookups;
using BAP.Log;
using BAP.BL;
using BAP.UI.Controllers;
using BAP.FileSystem;
using BAP.DAL;

namespace BAP.Web.Areas.Blog.Controllers
{        
    public class BlogsController : BaseController<BAP.DAL.Entities.Blog>
    {
		public BlogsController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<BAP.DAL.Entities.Blog>(configHelper, context))
        {                    
        }

        // GET: Content/Blogs       
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            int pageNumber = 1;
            int pageSize = _configHelper.FakeMaxPageSize;
            
            EntityPagingAttribute pageAttr = (EntityPagingAttribute)Attribute.GetCustomAttribute(typeof(BAP.DAL.Entities.Blog), typeof(EntityPagingAttribute));
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
            var blogs = _bl.SearchBlogs(searchString, sortOrder, pageNumber, pageSize);

            //If only one blog in the list - show it straight away
            if(blogs != null && blogs.Count == 1)
            {
                return RedirectToAction("Details", new { Id = blogs[0].Id });
            }

            return View(blogs);
        }

        // GET: Content/Blogs/Details/5        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAP.DAL.Entities.Blog blog = _bl.GetBlogById(id.Value);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Content/Blogs/Create
        [Authorize(Roles = "Administrator,User")]
        public ActionResult Create()
        {
            //ViewBag.BlogAuthorId = new SelectList(db.BlogAuthors, "Id", "NickName");
            return View();
        }

        // POST: Content/Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,User")]
        public ActionResult Create([Bind(Include = "Id,Name,ShortDescription,Description,MainImageUrl,BlogAuthorId,Tags,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] BAP.DAL.Entities.Blog blog)
        {
            if (ModelState.IsValid)
            {                                
                _bl.AddBlog(blog);
                return RedirectToAction("Index");
            }

            //ViewBag.BlogAuthorId = new SelectList(db.BlogAuthors, "Id", "NickName", blog.BlogAuthorId);
            return View(blog);
        }

        // GET: Content/Blogs/Edit/5
        [Authorize(Roles = "Administrator,User")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAP.DAL.Entities.Blog blog = _bl.GetBlogById(id.Value);
            if (blog == null)
            {
                return HttpNotFound();
            }
            //ViewBag.BlogAuthorId = new SelectList(db.BlogAuthors, "Id", "NickName", blog.BlogAuthorId);
            return View(blog);
        }

        // POST: Content/Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,User")]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortDescription,Description,MainImageUrl,BlogAuthorId,Tags,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] BAP.DAL.Entities.Blog blog)
        {
            if (ModelState.IsValid)
            {            
                _bl.UpdateBlog(blog);
                return RedirectToAction("Index");
            }
            //ViewBag.BlogAuthorId = new SelectList(db.BlogAuthors, "Id", "NickName", blog.BlogAuthorId);
            return View(blog);
        }

        // GET: Content/Blogs/Delete/5
        [Authorize(Roles = "Administrator,User")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAP.DAL.Entities.Blog blog = _bl.GetBlogById(id.Value);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Content/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,User")]
        public ActionResult DeleteConfirmed(int id)
        {
            BAP.DAL.Entities.Blog blog = _bl.GetBlogById(id);
            
            _bl.RemoveBlog(blog);
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
