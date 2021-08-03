using System.Web.Mvc;
using System.Collections.Generic;

using Newtonsoft.Json;

using BAP.Common;
using BAP.DAL;
using BAP.FileSystem;
using BAP.Log;
using BAP.Lookups;
using BAP.Email;
using BAP.ContentManagement;
using BAP.BL;
using BAP.eCommerce.BL;
using BAP.eCommerce.DAL.Entities;
using BAP.eCommerce.UI.Controllers;
using BAP.eCommerce.Resources;

namespace BAP.Web.Areas.eCommerce.Controllers
{
    [Authorize]
    public class CustomerOrdersController : BaseeCommerceController<CustomerOrder>, IContentExtendable
    {
        private readonly ICustomerOrderBL _cbl;

        public CustomerOrdersController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context, IMailer mailer, IFileProcessor fileProcessor) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<CustomerOrder>(configHelper, context), mailer, fileProcessor, new eCommerceBusinessLayer(lookupEngine, fileProc, configHelper, context, logger))
        {
            _cbl = (eCommerceBusinessLayer)_bl;
        }
        
        public ActionResult Index(string sortOrder = null, string currentFilter = null, int? page = 1, int? pageSize = 5, string view = "")
        {
            if(_eContext == null || _eContext.CurrentCustomer == null)
            {
                ClientNotify(ResObject.UIText_NoOrdersYet);
                Response.Redirect(Request.UrlReferrer.AbsoluteUri);
            }

            int pageNumber = page ?? 1;
            int rowsPerPage = GetRealPageSize(pageSize);

            InitIndexViewData(sortOrder, currentFilter);

            var customerId = _eContext.CurrentCustomer.Id;
            ViewBag.Customer = _eContext.CurrentCustomer;
            var filters = new List<SearchStruct>();
            var categoryFilter = new SearchStruct
            {
                field = "CustomerId",
                value = customerId.ToString()
            };
            filters.Add(categoryFilter);
            currentFilter = JsonConvert.SerializeObject(filters);
            var customerOrders = _cbl.SearchCustomerOrders(currentFilter, sortOrder, pageNumber, rowsPerPage);

            return string.IsNullOrEmpty(view) ? View(customerOrders) : View(view, customerOrders);
        }

        public ActionResult Details(int id)
        {
            var customerOrder = _cbl.GetCustomerOrderById(id);
            return View(customerOrder);
        }
    }
}