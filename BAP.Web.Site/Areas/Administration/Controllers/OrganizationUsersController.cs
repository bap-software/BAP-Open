using System;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using BAP.Common;
using BAP.Lookups;
using BAP.Log;
using BAP.DAL.Entities;
using BAP.BL;
using BAP.DAL;
using BAP.UI.Controllers;
using BAP.BL.AspNetIdentity;

namespace BAP.Web.Areas.Administration.Controllers
{
    //Every controller is created with restricted access be default. Any public action has to be created explicitly.
    [Authorize(Roles = "Administrator")]
    public class OrganizationUsersController : BaseController<OrganizationUser>
    {
		private ApplicationUserManager _userManager;

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

        public OrganizationUsersController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<OrganizationUser>(configHelper, context))
        {            
        }

        // GET: OrganizationUsers
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {            
            int pageNumber = 1;
            int pageSize = _configHelper.FakeMaxPageSize;
            
            EntityPagingAttribute pageAttr = (EntityPagingAttribute)Attribute.GetCustomAttribute(typeof(OrganizationUser), typeof(EntityPagingAttribute));
            if (pageAttr != null && pageAttr.Applied && pageAttr.PageSize > 0)
            {                                
                pageSize = pageAttr.PageSize;
                pageNumber = (page ?? 1);
            }

            ViewBag.CurrentSort = sortOrder;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            ViewBag.SortData = InitSortData(ViewBag.CurrentSort);

            ViewBag.BL = _bl;
            return View(_bl.SearchOrganizationUsers(searchString, sortOrder, pageNumber, pageSize));
        }
        
        // GET: OrganizationUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationUser organizationUser = _bl.GetOrganizationUserById(id.Value);
            if (organizationUser == null)
            {
                return HttpNotFound();
            }
            InitAppUserData(organizationUser);
            
            return View(organizationUser);
        }

        private void InitAppUserData(OrganizationUser user)
        {
            if (user == null)
                return;

            var appUser = UserManager.FindById(user.AspNetUserId);
            if(appUser != null)
            {
                user.Email = appUser.Email;
                user.EmailConfirmed = appUser.EmailConfirmed;
                user.LockoutEnabled = appUser.LockoutEnabled;
                user.LockoutEndDateUtc = appUser.LockoutEndDateUtc;
                user.TwoFactorEnabled = appUser.TwoFactorEnabled;
                user.AccessFailedCount = appUser.AccessFailedCount;
            }

            if(!string.IsNullOrEmpty(user.AspNetUserId))
            {
                try
                {
                    var roles = UserManager.GetRoles(user.AspNetUserId);
                    if (roles != null)
                    {
                        user.Roles = roles.ToList();
                    }
                }
                catch(Exception)
                {
                    user.Roles = new List<string> { _authHelper.BapUserRoleName };
                }                
            }            
        }

        private void SaveAppUserData(OrganizationUser user)
        {
            var appUser = UserManager.FindById(user.AspNetUserId);
            if (appUser != null)
            {
                if(user.Email != appUser.Email || user.EmailConfirmed != appUser.EmailConfirmed || user.LockoutEnabled != appUser.LockoutEnabled || user.TwoFactorEnabled != appUser.TwoFactorEnabled || user.AccessFailedCount != appUser.AccessFailedCount || user.LockoutEndDateUtc != appUser.LockoutEndDateUtc)
                {
                    appUser.Email = user.Email;
                    appUser.EmailConfirmed = user.EmailConfirmed;
                    appUser.LockoutEnabled = user.LockoutEnabled;
                    appUser.LockoutEndDateUtc = user.LockoutEndDateUtc;
                    appUser.TwoFactorEnabled = user.TwoFactorEnabled;
                    appUser.AccessFailedCount = user.AccessFailedCount;

                    UserManager.Update(appUser);
                }
            }
            else
            {
                appUser = new ApplicationUser()
                {
                    Email = user.Email,
                    UserName = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    LockoutEnabled = user.LockoutEnabled,
                    TwoFactorEnabled = user.TwoFactorEnabled,
                    AccessFailedCount = 0
                };
                var result = UserManager.Create(appUser);
                if (result.Succeeded)
                    user.AspNetUserId = appUser.Id;
            }
        }

        // GET: OrganizationUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrganizationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,AspNetUserId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,FirstName,MiddleName,LastName,AddressLine1,AddressLine2,City,County,State,Country,Zip,PhoneNumber,CellNumber,TenantUnit,TenantUnitId,OwnerGroup,OwnerPermissions,CreatedByUserName,LastModifiedByUserName,Email,EmailConfirmed,TwoFactorEnabled,LockoutEnabled,LockoutEndDateUtc,AccessFailedCount,UserName")] OrganizationUser organizationUser)
        {
            if (ModelState.IsValid)
            {
                //Prepare data to save                
                var organization = ((AuthorizationHelper<Organization>)_authHelper).GetCurrentOrganization();
                organizationUser.Organization = organization;                
                organizationUser.EmailConfirmed = false;
                organizationUser.TwoFactorEnabled = false;
                organizationUser.LockoutEnabled = true;

                //Save to both identity subsytem and database
                SaveAppUserData(organizationUser);
                _bl.AddOrganizationUser(organizationUser);

                //Adding to User role initially only
                UserManager.AddToRole(organizationUser.AspNetUserId, _authHelper.BapUserRoleName);

                //Send confirmation email
                string confirmationCode = await UserManager.GenerateEmailConfirmationTokenAsync(organizationUser.AspNetUserId);
                string passwordCode = await UserManager.GeneratePasswordResetTokenAsync(organizationUser.AspNetUserId);
                var callbackUrl = Url.Action("ConfirmEmailAndPassword", "Account", new { userId = organizationUser.AspNetUserId, ccode = confirmationCode, pcode = passwordCode }, protocol: Request.Url.Scheme);
                await UserManager.SendEmailAsync(organizationUser.AspNetUserId, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                //Check whether user create request came of specific page - if so, go back to that page
                var parentType = Request.QueryString["parentType"];                
                if(!string.IsNullOrEmpty(parentType))
                {
                    var parentTab = Request.QueryString["parentTab"];
                    var parentView = Request.QueryString["parentAction"];
                    var parentId = Request.QueryString["parentId"];
                    return RedirectToAction(parentView, parentType, new { id = parentId, tab = parentTab, userId = organizationUser.Id });
                }
                else
                {
                    //Redirect to user list page 
                    return RedirectToAction("Index");
                }
                
            }

            //Something went wrong if we got this far
            return View(organizationUser);
        }

        // GET: OrganizationUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationUser organizationUser = _bl.GetOrganizationUserById(id.Value);
            if (organizationUser == null)
            {
                return HttpNotFound();
            }

            InitAppUserData(organizationUser);            
            ViewBag.AllRoles = _authHelper.GetAllowedRoles();            

            return View(organizationUser);
        }

        // POST: OrganizationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,AspNetUserId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,FirstName,MiddleName,LastName,AddressLine1,AddressLine2,City,County,State,Country,Zip,PhoneNumber,CellNumber,TenantUnit,TenantUnitId,OwnerGroup,OwnerPermissions,CreatedByUserName,LastModifiedByUserName,Email,EmailConfirmed,TwoFactorEnabled,LockoutEnabled,LockoutEndDateUtc,AccessFailedCount,UserName")] OrganizationUser organizationUser, int editFormFlag)
        {
                            
            if (editFormFlag == 1 && ModelState.IsValid)
            {            
                _bl.UpdateOrganizationUser(organizationUser);
                SaveAppUserData(organizationUser);

                return RedirectToAction("Index");
            }
            else if (editFormFlag == 2)
            {                
                string code = await UserManager.GeneratePasswordResetTokenAsync(organizationUser.AspNetUserId);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = organizationUser.AspNetUserId, code = code }, protocol: Request.Url.Scheme);
                await UserManager.SendEmailAsync(organizationUser.AspNetUserId, Resources.Resources.UIText_ResetPassword, string.Format(Resources.Resources.CodeText_ResetPasswordEmail, callbackUrl));
                
                ViewBag.CurrentTab = "ResetPassword";
                ViewBag.ViewState = "Confirmed";

                organizationUser = _bl.GetOrganizationUserById(organizationUser.Id);
                InitAppUserData(organizationUser);

                return View(organizationUser);
            }
            else if(editFormFlag == 20)
            {
                return RedirectToAction("Index");
            }
            else if(editFormFlag == 3)
            {
                var selectedRoles = new List<string>();
                if (!string.IsNullOrEmpty(Request.Form["SelectedRole"]))
                    selectedRoles.AddRange(Request.Form["SelectedRole"].Split(",".ToCharArray()));                
                var allowedRoles = _authHelper.GetAllowedRoles();

                foreach(var role in allowedRoles)
                {
                    if (!selectedRoles.Contains(role) && UserManager.IsInRole(organizationUser.AspNetUserId, role))
                        UserManager.RemoveFromRole(organizationUser.AspNetUserId, role);
                    else if (selectedRoles.Contains(role) && !UserManager.IsInRole(organizationUser.AspNetUserId, role))
                        UserManager.AddToRole(organizationUser.AspNetUserId, role);                        
                }
                return RedirectToAction("Index");
            }

            return View(organizationUser);
        }

        // GET: OrganizationUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationUser organizationUser = _bl.GetOrganizationUserById(id.Value);
            if (organizationUser == null)
            {
                return HttpNotFound();
            }
            InitAppUserData(organizationUser);

            return View(organizationUser);
        }

        // POST: OrganizationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrganizationUser organizationUser = _bl.GetOrganizationUserById(id);
            var aspNetUserId = organizationUser.AspNetUserId;
            _bl.RemoveOrganizationUser(organizationUser);

            //Remove from identity system
            if (!string.IsNullOrEmpty(aspNetUserId))
            {
                var appUser = UserManager.FindById(organizationUser.AspNetUserId);
                if (appUser != null)
                {
                    var result = UserManager.Delete(appUser);
                    if (!result.Succeeded)
                    {
                        if (result.Errors != null)
                            throw new Common.Exceptions.BAPUserException(organizationUser.UserName, "Cannot delete user: " + string.Join(",", result.Errors));
                        else
                            throw new Common.Exceptions.BAPUserException(organizationUser.UserName, "Cannot delete user - unknown error.");
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Lock(int id)
        {
            OrganizationUser organizationUser = _bl.GetOrganizationUserById(id);
            if (organizationUser != null)
            {
                organizationUser.LockoutEnabled = true;
                SaveAppUserData(organizationUser);
            }
            TempData["CurrentTab"] = "users";
            return RedirectToAction("Index", "Organizations");
        }

        public ActionResult Unlock(int id)
        {
            OrganizationUser organizationUser = _bl.GetOrganizationUserById(id);
            if (organizationUser != null)
            {
                organizationUser.LockoutEnabled = false;
                SaveAppUserData(organizationUser);
            }
            TempData["CurrentTab"] = "users";
            return RedirectToAction("Index", "Organizations");
        }
     
    }
}
