// ***********************************************************************
// Assembly         : BAP.eCommerce.DAL
// Author           : Victor Mamray
// Created          : 05-02-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="eCommerceAuthorizationHelper.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.Common;
using BAP.DAL;

namespace BAP.eCommerce.DAL
{
    /// <summary>
    /// Class eCommerceAuthorizationHelper.
    /// Implements the <see cref="BAP.DAL.AuthorizationHelper{T}" />
    /// Implements the <see cref="BAP.Common.IAuthorizationHelper{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="BAP.DAL.AuthorizationHelper{T}" />
    /// <seealso cref="BAP.Common.IAuthorizationHelper{T}" />
    public class eCommerceAuthorizationHelper<T> : AuthorizationHelper<T>, IAuthorizationHelper<T> where T : class, IBapEntity
    {
        /// <summary>
        /// Initializes the authentication matrix.
        /// </summary>
        protected override void InitAuthMatrix()
        {
            base.InitAuthMatrix();
            if (AuthMatrix != null)
            {
                AuthMatrix.Add(new AuthItem { EntityName = "Product", Roles = 127, Permissions = 1843151 });
                AuthMatrix.Add(new AuthItem { EntityName = "RelatedProduct", Roles = 127, Permissions = 1843151 });
                AuthMatrix.Add(new AuthItem { EntityName = "Manufacturer", Roles = 127, Permissions = 1842895 });
                AuthMatrix.Add(new AuthItem { EntityName = "Supplier", Roles = 127, Permissions = 1842703 });
                
                AuthMatrix.Add(new AuthItem { EntityName = "ProductCategory", Roles = 127, Permissions = 1875535 });
                AuthMatrix.Add(new AuthItem { EntityName = "ProductOption", Roles = 127, Permissions = 1843151 });
                AuthMatrix.Add(new AuthItem { EntityName = "ProductOptionItem", Roles = 127, Permissions = 1843151 });
                
                AuthMatrix.Add(new AuthItem { EntityName = "ShoppingCart", Roles = 127, Permissions = 1867775 });
                AuthMatrix.Add(new AuthItem { EntityName = "ShoppingCartProduct", Roles = 127, Permissions = 1867775 });
                AuthMatrix.Add(new AuthItem { EntityName = "Address", Roles = 127, Permissions = 1850975 });
                AuthMatrix.Add(new AuthItem { EntityName = "DiscountCoupon", Roles = 127, Permissions = 1842703 });
                AuthMatrix.Add(new AuthItem { EntityName = "PaymentOption", Roles = 127, Permissions = 1875535 });
                AuthMatrix.Add(new AuthItem { EntityName = "ShippingCarrier", Roles = 127, Permissions = 1875535 });
                AuthMatrix.Add(new AuthItem { EntityName = "ShippingOption", Roles = 127, Permissions = 1875535 });

                AuthMatrix.Add(new AuthItem { EntityName = "Customer", Roles = 127, Permissions = 1851007 });
                AuthMatrix.Add(new AuthItem { EntityName = "CustomerPayment", Roles = 127, Permissions = 1851007 });
                AuthMatrix.Add(new AuthItem { EntityName = "CustomerOrder", Roles = 127, Permissions = 1851007 });
                AuthMatrix.Add(new AuthItem { EntityName = "CustomerOrderPayment", Roles = 127, Permissions = 1851007 });
                AuthMatrix.Add(new AuthItem { EntityName = "OrderItem", Roles = 127, Permissions = 15999 });

                AuthMatrix.Add(new AuthItem { EntityName = "Store", Roles = 127, Permissions = 1842703 });
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="eCommerceAuthorizationHelper{T}"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        public eCommerceAuthorizationHelper(IConfigHelper settings, IAuthorizationContext context) : base(settings, context)
        {            
        }
    }
}
