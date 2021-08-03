using System.Net;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

using BAP.Common;
using BAP.Lookups;
using BAP.Log;
using BAP.DAL.Entities;
using BAP.DAL;
using BAP.UI.Controllers;
using BAP.ContentManagement;
using BAP.FileSystem;

namespace BAP.Web.Areas.Administration.Controllers
{
    //Every controller is created with restricted access be default. Any public action has to be created explicitly.
    [Authorize(Roles = "Administrator,ContentManager,User,Supervisor")]
    public class MessagesController : BaseController<Message>, IContentExtendable
    {
        public MessagesController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<Message>(configHelper, context))
        {            
        }

        public override ActionResult IndexAll(string sortOrder = "", string currentFilter = "")
        {
            InitIndexViewData(sortOrder, currentFilter);
            return View(_bl.GetAllMessagesList(currentFilter, sortOrder));
        }
        
        // GET: Messages
        public ActionResult Index(string sortOrder, string currentFilter, int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int rowsPerPage = GetRealPageSize(pageSize);

            InitIndexViewData(sortOrder, currentFilter);
            return View(_bl.SearchMessages(currentFilter, sortOrder, pageNumber, rowsPerPage));
        }


        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = _bl.GetMessageById(id.Value);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult MultirowActionForm(int[] checkRow, string selectedAction, string currentFilter, string currentSort, int? page, int? pageSize)
        {
            if (selectedAction == "delete" && checkRow != null)
            {
                var logList = new List<Message>();
                for (int i = 0; i < checkRow.Length; i++)
                {
                    var log = _bl.GetMessageById(checkRow[i]);
                    if (log != null)
                        logList.Add(log);
                }
                _bl.RemoveMessage(logList.ToArray());
            }

            return RedirectToAction("Index", new { sortOrder = currentSort, currentFilter, page, pageSize });
        }

        // GET: Messages/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = _bl.GetMessageById(id.Value);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = _bl.GetMessageById(id);

            _bl.RemoveMessage(message);
            return RedirectToAction("Index");
        }

        // POST: Messages/Resend/5
        [HttpPost, ActionName("Resend")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Resend(int id)
        {
            Message message = _bl.GetMessageById(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            await _mailer.SendEmailAsync(message.FromAddress, message.ToAddress, message.Subject, message.Body, message.IsHtml);
            return RedirectToAction("Details", new { id });
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
