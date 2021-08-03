using System.Web.Mvc;

namespace BAP.Web.Areas.eCommerce
{
    public class eCommerceAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "eCommerce";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "eCommerce_default",
                "eCommerce/{controller}/{action}/{id}",
                new { controller = "eShop", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "BAP.Web.Areas.eCommerce.Controllers" }
            );
        }
    }
}