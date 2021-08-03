using System.Globalization;
using System.Net;
using System.Web.Mvc;

using BAP.Common;
using BAP.BL;
using BAP.DAL.Entities;
using BAP.Lookups;
using BAP.Log;
using BAP.DAL;
using BAP.UI.Controllers;

namespace BAP.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator,ContentManager")]
    public class LookupValuesController : BaseController<LookupValue>
    {        
        public LookupValuesController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<LookupValue>(configHelper, context))
        {
        }

        // GET: LookupValues
        public ActionResult Index()
        {
            return View(_bl.GetAllLookupValues());
        }

        // GET: LookupValues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LookupValue lookupValue = _bl.GetLookupValueById(id.Value);
            if (lookupValue == null)
            {
                return HttpNotFound();
            }
            return View(lookupValue);
        }

        // GET: LookupValues/Create
        public ActionResult Create(int lookupId = 0)
        {
            var lookupValue = new LookupValue()
            {
                CultureCode = CultureInfo.CurrentCulture.Name
            };

            return View(lookupValue);
        }

        // POST: LookupValues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Key,Text,Description,CultureCode,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,Order,OwnerGroup,OwnerPermissions,CultureCode,LocalizationId")] LookupValue lookupValue, int lookupId = 0)
        {
            if (ModelState.IsValid)
            {                                              
                if (lookupId > 0)
                {
                    var lookup = ((ILookupBL)_bl).GetLookupById(lookupId);
                    if (lookup != null)
                    {
                        lookupValue.Parent = lookup;
                    }
                }
                _bl.AddLookupValue(lookupValue);

                if(lookupId > 0)
                    return RedirectToAction("Details", "Lookups", new {Id = lookupId});

                return RedirectToAction("Index");
            }

            return View(lookupValue);
        }

        // GET: LookupValues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LookupValue lookupValue = _bl.GetLookupValueById(id.Value);
            
            if (lookupValue == null)
            {
                return HttpNotFound();
            }

            return View(lookupValue);
        }

        // POST: LookupValues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Key,Text,Description,CultureCode,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,Order,OwnerGroup,OwnerPermissions,CultureCode,LocalizationId")] LookupValue lookupValue)
        {
            if (ModelState.IsValid)
            {
                _bl.UpdateLookupValue(lookupValue);

                var parent = _bl.GetLookupValueById(lookupValue.Id).Parent;
                if (parent != null)
                    return RedirectToAction("Details", "Lookups", new { Id = parent.Id });

                return RedirectToAction("Index");
            }
            return View(lookupValue);
        }

        // GET: LookupValues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LookupValue lookupValue = _bl.GetLookupValueById(id.Value);
            if (lookupValue == null)
            {
                return HttpNotFound();
            }           
            return View(lookupValue);
        }

        // POST: LookupValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LookupValue lookupValue = _bl.GetLookupValueById(id);            
            int parentId = 0;
            if (lookupValue.Parent != null)
                parentId = lookupValue.Parent.Id;

            _bl.RemoveLookupValue(lookupValue);

            if (parentId > 0)
                return RedirectToAction("Details", "Lookups", new { Id = parentId });

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
