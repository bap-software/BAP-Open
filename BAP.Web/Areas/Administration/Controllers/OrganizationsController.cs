using System.Net;
using System.Web.Mvc;

using BAP.Common;
using BAP.BL;
using BAP.DAL.Entities;
using BAP.Lookups;
using BAP.Log;
using BAP.DAL;
using BAP.FileSystem;
using BAP.UI.Controllers;
using System.Linq;
using System.Threading.Tasks;

namespace BAP.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = @"Administrator")]
    public class OrganizationsController : BaseController<Organization>
    {        
        public OrganizationsController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<Organization>(configHelper, context))
        {            
        }
        

        // GET: Organizations
        public ActionResult Index()
        {            
            return RedirectToAction("Details", new { id = _authHelper.GetCurrentOrganizationId() });
        }

        // GET: Organizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = _bl.GetOrganizationById(id.Value);
            if (organization == null)
            {
                return HttpNotFound();
            }
            if (TempData["CurrentTab"] != null)
            {
                ViewBag.CurrentTab = TempData["CurrentTab"].ToString();
            }
            ViewBag.UserId = new SelectList(((IOrganizationUserBL)_bl).GetAllOrganizationUsers(), "Id", "FullName");
            ViewBag.SubscriptionId = new SelectList(((ISubscriptionBL)_bl).GetAllSubscriptions(), "Id", "UserTermRange");
            ViewBag.CurrentOrganization = _bl.CurrentOrganzation();
            ViewBag.CurrentUserId = _authHelper.GetCurrentUserId();
            ViewBag.ModuleId = new SelectList(((IModuleBL)_bl).GetAllModules().Where(a => a.Enabled).ToList(), "Id", "Name");
            return View(organization);
        }        

        // GET: Organizations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = _bl.GetOrganizationById(id.Value);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Organizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,TaxId,Status,StatusDate,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OrganizationType,AddressLine1,AddressLine2,City,County,State,Country,Zip,PhoneNumber,PhoneExtension,FaxNumber,OwnerGroup,OwnerPermissions,LogoPathUrl,FacebookUrl,TwitterUrl,LinkedinUrl,GoogleplusUrl,InstagramUrl,BlogUrl,Url,ContactEmail,SupportEmail,ImplementedCulturesText,HostName,HostNameAliasesText,BapDefaultFromEmail,BapDefaultContactEmail,SmtpUserName,SmtpUserPassword,SmtpHostName,SmtpPort,SmtpUseSsl,reCaptchaSiteKey,reCaptchaSecretKey,GetBearrerTokenDuringLogin,AuthCookieName,AuthCookieExpirationTime,WebApiPublicClientId,BearerTokenExpirationTime,WebApiAllowInsecureHttp,PublicFolderText,BaseFolderText,CookiesPopupEnabled,GdprPopupEnabled")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                if (_fileProcessor != null)
                {
                    var path = _fileProcessor.SaveAttachmentFile("Organization", organization.Id, organization.LogoFile);
                    if (!string.IsNullOrEmpty(path))
                        organization.LogoPathUrl = path;
                }

                _bl.UpdateOrganization(organization);
                return RedirectToAction("Index");
            }
            return View(organization);
        }

        public ActionResult AddOrganizationModule(int id, int moduleId)
        {
            Organization organization = _bl.GetOrganizationById(id);
            Module module = ((IModuleBL)_bl).GetModuleById(moduleId);
            if (organization == null)
            {
                return HttpNotFound();
            }
            _bl.AddOrganizationModule(organization, module);
            TempData["CurrentTab"] = "modules";
            return RedirectToAction("Details", new { id = id });
        }

        [HttpPost]
        public ActionResult EditOrganizationModule(OrganizationModule model)
        {
            if(ModelState.IsValid)
            {
                _bl.UpdateOrganizationModule(model);
                TempData["CurrentTab"] = "modules";
                return RedirectToAction("Details", new { id = model.OrganizationId });
            }
            return View(model);
        }

        public ActionResult RemoveOrganizationModule(int id, int organizationId)
        {            
            
            _bl.RemoveOrganizationModule(id);
            TempData["CurrentTab"] = "modules";
            return RedirectToAction("Details", new { id = organizationId });
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
