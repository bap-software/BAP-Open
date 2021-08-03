using Newtonsoft.Json;

namespace BAP.eCommerce.Suppliers.BrainDropShipping.ApiModels
{
    public class PutOrderRequest
    {
        [JsonRequired, JsonProperty("currency")]
        public string Currency { get; set; }
        
        [JsonRequired, JsonProperty("targetID")]
        public int TargetId { get; set; }
        
        [JsonProperty("addressID")]
        public int AddressId { get; set; }
        
        [JsonProperty("contactID")]
        public int ContactId { get; set; }
        
        [JsonProperty("clientID")]
        public int ClientId { get; set; }
    }
}