// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 07-26-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-26-2020
// ***********************************************************************
// <copyright file="DB.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using BAP.BL.AspNetIdentity;
using BAP.DAL.Entities;
using BAP.eCommerce.DAL.Entities;

namespace BAP.DB.eCommerce
{
    /// <summary>
    /// Class DB.
    /// Implements the <see cref="Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext{BAP.BL.AspNetIdentity.ApplicationUser}" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext{BAP.BL.AspNetIdentity.ApplicationUser}" />
    public class DB : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DB"/> class.
        /// </summary>
        public DB() : base("name=DefaultConnection")
        {
            InitDb();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DB"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public DB(string connectionString) : base(connectionString)
        {
            InitDb();
        }

        /// <summary>
        /// Maps table names, and sets up relationships between the various user entities
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkflowStageTransition>()
                  .HasMany<WorkflowAction>(s => s.Actions)
                  .WithMany(c => c.Transitions)
                  .Map(cs =>
                  {
                      cs.MapLeftKey("TransitionId");
                      cs.MapRightKey("ActionId");
                      cs.ToTable("WorkflowTranstionActions");
                  });

            modelBuilder.Entity<ContentNode>()
                  .HasMany<ContentView>(v => v.Views)
                  .WithMany(c => c.ContentNodes)
                  .Map(cs =>
                  {
                      cs.MapLeftKey("NodeId");
                      cs.MapRightKey("ViewId");
                      cs.ToTable("ContentNodeViews");
                  });
            
            //eCommerce
            modelBuilder.Entity<RelatedProduct>()
              .HasKey(rp => new { rp.ProductId, rp.SimilarProductId });

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

            modelBuilder.Entity<CustomerOrder>()
              .HasRequired(c => c.BillingAddress)
              .WithMany()
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerOrder>()
              .HasRequired(c => c.ShippingAddress)
              .WithMany()
              .WillCascadeOnDelete(false);
            
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

            modelBuilder.Entity<ScheduledTask>();

            //call base method
            base.OnModelCreating(modelBuilder);
        }

        //BAP base tables
        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        /// <value>The attachments.</value>
        public virtual DbSet<Attachment> Attachments { get; set; }
        /// <summary>
        /// Gets or sets the attachment tokens.
        /// </summary>
        /// <value>The attachment tokens.</value>
        public virtual DbSet<AttachmentAccess> AttachmentTokens { get; set; }
        /// <summary>
        /// Gets or sets the attachment history.
        /// </summary>
        /// <value>The attachment history.</value>
        public virtual DbSet<AttachmentHistory> AttachmentHistory { get; set; }
        /// <summary>
        /// Gets or sets the blogs.
        /// </summary>
        /// <value>The blogs.</value>
        public virtual DbSet<Blog> Blogs { get; set; }
        /// <summary>
        /// Gets or sets the blog authors.
        /// </summary>
        /// <value>The blog authors.</value>
        public virtual DbSet<BlogAuthor> BlogAuthors { get; set; }
        /// <summary>
        /// Gets or sets the blog comments.
        /// </summary>
        /// <value>The blog comments.</value>
        public virtual DbSet<BlogComment> BlogComments { get; set; }
        /// <summary>
        /// Gets or sets the blog comment users.
        /// </summary>
        /// <value>The blog comment users.</value>
        public virtual DbSet<BlogCommentUser> BlogCommentUsers { get; set; }
        /// <summary>
        /// Gets or sets the blog posts.
        /// </summary>
        /// <value>The blog posts.</value>
        public virtual DbSet<BlogPost> BlogPosts { get; set; }
        /// <summary>
        /// Gets or sets the content control parameters.
        /// </summary>
        /// <value>The content control parameters.</value>
        public virtual DbSet<ContentControlParameter> ContentControlParameters { get; set; }
        /// <summary>
        /// Gets or sets the content localizations.
        /// </summary>
        /// <value>The content localizations.</value>
        public virtual DbSet<ContentLocalization> ContentLocalizations { get; set; }
        /// <summary>
        /// Gets or sets the document templates.
        /// </summary>
        /// <value>The document templates.</value>
        public virtual DbSet<DocumentTemplate> DocumentTemplates { get; set; }
        /// <summary>
        /// Gets or sets the custom configurations.
        /// </summary>
        /// <value>The custom configurations.</value>
        public virtual DbSet<CustomConfiguration> CustomConfigurations { get; set; }
        /// <summary>
        /// Gets or sets the content nodes.
        /// </summary>
        /// <value>The content nodes.</value>
        public virtual DbSet<ContentNode> ContentNodes { get; set; }
        /// <summary>
        /// Gets or sets the content node routes.
        /// </summary>
        /// <value>The content node routes.</value>
        public virtual DbSet<ContentNodeRoute> ContentNodeRoutes { get; set; }
        /// <summary>
        /// Gets or sets the content views.
        /// </summary>
        /// <value>The content views.</value>
        public virtual DbSet<ContentView> ContentViews { get; set; }
        /// <summary>
        /// Gets or sets the content view controls.
        /// </summary>
        /// <value>The content view controls.</value>
        public virtual DbSet<ContentViewControl> ContentViewControls { get; set; }
        /// <summary>
        /// Gets or sets the countries.
        /// </summary>
        /// <value>The countries.</value>
        public virtual DbSet<Country> Countries { get; set; }
        /// <summary>
        /// Gets or sets the states.
        /// </summary>
        /// <value>The states.</value>
        public virtual DbSet<State> States { get; set; }
        /// <summary>
        /// Gets or sets the currencies.
        /// </summary>
        /// <value>The currencies.</value>
        public virtual DbSet<Currency> Currencies { get; set; }
        /// <summary>
        /// Gets or sets the organizations.
        /// </summary>
        /// <value>The organizations.</value>
        public virtual DbSet<Organization> Organizations { get; set; }
        /// <summary>
        /// Gets or sets the organization modules.
        /// </summary>
        /// <value>The organization modules.</value>
        public virtual DbSet<OrganizationModule> OrganizationModules { get; set; }
        /// <summary>
        /// Gets or sets the organization services.
        /// </summary>
        /// <value>The organization services.</value>
        public virtual DbSet<OrganizationService> OrganizationServices { get; set; }
        /// <summary>
        /// Gets or sets the organization users.
        /// </summary>
        /// <value>The organization users.</value>
        public virtual DbSet<OrganizationUser> OrganizationUsers { get; set; }
        /// <summary>
        /// Gets or sets the localizations.
        /// </summary>
        /// <value>The localizations.</value>
        public virtual DbSet<Localization> Localizations { get; set; }
        /// <summary>
        /// Gets or sets the lookups.
        /// </summary>
        /// <value>The lookups.</value>
        public virtual DbSet<Lookup> Lookups { get; set; }
        /// <summary>
        /// Gets or sets the lookup values.
        /// </summary>
        /// <value>The lookup values.</value>
        public virtual DbSet<LookupValue> LookupValues { get; set; }
        /// <summary>
        /// Gets or sets the event logs.
        /// </summary>
        /// <value>The event logs.</value>
        public virtual DbSet<EventLog> EventLogs { get; set; }
        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        /// <value>The messages.</value>
        public virtual DbSet<Message> Messages { get; set; }
        /// <summary>
        /// Gets or sets the modules.
        /// </summary>
        /// <value>The modules.</value>
        public virtual DbSet<Module> Modules { get; set; }
        /// <summary>
        /// Gets or sets the news letters.
        /// </summary>
        /// <value>The news letters.</value>
        public virtual DbSet<NewsLetter> NewsLetters { get; set; }
        /// <summary>
        /// Gets or sets the staging entities.
        /// </summary>
        /// <value>The staging entities.</value>
        public virtual DbSet<StagingEntity> StagingEntities { get; set; }
        /// <summary>
        /// Gets or sets the subscriptions.
        /// </summary>
        /// <value>The subscriptions.</value>
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        /// <summary>
        /// Gets or sets the subscribers.
        /// </summary>
        /// <value>The subscribers.</value>
        public virtual DbSet<Subscriber> Subscribers { get; set; }
        /// <summary>
        /// Gets or sets the workflow classes.
        /// </summary>
        /// <value>The workflow classes.</value>
        public virtual DbSet<WorkflowClass> WorkflowClasses { get; set; }
        /// <summary>
        /// Gets or sets the workflow actions.
        /// </summary>
        /// <value>The workflow actions.</value>
        public virtual DbSet<WorkflowAction> WorkflowActions { get; set; }
        /// <summary>
        /// Gets or sets the workflow action attributes.
        /// </summary>
        /// <value>The workflow action attributes.</value>
        public virtual DbSet<WorkflowActionAttribute> WorkflowActionAttributes { get; set; }
        /// <summary>
        /// Gets or sets the workflow stages.
        /// </summary>
        /// <value>The workflow stages.</value>
        public virtual DbSet<WorkflowStage> WorkflowStages { get; set; }
        /// <summary>
        /// Gets or sets the workflow stage transitions.
        /// </summary>
        /// <value>The workflow stage transitions.</value>
        public virtual DbSet<WorkflowStageTransition> WorkflowStageTransitions { get; set; }
        /// <summary>
        /// Gets or sets the workflow objects.
        /// </summary>
        /// <value>The workflow objects.</value>
        public virtual DbSet<WorkflowObject> WorkflowObjects { get; set; }

        //eCommerce
        /// <summary>
        /// Gets or sets the addresses.
        /// </summary>
        /// <value>The addresses.</value>
        public virtual DbSet<Address> Addresses { get; set; }
        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        /// <value>The customers.</value>
        public virtual DbSet<Customer> Customers { get; set; }
        /// <summary>
        /// Gets or sets the customer orders.
        /// </summary>
        /// <value>The customer orders.</value>
        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }
        /// <summary>
        /// Gets or sets the customer order payments.
        /// </summary>
        /// <value>The customer order payments.</value>
        public virtual DbSet<CustomerOrderPayment> CustomerOrderPayments { get; set; }
        /// <summary>
        /// Gets or sets the customer payments.
        /// </summary>
        /// <value>The customer payments.</value>
        public virtual DbSet<CustomerPayment> CustomerPayments { get; set; }
        /// <summary>
        /// Gets or sets the discount coupons.
        /// </summary>
        /// <value>The discount coupons.</value>
        public virtual DbSet<DiscountCoupon> DiscountCoupons { get; set; }
        /// <summary>
        /// Gets or sets the manufacturers.
        /// </summary>
        /// <value>The manufacturers.</value>
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        /// <summary>
        /// Gets or sets the order items.
        /// </summary>
        /// <value>The order items.</value>
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        /// <summary>
        /// Gets or sets the payment options.
        /// </summary>
        /// <value>The payment options.</value>
        public virtual DbSet<PaymentOption> PaymentOptions { get; set; }
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>The products.</value>
        public virtual DbSet<Product> Products { get; set; }
        /// <summary>
        /// Gets or sets the ProductSupplierData.
        /// </summary>
        /// <value>The ProductSupplierData.</value>
        public virtual DbSet<ProductSupplierData> ProductSupplierDatas { get; set; }
        /// <summary>
        /// Gets or sets the related products.
        /// </summary>
        /// <value>The related products.</value>
        public virtual DbSet<RelatedProduct> RelatedProducts { get; set; }
        /// <summary>
        /// Gets or sets the product categories.
        /// </summary>
        /// <value>The product categories.</value>
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        /// <summary>
        /// Gets or sets the product options.
        /// </summary>
        /// <value>The product options.</value>
        public virtual DbSet<ProductOption> ProductOptions { get; set; }
        /// <summary>
        /// Gets or sets the product option items.
        /// </summary>
        /// <value>The product option items.</value>
        public virtual DbSet<ProductOptionItem> ProductOptionItems { get; set; }
        /// <summary>
        /// Gets or sets the shipping carriers.
        /// </summary>
        /// <value>The shipping carriers.</value>
        public virtual DbSet<ShippingCarrier> ShippingCarriers { get; set; }
        /// <summary>
        /// Gets or sets the shipping options.
        /// </summary>
        /// <value>The shipping options.</value>
        public virtual DbSet<ShippingOption> ShippingOptions { get; set; }
        /// <summary>
        /// Gets or sets the shopping carts.
        /// </summary>
        /// <value>The shopping carts.</value>
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        /// <summary>
        /// Gets or sets the shopping cart products.
        /// </summary>
        /// <value>The shopping cart products.</value>
        public virtual DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }
        /// <summary>
        /// Gets or sets the suppliers.
        /// </summary>
        /// <value>The suppliers.</value>
        public virtual DbSet<Supplier> Suppliers { get; set; }
        /// <summary>
        /// Gets or sets the content control types.
        /// </summary>
        /// <value>The content control types.</value>
        public virtual DbSet<ContentControlType> ContentControlTypes { get; set; }
        /// <summary>
        /// Gets or sets the content controls.
        /// </summary>
        /// <value>The content controls.</value>
        public virtual DbSet<ContentControl> ContentControls { get; set; }

        /// <summary>
        /// Gets or sets the stores.
        /// </summary>
        /// <value>The stores.</value>
        public virtual DbSet<Store> Stores { get; set; }

        /// <summary>
        /// Gets or sets the scheduled tasks.
        /// </summary>
        /// <value>The scheduled tasks.</value>
        public virtual DbSet<ScheduledTask> ScheduledTasks { get; set; }
        

        private void InitDb()
        {
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<DB>(null);
        }
    }
}