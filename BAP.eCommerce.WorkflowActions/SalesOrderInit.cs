using System;
using System.Collections.Generic;

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
    public class SalesOrderInit : BaseWorkflowAction, IEntityWorkflowAction<CustomerOrder>
    {
        public SalesOrderInit(ILookupEngine lookupEngine, IFileProcessor fileProc, IConfigHelper configHelper, IAuthorizationContext context, ILogger logger) : base(lookupEngine, fileProc, configHelper, context, logger)
        {
        }

        public bool RequireCustomAttributes => false;

        public string AttributesExampleJson => null;

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

            try
            {
                using (var bl = new eCommerceBusinessLayer(_lookupEngine, _fileProcessor, _configHelper, _authContext, _logger))
                {
                    var order = (CustomerOrder)entity;
                    bl.GenerateInvoicePdf(order.Id);
                    bl.PrepareSoftwareProducts(order.Id);
                    result.Success = true;
                    _logger.LogDebug("Workflow.Action", "SalesOrderInit", $"Workflow for sales order #{order.Id} initiaized successfully.");
                }
                
            }
            catch (Exception exc)
            {
                _logger.LogException("Workflows", "SalesOrderInit", exc);
                result.Messages.Add($"Error occured during procesing action: {exc.Message}. See log for more details.");
            }

            return result;
        }
    }
}
