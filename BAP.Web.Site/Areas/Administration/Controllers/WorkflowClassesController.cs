using System;
using System.Net;
using System.Web.Mvc;

using BAP.Common;
using BAP.DAL.Entities;
using BAP.BL;
using BAP.Lookups;
using BAP.Log;
using BAP.DAL;
using BAP.UI.Controllers;


namespace BAP.Web.Areas.Administration.Controllers
{
    //Every controller is created with restricted access be default. Any public action has to be created explicitly.
    [Authorize(Roles = "Administrator")]
    public class WorkflowClassesController : BaseController<WorkflowClass>
    {
	    public WorkflowClassesController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<WorkflowClass>(configHelper, context))
        {
        }

        // GET: Administration/WorkflowClasses
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            int pageNumber = 1;
            int pageSize = _configHelper.FakeMaxPageSize;
            
            EntityPagingAttribute pageAttr = (EntityPagingAttribute)Attribute.GetCustomAttribute(typeof(WorkflowClass), typeof(EntityPagingAttribute));
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

            return View(_bl.SearchWorkflowClasses(searchString, sortOrder, pageNumber, pageSize));
        }

        // GET: Administration/WorkflowClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkflowClass workflowClass = _bl.GetWorkflowClassById(id.Value);
            if (workflowClass == null)
            {
                return HttpNotFound();
            }
            return View(workflowClass);
        }

        // GET: Administration/WorkflowClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/WorkflowClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortDescription,Description,BapEntityAssembly,BapEntityClass,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,AllowedRoles")] WorkflowClass workflowClass)
        {
            if (ModelState.IsValid)
            {
                                
                _bl.AddWorkflowClasses(workflowClass);
                return RedirectToAction("Index");
            }

            return View(workflowClass);
        }

        // GET: Administration/WorkflowClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkflowClass workflowClass = _bl.GetWorkflowClassById(id.Value);
            if (workflowClass == null)
            {
                return HttpNotFound();
            }
            return View(workflowClass);
        }

        // POST: Administration/WorkflowClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortDescription,Description,BapEntityAssembly,BapEntityClass,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,AllowedRoles")] WorkflowClass workflowClass)
        {
            if (ModelState.IsValid)
            {            
                _bl.UpdateWorkflowClasses(workflowClass);
                return RedirectToAction("Index");
            }
            return View(workflowClass);
        }

        // GET: Administration/WorkflowClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkflowClass workflowClass = _bl.GetWorkflowClassById(id.Value);
            if (workflowClass == null)
            {
                return HttpNotFound();
            }
            return View(workflowClass);
        }

        // POST: Administration/WorkflowClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkflowClass workflowClass = _bl.GetWorkflowClassById(id);
            
            _bl.RemoveWorkflowClasses(workflowClass);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
							((System.IDisposable)_bl).Dispose();
			            }
            base.Dispose(disposing);
        }        
    }
}
