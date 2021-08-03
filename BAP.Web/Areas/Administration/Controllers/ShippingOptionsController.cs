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
    public class ShippingOptionsController : BaseController<ShippingOption>
    {
        private readonly IShippingOptionBL _sbl;

        public ShippingOptionsController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<ShippingOption>(configHelper, context), new eCommerceBusinessLayer(lookupEngine, fileProc, configHelper, context, logger))
        {
            _sbl = (IShippingOptionBL)_bl;
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

            return View(_sbl.SearchShippingOptions(searchString, sortOrder, pageNumber, pageSize));
        }

        // GET: Controllers/ShippingCarriers/Details/5        
        public ActionResult AdminDetails(int id)
        {
            ShippingOption shippingOption = _sbl.GetShippingOptionById(id);
            if (shippingOption == null)
            {
                return HttpNotFound();
            }
            ViewBag.PaymentOptionId = new SelectList(((IPaymentOptionBL)_bl).GetAllPaymentOptions(), "Id", "Name");
            return View(shippingOption);
        }
        
        // GET: Controllers/ShippingOptions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Controllers/ShippingOptions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShippingCarrier,Id,Name,ShortDescription,Description,Enabled,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,ShippingCarrierId,OptionCode,TeaserImage,CustomConfigJson,MaxPrice,CultureCode,LocalizationId")] ShippingOption shippingoption)
        {
            if (ModelState.IsValid)
            {
                _sbl.AddShippingOption(shippingoption);
            }

            return RedirectToAction("AdminIndex");
        }

        // GET: Controllers/ShippingOptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingOption shippingoption = _sbl.GetShippingOptionById(id.Value);
            if (shippingoption == null)
            {
                return HttpNotFound();
            }

            var configSupport = ((IShippingCarrierBL)_bl).CheckCustomOptionConfigSupport(shippingoption.ShippingCarrier);
            if (configSupport != null)
                ViewBag.CustomDataSupported = configSupport.SupportsCustomConfig;
            else
                ViewBag.CustomDataSupported = false;

            if (configSupport != null && configSupport.SupportsCustomConfig)
                ViewBag.CustomDataExample = configSupport.CustomConfigExample;
            else
                ViewBag.CustomDataExample = "";

            return View(shippingoption);
        }

        // POST: Controllers/ShippingOptions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShippingCarrier,Id,Name,ShortDescription,Description,Enabled,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,ShippingCarrierId,OptionCode,TeaserImage,CustomConfigJson,MaxPrice,CultureCode,LocalizationId")] ShippingOption shippingoption)
        {
            if (ModelState.IsValid)
            {
                _sbl.UpdateShippingOption(shippingoption);
            }

            return RedirectToAction("AdminIndex");
        }

        // GET: Controllers/ShippingOptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingOption shippingoption = _sbl.GetShippingOptionById(id.Value);
            if (shippingoption == null)
            {
                return HttpNotFound();
            }

            return View(shippingoption);
        }

        // POST: Controllers/ShippingOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShippingOption shippingoption = _sbl.GetShippingOptionById(id);
            _sbl.RemoveShippingOption(shippingoption);
            return RedirectToAction("AdminIndex");
        }

        // POST: Controllers/ShippingOptions/AddPayment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPayment(int id, int paymentOptionId)
        {
            ShippingOption shippingoption = _sbl.GetShippingOptionById(id);
            PaymentOption paymentOption = ((IPaymentOptionBL)_bl).GetPaymentOptionById(paymentOptionId);
            if (shippingoption == null)
            {
                return HttpNotFound();
            }
            _sbl.AddPaymentOption(shippingoption, paymentOption);
            return RedirectToAction("AdminDetails", new { Id = id });
        }

        public ActionResult RemovePayment(int id, int paymentOptionId)
        {
            ShippingOption shippingoption = _sbl.GetShippingOptionById(id);
            PaymentOption paymentOption = ((IPaymentOptionBL)_bl).GetPaymentOptionById(paymentOptionId);
            if (shippingoption == null)
            {
                return HttpNotFound();
            }
            _sbl.RemovePaymentOption(shippingoption, paymentOption);
            return RedirectToAction("AdminDetails", new { Id = id });
        }
        
    }
}