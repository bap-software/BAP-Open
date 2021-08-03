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
    public class WorkflowStagesController : BaseController<WorkflowStage>
    {
		public WorkflowStagesController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<WorkflowStage>(configHelper, context))
        {
        }

        // GET: Administration/WorkflowStages
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            int pageNumber = 1;
            int pageSize = _configHelper.FakeMaxPageSize;
            
            EntityPagingAttribute pageAttr = (EntityPagingAttribute)Attribute.GetCustomAttribute(typeof(WorkflowStage), typeof(EntityPagingAttribute));
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
            
            return View(_bl.SearchWorkflowStages(searchString, sortOrder, pageNumber, pageSize));
        }

        // GET: Administration/WorkflowStages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkflowStage workflowStage = _bl.GetWorkflowStageById(id.Value);
            if (workflowStage == null)
            {
                return HttpNotFound();
            }
            return View(workflowStage);
        }

        // GET: Administration/WorkflowStages/Create
        public ActionResult Create()
        {
            ViewBag.StageType = new SelectList(_bl.GetStageTypes(), "Id", "Name");
            ViewBag.WorkflowId = new SelectList(((IWorkflowClassBL)_bl).GetAllWorkflowClasses(), "Id", "Name");
            return View();
        }

        // POST: Administration/WorkflowStages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StageType,Name,ShortDescription,Description,WorkflowId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] WorkflowStage workflowStage)
        {
            if (ModelState.IsValid)
            {
                                
                _bl.AddWorkflowStages(workflowStage);
                return RedirectToAction("Index");
            }

            ViewBag.StageType = new SelectList(_bl.GetStageTypes(), "Id", "Name", workflowStage.StageType);
            ViewBag.WorkflowId = new SelectList(((IWorkflowClassBL)_bl).GetAllWorkflowClasses(), "Id", "Name", workflowStage.WorkflowId);
            return View(workflowStage);
        }

        // GET: Administration/WorkflowStages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkflowStage workflowStage = _bl.GetWorkflowStageById(id.Value);
            if (workflowStage == null)
            {
                return HttpNotFound();
            }

            ViewBag.StageType = new SelectList(_bl.GetStageTypes(), "Id", "Name", workflowStage.StageType);
            ViewBag.WorkflowId = new SelectList(((IWorkflowClassBL)_bl).GetAllWorkflowClasses(), "Id", "Name", workflowStage.WorkflowId);
            return View(workflowStage);
        }

        // POST: Administration/WorkflowStages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StageType,Name,ShortDescription,Description,WorkflowId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] WorkflowStage workflowStage)
        {
            if (ModelState.IsValid)
            {            
                _bl.UpdateWorkflowStages(workflowStage);
                return RedirectToAction("Index");
            }

            ViewBag.StageType = new SelectList(_bl.GetStageTypes(), "Id", "Name", workflowStage.StageType);
            ViewBag.WorkflowId = new SelectList(((IWorkflowClassBL)_bl).GetAllWorkflowClasses(), "Id", "Name", workflowStage.WorkflowId);
            return View(workflowStage);
        }

        // GET: Administration/WorkflowStages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkflowStage workflowStage = _bl.GetWorkflowStageById(id.Value);
            if (workflowStage == null)
            {
                return HttpNotFound();
            }
            return View(workflowStage);
        }

        // POST: Administration/WorkflowStages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkflowStage workflowStage = _bl.GetWorkflowStageById(id);
            
            _bl.RemoveWorkflowStages(workflowStage);
            return RedirectToAction("Index");
        }
   
    }
}
