// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 07-26-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-26-2020
// ***********************************************************************
// <copyright file="Repositories.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.Common;
using BAP.DAL.Entities;
using System.Data.Entity;

namespace BAP.DAL
{
    /// <summary>
    /// Interface IMessageRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.Message}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.Message}" />
    public interface IMessageRepository : IGenericDataRepository<Message>
    {

    }

    /// <summary>
    /// Class MessageRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.Message}" />
    /// Implements the <see cref="BAP.DAL.IMessageRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.Message}" />
    /// <seealso cref="BAP.DAL.IMessageRepository" />
    public class MessageRepository : GenericDataRepository<Message>, IMessageRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal MessageRepository(DbContext context, IAuthorizationHelper<Message> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IModuleRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.Module}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.Module}" />
    public interface IModuleRepository : IGenericDataRepository<Module>
    {

    }

    /// <summary>
    /// Class ModuleRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.Module}" />
    /// Implements the <see cref="BAP.DAL.IModuleRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.Module}" />
    /// <seealso cref="BAP.DAL.IModuleRepository" />
    public class ModuleRepository : GenericDataRepository<Module>, IModuleRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal ModuleRepository(DbContext context, IAuthorizationHelper<Module> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IAttachmentRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.Attachment}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.Attachment}" />
    public interface IAttachmentRepository : IGenericDataRepository<Attachment>
    {

    }

    /// <summary>
    /// Class AttachmentRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.Attachment}" />
    /// Implements the <see cref="BAP.DAL.IAttachmentRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.Attachment}" />
    /// <seealso cref="BAP.DAL.IAttachmentRepository" />
    public class AttachmentRepository : GenericDataRepository<Attachment>, IAttachmentRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal AttachmentRepository(DbContext context, IAuthorizationHelper<Attachment> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IAttachmentAccessRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.AttachmentAccess}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.AttachmentAccess}" />
    public interface IAttachmentAccessRepository : IGenericDataRepository<AttachmentAccess>
    {

    }

    /// <summary>
    /// Class AttachmentAccessRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.AttachmentAccess}" />
    /// Implements the <see cref="BAP.DAL.IAttachmentAccessRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.AttachmentAccess}" />
    /// <seealso cref="BAP.DAL.IAttachmentAccessRepository" />
    public class AttachmentAccessRepository : GenericDataRepository<AttachmentAccess>, IAttachmentAccessRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentAccessRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal AttachmentAccessRepository(DbContext context, IAuthorizationHelper<AttachmentAccess> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IAttachmentHistRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.AttachmentHistory}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.AttachmentHistory}" />
    public interface IAttachmentHistRepository : IGenericDataRepository<AttachmentHistory>
    {

    }

    /// <summary>
    /// Class AttachmentHistRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.AttachmentHistory}" />
    /// Implements the <see cref="BAP.DAL.IAttachmentHistRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.AttachmentHistory}" />
    /// <seealso cref="BAP.DAL.IAttachmentHistRepository" />
    public class AttachmentHistRepository : GenericDataRepository<AttachmentHistory>, IAttachmentHistRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentHistRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal AttachmentHistRepository(DbContext context, IAuthorizationHelper<AttachmentHistory> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }


    /// <summary>
    /// Interface IBlogRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.Blog}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.Blog}" />
    public interface IBlogRepository : IGenericDataRepository<Blog>
    {

    }

    /// <summary>
    /// Class BlogRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.Blog}" />
    /// Implements the <see cref="BAP.DAL.IBlogRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.Blog}" />
    /// <seealso cref="BAP.DAL.IBlogRepository" />
    public class BlogRepository : GenericDataRepository<Blog>, IBlogRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal BlogRepository(DbContext context, IAuthorizationHelper<Blog> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IBlogAuthorRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.BlogAuthor}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.BlogAuthor}" />
    public interface IBlogAuthorRepository : IGenericDataRepository<BlogAuthor>
    {

    }

    /// <summary>
    /// Class BlogAuthorRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.BlogAuthor}" />
    /// Implements the <see cref="BAP.DAL.IBlogAuthorRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.BlogAuthor}" />
    /// <seealso cref="BAP.DAL.IBlogAuthorRepository" />
    public class BlogAuthorRepository : GenericDataRepository<BlogAuthor>, IBlogAuthorRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogAuthorRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal BlogAuthorRepository(DbContext context, IAuthorizationHelper<BlogAuthor> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IBlogPostRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.BlogPost}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.BlogPost}" />
    public interface IBlogPostRepository : IGenericDataRepository<BlogPost>
    {

    }

    /// <summary>
    /// Class BlogPostRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.BlogPost}" />
    /// Implements the <see cref="BAP.DAL.IBlogPostRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.BlogPost}" />
    /// <seealso cref="BAP.DAL.IBlogPostRepository" />
    public class BlogPostRepository : GenericDataRepository<BlogPost>, IBlogPostRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPostRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal BlogPostRepository(DbContext context, IAuthorizationHelper<BlogPost> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IBlogCommentRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.BlogComment}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.BlogComment}" />
    public interface IBlogCommentRepository : IGenericDataRepository<BlogComment>
    {

    }

    /// <summary>
    /// Class BlogCommentRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.BlogComment}" />
    /// Implements the <see cref="BAP.DAL.IBlogCommentRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.BlogComment}" />
    /// <seealso cref="BAP.DAL.IBlogCommentRepository" />
    public class BlogCommentRepository : GenericDataRepository<BlogComment>, IBlogCommentRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogCommentRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal BlogCommentRepository(DbContext context, IAuthorizationHelper<BlogComment> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IBlogCommentUserRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.BlogCommentUser}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.BlogCommentUser}" />
    public interface IBlogCommentUserRepository : IGenericDataRepository<BlogCommentUser>
    {

    }

    /// <summary>
    /// Class BlogCommentUserRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.BlogCommentUser}" />
    /// Implements the <see cref="BAP.DAL.IBlogCommentUserRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.BlogCommentUser}" />
    /// <seealso cref="BAP.DAL.IBlogCommentUserRepository" />
    public class BlogCommentUserRepository : GenericDataRepository<BlogCommentUser>, IBlogCommentUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogCommentUserRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal BlogCommentUserRepository(DbContext context, IAuthorizationHelper<BlogCommentUser> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IContentNodeRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.ContentNode}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.ContentNode}" />
    public interface IContentNodeRepository : IGenericDataRepository<ContentNode>
    {

    }

    /// <summary>
    /// Class ContentNodeRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.ContentNode}" />
    /// Implements the <see cref="BAP.DAL.IContentNodeRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.ContentNode}" />
    /// <seealso cref="BAP.DAL.IContentNodeRepository" />
    public class ContentNodeRepository : GenericDataRepository<ContentNode>, IContentNodeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentNodeRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal ContentNodeRepository(DbContext context, IAuthorizationHelper<ContentNode> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }


    /// <summary>
    /// Interface IContentViewRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.ContentView}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.ContentView}" />
    public interface IContentViewRepository : IGenericDataRepository<ContentView>
    {

    }
    /// <summary>
    /// Class ContentViewRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.ContentView}" />
    /// Implements the <see cref="BAP.DAL.IContentViewRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.ContentView}" />
    /// <seealso cref="BAP.DAL.IContentViewRepository" />
    public class ContentViewRepository : GenericDataRepository<ContentView>, IContentViewRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentViewRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal ContentViewRepository(DbContext context, IAuthorizationHelper<ContentView> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IContentViewControlRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.ContentViewControl}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.ContentViewControl}" />
    public interface IContentViewControlRepository : IGenericDataRepository<ContentViewControl>
    {

    }
    /// <summary>
    /// Class ContentViewControlRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.ContentViewControl}" />
    /// Implements the <see cref="BAP.DAL.IContentViewControlRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.ContentViewControl}" />
    /// <seealso cref="BAP.DAL.IContentViewControlRepository" />
    public class ContentViewControlRepository : GenericDataRepository<ContentViewControl>, IContentViewControlRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentViewControlRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal ContentViewControlRepository(DbContext context, IAuthorizationHelper<ContentViewControl> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IContentControlParameterRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.ContentControlParameter}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.ContentControlParameter}" />
    public interface IContentControlParameterRepository : IGenericDataRepository<ContentControlParameter>
    {

    }
    /// <summary>
    /// Class ContentControlParameterRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.ContentControlParameter}" />
    /// Implements the <see cref="BAP.DAL.IContentControlParameterRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.ContentControlParameter}" />
    /// <seealso cref="BAP.DAL.IContentControlParameterRepository" />
    public class ContentControlParameterRepository : GenericDataRepository<ContentControlParameter>, IContentControlParameterRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentControlParameterRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal ContentControlParameterRepository(DbContext context, IAuthorizationHelper<ContentControlParameter> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IContentNodeRouteRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.ContentNodeRoute}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.ContentNodeRoute}" />
    public interface IContentNodeRouteRepository : IGenericDataRepository<ContentNodeRoute>
    {

    }
    /// <summary>
    /// Class ContentNodeRouteRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.ContentNodeRoute}" />
    /// Implements the <see cref="BAP.DAL.IContentNodeRouteRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.ContentNodeRoute}" />
    /// <seealso cref="BAP.DAL.IContentNodeRouteRepository" />
    public class ContentNodeRouteRepository : GenericDataRepository<ContentNodeRoute>, IContentNodeRouteRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentNodeRouteRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal ContentNodeRouteRepository(DbContext context, IAuthorizationHelper<ContentNodeRoute> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }


    /// <summary>
    /// Interface IContentLocalizationRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.ContentLocalization}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.ContentLocalization}" />
    public interface IContentLocalizationRepository : IGenericDataRepository<ContentLocalization>
    {

    }
    /// <summary>
    /// Class ContentLocalizationRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.ContentLocalization}" />
    /// Implements the <see cref="BAP.DAL.IContentLocalizationRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.ContentLocalization}" />
    /// <seealso cref="BAP.DAL.IContentLocalizationRepository" />
    public class ContentLocalizationRepository : GenericDataRepository<ContentLocalization>, IContentLocalizationRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentLocalizationRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal ContentLocalizationRepository(DbContext context, IAuthorizationHelper<ContentLocalization> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }


    /// <summary>
    /// Interface ICountryRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.Country}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.Country}" />
    public interface ICountryRepository : IGenericDataRepository<Country>
    {

    }

    /// <summary>
    /// Class CountryRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.Country}" />
    /// Implements the <see cref="BAP.DAL.ICountryRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.Country}" />
    /// <seealso cref="BAP.DAL.ICountryRepository" />
    public class CountryRepository : GenericDataRepository<Country>, ICountryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal CountryRepository(DbContext context, IAuthorizationHelper<Country> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IStateRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.State}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.State}" />
    public interface IStateRepository : IGenericDataRepository<State>
    {

    }

    /// <summary>
    /// Class StateRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.State}" />
    /// Implements the <see cref="BAP.DAL.IStateRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.State}" />
    /// <seealso cref="BAP.DAL.IStateRepository" />
    public class StateRepository : GenericDataRepository<State>, IStateRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StateRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal StateRepository(DbContext context, IAuthorizationHelper<State> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface ICurrencyRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.Currency}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.Currency}" />
    public interface ICurrencyRepository : IGenericDataRepository<Currency>
    {

    }

    /// <summary>
    /// Class CurrencyRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.Currency}" />
    /// Implements the <see cref="BAP.DAL.ICurrencyRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.Currency}" />
    /// <seealso cref="BAP.DAL.ICurrencyRepository" />
    public class CurrencyRepository : GenericDataRepository<Currency>, ICurrencyRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal CurrencyRepository(DbContext context, IAuthorizationHelper<Currency> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface ICustomConfigurationRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.CustomConfiguration}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.CustomConfiguration}" />
    public interface ICustomConfigurationRepository : IGenericDataRepository<CustomConfiguration>
    {

    }

    /// <summary>
    /// Class CustomConfigurationRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.CustomConfiguration}" />
    /// Implements the <see cref="BAP.DAL.ICustomConfigurationRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.CustomConfiguration}" />
    /// <seealso cref="BAP.DAL.ICustomConfigurationRepository" />
    public class CustomConfigurationRepository : GenericDataRepository<CustomConfiguration>, ICustomConfigurationRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomConfigurationRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal CustomConfigurationRepository(DbContext context, IAuthorizationHelper<CustomConfiguration> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IDocumentTemplateRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.DocumentTemplate}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.DocumentTemplate}" />
    public interface IDocumentTemplateRepository : IGenericDataRepository<DocumentTemplate>
    {

    }

    /// <summary>
    /// Class DocumentTemplateRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.DocumentTemplate}" />
    /// Implements the <see cref="BAP.DAL.IDocumentTemplateRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.DocumentTemplate}" />
    /// <seealso cref="BAP.DAL.IDocumentTemplateRepository" />
    public class DocumentTemplateRepository : GenericDataRepository<DocumentTemplate>, IDocumentTemplateRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentTemplateRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal DocumentTemplateRepository(DbContext context, IAuthorizationHelper<DocumentTemplate> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IEventLogRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.EventLog}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.EventLog}" />
    public interface IEventLogRepository : IGenericDataRepository<EventLog>
    {

    }

    /// <summary>
    /// Class EventLogRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.EventLog}" />
    /// Implements the <see cref="BAP.DAL.IEventLogRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.EventLog}" />
    /// <seealso cref="BAP.DAL.IEventLogRepository" />
    public class EventLogRepository : GenericDataRepository<EventLog>, IEventLogRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventLogRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal EventLogRepository(DbContext context, IAuthorizationHelper<EventLog> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface ILocalizationRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.Localization}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.Localization}" />
    public interface ILocalizationRepository : IGenericDataRepository<Localization>
    {

    }

    /// <summary>
    /// Class LocalizationRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.Localization}" />
    /// Implements the <see cref="BAP.DAL.ILocalizationRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.Localization}" />
    /// <seealso cref="BAP.DAL.ILocalizationRepository" />
    public class LocalizationRepository : GenericDataRepository<Localization>, ILocalizationRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizationRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal LocalizationRepository(DbContext context, IAuthorizationHelper<Localization> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface ILookupRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.Lookup}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.Lookup}" />
    public interface ILookupRepository : IGenericDataRepository<Lookup>
    {

    }

    /// <summary>
    /// Class LookupRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.Lookup}" />
    /// Implements the <see cref="BAP.DAL.ILookupRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.Lookup}" />
    /// <seealso cref="BAP.DAL.ILookupRepository" />
    public class LookupRepository : GenericDataRepository<Lookup>, ILookupRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LookupRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal LookupRepository(DbContext context, IAuthorizationHelper<Lookup> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface ILookupValueRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.LookupValue}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.LookupValue}" />
    public interface ILookupValueRepository : IGenericDataRepository<LookupValue>
    {

    }

    /// <summary>
    /// Class LookupValueRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.LookupValue}" />
    /// Implements the <see cref="BAP.DAL.ILookupValueRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.LookupValue}" />
    /// <seealso cref="BAP.DAL.ILookupValueRepository" />
    public class LookupValueRepository : GenericDataRepository<LookupValue>, ILookupValueRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LookupValueRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal LookupValueRepository(DbContext context, IAuthorizationHelper<LookupValue> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface INewsLetterRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.NewsLetter}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.NewsLetter}" />
    public interface INewsLetterRepository : IGenericDataRepository<NewsLetter>
    {

    }

    /// <summary>
    /// Class NewsLetterRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.NewsLetter}" />
    /// Implements the <see cref="BAP.DAL.INewsLetterRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.NewsLetter}" />
    /// <seealso cref="BAP.DAL.INewsLetterRepository" />
    public class NewsLetterRepository : GenericDataRepository<NewsLetter>, INewsLetterRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewsLetterRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal NewsLetterRepository(DbContext context, IAuthorizationHelper<NewsLetter> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IOrganizationRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.Organization}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.Organization}" />
    public interface IOrganizationRepository : IGenericDataRepository<Organization>
    {

    }

    /// <summary>
    /// Class OrganizationRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.Organization}" />
    /// Implements the <see cref="BAP.DAL.IOrganizationRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.Organization}" />
    /// <seealso cref="BAP.DAL.IOrganizationRepository" />
    public class OrganizationRepository : GenericDataRepository<Organization>, IOrganizationRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal OrganizationRepository(DbContext context, IAuthorizationHelper<Organization> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IOrganizationModuleRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.OrganizationModule}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.OrganizationModule}" />
    public interface IOrganizationModuleRepository : IGenericDataRepository<OrganizationModule>
    {

    }

    /// <summary>
    /// Class OrganizationModuleRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.OrganizationModule}" />
    /// Implements the <see cref="BAP.DAL.IOrganizationModuleRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.OrganizationModule}" />
    /// <seealso cref="BAP.DAL.IOrganizationModuleRepository" />
    public class OrganizationModuleRepository : GenericDataRepository<OrganizationModule>, IOrganizationModuleRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationModuleRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal OrganizationModuleRepository(DbContext context, IAuthorizationHelper<OrganizationModule> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IOrganizationServiceRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.OrganizationService}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.OrganizationService}" />
    public interface IOrganizationServiceRepository : IGenericDataRepository<OrganizationService>
    {

    }

    /// <summary>
    /// Class OrganizationServiceRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.OrganizationService}" />
    /// Implements the <see cref="BAP.DAL.IOrganizationServiceRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.OrganizationService}" />
    /// <seealso cref="BAP.DAL.IOrganizationServiceRepository" />
    public class OrganizationServiceRepository : GenericDataRepository<OrganizationService>, IOrganizationServiceRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationServiceRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal OrganizationServiceRepository(DbContext context, IAuthorizationHelper<OrganizationService> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IOrganizationUserRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.OrganizationUser}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.OrganizationUser}" />
    public interface IOrganizationUserRepository : IGenericDataRepository<OrganizationUser>
    {

    }

    /// <summary>
    /// Class OrganizationUserRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.OrganizationUser}" />
    /// Implements the <see cref="BAP.DAL.IOrganizationUserRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.OrganizationUser}" />
    /// <seealso cref="BAP.DAL.IOrganizationUserRepository" />
    public class OrganizationUserRepository : GenericDataRepository<OrganizationUser>, IOrganizationUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationUserRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal OrganizationUserRepository(DbContext context, IAuthorizationHelper<OrganizationUser> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IScheduledTaskRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.ScheduledTask}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.ScheduledTask}" />
    public interface IScheduledTaskRepository : IGenericDataRepository<ScheduledTask>
    {

    }

    /// <summary>
    /// Class ScheduledTaskRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.ScheduledTask}" />
    /// Implements the <see cref="BAP.DAL.IScheduledTaskRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.ScheduledTask}" />
    /// <seealso cref="BAP.DAL.IScheduledTaskRepository" />
    public class ScheduledTaskRepository : GenericDataRepository<ScheduledTask>, IScheduledTaskRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduledTaskRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal ScheduledTaskRepository(DbContext context, IAuthorizationHelper<ScheduledTask> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IStagingEntityRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.StagingEntity}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.StagingEntity}" />
    public interface IStagingEntityRepository : IGenericDataRepository<StagingEntity>
    {

    }

    /// <summary>
    /// Class StagingEntityRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.StagingEntity}" />
    /// Implements the <see cref="BAP.DAL.IStagingEntityRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.StagingEntity}" />
    /// <seealso cref="BAP.DAL.IStagingEntityRepository" />
    public class StagingEntityRepository : GenericDataRepository<StagingEntity>, IStagingEntityRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StagingEntityRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal StagingEntityRepository(DbContext context, IAuthorizationHelper<StagingEntity> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface ISubscriberRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.Subscriber}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.Subscriber}" />
    public interface ISubscriberRepository : IGenericDataRepository<Subscriber>
    {

    }

    /// <summary>
    /// Class SubscriberRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.Subscriber}" />
    /// Implements the <see cref="BAP.DAL.ISubscriberRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.Subscriber}" />
    /// <seealso cref="BAP.DAL.ISubscriberRepository" />
    public class SubscriberRepository : GenericDataRepository<Subscriber>, ISubscriberRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriberRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal SubscriberRepository(DbContext context, IAuthorizationHelper<Subscriber> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface ISubscriptionRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.Subscription}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.Subscription}" />
    public interface ISubscriptionRepository : IGenericDataRepository<Subscription>
    {

    }

    /// <summary>
    /// Class SubscriptionRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.Subscription}" />
    /// Implements the <see cref="BAP.DAL.ISubscriptionRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.Subscription}" />
    /// <seealso cref="BAP.DAL.ISubscriptionRepository" />
    public class SubscriptionRepository : GenericDataRepository<Subscription>, ISubscriptionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal SubscriptionRepository(DbContext context, IAuthorizationHelper<Subscription> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IWorkflowClassRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.WorkflowClass}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.WorkflowClass}" />
    public interface IWorkflowClassRepository : IGenericDataRepository<WorkflowClass>
    {

    }

    /// <summary>
    /// Class WorkflowClassRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.WorkflowClass}" />
    /// Implements the <see cref="BAP.DAL.IWorkflowClassRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.WorkflowClass}" />
    /// <seealso cref="BAP.DAL.IWorkflowClassRepository" />
    public class WorkflowClassRepository : GenericDataRepository<WorkflowClass>, IWorkflowClassRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowClassRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal WorkflowClassRepository(DbContext context, IAuthorizationHelper<WorkflowClass> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IWorkflowActionRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.WorkflowAction}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.WorkflowAction}" />
    public interface IWorkflowActionRepository : IGenericDataRepository<WorkflowAction>
    {

    }

    /// <summary>
    /// Class WorkflowActionRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.WorkflowAction}" />
    /// Implements the <see cref="BAP.DAL.IWorkflowActionRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.WorkflowAction}" />
    /// <seealso cref="BAP.DAL.IWorkflowActionRepository" />
    public class WorkflowActionRepository : GenericDataRepository<WorkflowAction>, IWorkflowActionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowActionRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal WorkflowActionRepository(DbContext context, IAuthorizationHelper<WorkflowAction> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IWorkflowActionAttributeRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.WorkflowActionAttribute}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.WorkflowActionAttribute}" />
    public interface IWorkflowActionAttributeRepository : IGenericDataRepository<WorkflowActionAttribute>
    {

    }

    /// <summary>
    /// Class WorkflowActionAttributeRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.WorkflowActionAttribute}" />
    /// Implements the <see cref="BAP.DAL.IWorkflowActionAttributeRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.WorkflowActionAttribute}" />
    /// <seealso cref="BAP.DAL.IWorkflowActionAttributeRepository" />
    public class WorkflowActionAttributeRepository : GenericDataRepository<WorkflowActionAttribute>, IWorkflowActionAttributeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowActionAttributeRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal WorkflowActionAttributeRepository(DbContext context, IAuthorizationHelper<WorkflowActionAttribute> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IWorkflowStageRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.WorkflowStage}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.WorkflowStage}" />
    public interface IWorkflowStageRepository : IGenericDataRepository<WorkflowStage>
    {

    }

    /// <summary>
    /// Class WorkflowStageRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.WorkflowStage}" />
    /// Implements the <see cref="BAP.DAL.IWorkflowStageRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.WorkflowStage}" />
    /// <seealso cref="BAP.DAL.IWorkflowStageRepository" />
    public class WorkflowStageRepository : GenericDataRepository<WorkflowStage>, IWorkflowStageRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowStageRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal WorkflowStageRepository(DbContext context, IAuthorizationHelper<WorkflowStage> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IWorkflowStageTransitionRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.WorkflowStageTransition}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.WorkflowStageTransition}" />
    public interface IWorkflowStageTransitionRepository : IGenericDataRepository<WorkflowStageTransition>
    {

    }

    /// <summary>
    /// Class WorkflowStageTransitionRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.WorkflowStageTransition}" />
    /// Implements the <see cref="BAP.DAL.IWorkflowStageTransitionRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.WorkflowStageTransition}" />
    /// <seealso cref="BAP.DAL.IWorkflowStageTransitionRepository" />
    public class WorkflowStageTransitionRepository : GenericDataRepository<WorkflowStageTransition>, IWorkflowStageTransitionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowStageTransitionRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal WorkflowStageTransitionRepository(DbContext context, IAuthorizationHelper<WorkflowStageTransition> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IWorkflowObjectRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.WorkflowObject}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.WorkflowObject}" />
    public interface IWorkflowObjectRepository : IGenericDataRepository<WorkflowObject>
    {

    }

    /// <summary>
    /// Class WorkflowObjectRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.WorkflowObject}" />
    /// Implements the <see cref="BAP.DAL.IWorkflowObjectRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.WorkflowObject}" />
    /// <seealso cref="BAP.DAL.IWorkflowObjectRepository" />
    public class WorkflowObjectRepository : GenericDataRepository<WorkflowObject>, IWorkflowObjectRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowObjectRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal WorkflowObjectRepository(DbContext context, IAuthorizationHelper<WorkflowObject> authHelper, IConfigHelper settings)
            : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IContentControlTypeRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.ContentControlType}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.ContentControlType}" />
    public interface IContentControlTypeRepository : IGenericDataRepository<ContentControlType>
    {

    }

    /// <summary>
    /// Class ContentControlTypeRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.ContentControlType}" />
    /// Implements the <see cref="BAP.DAL.IContentControlTypeRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.ContentControlType}" />
    /// <seealso cref="BAP.DAL.IContentControlTypeRepository" />
    public class ContentControlTypeRepository : GenericDataRepository<ContentControlType>, IContentControlTypeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentControlTypeRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal ContentControlTypeRepository(DbContext context, IAuthorizationHelper<ContentControlType> authHelper, IConfigHelper settings)
          : base(context, authHelper, settings)
        {
        }
    }

    /// <summary>
    /// Interface IContentControlRepository
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.ContentControl}" />
    /// </summary>
    /// <seealso cref="BAP.Common.IGenericDataRepository{BAP.DAL.Entities.ContentControl}" />
    public interface IContentControlRepository : IGenericDataRepository<ContentControl>
    {

    }

    /// <summary>
    /// Class ContentControlRepository.
    /// Implements the <see cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.ContentControl}" />
    /// Implements the <see cref="BAP.DAL.IContentControlRepository" />
    /// </summary>
    /// <seealso cref="BAP.DAL.GenericDataRepository{BAP.DAL.Entities.ContentControl}" />
    /// <seealso cref="BAP.DAL.IContentControlRepository" />
    public class ContentControlRepository : GenericDataRepository<ContentControl>, IContentControlRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentControlRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        internal ContentControlRepository(DbContext context, IAuthorizationHelper<ContentControl> authHelper, IConfigHelper settings)
          : base(context, authHelper, settings)
        {
        }
    }
}
