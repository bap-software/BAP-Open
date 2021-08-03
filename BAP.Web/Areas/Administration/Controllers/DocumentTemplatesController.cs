using System;
using System.Net;
using System.Web.Mvc;

using BAP.Common;
using BAP.Lookups;
using BAP.Log;

using BAP.DAL.Entities;
using BAP.DAL;
using BAP.UI.Controllers;

namespace BAP.Web.Areas.Administration.Controllers
{
    //Every controller is created with restricted access be default. Any public action has to be created explicitly.
    [Authorize(Roles = @"Administrator,Supervisor")]
    public class DocumentTemplatesController : BaseController<DocumentTemplate>
    {        
        public DocumentTemplatesController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<DocumentTemplate>(configHelper, context))
        {
        }

        // GET: DocumentTemplates
        public ActionResult Index(string sortOrder, string currentFilter, int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int rowsPerPage = GetRealPageSize(pageSize);

            InitIndexViewData(sortOrder, currentFilter);

            return View(_bl.SearchDocumentTemplates(currentFilter, sortOrder, pageNumber, rowsPerPage));
        }

        // GET: DocumentTemplates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentTemplate documentTemplate = _bl.GetDocumentTemplateById(id.Value);
            if (documentTemplate == null)
            {
                return HttpNotFound();
            }
            return View(documentTemplate);
        }

        // GET: DocumentTemplates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Name,ShortDescription,Description,TemplateBody,IsEnabled,TemplateType,CultureCode,LocalizationId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,TemplateBodyUrl")] DocumentTemplate documentTemplate)
        {
            if (ModelState.IsValid)
            {
                _bl.AddDocumentTemplate(documentTemplate);
                return RedirectToAction("Index");
            }

            return View(documentTemplate);
        }

        // GET: DocumentTemplates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentTemplate documentTemplate = _bl.GetDocumentTemplateById(id.Value);
            if (documentTemplate == null)
            {
                return HttpNotFound();
            }
            return View(documentTemplate);
        }

        // POST: DocumentTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortDescription,Description,TemplateBody,IsEnabled,TemplateType,CultureCode,LocalizationId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,TemplateBodyUrl")] DocumentTemplate documentTemplate)
        {
            if (ModelState.IsValid)
            {
                _bl.UpdateDocumentTemplate(documentTemplate);
                return RedirectToAction("Index");
            }
            return View(documentTemplate);
        }

        // GET: DocumentTemplates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentTemplate documentTemplate = _bl.GetDocumentTemplateById(id.Value);
            if (documentTemplate == null)
            {
                return HttpNotFound();
            }
            return View(documentTemplate);
        }

        // POST: DocumentTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocumentTemplate documentTemplate = _bl.GetDocumentTemplateById(id);
            _bl.RemoveDocumentTemplate(documentTemplate);
            return RedirectToAction("Index");
        }

    }
}
