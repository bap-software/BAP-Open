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
    public class WorkflowActionAttributesController : BaseController<WorkflowActionAttribute>
    {		
        public WorkflowActionAttributesController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<WorkflowActionAttribute>(configHelper, context))
        {
        }

        // GET: Administration/WorkflowActionAttributes
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            int pageNumber = 1;
            int pageSize = _configHelper.FakeMaxPageSize;
            
            EntityPagingAttribute pageAttr = (EntityPagingAttribute)Attribute.GetCustomAttribute(typeof(WorkflowActionAttribute), typeof(EntityPagingAttribute));
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
            
            return View(_bl.SearchWorkflowActionAttributes(searchString, sortOrder, pageNumber, pageSize));
        }

        // GET: Administration/WorkflowActionAttributes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkflowActionAttribute workflowActionAttribute = _bl.GetWorkflowActionAttributeById(id.Value);
            if (workflowActionAttribute == null)
            {
                return HttpNotFound();
            }
            return View(workflowActionAttribute);
        }

        // GET: Administration/WorkflowActionAttributes/Create
        public ActionResult Create()
        {
            ViewBag.AtributeType = new SelectList(_bl.GetAttributeTypes(), "Id", "Name");
            ViewBag.AtributeDirection = new SelectList(_bl.GetAttributeDirections(), "Id", "Name");
            ViewBag.WorkflowActionId = new SelectList(((IWorkflowActionBL)_bl).GetAllWorkflowActions(), "Id", "Name");
            return View();
        }

        // POST: Administration/WorkflowActionAttributes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AtributeType,AtributeDirection,Name,ShortDescription,Description,DataSource,DefaultValue,IsPublic,IsVisible,IsReadonly,WorkflowActionId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] WorkflowActionAttribute workflowActionAttribute)
        {
            if (ModelState.IsValid)
            {
                _bl.AddWorkflowActionAttributes(workflowActionAttribute);
                return RedirectToAction("Details", "WorkflowActions", new { id = workflowActionAttribute.WorkflowActionId });
            }

            ViewBag.AtributeType = new SelectList(_bl.GetAttributeTypes(), "Id", "Name", workflowActionAttribute.AtributeType);
            ViewBag.AtributeDirection = new SelectList(_bl.GetAttributeDirections(), "Id", "Name");
            ViewBag.WorkflowActionId = new SelectList(((IWorkflowActionBL)_bl).GetAllWorkflowActions(), "Id", "Name", workflowActionAttribute.WorkflowActionId);
            return RedirectToAction("Details", "WorkflowActions", new { id = workflowActionAttribute.WorkflowActionId });
        }

        // GET: Administration/WorkflowActionAttributes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkflowActionAttribute workflowActionAttribute = _bl.GetWorkflowActionAttributeById(id.Value);
            if (workflowActionAttribute == null)
            {
                return HttpNotFound();
            }
            ViewBag.AtributeType = new SelectList(_bl.GetAttributeTypes(), "Id", "Name", workflowActionAttribute.AtributeType);
            ViewBag.AtributeDirection = new SelectList(_bl.GetAttributeDirections(), "Id", "Name");
            ViewBag.WorkflowActionId = new SelectList(((IWorkflowActionBL)_bl).GetAllWorkflowActions(), "Id", "Name", workflowActionAttribute.WorkflowActionId);
            return View(workflowActionAttribute);
        }

        // POST: Administration/WorkflowActionAttributes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AtributeType,AtributeDirection,Name,ShortDescription,Description,DataSource,DefaultValue,IsPublic,IsVisible,IsReadonly,WorkflowActionId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] WorkflowActionAttribute workflowActionAttribute)
        {
            if (ModelState.IsValid)
            {            
                _bl.UpdateWorkflowActionAttributes(workflowActionAttribute);
                return RedirectToAction("Details", "WorkflowActions", new { id = workflowActionAttribute.WorkflowActionId });
            }
            ViewBag.AtributeType = new SelectList(_bl.GetAttributeTypes(), "Id", "Name", workflowActionAttribute.AtributeType);
            ViewBag.AtributeDirection = new SelectList(_bl.GetAttributeDirections(), "Id", "Name");
            ViewBag.WorkflowActionId = new SelectList(((IWorkflowActionBL)_bl).GetAllWorkflowActions(), "Id", "Name", workflowActionAttribute.WorkflowActionId);
            return RedirectToAction("Details", "WorkflowActions", new { id = workflowActionAttribute.WorkflowActionId });
        }

        // GET: Administration/WorkflowActionAttributes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkflowActionAttribute workflowActionAttribute = _bl.GetWorkflowActionAttributeById(id.Value);
            if (workflowActionAttribute == null)
            {
                return HttpNotFound();
            }
            return View(workflowActionAttribute);
        }

        // POST: Administration/WorkflowActionAttributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkflowActionAttribute workflowActionAttribute = _bl.GetWorkflowActionAttributeById(id);
            var workflowActionId = workflowActionAttribute.WorkflowActionId;
            _bl.RemoveWorkflowActionAttributes(workflowActionAttribute);
            return RedirectToAction("Details", "WorkflowActions", new { id = workflowActionId });
        }
 
    }
}
