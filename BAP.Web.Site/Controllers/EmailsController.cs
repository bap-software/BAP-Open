using System.Net;
using System.Web.Mvc;

using BAP.DAL.Entities;
using BAP.UI.Controllers;
using BAP.BL;
using BAP.Log;
using BAP.Common;
using BAP.FileSystem;
using BAP.Lookups;
using BAP.DAL;
using BAP.Email;

namespace BAP.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class EmailsController : BaseController<Message>
    {        
        public EmailsController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IMailer mailer, IAuthorizationContext context, IFileProcessor fileProcessor) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<Message>(configHelper, context))
        {                 
        }

        // GET: Emails
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize)
        {            
            int pageNumber = page ?? 1;
            int rowsPerPage = GetRealPageSize(pageSize);
            InitIndexViewData(sortOrder, currentFilter);            

            return View(_bl.SearchMessages(currentFilter, sortOrder, pageNumber, rowsPerPage));
        }

        // GET: Emails/Details/5
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

        // GET: Emails/Create
        public ActionResult Create()
        {
            ViewBag.NewsLetterId = new SelectList(((INewsLetterBL)_bl).GetAllNewsLetters(), "Id", "Title");
            ViewBag.SubscriberId = new SelectList(((ISubscriberBL)_bl).GetAllSubscribers(), "Id", "Email");
            return View();
        }

        // POST: Emails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FromAddress,ToAddress,CopyAddress,BlackCopyAddress,Subject,Body,NewsLetterId,SubscriberId")] Message message)
        {
            if (ModelState.IsValid)
            {
                _bl.AddMessage(message);
                return RedirectToAction("Index");
            }

            ViewBag.NewsLetterId = new SelectList(((INewsLetterBL)_bl).GetAllNewsLetters(), "Id", "Title", message.NewsLetterId);
            ViewBag.SubscriberId = new SelectList(((ISubscriberBL)_bl).GetAllSubscribers(), "Id", "Email", message.SubscriberId);            
            return View(message);
        }

        // GET: Emails/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.NewsLetterId = new SelectList(((INewsLetterBL)_bl).GetAllNewsLetters(), "Id", "Title", message.NewsLetterId);
            ViewBag.SubscriberId = new SelectList(((ISubscriberBL)_bl).GetAllSubscribers(), "Id", "Email", message.SubscriberId);
            return View(message);
        }

        // POST: Emails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FromAddress,ToAddress,CopyAddress,BlackCopyAddress,Subject,Body,NewsLetterId,SubscriberId")] Message message)
        {
            if (ModelState.IsValid)
            {
                _bl.UpdateMessage(message);
                return RedirectToAction("Index");
            }
            ViewBag.NewsLetterId = new SelectList(((INewsLetterBL)_bl).GetAllNewsLetters(), "Id", "Title", message.NewsLetterId);
            ViewBag.SubscriberId = new SelectList(((ISubscriberBL)_bl).GetAllSubscribers(), "Id", "Email", message.SubscriberId);
            return View(message);
        }

        // GET: Emails/Delete/5
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

        // POST: Emails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = _bl.GetMessageById(id);
            _bl.RemoveMessage(message);
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
