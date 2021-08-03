// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 07-26-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-26-2020
// ***********************************************************************
// <copyright file="BapDb.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BAP.Common;
using BAP.DAL.Entities;

namespace BAP.DAL
{
    /// <summary>
    /// Class BapDb.
    /// Implements the <see cref="System.Data.Entity.DbContext" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public partial class BapDb : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BapDb"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public BapDb(IConfigHelper config)
            : base("name=" + config.BapDbConnName)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BapDb"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public BapDb(string connectionString)
            : base(connectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.</remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Types<IBapEntityWithState>().Configure(c => c.Ignore(p => p.EntityState));

            modelBuilder.Entity<Attachment>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Blog>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<BlogAuthor>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<BlogPost>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<BlogComment>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<BlogCommentUser>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<AttachmentHistory>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<AttachmentAccess>()
               .Property(e => e.TimeStamp)
               .IsFixedLength();

            modelBuilder.Entity<ContentNode>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<CustomConfiguration>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<DocumentTemplate>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Country>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<State>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Currency>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Organization>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<OrganizationModule>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<OrganizationService>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<OrganizationUser>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Localization>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Lookup>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<LookupValue>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Message>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Module>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<EventLog>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();
            
            modelBuilder.Entity<StagingEntity>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Subscription>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

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

            modelBuilder.Entity<ContentControlType>()
              .Property(e => e.TimeStamp)
              .IsFixedLength();

            modelBuilder.Entity<ContentControl>()
              .Property(e => e.TimeStamp)
              .IsFixedLength();

            modelBuilder.Entity<NewsLetter>()
              .Property(e => e.TimeStamp)
              .IsFixedLength();

            modelBuilder.Entity<ScheduledTask>()
              .Property(e => e.TimeStamp)
              .IsFixedLength();

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Fixes the state.
        /// </summary>
        public void FixState()
        {
            foreach (var entry in ChangeTracker.Entries<IBapEntityWithState>())
            {
                IBapEntityWithState stateInfo = entry.Entity;
                if (stateInfo.EntityState == BAPEntityState.Processed)
                    continue;
                entry.State = DataUtilities.ConvertState(stateInfo.EntityState);
                stateInfo.EntityState = BAPEntityState.Processed;
            }
        }

        /// <summary>
        /// Detaches all.
        /// </summary>
        public void DetachAll()
        {
            foreach (var entry in ChangeTracker.Entries<IBapEntityWithState>())
            {
                if (entry.State != EntityState.Detached)
                    entry.State = EntityState.Detached;

                entry.Entity.EntityState = BAPEntityState.Unchanged;
            }
        }

        /// <summary>
        /// Gets or sets the blogs.
        /// </summary>
        /// <value>The blogs.</value>
        public DbSet<Blog> Blogs { get; set; }
        /// <summary>
        /// Gets or sets the blog authors.
        /// </summary>
        /// <value>The blog authors.</value>
        public DbSet<BlogAuthor> BlogAuthors { get; set; }
        /// <summary>
        /// Gets or sets the blog posts.
        /// </summary>
        /// <value>The blog posts.</value>
        public DbSet<BlogPost> BlogPosts { get; set; }
        /// <summary>
        /// Gets or sets the blog comments.
        /// </summary>
        /// <value>The blog comments.</value>
        public DbSet<BlogComment> BlogComments { get; set; }
        /// <summary>
        /// Gets or sets the blog comment users.
        /// </summary>
        /// <value>The blog comment users.</value>
        public DbSet<BlogCommentUser> BlogCommentUsers { get; set; }

        /// <summary>
        /// Gets or sets the content nodes.
        /// </summary>
        /// <value>The content nodes.</value>
        public DbSet<ContentNode> ContentNodes { get; set; }
        /// <summary>
        /// Gets or sets the content views.
        /// </summary>
        /// <value>The content views.</value>
        public DbSet<ContentView> ContentViews { get; set; }
        /// <summary>
        /// Gets or sets the content view controls.
        /// </summary>
        /// <value>The content view controls.</value>
        public DbSet<ContentViewControl> ContentViewControls { get; set; }
        /// <summary>
        /// Gets or sets the content control parameters.
        /// </summary>
        /// <value>The content control parameters.</value>
        public DbSet<ContentControlParameter> ContentControlParameters { get; set; }
        /// <summary>
        /// Gets or sets the content node routes.
        /// </summary>
        /// <value>The content node routes.</value>
        public DbSet<ContentNodeRoute> ContentNodeRoutes { get; set; }
        /// <summary>
        /// Gets or sets the content localizations.
        /// </summary>
        /// <value>The content localizations.</value>
        public DbSet<ContentLocalization> ContentLocalizations { get; set; }

        /// <summary>
        /// Gets or sets the custom configurations.
        /// </summary>
        /// <value>The custom configurations.</value>
        public DbSet<CustomConfiguration> CustomConfigurations { get; set; }

        /// <summary>
        /// Gets or sets the document templates.
        /// </summary>
        /// <value>The document templates.</value>
        public DbSet<DocumentTemplate> DocumentTemplates { get; set; }

        /// <summary>
        /// Gets or sets the localizations.
        /// </summary>
        /// <value>The localizations.</value>
        public DbSet<Localization> Localizations { get; set; }

        /// <summary>
        /// Gets or sets the organization services.
        /// </summary>
        /// <value>The organization services.</value>
        public DbSet<OrganizationService> OrganizationServices { get; set; }

        /// <summary>
        /// Gets or sets the staging entities.
        /// </summary>
        /// <value>The staging entities.</value>
        public DbSet<StagingEntity> StagingEntities { get; set; }

        /// <summary>
        /// Gets or sets the workflow classes.
        /// </summary>
        /// <value>The workflow classes.</value>
        public DbSet<WorkflowClass> WorkflowClasses { get; set; }
        /// <summary>
        /// Gets or sets the workflow actions.
        /// </summary>
        /// <value>The workflow actions.</value>
        public DbSet<WorkflowAction> WorkflowActions { get; set; }
        /// <summary>
        /// Gets or sets the workflow action attributes.
        /// </summary>
        /// <value>The workflow action attributes.</value>
        public DbSet<WorkflowActionAttribute> WorkflowActionAttributes { get; set; }
        /// <summary>
        /// Gets or sets the workflow stages.
        /// </summary>
        /// <value>The workflow stages.</value>
        public DbSet<WorkflowStage> WorkflowStages { get; set; }
        /// <summary>
        /// Gets or sets the workflow stage transitions.
        /// </summary>
        /// <value>The workflow stage transitions.</value>
        public DbSet<WorkflowStageTransition> WorkflowStageTransitions { get; set; }
        /// <summary>
        /// Gets or sets the workflow objects.
        /// </summary>
        /// <value>The workflow objects.</value>
        public DbSet<WorkflowObject> WorkflowObjects { get; set; }

        /// <summary>
        /// Gets or sets the subscribers.
        /// </summary>
        /// <value>The subscribers.</value>
        public DbSet<Subscriber> Subscribers { get; set; }

        /// <summary>
        /// Gets or sets the scheduled tasks.
        /// </summary>
        /// <value>The scheduled tasks.</value>
        public DbSet<ScheduledTask> ScheduledTasks { get; set; }
    }
}