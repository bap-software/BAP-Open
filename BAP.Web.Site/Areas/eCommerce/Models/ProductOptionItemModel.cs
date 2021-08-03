namespace BAP.Web.Areas.eCommerce.Models
{
    public class ProductOptionItemModel
    {
        public int Id { get; set; }
        public int ProductOptionId { get; set; }
        public int? RelatedProductId { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Name { get; set; }
        public float PriceAdded { get; set; }
    }
}