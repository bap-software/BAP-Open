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
    public class WorkflowActionsController : BaseController<WorkflowAction>
    {	    
		public WorkflowActionsController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<WorkflowAction>(configHelper, context))
        {
        }

        // GET: Administration/WorkflowActions
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            int pageNumber = 1;
            int pageSize = _configHelper.FakeMaxPageSize;
            
            EntityPagingAttribute pageAttr = (EntityPagingAttribute)Attribute.GetCustomAttribute(typeof(WorkflowAction), typeof(EntityPagingAttribute));
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
            
            return View(_bl.SearchWorkflowActions(searchString, sortOrder, pageNumber, pageSize));
        }

        // GET: Administration/WorkflowActions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkflowAction workflowAction = _bl.GetWorkflowActionById(id.Value);
            if (workflowAction == null)
            {
                return HttpNotFound();
            }
            ViewBag.AtributeTypes = _bl.GetAttributeTypes();
            ViewBag.AtributeDirections = _bl.GetAttributeDirections();
            return View(workflowAction);
        }

        // GET: Administration/WorkflowActions/Create
        public ActionResult Create()
        {
            ViewBag.ActionType = new SelectList(_bl.GetActionTypes(), "Id", "Name");
            ViewBag.WorkflowId = new SelectList(((IWorkflowClassBL)_bl).GetAllWorkflowClasses(), "Id", "Name");
            return View();
        }

        // POST: Administration/WorkflowActions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ActionType,Name,ShortDescription,Description,ActionAssembly,ActionClass,WorkflowId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] WorkflowAction workflowAction)
        {
            if (ModelState.IsValid)
            {
                _bl.AddWorkflowActions(workflowAction);
                return RedirectToAction("Index");
            }

            ViewBag.ActionType = new SelectList(_bl.GetActionTypes(), "Id", "Name", workflowAction.ActionType);
            ViewBag.WorkflowId = new SelectList(((IWorkflowClassBL)_bl).GetAllWorkflowClasses(), "Id", "Name", workflowAction.WorkflowId);
            return View(workflowAction);
        }

        // GET: Administration/WorkflowActions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkflowAction workflowAction = _bl.GetWorkflowActionById(id.Value);
            if (workflowAction == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActionType = new SelectList(_bl.GetActionTypes(), "Id", "Name", workflowAction.ActionType);
            ViewBag.WorkflowId = new SelectList(((IWorkflowClassBL)_bl).GetAllWorkflowClasses(), "Id", "Name", workflowAction.WorkflowId);
            return View(workflowAction);
        }

        // POST: Administration/WorkflowActions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ActionType,Name,ShortDescription,Description,ActionAssembly,ActionClass,WorkflowId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] WorkflowAction workflowAction)
        {
            if (ModelState.IsValid)
            {            
                _bl.UpdateWorkflowActions(workflowAction);
                return RedirectToAction("Index");
            }
            ViewBag.ActionType = new SelectList(_bl.GetActionTypes(), "Id", "Name", workflowAction.ActionType);
            ViewBag.WorkflowId = new SelectList(((IWorkflowClassBL)_bl).GetAllWorkflowClasses(), "Id", "Name", workflowAction.WorkflowId);
            return View(workflowAction);
        }

        // GET: Administration/WorkflowActions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkflowAction workflowAction = _bl.GetWorkflowActionById(id.Value);
            if (workflowAction == null)
            {
                return HttpNotFound();
            }
            return View(workflowAction);
        }

        // POST: Administration/WorkflowActions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkflowAction workflowAction = _bl.GetWorkflowActionById(id);
            
            _bl.RemoveWorkflowActions(workflowAction);
            return RedirectToAction("Index");
        }    
    }
}
