using System;
using System.Net;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

using BAP.Common;
using BAP.Lookups;
using BAP.Log;
using BAP.UI.Controllers;
using BAP.FileSystem;
using BAP.DAL;

using BAP.eCommerce.DAL.Entities;
using BAP.eCommerce.BL;
using BAP.Web.Areas.eCommerce.Models;

namespace BAP.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator,Supervisor")]
    public class DiscountCouponsController : BaseController<DiscountCoupon>
    {
        private readonly IDiscountCouponBL _pbl;

        public DiscountCouponsController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<DiscountCoupon>(configHelper, context), new eCommerceBusinessLayer(lookupEngine, fileProc, configHelper, context, logger))
        {
            _pbl = (IDiscountCouponBL)_bl;
        }


        // GET: Controllers/DiscountCoupons/AdminIndex     
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

            return View(_pbl.SearchDiscountCoupons(searchString, sortOrder, pageNumber, pageSize));
        }

        // GET: Controllers/DiscountCoupons/AdminDetails/5       
        public ActionResult AdminDetails(int id)
        {
            DiscountCoupon discountcoupon = _pbl.GetDiscountCouponById(id);
            if (discountcoupon == null)
            {
                return HttpNotFound();
            }
            ViewBag.CriteriaFields = CreateCriteriaViewModel(discountcoupon.ApplyCriteria);
            if (TempData["CurrentTab"] != null)
            {
                ViewBag.CurrentTab = TempData["CurrentTab"].ToString();
            }
            return View(discountcoupon);
        }
        
        // GET: Controllers/DiscountCoupons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Controllers/DiscountCoupons/Create
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductsApplied,Id,Name,ShortDescription,Description,Enabled,IsPercent,Amount,Code,ExtraCodesText,DiscountType,ValidFrom,ValidTo,Priority,AllowLowerPriority,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,CustomData,BuyXAmount,GetYAmount,CultureCode,LocalizationId")] DiscountCoupon discountcoupon)
        {
            if (ModelState.IsValid)
            {
                _pbl.AddDiscountCoupon(discountcoupon);
                return RedirectToAction("AdminIndex");
            }

            return View(discountcoupon);
        }

        // GET: Controllers/DiscountCoupons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiscountCoupon discountcoupon = _pbl.GetDiscountCouponById(id.Value);
            if (discountcoupon == null)
            {
                return HttpNotFound();
            }

            return View(discountcoupon);
        }

        // POST: Controllers/DiscountCoupons/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductsApplied,Id,Name,ShortDescription,Description,Enabled,IsPercent,Amount,Code,ExtraCodesText,DiscountType,ValidFrom,ValidTo,Priority,AllowLowerPriority,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,CustomData,BuyXAmount,GetYAmount,CultureCode,LocalizationId")] DiscountCoupon discountcoupon)
        {
            if (ModelState.IsValid)
            {
                _pbl.UpdateDiscountCoupon(discountcoupon);
                return RedirectToAction("AdminIndex");
            }

            return View(discountcoupon);
        }

        // GET: Controllers/DiscountCoupons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiscountCoupon discountcoupon = _pbl.GetDiscountCouponById(id.Value);
            if (discountcoupon == null)
            {
                return HttpNotFound();
            }

            return View(discountcoupon);
        }

        // POST: Controllers/DiscountCoupons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiscountCoupon discountcoupon = _pbl.GetDiscountCouponById(id);
            _pbl.RemoveDiscountCoupon(discountcoupon);
            return RedirectToAction("AdminIndex");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult MultirowActionForm(int id, int[] checkRow, string selectedAction, string selectedProducts)
        {
            DiscountCoupon discountcoupon = _pbl.GetDiscountCouponById(id);
            if (discountcoupon != null)
            {
                if (selectedAction == "delete" && checkRow != null)
                {
                    _pbl.RemoveProductFromCoupon(discountcoupon, checkRow);
                }
                if (selectedAction == "add" && !string.IsNullOrEmpty(selectedProducts))
                {
                    try
                    {
                        var ids = selectedProducts.Split(",".ToCharArray()).Select(a => Convert.ToInt32(a)).ToArray();
                        _pbl.AddProductToCoupon(discountcoupon, ids);
                    }
                    catch (Exception exc)
                    {
                        _logger.LogException("DiscountCouponsController", "MultirowActionForm", exc);
                    }
                }
            }

            return RedirectToAction("AdminDetails", new { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult CriteriaActionForm(int id)
        {
            DiscountCoupon discountcoupon = _pbl.GetDiscountCouponById(id);
            if (discountcoupon == null)
            {
                return HttpNotFound();
            }
            if (discountcoupon != null)
            {
                var viewFields = CreateCriteriaViewModel(discountcoupon.ApplyCriteria);
                List<CriteriaFieldDTO> dtoList = null;
                foreach (var field in viewFields)
                {
                    var fieldNameBase = field.Id;
                    if (!Request["oper" + fieldNameBase].IsNullOrEmpty() && !Request["val" + fieldNameBase].IsNullOrEmpty())
                    {
                        var oper = CriteriaCompareOperator.None;
                        Enum.TryParse(Request["oper" + fieldNameBase], out oper);
                        var dto = new CriteriaFieldDTO
                        {
                            Id = field.Id,
                            FieldName = field.FieldName,
                            Operator = oper,
                            Values = Request["val" + fieldNameBase].Split(",".ToCharArray()).ToList()
                        };

                        if (dto.Operator != CriteriaCompareOperator.None && dto.Values.Any(a => !a.IsNullOrEmpty()))
                        {
                            if (dtoList == null)
                                dtoList = new List<CriteriaFieldDTO>();
                            dtoList.Add(dto);
                        }
                    }
                }

                if (dtoList != null)
                {
                    discountcoupon.ApplyCriteria.InitFromDTOArray(dtoList);
                    _pbl.UpdateDiscountCoupon(discountcoupon);
                }

                ViewBag.CriteriaFields = viewFields;
            }
            TempData["CurrentTab"] = "criteria";
            return RedirectToAction("AdminDetails", new { id = id });
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteProduct(int id, int productId)
        {
            DiscountCoupon discountcoupon = _pbl.GetDiscountCouponById(id);
            if (discountcoupon != null && discountcoupon.ProductsApplied != null)
            {
                _pbl.RemoveProductFromCoupon(discountcoupon, productId);
            }
            return RedirectToAction("AdminDetails", new { id = id });
        }
        #region private methods
        private List<DiscountCriteriaViewModel> CreateCriteriaViewModel(ICriteria<ShoppingCart> applyCriteria)
        {
            if (applyCriteria == null || applyCriteria.Fields == null || applyCriteria.Fields.Count == 0)
                return null;

            var result = new List<DiscountCriteriaViewModel>();
            ProcessCriteriaFieldsArray(applyCriteria.Fields, result, null, 0);
            return result;
        }

        private void ProcessCriteriaFieldsArray(List<CriteriaField> fields, List<DiscountCriteriaViewModel> result, DiscountCriteriaViewModel parentModel, int level)
        {
            foreach (var field in fields)
            {
                List<string> values = null;
                if (field.CompareValues != null)
                    values = field.CompareValues.Select(a => a.ToString()).ToList<string>();

                var viewModel = new DiscountCriteriaViewModel()
                {
                    Id = field.Id,
                    FieldName = field.Name,
                    FieldCaption = field.Caption,
                    FieldType = field.FieldType,
                    DataType = field.DataType,
                    AllowedOperators = field.AllowedOperators,
                    Level = level,
                    Operator = field.CompareOperator,
                    Values = values,
                    ObjectLookup = field.ObjectLookupItems
                };
                result.Add(viewModel);
                if (field.ChildFields != null && field.ChildFields.Count > 0)
                    ProcessCriteriaFieldsArray(field.ChildFields, result, viewModel, level + 1);
            }
        }
        #endregion
    }
}