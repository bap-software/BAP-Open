using System;
using System.Net;
using System.Web.Mvc;

using BAP.Common;
using BAP.DAL.Entities;
using BAP.Lookups;
using BAP.Log;
using BAP.DAL;
using BAP.UI.Controllers;


namespace BAP.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ContentControlTypesController : BaseController<ContentControlType>
    {        
        public ContentControlTypesController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<ContentControlType>(configHelper, context))
        {            
        }

        // GET: Lookups
        public ActionResult Index(string sortOrder, string currentFilter, int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int rowsPerPage = GetRealPageSize(pageSize);

            InitIndexViewData(sortOrder, currentFilter);

            return View(_bl.SearchContentControlTypes(currentFilter, sortOrder, pageNumber, rowsPerPage));
        }

        // GET: Lookups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentControlType contentControlType = _bl.GetContentControlTypeById(id.Value);
            if (contentControlType == null)
            {
                return HttpNotFound();
            }
            return View(contentControlType);
        }

        // GET: Lookups/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lookups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind(Include = "Id,Name,Description,IsEnabled,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,OwnerGroup,OwnerPermissions,CultureCode,LocalizationId")] ContentControlType contentControlType)
        {
            if (ModelState.IsValid)
            {
                _bl.AddContentControlType(contentControlType);
                return RedirectToAction("Index");
            }

            return View(contentControlType);
        }

        // GET: Lookups/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentControlType contentControlType = _bl.GetContentControlTypeById(id.Value);
            if (contentControlType == null)
            {
                return HttpNotFound();
            }
            return View(contentControlType);
        }

        // POST: Lookups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,IsEnabled,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,OwnerGroup,OwnerPermissions,CultureCode,LocalizationId")] ContentControlType contentControlType)
        {
            if (ModelState.IsValid)
            {
                _bl.UpdateContentControlType(contentControlType);
                return RedirectToAction("Index");
            }
            return View(contentControlType);
        }

        // GET: Lookups/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentControlType contentControlType = _bl.GetContentControlTypeById(id.Value);
            if (contentControlType == null)
            {
                return HttpNotFound();
            }
            return View(contentControlType);
        }

        // POST: Lookups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            ContentControlType contentControlType = _bl.GetContentControlTypeById(id);
            _bl.RemoveContentControlType(contentControlType);
            return RedirectToAction("Index");
        }
    }
}
