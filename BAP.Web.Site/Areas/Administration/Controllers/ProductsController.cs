using System;
using System.Net;
using System.Web.Mvc;

using BAP.Common;
using BAP.Lookups;
using BAP.Log;
using BAP.UI.Controllers;
using BAP.DAL;
using BAP.FileSystem;

using BAP.BL;
using BAP.eCommerce.BL;
using BAP.eCommerce.DAL.Entities;
using BAP.ContentManagement;
using BAP.Web.Areas.Administration.Models;
using BAP.eCommerce.BL.ProductCategoryNodes;
using System.Linq;

namespace BAP.Web.Areas.Administration.Controllers
{
    public static class ProductExtensions
    {
        public static MvcHtmlString ProductCategoryTreeView(this HtmlHelper helper, BAPProductCategoryData data, int treeViewId = 1, string area = "Administration", string controller = "Products", string action = "AdminIndex")
        {
            var result = "<ul class=\"jstree-container-ul jstree-children\" role=\"group\">";
            if (data != null && data.RootNode != null)
            {
                int nodeIndex = 0;
                result += ProcessNode(data, data.RootNode, treeViewId, 1, ref nodeIndex, area, controller, action);
            }
            result += "</ul>";
            return MvcHtmlString.Create(result);
        }

        private static string ProcessNode(BAPProductCategoryData data, ProductCategoryNode node, int treeViewId, int level, ref int index, string area = "", string controller = "", string action = "")
        {
            index++;

            string liCss = node.Expanded ? "jstree-open" : "jstree-closed";
            string selectedCss = "";
            if (node.Children == null || node.Children.Count == 0)
            {
                liCss = "jstree-leaf";
                node.Expanded = false;
            }

            string ariaSelected = "false";
            if (data.CurrentNode == node)
            {
                selectedCss = " jstree-clicked";
                ariaSelected = "true";
            }

            string routeValues = "?categoryId=" + node.NodeId;
            if (!string.IsNullOrWhiteSpace(data.Search))
                routeValues += "&searchString=" + data.Search;
            string navigateUrl = "/" + area + "/" + controller + "/" + action + routeValues;

            string basicId = string.Format("j{0}_{1}", treeViewId, index);
            string result = "<li role=\"treeitem\" aria-selected=\"" + ariaSelected + "\" aria-level=\"" + level.ToString() + "\" aria-labelledby=\"" + basicId + "_anchor\" aria-expanded=\"" + (node.Expanded ? "true" : "false") + "\" id=\"" + basicId + "\" class=\"jstree-node " + liCss + "\">";
            result += "<i class=\"jstree-icon\" role=\"presentation\"></i>";
            result += "<a class=\"jstree-anchor " + selectedCss + " \" href=\"" + navigateUrl + "\" tabindex=\"-1\" id=\"" + basicId + "_anchor\">";
            result += "<i class=\"jstree-icon jstree-themeicon fa fa-folder text-warning fa-lg jstree-themeicon-custom\" role=\"presentation\"></i>";
            result += node.Title;
            result += "</a>";
            if (node.Children != null && node.Children.Count > 0)
            {
                result += "<ul role=\"group\" class=\"jstree-children\">";
                for (int i = 0; i < node.Children.Count; i++)
                {
                    result += ProcessNode(data, node.Children[i], treeViewId, level + 1, ref index, area, controller, action);
                }
                result += "</ul>";
            }

            return result;
        }
    }

    [Authorize(Roles = "Administrator,ContentManager,Supervisor")]
    public class ProductsController : BaseController<Product>, IContentExtendable
    {
        private readonly IProductBL _pbl;
        private readonly IAttachmentBL _abl;
        private readonly IProductCategoryBL _pcbl;
        private readonly IRelatedProductBL _rpbl;

        public ProductsController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IFileProcessor fileProc, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<Product>(configHelper, context), new eCommerceBusinessLayer(lookupEngine, fileProc, configHelper, context, logger))
        {
            _pbl = (IProductBL)_bl;
            _pcbl = (IProductCategoryBL)_bl;
            _rpbl = (IRelatedProductBL)_bl;
            _abl = (IAttachmentBL)_bl;
        }
        
        public ActionResult AdminIndex(string sortOrder, string currentFilter, string searchString, int? categoryId, int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int rowsPerPage = GetRealPageSize(pageSize);

            InitIndexViewData(sortOrder, currentFilter);
            var model = PrepareData(sortOrder, currentFilter, searchString, pageNumber, rowsPerPage, categoryId);

            return View(model);
        }

        public ActionResult AdminProductSearch(string sortOrder, string currentFilter, int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int rowsPerPage = GetRealPageSize(pageSize);

            InitIndexViewData(sortOrder, currentFilter);
            return View(_pbl.SearchProductsAdmin(currentFilter, sortOrder, pageNumber, rowsPerPage));
        }

        public ActionResult AdminDetails(int id)
        {
            Product product = _pbl.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            if (TempData["CurrentTab"] != null)
            {
                ViewBag.CurrentTab = TempData["CurrentTab"].ToString();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create(int categoryId = -1)
        {
            return View(_pbl.CreateProduct(categoryId));
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SKU,Name,ShortDescription,Description,Price,ListPrice,MsrpPrice,MinPrice,MaxPrice,Enabled,PublishFrom,PublishTo,InStoreFrom,PublicStatus,InternalStatus,ImagePath,UID,Weight,Width,Depth,Height,WeightMeasure,SizeMeasure,AvailableItems,CustomData,NeedsShipping,MaxDownloads,ProductType,ParentProductId,ReorderAt,TrackInventory,AllowToRenew,IsTrial,SupplierId,ManufacturerId,ProductCategoryId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,IsFeatured,CustomDetailsUrl,CultureCode,LocalizationId,SourcePrice,IsOnline,BaseOnlineUrl,IsDownloadable")] Product product, int? categoryId = -1)
        {
            if (ModelState.IsValid)
            {
                _pbl.AddProduct(product);
                return RedirectToAction("AdminIndex", new { categoryId = categoryId });
            }
            _pbl.AssignCurrencyToProduct(product);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _pbl.GetProductById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }            
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SKU,Name,ShortDescription,Description,Price,ListPrice,MsrpPrice,MinPrice,MaxPrice,Enabled,PublishFrom,PublishTo,InStoreFrom,PublicStatus,InternalStatus,ImagePath,UID,Weight,Width,Depth,Height,WeightMeasure,SizeMeasure,AvailableItems,CustomData,NeedsShipping,MaxDownloads,ProductType,ParentProductId,ReorderAt,TrackInventory,AllowToRenew,IsTrial,SupplierId,ManufacturerId,ProductCategoryId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,IsFeatured,CustomDetailsUrl,CultureCode,LocalizationId,SourcePrice,IsOnline,BaseOnlineUrl,IsDownloadable")] Product product, int? categoryId = -1)
        {
            if (ModelState.IsValid)
            {
                _pbl.UpdateProduct(product);
                return RedirectToAction("AdminIndex", new { categoryId = categoryId });
            }
            _pbl.AssignCurrencyToProduct(product);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _pbl.GetProductById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int? categoryId = -1)
        {
            Product product = _pbl.GetProductById(id);

            _pbl.RemoveProduct(product);
            return RedirectToAction("AdminIndex", new { categoryId = categoryId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult ProductsActionForm(int id, string selectedFormAction, string selectedProducts)
        {
            Product product = _pbl.GetProductById(id);
            if (product != null && !string.IsNullOrEmpty(selectedProducts))
            {
                var ids = selectedProducts.Split(",".ToCharArray()).Select(a => Convert.ToInt32(a)).ToArray();
                if (selectedFormAction == "delete")
                {
                    _rpbl.RemoveProductFromRelated(product, ids);
                }
                if (selectedFormAction == "add")
                {
                    try
                    {
                        _rpbl.AddProductToRelated(product, ids);
                    }
                    catch (Exception exc)
                    {
                        ClientNotify(exc.Message, Resources.Resources.ErrorText_Error);
                    }
                }
            }

            return RedirectToAction("AdminDetails", new { id });
        }

        #region private methods

        private BAPProductCategoryData PrepareData(string sortOrder, string currentFilter, string searchString, int page, int pageSize, int? id = null)
        {
            //Filter Data
            var categories = _pcbl.GetAllProductCategories();
            if (!string.IsNullOrEmpty(searchString))
                categories = categories.Where(a => a.Name.ToLower().Contains(searchString.ToLower())).ToList();
            var products = _pbl.SearchProductsAdmin(currentFilter, sortOrder, page, pageSize, id.HasValue ? id.Value : 0);
            
            //Prepare category tree
            var data = new BAPProductCategoryData
            {
                RootNode = _pcbl.GetProductCategoryTree(categories), Search = searchString, Products = products
            };

            // if no node found by url - taking default one
            if (data.CurrentNode == null)
            {
                var allNodes = data.GetAllNodes(data.RootNode);
                if (id.GetValueOrDefault() > 0)
                    data.CurrentNode = allNodes.FirstOrDefault(n => n.NodeId == id.GetValueOrDefault());
                else
                    data.CurrentNode = data.RootNode;
            }

            return data;
        }        
        #endregion

    }
}