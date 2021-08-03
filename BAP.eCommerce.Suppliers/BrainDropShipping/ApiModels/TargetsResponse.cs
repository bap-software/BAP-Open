using System.Collections.Generic;
using Newtonsoft.Json;

namespace BAP.eCommerce.Suppliers.BrainDropShipping.ApiModels
{
    public class TargetsResponse
    {
        [JsonProperty("status")] 
        public string Status { get; set; }

        [JsonProperty("result")] 
        public List<TargetsResponseResultItem> Result { get; set; }
        
    }

    public class TargetsResponseResultItem
    {
        [JsonProperty("targetID")] 
        public int TargetId { get; set; }
        
        [JsonProperty("name")] 
        public string Name { get; set; }
        
        [JsonProperty("type")] 
        public string Type { get; set; }
        
        [JsonProperty("region")] 
        public string Region { get; set; }
    }
}