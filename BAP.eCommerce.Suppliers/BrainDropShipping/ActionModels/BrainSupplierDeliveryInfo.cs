using BAP.eCommerce.Suppliers.BrainDropShipping.ApiModels;

namespace BAP.eCommerce.Suppliers.BrainDropShipping.ActionModels
{
    public class BrainSupplierDeliveryInfo
    {
        public int RecipientType { get; set; }
        
        public string FullName { get; set; }
        
        /// <summary>
        /// Recipient phone number in format 0xxxxxxxxx
        /// </summary>
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }
        
        /// <summary>
        /// self or home
        /// </summary>
        public string DeliveryType { get; set; }
        
        public int DeliveryServiceCode { get; set; }
        
        public int TargetId { get; set; }
        public string Currency { get; set; } = BrainCurrency.Uah;
    }
}