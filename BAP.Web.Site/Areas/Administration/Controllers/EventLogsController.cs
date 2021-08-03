using System.Net;
using System.Web.Mvc;
using System.Collections.Generic;

using BAP.Common;
using BAP.Lookups;
using BAP.Log;
using BAP.DAL.Entities;
using BAP.DAL;
using BAP.UI.Controllers;
using BAP.ContentManagement;

namespace BAP.Web.Areas.Administration.Controllers
{
    //Every controller is created with restricted access be default. Any public action has to be created explicitly.
    [Authorize(Roles = "Administrator,ContentManager,Supervisor,User")]
    public class EventLogsController : BaseController<EventLog>, IContentExtendable
    {	    
		public EventLogsController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<EventLog>(configHelper, context))
        {
        }

        public override ActionResult IndexAll(string sortOrder = "", string currentFilter = "")
        {
            InitIndexViewData(sortOrder, currentFilter);
            return View(_bl.GetAllEventsList(currentFilter, sortOrder));
        }        

        // GET: EventLogs
        public ActionResult Index(string sortOrder, string currentFilter, int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int rowsPerPage = GetRealPageSize(pageSize);

            InitIndexViewData(sortOrder, currentFilter);
            return View(_bl.SearchEventLogs(currentFilter, sortOrder, pageNumber, rowsPerPage));
        }
        

        // GET: EventLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventLog eventLog = _bl.GetEventLogById(id.Value);
            if (eventLog == null)
            {
                return HttpNotFound();
            }
            return View(eventLog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult MultirowActionForm(int[] checkRow, string selectedAction, string currentFilter, string currentSort, int? page, int? pageSize)
        {
            if(selectedAction == "delete" && checkRow != null)
            {
                var logList = new List<EventLog>();
                for(int i = 0; i < checkRow.Length; i++)
                {
                    var log = _bl.GetEventLogById(checkRow[i]);
                    if (log != null)
                        logList.Add(log);
                }
                _bl.RemoveEventLog(logList.ToArray());
            }

            return RedirectToAction("Index", new { sortOrder = currentSort, currentFilter, page, pageSize});
        }

        // GET: EventLogs/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventLog eventLog = _bl.GetEventLogById(id.Value);
            if (eventLog == null)
            {
                return HttpNotFound();
            }
            return View(eventLog);
        }

        // POST: EventLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            EventLog eventLog = _bl.GetEventLogById(id);
            
            _bl.RemoveEventLog(eventLog);
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
