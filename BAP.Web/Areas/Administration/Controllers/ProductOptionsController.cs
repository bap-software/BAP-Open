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
using System.Linq;
using Newtonsoft.Json.Linq;
using BAP.eCommerce.Common.Exceptions;

namespace BAP.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator,ContentManager,Supervisor")]
    public class ProductOptionsController : BaseController<ProductOption>
    {
        private readonly IProductOptionBL _pbl;

        public ProductOptionsController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<ProductOption>(configHelper, context), new eCommerceBusinessLayer(lookupEngine, fileProc, configHelper, context, logger))
        {
            _pbl = (IProductOptionBL)_bl;
        }
        
        // GET: Controllers/ProductOptions/AdminIndex     
        public ActionResult AdminIndex(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int rowsPerPage = GetRealPageSize(pageSize);

            InitIndexViewData(sortOrder, currentFilter);

            return View(_pbl.SearchProductOptions(currentFilter, sortOrder, pageNumber, rowsPerPage));
        }

        // GET: Controllers/ProductOptions/AdminDetails/5       
        public ActionResult AdminDetails(int id)
        {
            ProductOption productoption = _pbl.GetProductOptionById(id);
            if (productoption == null)
            {
                return HttpNotFound();
            }
            return View(productoption);
        }
        
        // GET: Controllers/ProductOptions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Controllers/ProductOptions/Create
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductOptionItems,Id,Name,ShortDescription,Description,Type,UserControl,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,Enabled,CultureCode,LocalizationId")] ProductOption productoption)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _pbl.AddProductOption(productoption);
                    return RedirectToAction("AdminIndex");
                }
                catch (ProductOptionException exc)
                {
                    ClientNotify(exc.Message, Resources.Resources.ErrorText_Error);
                }
            }

            return View(productoption);
        }

        // GET: Controllers/ProductOptions/Edit/5
        public ActionResult Edit(int? id, bool? isModal = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOption productoption = _pbl.GetProductOptionById(id.Value);
            if (productoption == null)
            {
                return HttpNotFound();
            }

            if (isModal != null && isModal.Value)
            {
                ViewBag.IsModal = true;
            }

            return View(productoption);
        }

        // POST: Controllers/ProductOptions/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductOptionItems,Id,Name,ShortDescription,Description,Type,UserControl,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,Enabled,CultureCode,LocalizationId")] ProductOption productoption, bool? isModal = false)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _pbl.UpdateProductOption(productoption);
                    if (isModal == null || !isModal.Value)
                        return RedirectToAction("AdminIndex");
                    else
                    {
                        ViewBag.IsModal = true;
                        ViewBag.IsModalClose = true;
                    }
                }
                catch (ProductOptionException exc)
                {
                    ClientNotify(exc.Message, Resources.Resources.ErrorText_Error);
                }

            }
            else if (isModal != null && isModal.Value)
            {
                ViewBag.IsModal = true;
            }

            return View(productoption);
        }

        // GET: Controllers/ProductOptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOption productoption = _pbl.GetProductOptionById(id.Value);
            if (productoption == null)
            {
                return HttpNotFound();
            }

            return View(productoption);
        }

        // POST: Controllers/ProductOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductOption productoption = _pbl.GetProductOptionById(id);
            _pbl.RemoveProductOption(productoption);
            return RedirectToAction("AdminIndex");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,ContentManager")]
        public ActionResult MultirowActionForm(int id, string selectedAction, string selectedItems, string itemRowData)
        {
            ProductOption productOption = _pbl.GetProductOptionById(id);
            if (productOption != null)
            {
                if (selectedAction == "add")
                {
                    _pbl.CreateSingleItem(productOption);
                }
                else if (selectedAction == "delete" && !selectedItems.IsNullOrEmpty())
                {
                    var ids = selectedItems.Split(",".ToCharArray()).Select(a => Convert.ToInt32(a)).ToArray();
                    _pbl.RemoveItemFromOption(productOption, ids);
                }
                else if (selectedAction == "delete-item" && !selectedItems.IsNullOrEmpty())
                {
                    var i = 0;
                    Int32.TryParse(selectedItems, out i);
                    _pbl.RemoveItemFromOption(productOption, i);
                }
                else if (selectedAction == "save" && !itemRowData.IsNullOrEmpty())
                {
                    dynamic item = JObject.Parse(itemRowData);
                    SaveItem(productOption, item);
                }
                else if (selectedAction == "save-items" && !itemRowData.IsNullOrEmpty())
                {
                    dynamic data = JArray.Parse(itemRowData);
                    foreach (var item in data)
                    {
                        SaveItem(productOption, item);
                    }
                }
            }

            return RedirectToAction("AdminDetails", new { id = id });
        }

        private void SaveItem(ProductOption productOption, dynamic item)
        {
            int itemId = item.Id;
            string name = item.Name;
            decimal priceAdded = item.PriceAdded;
            string shortDescr = item.ShortDescription;
            int? relatedProductId = !string.IsNullOrWhiteSpace(item.RelatedProductId.Value) ? item.RelatedProductId : null;
            string descr = item.Description;
            try
            {
                _pbl.UpdateOptionItem(productOption, itemId, name, priceAdded, shortDescr, relatedProductId, descr);
            }
            catch (ProductOptionException exc)
            {
                ClientNotify(exc.Message, Resources.Resources.ErrorText_Error);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,ContentManager")]
        public ActionResult ProductsActionForm(int id, string selectedFormAction, string selectedProducts)
        {
            ProductOption productOption = _pbl.GetProductOptionById(id);
            if (productOption != null && !string.IsNullOrEmpty(selectedProducts))
            {
                var ids = selectedProducts.Split(",".ToCharArray()).Select(a => Convert.ToInt32(a)).ToArray();
                if (selectedFormAction == "delete")
                {
                    _pbl.RemoveProductFromOption(productOption, ids);
                }
                if (selectedFormAction == "add")
                {
                    try
                    {
                        _pbl.AddProductToOption(productOption, ids);
                    }
                    catch (ProductOptionException exc)
                    {
                        ClientNotify(exc.Message, Resources.Resources.ErrorText_Error);
                    }
                }
            }

            return RedirectToAction("AdminDetails", new { id = id });
        }
        
    }
}