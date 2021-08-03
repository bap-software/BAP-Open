using System.Web.Mvc;
using System.Threading.Tasks;

using BAP.DAL;
using BAP.Common;
using BAP.DAL.Entities;
using BAP.eCommerce.BL;
using BAP.FileSystem;
using BAP.Lookups;
using BAP.Log;
using BAP.Web.Areas.eCommerce.Models;

namespace BAP.Web.Areas.eCommerce.Controllers
{
    [Authorize]
    public class ManageController : Web.Controllers.ManageController
    {
        private readonly eCommerceBusinessLayer _ebl;
        public ManageController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context, IFileProcessor fileProc) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<OrganizationUser>(configHelper, context))
        {
            _ebl = new eCommerceBusinessLayer(lookupEngine, fileProc, configHelper, context, logger);
        }

        public override async Task<ActionResult> Index(ManageMessageId? message)
        {
            var model = new ManageIndexModel { UserId = _authHelper.GetCurrentUserId() };
            var orgUser = await _ebl.GetOrganizationUserByAspNetIdAsync(model.UserId);
            if(orgUser != null)
            {
                var customer = await _ebl.GetCustomerByUserIdAsync(orgUser.Id);
                if(customer != null)
                {
                    model.CustomerId = customer.Id;
                }                
            }            
            return View(model);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _ebl?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}