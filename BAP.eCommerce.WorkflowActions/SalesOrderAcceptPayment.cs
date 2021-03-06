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
    public class SalesOrderAcceptPayment : BaseWorkflowAction, IEntityWorkflowAction<CustomerOrder>
    {
        public string AttrReferenceId => "ReferenceId";
        public string AttrTotalPaid => "TotalPaid";
        public string AttrNotes = "Notes";

        public bool RequireCustomAttributes => true;
        public string AttributesExampleJson 
        { 
            get 
            {
                List<ActionAttribute<CustomerOrder>> example = new List<ActionAttribute<CustomerOrder>>();
                example.Add(new ActionAttribute<CustomerOrder>
                {
                    Name = AttrReferenceId,
                    ShortDescription = "Payment reference Id, returned by the gateway.",
                    AttributeDirection = AttributeDirection.Input,
                    AttributeType = AttributeType.Text,
                    IsPublic = true,
                    IsVisible = true,                    
                    UniqueId = Guid.NewGuid().ToString()
                });

                example.Add(new ActionAttribute<CustomerOrder>
                {
                    Name = AttrTotalPaid,
                    ShortDescription = "Total paid for the order.",
                    AttributeDirection = AttributeDirection.Input,
                    AttributeType = AttributeType.Currency,
                    IsPublic = true,
                    IsVisible = true,
                    UniqueId = Guid.NewGuid().ToString()
                });

                example.Add(new ActionAttribute<CustomerOrder>
                {
                    Name = AttrNotes,
                    ShortDescription = "Extra notes about payment processed.",
                    AttributeDirection = AttributeDirection.Input,
                    AttributeType = AttributeType.Text,
                    IsPublic = true,
                    IsVisible = true,
                    UniqueId = Guid.NewGuid().ToString()
                });
                return JsonConvert.SerializeObject(example);
            } 
        }


        public SalesOrderAcceptPayment(ILookupEngine lookupEngine, IFileProcessor fileProc, IConfigHelper configHelper, IAuthorizationContext context, ILogger logger) : base(lookupEngine, fileProc, configHelper, context, logger)
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
                    decimal totalPaid = 0;
                    decimal.TryParse(actionAttributes.SingleOrDefault(a => a.Name == AttrTotalPaid).Value, out totalPaid);
                    var orderPayment = new CustomerOrderPayment
                    {
                        AttemptNo = 1,
                        CurrencyId = order.CurrencyId,
                        CustomerOrderId = order.Id,
                        CustomerPaymentId = order.CustomerPaymentId,
                        IsError = false,
                        Started = DateTime.Now,
                        Finished = DateTime.Now,
                        PaymentIntent = PaymentIntent.order,
                        PaymentOptionId = order.PaymentOptionId,
                        PaymentStatus = PaymentStatus.approved ,
                        ReferenceId = actionAttributes.SingleOrDefault(a => a.Name == AttrReferenceId).Value,
                        Total = totalPaid,
                        PaymentNotes = actionAttributes.SingleOrDefault(a => a.Name == AttrNotes).Value
                    };
                    bl.AddCustomerOrderPayment(orderPayment);
                    bl.SoftwareProductsPaid(order.Id);
                    result.Success = true;
                    _logger.LogDebug("Workflow.Action", "SalesOrderAccepPayment", $"Payment for sales order #{order.Id} accepted successfully.");
                }
                
            }
            catch (Exception exc)
            {
                _logger.LogException("Workflows", "SalesOrderAcceptPayment", exc);
                result.Messages.Add($"Error occured during procesing action: {exc.Message}. See log for more details.");
            }

            return result;
        }
    }
}
