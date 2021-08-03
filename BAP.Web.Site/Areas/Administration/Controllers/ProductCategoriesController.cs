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
    [Authorize(Roles = "Administrator,ContentManager,Supervisor")]
    public class ProductCategoriesController : BaseController<ProductCategory>
    {
        private readonly IProductCategoryBL _pbl;

        public ProductCategoriesController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<ProductCategory>(configHelper, context), new eCommerceBusinessLayer(lookupEngine, fileProc, configHelper, context, logger))
        {
            _pbl = (IProductCategoryBL)_bl;
        }
        
        // GET: Controllers/ProductCategories/AdminIndex     
        public ActionResult AdminIndex(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int rowsPerPage = GetRealPageSize(pageSize);

            InitIndexViewData(sortOrder, currentFilter);

            return View(_pbl.SearchProductCategories(searchString, sortOrder, pageNumber, rowsPerPage));
        }

        // GET: Controllers/ProductCategories/AdminDetails/5       
        public ActionResult AdminDetails(int id)
        {
            ProductCategory productcategory = _pbl.GetProductCategoryById(id);
            if (productcategory == null)
            {
                return HttpNotFound();
            }
            return View(productcategory);
        }
        
        // GET: Controllers/ProductCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Controllers/ProductCategories/Create
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortDescription,Description,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,ParentCategoryId,Order,CultureCode,LocalizationId")] ProductCategory productcategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _pbl.AddProductCategory(productcategory);
                }
                catch (ProductCategoryException exc)
                {
                    ClientNotify(exc.Message, Resources.Resources.ErrorText_Error);
                    return View(productcategory);
                }
                return RedirectToAction("AdminIndex");
            }

            return View(productcategory);
        }

        // GET: Controllers/ProductCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productcategory = _pbl.GetProductCategoryById(id.Value);
            if (productcategory == null)
            {
                return HttpNotFound();
            }

            return View(productcategory);
        }

        // POST: Controllers/ProductCategories/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortDescription,Description,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,ParentCategoryId,Order,CultureCode,LocalizationId")] ProductCategory productcategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _pbl.UpdateProductCategory(productcategory);
                }
                catch (ProductCategoryException exc)
                {
                    ClientNotify(exc.Message, Resources.Resources.ErrorText_Error);
                    return View(productcategory);
                }
                return RedirectToAction("AdminIndex");
            }

            return View(productcategory);
        }

        // GET: Controllers/ProductCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productcategory = _pbl.GetProductCategoryById(id.Value);
            if (productcategory == null)
            {
                return HttpNotFound();
            }

            return View(productcategory);
        }

        // POST: Controllers/ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductCategory productcategory = _pbl.GetProductCategoryById(id);
            _pbl.RemoveProductCategory(productcategory);
            return RedirectToAction("AdminIndex");
        }

    }
}