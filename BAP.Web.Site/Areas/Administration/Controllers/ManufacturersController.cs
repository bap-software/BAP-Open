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
    public class ManufacturersController : BaseController<Manufacturer>
    {
        private readonly IManufacturerBL _mbl;

        public ManufacturersController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<Manufacturer>(configHelper, context), null, fileProc, new eCommerceBusinessLayer(lookupEngine, fileProc, configHelper, context, logger))
        {
            _mbl = (IManufacturerBL)_bl;
        }

        // GET: Controllers/Manufacturers
        public ActionResult AdminIndex(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int rowsPerPage = GetRealPageSize(pageSize);

            InitIndexViewData(sortOrder, currentFilter);

            return View(_mbl.SearchManufacturers(searchString, sortOrder, pageNumber, rowsPerPage));
        }

        // GET: Controllers/Manufacturers/Details/5        
        public ActionResult AdminDetails(int id)
        {
            Manufacturer manufacturer = _mbl.GetManufacturerById(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            if (TempData["CurrentTab"] != null)
            {
                ViewBag.CurrentTab = TempData["CurrentTab"].ToString();
            }
            return View(manufacturer);
        }

        // GET: Controllers/Manufacturers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Controllers/Manufacturers/Create
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortDescription,Description,LogoImage,File,Slogan,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,TimeStamp,LastModifiedBy,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,CultureCode,LocalizationId")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                ProcessImage(manufacturer);
                _mbl.AddManufacturer(manufacturer);
            }

            return RedirectToAction("AdminIndex");
        }

        // GET: Controllers/Manufacturers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = _mbl.GetManufacturerById(id.Value);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // POST: Controllers/Manufacturers/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortDescription,Description,LogoImage,File,Slogan,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,TimeStamp,LastModifiedBy,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,CultureCode,LocalizationId")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                ProcessImage(manufacturer);
                _mbl.UpdateManufacturer(manufacturer);
            }

            return RedirectToAction("AdminIndex");
        }

        // GET: Controllers/Manufacturers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = _mbl.GetManufacturerById(id.Value);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }

            return View(manufacturer);
        }

        // POST: Controllers/Manufacturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manufacturer manufacturer = _mbl.GetManufacturerById(id);
            _mbl.RemoveManufacturer(manufacturer);
            return RedirectToAction("AdminIndex");
        }

        private void ProcessImage(Manufacturer manufacturer)
        {
            if (manufacturer.File != null)
            {
                _fileProcessor.CreateFolder("Public", "Manufacturers");
                manufacturer.LogoImage = _fileProcessor.UploadFile("Public/Manufacturers", manufacturer.File);                
            }
        }

    }
}