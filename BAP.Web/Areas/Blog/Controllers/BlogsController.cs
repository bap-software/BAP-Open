using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

using BAP.Common;
using BAP.Lookups;
using BAP.Log;
using BAP.UI.Controllers;
using BAP.FileSystem;
using BAP.DAL;
using BAP.DAL.Entities;
using BAP.Web.Areas.BlogsArea.Models;
using System.Linq;
using BAP.BL;
using Newtonsoft.Json;
using PagedList;
using System.Globalization;
using System.Threading.Tasks;

namespace BAP.Web.Areas.BlogsArea.Controllers
{
    [RouteArea("blog")]
    [RoutePrefix("blogs")]
    [Route("{action}")]
    public class BlogsController : BaseController<Blog>
    {
        const int RECENT_BLOGS = 10;
        const int PAGE_SIZE = 5;

        public BlogsController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<Blog>(configHelper, context), null, fileProc)
        {
        }

        [Route("~/blogs")]
        public ActionResult Index(string sortOrder = "", string currentFilter = "", string searchString = "", int? page = 1)
        {
            if (!string.IsNullOrWhiteSpace(searchString) && searchString != "null")
            {
                var filters = new List<SearchStruct>();
                var categoryFilter = new SearchStruct
                {
                    field = "CategoryCode",
                    value = searchString
                };
                filters.Add(categoryFilter);
                searchString = JsonConvert.SerializeObject(filters);
            }

            var blogs = _bl.SearchBlogs(searchString, sortOrder, page.GetValueOrDefault(), PAGE_SIZE);
            if (searchString == "null")
                blogs = new PagedList<Blog>(blogs.Where(b => string.IsNullOrWhiteSpace(b.CategoryCode)), page.GetValueOrDefault(), PAGE_SIZE);

            if (!string.IsNullOrWhiteSpace(currentFilter))
            {
                var parts = currentFilter.Split(new char[] { '_' });
                var month = int.Parse(parts[0]);
                var year = int.Parse(parts[1]);
                blogs = new PagedList<Blog>(blogs.Where(b => b.CreateDate.GetValueOrDefault().Month == month && b.CreateDate.GetValueOrDefault().Year == year), page.GetValueOrDefault(), PAGE_SIZE);
            }

            FillViewBag(blogs.FirstOrDefault());

            return View(blogs);
        }

        [Route("~/blogs/{pid}/{ppid?}")]
        public ActionResult Details(string pid, string ppid = "")
        {
            //Validate
            if (string.IsNullOrEmpty(pid))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var blog = _bl.GetBlogByPublicId(pid);
            if (blog == null)
            {
                return HttpNotFound();
            }

            //Prepare model
            var blogModels = new List<BlogModel>
            {
                new BlogModel
                {
                    BlogPublicId = blog.GetPublicId(),
                    Id = blog.Id,
                    BlogId = blog.Id,
                    Name = blog.Name,
                    ShortDescription = blog.ShortDescription,
                    Description = blog.Description,
                    Tags = blog.Tags,
                    MainImageUrl = blog.MainImageUrl,
                    LastModifiedDate = blog.LastModifiedDate,
                    FacebookUrl = blog.FacebookUrl,
                    TwitterUrl = blog.TwitterUrl,
                    LinkedinUrl = blog.LinkedinUrl,
                    GoogleplusUrl = blog.GoogleplusUrl,
                    InstagramUrl = blog.InstagramUrl,
                    BlogAuthorId = blog.BlogAuthorId,
                    BlogAuthor = blog.BlogAuthor != null ? blog.BlogAuthor.FullName : string.Empty,
                    BlogPosts = blog.BlogPosts,
                    BlogComments = blog.BlogComments.Where(c => c.ParentComment == null).ToList()
                }
            };
            foreach (var post in blog.BlogPosts)
            {
                blogModels.Add(new BlogModel
                {
                    BlogPublicId = blog.GetPublicId(),
                    PostPublicId = post.GetPublicId(),
                    Id = post.Id,
                    BlogId = blog.Id,
                    Name = post.Title,
                    ShortDescription = post.ShortDescription,
                    Description = post.Text,
                    Tags = blog.Tags,
                    MainImageUrl = post.MainImageUrl,
                    LastModifiedDate = post.LastModifiedDate,
                    FacebookUrl = blog.FacebookUrl,
                    TwitterUrl = blog.TwitterUrl,
                    LinkedinUrl = blog.LinkedinUrl,
                    GoogleplusUrl = blog.GoogleplusUrl,
                    InstagramUrl = blog.InstagramUrl,
                    BlogAuthorId = blog.BlogAuthorId,
                    BlogAuthor = blog.BlogAuthor.FullName,
                    BlogPosts = blog.BlogPosts,
                    BlogComments = blog.BlogComments
                });
            }

            //Navigate
            var modelToShow = blogModels[0];
            if (string.IsNullOrEmpty(ppid))
            {
                if (blogModels.Count > 1)
                    modelToShow.Next = blogModels[1];
            }
            else
            {
                for (int i = 1; i < blogModels.Count; i++)
                {
                    if (blogModels[i].PostPublicId == ppid)
                    {
                        modelToShow = blogModels[i];
                        modelToShow.Prev = blogModels[i - 1];
                        if (i < (blogModels.Count - 1))
                            modelToShow.Next = blogModels[i + 1];
                        break;
                    }
                }
            }

            FillViewBag(blog);

            return View(modelToShow);
        }

        public ActionResult CreateComment()
        {
            return RedirectToAction("Index");
        }

        // POST: Content/Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,User")]
        public async Task<ActionResult> CreateComment([Bind(Include = "Title,Author,Text,BlogId,BlogPostId,ParentCommentId,NotifyAuthorByEmail")] BlogComment blogComment)
        {
            var blog = _bl.GetBlogById(blogComment.BlogId.GetValueOrDefault());
            if (ModelState.IsValid)
            {
                var orgUser = _bl.GetOrganizationUserByAspNetId(blog.CreatedBy);
                if (orgUser != null && blogComment.NotifyAuthorByEmail)
                {
                    blogComment.CommentAuthorUserId = orgUser.Id;
                    blogComment.Blog = blog;
                    await _bl.SendNotificationEmail(blogComment, orgUser.UserName);
                }
                _bl.AddBlogComment(blogComment);
                blog.BlogComments.Add(blogComment);
                var blogModel = new BlogModel
                {
                    BlogPublicId = blog.GetPublicId(),
                    Id = blog.Id,
                    BlogId = blog.Id,
                    Name = blog.Name,
                    ShortDescription = blog.ShortDescription,
                    Description = blog.Description,
                    Tags = blog.Tags,
                    MainImageUrl = blog.MainImageUrl,
                    LastModifiedDate = blog.LastModifiedDate,
                    FacebookUrl = blog.FacebookUrl,
                    TwitterUrl = blog.TwitterUrl,
                    LinkedinUrl = blog.LinkedinUrl,
                    GoogleplusUrl = blog.GoogleplusUrl,
                    InstagramUrl = blog.InstagramUrl,
                    BlogAuthor = blog.BlogAuthor != null ? blog.BlogAuthor.FullName : string.Empty,
                    BlogPosts = blog.BlogPosts,
                    BlogComments = blog.BlogComments.Where(c => c.ParentComment == null).ToList()
                };
                FillViewBag(blog);
                return PartialView("_BlogComments", blogModel);
            }

            return RedirectToAction("Details", new { pid = blog.GetPublicId() });
        }

        [Authorize(Roles = "Administrator,ContentManager,User")]
        public ActionResult SearchBlogs(string sortOrder = "", string searchString = "", int? authorId = -1, int? page = 1)
        {
            var blogSearchResults = new BlogSearchResults();
            int pageNumber = page.GetValueOrDefault();
            ViewBag.BlogSearchResults = blogSearchResults.Search = searchString;
            var filters = new List<SearchStruct>();
            var categoryFilter = new SearchStruct
            {
                field = "fulltext",
                value = searchString
            };
            filters.Add(categoryFilter);
            var searchTerm = JsonConvert.SerializeObject(filters);
            blogSearchResults.Blogs = _bl.SearchBlogs(searchTerm, sortOrder, pageNumber, PAGE_SIZE);
            blogSearchResults.BlogPosts = _bl.SearchBlogPosts(searchTerm, sortOrder, pageNumber, PAGE_SIZE);
            if (!string.IsNullOrWhiteSpace(searchString))
                blogSearchResults.BlogComments = _bl.SearchBlogComments(searchTerm, sortOrder, pageNumber, PAGE_SIZE);

            if (authorId > 0)
            {
                blogSearchResults.Blogs = new PagedList<Blog>(blogSearchResults.Blogs.Where(b => b.BlogAuthorId == authorId), page.GetValueOrDefault(), PAGE_SIZE);
                blogSearchResults.BlogPosts = new PagedList<BlogPost>(blogSearchResults.BlogPosts.Where(b => b.Blog.BlogAuthorId == authorId), page.GetValueOrDefault(), PAGE_SIZE);
            }
            if ((blogSearchResults.Blogs == null || !blogSearchResults.Blogs.Any()) &&
                (blogSearchResults.BlogPosts == null || !blogSearchResults.BlogPosts.Any()) &&
                (blogSearchResults.BlogComments == null || !blogSearchResults.BlogComments.Any()))
                return RedirectToAction("Index");

            FillViewBag();

            return View("SearchResults", blogSearchResults);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,User")]
        public ActionResult LikeComment(int commentId)
        {
            var userId = _authHelper.GetCurrentUserId();
            var blogComment = _bl.LikeBlogCommentUser(commentId, userId);
            return Json(new { blogComment.LikeNumber, blogComment.DislikeNumber }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,User")]
        public ActionResult DislikeComment(int commentId)
        {
            var userId = _authHelper.GetCurrentUserId();
            var blogComment = _bl.DislikeBlogCommentUser(commentId, userId);
            return Json(new { blogComment.LikeNumber, blogComment.DislikeNumber }, JsonRequestBehavior.AllowGet);
        }

        private void FillViewBag(Blog blog = null)
        {
            if (blog != null)
            {
                ViewBag.BlogName = blog.Name;
                ViewBag.BlogShortDescription = blog.ShortDescription;
                ViewBag.BlogFacebookUrl = blog.FacebookUrl;
                ViewBag.BlogTwitterUrl = blog.TwitterUrl;
                ViewBag.BlogLinkedinUrl = blog.LinkedinUrl;
                ViewBag.BlogGoogleplusUrl = blog.GoogleplusUrl;
                ViewBag.BlogInstagramUrl = blog.InstagramUrl;
                ViewBag.AllBlogComments = blog.BlogComments;
                ViewBag.ReturnUrl = Url.Action("Details", new { pid = blog.GetPublicId() });
            }

            var allBlogs = _bl.GetAllBlogs();
            ViewBag.RecentPosts = allBlogs.OrderByDescending(b => b.CreateDate).Take(RECENT_BLOGS).ToList();

            var lookup = _bl.GetLookupByName("CategoryCode");
            var blogCategories = new List<BlogCategory>();
            foreach (var item in lookup.Values)
            {
                var blogCategory = new BlogCategory
                {
                    Category = item,
                    BlogNumber = allBlogs.Count(b => b.CategoryCode == item.Key)
                };
                blogCategories.Add(blogCategory);
            }
            var uncategorized = new BlogCategory
            {
                Category = new LookupValue() { Key = "null", Text = Resources.Resources.FieldLabel_Blog_Uncategorized },
                BlogNumber = allBlogs.Count(b => string.IsNullOrWhiteSpace(b.CategoryCode))
            };
            blogCategories.Add(uncategorized);
            ViewBag.Categories = blogCategories;

            var blogArchives = new List<BlogArchive>();
            var periods = allBlogs.GroupBy(b => new { b.CreateDate.GetValueOrDefault().Month, b.CreateDate.GetValueOrDefault().Year }).Select(b => new { Period = b.Key, Count = b.Count() });

            foreach (var item in periods)
            {
                var blogArchive = new BlogArchive
                {
                    Year = item.Period.Year,
                    Month = item.Period.Month,
                    MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.Period.Month),
                    BlogNumber = item.Count
                };
                blogArchives.Add(blogArchive);
            }
            ViewBag.Archives = blogArchives;
        }
    }
}
