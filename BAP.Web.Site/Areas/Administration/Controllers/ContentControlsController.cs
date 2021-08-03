using System;
using System.Net;
using System.Web.Mvc;

using BAP.Common;
using BAP.DAL.Entities;
using BAP.Lookups;
using BAP.Log;
using BAP.DAL;
using BAP.UI.Controllers;


namespace BAP.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator,ContentManager")]
    public class ContentControlsController : BaseController<ContentControl>
    {
        public ContentControlsController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<ContentControl>(configHelper, context))
        {        
        }

        // GET: Lookups
        public ActionResult Index(string sortOrder, string currentFilter, int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int rowsPerPage = GetRealPageSize(pageSize);

            InitIndexViewData(sortOrder, currentFilter);

            return View(_bl.SearchContentControls(currentFilter, sortOrder, pageNumber, rowsPerPage));
        }

        // GET: Lookups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentControl contentControl = _bl.GetContentControlById(id.Value);
            if (contentControl == null)
            {
                return HttpNotFound();
            }
            return View(contentControl);
        }

        // GET: Lookups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lookups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,IsEnabled,ContentControlTypeId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,OwnerGroup,OwnerPermissions,DisplayName,HasDialog,HasCKEditor,ContentBefore,ContentAfter,MainCss,IconCss,ContainerTag,DialogContent,ContentHolderFieldId,JavaScriptContent,CultureCode,LocalizationId")] ContentControl contentControl)
        {
            if (ModelState.IsValid)
            {
                _bl.AddContentControl(contentControl);
                return RedirectToAction("Index");
            }

            return View(contentControl);
        }

        // GET: Lookups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentControl contentControl = _bl.GetContentControlById(id.Value);
            if (contentControl == null)
            {
                return HttpNotFound();
            }
            return View(contentControl);
        }

        // POST: Lookups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,IsEnabled,ContentControlTypeId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,OwnerGroup,OwnerPermissions,DisplayName,HasDialog,HasCKEditor,ContentBefore,ContentAfter,MainCss,IconCss,ContainerTag,DialogContent,ContentHolderFieldId,JavaScriptContent,CultureCode,LocalizationId")] ContentControl contentControl)
        {
            if (ModelState.IsValid)
            {                
                _bl.UpdateContentControl(contentControl);
                return RedirectToAction("Index");
            }
            return View(contentControl);
        }

        // GET: Lookups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentControl contentControl = _bl.GetContentControlById(id.Value);
            if (contentControl == null)
            {
                return HttpNotFound();
            }
            return View(contentControl);
        }

        // POST: Lookups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContentControl contentControl = _bl.GetContentControlById(id);
            _bl.RemoveContentControl(contentControl);
            return RedirectToAction("Index");
        }

    }
}
