using BAP.DAL.Entities;

namespace BAP.Web.Areas.BlogsArea.Models
{    
    public class BlogCategory
    {        
        public LookupValue Category { get; set; }
        
        public int BlogNumber { get; set; }
    }
}