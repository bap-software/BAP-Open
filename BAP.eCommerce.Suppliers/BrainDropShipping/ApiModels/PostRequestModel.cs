using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;

namespace BAP.eCommerce.Suppliers.BrainDropShipping.ApiModels
{
    public abstract class PostRequestModel
    {
        public virtual IList<Parameter> FormData()
        {
            var properties = GetType().GetProperties()
                .Where(x => x.CustomAttributes.Any(attr => attr.AttributeType == typeof(JsonPropertyAttribute)));

            return properties.Select(x => new Parameter
            {
                Name = x.Name,
                Value = x.GetValue(this)
            }).ToList();
        }
    }
}