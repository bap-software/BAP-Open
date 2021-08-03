using Newtonsoft.Json;

namespace BAP.eCommerce.Suppliers.BrainDropShipping.ApiModels
{
    public class AddRecipientResponse : IResponseWithError
    {
        [JsonProperty("status")] 
        public string Status { get; set; }

        [JsonProperty("recipientID")]
        public int RecipientId { get; set; }

        [JsonProperty("addressID")]
        public int AddressId { get; set; }       
        
        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }
        
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}