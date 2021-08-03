using System.Web.Mvc;
using BAP.BL.AspNetIdentity;
using BAP.Log;
using BAP.Common;
using BAP.Lookups;
using BAP.DAL;
using Microsoft.AspNet.Identity;
using BAP.BL.Registration;

namespace BAP.Web.Areas.eCommerce.Controllers
{
    [Authorize]
    [ContentManagement(allowed: false)]
    public class AccountController : Web.Controllers.AccountController
    {
        public AccountController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context, IRegistrationHelper regHelper) :
           base(logger, configHelper, lookupEngine, context, regHelper)
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context, IRegistrationHelper regHelper) :
            base(userManager, signInManager, logger, configHelper, lookupEngine, context, regHelper)
        {
        }

        protected override ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "eShop", new { Area = "eCommerce" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "eShop", new { Area = "eCommerce" });
        }
    }
}