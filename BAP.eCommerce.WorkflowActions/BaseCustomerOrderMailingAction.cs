using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

using Newtonsoft.Json;

using BAP.Common;
using BAP.Workflow;
using BAP.Lookups;
using BAP.FileSystem;
using BAP.DAL;
using BAP.Log;
using BAP.BL;
using BAP.Email;
using BAP.eCommerce.DAL.Entities;
using BAP.eCommerce.Resources;

namespace BAP.eCommerce.WorkflowActions
{
    public class BaseCustomerOrderMailingAction : BaseWorkflowAction, IEntityWorkflowAction<CustomerOrder>
    {
        protected const string _emailTemplateAttrName = "EmailTemplate";
        protected string _emailSubject = ResObject.EmailText_OrderSubject;
        public BaseCustomerOrderMailingAction(ILookupEngine lookupEngine, IFileProcessor fileProc, IConfigHelper configHelper, IAuthorizationContext context, ILogger logger) 
            : base(lookupEngine, fileProc, configHelper, context, logger)
        {
        }

        public virtual bool RequireCustomAttributes => true;
        public virtual string AttributesExampleJson
        {
            get
            {
                List<ActionAttribute<CustomerOrder>> example = new List<ActionAttribute<CustomerOrder>>();
                example.Add(new ActionAttribute<CustomerOrder>
                {
                    Name = _emailTemplateAttrName,
                    ShortDescription = "Name of the email document template to be used to send this type of email.",
                    AttributeDirection = AttributeDirection.Input,
                    AttributeType = AttributeType.Text,
                    IsPublic = true,
                    IsVisible = true,
                    UniqueId = Guid.NewGuid().ToString()
                });
                return JsonConvert.SerializeObject(example);
            }
        }

        public ExecutionResult Execute(IBapEntity entity, List<ActionAttribute<CustomerOrder>> actionAttributes)
        {
            var result = new ExecutionResult
            {
                Success = false,
                Messages = new List<string> ()
            };

            if (entity == null || actionAttributes == null || !actionAttributes.Any(a => a.Name == _emailTemplateAttrName))
            {
                result.Messages.Add("Invaid or missing input parameters.");
                return result;
            }

            if(!(entity is CustomerOrder))
            {
                result.Messages.Add("This action supposed to work with CustomerOrder entity.");
                return result;
            }
                
            using (var bl = new BusinessLayer(_configHelper, _authContext, _logger))
            {
                var mailer = DependencyResolver.Current.GetService<IMailer>();
                if(mailer == null)
                {
                    result.Messages.Add("Mailer cannot be null, it has to be properly configured.");
                    return result;
                }
                if(actionAttributes == null || !actionAttributes.Any(a => a.Name == _emailTemplateAttrName))
                {
                    result.Messages.Add($"Email template name is not specified as one of the action attributes. {_emailTemplateAttrName} action attribute is required with the valid name of the document template to use.");
                    return result;
                }

                try
                {
                    IDocumentTemplateBL tbl = bl;
                    var template = tbl.GetDocumentTemplateByName(actionAttributes.FirstOrDefault(a => a.Name == _emailTemplateAttrName).Value);
                    if (template != null)
                    {
                        var documentText = tbl.TransformTemplate(template.TemplateBody, entity, true);
                        var custOrder = (CustomerOrder)entity;
                        mailer.SendEmail(mailer.DefaultFromAddress, custOrder.Customer.Email, _emailSubject, documentText);
                        result.Success = true;
                        _logger.LogDebug("Workflow.Action", "BaseCustomerOrderMailingAction", $"Email has been sent for the  order #{custOrder.Id} using template {template.Name}.");
                    }
                    else
                    {
                        result.Messages.Add("Email tempate body coud not be found.");
                        return result;
                    }
                }
                catch(Exception exc)
                {
                    _logger.LogException("Workflows", "BaseCustomerOrderMailingAction", exc);
                    result.Messages.Add($"Error occured during procesing action: {exc.Message}. See log for more details.");
                }                                    
            }
            return result;
        }
    }
}
