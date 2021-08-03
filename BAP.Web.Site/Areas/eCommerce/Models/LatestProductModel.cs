using System.Collections.Generic;
using System.Linq;

using BAP.DAL.Entities;
using BAP.eCommerce.DAL.Entities;

namespace BAP.Web.Areas.eCommerce.Models
{
    public class LatestProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string ImagePath { get; set; }
        public string PublicId { get; set; }
    }
}