using System;
using System.Net;
using System.Web.Mvc;

using BAP.Common;
using BAP.Lookups;
using BAP.Log;
using BAP.DAL;
using BAP.FileSystem;
using BAP.UI.Controllers;


namespace BAP.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator,ContentManager")]
    public class BlogsController : BaseController<DAL.Entities.Blog>
    {        
        public BlogsController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context, IFileProcessor fileProc) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<DAL.Entities.Blog>(configHelper, context), null, fileProc)
        {
        }

        // GET: Blogs
        public ActionResult Index(string sortOrder, string currentFilter, int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int rowsPerPage = GetRealPageSize(pageSize);

            InitIndexViewData(sortOrder, currentFilter);

            return View(_bl.SearchBlogs(currentFilter, sortOrder, pageNumber, rowsPerPage));
        }

        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAL.Entities.Blog blog = _bl.GetBlogById(id.Value);
            if (blog == null)
            {
                return HttpNotFound();
            }
            if (TempData["CurrentTab"] != null)
            {
                ViewBag.CurrentTab = TempData["CurrentTab"].ToString();
            }
            return View(blog);
        }

        // GET: Blogs/Create
        [Authorize(Roles = "Administrator,ContentManager")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize(Roles = "Administrator,ContentManager")]
        public ActionResult Create([Bind(Include = "Id,Name,ShortDescription,Description,MainImageUrl,BlogAuthorId,BlogAuthor,Tags,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,CultureCode,LocalizationId,File,CategoryCode,FacebookUrl,TwitterUrl,LinkedinUrl,GoogleplusUrl,InstagramUrl")] DAL.Entities.Blog blog)
        {
            if (ModelState.IsValid)
            {
                ProcessImage(blog);
                _bl.AddBlog(blog);
                return RedirectToAction("Index");
            }

            return View(blog);
        }

        // GET: Blogs/Edit/5
        [Authorize(Roles = "Administrator,ContentManager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var blog = _bl.GetBlogById(id.Value);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize(Roles = "Administrator,ContentManager")]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortDescription,Description,MainImageUrl,BlogAuthorId,BlogAuthor,Tags,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,CultureCode,LocalizationId,File,CategoryCode,FacebookUrl,TwitterUrl,LinkedinUrl,GoogleplusUrl,InstagramUrl")] DAL.Entities.Blog blog)
        {
            if (ModelState.IsValid)
            {
                ProcessImage(blog);
                _bl.UpdateBlog(blog);
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Blogs/Delete/5
        [Authorize(Roles = "Administrator,ContentManager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAL.Entities.Blog blog = _bl.GetBlogById(id.Value);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,ContentManager")]
        public ActionResult DeleteConfirmed(int id)
        {
            DAL.Entities.Blog blog = _bl.GetBlogById(id);
            _bl.RemoveBlog(blog);
            return RedirectToAction("Index");
        }

        private void ProcessImage(DAL.Entities.Blog blog)
        {
            if (blog.File != null)
            {
                _fileProcessor.CreateFolder("Public", "Blogs");
                _fileProcessor.UploadFile("Public/Blogs", blog.File);
                blog.MainImageUrl = "Public/Blogs/" + blog.File.FileName;
            }
        }
    }
}
