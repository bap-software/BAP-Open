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
using BAP.eCommerce.Common.Exceptions;

namespace BAP.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator,Supervisor")]
    public class AddressesController : BaseController<Address>
    {
        private readonly IAddressBL _abl;

        public AddressesController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<Address>(configHelper, context), new eCommerceBusinessLayer(lookupEngine, fileProc, configHelper, context, logger))
        {            
            _abl = (IAddressBL)_bl;
        }

        // GET: Controllers/Addresses/AdminIndex     
        public ActionResult AdminIndex(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int rowsPerPage = GetRealPageSize(pageSize);

            InitIndexViewData(sortOrder, currentFilter);

            return View(_abl.SearchAddresses(searchString, sortOrder, pageNumber, rowsPerPage));
        }

        // GET: Controllers/Addresses/AdminDetails/5       
        public ActionResult AdminDetails(int id)
        {
            Address address = _abl.GetAddressById(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // GET: Controllers/Addresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Controllers/Addresses/Create
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CompanyName,Description,FirstName,MiddleName,LastName,AddressLine1,AddressLine2,City,County,State,Country,Zip,PhoneNumber,PhoneExtension,FaxNumber,CellNumber,ContactEmail,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] Address address)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _abl.AddAddress(address);
                }
                catch (AddressException exc)
                {
                    ClientNotify(exc.Message, Resources.Resources.ErrorText_Error);
                    return View(address);
                }
                return RedirectToAction("AdminIndex");
            }

            return View(address);
        }

        // GET: Controllers/Addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = _abl.GetAddressById(id.Value);
            if (address == null)
            {
                return HttpNotFound();
            }

            return View(address);
        }

        // POST: Controllers/Addresses/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CompanyName,Description,FirstName,MiddleName,LastName,AddressLine1,AddressLine2,City,County,State,Country,Zip,PhoneNumber,PhoneExtension,FaxNumber,CellNumber,ContactEmail,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] Address address)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _abl.UpdateAddress(address);
                }
                catch (AddressException exc)
                {
                    ClientNotify(exc.Message, Resources.Resources.ErrorText_Error);
                    return View(address);
                }
                return RedirectToAction("AdminIndex");
            }

            return View(address);
        }

        // GET: Controllers/Addresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = _abl.GetAddressById(id.Value);
            if (address == null)
            {
                return HttpNotFound();
            }

            return View(address);
        }

        // POST: Controllers/Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Address address = _abl.GetAddressById(id);
            _abl.RemoveAddress(address);
            return RedirectToAction("AdminIndex");
        }        
    }
}