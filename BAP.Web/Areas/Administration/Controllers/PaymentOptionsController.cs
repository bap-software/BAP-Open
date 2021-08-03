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
    public class PaymentOptionsController : BaseController<PaymentOption>
    {
        private readonly IPaymentOptionBL _pbl;

        public PaymentOptionsController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<PaymentOption>(configHelper, context), new eCommerceBusinessLayer(lookupEngine, fileProc, configHelper, context, logger))
        {
            _pbl = (IPaymentOptionBL)_bl;
        }


        // GET: Controllers/PaymentOptions/AdminIndex     
        public ActionResult AdminIndex(string sortOrder, string currentFilter, string searchString, int? page)
        {
            int pageNumber = 1;
            int pageSize = _configHelper.FakeMaxPageSize;

            EntityPagingAttribute pageAttr = (EntityPagingAttribute)Attribute.GetCustomAttribute(typeof(DAL.Entities.Blog), typeof(EntityPagingAttribute));
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

            return View(_pbl.SearchPaymentOptions(searchString, sortOrder, pageNumber, pageSize));
        }

        // GET: Controllers/PaymentOptions/AdminDetails/5       
        public ActionResult AdminDetails(int id)
        {
            PaymentOption paymentoption = _pbl.GetPaymentOptionById(id);
            if (paymentoption == null)
            {
                return HttpNotFound();
            }
            return View(paymentoption);
        }
        
        // GET: Controllers/PaymentOptions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Controllers/PaymentOptions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShippingOptions,Id,Name,ShortDescription,Description,Enabled,AsssemblyName,ClassName,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,CultureCode,LocalizationId,PaymentContainerCss,CustomConfigJson")] PaymentOption paymentoption)
        {
            if (ModelState.IsValid)
            {
                _pbl.AddPaymentOption(paymentoption);
                return RedirectToAction("AdminIndex");
            }

            return View(paymentoption);
        }

        // GET: Controllers/PaymentOptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentOption paymentoption = _pbl.GetPaymentOptionById(id.Value);
            if (paymentoption == null)
            {
                return HttpNotFound();
            }

            var configSupport = _pbl.CheckCustomConfigSupport(paymentoption);
            if (configSupport != null)
                ViewBag.CustomDataSupported = configSupport.SupportsCustomConfig;
            else
                ViewBag.CustomDataSupported = false;

            if (configSupport != null && configSupport.SupportsCustomConfig)
                ViewBag.CustomDataExample = configSupport.CustomConfigExample;
            else
                ViewBag.CustomDataExample = "";

            return View(paymentoption);
        }

        // POST: Controllers/PaymentOptions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShippingOptions,Id,Name,ShortDescription,Description,Enabled,AsssemblyName,ClassName,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,CultureCode,LocalizationId,PaymentContainerCss,CustomConfigJson")] PaymentOption paymentoption)
        {
            if (ModelState.IsValid)
            {
                _pbl.UpdatePaymentOption(paymentoption);
                return RedirectToAction("AdminIndex");
            }

            return View(paymentoption);
        }

        // GET: Controllers/PaymentOptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentOption paymentoption = _pbl.GetPaymentOptionById(id.Value);
            if (paymentoption == null)
            {
                return HttpNotFound();
            }

            return View(paymentoption);
        }

        // POST: Controllers/PaymentOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaymentOption paymentoption = _pbl.GetPaymentOptionById(id);
            _pbl.RemovePaymentOption(paymentoption);
            return RedirectToAction("AdminIndex");
        }

    }
}