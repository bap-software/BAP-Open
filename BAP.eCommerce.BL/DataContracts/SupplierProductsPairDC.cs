using System.Collections.Generic;
using BAP.eCommerce.DAL.Entities;

namespace BAP.eCommerce.BL.DataContracts
{
    public class SupplierProductsPairDC
    {
        public int? SupplierId => Supplier?.Id;
        
        public BAP.eCommerce.DAL.Entities.Supplier Supplier { get; set; }
        public List<ShoppingCartProduct> ShoppingCartProducts { get; set; }
    }
}