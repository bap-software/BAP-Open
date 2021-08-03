using Newtonsoft.Json;

namespace BAP.eCommerce.Suppliers.BrainDropShipping.ApiModels
{
    /// <summary>
    /// For more info: http://api.brain.com.ua/help/put_order
    /// </summary>
    public class PutOrderResponse : IResponseWithError
    {
        /// <summary>
        /// Indicates either success or failed status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("result")]
        public PutOrderResponseResult Result { get; set; }       
        
        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }
        
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }

    public class PutOrderResponseResult
    {
        [JsonProperty("orderID")]
        public int OrderId { get; set; }
    }
}