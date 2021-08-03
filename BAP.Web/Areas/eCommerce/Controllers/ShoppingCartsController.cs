using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Newtonsoft.Json;

using BAP.Common;
using BAP.DAL;
using BAP.FileSystem;
using BAP.Log;
using BAP.Lookups;
using BAP.Email;
using BAP.ContentManagement;

using BAP.eCommerce.BL;
using BAP.eCommerce.Common.Exceptions;
using BAP.eCommerce.DAL.Entities;
using BAP.eCommerce.Resources;
using BAP.eCommerce.UI.Controllers;
using System.Threading.Tasks;
using BAP.Common.Suppliers;
using BAP.eCommerce.SupplierEngine;


namespace BAP.Web.Areas.eCommerce.Controllers
{
    [Authorize(Roles = "Administrator,User")]
    public class ShoppingCartsController : BaseeCommerceController<ShoppingCart>, IContentExtendable
    {
        private readonly IShoppingCartBL _scbl;
        private readonly IShippingOptionBL _sobl;
        private readonly IPaymentOptionBL _pobl;
        private readonly IStoreBL _sbl;

        public ShoppingCartsController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context, IMailer mailer, IFileProcessor fileProcessor) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<ShoppingCart>(configHelper, context), mailer, fileProcessor, new eCommerceBusinessLayer(lookupEngine, fileProc, configHelper, context, logger))
        {
            _scbl = (eCommerceBusinessLayer)_bl;
            _sobl = (eCommerceBusinessLayer)_bl;
            _pobl = (eCommerceBusinessLayer)_bl;
            _sbl = (eCommerceBusinessLayer)_bl;
        }
        
        // GET: Controllers/ShoppingCarts/Details/5
        [AllowAnonymous]
        public ActionResult Details()
        {
            var shoppingCart = _eContext.CurrentShoppingCart;
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }
            var store = _sbl.GetDefaultStore();
            ViewBag.IsUnregisteredCheckoutAllowed = store != null && store.IsUnregisteredCheckoutAllowed;
            return View(shoppingCart);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(string discountCoupon, bool forceUpdate = false)
        {
            bool isAnyChange = false;
            var shoppingCart = _eContext.CurrentShoppingCart;
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }

            // Process discount coupon and attach it to the shopping cart
            if (!(!discountCoupon.IsNullOrEmpty() && shoppingCart.DiscountCoupon != null && shoppingCart.DiscountCoupon.Code == discountCoupon))
            {
                isAnyChange = _scbl.ApplyDiscountCoupon(shoppingCart, discountCoupon);
                if (isAnyChange && !discountCoupon.IsNullOrEmpty())
                {
                    ViewBag.CouponAppliedText = string.Format(ResObject.UIText_CouponApplied, discountCoupon);
                }
                else if (!isAnyChange && !discountCoupon.IsNullOrEmpty())
                {
                    ViewBag.CouponAppliedText = string.Format(ResObject.UIText_CouponNotApplied, discountCoupon);
                }
                else if (isAnyChange && discountCoupon.IsNullOrEmpty())
                {
                    ViewBag.CouponAppliedText = ResObject.UIText_CouponRemoved;
                }
            }

            // Process items counts
            foreach (var key in Request.Form.AllKeys.Where(a => a.Contains("ItemCount_")))
            {
                var itemId = Convert.ToInt32(key.Split("_".ToCharArray())[1]);
                var value = Convert.ToInt32(Request.Form[key]);
                if (value < 0)
                    value = 1;
                if (_scbl.UpdateProductCount(shoppingCart, itemId, value))
                    isAnyChange = true;
            }

            // If we did any change to the shopping cart let's update it into DB
            if (forceUpdate || isAnyChange)
            {
                _scbl.UpdateShoppingCart(shoppingCart);
            }

            if (shoppingCart.HasMessage)
                ClientNotify(shoppingCart.NotificationMessage);
            var store = _sbl.GetDefaultStore();
            ViewBag.IsUnregisteredCheckoutAllowed = store != null && store.IsUnregisteredCheckoutAllowed;
            return View(shoppingCart);
        }

        [AllowAnonymous]
        public ActionResult SmallDetails()
        {
            var shoppingCart = _eContext.CurrentShoppingCart;
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }

            return View(shoppingCart);
        }

        // GET: Controllers/ShoppingCarts/Checkout/5
        [AllowAnonymous]
        public ActionResult Checkout(bool goThrough = false)
        {
            var shoppingCart = _eContext.CurrentShoppingCart;
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }

            if (!goThrough && !_authContext.IsAuthenticated)
            {
                return RedirectToAction("SignUp", "Account", new { Area = "eCommerce", returnUrl = this.Url.Action("Checkout", "ShoppingCarts", new { shoppingCart.Id }) });
            }

            // need to populate shopping cart address from user if empty still
            _scbl.PullAddressFromUser(shoppingCart);
            return View(shoppingCart);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout([Bind(Include = "BillingAddress,Currency,DiscountCoupon,PaymentOption,ShippingAddress,ShippingOption,ShoppingCartProducts,User,Id,UserId,CurrencyId,ShippingOptionId,PaymentOptionId,DiscountCouponId,BillingAddressId,ShippingAddressId,Coupon,Notes,CustomData,Subtotal,Total,ShippingCost,TotalDiscounts,TaxTotal,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,LastModifiedBy,TimeStamp,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,ShippingAsBilling")] ShoppingCart shoppingCart)
        {
            if (ModelState.IsValid)
            {
                _scbl.SaveAddresses(shoppingCart);
                if (shoppingCart.ShoppingCartProducts == null)
                    shoppingCart.ShoppingCartProducts = _eContext.CurrentShoppingCart.ShoppingCartProducts;
                var needsShipping = shoppingCart.ShoppingCartProducts.Any(p => p.Product.NeedsShipping);
                var needsPayment = shoppingCart.ShoppingCartProducts.Any(p => p.Product.Price > 0);
                if (needsShipping || needsPayment)
                    return RedirectToAction("ShippingAndPayment", new { shoppingCart.Id });
                return RedirectToAction("Review", new { shoppingCart.Id });
            }

            if (shoppingCart.HasMessage)
                ClientNotify(shoppingCart.NotificationMessage);
            return View(shoppingCart);
        }

        [AllowAnonymous]
        public async  Task<ActionResult> ShippingAndPayment()
        {
            var shoppingCart = _eContext.CurrentShoppingCart;
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurrencySymbol = "$";
            if (_eContext?.CurrentCurrency != null)
            {
                ViewBag.CurrencySymbol = _eContext.CurrentCurrency.Symbol;
            }

            var shippingOptions = _eContext.ShippingOptions;
            var shippingOptionsDC = _sobl.GetShippingOptions(shoppingCart, shippingOptions);
            if(shoppingCart.ShippingOption == null && shippingOptionsDC != null && shippingOptionsDC.Any())
            {
                await _scbl.SetShippingOptionAsync(shoppingCart, shippingOptionsDC.First().Id);                
            }
            if (shoppingCart.ShippingOption != null)
            {
                var warehouses = _sobl.SearchAvalilableBranches(shoppingCart);
                if (warehouses != null && warehouses.Any())
                {
                    ViewBag.WarehouseList = warehouses
                        .Select(x => (Id: x.Id, Description: x.Description, Selected: false))
                        .ToList();
                }
            }
            ViewBag.ShippingOptions = shippingOptionsDC;           

            var paymentOptions = _eContext.PaymentOptions;
            ViewBag.PaymentOptions = _pobl.GetPaymentOptions(shoppingCart, paymentOptions);
            
            return View(shoppingCart);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ShippingAndPayment(int id, int? shippingOptionId, int? paymentOptionId)
        {
            var shoppingCart = _scbl.GetShoppingCartById(id);
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }

            if (shippingOptionId.GetValueOrDefault() > 0 || paymentOptionId.GetValueOrDefault() > 0)
            {
                await _scbl.SetShippingOptionAsync(shoppingCart, shippingOptionId.GetValueOrDefault());
                await _scbl.SetPaymentOptionAsync(shoppingCart, paymentOptionId.GetValueOrDefault());
                return RedirectToAction("Review", new { shoppingCart.Id });
            }

            var shippingOptions = _eContext.ShippingOptions;
            ViewBag.ShippingOptions = JsonConvert.SerializeObject(((IShippingOptionBL)_bl).GetShippingOptions(shoppingCart, shippingOptions));
            var paymentOptions = _eContext.PaymentOptions;
            ViewBag.PaymentOptions = JsonConvert.SerializeObject(((IPaymentOptionBL)_bl).GetPaymentOptions(shoppingCart, paymentOptions));
            
            if (shoppingCart.HasMessage)
                ClientNotify(shoppingCart.NotificationMessage);
            return View(shoppingCart);
        }

        // GET: Controllers/ShoppingCarts/Shipping/5
        [AllowAnonymous]
        public ActionResult Shipping()
        {
            var shoppingCart = _eContext.CurrentShoppingCart;
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }

            var shippingOptions = _eContext.ShippingOptions;
            ViewBag.ShippingOptions = JsonConvert.SerializeObject(((IShippingOptionBL)_bl).GetShippingOptions(shoppingCart, shippingOptions));
            return View(shoppingCart);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Shipping(int id, int shippingOptionId)
        {
            var shoppingCart = _scbl.GetShoppingCartById(id);
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }

            if (shippingOptionId > 0)
            {
                if (_scbl.SetShippingOption(shoppingCart, shippingOptionId))
                    return RedirectToAction("Payment", new { shoppingCart.Id });
            }

            var shippingOptions = _eContext.ShippingOptions;
            ViewBag.ShippingOptions = JsonConvert.SerializeObject(((IShippingOptionBL)_bl).GetShippingOptions(shoppingCart, shippingOptions));
            if (shoppingCart.HasMessage)
                ClientNotify(shoppingCart.NotificationMessage);
            return View(shoppingCart);
        }

        // GET: Controllers/ShoppingCarts/Payment/5
        [AllowAnonymous]
        public ActionResult Payment()
        {
            var shoppingCart = _eContext.CurrentShoppingCart;
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }
            var paymentOptions = _eContext.PaymentOptions;
            ViewBag.PaymentOptions = JsonConvert.SerializeObject(((IPaymentOptionBL)_bl).GetPaymentOptions(shoppingCart, paymentOptions));
            return View(shoppingCart);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Payment(int id, int paymentOptionId)
        {
            var shoppingCart = _scbl.GetShoppingCartById(id);
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }

            if (paymentOptionId > 0)
            {
                if (_scbl.SetPaymentOption(shoppingCart, paymentOptionId))
                    return RedirectToAction("Review", new { shoppingCart.Id });
            }

            var paymentOptions = _eContext.PaymentOptions;
            ViewBag.PaymentOptions = JsonConvert.SerializeObject(((IPaymentOptionBL)_bl).GetPaymentOptions(shoppingCart, paymentOptions));
            if (shoppingCart.HasMessage)
                ClientNotify(shoppingCart.NotificationMessage);
            return View(shoppingCart);
        }

        // GET: Controllers/ShoppingCarts/Review/5
        [AllowAnonymous]
        public ActionResult Review()
        {
            var shoppingCart = _eContext.CurrentShoppingCart;
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCart);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Review([Bind(Include = "Id,TermsAndConditions")] ShoppingCart cart)
        {
            var shoppingCart = _scbl.GetShoppingCartById(cart.Id);
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }

            if (!cart.TermsAndConditions)
            {
                ClientNotify(Resources.Resources.UIText_YouMustAgree);
                return View(shoppingCart);
            }
            
            // initiate delivery with chosen shipping provider
            string warehouseNumber = string.Empty;
            var shoppingCartCustomData = _scbl.GetShoppingCartCustomData(shoppingCart);
            if (shoppingCartCustomData != null)
            {
                warehouseNumber = shoppingCartCustomData.ShipToBranchCode;
            }

            var response = _sobl.InitiateDelivery(shoppingCart);
            if(response != null && response.Success) //otherwise nothing happens, but sales manager will need to resolve shipment manually
            {
                _scbl.SetShoppingCartCustomData(shoppingCart, new ShoppingCartCustomData
                {
                    ShipReferenceId = response.RefDocumentNumber,
                    ShipToBranchCode = warehouseNumber
                });
                _scbl.UpdateShoppingCart(shoppingCart);
            }
                        
            // create order
            var order = _scbl.ConvertToOrder(shoppingCart);

            // Re-query order with all data
            order = ((ICustomerOrderBL)_bl).GetCustomerOrderById(order.Id);
            // check payment behavior
            
            PaymentPageInfo paymentPage = GetPaymentPageInfo(order);
            
            // if payment page is available show it
            if (paymentPage != null)
            {
                //show payment page here
                switch (paymentPage.PaymentPageContentType)
                {
                    case PaymentPageContentType.Url:
                        return Redirect(paymentPage.Url);
                    case PaymentPageContentType.Html:
                        SetPaymentPageInfoToViewBag(paymentPage);
                        return View("PaymentPage");
                }
            }

            // if we got here - no payment page is shown
            return RedirectToAction("OrderCreated", new { id = order.Id });
        }

        [AllowAnonymous]
        public ActionResult OrderCreated(int? id)
        {
            bool isError = false;
            string errorMessage = "";

            if (id == null)
            {
                return HttpNotFound();
            }

            var order = ((ICustomerOrderBL)_bl).GetCustomerOrderById(id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }

            //Apply payment on order
            try
            {
                ((ICustomerOrderBL)_bl).ApplyPaymentOnOrder(id.Value);
            }
            catch(Exception exc)
            {                
                _logger.LogException("ShoppingCartsController", "OrderCreated", exc);
                isError = true;
                errorMessage = ResObject.ErrorText_PaymentCannotBeAppliedOnOrder;
            }
                                        
            if (isError)
            {
                ViewBag.IsError = true;
                ViewBag.ErrorMessage = errorMessage;
            }
            else
            {
                ViewBag.IsError = false;
            }

            return View(order);
        }

        [AllowAnonymous]
        public ActionResult PaymentPageiFrameCallback(int? id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }

            var order = ((ICustomerOrderBL)_bl).GetCustomerOrderById(id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }

            if (order.PaymentOptionId.HasValue && order.PaymentOptionId.Value > 0)
            {
                IPaymentOptionProvider provider = ((IPaymentOptionBL)_bl).GetPaymentOptionProvider(order.PaymentOptionId.Value);
                if (provider != null)
                {
                    ViewBag.PaymentHtmlStr = provider.GetiFrameCallbackHtml(order);
                }
            }

            return View();
        }

        [AllowAnonymous]
        public ActionResult AddToCart(int productId, int count, string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ShoppingCartException(ResObject.ErrorText_IllegalAddToCart);
            }

            var shoppingCart = _eContext.CurrentShoppingCart;
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }
            var productBl = (IProductBL)_bl;
            var product = productBl.GetProductById(productId);
            if (product == null)
            {
                return HttpNotFound();
            }

            if (Session != null)
            {
                if (Session["Wishlist"] is List<int> wishlist && wishlist.Any(x => x == productId))
                    wishlist.Remove(productId);
            }

            if (!IsPostTokenPresent(shoppingCart.Id, token))
            {
                AddPostToken(shoppingCart.Id, token);
                _scbl.AddProductToShoppingCart(shoppingCart, product, count);
            }

            return RedirectToAction("Details", new { shoppingCart.Id });
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult QuickAddToCart(int productId, int count, string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ShoppingCartException(ResObject.ErrorText_IllegalAddToCart);
            }

            var shoppingCart = _eContext.CurrentShoppingCart;
            if (shoppingCart == null)
            {
                return Json(new { status = "error" });
            }

            var productBl = (IProductBL)_bl;
            var product = productBl.GetProductById(productId);
            if (product == null)
            {
                return Json(new { status = "error" });
            }

            if (Session != null)
            {
                if (Session["Wishlist"] is List<int> wishlist && wishlist.Any(x => x == productId))
                    wishlist.Remove(productId);
            }

            if (!IsPostTokenPresent(shoppingCart.Id, token))
            {
                AddPostToken(shoppingCart.Id, token);
                _scbl.AddProductToShoppingCart(shoppingCart, product, count);
            }

            return Json(new { status = "success", oldToken = token, newToken = Guid.NewGuid() });
        }

        [AllowAnonymous]
        public ActionResult RemoveFromCart(int productId, string parentView)
        {
            var productBl = (IShoppingCartProductBL)_bl;
            var product = productBl.GetShoppingCartProductById(productId);
            if (product?.ShoppingCart == null)
            {
                return HttpNotFound();
            }
            var scId = product.ShoppingCart.Id;
            _scbl.RemoveProductFromShoppingCart(product.ShoppingCart, product);
            var view = "Details";
            if (!string.IsNullOrEmpty(parentView))
                view = parentView;
            return RedirectToAction(view, new { Id = scId });
        }
        
                
        private PaymentPageInfo GetPaymentPageInfo(CustomerOrder order)
        {
            PaymentPageInfo paymentPage = null;
            if (order.PaymentOptionId.HasValue && order.PaymentOptionId.Value > 0)
            {
                var paymentOption = ((IPaymentOptionBL) _bl).GetPaymentOptionById(order.PaymentOptionId.Value);
                IPaymentOptionProvider provider =
                    ((IPaymentOptionBL) _bl).GetPaymentOptionProvider(order.PaymentOptionId.Value);
                if (provider != null)
                {
                    var refId = "";
                    var containerCss = paymentOption.PaymentContainerCss;
                    if (order.CustomerPaymentId.HasValue)
                    {
                        var customerPayment = ((ICustomerPaymentBL) _bl).GetCustomerPaymentById(order.CustomerPaymentId.Value);
                        if (customerPayment != null)
                            refId = customerPayment.AccountReferenceId;
                    }

                    var requestUrl = this.Request.Url;
                    if (requestUrl != null)
                    {
                        var callBackUrl = this.Url.Action("OrderCreated", null, null, requestUrl.Scheme) + "/" + order.Id + "/";
                        var iFrameCallbackUrl = this.Url.Action("PaymentPageiFrameCallback", null, null, requestUrl.Scheme) +
                                                "/" + order.Id.ToString() + "/";
                        paymentPage = provider.GetPaymentPage(order, callBackUrl, containerCss, refId, iFrameCallbackUrl);
                    }
                }
            }

            return paymentPage;
        }
        
        
        private void SetPaymentPageInfoToViewBag(PaymentPageInfo paymentPage)
        {
            ViewBag.PaymentHeaderStr = paymentPage.HeadContent;
            ViewBag.PaymentJavaScript = paymentPage.JavaScript;
            ViewBag.PaymentHtmlStr = paymentPage.HtmlContent;
        }

    }
}