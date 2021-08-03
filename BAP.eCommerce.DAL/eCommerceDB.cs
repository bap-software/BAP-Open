// ***********************************************************************
// Assembly         : BAP.eCommerce.DAL
// Author           : Victor Mamray
// Created          : 06-26-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-26-2020
// ***********************************************************************
// <copyright file="eCommerceDB.cs" company="BAP Software Ltd.">
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
    /// Class eCommerceDB.
    /// Implements the <see cref="BAP.DAL.BapDb" />
    /// </summary>
    /// <seealso cref="BAP.DAL.BapDb" />
    public partial class eCommerceDB : BapDb
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="eCommerceDB"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public eCommerceDB(IConfigHelper config) : base(config)
        {
        }

        /// <summary>
        /// Gets or sets the addresses.
        /// </summary>
        /// <value>The addresses.</value>
        public DbSet<Address> Addresses { get; set; }

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        /// <value>The customers.</value>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the customer orders.
        /// </summary>
        /// <value>The customer orders.</value>
        public DbSet<CustomerOrder> CustomerOrders { get; set; }

        /// <summary>
        /// Gets or sets the customer order payments.
        /// </summary>
        /// <value>The customer order payments.</value>
        public DbSet<CustomerOrderPayment> CustomerOrderPayments { get; set; }

        /// <summary>
        /// Gets or sets the customer payments.
        /// </summary>
        /// <value>The customer payments.</value>
        public DbSet<CustomerPayment> CustomerPayments { get; set; }

        /// <summary>
        /// Gets or sets the discount coupons.
        /// </summary>
        /// <value>The discount coupons.</value>
        public DbSet<DiscountCoupon> DiscountCoupons { get; set; }

        /// <summary>
        /// Gets or sets the manufacturers.
        /// </summary>
        /// <value>The manufacturers.</value>
        public DbSet<Manufacturer> Manufacturers { get; set; }

        /// <summary>
        /// Gets or sets the payment options.
        /// </summary>
        /// <value>The payment options.</value>
        public DbSet<PaymentOption> PaymentOptions { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>The products.</value>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the related products.
        /// </summary>
        /// <value>The related products.</value>
        public DbSet<RelatedProduct> RelatedProducts { get; set; }

        /// <summary>
        /// Gets or sets the order items.
        /// </summary>
        /// <value>The order items.</value>
        public DbSet<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// Gets or sets the product categories.
        /// </summary>
        /// <value>The product categories.</value>
        public DbSet<ProductCategory> ProductCategories { get; set; }

        /// <summary>
        /// Gets or sets the product options.
        /// </summary>
        /// <value>The product options.</value>
        public DbSet<ProductOption> ProductOptions { get; set; }

        /// <summary>
        /// Gets or sets the product option items.
        /// </summary>
        /// <value>The product option items.</value>
        public DbSet<ProductOptionItem> ProductOptionItems { get; set; }

        /// <summary>
        /// Gets or sets the shipping carriers.
        /// </summary>
        /// <value>The shipping carriers.</value>
        public DbSet<ShippingCarrier> ShippingCarriers { get; set; }

        /// <summary>
        /// Gets or sets the shipping options.
        /// </summary>
        /// <value>The shipping options.</value>
        public DbSet<ShippingOption> ShippingOptions { get; set; }

        /// <summary>
        /// Gets or sets the shopping carts.
        /// </summary>
        /// <value>The shopping carts.</value>
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        /// <summary>
        /// Gets or sets the shopping cart products.
        /// </summary>
        /// <value>The shopping cart products.</value>
        public DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }

        /// <summary>
        /// Gets or sets the suppliers.
        /// </summary>
        /// <value>The suppliers.</value>
        public DbSet<Supplier> Suppliers { get; set; }

        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RelatedProduct>().HasKey(rp => new { rp.ProductId, rp.SimilarProductId });

            modelBuilder.Entity<Product>()
                .HasMany(p => p.RelatedProducts)
                .WithRequired(rp => rp.Product)
                .HasForeignKey(rp => rp.ProductId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RelatedProduct>()
                .HasRequired(rp => rp.SimilarProduct)
                .WithMany()
                .HasForeignKey(rp => rp.SimilarProductId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ShippingOption>()
                        .HasMany<PaymentOption>(s => s.AllowedPaymentOptions)
                        .WithMany(c => c.ShippingOptions)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("ShippingOptionId");
                            cs.MapRightKey("PaymentOptionId");
                            cs.ToTable("ShippingPayment");
                        });

            modelBuilder.Entity<DiscountCoupon>()
                        .HasMany<Product>(s => s.ProductsApplied)
                        .WithMany(c => c.Discounts)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("DiscountCouponId");
                            cs.MapRightKey("ProductId");
                            cs.ToTable("DiscountProduct");
                        });


            modelBuilder.Entity<ProductOption>()
                        .HasMany<Product>(s => s.Products)
                        .WithMany(c => c.Options)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("ProductOptionId");
                            cs.MapRightKey("ProductId");
                            cs.ToTable("ProductOptionProduct");
                        });

            modelBuilder.Entity<Store>()
                .HasMany<PaymentOption>(s => s.StorePaymentOptions)
                .WithMany(c => c.Stores)
                .Map(cs =>
                {
                    cs.MapLeftKey("StoreId");
                    cs.MapRightKey("PaymentOptionId");
                    cs.ToTable("StorePaymentOption");
                });

            modelBuilder.Entity<Store>()
                .HasMany<ShippingOption>(s => s.StoreShippingOptions)
                .WithMany(c => c.Stores)
                .Map(cs =>
                {
                    cs.MapLeftKey("StoreId");
                    cs.MapRightKey("ShippingOptionId");
                    cs.ToTable("StoreShippingOption");
                });

            modelBuilder.Entity<Store>()
                .HasMany<ProductCategory>(s => s.StoreProductCategories)
                .WithMany(c => c.Stores)
                .Map(cs =>
                {
                    cs.MapLeftKey("StoreId");
                    cs.MapRightKey("ProductCategoryId");
                    cs.ToTable("StoreProductCategory");
                });

            modelBuilder.Entity<Store>()
                .HasMany<DiscountCoupon>(s => s.StoreDiscountCoupons)
                .WithMany(c => c.Stores)
                .Map(cs =>
                {
                    cs.MapLeftKey("StoreId");
                    cs.MapRightKey("DiscountCouponId");
                    cs.ToTable("StoreDiscountCoupon");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
