namespace BAP.Web.Areas.eCommerce.Models
{
    public class TrendingProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal SalesPrice { get; set; }
        public string ImagePath { get; set; }
        public string ShortDescription { get; set;  }
        public string Description { get; set; }
        public string PublicId { get; set; }
        //If products price is discounted return true
        public bool IsDiscounted() => SalesPrice > 0 && SalesPrice < RegularPrice;
        public string GetDiscount() => ((int)(((RegularPrice - SalesPrice) / RegularPrice) * 100)).ToString();
    }
}