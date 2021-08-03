using BAP.BL;
using BAP.BL.Tasks;
using BAP.Common;
using BAP.DAL;
using BAP.DAL.Entities;
using BAP.Log;
using BAP.Lookups;
using BAP.UI.Controllers;
using System;
using System.Net;
using System.Web.Mvc;

namespace BAP.Web.Areas.Administration.Controllers
{
    //Every controller is created with restricted access be default. Any public action has to be created explicitly.
    [Authorize(Roles = @"Administrator")]
    public class ScheduledTasksController : BaseController<ScheduledTask>
    {
        public ScheduledTasksController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<ScheduledTask>(configHelper, context))
        {
        }

        // GET: ScheduledTasks
        public ActionResult Index(string sortOrder, string currentFilter, int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int rowsPerPage = GetRealPageSize(pageSize);

            InitIndexViewData(sortOrder, currentFilter);

            return View(_bl.SearchScheduledTasks(currentFilter, sortOrder, pageNumber, rowsPerPage));
        }

        // GET: ScheduledTasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduledTask ScheduledTask = _bl.GetScheduledTaskById(id.Value);
            if (ScheduledTask == null)
            {
                return HttpNotFound();
            }
            return View(ScheduledTask);
        }

        // GET: ScheduledTasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScheduledTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortName,Description,UniqueId,Recurring,Running,Executions,LastRun,NextRun,Interval,JobClass,JobAssembly,JobData,LastResult,LastMessage,Enabled,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] ScheduledTask ScheduledTask)
        {
            if (ModelState.IsValid)
            {
                _bl.AddScheduledTask(ScheduledTask);
                return RedirectToAction("Index");
            }

            return View(ScheduledTask);
        }

        // GET: ScheduledTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduledTask ScheduledTask = _bl.GetScheduledTaskById(id.Value);            
            if (ScheduledTask == null)
            {
                return HttpNotFound();
            }
            var taskEngine = new TaskEngine();
            ViewBag.CustomDataJsonExample = taskEngine.GetTaskCustomDataJsonExample(ScheduledTask);
            return View(ScheduledTask);
        }

        // POST: ScheduledTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortName,Description,UniqueId,Recurring,Running,Executions,LastRun,NextRun,Interval,JobClass,JobAssembly,JobData,LastResult,LastMessage,Enabled,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] ScheduledTask ScheduledTask)
        {
            if (ModelState.IsValid)
            {
                _bl.UpdateScheduledTask(ScheduledTask);
                return RedirectToAction("Index");
            }
            return View(ScheduledTask);
        }

        // GET: ScheduledTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduledTask ScheduledTask = _bl.GetScheduledTaskById(id.Value);
            if (ScheduledTask == null)
            {
                return HttpNotFound();
            }
            return View(ScheduledTask);
        }

        // POST: ScheduledTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScheduledTask ScheduledTask = _bl.GetScheduledTaskById(id);
            _bl.RemoveScheduledTask(ScheduledTask);
            return RedirectToAction("Index");
        }
    }
}