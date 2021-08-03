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
using BAP.BL;

namespace BAP.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator,Supervisor")]
    public class StoresController : BaseController<Store>
    {
        private readonly IStoreBL _sbl;

        public StoresController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<Store>(configHelper, context), new eCommerceBusinessLayer(lookupEngine, fileProc, configHelper, context, logger))
        {
            _sbl = (IStoreBL)_bl;
        }
        
        // GET: Controllers/Stores/AdminIndex     
        public ActionResult AdminIndex(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int rowsPerPage = GetRealPageSize(pageSize);

            InitIndexViewData(sortOrder, currentFilter);

            return View(_sbl.SearchStores(searchString, sortOrder, pageNumber, rowsPerPage));
        }

        // GET: Controllers/Stores/AdminDetails/5       
        public ActionResult AdminDetails(int id)
        {
            Store store = _sbl.GetStoreById(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            if (TempData["CurrentTab"] != null)
            {
                ViewBag.CurrentTab = TempData["CurrentTab"].ToString();
            }
            ViewBag.PaymentOptionId = new SelectList(((IPaymentOptionBL)_bl).GetAllPaymentOptions(), "Id", "Name");
            ViewBag.ShippingOptionId = new SelectList(((IShippingOptionBL)_bl).GetAllShippingOptions(), "Id", "Name");
            ViewBag.ProductCategoryId = new SelectList(((IProductCategoryBL)_bl).GetAllProductCategories(), "Id", "Name");
            ViewBag.DiscountCouponId = new SelectList(((IDiscountCouponBL)_bl).GetAllDiscountCoupons(), "Id", "Name");
            return View(store);
        }
        
        // GET: Controllers/Stores/Create
        public ActionResult Create()
        {
            var currentOrganizationUser = ((IOrganizationUserBL)_bl).GetOrganizationUserByAspNetId(_authHelper.GetCurrentUserId());
            var currentOrganization = ((IOrganizationBL)_bl).GetOrganizationById(_authHelper.GetCurrentOrganizationId());
            var store = new Store
            {
                AdminUserId = currentOrganizationUser.Id,
                AdminUser = currentOrganizationUser,
                OrganizationId = currentOrganization.Id,
                Organization = currentOrganization,
                IsUnregisteredCheckoutAllowed = true
            };
            return View(store);
        }

        // POST: Controllers/Stores/Create
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,IsDefault,IsUnregisteredCheckoutAllowed,ShortDescription,Description,InvoiceTemplate,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,AdminUserId,OrganizationId,QuickShoppingCart")] Store store)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    store.EntityState = BAPEntityState.Added;
                    _sbl.AddStore(store);
                }
                catch (Exception exc)
                {
                    ClientNotify(exc.Message, Resources.Resources.ErrorText_Error);
                    return View(store);
                }
                return RedirectToAction("AdminIndex");
            }

            return View(store);
        }

        // GET: Controllers/Stores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = _sbl.GetStoreById(id.Value);
            _sbl.InitSubordinateEntities(store);
            
            if (store == null)
            {
                return HttpNotFound();
            }

            return View(store);
        }

        // POST: Controllers/Stores/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,IsDefault,IsUnregisteredCheckoutAllowed,ShortDescription,Description,InvoiceTemplate,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,AdminUserId,OrganizationId,BillingAddressId,BillingAddress,ShippingAddressId,ShippingAddress,QuickShoppingCart")] Store store)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    store.EntityState = BAPEntityState.Modified;
                    _sbl.UpdateStore(store);
                }
                catch (Exception exc)
                {
                    ClientNotify(exc.Message, Resources.Resources.ErrorText_Error);
                    return View(store);
                }
                if (TempData["CurrentTab"] != null)
                {
                    ViewBag.CurrentTab = TempData["CurrentTab"].ToString();
                }
                return RedirectToAction("AdminIndex");
            }

            return View(store);
        }

        // GET: Controllers/Stores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = _sbl.GetStoreById(id.Value);
            if (store == null)
            {
                return HttpNotFound();
            }

            return View(store);
        }

        // POST: Controllers/Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Store store = _sbl.GetStoreById(id);
            _sbl.RemoveStore(store);
            return RedirectToAction("AdminIndex");
        }

        public ActionResult AddPayment(int id, int paymentOptionId)
        {
            Store store = _sbl.GetStoreById(id);
            PaymentOption paymentOption = ((IPaymentOptionBL)_bl).GetPaymentOptionById(paymentOptionId);
            if (store == null)
            {
                return HttpNotFound();
            }
            _sbl.AddPaymentOption(store, paymentOption);
            TempData["CurrentTab"] = "paymentOptions";
            return RedirectToAction("AdminDetails", new { Id = id });
        }

        public ActionResult RemovePayment(int id, int paymentOptionId)
        {
            Store store = _sbl.GetStoreById(id);
            PaymentOption paymentOption = ((IPaymentOptionBL)_bl).GetPaymentOptionById(paymentOptionId);
            if (store == null)
            {
                return HttpNotFound();
            }
            _sbl.RemovePaymentOption(store, paymentOption);
            TempData["CurrentTab"] = "paymentOptions";
            return RedirectToAction("AdminDetails", new { Id = id });
        }

        public ActionResult AddShipping(int id, int shippingOptionId)
        {
            Store store = _sbl.GetStoreById(id);
            ShippingOption shippingOption = ((IShippingOptionBL)_bl).GetShippingOptionById(shippingOptionId);
            if (store == null)
            {
                return HttpNotFound();
            }
            _sbl.AddShippingOption(store, shippingOption);
            TempData["CurrentTab"] = "shippingOptions";
            return RedirectToAction("AdminDetails", new { Id = id });
        }

        public ActionResult RemoveShipping(int id, int shippingOptionId)
        {
            Store store = _sbl.GetStoreById(id);
            ShippingOption shippingOption = ((IShippingOptionBL)_bl).GetShippingOptionById(shippingOptionId);
            if (store == null)
            {
                return HttpNotFound();
            }
            _sbl.RemoveShippingOption(store, shippingOption);
            TempData["CurrentTab"] = "shippingOptions";
            return RedirectToAction("AdminDetails", new { Id = id });
        }

        public ActionResult AddProductCategory(int id, int productCategoryId)
        {
            Store store = _sbl.GetStoreById(id);
            ProductCategory productCategory = ((IProductCategoryBL)_bl).GetProductCategoryById(productCategoryId);
            if (store == null)
            {
                return HttpNotFound();
            }
            _sbl.AddProductCategory(store, productCategory);
            TempData["CurrentTab"] = "productCategories";
            return RedirectToAction("AdminDetails", new { Id = id });
        }

        public ActionResult RemoveProductCategory(int id, int productCategoryId)
        {
            Store store = _sbl.GetStoreById(id);
            ProductCategory productCategory = ((IProductCategoryBL)_bl).GetProductCategoryById(productCategoryId);
            if (store == null)
            {
                return HttpNotFound();
            }
            _sbl.RemoveProductCategory(store, productCategory);
            TempData["CurrentTab"] = "productCategories";
            return RedirectToAction("AdminDetails", new { Id = id });
        }

        public ActionResult AddDiscountCoupon(int id, int discountCouponId)
        {
            Store store = _sbl.GetStoreById(id);
            DiscountCoupon discountCoupon = ((IDiscountCouponBL)_bl).GetDiscountCouponById(discountCouponId);
            if (store == null)
            {
                return HttpNotFound();
            }
            _sbl.AddDiscountCoupon(store, discountCoupon);
            TempData["CurrentTab"] = "discountCoupons";
            return RedirectToAction("AdminDetails", new { Id = id });
        }

        public ActionResult RemoveDiscountCoupon(int id, int discountCouponId)
        {
            Store store = _sbl.GetStoreById(id);
            DiscountCoupon discountCoupon = ((IDiscountCouponBL)_bl).GetDiscountCouponById(discountCouponId);
            if (store == null)
            {
                return HttpNotFound();
            }
            _sbl.RemoveDiscountCoupon(store, discountCoupon);
            TempData["CurrentTab"] = "discountCoupons";
            return RedirectToAction("AdminDetails", new { Id = id });
        }

    }
}