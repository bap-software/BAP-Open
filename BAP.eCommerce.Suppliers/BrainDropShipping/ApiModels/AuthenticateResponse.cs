using Newtonsoft.Json;

namespace BAP.eCommerce.Suppliers.BrainDropShipping.ApiModels
{
    public class AuthenticateResponse
    {
        /// <summary>
        /// Indicates either success or failed status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public string Status { get; set; }
        
        /// <summary>
        /// Authentication token
        /// </summary>
        /// <value>The result.</value>
        [JsonProperty("result")]
        public string Result { get; set; }
    }
}