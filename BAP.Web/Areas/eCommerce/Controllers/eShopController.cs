using System.Linq;
using System.Web.Mvc;

using BAP.Common;
using BAP.DAL;
using BAP.DAL.Entities;
using BAP.Email;
using BAP.FileSystem;
using BAP.Log;
using BAP.Lookups;
using BAP.ContentManagement;
using BAP.BL;
using BAP.eCommerce.UI.Controllers;
using BAP.eCommerce.BL;
using BAP.Web.Areas.eCommerce.Models;

namespace BAP.Web.Areas.eCommerce.Controllers
{	
	/*[Authorize]*/
    public class eShopController : BaseeCommerceController<Organization>, IContentExtendable
    {                
        public eShopController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IMailer mailer, IAuthorizationContext context, IFileProcessor fileProcessor) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<Organization>(configHelper, context), mailer, fileProcessor, new eCommerceBusinessLayer(lookupEngine, fileProcessor, configHelper, context, logger))
        {                        
        }

        public ActionResult Index()
        {
            _logger.LogText("Home", "Index", "Start");

            var homeModel = new HomePageModel();
            var orgSrvBL = (IOrganizationServiceBL)_bl;
            homeModel.OrgServices = new System.Collections.Generic.List<OrganizationService>();
            homeModel.OrgServices.AddRange(orgSrvBL.GetAllOrganizationServices().Where(a => a.Enabled));
            
            return View(homeModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult PhysicalTherapy()
        {
            return View();
        }

        public ActionResult Surfing()
        {
            return View();
        }

        public ActionResult AquaGym()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.AddressLine1 = _currentOrganization.AddressLine1;
            ViewBag.AddressLine2 = _currentOrganization.AddressLine2;
            ViewBag.PhoneNumber = _currentOrganization.PhoneNumber;
            ViewBag.SupportEmail = _currentOrganization.SupportEmail;
            ViewBag.ContactEmail = _currentOrganization.ContactEmail;
            
            return View();
        }     
    }
}