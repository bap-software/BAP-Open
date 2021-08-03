using BAP.DAL.Entities;
using PagedList;

namespace BAP.Web.Areas.BlogsArea.Models
{
    public class BlogSearchResults
    {
        public string Search { get; set; }

        public IPagedList<Blog> Blogs { get; set; }

        public IPagedList<BlogPost> BlogPosts { get; set; }

        public IPagedList<BlogComment> BlogComments { get; set; }
    }
}