using System;
using System.Net;
using System.Web.Mvc;

using BAP.Common;
using BAP.DAL.Entities;
using BAP.Lookups;
using BAP.Log;
using BAP.DAL;
using BAP.UI.Controllers;

namespace BAP.Web.Areas.Administration.Controllers
{
    //Every controller is created with restricted access be default. Any public action has to be created explicitly.
    [Authorize(Roles = "Administrator")]
    public class ModulesController : BaseController<Module>
    {
        public ModulesController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<Module>(configHelper, context))
        {
        }

        // GET: Modules
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            int pageNumber = 1;
            int pageSize = _configHelper.FakeMaxPageSize;

            EntityPagingAttribute pageAttr = (EntityPagingAttribute)Attribute.GetCustomAttribute(typeof(Module), typeof(EntityPagingAttribute));
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
            InitIndexViewData(sortOrder, currentFilter);
            return View(_bl.SearchModules(searchString, sortOrder, pageNumber, pageSize));
        }

        // GET: Controllers/Modules/5     
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var module = _bl.GetModuleById(id.Value);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // GET: Modules/Create
        public ActionResult Create()
        {
            var module = new Module { GlobalId = Guid.NewGuid() };
            return View(module);
        }

        // POST: Modules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Name,ShortDescription,Description,Enabled,GlobalId,Roles,BitMask,TenantUnit,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] Module module)
        {
            if (ModelState.IsValid)
            {
                _bl.AddModule(module);
                return RedirectToAction("Index");
            }

            return View(module);
        }

        // GET: Modules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = _bl.GetModuleById(id.Value);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // POST: Modules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortDescription,Description,Enabled,GlobalId,Roles,BitMask,TenantUnit,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] Module module)
        {
            if (ModelState.IsValid)
            {
                _bl.UpdateModule(module);
                return RedirectToAction("Index");
            }
            return View(module);
        }

        // GET: Modules/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = _bl.GetModuleById(id.Value);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            Module module = _bl.GetModuleById(id);
            _bl.RemoveModule(module);
            return RedirectToAction("Index");
        }

    }
}
