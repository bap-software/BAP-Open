using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using BAP.BL.AspNetIdentity;
using BAP.DAL.Entities;
using BAP.eCommerce.DAL.Entities;

namespace BAP.DB
{
    public class DB : IdentityDbContext<ApplicationUser>
    {
        public DB() : base("name=DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DB(string connectionString) : base(connectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

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
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<AttachmentAccess> AttachmentTokens { get; set; }
        public virtual DbSet<AttachmentHistory> AttachmentHistory { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<BlogAuthor> BlogAuthors { get; set; }
        public virtual DbSet<BlogComment> BlogComments { get; set; }
        public virtual DbSet<BlogCommentUser> BlogCommentUsers { get; set; }
        public virtual DbSet<BlogPost> BlogPosts { get; set; }
        public virtual DbSet<ContentControlParameter> ContentControlParameters { get; set; }
        public virtual DbSet<ContentLocalization> ContentLocalizations { get; set; }
        public virtual DbSet<DocumentTemplate> DocumentTemplates { get; set; }
        public virtual DbSet<CustomConfiguration> CustomConfigurations { get; set; }
        public virtual DbSet<ContentNode> ContentNodes { get; set; }
        public virtual DbSet<ContentNodeRoute> ContentNodeRoutes { get; set; }
        public virtual DbSet<ContentView> ContentViews { get; set; }
        public virtual DbSet<ContentViewControl> ContentViewControls { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<OrganizationModule> OrganizationModules { get; set; }
        public virtual DbSet<OrganizationService> OrganizationServices { get; set; }
        public virtual DbSet<OrganizationUser> OrganizationUsers { get; set; }
        public virtual DbSet<Lookup> Lookups { get; set; }
        public virtual DbSet<LookupValue> LookupValues { get; set; }
        public virtual DbSet<EventLog> EventLogs { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<NewsLetter> NewsLetters { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<Subscriber> Subscribers { get; set; }
        public virtual DbSet<WorkflowClass> WorkflowClasses { get; set; }
        public virtual DbSet<WorkflowAction> WorkflowActions { get; set; }
        public virtual DbSet<WorkflowActionAttribute> WorkflowActionAttributes { get; set; }
        public virtual DbSet<WorkflowStage> WorkflowStages { get; set; }
        public virtual DbSet<WorkflowStageTransition> WorkflowStageTransitions { get; set; }
        public virtual DbSet<WorkflowObject> WorkflowObjects { get; set; }

        //eCommerce
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }
        public virtual DbSet<CustomerOrderPayment> CustomerOrderPayments { get; set; }
        public virtual DbSet<CustomerPayment> CustomerPayments { get; set; }
        public virtual DbSet<DiscountCoupon> DiscountCoupons { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<PaymentOption> PaymentOptions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<RelatedProduct> RelatedProducts { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductOption> ProductOptions { get; set; }
        public virtual DbSet<ProductOptionItem> ProductOptionItems { get; set; }
        public virtual DbSet<ShippingCarrier> ShippingCarriers { get; set; }
        public virtual DbSet<ShippingOption> ShippingOptions { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<ContentControlType> ContentControlTypes { get; set; }
        public virtual DbSet<ContentControl> ContentControls { get; set; }

        public virtual DbSet<Store> Stores { get; set; }

        public virtual DbSet<ScheduledTask> ScheduledTasks { get; set; }
    }
}