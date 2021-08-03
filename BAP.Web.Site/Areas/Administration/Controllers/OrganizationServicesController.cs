
using System;
using System.Net;
using System.Web.Mvc;


using BAP.Common;
using BAP.Lookups;
using BAP.Log;
using BAP.DAL;
using BAP.DAL.Entities;

using BAP.UI.Controllers;
using BAP.FileSystem;

namespace BAP.Web.Areas.Administration.Controllers
{
    //Every controller is created with restricted access be default. Any public action has to be created explicitly.
    [Authorize(Roles = "Administrator")]
    public class OrganizationServicesController : BaseController<OrganizationService>
    {        
        public OrganizationServicesController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<OrganizationService>(configHelper, context))
        {        
        }

        // GET: Administration/OrganizationServices
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            int pageNumber = 1;
            int pageSize = _configHelper.FakeMaxPageSize;

            EntityPagingAttribute pageAttr = (EntityPagingAttribute)Attribute.GetCustomAttribute(typeof(OrganizationService), typeof(EntityPagingAttribute));
            if (pageAttr != null && pageAttr.Applied && pageAttr.PageSize > 0)
            {
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

                pageNumber = (page ?? 1);
                pageSize = pageAttr.PageSize;
            }

            return View(_bl.SearchOrganizationServices(searchString, sortOrder, pageNumber, pageSize));
        }

        // GET: Administration/OrganizationServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationService organizationService = _bl.GetOrganizationServiceById(id.Value);
            if (organizationService == null)
            {
                return HttpNotFound();
            }
            return View(organizationService);
        }

        // GET: Administration/OrganizationServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/OrganizationServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortDescription,Description,ImageUrl,IconClass,Order,Enabled,CultureCode,LocalizationId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] OrganizationService organizationService)
        {
            if (ModelState.IsValid)
            {

                _bl.AddOrganizationService(organizationService);
                return RedirectToAction("Index");
            }

            return View(organizationService);
        }

        // GET: Administration/OrganizationServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationService organizationService = _bl.GetOrganizationServiceById(id.Value);
            if (organizationService == null)
            {
                return HttpNotFound();
            }
            return View(organizationService);
        }

        // POST: Administration/OrganizationServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortDescription,Description,ImageUrl,IconClass,Order,Enabled,CultureCode,LocalizationId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] OrganizationService organizationService)
        {
            if (ModelState.IsValid)
            {
                _bl.UpdateOrganizationService(organizationService);
                return RedirectToAction("Index");
            }
            return View(organizationService);
        }

        // GET: Administration/OrganizationServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationService organizationService = _bl.GetOrganizationServiceById(id.Value);
            if (organizationService == null)
            {
                return HttpNotFound();
            }
            return View(organizationService);
        }

        // POST: Administration/OrganizationServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrganizationService organizationService = _bl.GetOrganizationServiceById(id);

            _bl.RemoveOrganizationService(organizationService);
            return RedirectToAction("Index");
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
