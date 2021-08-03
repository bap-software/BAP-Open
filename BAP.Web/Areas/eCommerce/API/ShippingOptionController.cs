using System;
using System.Net;
using System.Web.Http;
using System.Collections.Generic;

using BAP.Common;
using BAP.DAL;
using BAP.eCommerce.BL;
using BAP.eCommerce.BL.DataContracts;
using BAP.eCommerce.DAL.Entities;
using BAP.FileSystem;
using BAP.Log;
using BAP.Lookups;

namespace BAP.Web.Areas.eCommerce.API
{
    [Authorize]
    public class ShippingOptionController : ApiController
    {
        private readonly ILogger _logger;
        private readonly IShippingOptionBL _bl;

        public ShippingOptionController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) 
            : base()
        {
            _logger = logger;
            _bl = new eCommerceBusinessLayer(lookupEngine, fileProc, configHelper, context, logger);
        }

        // GET api/<controller>
        // Method is for public use
        [AllowAnonymous]
        [HttpGet]        
        public IEnumerable<ShippingOptionDC> Get(int cartId)
        {
            try
            {
                IShoppingCartBL cartBL = (IShoppingCartBL)_bl;
                var shoppingCart = cartBL.GetShoppingCartById(cartId);
                return GetShippingOptions(shoppingCart);
            }
            catch(Exception ex)
            {
                _logger.LogException("eCommerce Web API", "Get Shipping Options", new Exception(string.Format("Exception occurred processing web api request for the shopping cart id = {0}", cartId), ex));
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            
        }

        // GET api/<controller>
        // Method is for authenticated user who suppose to have shopping cart already
        [HttpGet]
        public IEnumerable<ShippingOptionDC> Get()
        {
            try
            {            
                IShoppingCartBL cartBL = (IShoppingCartBL)_bl;
                var shoppingCart = cartBL.GetCurrentShoppingCart();
                return GetShippingOptions(shoppingCart);
            }
            catch (Exception ex)
            {
                _logger.LogException("eCommerce Web API", "Get Shipping Options", new Exception("Exception occurred processing web api request for the current shopping cart", ex));
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        private IEnumerable<ShippingOptionDC> GetShippingOptions(ShoppingCart shoppingCart)
        {
            return _bl.GetShippingOptions(shoppingCart);
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