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
    public class SalesOrderDeliveryDeclined : BaseWorkflowAction, IEntityWorkflowAction<CustomerOrder>
    {
        
        public string AttrNotes = "Delivery Decline Notes";

        public bool RequireCustomAttributes => true;
        public string AttributesExampleJson 
        { 
            get 
            {
                List<ActionAttribute<CustomerOrder>> example = new List<ActionAttribute<CustomerOrder>>();
                
                example.Add(new ActionAttribute<CustomerOrder>
                {
                    Name = AttrNotes,
                    ShortDescription = "Extra notes about delivery declined.",
                    AttributeDirection = AttributeDirection.Input,
                    AttributeType = AttributeType.Text,
                    IsPublic = true,
                    IsVisible = true,
                    UniqueId = Guid.NewGuid().ToString()
                });
                return JsonConvert.SerializeObject(example);
            } 
        }


        public SalesOrderDeliveryDeclined(ILookupEngine lookupEngine, IFileProcessor fileProc, IConfigHelper configHelper, IAuthorizationContext context, ILogger logger) : base(lookupEngine, fileProc, configHelper, context, logger)
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
                result.Messages.Add("This action requires number of attributes provided.");
                return result;
            }

            try
            {
                using (var bl = new eCommerceBusinessLayer(_lookupEngine, _fileProcessor, _configHelper, _authContext, _logger))
                {
                    var order = (CustomerOrder)entity;
                    order.ShipmentDeclined = true;
                    order.ShipmentDeclinedAt = DateTime.Now;
                    order.Notes += (!string.IsNullOrEmpty(order.Notes) ? "\r\n" : "") + actionAttributes.SingleOrDefault(a => a.Name == AttrNotes).Value;                    
                    bl.UpdateCustomerOrder(order);
                    result.Success = true;
                    _logger.LogDebug("Workflow.Action", "SalesOrderDeliveryDeclined", $"Sales order #{order.Id} was declined.");
                }
                
            }
            catch (Exception exc)
            {
                _logger.LogException("Workflows", "SalesOrderDeliveryDeclined", exc);
                result.Messages.Add($"Error occured during procesing action: {exc.Message}. See log for more details.");
            }

            return result;
        }
    }
}
