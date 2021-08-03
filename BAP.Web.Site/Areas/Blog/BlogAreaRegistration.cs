using System.Web.Mvc;

namespace BAP.Web.Areas.Blog
{
    public class BlogAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Blog";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {            
            context.MapRoute(
                "Blog_default",
                "Blog/{controller}/{action}/{id}",
                new { action = "Index", controller = "Blogs", id = UrlParameter.Optional },
                namespaces: new[] { "BAP.Web.Areas.Blog.Controllers" }
            );            
        }
    }
}