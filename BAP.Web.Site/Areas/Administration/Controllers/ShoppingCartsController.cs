using System;
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
using BAP.ContentManagement;

namespace BAP.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator,Supervisor")]
    public class ShoppingCartsController : BaseController<ShoppingCart>, IContentExtendable
    {
        private readonly IShoppingCartBL _sbl;

        public ShoppingCartsController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<ShoppingCart>(configHelper, context), new eCommerceBusinessLayer(lookupEngine, fileProc, configHelper, context, logger))
        {
            _sbl = (IShoppingCartBL)_bl;
        }
        
        // GET: Controllers/ShoppingCarts        
        public ActionResult AdminIndex(string sortOrder, string currentFilter, int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int rowsPerPage = GetRealPageSize(pageSize);

            InitIndexViewData(sortOrder, currentFilter);

            return View(_sbl.SearchAdminShoppingCarts(currentFilter, sortOrder, pageNumber, rowsPerPage));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult MultirowActionForm(int[] checkRow, string selectedAction, string currentFilter, string currentSort, int? page, int? pageSize)
        {
            if (selectedAction == "delete" && checkRow != null)
            {
                var scList = new List<ShoppingCart>();
                for (int i = 0; i < checkRow.Length; i++)
                {
                    var sc = _sbl.GetShoppingCartWithProductsById(checkRow[i]);
                    if (sc != null)
                        scList.Add(sc);
                }
                _sbl.RemoveShoppingCart(scList.ToArray());
            }

            return RedirectToAction("AdminIndex", new { sortOrder = currentSort, currentFilter = currentFilter, page = page, pageSize = pageSize });
        }
        
        // GET: Controllers/ShoppingCarts/Details/5        
        public ActionResult AdminDetails(int id)
        {
            ShoppingCart shoppingcart = _sbl.GetAdminShoppingCartById(id);
            if (shoppingcart == null)
            {
                return HttpNotFound();
            }
            return View(shoppingcart);
        }
        
        // GET: Controllers/ShoppingCarts/Delete/5
        public ActionResult Delete(int id)
        {
            ShoppingCart shoppingcart = _sbl.GetAdminShoppingCartById(id);
            if (shoppingcart == null)
            {
                return HttpNotFound();
            }

            return View(shoppingcart);
        }

        // POST: Controllers/ShoppingCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoppingCart shoppingcart = _sbl.GetAdminShoppingCartById(id);
            _sbl.RemoveShoppingCart(shoppingcart);
            return RedirectToAction("AdminIndex");
        }

    }
}