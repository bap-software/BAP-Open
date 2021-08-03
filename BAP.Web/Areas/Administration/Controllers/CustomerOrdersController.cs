using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using BAP.Common;
using BAP.Lookups;
using BAP.Log;
using BAP.UI.Controllers;
using BAP.FileSystem;
using BAP.DAL;
using BAP.eCommerce.DAL.Entities;
using BAP.eCommerce.BL;
using BAP.Workflow;

namespace BAP.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator,Supervisor")]
    public class CustomerOrdersController : BaseController<CustomerOrder>
    {
        readonly ICustomerOrderBL _cbl;

        public CustomerOrdersController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<CustomerOrder>(configHelper, context), null, 
                fileProc, new eCommerceBusinessLayer(lookupEngine, fileProc, configHelper, context, logger))
        {
            _cbl = (ICustomerOrderBL)_bl;
        }

        // GET: Controllers/CustomerOrders/AdminIndex     
        public ActionResult AdminIndex(string sortOrder, string currentFilter, int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            if (pageSize == null || pageSize.Value < 1)
            {
                pageSize = _configHelper.FakeMaxPageSize;
                EntityPagingAttribute pageAttr = (EntityPagingAttribute)Attribute.GetCustomAttribute(typeof(CustomerOrder), typeof(EntityPagingAttribute));
                if (pageAttr != null && pageAttr.Applied && pageAttr.PageSize > 0)
                {
                    pageSize = pageAttr.PageSize;
                }
            }

            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentFilter = currentFilter;
            ViewBag.SortData = InitSortData(ViewBag.CurrentSort);

            return View(_cbl.SearchCustomerOrders(currentFilter, sortOrder, pageNumber, pageSize.Value));
        }

        // GET: Controllers/CustomerOrders/AdminDetails/5       
        public ActionResult AdminDetails(int id, int? childObjectId, int? attachmentId)
        {
            var customerOrder = _cbl.GetCustomerOrderById(id);
            if (customerOrder == null)
            {
                return HttpNotFound();
            }

            // if supports workflows - get workflow and pass it via ViewBag
            if (_bl is ISupportWorkflow<CustomerOrder> workflowBl)
            {
                var workflow = workflowBl.GetCurrentWorkflow(customerOrder, childObjectId, attachmentId);
                if (workflow != null)
                {
                    ViewBag.CurrentWorkflow = workflow;
                } 
                else
                {
                    ViewBag.AvailableWorkflows = workflowBl.GetAvailableFlows(customerOrder);
                }
            }

            if (TempData["CurrentTab"] != null)
            {
                ViewBag.CurrentTab = TempData["CurrentTab"].ToString();
            }
           
            _cbl.GenerateInvoicePdf(id);

            return View(customerOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Workflow(int id, int? actionId, int? transitionId, string transitionComment, string attribsJson = null)
        {
            CustomerOrder customerOrder = _cbl.GetCustomerOrderById(id);
            if (customerOrder == null)
            {
                return HttpNotFound();
            }

            var workflowBl = (ISupportWorkflow<CustomerOrder>)_bl;
            var workflow = workflowBl.GetCurrentWorkflow(customerOrder);
            if (workflow != null)
            {
                // process action
                if (actionId != null)
                {                    
                    var jsonText = workflowBl.DoAction(workflow, actionId.Value, attribsJson);
                    if (jsonText == null)
                        ClientNotify(Resources.Resources.UIText_WFActionErrorOccured, Resources.Resources.ErrorText_Error);
                }
                
                // choose transition
                if (transitionId != null)
                {
                    if (!workflowBl.ChooseTransition(workflow, transitionId.Value, transitionComment))
                        ClientNotify(Resources.Resources.UIText_WFTransIsNotPossible);
                }

                ViewBag.CurrentWorkflow = workflow;
            }

            return RedirectToAction("AdminDetails", new { customerOrder.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChooseWorkflow(int id, int workflowClassId)
        {
            CustomerOrder customerOrder = _cbl.GetCustomerOrderById(id);
            if (customerOrder == null)
            {
                return HttpNotFound();
            }
            var workflowBl = (ISupportWorkflow<CustomerOrder>)_bl;
            ViewBag.CurrentWorkflow = workflowBl.ChooseWorkflow(customerOrder, workflowClassId);
            return RedirectToAction("AdminDetails", new { customerOrder.Id });
        }

        // GET: Controllers/CustomerOrders        
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            int pageNumber = 1;
            int pageSize = _configHelper.FakeMaxPageSize;

            EntityPagingAttribute pageAttr = (EntityPagingAttribute)Attribute.GetCustomAttribute(typeof(DAL.Entities.Blog), typeof(EntityPagingAttribute));
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

                pageNumber = page ?? 1;
                pageSize = pageAttr.PageSize;
            }

            return View(_cbl.SearchCustomerOrders(searchString, sortOrder, pageNumber, pageSize));
        }

        // GET: Controllers/CustomerOrders/Details/5        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrder customerOrder = _cbl.GetCustomerOrderById(id.Value);
            if (customerOrder == null)
            {
                return HttpNotFound();
            }
            return View(customerOrder);
        }

        // GET: Controllers/CustomerOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customerOrder = _cbl.GetCustomerOrderById(id.Value);
            if (customerOrder == null)
            {
                return HttpNotFound();
            }

            return View(customerOrder);
        }

        // POST: Controllers/CustomerOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerOrder customerOrder = _cbl.GetSingleCustomerOrderById(id);
            _cbl.RemoveCustomerOrder(customerOrder);
            return RedirectToAction("AdminIndex");
        }

        // GET: Controllers/CustomerOrders/SentToCustomer/5
        [HttpGet]
        public async Task<ActionResult> SendInvoceToCustomer(int id)
        {
            TempData["CurrentTab"] = "invoice";
            await _cbl.SendOrderInvoiceToCustomerAsync(id);
            ClientNotify(Resources.Resources.FieldLabel_MessageWasSent);
            return RedirectToAction("AdminDetails", new { id });
        }
    }
}