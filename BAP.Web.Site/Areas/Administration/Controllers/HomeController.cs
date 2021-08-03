using System.Web.Mvc;

using BAP.DAL;
using BAP.Log;
using BAP.Email;
using BAP.Lookups;
using BAP.FileSystem;
using BAP.DAL.Entities;
using BAP.UI.Controllers;

namespace BAP.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator,ContentManager,Supervisor")]
    public class HomeController : BaseController<Attachment>
    {
        public HomeController(ILogger logger, Common.IConfigHelper configHelper, ILookupEngine lookupEngine, IMailer mailer, IAuthorizationContext context, IFileProcessor fileProcessor) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<Attachment>(configHelper, context), mailer, fileProcessor)
        {
        }

        // GET: Administration/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}