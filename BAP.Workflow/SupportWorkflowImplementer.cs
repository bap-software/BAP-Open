using BAP.BL;
using BAP.Common;
using BAP.DAL;
using BAP.DAL.Entities;
using BAP.FileSystem;
using BAP.Log;
using BAP.Lookups;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAP.Workflow
{
    public class SupportWorkflowImplementer<T> : ISupportWorkflow<T> where T : class, IBapEntity
    {
        /// <summary>
        /// The bl instance
        /// </summary>
        protected readonly IWorkflowClassBL _bl;
        /// <summary>
        /// The configuration helper
        /// </summary>
        protected readonly IConfigHelper _configHelper;        
        /// <summary>
        /// The authentication context
        /// </summary>
        protected readonly IAuthorizationContext _authContext;
        /// <summary>
        /// The lookup engine
        /// </summary>
        protected readonly ILookupEngine _lookupEngine;
        /// <summary>
        /// The logger
        /// </summary>
        protected readonly ILogger _logger;
        /// <summary>
        /// The file processor
        /// </summary>
        protected readonly IFileProcessor _fileProcessor;

        public SupportWorkflowImplementer(ILogger logger, IConfigHelper configHelper, IAuthorizationContext authContext, ILookupEngine lookupEngine, IFileProcessor fileProcessor, IWorkflowClassBL bl)
        {
            _logger = logger;
            _configHelper = configHelper;
            _authContext = authContext;
            _lookupEngine = lookupEngine;
            _fileProcessor = fileProcessor;
            _bl = bl;
        }

        public bool ChooseTransition(Workflow<T> workflow, int metaTranstionId, string comment)
        {
            var workflowEngine = new WorkflowEngine<T>(_configHelper, _authContext, _logger, _lookupEngine, _fileProcessor, _bl);
            var result = workflowEngine.ChooseTransition(workflow, workflow.Transitions.SingleOrDefault(a => a.MetaId == metaTranstionId), comment);
            if (result)
                workflowEngine.SaveWorkflow(workflow);
            return result;
        }

        public Workflow<T> ChooseWorkflow(T entity, int workflowId)
        {
            var workflowEngine = new WorkflowEngine<T>(_configHelper, _authContext, _logger, _lookupEngine, _fileProcessor, _bl);
            var flows = workflowEngine.GetAvailableWorkflowClasses(entity);
            if (flows != null && flows.Any(a => a.Id == workflowId))
            {
                return workflowEngine.InitWorkflow(flows.SingleOrDefault(a => a.Id == workflowId), entity);
            }

            return null;
        }

        public void RemoveCurrentWorkflow(T entity)
        {
            var workflowEngine = new WorkflowEngine<T>(_configHelper, _authContext, _logger, _lookupEngine, _fileProcessor, _bl);
            workflowEngine.RemoveWorkflow(entity);
        }

        public string DoAction(Workflow<T> workflow, int metaActionId, string attributesJson)
        {
            string result = null;
            if (workflow == null)
                return result;

            var action = workflow.Actions.SingleOrDefault(a => a.MetaId == metaActionId);
            if (action == null)
                return result;

            var workflowEngine = new WorkflowEngine<T>(_configHelper, _authContext, _logger, _lookupEngine, _fileProcessor, _bl);

            if (!string.IsNullOrEmpty(attributesJson) && action.Attributes != null && action.Attributes.Any(a => a.AttributeDirection == AttributeDirection.Input || a.AttributeDirection == AttributeDirection.Both))
            {
                var jobject = JObject.Parse(attributesJson);
                if (jobject != null)
                {
                    foreach (var val in jobject)
                    {
                        if (action.Attributes.Any(a => a.Name == val.Key))
                        {
                            var attr = action.Attributes.SingleOrDefault(a => a.Name == val.Key);
                            if (attr != null)
                            {
                                attr.Value = val.Value.ToString();
                            }
                        }
                    }
                }
            }

            if (workflowEngine.DoAction(action))
            {
                if (action.Attributes.Any(a => a.AttributeDirection == AttributeDirection.Output || a.AttributeDirection == AttributeDirection.Both))
                {
                    result = "{";
                    var first = true;
                    foreach (var attr in action.Attributes.Where(a => a.AttributeDirection == AttributeDirection.Output || a.AttributeDirection == AttributeDirection.Both))
                    {
                        if (!first)
                            result += ",";
                        result += $"\"{attr.Name}\"=" + (attr.AttributeType == AttributeType.Number ? attr.Value : $"\"{attr.Value}\"");
                        first = false;
                    }
                    result += "}";
                }
                else
                {
                    //just return new empty object as inducator of success
                    result = "{}";
                }
                workflowEngine.SaveWorkflow(workflow);
            }

            return result;
        }

        public List<WorkflowClass> GetAvailableFlows(T entity)
        {
            var workflowEngine = new WorkflowEngine<T>(_configHelper, _authContext, _logger, _lookupEngine, _fileProcessor, _bl);
            return workflowEngine.GetAvailableWorkflowClasses(entity);
        }

        public Workflow<T> GetCurrentWorkflow(T entity, int? metaId = null, int? attachmentId = null)
        {
            var workflowEngine = new WorkflowEngine<T>(_configHelper, _authContext, _logger, _lookupEngine, _fileProcessor, _bl);
            return workflowEngine.GetWorkflow(entity, metaId, attachmentId);
        }

        public void SaveWorkflow(Workflow<T> workflow)
        {
            var workflowEngine = new WorkflowEngine<T>(_configHelper, _authContext, _logger, _lookupEngine, _fileProcessor, _bl);
            workflowEngine.SaveWorkflow(workflow);
        }
    }
}
