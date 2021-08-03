using Newtonsoft.Json;

namespace BAP.eCommerce.Suppliers.BrainDropShipping.ApiModels
{
    public class PutProductRequest : PostRequestModel
    {
        [JsonProperty("productID")]
        public int ProductId { get; set; }
        
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        
        [JsonProperty("recipient_price")]
        public decimal RecipientPrice { get; set; }
    }
}