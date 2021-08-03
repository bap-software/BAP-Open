using System;
using System.Web.Http;
using System.Reflection;
using System.Linq;

using BAP.DAL;
using BAP.Log;
using BAP.Lookups;
using BAP.Common;
using BAP.FileSystem;
using BAP.ContentManagement;
using BAP.Web.WebAPI.Contracts;

namespace BAP.Web.WebAPI
{
    [Authorize]    
    public class EditActionParametersValuesController : BaseCmsController
    {
        public EditActionParametersValuesController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) 
            : base(logger, configHelper, fileProc, lookupEngine, context)
        {
                 
        }        
       
        [HttpGet]
        public GetActionPrametersValuesResponse Get(int nodeId)
        {            
            //Get current node instance
            var assemblies = GetAssembliesToScan();
            CMSNode cmsNode = null;
            using (var _cmsEngine = new CMSEngine(_configHelper, _context, _logger))
            {
                cmsNode = _cmsEngine.GetSingleNodeById(nodeId, assemblies);
            }                
            if (cmsNode == null || cmsNode.Content == null || string.IsNullOrEmpty(cmsNode.Content.Action))
                return new GetActionPrametersValuesResponse { ContentNodeId = nodeId, Success = false, ErrorMessage = "Could not find appropriate action for the given content node - invalid input parameters." };

            //If values are present - return them to edit (will need to put validation of them later)
            if (!string.IsNullOrEmpty(cmsNode.Content.ActionParams))
                return new GetActionPrametersValuesResponse { ContentNodeId = nodeId, Success = true, ParametersValuesJson = cmsNode.Content.ActionParams };

            //No values are available - generate template
            Type controllerClassType = null;
            if (cmsNode.ThisController != null && cmsNode.ThisController.ControllerClassType != null)
                controllerClassType = cmsNode.ThisController.ControllerClassType;

            if (controllerClassType == null)
            {
                foreach(var asmb in assemblies)
                {
                    foreach(var tp in asmb.GetTypes())
                    {
                        if(tp.Name == cmsNode.Content.Controller + "Controller")
                        {
                            controllerClassType = tp;
                            break;
                        }
                    }
                }
            }

            var result = new GetActionPrametersValuesResponse
            {
                Success = true,
                ContentNodeId = nodeId
            };

            MethodInfo action = null;
            var actions = controllerClassType.GetMethods();
            foreach(var act in actions)
            {
                if(act.Name == cmsNode.Content.Action 
                    && !act.CustomAttributes.Any(a => a.AttributeType == typeof(HttpPostAttribute))
                    && !act.CustomAttributes.Any(a => a.AttributeType == typeof(HttpPutAttribute))
                    && !act.CustomAttributes.Any(a => a.AttributeType == typeof(HttpPatchAttribute))
                    )
                {
                    action = act;
                    break;
                }
            }
            try
            {
                if (action == null)
                    action = controllerClassType.GetMethod(cmsNode.Content.Action);
            }
            catch (Exception){ }

            if (action != null)
            {
                var actionParams = action.GetParameters();
                var resultJson = "";
                if(actionParams != null && actionParams.Any())
                {
                    foreach(var p in actionParams)
                    {
                        if (!string.IsNullOrEmpty(resultJson))
                            resultJson += ",";
                        //resultJson += $"\"{p.Name}\":{{\"Type\":\"{p.ParameterType.Name}\",\"DefaultValue\":\"{p.DefaultValue}\"}}";
                        resultJson += $"\"{p.Name}\":\"{p.DefaultValue}\"";
                    }
                }
                result.ParametersValuesJson = $"{{{resultJson}}}";
            }

            return result;
        }

        [HttpPut]           
        public UpdateActionPrametersValuesResponse Put([FromBody]UpdateActionPrametersValuesRequest request)
        {
            try
            {
                var assemblies = GetAssembliesToScan();               
                using (var _cmsEngine = new CMSEngine(_configHelper, _context, _logger))
                {
                    var cmsNode = _cmsEngine.GetSingleNodeById(request.NodeId, assemblies);
                    _cmsEngine.UpdateNodeActionParametersValues(cmsNode.Content, request.ActionParametersJson);

                }
            }
            catch(Exception exc)
            {
                _logger.LogException("DesignPageSettingsController", "PUT", exc);
                return new UpdateActionPrametersValuesResponse
                {
                    Success = false,
                    ErrorMessage = "Failed to process update settings request."
                };
            }
            return new UpdateActionPrametersValuesResponse
            {
                Success = true
            };
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_bl != null)
                    _bl.Dispose();
            }
            base.Dispose(disposing);
        }
    }    
}