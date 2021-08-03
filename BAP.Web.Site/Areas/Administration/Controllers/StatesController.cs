using System;
using System.Web.Mvc;

using BAP.Common;
using BAP.Lookups;
using BAP.Log;
using BAP.DAL;
using BAP.DAL.Entities;
using BAP.UI.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace BAP.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class StatesController : BaseController<State>
    {
        public StatesController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<State>(configHelper, context))
        {
        }

        [HttpGet]
        public ActionResult GetStates(string countryName)
        {
            var country = _bl.SearchCountries($"[{{\"field\":\"Name\",\"value\":\"{countryName}\"}}]", "Name-asc").FirstOrDefault();
            var states = country != null ? _bl.SearchStates($"[{{\"field\":\"CountryId\",\"value\":\"{country.Id}\"}}]", "Name-asc") : new List<State>();
            return Json(states, JsonRequestBehavior.AllowGet);
        }

        // POST: States/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind(Include = "Id,Name,ShortName,Description,TwoLetterCode,ThreeLetterCode,CountryId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] State state)
        {
            if (ModelState.IsValid)
                _bl.AddState(state);
            TempData["CurrentTab"] = "states";
            return RedirectToAction("Details", "Countries", new { id = state.CountryId });
        }

        // POST: States/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortName,Description,TwoLetterCode,ThreeLetterCode,CountryId,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] State state)
        {
            if (ModelState.IsValid)
                _bl.UpdateState(state);
            TempData["CurrentTab"] = "states";
            return RedirectToAction("Details", "Countries", new { id = state.CountryId });
        }

        // POST: States/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            State state = _bl.GetStateById(id);
            var countryId = state.CountryId;
            _bl.RemoveState(state);
            TempData["CurrentTab"] = "states";
            return RedirectToAction("Details", "Countries", new { id = countryId });
        }
    }
}
