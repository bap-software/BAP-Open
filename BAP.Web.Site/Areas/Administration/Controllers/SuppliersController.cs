using System;
using System.Net;
using System.Web.Mvc;

using BAP.Common;
using BAP.Lookups;
using BAP.Log;
using BAP.UI.Controllers;
using BAP.FileSystem;
using BAP.DAL;

using BAP.eCommerce.DAL.Entities;
using BAP.eCommerce.BL;

namespace BAP.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator,Supervisor")]
    public class SuppliersController : BaseController<Supplier>
    {
        private ISupplierBL _sbl;
        public SuppliersController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<Supplier>(configHelper, context), new eCommerceBusinessLayer(lookupEngine, fileProc, configHelper, context, logger))
        {
            _sbl = (ISupplierBL)_bl;
        }

        // GET: Controllers/Suppliers
        public ActionResult AdminIndex(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int rowsPerPage = GetRealPageSize(pageSize);

            InitIndexViewData(sortOrder, currentFilter);

            return View(_sbl.SearchSuppliers(searchString, sortOrder, pageNumber, rowsPerPage));
        }

        // GET: Controllers/Supplier/Details/5        
        public ActionResult AdminDetails(int id)
        {
            Supplier supplier = _sbl.GetSupplierById(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            if (TempData["CurrentTab"] != null)
            {
                ViewBag.CurrentTab = TempData["CurrentTab"].ToString();
            }
            return View(supplier);
        }

        // GET: Controllers/Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Controllers/Supplier/Create
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortDescription,Description,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,TimeStamp,LastModifiedBy,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,CultureCode,LocalizationId")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _sbl.AddSupplier(supplier);
            }

            return RedirectToAction("AdminIndex");
        }

        // GET: Controllers/Supplier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = _sbl.GetSupplierById(id.Value);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Controllers/Supplier/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortDescription,Description,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,TimeStamp,LastModifiedBy,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,CultureCode,LocalizationId")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _sbl.UpdateSupplier(supplier);
            }

            return RedirectToAction("AdminIndex");
        }

        // GET: Controllers/Supplier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = _sbl.GetSupplierById(id.Value);
            if (supplier == null)
            {
                return HttpNotFound();
            }

            return View(supplier);
        }

        // POST: Controllers/Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = _sbl.GetSupplierById(id);
            _sbl.RemoveSupplier(supplier);
            return RedirectToAction("AdminIndex");
        }

    }
}