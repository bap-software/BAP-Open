using Newtonsoft.Json;

namespace BAP.eCommerce.Suppliers.BrainDropShipping.ApiModels
{
    public class AddRecipientRequest : PostRequestModel
    {
        [JsonRequired, JsonProperty("recipient_type")]
        public int RecipientType { get; set; }
        
        [JsonRequired, JsonProperty("name")]
        public string FullName { get; set; }
        
        /// <summary>
        /// Recipient phone number in format 0xxxxxxxxx
        /// </summary>
        [JsonRequired, JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        
        [JsonRequired, JsonProperty("email")]
        public string Email { get; set; }
        
        /// <summary>
        /// self or home
        /// </summary>
        [JsonRequired, JsonProperty("delivery_type")]
        public string DeliveryType { get; set; }
        
        [JsonRequired, JsonProperty("delivery_service_code")]
        public int DeliveryServiceCode { get; set; }
        
        [JsonRequired, JsonProperty("targetID")]
        public int TargetId { get; set; }
    }
}