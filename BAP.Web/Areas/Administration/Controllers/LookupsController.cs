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
    [Authorize(Roles = "Administrator,ContentManager")]
    public class LookupsController : BaseController<Lookup>
    {        
        
        public LookupsController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<Lookup>(configHelper, context))
        {            
        }

        // GET: Lookups
        public ActionResult Index(string sortOrder, string currentFilter, int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int rowsPerPage = GetRealPageSize(pageSize);

            InitIndexViewData(sortOrder, currentFilter);

            return View(_bl.SearchLookups(currentFilter, sortOrder, pageNumber, rowsPerPage));
        }

        // GET: Lookups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lookup lookup = _bl.GetLookupById(id.Value);
            if (lookup == null)
            {
                return HttpNotFound();
            }
            return View(lookup);
        }

        // GET: Lookups/Create
        [Authorize(Roles = "Administrator,ContentManager")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lookups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,ContentManager")]
        public ActionResult Create([Bind(Include = "Id,Name,Description,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,LookupType,IntRangeFrom,IntRangeTo,FloatRangeFrom,FloatRangeTo,FloatRangeStep,DateRangeFrom,DateRangeTo,RangePrefix,EntityName,EntityValueField,EntityNameField,EntityFilter,EntityOrderBy,EntityAssembly,EntityClass,OwnerGroup,OwnerPermissions,CultureCode,LocalizationId")] Lookup lookup)
        {
            if (ModelState.IsValid)
            {
                _bl.AddLookup(lookup);
                return RedirectToAction("Index");
            }

            return View(lookup);
        }

        // GET: Lookups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lookup lookup = _bl.GetLookupById(id.Value);
            if (lookup == null)
            {
                return HttpNotFound();
            }
            return View(lookup);
        }

        // POST: Lookups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,ContentManager")]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,LookupType,IntRangeFrom,IntRangeTo,FloatRangeFrom,FloatRangeTo,FloatRangeStep,DateRangeFrom,DateRangeTo,RangePrefix,EntityName,EntityValueField,EntityNameField,EntityFilter,EntityOrderBy,EntityAssembly,EntityClass,OwnerGroup,OwnerPermissions,CultureCode,LocalizationId")] Lookup lookup)
        {
            if (ModelState.IsValid)
            {
                _bl.UpdateLookup(lookup);
                return RedirectToAction("Index");
            }
            return View(lookup);
        }

        // GET: Lookups/Delete/5
        [Authorize(Roles = "Administrator,ContentManager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lookup lookup = _bl.GetLookupById(id.Value);
            if (lookup == null)
            {
                return HttpNotFound();
            }
            return View(lookup);
        }

        // POST: Lookups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,ContentManager")]
        public ActionResult DeleteConfirmed(int id)
        {
            Lookup lookup = _bl.GetLookupById(id);
            _bl.RemoveLookup(lookup);
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
