using System;
using System.Linq;

using BAP.DAL.Entities;

namespace BAP.Web.Areas.eCommerce.Models
{
    public class FeaturedProductModel
    {
        public Currency Currency { get; set; }
        public decimal Price { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Promotion { get; set; }

        public DateTime PublicDate { get; set; }

        public string PublicId { get; set; }
        public string GetDescription() => Promotion;
        //Crop description to n word.
        public string GetDescription(int n) =>string.Join(" ",Promotion.Split(' ').Take(5));
    }
}