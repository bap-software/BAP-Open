using System.Collections.Generic;
using BAP.DAL.Entities;
using BAP.eCommerce.DAL.Entities;

namespace BAP.Web.Areas.eCommerce.Models
{
    public class HomePageModel
    {
        public List<Product> TopFeaturedProducts { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public string SelectedCategoryName { get; set; }
        public List<Product> SelectedCategoryProducts { get; set; }
        public Product SpecialProduct { get; set; }
        public List<OrganizationService> OrgServices { get; set; }
    }
}