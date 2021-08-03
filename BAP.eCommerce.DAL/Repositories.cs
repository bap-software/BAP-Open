// ***********************************************************************
// Assembly         : BAP.eCommerce.DAL
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="Repositories.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Data.Entity;

using BAP.Common;
using BAP.DAL;

using BAP.eCommerce.DAL.Entities;
using BAP.eCommerce.DAL;

namespace BAP.eCommerce.DAL
{
    /// <summary>
    /// Interface IManufacturerRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.Manufacturer}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.Manufacturer}" />
    public interface IManufacturerRepository : IGenericDataRepository<Manufacturer>
    {

    }

    /// <summary>
    /// Class ManufacturerRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.Manufacturer}" />
    /// Implements the <see cref="BAP.eCommerce.DAL.IManufacturerRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.Manufacturer}" />
    /// <seealso cref="BAP.eCommerce.DAL.IManufacturerRepository" />
    public class ManufacturerRepository : GenericDataRepository<Manufacturer>, IManufacturerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManufacturerRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal ManufacturerRepository(DbContext context, IAuthorizationHelper<Manufacturer> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface ISupplierRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.Supplier}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.Supplier}" />
    public interface ISupplierRepository : IGenericDataRepository<Supplier>
    {

    }

    /// <summary>
    /// Class SupplierRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.Supplier}" />
    /// Implements the <see cref="BAP.eCommerce.DAL.ISupplierRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.Supplier}" />
    /// <seealso cref="BAP.eCommerce.DAL.ISupplierRepository" />
    public class SupplierRepository : GenericDataRepository<Supplier>, ISupplierRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal SupplierRepository(DbContext context, IAuthorizationHelper<Supplier> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IProductRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.Product}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.Product}" />
    public interface IProductRepository : IGenericDataRepository<Product>
    {

    }

    /// <summary>
    /// Class ProductRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.Product}" />
    /// Implements the <see cref="BAP.eCommerce.DAL.IProductRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.Product}" />
    /// <seealso cref="BAP.eCommerce.DAL.IProductRepository" />
    public class ProductRepository : GenericDataRepository<Product>, IProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal ProductRepository(DbContext context, IAuthorizationHelper<Product> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IRelatedProductRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.RelatedProduct}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.RelatedProduct}" />
    public interface IRelatedProductRepository : IGenericDataRepository<RelatedProduct>
    {

    }

    /// <summary>
    /// Class RelatedProductRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.RelatedProduct}" />
    /// Implements the <see cref="BAP.eCommerce.DAL.IRelatedProductRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.RelatedProduct}" />
    /// <seealso cref="BAP.eCommerce.DAL.IRelatedProductRepository" />
    public class RelatedProductRepository : GenericDataRepository<RelatedProduct>, IRelatedProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RelatedProductRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal RelatedProductRepository(DbContext context, IAuthorizationHelper<RelatedProduct> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IProductCategoryRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.ProductCategory}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.ProductCategory}" />
    public interface IProductCategoryRepository : IGenericDataRepository<ProductCategory>
    {

    }

    /// <summary>
    /// Class ProductCategoryRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.ProductCategory}" />
    /// Implements the <see cref="BAP.eCommerce.DAL.IProductCategoryRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.ProductCategory}" />
    /// <seealso cref="BAP.eCommerce.DAL.IProductCategoryRepository" />
    public class ProductCategoryRepository : GenericDataRepository<ProductCategory>, IProductCategoryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCategoryRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal ProductCategoryRepository(DbContext context, IAuthorizationHelper<ProductCategory> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IProductOptionRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.ProductOption}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.ProductOption}" />
    public interface IProductOptionRepository : IGenericDataRepository<ProductOption>
    {

    }

    /// <summary>
    /// Class ProductOptionRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.ProductOption}" />
    /// Implements the <see cref="BAP.eCommerce.DAL.IProductOptionRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.ProductOption}" />
    /// <seealso cref="BAP.eCommerce.DAL.IProductOptionRepository" />
    public class ProductOptionRepository : GenericDataRepository<ProductOption>, IProductOptionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductOptionRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal ProductOptionRepository(DbContext context, IAuthorizationHelper<ProductOption> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IProductOptionItemRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.ProductOptionItem}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.ProductOptionItem}" />
    public interface IProductOptionItemRepository : IGenericDataRepository<ProductOptionItem>
    {

    }

    /// <summary>
    /// Class ProductOptionItemRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.ProductOptionItem}" />
    /// Implements the <see cref="BAP.eCommerce.DAL.IProductOptionItemRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.ProductOptionItem}" />
    /// <seealso cref="BAP.eCommerce.DAL.IProductOptionItemRepository" />
    public class ProductOptionItemRepository : GenericDataRepository<ProductOptionItem>, IProductOptionItemRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductOptionItemRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal ProductOptionItemRepository(DbContext context, IAuthorizationHelper<ProductOptionItem> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IAddressRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.Address}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.Address}" />
    public interface IAddressRepository : IGenericDataRepository<Address>
    {

    }

    /// <summary>
    /// Class AddressRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.Address}" />
    /// Implements the <see cref="BAP.eCommerce.DAL.IAddressRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.Address}" />
    /// <seealso cref="BAP.eCommerce.DAL.IAddressRepository" />
    public class AddressRepository : GenericDataRepository<Address>, IAddressRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal AddressRepository(DbContext context, IAuthorizationHelper<Address> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IDiscountCouponRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.DiscountCoupon}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.DiscountCoupon}" />
    public interface IDiscountCouponRepository : IGenericDataRepository<DiscountCoupon>
    {

    }

    /// <summary>
    /// Class DiscountCouponRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.DiscountCoupon}" />
    /// Implements the <see cref="BAP.eCommerce.DAL.IDiscountCouponRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.DiscountCoupon}" />
    /// <seealso cref="BAP.eCommerce.DAL.IDiscountCouponRepository" />
    public class DiscountCouponRepository : GenericDataRepository<DiscountCoupon>, IDiscountCouponRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscountCouponRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal DiscountCouponRepository(DbContext context, IAuthorizationHelper<DiscountCoupon> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IPaymentOptionRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.PaymentOption}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.PaymentOption}" />
    public interface IPaymentOptionRepository : IGenericDataRepository<PaymentOption>
    {

    }

    /// <summary>
    /// Class PaymentOptionRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.PaymentOption}" />
    /// Implements the <see cref="BAP.eCommerce.DAL.IPaymentOptionRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.PaymentOption}" />
    /// <seealso cref="BAP.eCommerce.DAL.IPaymentOptionRepository" />
    public class PaymentOptionRepository : GenericDataRepository<PaymentOption>, IPaymentOptionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentOptionRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal PaymentOptionRepository(DbContext context, IAuthorizationHelper<PaymentOption> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IShippingCarrierRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.ShippingCarrier}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.ShippingCarrier}" />
    public interface IShippingCarrierRepository : IGenericDataRepository<ShippingCarrier>
    {

    }

    /// <summary>
    /// Class ShippingCarrierRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.ShippingCarrier}" />
    /// Implements the <see cref="BAP.eCommerce.DAL.IShippingCarrierRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.ShippingCarrier}" />
    /// <seealso cref="BAP.eCommerce.DAL.IShippingCarrierRepository" />
    public class ShippingCarrierRepository : GenericDataRepository<ShippingCarrier>, IShippingCarrierRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShippingCarrierRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal ShippingCarrierRepository(DbContext context, IAuthorizationHelper<ShippingCarrier> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IShippingOptionRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.ShippingOption}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.ShippingOption}" />
    public interface IShippingOptionRepository : IGenericDataRepository<ShippingOption>
    {

    }

    /// <summary>
    /// Class ShippingOptionRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.ShippingOption}" />
    /// Implements the <see cref="BAP.eCommerce.DAL.IShippingOptionRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.ShippingOption}" />
    /// <seealso cref="BAP.eCommerce.DAL.IShippingOptionRepository" />
    public class ShippingOptionRepository : GenericDataRepository<ShippingOption>, IShippingOptionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShippingOptionRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal ShippingOptionRepository(DbContext context, IAuthorizationHelper<ShippingOption> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IShoppingCartRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.ShoppingCart}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.ShoppingCart}" />
    public interface IShoppingCartRepository : IGenericDataRepository<ShoppingCart>
    {

    }

    /// <summary>
    /// Class ShoppingCartRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.ShoppingCart}" />
    /// Implements the <see cref="BAP.eCommerce.DAL.IShoppingCartRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.ShoppingCart}" />
    /// <seealso cref="BAP.eCommerce.DAL.IShoppingCartRepository" />
    public class ShoppingCartRepository : GenericDataRepository<ShoppingCart>, IShoppingCartRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal ShoppingCartRepository(DbContext context, IAuthorizationHelper<ShoppingCart> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IShoppingCartProductRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.ShoppingCartProduct}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.ShoppingCartProduct}" />
    public interface IShoppingCartProductRepository : IGenericDataRepository<ShoppingCartProduct>
    {

    }

    /// <summary>
    /// Class ShoppingCartProductRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.ShoppingCartProduct}" />
    /// Implements the <see cref="BAP.eCommerce.DAL.IShoppingCartProductRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.ShoppingCartProduct}" />
    /// <seealso cref="BAP.eCommerce.DAL.IShoppingCartProductRepository" />
    public class ShoppingCartProductRepository : GenericDataRepository<ShoppingCartProduct>, IShoppingCartProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartProductRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal ShoppingCartProductRepository(DbContext context, IAuthorizationHelper<ShoppingCartProduct> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface ICustomerPaymentRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.CustomerPayment}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.CustomerPayment}" />
    public interface ICustomerPaymentRepository : IGenericDataRepository<CustomerPayment>
    {

    }
    /// <summary>
    /// Class CustomerPaymentRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.CustomerPayment}" />
    /// Implements the <see cref="BAP.eCommerce.DAL.ICustomerPaymentRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.CustomerPayment}" />
    /// <seealso cref="BAP.eCommerce.DAL.ICustomerPaymentRepository" />
    public class CustomerPaymentRepository : GenericDataRepository<CustomerPayment>, ICustomerPaymentRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerPaymentRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal CustomerPaymentRepository(DbContext context, IAuthorizationHelper<CustomerPayment> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface ICustomerOrderRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.CustomerOrder}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.CustomerOrder}" />
    public interface ICustomerOrderRepository : IGenericDataRepository<CustomerOrder>
    {

    }

    /// <summary>
    /// Class CustomerOrderRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.CustomerOrder}" />
    /// Implements the <see cref="BAP.eCommerce.DAL.ICustomerOrderRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.CustomerOrder}" />
    /// <seealso cref="BAP.eCommerce.DAL.ICustomerOrderRepository" />
    public class CustomerOrderRepository : GenericDataRepository<CustomerOrder>, ICustomerOrderRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerOrderRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal CustomerOrderRepository(DbContext context, IAuthorizationHelper<CustomerOrder> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IOrderItemRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.OrderItem}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.OrderItem}" />
    public interface IOrderItemRepository : IGenericDataRepository<OrderItem>
    {

    }
    /// <summary>
    /// Class OrderItemRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.OrderItem}" />
    /// Implements the <see cref="BAP.eCommerce.DAL.IOrderItemRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.OrderItem}" />
    /// <seealso cref="BAP.eCommerce.DAL.IOrderItemRepository" />
    public class OrderItemRepository : GenericDataRepository<OrderItem>, IOrderItemRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal OrderItemRepository(DbContext context, IAuthorizationHelper<OrderItem> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface ICustomerRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.Customer}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.Customer}" />
    public interface ICustomerRepository : IGenericDataRepository<Customer>
    {

    }
    /// <summary>
    /// Class CustomerRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.Customer}" />
    /// Implements the <see cref="BAP.eCommerce.DAL.ICustomerRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.Customer}" />
    /// <seealso cref="BAP.eCommerce.DAL.ICustomerRepository" />
    public class CustomerRepository : GenericDataRepository<Customer>, ICustomerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal CustomerRepository(DbContext context, IAuthorizationHelper<Customer> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface ICustomerOrderPaymentRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.CustomerOrderPayment}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.CustomerOrderPayment}" />
    public interface ICustomerOrderPaymentRepository : IGenericDataRepository<CustomerOrderPayment>
    {

    }
    /// <summary>
    /// Class CustomerOrderPaymentRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.CustomerOrderPayment}" />
    /// Implements the <see cref="BAP.eCommerce.DAL.ICustomerOrderPaymentRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.CustomerOrderPayment}" />
    /// <seealso cref="BAP.eCommerce.DAL.ICustomerOrderPaymentRepository" />
    public class CustomerOrderPaymentRepository : GenericDataRepository<CustomerOrderPayment>, ICustomerOrderPaymentRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerOrderPaymentRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal CustomerOrderPaymentRepository(DbContext context, IAuthorizationHelper<CustomerOrderPayment> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IStoreRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.Store}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.eCommerce.DAL.Entities.Store}" />
    public interface IStoreRepository : IGenericDataRepository<Store>
    {

    }
    /// <summary>
    /// Class StoreRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.Store}" />
    /// Implements the <see cref="BAP.eCommerce.DAL.IStoreRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.eCommerce.DAL.Entities.Store}" />
    /// <seealso cref="BAP.eCommerce.DAL.IStoreRepository" />
    public class StoreRepository : GenericDataRepository<Store>, IStoreRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal StoreRepository(DbContext context, IAuthorizationHelper<Store> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

}
