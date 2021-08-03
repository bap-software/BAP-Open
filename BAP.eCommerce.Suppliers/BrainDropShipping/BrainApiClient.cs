using System.Collections.Generic;
using System.Threading.Tasks;
using BAP.Common;
using BAP.Common.Rest;
using BAP.eCommerce.Suppliers.BrainDropShipping.ApiModels;
using BAP.Log;
using Newtonsoft.Json;
using RestSharp;

namespace BAP.eCommerce.Suppliers.BrainDropShipping
{
    public class BrainApiClient : BAPRestClientBase
    {
        public BrainApiClient(IConfigHelper configHelper, ILogger logger) : base(configHelper, logger)
        {
        }

        public BrainApiClient(IConfigHelper configHelper, ILogger logger, string baseUrl) : base(configHelper, logger, baseUrl)
        {
        }
        
        /// <summary>
        /// Authenticates the specified username.
        /// </summary>
        public Task<AuthenticateResponse> AuthenticateAsync(string username, string password)
        {
            var formData = new List<Parameter>
            {
                new Parameter {Name = "login", Value = username},
                new Parameter {Name = "password", Value = password}
            };
            
            var response = DoRestRequest<object, AuthenticateResponse>(null, FullUrl("auth"), "", HttpMethod.Post, formData: formData);
            if (response.Success)
            {
                return Task.FromResult(response.Data);
            }
            
            LogError($"Failed to call {nameof(AuthenticateAsync)} method of {nameof(BrainApiClient)}");
            return Task.FromResult((AuthenticateResponse)null);
        }
        
        /// <summary>
        /// Authenticates the specified username.
        /// </summary>
        public Task<TargetsResponse> GetTargetsAsync(string sessionId)
        {
            
            var response = DoRestRequest<object, TargetsResponse>(null, FullUrl($"targets/{sessionId}"), "", HttpMethod.Get);
            if (response.Success)
            {
                return Task.FromResult(response.Data);
            }
            
            LogError($"Failed to call {nameof(GetTargetsAsync)} method of {nameof(BrainApiClient)}");
            return Task.FromResult((TargetsResponse)null);
        }

        /// <summary>
        /// Add product to cart. Cart is always created within particular session.
        /// </summary>
        public Task<PutProductResponse> AddProductToCartAsync(List<PutProductRequest> products, string sessionId)
        {
            var formData = new List<Parameter>
            {
                new Parameter {Name = "data", Value = JsonConvert.SerializeObject(products)}
            };
            
            var response = DoRestRequest<object, PutProductResponse>(null, FullUrl($"order/{sessionId}"), "", HttpMethod.Post, formData: formData);
            if (response.Success)
            {
                return Task.FromResult(response.Data);
            }
            
            LogError($"Failed to call {nameof(AddProductToCartAsync)} method of {nameof(BrainApiClient)}");
            return Task.FromResult((PutProductResponse)null);
        }

        public Task<AddRecipientResponse> AddRecipientAsync(AddRecipientRequest addRecipientRequest, string sessionId)
        {
            var response = DoRestRequest<AddRecipientRequest, AddRecipientResponse>(addRecipientRequest, FullUrl($"add_recipient/{sessionId}"), "", HttpMethod.Post);
            if (response.Success)
            {
                return Task.FromResult(response.Data);
            }
            
            LogError($"Failed to call {nameof(AddRecipientAsync)} method of {nameof(BrainApiClient)}");
            return Task.FromResult((AddRecipientResponse)null);
        }

        public Task<PutOrderResponse> PutOrderAsync(PutOrderRequest putOrderRequest, string sessionId)
        {
            var response = DoRestRequest<PutOrderRequest, PutOrderResponse>(putOrderRequest, FullUrl($"order/put/{sessionId}"), "", HttpMethod.Post);
            if (response.Success)
            {
                return Task.FromResult(response.Data);
            }
            
            LogError($"Failed to call {nameof(PutOrderAsync)} method of {nameof(BrainApiClient)}");
            return Task.FromResult((PutOrderResponse)null);
        }
        
        public Task<AddRecipientResponse> ShipOrderToDropAsync(int orderId, string sessionId)
        {
            var response = DoRestRequest<object, AddRecipientResponse>(null, FullUrl($"order/{orderId}/ship_to_drop/{sessionId}"), "", HttpMethod.Post);
            if (response.Success)
            {
                return Task.FromResult(response.Data);
            }
            
            LogError($"Failed to call {nameof(ShipOrderToDropAsync)} method of {nameof(BrainApiClient)}");
            return Task.FromResult((AddRecipientResponse)null);
        }
        
        private string FullUrl(string urlPart)
        {
            return $"{_baseUrl.TrimEnd('/')}/{urlPart}";
        }
    }
}