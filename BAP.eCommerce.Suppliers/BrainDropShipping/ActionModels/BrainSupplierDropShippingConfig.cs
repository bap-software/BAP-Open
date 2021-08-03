using BAP.eCommerce.Suppliers.BrainDropShipping.ApiModels;

namespace BAP.eCommerce.Suppliers.BrainDropShipping.ActionModels
{
    public class BrainSupplierDropShippingConfig
    {
        public string ApiUrl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        
        /// <summary>
        /// Delivery type: self or home.
        /// Default is self.
        /// </summary>
        public string DeliveryType { get; set; } = BrainDeliveryType.Self;

        /// <summary>
        /// Recipient type: person(0) or organization(1).
        /// By default is 0 that means person.
        /// </summary>
        public int RecipientType { get; set; } = BrainRecipientType.Person;

        /// <summary>
        /// Describes particular name for region that will be used for delivery
        /// Default is Nova Poshta
        /// </summary>
        public string TargetRegionName { get; set; } = TargetRegion.NovaPoshta;
    }
}