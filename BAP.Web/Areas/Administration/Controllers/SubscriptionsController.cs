using System;
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
    //Every controller is created with restricted access be default. Any public action has to be created explicitly.
    [Authorize(Roles = "Administrator")]
    public class SubscriptionsController : BaseController<Subscription>
    {
        
        public SubscriptionsController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<Subscription>(configHelper, context))
        {            
        }

        // GET: Subscriptions
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

            return View(_bl.SearchSubscriptions(searchString, sortOrder, pageNumber, pageSize));
        }

        // GET: Subscriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = _bl.GetSubscriptionById(id.Value);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        // GET: Subscriptions/Create
        public ActionResult Create()
        {
            var subscription = new Subscription();
            var currentOrganizationUser = ((IOrganizationUserBL)_bl).GetOrganizationUserByAspNetId(_authHelper.GetCurrentUserId());
            var currentOrganization = ((IOrganizationBL)_bl).GetOrganizationById(_authHelper.GetCurrentOrganizationId());
            if (currentOrganizationUser != null && currentOrganization != null)
            {
                subscription = _bl.InitSubscription("default", "trial");
                subscription.UserId = currentOrganizationUser.Id;
                subscription.User = currentOrganizationUser;
                subscription.OrganizationId = currentOrganization.Id;
                subscription.Organization = currentOrganization;
            }
            return View(subscription);
        }

        // POST: Subscriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SubscriptionType,InitialTerm,TermStart,TermEnd,ContractDate,AutoRenew,RenewalTerm,SubTotal,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,UserId,OrganizationId")] Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                _bl.AddSubscription(subscription);
                return RedirectToAction("Index");
            }

            return View(subscription);
        }

        // GET: Subscriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = _bl.GetSubscriptionById(id.Value);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        // POST: Subscriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SubscriptionType,InitialTerm,TermStart,TermEnd,ContractDate,AutoRenew,RenewalTerm,SubTotal,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,UserId,OrganizationId")] Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                _bl.UpdateSubscription(subscription);
                return RedirectToAction("Index");
            }
            return View(subscription);
        }

        // GET: Subscriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = _bl.GetSubscriptionById(id.Value);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        // POST: Subscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subscription subscription = _bl.GetSubscriptionById(id);
            _bl.RemoveSubscription(subscription);
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
