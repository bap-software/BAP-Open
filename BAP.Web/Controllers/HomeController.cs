using System;
using System.Linq;
using System.Web.Mvc;

using BAP.Common;
using BAP.Lookups;
using BAP.Log;
using BAP.UI.Controllers;
using BAP.DAL;
using BAP.Email;
using BAP.DAL.Entities;
using BAP.FileSystem;
using BAP.ContentManagement;
using BAP.BL;
using BAP.Web.Models;

namespace BAP.Web.Controllers
{     
    public class HomeController : BaseController<Organization>, IContentExtendable
    {                
        public HomeController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IMailer mailer, IAuthorizationContext context, IFileProcessor fileProcessor) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<Organization>(configHelper, context), mailer, fileProcessor)
        {                        
        }        
        
        public ActionResult Index()
        {
            var model = new HomeData { Services = ((IOrganizationServiceBL)_bl).GetAllOrganizationServices().ToList() };
            return View(model);
        }                               		        
    }
}