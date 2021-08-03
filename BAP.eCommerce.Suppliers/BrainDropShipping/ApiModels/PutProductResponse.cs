using Newtonsoft.Json;

namespace BAP.eCommerce.Suppliers.BrainDropShipping.ApiModels
{
    public class PutProductResponse : IResponseWithError
    {
        [JsonProperty("status")] 
        public string Status { get; set; }

        [JsonProperty("result")]
        public string Result { get; set; }       
        
        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }
        
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}