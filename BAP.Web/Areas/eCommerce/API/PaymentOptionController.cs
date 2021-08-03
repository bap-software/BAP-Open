using System;
using System.Net;
using System.Web.Http;
using System.Collections.Generic;

using BAP.Common;
using BAP.eCommerce.BL;
using BAP.eCommerce.BL.DataContracts;
using BAP.FileSystem;
using BAP.Log;
using BAP.Lookups;
using BAP.DAL;

namespace BAP.Web.Areas.eCommerce.API
{
    [Authorize]
    public class PaymentOptionController : ApiController
    {
        private readonly IPaymentOptionBL _bl;

        public PaymentOptionController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) 
            : base()
        {
            _bl = new eCommerceBusinessLayer(lookupEngine, fileProc, configHelper, context, logger);
        }

        [AllowAnonymous]
        // GET api/<controller>
        public IEnumerable<PaymentOtionDC> Get(int cartId)
        {
            IShoppingCartBL cartBL = (IShoppingCartBL)_bl;
            var shoppingCart = cartBL.GetShoppingCartById(cartId);
            return _bl.GetPaymentOptions(shoppingCart);
        }

        // GET api/<controller>
        public IEnumerable<PaymentOtionDC> Get()
        {
            IShoppingCartBL cartBL = (IShoppingCartBL)_bl;
            var shoppingCart = cartBL.GetCurrentShoppingCart();
            return _bl.GetPaymentOptions(shoppingCart);
        }     
               
        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            throw new HttpResponseException(HttpStatusCode.MethodNotAllowed);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
            throw new HttpResponseException(HttpStatusCode.MethodNotAllowed);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            throw new HttpResponseException(HttpStatusCode.MethodNotAllowed);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(_bl != null)
                    ((IDisposable)_bl).Dispose();
            }
            base.Dispose(disposing);
        }
    }
}