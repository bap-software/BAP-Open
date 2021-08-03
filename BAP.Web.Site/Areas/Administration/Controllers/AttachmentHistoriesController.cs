using System.Net;
using System.Web.Mvc;

using BAP.Common;
using BAP.Lookups;
using BAP.Log;
using BAP.DAL;
using BAP.DAL.Entities;
using BAP.BL;
using BAP.UI.Controllers;

namespace BAP.Web.Areas.Administration.Controllers
{
    public class AttachmentHistoriesController : BaseController<AttachmentHistory>
    {        
        public AttachmentHistoriesController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<AttachmentHistory>(configHelper, context))
        {            
        }

        // GET: AttachmentHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AttachmentHistory attachmentHistory = _bl.GetAttachmentHistById(id.Value);
            if (attachmentHistory == null)
            {
                return HttpNotFound();
            }

            return View(attachmentHistory);
        }
                
        // GET: AttachmentHistories/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttachmentHistory attachmentHistory = _bl.GetAttachmentHistById(id.Value);
            if (attachmentHistory == null)
            {
                return HttpNotFound();
            }
            return View(attachmentHistory);
        }

        // POST: AttachmentHistories/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AttachmentHistory attachmentHistory = _bl.GetAttachmentHistById(id);
            _bl.RemoveAttachmentHistory(attachmentHistory);

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
