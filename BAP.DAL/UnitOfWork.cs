// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 07-26-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-26-2020
// ***********************************************************************
// <copyright file="UnitOfWork.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.Common;
using BAP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BAP.DAL
{
    /// <summary>
    /// Interface IUnitOfWork
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Fixes the entity states.
        /// </summary>
        void FixEntityStates();
        /// <summary>
        /// Detaches all.
        /// </summary>
        void DetachAll();
        /// <summary>
        /// Gets the entity states.
        /// </summary>
        /// <returns>Dictionary&lt;System.String, System.String&gt;.</returns>
        Dictionary<string, string> GetEntityStates();

        /// <summary>
        /// Gets the message repository.
        /// </summary>
        /// <value>The message repository.</value>
        MessageRepository MessageRepository { get; }
        /// <summary>
        /// Gets the module repository.
        /// </summary>
        /// <value>The module repository.</value>
        ModuleRepository ModuleRepository { get; }

        /// <summary>
        /// Gets the attachment repository.
        /// </summary>
        /// <value>The attachment repository.</value>
        AttachmentRepository AttachmentRepository { get; }
        /// <summary>
        /// Gets the attachment hist repository.
        /// </summary>
        /// <value>The attachment hist repository.</value>
        AttachmentHistRepository AttachmentHistRepository { get; }
        /// <summary>
        /// Gets the attachment access repository.
        /// </summary>
        /// <value>The attachment access repository.</value>
        AttachmentAccessRepository AttachmentAccessRepository { get; }

        /// <summary>
        /// Gets the blog repository.
        /// </summary>
        /// <value>The blog repository.</value>
        BlogRepository BlogRepository { get; }
        /// <summary>
        /// Gets the blog author repository.
        /// </summary>
        /// <value>The blog author repository.</value>
        BlogAuthorRepository BlogAuthorRepository { get; }
        /// <summary>
        /// Gets the blog post repository.
        /// </summary>
        /// <value>The blog post repository.</value>
        BlogPostRepository BlogPostRepository { get; }
        /// <summary>
        /// Gets the blog comment repository.
        /// </summary>
        /// <value>The blog comment repository.</value>
        BlogCommentRepository BlogCommentRepository { get; }
        /// <summary>
        /// Gets the blog comment user repository.
        /// </summary>
        /// <value>The blog comment user repository.</value>
        BlogCommentUserRepository BlogCommentUserRepository { get; }

        /// <summary>
        /// Gets the content node repository.
        /// </summary>
        /// <value>The content node repository.</value>
        ContentNodeRepository ContentNodeRepository { get; }
        /// <summary>
        /// Gets the content view repository.
        /// </summary>
        /// <value>The content view repository.</value>
        ContentViewRepository ContentViewRepository { get; }
        /// <summary>
        /// Gets the content view control repository.
        /// </summary>
        /// <value>The content view control repository.</value>
        ContentViewControlRepository ContentViewControlRepository { get; }
        /// <summary>
        /// Gets the content control parameter repository.
        /// </summary>
        /// <value>The content control parameter repository.</value>
        ContentControlParameterRepository ContentControlParameterRepository { get; }
        /// <summary>
        /// Gets the content node route repository.
        /// </summary>
        /// <value>The content node route repository.</value>
        ContentNodeRouteRepository ContentNodeRouteRepository { get; }
        /// <summary>
        /// Gets the content localization repository.
        /// </summary>
        /// <value>The content localization repository.</value>
        ContentLocalizationRepository ContentLocalizationRepository { get; }

        /// <summary>
        /// Gets the country repository.
        /// </summary>
        /// <value>The country repository.</value>
        CountryRepository CountryRepository { get; }
        /// <summary>
        /// Gets the state repository.
        /// </summary>
        /// <value>The state repository.</value>
        StateRepository StateRepository { get; }
        /// <summary>
        /// Gets the currency repository.
        /// </summary>
        /// <value>The currency repository.</value>
        CurrencyRepository CurrencyRepository { get; }
        /// <summary>
        /// Gets the custom configuration repository.
        /// </summary>
        /// <value>The custom configuration repository.</value>
        CustomConfigurationRepository CustomConfigurationRepository { get; }
        /// <summary>
        /// Gets the document template repository.
        /// </summary>
        /// <value>The document template repository.</value>
        DocumentTemplateRepository DocumentTemplateRepository { get; }
        /// <summary>
        /// Gets the event log repository.
        /// </summary>
        /// <value>The event log repository.</value>
        EventLogRepository EventLogRepository { get; }
        /// <summary>
        /// Gets the localization repository.
        /// </summary>
        /// <value>The localization repository.</value>
        LocalizationRepository LocalizationRepository { get; }
        /// <summary>
        /// Gets the lookup repository.
        /// </summary>
        /// <value>The lookup repository.</value>
        LookupRepository LookupRepository { get; }
        /// <summary>
        /// Gets the lookup value repository.
        /// </summary>
        /// <value>The lookup value repository.</value>
        LookupValueRepository LookupValueRepository { get; }
        /// <summary>
        /// Gets the news letter repository.
        /// </summary>
        /// <value>The news letter repository.</value>
        NewsLetterRepository NewsLetterRepository { get; }
        /// <summary>
        /// Gets the organization repository.
        /// </summary>
        /// <value>The organization repository.</value>
        OrganizationRepository OrganizationRepository { get; }
        /// <summary>
        /// Gets the organization service repository.
        /// </summary>
        /// <value>The organization service repository.</value>
        OrganizationServiceRepository OrganizationServiceRepository { get; }
        /// <summary>
        /// Gets the organization user repository.
        /// </summary>
        /// <value>The organization user repository.</value>
        OrganizationUserRepository OrganizationUserRepository { get; }
        /// <summary>
        /// Gets the organization module repository.
        /// </summary>
        /// <value>The organization module repository.</value>
        OrganizationModuleRepository OrganizationModuleRepository { get; }
        /// <summary>
        /// Gets the scheduled task repository.
        /// </summary>
        /// <value>The scheduled task repository.</value>
        ScheduledTaskRepository ScheduledTaskRepository { get; }
        /// <summary>
        /// Gets the staging entity repository.
        /// </summary>
        /// <value>The staging entity repository.</value>
        StagingEntityRepository StagingEntityRepository { get; }
        /// <summary>
        /// Gets the subscriber repository.
        /// </summary>
        /// <value>The subscriber repository.</value>
        SubscriberRepository SubscriberRepository { get; }
        /// <summary>
        /// Gets the subscription repository.
        /// </summary>
        /// <value>The subscription repository.</value>
        SubscriptionRepository SubscriptionRepository { get; }

        /// <summary>
        /// Gets the workflow class repository.
        /// </summary>
        /// <value>The workflow class repository.</value>
        WorkflowClassRepository WorkflowClassRepository { get; }
        /// <summary>
        /// Gets the workflow action repository.
        /// </summary>
        /// <value>The workflow action repository.</value>
        WorkflowActionRepository WorkflowActionRepository { get; }
        /// <summary>
        /// Gets the workflow action attribute repository.
        /// </summary>
        /// <value>The workflow action attribute repository.</value>
        WorkflowActionAttributeRepository WorkflowActionAttributeRepository { get; }
        /// <summary>
        /// Gets the workflow stage repository.
        /// </summary>
        /// <value>The workflow stage repository.</value>
        WorkflowStageRepository WorkflowStageRepository { get; }
        /// <summary>
        /// Gets the workflow stage transition repository.
        /// </summary>
        /// <value>The workflow stage transition repository.</value>
        WorkflowStageTransitionRepository WorkflowStageTransitionRepository { get; }
        /// <summary>
        /// Gets the workflow object repository.
        /// </summary>
        /// <value>The workflow object repository.</value>
        WorkflowObjectRepository WorkflowObjectRepository { get; }

        /// <summary>
        /// Gets the content control type repository.
        /// </summary>
        /// <value>The content control type repository.</value>
        ContentControlTypeRepository ContentControlTypeRepository { get; }

        /// <summary>
        /// Gets the content control repository.
        /// </summary>
        /// <value>The content control repository.</value>
        ContentControlRepository ContentControlRepository { get; }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();
        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <returns>Task.</returns>
        Task SaveAsync();
    }

    /// <summary>
    /// Class UnitOfWork.
    /// Implements the <see cref="BAP.DAL.IUnitOfWork" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="BAP.DAL.IUnitOfWork" />
    /// <seealso cref="System.IDisposable" />
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        /// <summary>
        /// The database
        /// </summary>
        protected DbContext _db;

        /// <summary>
        /// The message repository
        /// </summary>
        private MessageRepository _messageRepository;
        /// <summary>
        /// The module repository
        /// </summary>
        private ModuleRepository _moduleRepository;

        /// <summary>
        /// The attachment repository
        /// </summary>
        private AttachmentRepository _attachmentRepository;
        /// <summary>
        /// The attachment hist repository
        /// </summary>
        private AttachmentHistRepository _attachmentHistRepository;
        /// <summary>
        /// The attachment access repository
        /// </summary>
        private AttachmentAccessRepository _attachmentAccessRepository;

        /// <summary>
        /// The blog repository
        /// </summary>
        private BlogRepository _blogRepository;
        /// <summary>
        /// The blog author repository
        /// </summary>
        private BlogAuthorRepository _blogAuthorRepository;
        /// <summary>
        /// The blog post repository
        /// </summary>
        private BlogPostRepository _blogPostRepository;
        /// <summary>
        /// The blog comment repository
        /// </summary>
        private BlogCommentRepository _blogCommentRepository;
        /// <summary>
        /// The blog comment user repository
        /// </summary>
        private BlogCommentUserRepository _blogCommentUserRepository;

        /// <summary>
        /// The content node repository
        /// </summary>
        private ContentNodeRepository _contentNodeRepository;
        /// <summary>
        /// The content view repository
        /// </summary>
        private ContentViewRepository _contentViewRepository;
        /// <summary>
        /// The content view control repository
        /// </summary>
        private ContentViewControlRepository _contentViewControlRepository;
        /// <summary>
        /// The content control parameter repository
        /// </summary>
        private ContentControlParameterRepository _contentControlParameterRepository;
        /// <summary>
        /// The content node route repository
        /// </summary>
        private ContentNodeRouteRepository _contentNodeRouteRepository;
        /// <summary>
        /// The content localization repository
        /// </summary>
        private ContentLocalizationRepository _contentLocalizationRepository;

        /// <summary>
        /// The country repository
        /// </summary>
        private CountryRepository _countryRepository;
        /// <summary>
        /// The currency repository
        /// </summary>
        private CurrencyRepository _currencyRepository;
        /// <summary>
        /// The custom configuration repository
        /// </summary>
        private CustomConfigurationRepository _customConfigurationRepository;
        /// <summary>
        /// The state repository
        /// </summary>
        private StateRepository _stateRepository;
        /// <summary>
        /// The document template repository
        /// </summary>
        private DocumentTemplateRepository _documentTemplateRepository;
        /// <summary>
        /// The event log repository
        /// </summary>
        private EventLogRepository _eventLogRepository;
        /// <summary>
        /// The localization repository
        /// </summary>
        private LocalizationRepository _localizationRepository;
        /// <summary>
        /// The lookup repository
        /// </summary>
        private LookupRepository _lookupRepository;
        /// <summary>
        /// The lookup value repository
        /// </summary>
        private LookupValueRepository _lookupValueRepository;
        /// <summary>
        /// The news letter repository
        /// </summary>
        private NewsLetterRepository _newsLetterRepository;
        /// <summary>
        /// The organization repository
        /// </summary>
        private OrganizationRepository _organizationRepository;
        /// <summary>
        /// The organization module repository
        /// </summary>
        private OrganizationModuleRepository _organizationModuleRepository;
        /// <summary>
        /// The organization service repository
        /// </summary>
        private OrganizationServiceRepository _organizationServiceRepository;
        /// <summary>
        /// The organization user repository
        /// </summary>
        private OrganizationUserRepository _organizationUserRepository;
        /// <summary>
        /// The scheduled task repository
        /// </summary>
        private ScheduledTaskRepository _scheduledTaskRepository;
        /// <summary>
        /// The staging entity repository
        /// </summary>
        private StagingEntityRepository _stagingEntityRepository;
        /// <summary>
        /// The subscriber repository
        /// </summary>
        private SubscriberRepository _subscriberRepository;
        /// <summary>
        /// The subscription repository
        /// </summary>
        private SubscriptionRepository _subscriptionRepository;

        /// <summary>
        /// The workflow class repository
        /// </summary>
        private WorkflowClassRepository _workflowClassRepository;
        /// <summary>
        /// The workflow action repository
        /// </summary>
        private WorkflowActionRepository _workflowActionRepository;
        /// <summary>
        /// The workflow action attribute repository
        /// </summary>
        private WorkflowActionAttributeRepository _workflowActionAttributeRepository;
        /// <summary>
        /// The workflow stage repository
        /// </summary>
        private WorkflowStageRepository _workflowStageRepository;
        /// <summary>
        /// The workflow stage transition repository
        /// </summary>
        private WorkflowStageTransitionRepository _workflowStageTransitionRepository;
        /// <summary>
        /// The workflow object repository
        /// </summary>
        private WorkflowObjectRepository _workflowObjectRepository;
        /// <summary>
        /// The content control type repository
        /// </summary>
        private ContentControlTypeRepository _contentControlTypeRepository;
        /// <summary>
        /// The content control repository
        /// </summary>
        private ContentControlRepository _contentControlRepository;

        /// <summary>
        /// The settings
        /// </summary>
        protected IConfigHelper _settings;
        /// <summary>
        /// The authentication context
        /// </summary>
        protected IAuthorizationContext _authContext;

        /// <summary>
        /// Prevents a default instance of the <see cref="UnitOfWork"/> class from being created.
        /// </summary>
        private UnitOfWork()
        {
            _settings = null;
            _authContext = null;
            _db = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="context">The context.</param>
        public UnitOfWork(DbContext db, IAuthorizationContext context)
        {
            _settings = null;
            _db = db;
            _authContext = context;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        public UnitOfWork(IConfigHelper settings, IAuthorizationContext context)
        {
            _settings = settings;
            _db = new BapDb(settings);
            _authContext = context;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="db">The database.</param>
        /// <param name="context">The context.</param>
        public UnitOfWork(IConfigHelper settings, DbContext db, IAuthorizationContext context)
        {
            _settings = settings;
            _db = db;
            _authContext = context;
        }

        /// <summary>
        /// Fixes the entity states.
        /// </summary>
        public virtual void FixEntityStates()
        {
            ((BapDb)_db).FixState();
        }

        /// <summary>
        /// Detaches all.
        /// </summary>
        public virtual void DetachAll()
        {
            ((BapDb)_db).DetachAll();
        }

        /// <summary>
        /// Gets the entity states.
        /// </summary>
        /// <returns>Dictionary&lt;System.String, System.String&gt;.</returns>
        public Dictionary<string, string> GetEntityStates()
        {
            var result = new Dictionary<string, string>();
            var entries = _db.ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                result.Add(entry.Entity.GetType().Name + " " + Guid.NewGuid().ToString(), entry.State.ToString());
            }
            return result;
        }

        /// <summary>
        /// Gets the message repository.
        /// </summary>
        /// <value>The message repository.</value>
        public MessageRepository MessageRepository
        {
            get
            {
                if (this._messageRepository == null)
                {
                    this._messageRepository = new MessageRepository(_db, new AuthorizationHelper<Message>(_settings, _authContext), _settings);
                }
                return _messageRepository;
            }
        }

        /// <summary>
        /// Gets the module repository.
        /// </summary>
        /// <value>The module repository.</value>
        public ModuleRepository ModuleRepository
        {
            get
            {
                if (this._moduleRepository == null)
                {
                    this._moduleRepository = new ModuleRepository(_db, new AuthorizationHelper<Module>(_settings, _authContext), _settings);
                }
                return _moduleRepository;
            }
        }

        /// <summary>
        /// Gets the attachment repository.
        /// </summary>
        /// <value>The attachment repository.</value>
        public AttachmentRepository AttachmentRepository
        {
            get
            {
                if (this._attachmentRepository == null)
                {
                    this._attachmentRepository = new AttachmentRepository(_db, new AuthorizationHelper<Attachment>(_settings, _authContext), _settings);
                }
                return _attachmentRepository;
            }
        }

        /// <summary>
        /// Gets the attachment access repository.
        /// </summary>
        /// <value>The attachment access repository.</value>
        public AttachmentAccessRepository AttachmentAccessRepository
        {
            get
            {
                if (this._attachmentAccessRepository == null)
                {
                    this._attachmentAccessRepository = new AttachmentAccessRepository(_db, new AuthorizationHelper<AttachmentAccess>(_settings, _authContext), _settings);
                }
                return _attachmentAccessRepository;
            }
        }

        /// <summary>
        /// Gets the attachment hist repository.
        /// </summary>
        /// <value>The attachment hist repository.</value>
        public AttachmentHistRepository AttachmentHistRepository
        {
            get
            {
                if (this._attachmentHistRepository == null)
                {
                    this._attachmentHistRepository = new AttachmentHistRepository(_db, new AuthorizationHelper<AttachmentHistory>(_settings, _authContext), _settings);
                }
                return _attachmentHistRepository;
            }
        }

        /// <summary>
        /// Gets the blog repository.
        /// </summary>
        /// <value>The blog repository.</value>
        public BlogRepository BlogRepository
        {
            get
            {
                if (this._blogRepository == null)
                {
                    this._blogRepository = new BlogRepository(_db, new AuthorizationHelper<Blog>(_settings, _authContext), _settings);
                }
                return _blogRepository;
            }
        }

        /// <summary>
        /// Gets the blog author repository.
        /// </summary>
        /// <value>The blog author repository.</value>
        public BlogAuthorRepository BlogAuthorRepository
        {
            get
            {
                if (this._blogAuthorRepository == null)
                {
                    this._blogAuthorRepository = new BlogAuthorRepository(_db, new AuthorizationHelper<BlogAuthor>(_settings, _authContext), _settings);
                }
                return _blogAuthorRepository;
            }
        }

        /// <summary>
        /// Gets the blog post repository.
        /// </summary>
        /// <value>The blog post repository.</value>
        public BlogPostRepository BlogPostRepository
        {
            get
            {
                if (this._blogPostRepository == null)
                {
                    this._blogPostRepository = new BlogPostRepository(_db, new AuthorizationHelper<BlogPost>(_settings, _authContext), _settings);
                }
                return _blogPostRepository;
            }
        }

        /// <summary>
        /// Gets the blog comment repository.
        /// </summary>
        /// <value>The blog comment repository.</value>
        public BlogCommentRepository BlogCommentRepository
        {
            get
            {
                if (this._blogCommentRepository == null)
                {
                    this._blogCommentRepository = new BlogCommentRepository(_db, new AuthorizationHelper<BlogComment>(_settings, _authContext), _settings);
                }
                return _blogCommentRepository;
            }
        }

        /// <summary>
        /// Gets the blog comment user repository.
        /// </summary>
        /// <value>The blog comment user repository.</value>
        public BlogCommentUserRepository BlogCommentUserRepository
        {
            get
            {
                if (this._blogCommentUserRepository == null)
                {
                    this._blogCommentUserRepository = new BlogCommentUserRepository(_db, new AuthorizationHelper<BlogCommentUser>(_settings, _authContext), _settings);
                }
                return _blogCommentUserRepository;
            }
        }

        /// <summary>
        /// Gets the content node repository.
        /// </summary>
        /// <value>The content node repository.</value>
        public ContentNodeRepository ContentNodeRepository
        {
            get
            {
                if (this._contentNodeRepository == null)
                {
                    this._contentNodeRepository = new ContentNodeRepository(_db, new AuthorizationHelper<ContentNode>(_settings, _authContext), _settings);
                }
                return _contentNodeRepository;
            }
        }

        /// <summary>
        /// Gets the content view repository.
        /// </summary>
        /// <value>The content view repository.</value>
        public ContentViewRepository ContentViewRepository
        {
            get
            {
                if (this._contentViewRepository == null)
                {
                    this._contentViewRepository = new ContentViewRepository(_db, new AuthorizationHelper<ContentView>(_settings, _authContext), _settings);
                }
                return _contentViewRepository;
            }
        }

        /// <summary>
        /// Gets the content view control repository.
        /// </summary>
        /// <value>The content view control repository.</value>
        public ContentViewControlRepository ContentViewControlRepository
        {
            get
            {
                if (this._contentViewControlRepository == null)
                {
                    this._contentViewControlRepository = new ContentViewControlRepository(_db, new AuthorizationHelper<ContentViewControl>(_settings, _authContext), _settings);
                }
                return _contentViewControlRepository;
            }
        }

        /// <summary>
        /// Gets the content control parameter repository.
        /// </summary>
        /// <value>The content control parameter repository.</value>
        public ContentControlParameterRepository ContentControlParameterRepository
        {
            get
            {
                if (this._contentControlParameterRepository == null)
                {
                    this._contentControlParameterRepository = new ContentControlParameterRepository(_db, new AuthorizationHelper<ContentControlParameter>(_settings, _authContext), _settings);
                }
                return _contentControlParameterRepository;
            }
        }

        /// <summary>
        /// Gets the content node route repository.
        /// </summary>
        /// <value>The content node route repository.</value>
        public ContentNodeRouteRepository ContentNodeRouteRepository
        {
            get
            {
                if (this._contentNodeRouteRepository == null)
                {
                    this._contentNodeRouteRepository = new ContentNodeRouteRepository(_db, new AuthorizationHelper<ContentNodeRoute>(_settings, _authContext), _settings);
                }
                return _contentNodeRouteRepository;
            }
        }

        /// <summary>
        /// Gets the content localization repository.
        /// </summary>
        /// <value>The content localization repository.</value>
        public ContentLocalizationRepository ContentLocalizationRepository
        {
            get
            {
                if (this._contentLocalizationRepository == null)
                {
                    this._contentLocalizationRepository = new ContentLocalizationRepository(_db, new AuthorizationHelper<ContentLocalization>(_settings, _authContext), _settings);
                }
                return _contentLocalizationRepository;
            }
        }

        /// <summary>
        /// Gets the country repository.
        /// </summary>
        /// <value>The country repository.</value>
        public CountryRepository CountryRepository
        {
            get
            {
                if (this._countryRepository == null)
                {
                    this._countryRepository = new CountryRepository(_db, new AuthorizationHelper<Country>(_settings, _authContext), _settings);
                }
                return _countryRepository;
            }
        }

        /// <summary>
        /// Gets the state repository.
        /// </summary>
        /// <value>The state repository.</value>
        public StateRepository StateRepository
        {
            get
            {
                if (this._stateRepository == null)
                {
                    this._stateRepository = new StateRepository(_db, new AuthorizationHelper<State>(_settings, _authContext), _settings);
                }
                return _stateRepository;
            }
        }


        /// <summary>
        /// Gets the currency repository.
        /// </summary>
        /// <value>The currency repository.</value>
        public CurrencyRepository CurrencyRepository
        {
            get
            {
                if (this._currencyRepository == null)
                {
                    this._currencyRepository = new CurrencyRepository(_db, new AuthorizationHelper<Currency>(_settings, _authContext), _settings);
                }
                return _currencyRepository;
            }
        }

        /// <summary>
        /// Gets the custom configuration repository.
        /// </summary>
        /// <value>The custom configuration repository.</value>
        public CustomConfigurationRepository CustomConfigurationRepository
        {
            get
            {
                if (this._customConfigurationRepository == null)
                {
                    this._customConfigurationRepository = new CustomConfigurationRepository(_db, new AuthorizationHelper<CustomConfiguration>(_settings, _authContext), _settings);
                }
                return _customConfigurationRepository;
            }
        }

        /// <summary>
        /// Gets the document template repository.
        /// </summary>
        /// <value>The document template repository.</value>
        public DocumentTemplateRepository DocumentTemplateRepository
        {
            get
            {
                if (this._documentTemplateRepository == null)
                {
                    this._documentTemplateRepository = new DocumentTemplateRepository(_db, new AuthorizationHelper<DocumentTemplate>(_settings, _authContext), _settings);
                }
                return _documentTemplateRepository;
            }
        }

        /// <summary>
        /// Gets the event log repository.
        /// </summary>
        /// <value>The event log repository.</value>
        public EventLogRepository EventLogRepository
        {
            get
            {
                if (this._eventLogRepository == null)
                {
                    this._eventLogRepository = new EventLogRepository(_db, new AuthorizationHelper<EventLog>(_settings, _authContext), _settings);
                }
                return _eventLogRepository;
            }
        }

        /// <summary>
        /// Gets the localization repository.
        /// </summary>
        /// <value>The localization repository.</value>
        public LocalizationRepository LocalizationRepository
        {
            get
            {
                if (this._localizationRepository == null)
                {
                    this._localizationRepository = new LocalizationRepository(_db, new AuthorizationHelper<Localization>(_settings, _authContext), _settings);
                }
                return _localizationRepository;
            }
        }

        /// <summary>
        /// Gets the lookup repository.
        /// </summary>
        /// <value>The lookup repository.</value>
        public LookupRepository LookupRepository
        {
            get
            {
                if (this._lookupRepository == null)
                {
                    this._lookupRepository = new LookupRepository(_db, new AuthorizationHelper<Lookup>(_settings, _authContext), _settings);
                }
                return _lookupRepository;
            }
        }

        /// <summary>
        /// Gets the lookup value repository.
        /// </summary>
        /// <value>The lookup value repository.</value>
        public LookupValueRepository LookupValueRepository
        {
            get
            {
                if (this._lookupValueRepository == null)
                {
                    this._lookupValueRepository = new LookupValueRepository(_db, new AuthorizationHelper<LookupValue>(_settings, _authContext), _settings);
                }
                return _lookupValueRepository;
            }
        }

        /// <summary>
        /// Gets the news letter repository.
        /// </summary>
        /// <value>The news letter repository.</value>
        public NewsLetterRepository NewsLetterRepository
        {
            get
            {
                if (this._newsLetterRepository == null)
                {
                    this._newsLetterRepository = new NewsLetterRepository(_db, new AuthorizationHelper<NewsLetter>(_settings, _authContext), _settings);
                }
                return _newsLetterRepository;
            }
        }

        /// <summary>
        /// Gets the organization repository.
        /// </summary>
        /// <value>The organization repository.</value>
        public OrganizationRepository OrganizationRepository
        {
            get
            {
                if (this._organizationRepository == null)
                {
                    this._organizationRepository = new OrganizationRepository(_db, new AuthorizationHelper<Organization>(_settings, _authContext), _settings);
                }
                return _organizationRepository;
            }
        }

        /// <summary>
        /// Gets the organization module repository.
        /// </summary>
        /// <value>The organization module repository.</value>
        public OrganizationModuleRepository OrganizationModuleRepository
        {
            get
            {
                if (this._organizationModuleRepository == null)
                {
                    this._organizationModuleRepository = new OrganizationModuleRepository(_db, new AuthorizationHelper<OrganizationModule>(_settings, _authContext), _settings);
                }
                return _organizationModuleRepository;
            }
        }

        /// <summary>
        /// Gets the organization service repository.
        /// </summary>
        /// <value>The organization service repository.</value>
        public OrganizationServiceRepository OrganizationServiceRepository
        {
            get
            {
                if (this._organizationServiceRepository == null)
                {
                    this._organizationServiceRepository = new OrganizationServiceRepository(_db, new AuthorizationHelper<OrganizationService>(_settings, _authContext), _settings);
                }
                return _organizationServiceRepository;
            }
        }

        /// <summary>
        /// Gets the organization user repository.
        /// </summary>
        /// <value>The organization user repository.</value>
        public OrganizationUserRepository OrganizationUserRepository
        {
            get
            {
                if (this._organizationUserRepository == null)
                {
                    this._organizationUserRepository = new OrganizationUserRepository(_db, new AuthorizationHelper<OrganizationUser>(_settings, _authContext), _settings);
                }
                return _organizationUserRepository;
            }
        }

        /// <summary>
        /// Gets the scheduled task repository.
        /// </summary>
        /// <value>The scheduled task repository.</value>
        public ScheduledTaskRepository ScheduledTaskRepository
        {
            get
            {
                if (this._scheduledTaskRepository == null)
                {
                    this._scheduledTaskRepository = new ScheduledTaskRepository(_db, new AuthorizationHelper<ScheduledTask>(_settings, _authContext), _settings);
                }
                return _scheduledTaskRepository;
            }
        }

        /// <summary>
        /// Gets the staging entity repository.
        /// </summary>
        /// <value>The staging entity repository.</value>
        public StagingEntityRepository StagingEntityRepository
        {
            get
            {
                if (this._stagingEntityRepository == null)
                {
                    this._stagingEntityRepository = new StagingEntityRepository(_db, new AuthorizationHelper<StagingEntity>(_settings, _authContext), _settings);
                }
                return _stagingEntityRepository;
            }
        }

        /// <summary>
        /// Gets the subscriber repository.
        /// </summary>
        /// <value>The subscriber repository.</value>
        public SubscriberRepository SubscriberRepository
        {
            get
            {
                if (this._subscriberRepository == null)
                {
                    this._subscriberRepository = new SubscriberRepository(_db, new AuthorizationHelper<Subscriber>(_settings, _authContext), _settings);
                }
                return _subscriberRepository;
            }
        }

        /// <summary>
        /// Gets the subscription repository.
        /// </summary>
        /// <value>The subscription repository.</value>
        public SubscriptionRepository SubscriptionRepository
        {
            get
            {
                if (this._subscriptionRepository == null)
                {
                    this._subscriptionRepository = new SubscriptionRepository(_db, new AuthorizationHelper<Subscription>(_settings, _authContext), _settings);
                }
                return _subscriptionRepository;
            }
        }

        /// <summary>
        /// Gets the workflow class repository.
        /// </summary>
        /// <value>The workflow class repository.</value>
        public WorkflowClassRepository WorkflowClassRepository
        {
            get
            {
                if (this._workflowClassRepository == null)
                {
                    this._workflowClassRepository = new WorkflowClassRepository(_db, new AuthorizationHelper<WorkflowClass>(_settings, _authContext), _settings);
                }
                return _workflowClassRepository;
            }
        }

        /// <summary>
        /// Gets the workflow action repository.
        /// </summary>
        /// <value>The workflow action repository.</value>
        public WorkflowActionRepository WorkflowActionRepository
        {
            get
            {
                if (this._workflowActionRepository == null)
                {
                    this._workflowActionRepository = new WorkflowActionRepository(_db, new AuthorizationHelper<WorkflowAction>(_settings, _authContext), _settings);
                }
                return _workflowActionRepository;
            }
        }

        /// <summary>
        /// Gets the workflow action attribute repository.
        /// </summary>
        /// <value>The workflow action attribute repository.</value>
        public WorkflowActionAttributeRepository WorkflowActionAttributeRepository
        {
            get
            {
                if (this._workflowActionAttributeRepository == null)
                {
                    this._workflowActionAttributeRepository = new WorkflowActionAttributeRepository(_db, new AuthorizationHelper<WorkflowActionAttribute>(_settings, _authContext), _settings);
                }
                return _workflowActionAttributeRepository;
            }
        }

        /// <summary>
        /// Gets the workflow stage repository.
        /// </summary>
        /// <value>The workflow stage repository.</value>
        public WorkflowStageRepository WorkflowStageRepository
        {
            get
            {
                if (this._workflowStageRepository == null)
                {
                    this._workflowStageRepository = new WorkflowStageRepository(_db, new AuthorizationHelper<WorkflowStage>(_settings, _authContext), _settings);
                }
                return _workflowStageRepository;
            }
        }

        /// <summary>
        /// Gets the workflow stage transition repository.
        /// </summary>
        /// <value>The workflow stage transition repository.</value>
        public WorkflowStageTransitionRepository WorkflowStageTransitionRepository
        {
            get
            {
                if (this._workflowStageTransitionRepository == null)
                {
                    this._workflowStageTransitionRepository = new WorkflowStageTransitionRepository(_db, new AuthorizationHelper<WorkflowStageTransition>(_settings, _authContext), _settings);
                }
                return _workflowStageTransitionRepository;
            }
        }

        /// <summary>
        /// Gets the workflow object repository.
        /// </summary>
        /// <value>The workflow object repository.</value>
        public WorkflowObjectRepository WorkflowObjectRepository
        {
            get
            {
                if (this._workflowObjectRepository == null)
                {
                    this._workflowObjectRepository = new WorkflowObjectRepository(_db, new AuthorizationHelper<WorkflowObject>(_settings, _authContext), _settings);
                }
                return _workflowObjectRepository;
            }
        }

        /// <summary>
        /// Gets the content control type repository.
        /// </summary>
        /// <value>The content control type repository.</value>
        public ContentControlTypeRepository ContentControlTypeRepository
        {
            get
            {
                if (this._contentControlTypeRepository == null)
                {
                    this._contentControlTypeRepository = new ContentControlTypeRepository(_db, new AuthorizationHelper<ContentControlType>(_settings, _authContext), _settings);
                }
                return _contentControlTypeRepository;
            }
        }

        /// <summary>
        /// Gets the content control repository.
        /// </summary>
        /// <value>The content control repository.</value>
        public ContentControlRepository ContentControlRepository
        {
            get
            {
                if (this._contentControlRepository == null)
                {
                    this._contentControlRepository = new ContentControlRepository(_db, new AuthorizationHelper<ContentControl>(_settings, _authContext), _settings);
                }
                return _contentControlRepository;
            }
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            FixEntityStates();
            _db.SaveChanges();
        }

        /// <summary>
        /// save as an asynchronous operation.
        /// </summary>
        public async Task SaveAsync()
        {
            FixEntityStates();
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed = false;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this._disposed = true;
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
