// ***********************************************************************
// Assembly         : BAP.eCommerce.DAL
// Author           : Victor Mamray
// Created          : 06-26-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-26-2020
// ***********************************************************************
// <copyright file="eCommerceUnitOfWork.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Data.Entity;

using BAP.Common;
using BAP.DAL;

using BAP.eCommerce.DAL.Entities;

namespace BAP.eCommerce.DAL
{
    /// <summary>
    /// Interface IeCommerceUnitOfWork
    /// Implements the <see cref="BAP.DAL.IUnitOfWork" />
    /// </summary>
    /// <seealso cref="BAP.DAL.IUnitOfWork" />
    public interface IeCommerceUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Gets the manufacturer repository.
        /// </summary>
        /// <value>The manufacturer repository.</value>
        ManufacturerRepository ManufacturerRepository { get; }
        /// <summary>
        /// Gets the supplier repository.
        /// </summary>
        /// <value>The supplier repository.</value>
        SupplierRepository SupplierRepository { get; }
        /// <summary>
        /// Gets the product repository.
        /// </summary>
        /// <value>The product repository.</value>
        ProductRepository ProductRepository { get; }
        /// <summary>
        /// Gets the related product repository.
        /// </summary>
        /// <value>The related product repository.</value>
        RelatedProductRepository RelatedProductRepository { get; }
        /// <summary>
        /// Gets the product category repository.
        /// </summary>
        /// <value>The product category repository.</value>
        ProductCategoryRepository ProductCategoryRepository { get; }
        /// <summary>
        /// Gets the product option repository.
        /// </summary>
        /// <value>The product option repository.</value>
        ProductOptionRepository ProductOptionRepository { get; }
        /// <summary>
        /// Gets the product option item repository.
        /// </summary>
        /// <value>The product option item repository.</value>
        ProductOptionItemRepository ProductOptionItemRepository { get; }
        /// <summary>
        /// Gets the shopping cart repository.
        /// </summary>
        /// <value>The shopping cart repository.</value>
        ShoppingCartRepository ShoppingCartRepository { get; }
        /// <summary>
        /// Gets the shopping cart product repository.
        /// </summary>
        /// <value>The shopping cart product repository.</value>
        ShoppingCartProductRepository ShoppingCartProductRepository { get; }
        /// <summary>
        /// Gets the address repository.
        /// </summary>
        /// <value>The address repository.</value>
        AddressRepository AddressRepository { get; }
        /// <summary>
        /// Gets the discount coupon repository.
        /// </summary>
        /// <value>The discount coupon repository.</value>
        DiscountCouponRepository DiscountCouponRepository { get; }
        /// <summary>
        /// Gets the payment option repository.
        /// </summary>
        /// <value>The payment option repository.</value>
        PaymentOptionRepository PaymentOptionRepository { get; }
        /// <summary>
        /// Gets the shipping carrier repository.
        /// </summary>
        /// <value>The shipping carrier repository.</value>
        ShippingCarrierRepository ShippingCarrierRepository { get; }
        /// <summary>
        /// Gets the shipping option repository.
        /// </summary>
        /// <value>The shipping option repository.</value>
        ShippingOptionRepository ShippingOptionRepository { get; }
        /// <summary>
        /// Gets the customer payment repository.
        /// </summary>
        /// <value>The customer payment repository.</value>
        CustomerPaymentRepository CustomerPaymentRepository { get; }
        /// <summary>
        /// Gets the customer order repository.
        /// </summary>
        /// <value>The customer order repository.</value>
        CustomerOrderRepository CustomerOrderRepository { get; }
        /// <summary>
        /// Gets the customer order payment repository.
        /// </summary>
        /// <value>The customer order payment repository.</value>
        CustomerOrderPaymentRepository CustomerOrderPaymentRepository { get; }
        /// <summary>
        /// Gets the order item repository.
        /// </summary>
        /// <value>The order item repository.</value>
        OrderItemRepository OrderItemRepository { get; }
        /// <summary>
        /// Gets the customer repository.
        /// </summary>
        /// <value>The customer repository.</value>
        CustomerRepository CustomerRepository { get; }
        /// <summary>
        /// Gets the store repository.
        /// </summary>
        /// <value>The store repository.</value>
        StoreRepository StoreRepository { get; }
    }

    /// <summary>
    /// Class eCommerceUnitOfWork.
    /// Implements the <see cref="BAP.DAL.UnitOfWork" />
    /// Implements the <see cref="BAP.eCommerce.DAL.IeCommerceUnitOfWork" />
    /// </summary>
    /// <seealso cref="BAP.DAL.UnitOfWork" />
    /// <seealso cref="BAP.eCommerce.DAL.IeCommerceUnitOfWork" />
    public class eCommerceUnitOfWork : UnitOfWork, IeCommerceUnitOfWork
    {
        /// <summary>
        /// The manufacturer repository
        /// </summary>
        private ManufacturerRepository _manufacturerRepository;
        /// <summary>
        /// The supplier repository
        /// </summary>
        private SupplierRepository _supplierRepository;
        /// <summary>
        /// The product repository
        /// </summary>
        private ProductRepository _productRepository;
        /// <summary>
        /// The related product repository
        /// </summary>
        private RelatedProductRepository _relatedProductRepository;
        /// <summary>
        /// The product category repository
        /// </summary>
        private ProductCategoryRepository _productCategoryRepository;
        /// <summary>
        /// The product option repository
        /// </summary>
        private ProductOptionRepository _productOptionRepository;
        /// <summary>
        /// The product option item repository
        /// </summary>
        private ProductOptionItemRepository _productOptionItemRepository;
        /// <summary>
        /// The shopping cart repository
        /// </summary>
        private ShoppingCartRepository _shoppingCartRepository;
        /// <summary>
        /// The shopping cart product repository
        /// </summary>
        private ShoppingCartProductRepository _shoppingCartProductRepository;
        /// <summary>
        /// The address repository
        /// </summary>
        private AddressRepository _addressRepository;
        /// <summary>
        /// The discount coupon repository
        /// </summary>
        private DiscountCouponRepository _discountCouponRepository;
        /// <summary>
        /// The payment option repository
        /// </summary>
        private PaymentOptionRepository _paymentOptionRepository;
        /// <summary>
        /// The shipping carrier repository
        /// </summary>
        private ShippingCarrierRepository _shippingCarrierRepository;
        /// <summary>
        /// The shipping option repository
        /// </summary>
        private ShippingOptionRepository _shippingOptionRepository;
        /// <summary>
        /// The customer payment repository
        /// </summary>
        private CustomerPaymentRepository _CustomerPaymentRepository;
        /// <summary>
        /// The customer order repository
        /// </summary>
        private CustomerOrderRepository _CustomerOrderRepository;
        /// <summary>
        /// The customer order payment repository
        /// </summary>
        private CustomerOrderPaymentRepository _CustomerOrderPaymentRepository;
        /// <summary>
        /// The order item repository
        /// </summary>
        private OrderItemRepository _OrderItemRepository;
        /// <summary>
        /// The customer repository
        /// </summary>
        private CustomerRepository _CustomerRepository;
        /// <summary>
        /// The store repository
        /// </summary>
        private StoreRepository _StoreRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="eCommerceUnitOfWork"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        public eCommerceUnitOfWork(IConfigHelper settings, IAuthorizationContext context) : base(settings, new eCommerceDB(settings), context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="eCommerceUnitOfWork"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="db">The database.</param>
        /// <param name="context">The context.</param>
        public eCommerceUnitOfWork(IConfigHelper settings, DbContext db, IAuthorizationContext context) : base(settings, db, context)
        {            
        }

        /// <summary>
        /// Gets the manufacturer repository.
        /// </summary>
        /// <value>The manufacturer repository.</value>
        public ManufacturerRepository ManufacturerRepository
        {
            get
            {
                if (this._manufacturerRepository == null)
                {
                    this._manufacturerRepository = new ManufacturerRepository(_db, new eCommerceAuthorizationHelper<Manufacturer>(_settings, _authContext), _settings);
                }
                return _manufacturerRepository;
            }
        }

        /// <summary>
        /// Gets the supplier repository.
        /// </summary>
        /// <value>The supplier repository.</value>
        public SupplierRepository SupplierRepository
        {
            get
            {
                if (this._supplierRepository == null)
                {
                    this._supplierRepository = new SupplierRepository(_db, new eCommerceAuthorizationHelper<Supplier>(_settings, _authContext), _settings);
                }
                return _supplierRepository;
            }
        }

        /// <summary>
        /// Gets the product repository.
        /// </summary>
        /// <value>The product repository.</value>
        public ProductRepository ProductRepository
        {
            get
            {
                if (this._productRepository == null)
                {
                    this._productRepository = new ProductRepository(_db, new eCommerceAuthorizationHelper<Product>(_settings, _authContext), _settings);
                }
                return _productRepository;
            }
        }

        /// <summary>
        /// Gets the related product repository.
        /// </summary>
        /// <value>The related product repository.</value>
        public RelatedProductRepository RelatedProductRepository
        {
            get
            {
                if (this._relatedProductRepository == null)
                {
                    this._relatedProductRepository = new RelatedProductRepository(_db, new eCommerceAuthorizationHelper<RelatedProduct>(_settings, _authContext), _settings);
                }
                return _relatedProductRepository;
            }
        }

        /// <summary>
        /// Gets the product category repository.
        /// </summary>
        /// <value>The product category repository.</value>
        public ProductCategoryRepository ProductCategoryRepository
        {
            get
            {
                if (this._productCategoryRepository == null)
                {
                    this._productCategoryRepository = new ProductCategoryRepository(_db, new eCommerceAuthorizationHelper<ProductCategory>(_settings, _authContext), _settings);
                }
                return _productCategoryRepository;
            }
        }

        /// <summary>
        /// Gets the product option repository.
        /// </summary>
        /// <value>The product option repository.</value>
        public ProductOptionRepository ProductOptionRepository
        {
            get
            {
                if (this._productOptionRepository == null)
                {
                    this._productOptionRepository = new ProductOptionRepository(_db, new eCommerceAuthorizationHelper<ProductOption>(_settings, _authContext), _settings);
                }
                return _productOptionRepository;
            }
        }

        /// <summary>
        /// Gets the product option item repository.
        /// </summary>
        /// <value>The product option item repository.</value>
        public ProductOptionItemRepository ProductOptionItemRepository
        {
            get
            {
                if (this._productOptionItemRepository == null)
                {
                    this._productOptionItemRepository = new ProductOptionItemRepository(_db, new eCommerceAuthorizationHelper<ProductOptionItem>(_settings, _authContext), _settings);
                }
                return _productOptionItemRepository;
            }
        }

        /// <summary>
        /// Gets the shopping cart repository.
        /// </summary>
        /// <value>The shopping cart repository.</value>
        public ShoppingCartRepository ShoppingCartRepository
        {
            get
            {
                if (this._shoppingCartRepository == null)
                {
                    this._shoppingCartRepository = new ShoppingCartRepository(_db, new eCommerceAuthorizationHelper<ShoppingCart>(_settings, _authContext), _settings);
                }
                return _shoppingCartRepository;
            }
        }

        /// <summary>
        /// Gets the shopping cart product repository.
        /// </summary>
        /// <value>The shopping cart product repository.</value>
        public ShoppingCartProductRepository ShoppingCartProductRepository
        {
            get
            {
                if (this._shoppingCartProductRepository == null)
                {
                    this._shoppingCartProductRepository = new ShoppingCartProductRepository(_db, new eCommerceAuthorizationHelper<ShoppingCartProduct>(_settings, _authContext), _settings);
                }
                return _shoppingCartProductRepository;
            }
        }

        /// <summary>
        /// Gets the address repository.
        /// </summary>
        /// <value>The address repository.</value>
        public AddressRepository AddressRepository
        {
            get
            {
                if (this._addressRepository == null)
                {
                    this._addressRepository = new AddressRepository(_db, new eCommerceAuthorizationHelper<Address>(_settings, _authContext), _settings);
                }
                return _addressRepository;
            }
        }

        /// <summary>
        /// Gets the discount coupon repository.
        /// </summary>
        /// <value>The discount coupon repository.</value>
        public DiscountCouponRepository DiscountCouponRepository
        {
            get
            {
                if (this._discountCouponRepository == null)
                {
                    this._discountCouponRepository = new DiscountCouponRepository(_db, new eCommerceAuthorizationHelper<DiscountCoupon>(_settings, _authContext), _settings);
                }
                return _discountCouponRepository;
            }
        }

        /// <summary>
        /// Gets the payment option repository.
        /// </summary>
        /// <value>The payment option repository.</value>
        public PaymentOptionRepository PaymentOptionRepository
        {
            get
            {
                if (this._paymentOptionRepository == null)
                {
                    this._paymentOptionRepository = new PaymentOptionRepository(_db, new eCommerceAuthorizationHelper<PaymentOption>(_settings, _authContext), _settings);
                }
                return _paymentOptionRepository;
            }
        }

        /// <summary>
        /// Gets the shipping carrier repository.
        /// </summary>
        /// <value>The shipping carrier repository.</value>
        public ShippingCarrierRepository ShippingCarrierRepository
        {
            get
            {
                if (this._shippingCarrierRepository == null)
                {
                    this._shippingCarrierRepository = new ShippingCarrierRepository(_db, new eCommerceAuthorizationHelper<ShippingCarrier>(_settings, _authContext), _settings);
                }
                return _shippingCarrierRepository;
            }
        }

        /// <summary>
        /// Gets the shipping option repository.
        /// </summary>
        /// <value>The shipping option repository.</value>
        public ShippingOptionRepository ShippingOptionRepository
        {
            get
            {
                if (this._shippingOptionRepository == null)
                {
                    this._shippingOptionRepository = new ShippingOptionRepository(_db, new eCommerceAuthorizationHelper<ShippingOption>(_settings, _authContext), _settings);
                }
                return _shippingOptionRepository;
            }
        }

        /// <summary>
        /// Gets the customer payment repository.
        /// </summary>
        /// <value>The customer payment repository.</value>
        public CustomerPaymentRepository CustomerPaymentRepository
        {
            get
            {
                if (this._CustomerPaymentRepository == null)
                {
                    this._CustomerPaymentRepository = new CustomerPaymentRepository(_db, new eCommerceAuthorizationHelper<CustomerPayment>(_settings, _authContext), _settings);
                }
                return _CustomerPaymentRepository;
            }
        }

        /// <summary>
        /// Gets the customer order repository.
        /// </summary>
        /// <value>The customer order repository.</value>
        public CustomerOrderRepository CustomerOrderRepository
        {
            get
            {
                if (this._CustomerOrderRepository == null)
                {
                    this._CustomerOrderRepository = new CustomerOrderRepository(_db, new eCommerceAuthorizationHelper<CustomerOrder>(_settings, _authContext), _settings);
                }
                return _CustomerOrderRepository;
            }
        }

        /// <summary>
        /// Gets the order item repository.
        /// </summary>
        /// <value>The order item repository.</value>
        public OrderItemRepository OrderItemRepository
        {
            get
            {
                if (this._OrderItemRepository == null)
                {
                    this._OrderItemRepository = new OrderItemRepository(_db, new eCommerceAuthorizationHelper<OrderItem>(_settings, _authContext), _settings);
                }
                return _OrderItemRepository;
            }
        }


        /// <summary>
        /// Gets the customer repository.
        /// </summary>
        /// <value>The customer repository.</value>
        public CustomerRepository CustomerRepository
        {
            get
            {
                if (this._CustomerRepository == null)
                {
                    this._CustomerRepository = new CustomerRepository(_db, new eCommerceAuthorizationHelper<Customer>(_settings, _authContext), _settings);
                }
                return _CustomerRepository;
            }
        }

        /// <summary>
        /// Gets the customer order payment repository.
        /// </summary>
        /// <value>The customer order payment repository.</value>
        public CustomerOrderPaymentRepository CustomerOrderPaymentRepository
        {
            get
            {
                if (this._CustomerOrderPaymentRepository == null)
                {
                    this._CustomerOrderPaymentRepository = new CustomerOrderPaymentRepository(_db, new eCommerceAuthorizationHelper<CustomerOrderPayment>(_settings, _authContext), _settings);
                }
                return _CustomerOrderPaymentRepository;
            }
        }

        /// <summary>
        /// Gets the store repository.
        /// </summary>
        /// <value>The store repository.</value>
        public StoreRepository StoreRepository
        {
            get
            {
                if (this._StoreRepository == null)
                {
                    this._StoreRepository = new StoreRepository(_db, new eCommerceAuthorizationHelper<Store>(_settings, _authContext), _settings);
                }
                return _StoreRepository;
            }
        }
    }
}
