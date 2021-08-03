using System.Collections.Generic;

using BAP.DAL.Entities;
using BAP.eCommerce.DAL.Entities;

namespace BAP.Web.Areas.eCommerce.Models
{
    public class WishlistModel
    {
        public List<Product> Products { get; set; }

        public Currency Currency { get; set; }
    }
}