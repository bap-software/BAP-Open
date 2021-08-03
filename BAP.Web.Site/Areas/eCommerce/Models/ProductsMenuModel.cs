using System.Collections.Generic;
using BAP.DAL.Entities;
using BAP.eCommerce.DAL.Entities;

namespace BAP.Web.Areas.eCommerce.Models
{
    public class ProductsMenuModel
    {
        public IList<ProductModel> Products { get; set; }

        public IList<ProductCategory> Categories { get; set; }

        public IList<Manufacturer> Manufacturers { get; set; }

        public IList<ContentNode> ContentNodes { get; set; }

        public ProductsMenuModel()
        {
            Products = new List<ProductModel>();
            Categories = new List<ProductCategory>();
            Manufacturers = new List<Manufacturer>();
            ContentNodes = new List<ContentNode>();
        }
    }
}