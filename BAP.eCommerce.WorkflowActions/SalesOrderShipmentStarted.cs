using System;
using System.Linq;
using System.Collections.Generic;

using Newtonsoft.Json;

using BAP.Common;
using BAP.Workflow;
using BAP.Lookups;
using BAP.FileSystem;
using BAP.DAL;
using BAP.Log;
using BAP.eCommerce.BL;
using BAP.eCommerce.DAL.Entities;

namespace BAP.eCommerce.WorkflowActions
{
    public class SalesOrderShipmentStarted : BaseWorkflowAction, IEntityWorkflowAction<CustomerOrder>
    {
        public string AttrShippingReferenceId => "ShippingReferenceId";        

        public bool RequireCustomAttributes => true;
        public string AttributesExampleJson 
        { 
            get 
            {
                List<ActionAttribute<CustomerOrder>> example = new List<ActionAttribute<CustomerOrder>>();
                example.Add(new ActionAttribute<CustomerOrder>
                {
                    Name = AttrShippingReferenceId,
                    ShortDescription = "Shipment reference Id, returned by the shipping company.",
                    AttributeDirection = AttributeDirection.Input,
                    AttributeType = AttributeType.Text,
                    IsPublic = true,
                    IsVisible = true,                    
                    UniqueId = Guid.NewGuid().ToString()
                });
                
                return JsonConvert.SerializeObject(example);
            } 
        }


        public SalesOrderShipmentStarted(ILookupEngine lookupEngine, IFileProcessor fileProc, IConfigHelper configHelper, IAuthorizationContext context, ILogger logger) : base(lookupEngine, fileProc, configHelper, context, logger)
        {
        }

        
        public ExecutionResult Execute(IBapEntity entity, List<ActionAttribute<CustomerOrder>> actionAttributes)
        {
            var result = new ExecutionResult
            {
                Success = false,
                Messages = new List<string>()
            };

            if (entity == null)
            {
                result.Messages.Add("Entity instance has to be provided.");
                return result;
            }

            if (!(entity is CustomerOrder))
            {
                result.Messages.Add("This action supposed to work with CustomerOrder entity.");
                return result;
            }

            if(actionAttributes == null || !actionAttributes.Any())
            {
                result.Messages.Add("This action requires shipping reference id attributes provided.");
                return result;
            }

            try
            {
                using (var bl = new eCommerceBusinessLayer(_lookupEngine, _fileProcessor, _configHelper, _authContext, _logger))
                {
                    var order = (CustomerOrder)entity;
                    order.ShippingReferenceId = actionAttributes.SingleOrDefault(a => a.Name == AttrShippingReferenceId).Value;
                    order.ShipmentInitiatedAt = DateTime.Now;
                    bl.UpdateCustomerOrder(order);
                    result.Success = true;
                    _logger.LogDebug("Workflow.Action", "SalesOrderShipmentStarted", $"Shipment for sales order #{order.Id} started successfully.");
                }
                
            }
            catch (Exception exc)
            {
                _logger.LogException("Workflows", "SalesOrderShipmentStarted", exc);
                result.Messages.Add($"Error occured during procesing action: {exc.Message}. See log for more details.");
            }

            return result;
        }
    }
}
