using System.Collections.Generic;

namespace BAP.Web.Areas.eCommerce.Models
{
    public class CategoryModel
    {
        public int? CategoryId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string PCID { get; set; }
        public List<ManufacturerModel> Manufacturers { get; set; }
    }

    public class ManufacturerModel
    {
        public int? ManufacturerId { get; set; }
        public string Name { get; set; }
        public List<ProductByCategoryModel> ProductByCategory { get; set; }
    }

    public class ProductByCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float RegularPrice { get; set; }
        public float SalesPrice { get; set; }
        public string ImagePath { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string PublicId { get; set; }
        public int? ManufacturerId { get; set; }
        public int? CategoryId { get; set; }
        public bool IsDiscounted() => SalesPrice > 0 && SalesPrice < RegularPrice;
        public string GetDiscount() => ((int)(((RegularPrice - SalesPrice) / RegularPrice) * 100)).ToString();
    }
}
