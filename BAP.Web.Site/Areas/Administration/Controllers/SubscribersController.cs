using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using System.Threading.Tasks;

using BAP.Common;
using BAP.Lookups;
using BAP.Log;
using BAP.DAL;
using BAP.BL;
using BAP.DAL.Entities;
using BAP.UI.Controllers;
using BAP.FileSystem;

namespace BAP.Web.Areas.Administration.Controllers
{
    //Every controller is created with restricted access be default. Any public action has to be created explicitly.
    [Authorize(Roles = "Administrator")]
    public class SubscribersController : BaseController<Subscriber>
    {        
        public SubscribersController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<Subscriber>(configHelper, context))
        {            
        }

        // GET: Administration/Subscribers
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            int pageNumber = 1;
            int pageSize = _configHelper.FakeMaxPageSize;

            EntityPagingAttribute pageAttr = (EntityPagingAttribute)Attribute.GetCustomAttribute(typeof(Subscription), typeof(EntityPagingAttribute));
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

            return View(_bl.SearchSubscribers(searchString, sortOrder, pageNumber, pageSize));
        }

        // GET: Administration/Subscribers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Subscriber subscriber = _bl.GetSubscriberById(id.Value);
            if (subscriber == null)
            {
                return HttpNotFound();
            }
            return View(subscriber);
        }

        // GET: Administration/Subscribers/Create
        public ActionResult Create()
        {
            var subscriber = new Subscriber
            {
                PublicId = Guid.NewGuid()
            };
            return View(subscriber);
        }

        // POST: Subscribers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PublicId,Email,Enabled,RegisterDate,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,LastNewsletterIdReceived")] Subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                _bl.AddSubscriber(subscriber);
                return RedirectToAction("Index");
            }

            return View(subscriber);
        }

        // GET: Administration/Subscribers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscriber subscriber = _bl.GetSubscriberById(id.Value);
            if (subscriber == null)
            {
                return HttpNotFound();
            }
            return View(subscriber);
        }

        // POST: Administration/Subscribers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PublicId,Email,Enabled,RegisterDate,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,LastNewsletterIdReceived")] Subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                _bl.UpdateSubscriber(subscriber);
                return RedirectToAction("Index");
            }
            return View(subscriber);
        }

        // GET: Administration/Subscribers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscriber subscriber = _bl.GetSubscriberById(id.Value);
            if (subscriber == null)
            {
                return HttpNotFound();
            }
            return View(subscriber);
        }

        // POST: Administration/Subscribers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subscriber subscriber = _bl.GetSubscriberById(id);
            _bl.RemoveSubscriber(subscriber);
            return RedirectToAction("Index");
        }

    }
}
