using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

using BAP.Web.Models;
using BAP.BL.AspNetIdentity;
using BAP.BL.Registration;
using BAP.UI.Controllers;
using BAP.DAL.Entities;
using BAP.Log;
using BAP.Common;
using BAP.Lookups;
using BAP.DAL;
using BAP.Common.Registration;
using BAP.Common.Exceptions;
using System;

namespace BAP.Web.Controllers
{
    [Authorize]
    [ContentManagement(allowed: false)]
    public class AccountController : BaseController<OrganizationUser>
    {
        private readonly string _userRegistratorTypeName = "UserRegistrator";

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private IRegistrationHelper _regHelper;

        public AccountController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context, IRegistrationHelper regHelper) :
           base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<OrganizationUser>(configHelper, context))
        {
            _regHelper = regHelper;
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context, IRegistrationHelper regHelper) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<OrganizationUser>(configHelper, context))
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _regHelper = regHelper;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult SignUp(string returnUrl, string view = "")
        {
            ViewBag.ReturnUrl = returnUrl;

            if (string.IsNullOrEmpty(view))
                return View();
            else
                return View(view);
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl, string view = "")
        {
            ViewBag.ReturnUrl = returnUrl;
            if (string.IsNullOrEmpty(view))
                return View();
            else
                return View(view);
        }

        //
        // GET: /Account/LoginHeader
        [AllowAnonymous]
        public ActionResult LoginHeader(string view = "")
        {
            if (string.IsNullOrEmpty(view))
                return View();
            else
                return View(view);
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl, string view = "")
        {
            if (!ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(view))
                    return View(model);
                else
                    return View(view, model);
            }

            // Require the user to have a confirmed email before they can log on.
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user != null)
            {
                if (!await UserManager.IsEmailConfirmedAsync(user.Id))
                {
                    ViewBag.errorMessage = "You must have a confirmed email to log on.";
                    return View("Error");
                }
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    _authContext.RequestBearrerToken(model.Email, model.Password);
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe, view = view });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    if (string.IsNullOrEmpty(view))
                        return View(model);
                    else
                        return View(view, model);
            }
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe, string view = "")
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            if (string.IsNullOrEmpty(view))
                view = "VerifyCode";

            return View(view, new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model, string view = "")
        {
            if (string.IsNullOrEmpty(view))
                view = "VerifyCode";

            if (!ModelState.IsValid)
            {
                return View(view, model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(view, model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register(string returnUrl, string view = "")
        {
            if (string.IsNullOrEmpty(view))
                view = "Register";
            ViewBag.ReturnUrl = returnUrl;
            return View(view);
        }

        //
        // GET: /Account/RegisterHeader
        [AllowAnonymous]
        public ActionResult RegisterHeader(string view = "")
        {
            if (string.IsNullOrEmpty(view))
                view = "RegisterHeader";
            return View(view);
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model, string returnUrl, string view = "")
        {
            if (string.IsNullOrEmpty(view))
                view = "Register";

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //Register user within a system
                    var regEngine = _regHelper.GetRegistrationEngine(_userRegistratorTypeName);
                    var regModel = new RegistrationModel
                    {
                        AspNetUserId = user.Id,
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        RegistrationType = "reg-user",
                        SubscriptionTerm = "term-annual"
                    };
                    RegistrationResponse response = regEngine.Register(regModel);

                    //Assign registered user to default "User" role
                    if (response != null)
                    {
                        if (response.Success)
                        {
                            foreach (var role in response.UserRoles)
                            {
                                UserManager.AddToRole(user.Id, role);
                            }
                        }
                        else
                        {
                            if (response.Exception != null)
                                throw new BAPRegistrationException("Exception registering new user or company", response.Exception);
                            else if (!string.IsNullOrEmpty(response.Message))
                                throw new BAPRegistrationException(string.Format("Error registering new user or company: {0}", response.Message));
                            else
                                throw new BAPRegistrationException("Unknown error registering new user or company");
                        }
                    }
                    else
                    {
                        throw new BAPRegistrationException("Unknown or unsupported registration type");
                    }

                    //Send confirmation email
                    string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code, returnUrl }, protocol: Request.Url.Scheme);
                    await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Dear Customer,<br/>Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    //Redirect to confirmation view
                    return RedirectToAction("SentConfirmationEmail", "Account");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(view, model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult SentConfirmationEmail()
        {
            return View();
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code, string returnUrl)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            if (!string.IsNullOrEmpty(returnUrl))
                return RedirectToLocal(returnUrl);
            else
                return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    _logger.LogError("AccountController", "UserNotFount", "Attempt to restore password for the account which does not exist: " + model.Email);
                    ViewBag.errorMessage = string.Format(Resources.Resources.Account_UserWithEmail_NotRegistered, model.Email);
                    return View("Error");
                }

                string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult CookiesNotice()
        {
            bool showBanner = true;
            if(Request.Cookies["cookiesconfirmed"] != null && Request.Cookies["cookiesconfirmed"].Value == "true")
            {
                showBanner = false;
            }
            else if(_authContext == null || _authContext.GetCurrentOrganization(_configHelper) == null || !_authContext.GetCurrentOrganization(_configHelper).CookiesPopupEnabled)
            {
                showBanner = false;
            }

            if (showBanner)
                TempData["CookiesBannerShown"] = true;

            return PartialView(showBanner);
        }

        [AllowAnonymous]
        public ActionResult GdprNotice()
        {
            bool showBanner = true;
            if(TempData["CookiesBannerShown"] != null && (bool)TempData["CookiesBannerShown"])
            {
                showBanner = false;
            } 
            else if (Request.Cookies["gdprconfirmed"] != null && Request.Cookies["gdprconfirmed"].Value == "true")
            {
                showBanner = false;
            }
            else if (_authContext == null || _authContext.GetCurrentOrganization(_configHelper) == null || !_authContext.GetCurrentOrganization(_configHelper).GdprPopupEnabled)
            {
                showBanner = false;
            }

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

        [HttpPost]
        [AllowAnonymous]
        public void ConfirmGdpr(string returnUrl)
        {
            var cookie = new HttpCookie("gdprconfirmed", "true");
            cookie.Expires = DateTime.Now.AddYears(1);
            Response.SetCookie(cookie);
            Response.Redirect(returnUrl);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";        
        protected IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                if (error.ToLowerInvariant().Contains("password"))
                    ModelState.AddModelError("Password", error);
                else
                    ModelState.AddModelError(string.Empty, error);
            }
        }

        protected virtual ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}