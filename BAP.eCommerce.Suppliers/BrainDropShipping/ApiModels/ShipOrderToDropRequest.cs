using System;
using Newtonsoft.Json;

namespace BAP.eCommerce.Suppliers.BrainDropShipping.ApiModels
{
    /// <summary>
    /// Detailed info: http://api.brain.com.ua/help/ship_order_to_drop
    /// </summary>
    public class ShipOrderToDropRequest
    {
        [JsonProperty("orderID")]
        public int OrderId { get; set; }
        
        [JsonProperty("recipientID")]
        public int RecipientId { get; set; }
        
        [JsonProperty("addressID")]
        public int AddressId { get; set; }
        
        [JsonProperty("recipient_order_number")]
        public int RecipientOrderNumber { get; set; }

        [JsonProperty("payment_method_type")] 
        public int PaymentMethodType { get; set; } = BrainPaymentMethodType.Cash;
        
        [JsonProperty("recipient_order_date")]
        public DateTimeOffset RecipientOrderDate { get; set; } = DateTimeOffset.UtcNow;

        [JsonProperty("delivery_cost")]
        public decimal DeliveryCost { get; set; }
    }
}