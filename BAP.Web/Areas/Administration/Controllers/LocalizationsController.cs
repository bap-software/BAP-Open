using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Web.Mvc;
using System.Resources;
using System.Web.Http.Results;
using BAP.BL;
using BAP.Common;
using BAP.Lookups;
using BAP.Log;
using BAP.DAL;
using BAP.DAL.Entities;

using BAP.UI.Controllers;
using BAP.FileSystem;
using BAP.Web.Models;
using Newtonsoft.Json;
using PagedList;
using BAP.Web.Areas.Administration.Models;

namespace BAP.Web.Areas.Administration.Controllers
{
    //Every controller is created with restricted access be default. Any public action has to be created explicitly.
    [Authorize(Roles = "Administrator")]
    public class LocalizationsController : BaseController<Localization>
    {
        private readonly IAuthorizationContext _context;
        public LocalizationsController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<Localization>(configHelper, context))
        {
            _context = context;
        }

        // GET: Administration/Localizations
        public ActionResult Index(
            string sortOrder, 
            string localizationName, 
            string localizationValue, 
            string localizationCultureCode, 
            int? page,
            int? pageSize)
        {
            var pageNumber = page ?? 1;
            var rowsPerPage = GetRealPageSize(pageSize);
            var sortExpression = string.IsNullOrEmpty(sortOrder) ? "default" : sortOrder;

            SetIndexViewBag(rowsPerPage, sortExpression, localizationName, localizationValue, localizationCultureCode);

            var searchExpression = GetSearchExpression(localizationName, localizationValue, localizationCultureCode);

            return View(_bl.SearchLocalizations(searchExpression, sortExpression, pageNumber, rowsPerPage));
        }

        // GET: Administration/Localizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localization Localization = _bl.GetLocalizationById(id.Value);
            if (Localization == null)
            {
                return HttpNotFound();
            }
            return View(Localization);
        }

        // GET: Administration/Localizations/Create
        public ActionResult Create()
        {
            CulturesToViewBag("");
            return View();
        }

        // POST: Administration/Localizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ResourceSet,FileName,Value,Object,ObjectId,CultureCode,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions")] Localization Localization)
        {
            var existedLocalizations = SearchForExistedLocalizationsInDb(Localization);

            if (existedLocalizations.Any())
            {
                ModelState.AddModelError(nameof(Localization.Name), "Localization with this name and CultureCode is already exists");
            }
            
            if (ModelState.IsValid)
            {
                _bl.AddLocalization(Localization);
                ResetResources();
                return RedirectToAction("Index");
            }
            CulturesToViewBag(Localization.CultureCode);
            return View(Localization);
        }

        private IPagedList<Localization> SearchForExistedLocalizationsInDb(Localization localization)
        {
            var searchDuplicatesList = new List<SearchStruct>
            {
                new SearchStruct
                {
                    field = nameof(Localization.Name),
                    value = localization.Name
                },
                new SearchStruct
                {
                    field = nameof(Localization.CultureCode),
                    value = localization.CultureCode
                }
            };

            var searchExpression = JsonConvert.SerializeObject(searchDuplicatesList);
            return _bl.SearchLocalizations(searchExpression, "default", 1, int.MaxValue);
        }

        // GET: Administration/Localizations/Edit?localizationName=UIText_Edit
        public ActionResult Edit(string localizationName)
        {
            if (string.IsNullOrEmpty(localizationName))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var searchList = new List<SearchStruct>
            {
                new SearchStruct
                {
                    field = $"{nameof(Localization.Name)}",
                    value = localizationName
                }
            };

            var searchExpression = JsonConvert.SerializeObject(searchList);
            const string sortExpression = "default";
            
            var localizations = _bl.SearchLocalizations(searchExpression, sortExpression, 1, int.MaxValue);
            
            if (!localizations.Any())
            {
                return HttpNotFound();
            }
            
            var currOrg = _context.GetCurrentOrganization(_configHelper);
            var cultureHelper = new CultureHelper(currOrg.ImplementedCultures);
            var allowedLocalizations = localizations
                .Where(
                    x => string.IsNullOrEmpty(x.CultureCode) 
                         || currOrg.ImplementedCultures.Any(cul => cul == x.CultureCode));

            var localizationEditViewModel = new LocalizationEditViewModel(allowedLocalizations.ToList(), cultureHelper);

            return View(localizationEditViewModel);
        }

        // POST: Administration/Localizations/Edit?localizationName=UIText_Edit
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Name,ResourceSet,FileName,Value,Object,ObjectId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,Items")]
            LocalizationEditViewModel localizationEditViewModel)
        {
            if (ModelState.IsValid)
            {
                foreach (var localizationItem in localizationEditViewModel.Items)
                {
                    var localization = _bl.GetLocalizationById(localizationItem.LocalizationId);
                    localization.Value = localizationItem.Value;

                    // In case if localization was seed previously without CultureCode
                    if (string.IsNullOrEmpty(localization.CultureCode))
                    {
                        localization.CultureCode = localizationItem.CultureCode;
                    }
                    
                    _bl.UpdateLocalization(localization);
                }
                
                ResetResources();
                return RedirectToAction("Index");
            }
            
            return View(localizationEditViewModel);
        }

        // GET: Administration/Localizations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localization Localization = _bl.GetLocalizationById(id.Value);
            if (Localization == null)
            {
                return HttpNotFound();
            }
            return View(Localization);
        }

        // POST: Administration/Localizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Localization Localization = _bl.GetLocalizationById(id);

            _bl.RemoveLocalization(Localization);
            ResetResources();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLocalizationValue(int localizationId, string newValue)
        {
            var targetLocalization = _bl.GetLocalizationById(localizationId);

            if (targetLocalization == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            if (newValue.StartsWith("\""))
            {
                newValue = newValue.Substring(1);
            }

            if (newValue.EndsWith("\""))
            {
                newValue = newValue.Substring(0, newValue.Length - 1);
            }
            
            targetLocalization.Value = newValue;

            try
            {   
                _bl.UpdateLocalization(targetLocalization);
            }
            catch (Exception e)
            {
                _logger.LogError(nameof(LocalizationsController), nameof(EditLocalizationValue),
                    $"Can't update Localization Value. Localization Id = {localizationId}, Message: {e.Message}");
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
            
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MultirowActionForm(int[] checkRow, string selectedAction,  string sortOrder, int? page, int? pageSize)
        {
            if(selectedAction == "delete" && checkRow != null)
            {
                var localizations = checkRow
                    .Select(rowId => _bl.GetLocalizationById(rowId)).Where(log => log != null)
                    .ToArray();
                
                _bl.RemoveLocalization(localizations);
            }

            return RedirectToAction("Index", new { sortOrder, page, pageSize});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ((System.IDisposable)_bl).Dispose();
            }
            base.Dispose(disposing);
        }

        private string GetSearchExpression(string localizationName, string localizationValue, string localizationCultureCode)
        {
            var searchList = new List<SearchStruct>();

            if (!string.IsNullOrEmpty(localizationName))
            {
                searchList.Add(new SearchStruct
                {
                    field = $"{nameof(Localization.Name)}-like",
                    value = localizationName
                });
            }

            if (!string.IsNullOrEmpty(localizationValue))
            {
                searchList.Add(new SearchStruct
                {
                    field = $"{nameof(Localization.Value)}-like",
                    value = localizationValue
                });
            }

            if (!string.IsNullOrEmpty(localizationCultureCode))
            {
                searchList.Add(new SearchStruct
                {
                    field = $"{nameof(Localization.CultureCode)}-like",
                    value = localizationCultureCode
                });
            }

            return JsonConvert.SerializeObject(searchList);
        }

        private void SetIndexViewBag(int pageSize, string currentSort, string localizationName, string localizationValue, string localizationCultureCode)
        {
            var currOrg = _context.GetCurrentOrganization(_configHelper);
            
            ViewBag.LocalizationName = localizationName;
            ViewBag.LocalizationValue = localizationValue;
            ViewBag.LocalizationCultureCode = localizationCultureCode;

            var culturesSelectList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = String.Empty,
                    Text = String.Empty,
                }
            };
            culturesSelectList.AddRange(currOrg.ImplementedCultures.Select(x => new SelectListItem
            {
                Value = x,
                Text = x,
                Selected = localizationCultureCode == x
            }));

            ViewBag.Cultures = culturesSelectList;
            ViewBag.CurrentSort = currentSort;
            ViewBag.PageSize = pageSize;
        }

        private void CulturesToViewBag(string selectedCulture)
        {
            var cultureHelper = new CultureHelper(_authContext.GetCurrentOrganization(_configHelper).ImplementedCultures);
            var cultures = cultureHelper.Cultures.Select(a => new SelectListItem { Text = a, Value = a, Selected = (selectedCulture == a) }).ToList();
            cultures.Insert(0, new SelectListItem { Text = Resources.Resources.UIText_Select, Value = "" });
            ViewBag.Cultures = cultures;
        }

        private void ResetResources()
        {
            var resManager = DependencyResolver.Current.GetService<ResourceManager>();
            if (resManager != null)
                resManager.ReleaseAllResources();
        }
    }
}
