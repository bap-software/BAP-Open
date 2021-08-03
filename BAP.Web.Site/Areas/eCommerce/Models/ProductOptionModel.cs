using BAP.eCommerce.DAL.Entities;
using System.Collections.Generic;

namespace BAP.Web.Areas.eCommerce.Models
{
    public class ProductOptionModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }

        public ProductOptionUserControl? UserControl { get; set; }
        public ProductOptionType? Type { get; set; }    
        public List<ProductOptionItemModel> OptionItems { get; set; }
    }
}