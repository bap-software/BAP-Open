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
    public class ShippingCarriersController : BaseController<ShippingCarrier>
    {
        private readonly IShippingCarrierBL _pbl;

        public ShippingCarriersController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<ShippingCarrier>(configHelper, context), new eCommerceBusinessLayer(lookupEngine, fileProc, configHelper, context, logger))
        {
            _pbl = (IShippingCarrierBL)_bl;
        }

        // GET: Controllers/ShippingCarriers        
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

            return View(_pbl.SearchShippingCarriers(searchString, sortOrder, pageNumber, pageSize));
        }

        // GET: Controllers/ShippingCarriers/Details/5        
        public ActionResult AdminDetails(int id)
        {
            ShippingCarrier shippingcarrier = _pbl.GetShippingCarrierById(id);
            if (shippingcarrier == null)
            {
                return HttpNotFound();
            }
            if (TempData["CurrentTab"] != null)
            {
                ViewBag.CurrentTab = TempData["CurrentTab"].ToString();
            }
            return View(shippingcarrier);
        }

        // GET: Controllers/ShippingCarriers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Controllers/ShippingCarriers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShippingOptions,Id,Name,ShortDescription,Description,Enabled,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,ShippingProviderAssembly,ShippingProviderClass,OptionCode,TeaserImage,CustomConfigJson,CultureCode,LocalizationId")] ShippingCarrier shippingcarrier)
        {
            if (ModelState.IsValid)
            {
                _pbl.AddShippingCarrier(shippingcarrier);
            }

            return RedirectToAction("AdminIndex");
        }

        // GET: Controllers/ShippingCarriers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingCarrier shippingcarrier = _pbl.GetShippingCarrierById(id.Value);
            if (shippingcarrier == null)
            {
                return HttpNotFound();
            }
            var configSupport = _pbl.CheckCustomConfigSupport(shippingcarrier);
            if (configSupport != null)
                ViewBag.CustomDataSupported = configSupport.SupportsCustomConfig;
            else
                ViewBag.CustomDataSupported = false;

            if (configSupport != null && configSupport.SupportsCustomConfig)
                ViewBag.CustomDataExample = configSupport.CustomConfigExample;
            else
                ViewBag.CustomDataExample = "";

            return View(shippingcarrier);
        }

        // POST: Controllers/ShippingCarriers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShippingOptions,Id,Name,ShortDescription,Description,Enabled,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,ShippingProviderAssembly,ShippingProviderClass,OptionCode,TeaserImage,CustomConfigJson,CultureCode,LocalizationId")] ShippingCarrier shippingcarrier)
        {
            if (ModelState.IsValid)
            {
                _pbl.UpdateShippingCarrier(shippingcarrier);
            }

            return RedirectToAction("AdminIndex");
        }

        // GET: Controllers/ShippingCarriers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingCarrier shippingcarrier = _pbl.GetShippingCarrierById(id.Value);
            if (shippingcarrier == null)
            {
                return HttpNotFound();
            }

            return View(shippingcarrier);
        }

        // POST: Controllers/ShippingCarriers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShippingCarrier shippingcarrier = _pbl.GetShippingCarrierById(id);
            _pbl.RemoveShippingCarrier(shippingcarrier);
            return RedirectToAction("AdminIndex");
        }
    }
}