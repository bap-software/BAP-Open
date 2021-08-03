using System;
using System.Collections.Generic;
using System.Linq;
using BAP.Common;
using BAP.Common.Suppliers;
using BAP.eCommerce.DAL.Entities;
using BAP.eCommerce.SupplierEngine;
using BAP.eCommerce.Suppliers.BrainDropShipping.ActionModels;
using BAP.eCommerce.Suppliers.BrainDropShipping.ApiModels;
using BAP.Log;
using Newtonsoft.Json;

namespace BAP.eCommerce.Suppliers.BrainDropShipping
{
    public class RequestDropShippingAction : IBapSupplierAction
    {
        private readonly IConfigHelper _configHelper;
        private readonly ILogger _logger;

        public Guid PublicId
        {
            get => SupplierActionPublicIds.BrainDropShippingAction;
            set => throw new InvalidOperationException($"Not allowed to change {nameof(PublicId)}");
        }
        
        public RequestDropShippingAction(IConfigHelper configHelper, ILogger logger)
        {
            _configHelper = configHelper;
            _logger = logger;
        }
        
        public SupplierExecutionResult ExecuteAction(string supplierConfig, params BapDynamicVariable[] actionArguments)
        {
            var result = new SupplierExecutionResult();

            var config = JsonConvert.DeserializeObject<BrainSupplierDropShippingConfig>(supplierConfig);
            
            var products = FindShoppingCartProducts(actionArguments);
            var deliveryInfo = FindDeliveryInfo(actionArguments);

            var areArgumentsNotValid = ValidateActionArguments(deliveryInfo, result, products);

            if (areArgumentsNotValid)
            {
                return result;
            }
            
            var apiClient = new BrainApiClient(_configHelper, _logger, config.ApiUrl);

            var authenticateResponse = apiClient.AuthenticateAsync(config.UserName, config.Password)
                .GetAwaiter().GetResult();

            if (authenticateResponse.Status != BrainStatusResponse.Success)
            {
                var error = $"Cannot authorize in Brain API.";

                result.AddError(error);
                _logger.LogError(nameof(RequestDropShippingAction), nameof(ExecuteAction), error);
                
                return result;
            }

            var sessionId = authenticateResponse.Result;


            var addProductsRequestData = products.Select(x => new PutProductRequest()
            {
                ProductId = x.Product.ProductSupplierData.ExternalProductId,
                Quantity = x.Count,
                RecipientPrice = x.Price
            }).ToList();
            
            var addProductToCartResponse = apiClient.AddProductToCartAsync(addProductsRequestData, sessionId)
                .GetAwaiter()
                .GetResult();

            if (addProductToCartResponse.Status != BrainStatusResponse.Success)
            {
                var error = $"Cannot add products to cart. Status: {addProductToCartResponse.Status}. Result: {addProductToCartResponse.Result}";
                result.AddError(error);
                _logger.LogError(nameof(RequestDropShippingAction), nameof(ExecuteAction), error);
               
                return result;
            }

            var novaPoshtaTargetId = FindNovaPoshtaTargetId(apiClient, sessionId, config);

            if (!novaPoshtaTargetId.HasValue)
            {
                var error = $"Cannot add find NovaPoshta region in Brain targets. Tried to find target region name [{config.TargetRegionName}]";
                result.AddError(error);
                _logger.LogError(nameof(RequestDropShippingAction), nameof(ExecuteAction), error);
               
                return result;
            }
            
            var addRecipientResponse = apiClient.AddRecipientAsync(new AddRecipientRequest()
            {
                Email = deliveryInfo.Email,
                DeliveryType = deliveryInfo.DeliveryType,
                FullName = deliveryInfo.FullName,
                PhoneNumber = deliveryInfo.PhoneNumber,
                RecipientType = deliveryInfo.RecipientType,
                TargetId = novaPoshtaTargetId.Value,
                DeliveryServiceCode = deliveryInfo.DeliveryServiceCode
            }, sessionId).GetAwaiter().GetResult();

            if (addRecipientResponse.Status != BrainStatusResponse.Success)
            {
                var error = $"Cannot create recipient. Status: {addRecipientResponse.Status}.";
                result.AddError(error);
                _logger.LogError(nameof(RequestDropShippingAction), nameof(ExecuteAction), error);
               
                return result;
            }

            var putOrderResponse = apiClient.PutOrderAsync(new PutOrderRequest
            {
                Currency = deliveryInfo.Currency,
                AddressId = addRecipientResponse.AddressId,
                TargetId = deliveryInfo.TargetId,
                ClientId = addRecipientResponse.RecipientId
            }, sessionId).GetAwaiter().GetResult();
            
            if (putOrderResponse.Status != BrainStatusResponse.Success)
            {
                var error = $"Cannot create external order. Status: {putOrderResponse.Status}.";
                result.AddError(error);
                _logger.LogError(nameof(RequestDropShippingAction), nameof(ExecuteAction), error);
               
                return result;
            }
            
            var shipOrderResponse = apiClient.ShipOrderToDropAsync(putOrderResponse.Result.OrderId, sessionId).GetAwaiter().GetResult();
            
            if (shipOrderResponse.Status != BrainStatusResponse.Success)
            {
                var error = $"Cannot ship order. Status: {shipOrderResponse.Status}.";
                result.AddError(error);
                _logger.LogError(nameof(RequestDropShippingAction), nameof(ExecuteAction), error);
               
                return result;
            }
            
            result.AddResultData(new DropShippingActionResultData
            {
                ExternalAddressId = addRecipientResponse.AddressId,
                ExternalOrderId = putOrderResponse.Result.OrderId,
                ExternalRecipientId = addRecipientResponse.RecipientId
            });
            
            result.AddInfo($"Finish executing {nameof(RequestDropShippingAction)}");
            
            return result;
        }

        private static int? FindNovaPoshtaTargetId(BrainApiClient apiClient, string sessionId,
            BrainSupplierDropShippingConfig config)
        {
            var allTargets = apiClient.GetTargetsAsync(sessionId).GetAwaiter().GetResult();
            var novaPoshtaTarget = allTargets.Result.FirstOrDefault(x => x.Region == config.TargetRegionName);

            return novaPoshtaTarget?.TargetId;
        }

        private static BrainSupplierDeliveryInfo FindDeliveryInfo(BapDynamicVariable[] actionArguments)
        {
            return actionArguments
                .FirstOrDefault(x => x.Key == BapSupplierVariableKey.DeliveryInfo)
                ?.Value as BrainSupplierDeliveryInfo;
        }

        private static List<ShoppingCartProduct> FindShoppingCartProducts(BapDynamicVariable[] actionArguments)
        {
            return actionArguments
                .FirstOrDefault(x => x.Key == BapSupplierVariableKey.ShoppingCartProducts)
                ?.Value as List<ShoppingCartProduct>;
        }

        private bool ValidateActionArguments(BrainSupplierDeliveryInfo deliveryInfo, SupplierExecutionResult result,
            List<ShoppingCartProduct> products)
        {
            var validationResult = false;

            if (deliveryInfo == null)
            {
                var error = "No delivery info";
                result.AddError(error);
                _logger.LogError(nameof(RequestDropShippingAction), nameof(ExecuteAction), error);

                validationResult = true;
            }

            if (products == null || products.Count == 0)
            {
                var error = "No products to add to cart. Exit from execution.";
                result.AddError(error);
                _logger.LogError(nameof(RequestDropShippingAction), nameof(ExecuteAction), error);

                validationResult = true;
            }

            return validationResult;
        }
    }
}