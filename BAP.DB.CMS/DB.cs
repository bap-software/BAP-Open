using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using BAP.BL.AspNetIdentity;
using BAP.DAL.Entities;

namespace BAP.CMSDB
{
    public class DB : IdentityDbContext<ApplicationUser>
    {
        public DB() : base("name=BAPCMSConnection" )
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DB(string connectionString) : base(connectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentNode>()
                  .HasMany<ContentView>(v => v.Views)
                  .WithMany(c => c.ContentNodes)
                  .Map(cs =>
                  {
                      cs.MapLeftKey("NodeId");
                      cs.MapRightKey("ViewId");
                      cs.ToTable("ContentNodeViews");
                  });
            
            
            //call base method
            base.OnModelCreating(modelBuilder);
        }

        //BAP base tables
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<AttachmentAccess> AttachmentTokens { get; set; }
        public virtual DbSet<AttachmentHistory> AttachmentHistory { get; set; }
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
        public virtual DbSet<Localization> Localizations { get; set; }
        public virtual DbSet<Lookup> Lookups { get; set; }
        public virtual DbSet<LookupValue> LookupValues { get; set; }
        public virtual DbSet<EventLog> EventLogs { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<NewsLetter> NewsLetters { get; set; }
        public virtual DbSet<Subscriber> Subscribers { get; set; }
        public virtual DbSet<ContentControlType> ContentControlTypes { get; set; }
        public virtual DbSet<ContentControl> ContentControls { get; set; }        
    }
}