using System;
using System.Net;
using System.Linq;
using System.Web.Mvc;

using BAP.Common;
using BAP.Email;
using BAP.Log;
using BAP.Web.Models;
using BAP.UI.Controllers;
using BAP.DAL.Entities;
using BAP.Lookups;
using BAP.DAL;
using BAP.FileSystem;
using BAP.BL;
using BAP.ContentManagement;
using System.Web;

namespace BAP.Web.Controllers
{    
    public class HomeController : BaseController<Organization>, IContentExtendable
    {        
        IOrganizationBL _obl;

        public HomeController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IMailer mailer, IAuthorizationContext context, IFileProcessor fileProcessor) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<Organization>(configHelper, context), mailer, fileProcessor)
        {
            _obl = (IOrganizationBL)_bl;
        }
        		
		[AllowAnonymous]
		[HttpPost]		
		public ActionResult RegisterSubscriber(SubscribeEmailModel message)
		{
			try
			{
				var org = _authContext.GetCurrentOrganization(_configHelper);
				ValidateReCaptcha(message.RecaptchaResponse);
				var publicId = _bl.RegisterNewsletterSubscriber(message.Email);

				_mailer.SendEmail(string.Empty, message.Email, "News letters from " + org.Name, "<h3>Hello!</h3><br/><p>This is confirmation email that you registered with " + org.Name + " in order to receive news. You'll be receiving them shortly.</p><br/><h4>Thanks and regards,<br/>" + org.Name + " team.</h4><small>P.S. If you received this email by mistake and wish not receive any news from us please follow this link " + Request.Url.Scheme + "://" + Request.Url.Authority + "/Subscribers/unsubscribe?publicId=" + publicId + "(copy and paste into browser's address bar).</small>", true);
				_mailer.SendEmail(org.BapDefaultFromEmail, org.BapDefaultContactEmail, "Newsletter subscription added", "New user registered to receive our newletter: " + message.Email + ". Please take action ASAP.\r\nBest regard,\r\nSystem administrator.");
			}
			catch (Exception exc)
			{
				_logger.LogException(@"Home", @"RegisterSubscriber", exc);
				
			}
			return RedirectToAction("Index"); ;
		}

		[AllowAnonymous]		
		public ActionResult Unsubscribe(string publicId)
		{
			if (string.IsNullOrEmpty(publicId))
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			
			try
			{
				_bl.UnsubscribeNewsLetter(publicId);
			}
			catch (Exception exc)
			{
				_logger.LogException(@"Home", @"Unsubscribe", exc);
			}				
						
			return RedirectToAction("Index");
		}

		public ActionResult ServicesList()
        {
            var model = new HomeData { Services = ((IOrganizationServiceBL)_bl).GetAllOrganizationServices().ToList() };
            return View(model);
        }

        public ActionResult Index()
        {
            var model = new HomeData { Services = ((IOrganizationServiceBL)_bl).GetAllOrganizationServices().ToList() };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "About us.";            
            return View();
        }

        public ActionResult Contact(string subject = null)
        {
            ViewBag.Message = "Our contacts.";          
            return View(new HomeData { ContactSubject = subject });
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Our services.";
            var model = new HomeData { Services = ((IOrganizationServiceBL)_bl).GetAllOrganizationServices().ToList() };
            return View(model);
        }

        public ActionResult Products()
        {
            ViewBag.Message = "Our products.";            
            return View();
        }

        public ActionResult Pricing()
        {
            ViewBag.Message = "Our pricing model.";            
            return View();
        }

        public ActionResult PrivacyPolicy()
        {         
            return View();
        }

        [AllowAnonymous]
        public ActionResult CookiesNotice()
        {
            bool showBanner = true;
            if (Request.Cookies["cookiesconfirmed"] != null && Request.Cookies["cookiesconfirmed"].Value == "true")
            {
                showBanner = false;
            }
            else if (_authContext == null || _authContext.GetCurrentOrganization(_configHelper) == null || !_authContext.GetCurrentOrganization(_configHelper).CookiesPopupEnabled)
            {
                showBanner = false;
            }

            if (showBanner)
                TempData["CookiesBannerShown"] = true;

            return PartialView(showBanner);
        }

        [HttpPost]
        [AllowAnonymous]
        public void ConfirmCookies(string returnUrl)
        {
            var cookie = new HttpCookie("cookiesconfirmed", "true");
            cookie.Expires = DateTime.Now.AddYears(1);
            Response.SetCookie(cookie);
            Response.Redirect(returnUrl);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ((System.IDisposable)_bl).Dispose();
            }
            base.Dispose(disposing);
        }        
    }
}