using System;
using System.Web.Http;

using BAP.BL;
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
    public class DesignPageSettingsController : ApiController
    {
        protected readonly BusinessLayer _bl = null;
        protected readonly IFileProcessor _fileProcessor = null;        
        protected readonly ILogger _logger;
        protected readonly IConfigHelper _configHelper;
        protected readonly IAuthorizationContext _context;

        public DesignPageSettingsController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) : base()
        {
            _logger = logger;
            _fileProcessor = fileProc;
            _configHelper = configHelper;
            _context = context;
            _bl = new BusinessLayer(configHelper, context, lookupEngine, logger);            
        }        

        [HttpPut]           
        public UpdateNodeSettingsResponse UpdateNodeSettings([FromBody]UpdateNodeSettingsRequest request)
        {
            try
            {
                using (var _cmsEngine = new CMSEngine(_configHelper, _context, _logger))
                {
                    _cmsEngine.UpdateNodeSettings(request.nodeId, request.viewId, request.pageTab, request.designGroup, request.settingsPane, request.controlUsed, request.showDesignPane);
                }                    
            }
            catch(Exception exc)
            {
                _logger.LogException("DesignPageSettingsController", "PUT", exc);
                return new UpdateNodeSettingsResponse
                {
                    Success = false,
                    ErrorMessage = "Failed to process update settings request."
                };
            }
            return new UpdateNodeSettingsResponse {
                Success = true
            };
        }

        //Need to add AddControl here

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(_bl != null)
                    _bl.Dispose();
            }
            base.Dispose(disposing);
        }
    }    
}