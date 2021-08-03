using System;
using System.Collections.Generic;
using BAP.DAL.Entities;

namespace BAP.Web.Areas.BlogsArea.Models
{    
    public class BlogModel
    {        
        public BlogModel Prev { get; set; }
        public BlogModel Next { get; set; }
        public string BlogPublicId { get; set; }
        public string PostPublicId { get; set; }
        public int Id { get; set; }

        public int BlogId { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public string MainImageUrl { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public int? BlogAuthorId { get; set; }

        public string BlogAuthor { get; set; }

        public string FacebookUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string LinkedinUrl { get; set; }

        public string GoogleplusUrl { get; set; }

        public string InstagramUrl { get; set; }

        public List<BlogPost> BlogPosts { get; set; }

        public List<BlogComment> BlogComments { get; set; }
    }
}