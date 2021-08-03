using System;
using System.Net;
using System.Web.Mvc;

using BAP.Common;
using BAP.Lookups;
using BAP.Log;
using BAP.UI.Controllers;
using BAP.FileSystem;
using BAP.DAL;

using BAP.eCommerce.DAL.Entities;
using BAP.eCommerce.BL;
using BAP.eCommerce.Common.Exceptions;
using BAP.BL;

namespace BAP.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator,Supervisor")]
    public class CustomersController : BaseController<Customer>
    {
        private readonly ICustomerBL _cbl;

        public CustomersController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<Customer>(configHelper, context), new eCommerceBusinessLayer(lookupEngine, fileProc, configHelper, context, logger))
        {
            _cbl = (ICustomerBL)_bl;
        }

        // GET: Controllers/Customers/AdminIndex     
        public ActionResult AdminIndex(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int rowsPerPage = GetRealPageSize(pageSize);

            InitIndexViewData(sortOrder, currentFilter);

            return View(_cbl.SearchCustomers(searchString, sortOrder, pageNumber, rowsPerPage));
        }

        // GET: Controllers/Customers/AdminDetails/5       
        public ActionResult AdminDetails(int id)
        {
            Customer customer = _cbl.GetCustomerById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            if (TempData["CurrentTab"] != null)
            {
                ViewBag.CurrentTab = TempData["CurrentTab"].ToString();
            }
            return View(customer);
        }

        // GET: Controllers/Customers/Create
        public ActionResult Create()
        {
            var currentOrganizationUser = ((IOrganizationUserBL)_bl).GetOrganizationUserByAspNetId(_authHelper.GetCurrentUserId());
            var customer = new Customer
            {
                LoginUserId = currentOrganizationUser.Id,
                LoginUser = currentOrganizationUser
            };
            return View(customer);
        }

        // POST: Controllers/Customers/Create
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortDescription,Description,FirstName,MiddleName,LastName,BillingAddressId,BillingAddress,ShippingAddressId,ShippingAddress,CompanyAddressId,CompanyAddress,Email,PhoneNumber,PhoneExtension,FaxNumber,CellNumber,CompanyName,LoginUserId,LoginUser,CustomData,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,PrefferedShippingOptionId,PrefferedShippingOption,PrefferedCurrencyId,PrefferedCurrency")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    customer.EntityState = BAPEntityState.Added;
                    _cbl.AddCustomer(customer);
                }
                catch (CustomerException exc)
                {
                    ClientNotify(exc.Message, Resources.Resources.ErrorText_Error);
                    return View(customer);
                }
                return RedirectToAction("AdminIndex");
            }

            return View(customer);
        }

        // GET: Controllers/Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer сustomer = _cbl.GetCustomerById(id.Value);
            _cbl.InitSubordinateEntities(сustomer);
            if (сustomer == null)
            {
                return HttpNotFound();
            }

            return View(сustomer);
        }

        // POST: Controllers/Customers/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortDescription,Description,FirstName,MiddleName,LastName,BillingAddressId,BillingAddress,ShippingAddressId,ShippingAddress,CompanyAddressId,CompanyAddress,Email,PhoneNumber,PhoneExtension,FaxNumber,CellNumber,CompanyName,LoginUserId,LoginUser,CustomData,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,PrefferedShippingOptionId,PrefferedShippingOption,PrefferedCurrencyId,PrefferedCurrency")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    customer.EntityState = BAPEntityState.Modified;
                    _cbl.UpdateCustomer(customer);
                }
                catch (CustomerException exc)
                {
                    ClientNotify(exc.Message, Resources.Resources.ErrorText_Error);
                    return View(customer);
                }
                return RedirectToAction("AdminIndex");
            }

            return View(customer);
        }

        // GET: Controllers/Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _cbl.GetCustomerById(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        // POST: Controllers/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = _cbl.GetCustomerById(id);
            _cbl.RemoveCustomer(customer);
            return RedirectToAction("AdminIndex");
        }

        public ActionResult RemoveCustomerPayment(int id, int customerPaymentId)
        {
            Customer customer = _cbl.GetCustomerById(id);
            CustomerPayment customerPayment = ((ICustomerPaymentBL)_bl).GetCustomerPaymentById(customerPaymentId);
            if (customer == null)
            {
                return HttpNotFound();
            }
            _cbl.RemoveCustomerPayment(customer, customerPayment);
            TempData["CurrentTab"] = "customerPayments";
            return RedirectToAction("AdminDetails", new { Id = id });
        }
    }
}