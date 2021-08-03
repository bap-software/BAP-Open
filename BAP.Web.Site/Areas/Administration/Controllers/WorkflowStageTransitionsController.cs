using System;
using System.Net;
using System.Linq;
using System.Web.Mvc;

using BAP.Common;
using BAP.DAL.Entities;
using BAP.BL;
using BAP.Lookups;
using BAP.Log;
using BAP.DAL;
using BAP.UI.Controllers;
using BAP.Workflow;

namespace BAP.Web.Areas.Administration.Controllers
{
    //Every controller is created with restricted access be default. Any public action has to be created explicitly.
    [Authorize(Roles = "Administrator")]
    public class WorkflowStageTransitionsController : BaseController<WorkflowStageTransition>
    {
        public WorkflowStageTransitionsController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<WorkflowStageTransition>(configHelper, context))
        {
        }

        // GET: Administration/WorkflowStageTransitions
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            int pageNumber = 1;
            int pageSize = _configHelper.FakeMaxPageSize;

            EntityPagingAttribute pageAttr = (EntityPagingAttribute)Attribute.GetCustomAttribute(typeof(WorkflowStageTransition), typeof(EntityPagingAttribute));
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

            //var workflowStageTransitions = db.WorkflowStageTransitions.Include(w => w.FromStage).Include(w => w.ToStage).Include(w => w.Workflow);
            return View(_bl.SearchWorkflowStageTransitions(searchString, sortOrder, pageNumber, pageSize));
        }

        // GET: Administration/WorkflowStageTransitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkflowStageTransition workflowStageTransition = _bl.GetWorkflowStageTransitionById(id.Value);
            if (workflowStageTransition == null)
            {
                return HttpNotFound();
            }
            return View(workflowStageTransition);
        }

        // GET: Administration/WorkflowStageTransitions/Create
        public ActionResult Create()
        {
            InitDropdownsData(null);
            return View();
        }

        // POST: Administration/WorkflowStageTransitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortDescription,Description,MainImageUrl,WorkflowId,FromStageId,ToStageId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] WorkflowStageTransition workflowStageTransition)
        {
            if (ModelState.IsValid)
            {
                _bl.AddWorkflowStageTransitions(workflowStageTransition);
                return RedirectToAction("Index");
            }
            InitDropdownsData(workflowStageTransition);
            return View(workflowStageTransition);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAction(int id, int actionToTransition)
        {
            WorkflowStageTransition workflowStageTransition = _bl.GetWorkflowStageTransitionById(id);
            if (workflowStageTransition == null)
            {
                return HttpNotFound();
            }

            WorkflowAction workflowAction = ((IWorkflowActionBL)_bl).GetWorkflowActionById(actionToTransition);
            if (workflowAction != null)
            {
                if(workflowAction.ActionType != (int)ActionType.Work)
                {
                    ClientNotify(Resources.Resources.UIText_Workflow_NotWork);
                    return View("Details", workflowStageTransition);
                }

                if (workflowStageTransition.Actions.All(a => a.Id != actionToTransition))
                {
                    _bl.AddWorkflowTranstionAction(id, actionToTransition);
                    workflowStageTransition = _bl.GetWorkflowStageTransitionById(id);
                }
                else
                {
                    ClientNotify(Resources.Resources.UIText_Workflow_AlreadyAdded);
                    return View("Details", workflowStageTransition);
                }
            }

            return View("Details", workflowStageTransition);
        }

        [HttpGet]
        public ActionResult DeleteAction(int id, int actionToDelete)
        {
            WorkflowStageTransition workflowStageTransition = _bl.GetWorkflowStageTransitionById(id);
            if (workflowStageTransition == null)
            {
                return HttpNotFound();
            }
            WorkflowAction workflowAction = ((IWorkflowActionBL)_bl).GetWorkflowActionById(actionToDelete);

            _bl.RemoveWorkflowTranstionAction(workflowStageTransition, workflowAction);
            workflowStageTransition = _bl.GetWorkflowStageTransitionById(id);

            return View("Details", workflowStageTransition);
        }

        // GET: Administration/WorkflowStageTransitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkflowStageTransition workflowStageTransition = _bl.GetWorkflowStageTransitionById(id.Value);
            if (workflowStageTransition == null)
            {
                return HttpNotFound();
            }
            InitDropdownsData(workflowStageTransition);
            return View(workflowStageTransition);
        }


        // POST: Administration/WorkflowStageTransitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortDescription,Description,MainImageUrl,WorkflowId,FromStageId,ToStageId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] WorkflowStageTransition workflowStageTransition)
        {
            if (ModelState.IsValid)
            {
                _bl.UpdateWorkflowStageTransitions(workflowStageTransition);
                return RedirectToAction("Index");
            }
            InitDropdownsData(workflowStageTransition);
            return View(workflowStageTransition);
        }

        // GET: Administration/WorkflowStageTransitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkflowStageTransition workflowStageTransition = _bl.GetWorkflowStageTransitionById(id.Value);
            if (workflowStageTransition == null)
            {
                return HttpNotFound();
            }
            return View(workflowStageTransition);
        }

        // POST: Administration/WorkflowStageTransitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkflowStageTransition workflowStageTransition = _bl.GetWorkflowStageTransitionById(id);

            _bl.RemoveWorkflowStageTransitions(workflowStageTransition);
            return RedirectToAction("Index");
        }

        private void InitDropdownsData(WorkflowStageTransition workflowStageTransition)
        {
            ViewBag.FromStageId = new SelectList(((IWorkflowStageBL)_bl).GetAllWorkflowStages(), "Id", "Name", workflowStageTransition?.FromStageId);
            ViewBag.ToStageId = new SelectList(((IWorkflowStageBL)_bl).GetAllWorkflowStages(), "Id", "Name", workflowStageTransition?.ToStageId);
            ViewBag.WorkflowId = new SelectList(((IWorkflowClassBL)_bl).GetAllWorkflowClasses(), "Id", "Name", workflowStageTransition?.WorkflowId);
        }
    }
}
