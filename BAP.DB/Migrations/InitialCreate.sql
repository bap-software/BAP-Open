CREATE TABLE [dbo].[Address] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80) NOT NULL,
    [CompanyName] [nvarchar](256),
    [Description] [nvarchar](1024),
    [FirstName] [nvarchar](50) NOT NULL,
    [MiddleName] [nvarchar](50),
    [LastName] [nvarchar](50) NOT NULL,
    [AddressLine1] [nvarchar](80) NOT NULL,
    [AddressLine2] [nvarchar](80),
    [City] [nvarchar](80) NOT NULL,
    [County] [nvarchar](80),
    [State] [nvarchar](80) NOT NULL,
    [Country] [nvarchar](80) NOT NULL,
    [Zip] [nvarchar](5) NOT NULL,
    [PhoneNumber] [nvarchar](20) NOT NULL,
    [PhoneExtension] [nvarchar](5),
    [FaxNumber] [nvarchar](20),
    [CellNumber] [nvarchar](20),
    [ContactEmail] [nvarchar](255) NOT NULL,
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Address] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_AddressName] ON [dbo].[Address]([Name])
CREATE INDEX [IX_Tenant] ON [dbo].[Address]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[Address]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[Address]([OwnerPermissions])
CREATE TABLE [dbo].[AttachmentHistory] (
    [Id] [int] NOT NULL IDENTITY,
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [FileName] [nvarchar](max),
    [FilePath] [nvarchar](max),
    [Length] [bigint],
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    [Attachment_Id] [int],
    CONSTRAINT [PK_dbo.AttachmentHistory] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_Tenant] ON [dbo].[AttachmentHistory]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[AttachmentHistory]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[AttachmentHistory]([OwnerPermissions])
CREATE INDEX [IX_Attachment_Id] ON [dbo].[AttachmentHistory]([Attachment_Id])
CREATE TABLE [dbo].[Attachment] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](255),
    [Description] [nvarchar](1024),
    [AttachmentType] [nvarchar](255),
    [Object] [nvarchar](255),
    [ObjectId] [int] NOT NULL,
    [PathUrl] [nvarchar](255),
    [Status] [nvarchar](80),
    [StatusDate] [datetime] NOT NULL,
    [Published] [bit],
    [PublishFrom] [datetime],
    [PublishTo] [datetime],
    [MimeType] [nvarchar](255),
    [PathAliases] [nvarchar](max),
    [AltText] [nvarchar](255),
    [TitleText] [nvarchar](255),
    [Keywords] [nvarchar](255),
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [Length] [bigint],
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Attachment] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_AttachmentNameObect] ON [dbo].[Attachment]([Name], [AttachmentType], [Object], [ObjectId])
CREATE INDEX [IX_Tenant] ON [dbo].[Attachment]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[Attachment]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[Attachment]([OwnerPermissions])
CREATE TABLE [dbo].[BlogAuthor] (
    [Id] [int] NOT NULL IDENTITY,
    [NickName] [nvarchar](80),
    [FirstName] [nvarchar](80),
    [LastName] [nvarchar](80),
    [Email] [nvarchar](256),
    [WebSite] [nvarchar](256),
    [OrganizationUserId] [int],
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.BlogAuthor] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_BlogAuthorName] ON [dbo].[BlogAuthor]([FirstName], [LastName])
CREATE INDEX [IX_OrganizationUserId] ON [dbo].[BlogAuthor]([OrganizationUserId])
CREATE INDEX [IX_Tenant] ON [dbo].[BlogAuthor]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[BlogAuthor]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[BlogAuthor]([OwnerPermissions])
CREATE TABLE [dbo].[Blog] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80),
    [ShortDescription] [nvarchar](256),
    [Description] [nvarchar](1024),
    [MainImageUrl] [nvarchar](1024),
    [BlogAuthorId] [int],
    [Tags] [nvarchar](256),
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Blog] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_BlogName] ON [dbo].[Blog]([Name])
CREATE INDEX [IX_BlogAuthorId] ON [dbo].[Blog]([BlogAuthorId])
CREATE INDEX [IX_Tenant] ON [dbo].[Blog]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[Blog]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[Blog]([OwnerPermissions])
CREATE TABLE [dbo].[BlogComment] (
    [Id] [int] NOT NULL IDENTITY,
    [Title] [nvarchar](80),
    [Author] [nvarchar](80),
    [Text] [nvarchar](512),
    [BlogId] [int],
    [BlogPostId] [int],
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.BlogComment] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_BlogComment] ON [dbo].[BlogComment]([Title], [Author])
CREATE INDEX [IX_BlogId] ON [dbo].[BlogComment]([BlogId])
CREATE INDEX [IX_BlogPostId] ON [dbo].[BlogComment]([BlogPostId])
CREATE INDEX [IX_Tenant] ON [dbo].[BlogComment]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[BlogComment]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[BlogComment]([OwnerPermissions])
CREATE TABLE [dbo].[BlogPost] (
    [Id] [int] NOT NULL IDENTITY,
    [Title] [nvarchar](80),
    [ShortDescription] [nvarchar](256),
    [Text] [nvarchar](2048),
    [MainImageUrl] [nvarchar](1024),
    [BlogId] [int],
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.BlogPost] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_BlogPost] ON [dbo].[BlogPost]([Title], [ShortDescription])
CREATE INDEX [IX_BlogId] ON [dbo].[BlogPost]([BlogId])
CREATE INDEX [IX_Tenant] ON [dbo].[BlogPost]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[BlogPost]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[BlogPost]([OwnerPermissions])
CREATE TABLE [dbo].[OrganizationUser] (
    [Id] [int] NOT NULL IDENTITY,
    [AspNetUserId] [nvarchar](max),
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](max),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](max),
    [TimeStamp] rowversion,
    [FirstName] [nvarchar](50),
    [MiddleName] [nvarchar](50),
    [LastName] [nvarchar](50),
    [AddressLine1] [nvarchar](80),
    [AddressLine2] [nvarchar](80),
    [City] [nvarchar](80),
    [County] [nvarchar](80),
    [State] [nvarchar](80),
    [Country] [nvarchar](80),
    [Zip] [nvarchar](5),
    [PhoneNumber] [nvarchar](20),
    [CellNumber] [nvarchar](20),
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [UserName] [nvarchar](max),
    [FullName] [nvarchar](max),
    [Organization_Id] [int],
    CONSTRAINT [PK_dbo.OrganizationUser] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_OrgUserName] ON [dbo].[OrganizationUser]([FirstName], [MiddleName], [LastName])
CREATE INDEX [IX_Tenant] ON [dbo].[OrganizationUser]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[OrganizationUser]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[OrganizationUser]([OwnerPermissions])
CREATE INDEX [IX_Organization_Id] ON [dbo].[OrganizationUser]([Organization_Id])
CREATE TABLE [dbo].[Organization] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80),
    [Description] [nvarchar](255),
    [TaxId] [nvarchar](80),
    [Status] [nvarchar](80),
    [StatusDate] [datetime] NOT NULL,
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](max),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](max),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OrganizationType] [int] NOT NULL,
    [AddressLine1] [nvarchar](80),
    [AddressLine2] [nvarchar](80),
    [City] [nvarchar](80),
    [County] [nvarchar](80),
    [State] [nvarchar](80),
    [Country] [nvarchar](80),
    [Zip] [nvarchar](5),
    [PhoneNumber] [nvarchar](20),
    [PhoneExtension] [nvarchar](5),
    [FaxNumber] [nvarchar](20),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    [LogoPathUrl] [nvarchar](255),
    [FacebookUrl] [nvarchar](255),
    [TwitterUrl] [nvarchar](255),
    [LinkedinUrl] [nvarchar](255),
    [GoogleplusUrl] [nvarchar](255),
    [Url] [nvarchar](255),
    [ContactEmail] [nvarchar](255),
    [SupportEmail] [nvarchar](255),
    [ImplementedCulturesText] [nvarchar](255),
    [HostName] [nvarchar](255),
    [HostNameAliasesText] [nvarchar](2048),
    [BapDefaultFromEmail] [nvarchar](255),
    [BapDefaultContactEmail] [nvarchar](255),
    [SmtpUserName] [nvarchar](255),
    [SmtpUserPassword] [nvarchar](255),
    [SmtpHostName] [nvarchar](255),
    [SmtpPort] [int] NOT NULL,
    [SmtpUseSsl] [bit] NOT NULL,
    [reCaptchaSiteKey] [nvarchar](255),
    [reCaptchaSecretKey] [nvarchar](255),
    [GetBearrerTokenDuringLogin] [bit] NOT NULL,
    [AuthCookieName] [nvarchar](255),
    [AuthCookieExpirationTime] [int] NOT NULL,
    [WebApiPublicClientId] [nvarchar](255),
    [BearerTokenExpirationTime] [int] NOT NULL,
    [WebApiAllowInsecureHttp] [bit] NOT NULL,
    [PublicFolderText] [nvarchar](255),
    [BaseFolderText] [nvarchar](255),
    CONSTRAINT [PK_dbo.Organization] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_OrganizationName] ON [dbo].[Organization]([Name])
CREATE INDEX [IX_Tenant] ON [dbo].[Organization]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[Organization]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[Organization]([OwnerPermissions])
CREATE TABLE [dbo].[ContentControlParameter] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80),
    [ShortDescription] [nvarchar](256),
    [Description] [nvarchar](max),
    [ContentViewControlId] [int],
    [ParameterName] [nvarchar](40),
    [DataType] [nvarchar](40),
    [DataSource] [nvarchar](512),
    [DefaultValue] [nvarchar](1024),
    [IsRequired] [bit] NOT NULL,
    [IsReadOnly] [bit] NOT NULL,
    [IsVisible] [bit] NOT NULL,
    [PlaceHolder] [nvarchar](80),
    [Caption] [nvarchar](40),
    [FormControl] [nvarchar](80),
    [DefaultErrorMessage] [nvarchar](256),
    [CssClass] [nvarchar](80),
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ContentControlParameter] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_ContentControlParameterName] ON [dbo].[ContentControlParameter]([Name])
CREATE INDEX [IX_ContentViewControlId] ON [dbo].[ContentControlParameter]([ContentViewControlId])
CREATE INDEX [IX_ContentControlParameterTenant] ON [dbo].[ContentControlParameter]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[ContentControlParameter]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[ContentControlParameter]([OwnerPermissions])
CREATE TABLE [dbo].[ContentViewControl] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80),
    [Description] [nvarchar](max),
    [ContentNodeId] [int],
    [ContentViewId] [int],
    [ControlType] [nvarchar](80),
    [ControlId] [nvarchar](80),
    [ControlTitle] [nvarchar](40),
    [IsVisible] [bit] NOT NULL,
    [IsReadOnly] [bit] NOT NULL,
    [ContainerTag] [nvarchar](20),
    [ContainerCss] [nvarchar](40),
    [ContainerContent] [nvarchar](1024),
    [ContentBefore] [nvarchar](1024),
    [ContentAfter] [nvarchar](1024),
    [JavaScript] [nvarchar](max),
    [StyleContent] [nvarchar](max),
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ContentViewControl] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_ContentViewControlName] ON [dbo].[ContentViewControl]([Name])
CREATE INDEX [IX_ContentNodeId] ON [dbo].[ContentViewControl]([ContentNodeId])
CREATE INDEX [IX_ContentViewId] ON [dbo].[ContentViewControl]([ContentViewId])
CREATE INDEX [IX_ContentViewControlTenant] ON [dbo].[ContentViewControl]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[ContentViewControl]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[ContentViewControl]([OwnerPermissions])
CREATE TABLE [dbo].[ContentNode] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80) NOT NULL,
    [ShortDescription] [nvarchar](256),
    [Description] [nvarchar](max),
    [Alias] [nvarchar](80) NOT NULL,
    [AliasPath] [nvarchar](1024) NOT NULL,
    [IsHome] [bit] NOT NULL,
    [ShowInMenu] [bit] NOT NULL,
    [ShowInSitemap] [bit] NOT NULL,
    [ContentDescription] [nvarchar](256),
    [ContentKeywords] [nvarchar](256),
    [ContentAuthor] [nvarchar](128),
    [LayoutPath] [nvarchar](1024),
    [NavigationType] [int] NOT NULL,
    [Rating] [int] NOT NULL,
    [Culture] [nvarchar](20),
    [Area] [nvarchar](80),
    [Controller] [nvarchar](80),
    [Action] [nvarchar](80),
    [ActionParams] [nvarchar](256),
    [View] [nvarchar](80),
    [RouteUrl] [nvarchar](256),
    [NameSpaces] [nvarchar](256),
    [Enabled] [bit] NOT NULL,
    [DefaultCss] [nvarchar](80),
    [UrlAliases] [nvarchar](max),
    [ContentTitle] [nvarchar](80),
    [ContentTagGroup] [nvarchar](80),
    [ContentTags] [nvarchar](256),
    [SitemapPriority] [int] NOT NULL,
    [SitemapChangeFrequency] [int] NOT NULL,
    [MenuCaption] [nvarchar](80),
    [Roles] [nvarchar](256),
    [AllowChildren] [bit] NOT NULL,
    [MenuClicable] [bit] NOT NULL,
    [MenuIcon] [nvarchar](256),
    [UrlTarget] [nvarchar](40),
    [MenuExtraAttributes] [nvarchar](512),
    [HttpMethod] [nvarchar](10),
    [MenuSortOrder] [int] NOT NULL,
    [ParentNodeId] [int],
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ContentNode] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_ContentNodeName] ON [dbo].[ContentNode]([Name])
CREATE UNIQUE INDEX [IX_ContentNodeRoute] ON [dbo].[ContentNode]([Area], [Controller], [Action], [View])
CREATE INDEX [IX_ParentNodeId] ON [dbo].[ContentNode]([ParentNodeId])
CREATE INDEX [IX_ContentNodeTenant] ON [dbo].[ContentNode]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[ContentNode]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[ContentNode]([OwnerPermissions])
CREATE TABLE [dbo].[ContentView] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80),
    [Description] [nvarchar](max),
    [ViewName] [nvarchar](80),
    [ViewPath] [nvarchar](1024),
    [LayoutPath] [nvarchar](1024),
    [ViewContent] [nvarchar](max),
    [Roles] [nvarchar](80),
    [IsPartial] [bit] NOT NULL,
    [IsShared] [bit] NOT NULL,
    [IsMain] [bit] NOT NULL,
    [Enabled] [bit] NOT NULL,
    [IsLayout] [bit] NOT NULL,
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ContentView] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_ContentViewName] ON [dbo].[ContentView]([Name])
CREATE INDEX [IX_ContentViewTenant] ON [dbo].[ContentView]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[ContentView]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[ContentView]([OwnerPermissions])
CREATE TABLE [dbo].[ContentLocalization] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80),
    [CultureCode] [nvarchar](20),
    [ContentNodeId] [int],
    [Text] [nvarchar](max),
    [IsDefault] [bit] NOT NULL,
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ContentLocalization] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_ContentLocalizationName] ON [dbo].[ContentLocalization]([Name])
CREATE INDEX [IX_ContentNodeId] ON [dbo].[ContentLocalization]([ContentNodeId])
CREATE INDEX [IX_ContentLocalizationTenant] ON [dbo].[ContentLocalization]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[ContentLocalization]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[ContentLocalization]([OwnerPermissions])
CREATE TABLE [dbo].[ContentNodeRoute] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80),
    [Description] [nvarchar](max),
    [ContentNodeId] [int],
    [RouteName] [nvarchar](80),
    [Controller] [nvarchar](80),
    [Action] [nvarchar](80),
    [Area] [nvarchar](80),
    [DataTokens] [nvarchar](256),
    [RouteParameters] [nvarchar](1024),
    [NameSpaces] [nvarchar](1024),
    [Url] [nvarchar](1024),
    [Roles] [nvarchar](256),
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ContentNodeRoute] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_ContentNodeRouteName] ON [dbo].[ContentNodeRoute]([Name])
CREATE INDEX [IX_ContentNodeId] ON [dbo].[ContentNodeRoute]([ContentNodeId])
CREATE INDEX [IX_ContentNodeRouteTenant] ON [dbo].[ContentNodeRoute]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[ContentNodeRoute]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[ContentNodeRoute]([OwnerPermissions])
CREATE TABLE [dbo].[Currency] (
    [Id] [int] NOT NULL IDENTITY,
    [ThreeLetterCode] [nvarchar](5) NOT NULL,
    [Name] [nvarchar](50) NOT NULL,
    [Description] [nvarchar](255) NOT NULL,
    [ExchangeRate] [decimal](18, 2),
    [Symbol] [nvarchar](5) NOT NULL,
    [IsMain] [bit] NOT NULL,
    [IsEnabled] [bit] NOT NULL,
    [RoundTo] [int] NOT NULL,
    [FormatString] [nvarchar](20),
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Currency] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_CurrencyCode] ON [dbo].[Currency]([ThreeLetterCode])
CREATE INDEX [IX_Tenant] ON [dbo].[Currency]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[Currency]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[Currency]([OwnerPermissions])
CREATE TABLE [dbo].[CustomerOrderPayment] (
    [Id] [int] NOT NULL IDENTITY,
    [ReferenceId] [nvarchar](512),
    [CustomerOrderId] [int],
    [PaymentOptionId] [int] NOT NULL,
    [CustomerPaymentId] [int],
    [PaymentStatus] [int] NOT NULL,
    [AttemptNo] [int] NOT NULL,
    [Started] [datetime] NOT NULL,
    [Finished] [datetime] NOT NULL,
    [PaymentIntent] [int] NOT NULL,
    [CurrencyId] [int] NOT NULL,
    [Total] [real] NOT NULL,
    [IsError] [bit] NOT NULL,
    [ErrorCode] [nvarchar](40),
    [ErrorDescription] [nvarchar](512),
    [PaymentNotes] [nvarchar](256),
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CustomerOrderPayment] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_CustomerOrderId] ON [dbo].[CustomerOrderPayment]([CustomerOrderId])
CREATE INDEX [IX_PaymentOptionId] ON [dbo].[CustomerOrderPayment]([PaymentOptionId])
CREATE INDEX [IX_CustomerPaymentId] ON [dbo].[CustomerOrderPayment]([CustomerPaymentId])
CREATE INDEX [IX_CurrencyId] ON [dbo].[CustomerOrderPayment]([CurrencyId])
CREATE INDEX [IX_CustomerOrderPaymentTenant] ON [dbo].[CustomerOrderPayment]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[CustomerOrderPayment]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[CustomerOrderPayment]([OwnerPermissions])
CREATE TABLE [dbo].[CustomerOrder] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80) NOT NULL,
    [ShortDescription] [nvarchar](256),
    [Description] [nvarchar](max),
    [CustomerId] [int],
    [CustomerPaymentId] [int],
    [UserId] [int],
    [CurrencyId] [int] NOT NULL,
    [ShippingOptionId] [int] NOT NULL,
    [PaymentOptionId] [int] NOT NULL,
    [DiscountCouponId] [int],
    [BillingAddressId] [int] NOT NULL,
    [ShippingAddressId] [int] NOT NULL,
    [Coupon] [nvarchar](200),
    [Notes] [nvarchar](1024),
    [CustomData] [nvarchar](1024),
    [Subtotal] [real] NOT NULL,
    [Total] [real] NOT NULL,
    [DiscountsTotal] [real] NOT NULL,
    [ShippingCost] [real] NOT NULL,
    [TaxTotal] [real] NOT NULL,
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CustomerOrder] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_CustomerOrderName] ON [dbo].[CustomerOrder]([Name])
CREATE INDEX [IX_CustomerId] ON [dbo].[CustomerOrder]([CustomerId])
CREATE INDEX [IX_CustomerPaymentId] ON [dbo].[CustomerOrder]([CustomerPaymentId])
CREATE INDEX [IX_UserId] ON [dbo].[CustomerOrder]([UserId])
CREATE INDEX [IX_CurrencyId] ON [dbo].[CustomerOrder]([CurrencyId])
CREATE INDEX [IX_ShippingOptionId] ON [dbo].[CustomerOrder]([ShippingOptionId])
CREATE INDEX [IX_PaymentOptionId] ON [dbo].[CustomerOrder]([PaymentOptionId])
CREATE INDEX [IX_DiscountCouponId] ON [dbo].[CustomerOrder]([DiscountCouponId])
CREATE INDEX [IX_BillingAddressId] ON [dbo].[CustomerOrder]([BillingAddressId])
CREATE INDEX [IX_ShippingAddressId] ON [dbo].[CustomerOrder]([ShippingAddressId])
CREATE INDEX [IX_CustomerOrderTenant] ON [dbo].[CustomerOrder]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[CustomerOrder]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[CustomerOrder]([OwnerPermissions])
CREATE TABLE [dbo].[Customer] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80) NOT NULL,
    [ShortDescription] [nvarchar](256),
    [Description] [nvarchar](max),
    [FirstName] [nvarchar](50) NOT NULL,
    [LastName] [nvarchar](50) NOT NULL,
    [MiddleName] [nvarchar](50),
    [BillingAddressId] [int],
    [ShippingAddressId] [int],
    [CompanyAddressId] [int],
    [Email] [nvarchar](200) NOT NULL,
    [PhoneNumber] [nvarchar](200) NOT NULL,
    [PhoneExtension] [nvarchar](5),
    [CellNumber] [nvarchar](20),
    [FaxNumber] [nvarchar](20),
    [CompanyName] [nvarchar](50),
    [LoginUserId] [int],
    [CustomData] [nvarchar](1024),
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    [PrefferedShippingOptionId] [int],
    [PrefferedCurrencyId] [int],
    CONSTRAINT [PK_dbo.Customer] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_CustomerName] ON [dbo].[Customer]([Name])
CREATE INDEX [IX_BillingAddressId] ON [dbo].[Customer]([BillingAddressId])
CREATE INDEX [IX_ShippingAddressId] ON [dbo].[Customer]([ShippingAddressId])
CREATE INDEX [IX_CompanyAddressId] ON [dbo].[Customer]([CompanyAddressId])
CREATE INDEX [IX_LoginUserId] ON [dbo].[Customer]([LoginUserId])
CREATE INDEX [IX_CustomerTenant] ON [dbo].[Customer]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[Customer]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[Customer]([OwnerPermissions])
CREATE TABLE [dbo].[CustomerPayment] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80) NOT NULL,
    [ShortDescription] [nvarchar](256),
    [Description] [nvarchar](max),
    [CustomerId] [int],
    [PaymentOptionId] [int] NOT NULL,
    [AccountReferenceId] [nvarchar](512),
    [LastUsed] [datetime],
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CustomerPayment] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_CustomerPaymentName] ON [dbo].[CustomerPayment]([Name])
CREATE INDEX [IX_CustomerId] ON [dbo].[CustomerPayment]([CustomerId])
CREATE INDEX [IX_PaymentOptionId] ON [dbo].[CustomerPayment]([PaymentOptionId])
CREATE INDEX [IX_CustomerPaymentTenant] ON [dbo].[CustomerPayment]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[CustomerPayment]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[CustomerPayment]([OwnerPermissions])
CREATE TABLE [dbo].[PaymentOption] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80) NOT NULL,
    [ShortDescription] [nvarchar](256),
    [Description] [nvarchar](1024),
    [Enabled] [bit] NOT NULL,
    [AsssemblyName] [nvarchar](256),
    [ClassName] [nvarchar](256),
    [PaymentContainerCss] [nvarchar](40),
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.PaymentOption] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_PaymentOptionName] ON [dbo].[PaymentOption]([Name])
CREATE INDEX [IX_Tenant] ON [dbo].[PaymentOption]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[PaymentOption]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[PaymentOption]([OwnerPermissions])
CREATE TABLE [dbo].[ShippingOption] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80) NOT NULL,
    [ShortDescription] [nvarchar](256),
    [Description] [nvarchar](1024),
    [Enabled] [bit] NOT NULL,
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    [ShippingCarrierId] [int] NOT NULL,
    [TeaserImage] [nvarchar](256),
    [OptionCode] [nvarchar](40) NOT NULL,
    CONSTRAINT [PK_dbo.ShippingOption] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_ShippingOptionName] ON [dbo].[ShippingOption]([Name])
CREATE INDEX [IX_Tenant] ON [dbo].[ShippingOption]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[ShippingOption]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[ShippingOption]([OwnerPermissions])
CREATE INDEX [IX_ShippingCarrierId] ON [dbo].[ShippingOption]([ShippingCarrierId])
CREATE TABLE [dbo].[ShippingCarrier] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80) NOT NULL,
    [ShortDescription] [nvarchar](256),
    [Description] [nvarchar](1024),
    [Enabled] [bit] NOT NULL,
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    [ShippingProviderAssembly] [nvarchar](1024),
    [ShippingProviderClass] [nvarchar](80),
    [TeaserImage] [nvarchar](256),
    [OptionCode] [nvarchar](40),
    CONSTRAINT [PK_dbo.ShippingCarrier] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_ShippingCarrierName] ON [dbo].[ShippingCarrier]([Name])
CREATE INDEX [IX_Tenant] ON [dbo].[ShippingCarrier]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[ShippingCarrier]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[ShippingCarrier]([OwnerPermissions])
CREATE TABLE [dbo].[DiscountCoupon] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80) NOT NULL,
    [ShortDescription] [nvarchar](256),
    [Description] [nvarchar](1024),
    [Enabled] [bit] NOT NULL,
    [IsPercent] [bit] NOT NULL,
    [Amount] [real] NOT NULL,
    [Code] [nvarchar](200),
    [ExtraCodesText] [nvarchar](max),
    [CustomData] [nvarchar](max),
    [DiscountType] [int] NOT NULL,
    [ValidFrom] [datetime] NOT NULL,
    [ValidTo] [datetime] NOT NULL,
    [Priority] [int] NOT NULL,
    [AllowLowerPriority] [bit] NOT NULL,
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.DiscountCoupon] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_DiscountCouponName] ON [dbo].[DiscountCoupon]([Name])
CREATE INDEX [IX_Tenant] ON [dbo].[DiscountCoupon]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[DiscountCoupon]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[DiscountCoupon]([OwnerPermissions])
CREATE TABLE [dbo].[Product] (
    [Id] [int] NOT NULL IDENTITY,
    [SKU] [nvarchar](50) NOT NULL,
    [Name] [nvarchar](80) NOT NULL,
    [ShortDescription] [nvarchar](256) NOT NULL,
    [Description] [nvarchar](max),
    [Price] [real] NOT NULL,
    [ListPrice] [real] NOT NULL,
    [MsrpPrice] [real] NOT NULL,
    [MinPrice] [real] NOT NULL,
    [MaxPrice] [real] NOT NULL,
    [Enabled] [bit] NOT NULL,
    [PublishFrom] [datetime] NOT NULL,
    [PublishTo] [datetime] NOT NULL,
    [InStoreFrom] [datetime] NOT NULL,
    [PublicStatus] [nvarchar](50),
    [InternalStatus] [nvarchar](50),
    [ImagePath] [nvarchar](512),
    [UID] [uniqueidentifier] NOT NULL,
    [Weight] [real] NOT NULL,
    [Width] [real] NOT NULL,
    [Depth] [real] NOT NULL,
    [Height] [real] NOT NULL,
    [WeightMeasure] [nvarchar](50),
    [SizeMeasure] [nvarchar](50),
    [AvailableItems] [int] NOT NULL,
    [CustomData] [nvarchar](2048),
    [NeedsShipping] [bit] NOT NULL,
    [MaxDownloads] [int] NOT NULL,
    [ProductType] [nvarchar](50),
    [ParentProductId] [int],
    [ReorderAt] [datetime] NOT NULL,
    [TrackInventory] [bit] NOT NULL,
    [AllowToRenew] [bit] NOT NULL,
    [IsTrial] [bit] NOT NULL,
    [IsFeatured] [bit] NOT NULL,
    [SupplierId] [int],
    [ManufacturerId] [int],
    [ProductCategoryId] [int],
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Product] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_ProductName] ON [dbo].[Product]([Name])
CREATE INDEX [IX_ParentProductId] ON [dbo].[Product]([ParentProductId])
CREATE INDEX [IX_SupplierId] ON [dbo].[Product]([SupplierId])
CREATE INDEX [IX_ManufacturerId] ON [dbo].[Product]([ManufacturerId])
CREATE INDEX [IX_ProductCategoryId] ON [dbo].[Product]([ProductCategoryId])
CREATE INDEX [IX_Tenant] ON [dbo].[Product]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[Product]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[Product]([OwnerPermissions])
CREATE TABLE [dbo].[Manufacturer] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80) NOT NULL,
    [ShortDescription] [nvarchar](256),
    [Description] [nvarchar](1024),
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Manufacturer] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_ManufacturerName] ON [dbo].[Manufacturer]([Name])
CREATE INDEX [IX_Tenant] ON [dbo].[Manufacturer]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[Manufacturer]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[Manufacturer]([OwnerPermissions])
CREATE TABLE [dbo].[ProductOption] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80) NOT NULL,
    [ShortDescription] [nvarchar](256) NOT NULL,
    [Description] [nvarchar](1024),
    [Type] [int] NOT NULL,
    [UserControl] [int] NOT NULL,
    [Enabled] [bit] NOT NULL,
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ProductOption] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_ProductOptionName] ON [dbo].[ProductOption]([Name])
CREATE INDEX [IX_Tenant] ON [dbo].[ProductOption]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[ProductOption]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[ProductOption]([OwnerPermissions])
CREATE TABLE [dbo].[ProductOptionItem] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80) NOT NULL,
    [ShortDescription] [nvarchar](256) NOT NULL,
    [Description] [nvarchar](1024),
    [RelatedProductId] [int],
    [ProductOptionId] [int],
    [PriceAdded] [real] NOT NULL,
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ProductOptionItem] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_ProductOptionItemName] ON [dbo].[ProductOptionItem]([Name], [ProductOptionId])
CREATE INDEX [IX_RelatedProductId] ON [dbo].[ProductOptionItem]([RelatedProductId])
CREATE INDEX [IX_Tenant] ON [dbo].[ProductOptionItem]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[ProductOptionItem]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[ProductOptionItem]([OwnerPermissions])
CREATE TABLE [dbo].[ProductCategory] (
    [Id] [int] NOT NULL IDENTITY,
    [ParentCategoryId] [int],
    [Name] [nvarchar](80) NOT NULL,
    [ShortDescription] [nvarchar](256) NOT NULL,
    [Description] [nvarchar](1024),
    [Order] [int],
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ProductCategory] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_ParentCategoryId] ON [dbo].[ProductCategory]([ParentCategoryId])
CREATE UNIQUE INDEX [IX_ProductCategoryName] ON [dbo].[ProductCategory]([Name])
CREATE INDEX [IX_Tenant] ON [dbo].[ProductCategory]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[ProductCategory]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[ProductCategory]([OwnerPermissions])
CREATE TABLE [dbo].[RelatedProduct] (
    [ProductId] [int] NOT NULL,
    [SimilarProductId] [int] NOT NULL,
    [Id] [int] NOT NULL IDENTITY,
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.RelatedProduct] PRIMARY KEY ([ProductId], [SimilarProductId])
)
CREATE UNIQUE INDEX [IX_RelatedProduct] ON [dbo].[RelatedProduct]([ProductId], [SimilarProductId])
CREATE INDEX [IX_Tenant] ON [dbo].[RelatedProduct]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[RelatedProduct]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[RelatedProduct]([OwnerPermissions])
CREATE TABLE [dbo].[Supplier] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80) NOT NULL,
    [ShortDescription] [nvarchar](256),
    [Description] [nvarchar](1024),
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Supplier] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_SupplierName] ON [dbo].[Supplier]([Name])
CREATE INDEX [IX_Tenant] ON [dbo].[Supplier]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[Supplier]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[Supplier]([OwnerPermissions])
CREATE TABLE [dbo].[OrderItem] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80) NOT NULL,
    [ShortDescription] [nvarchar](256),
    [Description] [nvarchar](max),
    [ProductId] [int] NOT NULL,
    [DiscountCouponId] [int],
    [CustomerOrderId] [int],
    [Price] [real] NOT NULL,
    [Count] [int] NOT NULL,
    [Subtotal] [real] NOT NULL,
    [TotalTax] [real] NOT NULL,
    [TotalDiscounts] [real] NOT NULL,
    [CustomData] [nvarchar](1024),
    [OptionsData] [nvarchar](1024),
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.OrderItem] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_OrderItemName] ON [dbo].[OrderItem]([Name])
CREATE INDEX [IX_ProductId] ON [dbo].[OrderItem]([ProductId])
CREATE INDEX [IX_DiscountCouponId] ON [dbo].[OrderItem]([DiscountCouponId])
CREATE INDEX [IX_CustomerOrderId] ON [dbo].[OrderItem]([CustomerOrderId])
CREATE INDEX [IX_OrderItemTenant] ON [dbo].[OrderItem]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[OrderItem]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[OrderItem]([OwnerPermissions])
CREATE TABLE [dbo].[EventLog] (
    [Id] [int] NOT NULL IDENTITY,
    [EventType] [nvarchar](10),
    [EventTime] [datetime] NOT NULL,
    [EventSource] [nvarchar](100),
    [EventCode] [nvarchar](100),
    [IpAddress] [nvarchar](100),
    [Description] [nvarchar](max),
    [EventUrl] [nvarchar](2000),
    [EventMachineName] [nvarchar](100),
    [EventUserAgent] [nvarchar](max),
    [EventUrlReferrer] [nvarchar](2000),
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.EventLog] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_Tenant] ON [dbo].[EventLog]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[EventLog]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[EventLog]([OwnerPermissions])
CREATE TABLE [dbo].[Lookup] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80),
    [Description] [nvarchar](255),
    [LookupType] [int] NOT NULL,
    [IntRangeFrom] [int],
    [IntRangeTo] [int],
    [FloatRangeFrom] [real],
    [FloatRangeTo] [real],
    [FloatRangeStep] [real],
    [DateRangeFrom] [datetime],
    [DateRangeTo] [datetime],
    [RangePrefix] [nvarchar](10),
    [EntityName] [nvarchar](255),
    [EntityValueField] [nvarchar](80),
    [EntityNameField] [nvarchar](80),
    [EntityFilter] [nvarchar](1024),
    [EntityOrderBy] [nvarchar](512),
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [EntityAssembly] [nvarchar](512),
    [EntityClass] [nvarchar](512),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    [ParentLookup_Id] [int],
    CONSTRAINT [PK_dbo.Lookup] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_LookupName] ON [dbo].[Lookup]([Name])
CREATE INDEX [IX_Tenant] ON [dbo].[Lookup]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[Lookup]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[Lookup]([OwnerPermissions])
CREATE INDEX [IX_ParentLookup_Id] ON [dbo].[Lookup]([ParentLookup_Id])
CREATE TABLE [dbo].[LookupValue] (
    [Id] [int] NOT NULL IDENTITY,
    [Key] [nvarchar](50),
    [Text] [nvarchar](50),
    [Description] [nvarchar](255),
    [CultureCode] [nvarchar](10),
    [ParentKey] [nvarchar](50),
    [Order] [int] NOT NULL,
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    [Parent_Id] [int],
    CONSTRAINT [PK_dbo.LookupValue] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_LookupValue] ON [dbo].[LookupValue]([Key], [Text], [Description])
CREATE INDEX [IX_Tenant] ON [dbo].[LookupValue]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[LookupValue]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[LookupValue]([OwnerPermissions])
CREATE INDEX [IX_Parent_Id] ON [dbo].[LookupValue]([Parent_Id])
CREATE TABLE [dbo].[Message] (
    [Id] [int] NOT NULL IDENTITY,
    [FromAddress] [nvarchar](255),
    [ToAddress] [nvarchar](255),
    [CopyAddress] [nvarchar](255),
    [BlackCopyAddress] [nvarchar](255),
    [Subject] [nvarchar](80),
    [Body] [nvarchar](2000),
    [NewsLetterId] [int],
    [SubscriberId] [int],
    [Object] [nvarchar](255),
    [ObjectId] [int] NOT NULL,
    [Sent] [bit],
    [SentDate] [datetime],
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion NOT NULL,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Message] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_MessageUnique] ON [dbo].[Message]([FromAddress], [ToAddress], [Subject], [CreateDate])
CREATE INDEX [IX_NewsLetterId] ON [dbo].[Message]([NewsLetterId])
CREATE INDEX [IX_SubscriberId] ON [dbo].[Message]([SubscriberId])
CREATE INDEX [IX_Tenant] ON [dbo].[Message]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[Message]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[Message]([OwnerPermissions])
CREATE TABLE [dbo].[NewsLetter] (
    [Id] [int] NOT NULL IDENTITY,
    [Title] [nvarchar](50),
    [Subtitle] [nvarchar](80),
    [TextHtml] [nvarchar](2000),
    [ImagePath] [nvarchar](255),
    [PublishDate] [datetime] NOT NULL,
    [Published] [bit] NOT NULL,
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion NOT NULL,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.NewsLetter] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_NewsLetterName] ON [dbo].[NewsLetter]([Title], [Subtitle])
CREATE INDEX [IX_Tenant] ON [dbo].[NewsLetter]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[NewsLetter]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[NewsLetter]([OwnerPermissions])
CREATE TABLE [dbo].[Subscriber] (
    [Id] [int] NOT NULL IDENTITY,
    [PublicId] [uniqueidentifier] NOT NULL,
    [Email] [nvarchar](512),
    [Enabled] [bit] NOT NULL,
    [RegisterDate] [datetime] NOT NULL,
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion NOT NULL,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Subscriber] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_SubscriberEmail] ON [dbo].[Subscriber]([Email])
CREATE INDEX [IX_Tenant] ON [dbo].[Subscriber]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[Subscriber]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[Subscriber]([OwnerPermissions])
CREATE TABLE [dbo].[OrganizationService] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80),
    [ShortDescription] [nvarchar](256),
    [Description] [nvarchar](max),
    [ImageUrl] [nvarchar](512),
    [IconClass] [nvarchar](80),
    [Order] [int] NOT NULL,
    [Enabled] [bit] NOT NULL,
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.OrganizationService] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_OrganizationServiceName] ON [dbo].[OrganizationService]([Name])
CREATE INDEX [IX_OrganizationServiceTenant] ON [dbo].[OrganizationService]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[OrganizationService]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[OrganizationService]([OwnerPermissions])
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] [nvarchar](128) NOT NULL,
    [Name] [nvarchar](256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]([Name])
CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] [nvarchar](128) NOT NULL,
    [RoleId] [nvarchar](128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId])
)
CREATE INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]([UserId])
CREATE INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]([RoleId])
CREATE TABLE [dbo].[ShoppingCartProduct] (
    [Id] [int] NOT NULL IDENTITY,
    [Count] [int] NOT NULL,
    [Price] [real] NOT NULL,
    [Subtotal] [real] NOT NULL,
    [TotalDiscount] [real] NOT NULL,
    [ProductId] [int] NOT NULL,
    [DiscountCouponId] [int],
    [Coupon] [nvarchar](200),
    [ShoppingCartId] [int],
    [CustomData] [nvarchar](1024),
    [OptionsData] [nvarchar](1024),
    [OptionsAddedPrice] [real] NOT NULL,
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ShoppingCartProduct] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_ProductId] ON [dbo].[ShoppingCartProduct]([ProductId])
CREATE INDEX [IX_DiscountCouponId] ON [dbo].[ShoppingCartProduct]([DiscountCouponId])
CREATE INDEX [IX_ShoppingCartId] ON [dbo].[ShoppingCartProduct]([ShoppingCartId])
CREATE INDEX [IX_Tenant] ON [dbo].[ShoppingCartProduct]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[ShoppingCartProduct]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[ShoppingCartProduct]([OwnerPermissions])
CREATE TABLE [dbo].[ShoppingCart] (
    [Id] [int] NOT NULL IDENTITY,
    [UserId] [int],
    [CurrencyId] [int] NOT NULL,
    [ShippingOptionId] [int],
    [PaymentOptionId] [int],
    [DiscountCouponId] [int],
    [BillingAddressId] [int],
    [ShippingAddressId] [int],
    [Coupon] [nvarchar](200),
    [Notes] [nvarchar](1024),
    [CustomData] [nvarchar](1024),
    [Subtotal] [real] NOT NULL,
    [Total] [real] NOT NULL,
    [ShippingCost] [real],
    [TotalDiscounts] [real],
    [TaxTotal] [real],
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    [ShippingAsBilling] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.ShoppingCart] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_UserId] ON [dbo].[ShoppingCart]([UserId])
CREATE INDEX [IX_CurrencyId] ON [dbo].[ShoppingCart]([CurrencyId])
CREATE INDEX [IX_ShippingOptionId] ON [dbo].[ShoppingCart]([ShippingOptionId])
CREATE INDEX [IX_PaymentOptionId] ON [dbo].[ShoppingCart]([PaymentOptionId])
CREATE INDEX [IX_DiscountCouponId] ON [dbo].[ShoppingCart]([DiscountCouponId])
CREATE INDEX [IX_BillingAddressId] ON [dbo].[ShoppingCart]([BillingAddressId])
CREATE INDEX [IX_ShippingAddressId] ON [dbo].[ShoppingCart]([ShippingAddressId])
CREATE INDEX [IX_Tenant] ON [dbo].[ShoppingCart]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[ShoppingCart]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[ShoppingCart]([OwnerPermissions])
CREATE TABLE [dbo].[Subscription] (
    [Id] [int] NOT NULL IDENTITY,
    [SubscriptionType] [nvarchar](20),
    [InitialTerm] [int] NOT NULL,
    [TermStart] [datetime] NOT NULL,
    [TermEnd] [datetime] NOT NULL,
    [ContractDate] [datetime] NOT NULL,
    [AutoRenew] [bit] NOT NULL,
    [RenewalTerm] [int] NOT NULL,
    [SubTotal] [decimal](18, 2),
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    [Organization_Id] [int],
    [User_Id] [int],
    CONSTRAINT [PK_dbo.Subscription] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_Tenant] ON [dbo].[Subscription]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[Subscription]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[Subscription]([OwnerPermissions])
CREATE INDEX [IX_Organization_Id] ON [dbo].[Subscription]([Organization_Id])
CREATE INDEX [IX_User_Id] ON [dbo].[Subscription]([User_Id])
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] [nvarchar](128) NOT NULL,
    [Email] [nvarchar](256),
    [EmailConfirmed] [bit] NOT NULL,
    [PasswordHash] [nvarchar](max),
    [SecurityStamp] [nvarchar](max),
    [PhoneNumber] [nvarchar](max),
    [PhoneNumberConfirmed] [bit] NOT NULL,
    [TwoFactorEnabled] [bit] NOT NULL,
    [LockoutEndDateUtc] [datetime],
    [LockoutEnabled] [bit] NOT NULL,
    [AccessFailedCount] [int] NOT NULL,
    [UserName] [nvarchar](256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [UserNameIndex] ON [dbo].[AspNetUsers]([UserName])
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] [int] NOT NULL IDENTITY,
    [UserId] [nvarchar](128) NOT NULL,
    [ClaimType] [nvarchar](max),
    [ClaimValue] [nvarchar](max),
    CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]([UserId])
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] [nvarchar](128) NOT NULL,
    [ProviderKey] [nvarchar](128) NOT NULL,
    [UserId] [nvarchar](128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey], [UserId])
)
CREATE INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]([UserId])
CREATE TABLE [dbo].[WorkflowActionAttribute] (
    [Id] [int] NOT NULL IDENTITY,
    [AtributeType] [int] NOT NULL,
    [Name] [nvarchar](80),
    [ShortDescription] [nvarchar](256),
    [Description] [nvarchar](1024),
    [DataSource] [nvarchar](1024),
    [DefaultValue] [nvarchar](max),
    [IsPublic] [bit] NOT NULL,
    [IsVisible] [bit] NOT NULL,
    [IsReadonly] [bit] NOT NULL,
    [WorkflowActionId] [int],
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.WorkflowActionAttribute] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_WorkflowActionAttributeName] ON [dbo].[WorkflowActionAttribute]([Name])
CREATE INDEX [IX_WorkflowActionId] ON [dbo].[WorkflowActionAttribute]([WorkflowActionId])
CREATE INDEX [IX_Tenant] ON [dbo].[WorkflowActionAttribute]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[WorkflowActionAttribute]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[WorkflowActionAttribute]([OwnerPermissions])
CREATE TABLE [dbo].[WorkflowAction] (
    [Id] [int] NOT NULL IDENTITY,
    [ActionType] [int] NOT NULL,
    [Name] [nvarchar](80),
    [ShortDescription] [nvarchar](256),
    [Description] [nvarchar](1024),
    [ActionAssembly] [nvarchar](1024),
    [ActionClass] [nvarchar](1024),
    [WorkflowId] [int],
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.WorkflowAction] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_WorkflowActionName] ON [dbo].[WorkflowAction]([Name])
CREATE INDEX [IX_WorkflowId] ON [dbo].[WorkflowAction]([WorkflowId])
CREATE INDEX [IX_Tenant] ON [dbo].[WorkflowAction]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[WorkflowAction]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[WorkflowAction]([OwnerPermissions])
CREATE TABLE [dbo].[WorkflowStageTransition] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80),
    [ShortDescription] [nvarchar](256),
    [Description] [nvarchar](1024),
    [MainImageUrl] [nvarchar](1024),
    [WorkflowId] [int],
    [FromStageId] [int],
    [ToStageId] [int],
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.WorkflowStageTransition] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_WorkflowTransitionName] ON [dbo].[WorkflowStageTransition]([Name])
CREATE INDEX [IX_WorkflowId] ON [dbo].[WorkflowStageTransition]([WorkflowId])
CREATE INDEX [IX_FromStageId] ON [dbo].[WorkflowStageTransition]([FromStageId])
CREATE INDEX [IX_ToStageId] ON [dbo].[WorkflowStageTransition]([ToStageId])
CREATE INDEX [IX_Tenant] ON [dbo].[WorkflowStageTransition]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[WorkflowStageTransition]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[WorkflowStageTransition]([OwnerPermissions])
CREATE TABLE [dbo].[WorkflowStage] (
    [Id] [int] NOT NULL IDENTITY,
    [StageType] [int] NOT NULL,
    [Name] [nvarchar](80),
    [ShortDescription] [nvarchar](256),
    [Description] [nvarchar](1024),
    [WorkflowId] [int],
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.WorkflowStage] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_WorkflowStageName] ON [dbo].[WorkflowStage]([Name])
CREATE INDEX [IX_WorkflowId] ON [dbo].[WorkflowStage]([WorkflowId])
CREATE INDEX [IX_Tenant] ON [dbo].[WorkflowStage]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[WorkflowStage]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[WorkflowStage]([OwnerPermissions])
CREATE TABLE [dbo].[WorkflowClass] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80),
    [ShortDescription] [nvarchar](256),
    [Description] [nvarchar](1024),
    [BapEntityAssembly] [nvarchar](1024),
    [BapEntityClass] [nvarchar](1024),
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    [AllowedRoles] [nvarchar](max),
    CONSTRAINT [PK_dbo.WorkflowClass] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_WorkflowClassName] ON [dbo].[WorkflowClass]([Name])
CREATE INDEX [IX_Tenant] ON [dbo].[WorkflowClass]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[WorkflowClass]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[WorkflowClass]([OwnerPermissions])
CREATE TABLE [dbo].[WorkflowObject] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](80),
    [ShortDescription] [nvarchar](256),
    [Description] [nvarchar](1024),
    [WorkflowId] [int],
    [BapEntityAssembly] [nvarchar](1024),
    [BapEntityClass] [nvarchar](1024),
    [BapEntityId] [int] NOT NULL,
    [WorkflowData] [nvarchar](max),
    [TenantUnit] [nvarchar](50),
    [TenantUnitId] [int],
    [CreateDate] [datetime],
    [CreatedBy] [nvarchar](128),
    [LastModifiedDate] [datetime],
    [LastModifiedBy] [nvarchar](128),
    [TimeStamp] rowversion,
    [CreatedByUserName] [nvarchar](max),
    [LastModifiedByUserName] [nvarchar](max),
    [OwnerGroup] [int] NOT NULL,
    [OwnerPermissions] [int] NOT NULL,
    CONSTRAINT [PK_dbo.WorkflowObject] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_WorkflowObjectName] ON [dbo].[WorkflowObject]([Name])
CREATE INDEX [IX_WorkflowId] ON [dbo].[WorkflowObject]([WorkflowId])
CREATE INDEX [IX_Tenant] ON [dbo].[WorkflowObject]([TenantUnit], [TenantUnitId])
CREATE INDEX [IX_OwnerGroup] ON [dbo].[WorkflowObject]([OwnerGroup])
CREATE INDEX [IX_OwnerPermissions] ON [dbo].[WorkflowObject]([OwnerPermissions])
CREATE TABLE [dbo].[ContentNodeViews] (
    [NodeId] [int] NOT NULL,
    [ViewId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ContentNodeViews] PRIMARY KEY ([NodeId], [ViewId])
)
CREATE INDEX [IX_NodeId] ON [dbo].[ContentNodeViews]([NodeId])
CREATE INDEX [IX_ViewId] ON [dbo].[ContentNodeViews]([ViewId])
CREATE TABLE [dbo].[ShippingPayment] (
    [ShippingOptionId] [int] NOT NULL,
    [PaymentOptionId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ShippingPayment] PRIMARY KEY ([ShippingOptionId], [PaymentOptionId])
)
CREATE INDEX [IX_ShippingOptionId] ON [dbo].[ShippingPayment]([ShippingOptionId])
CREATE INDEX [IX_PaymentOptionId] ON [dbo].[ShippingPayment]([PaymentOptionId])
CREATE TABLE [dbo].[ProductOptionProduct] (
    [ProductOptionId] [int] NOT NULL,
    [ProductId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ProductOptionProduct] PRIMARY KEY ([ProductOptionId], [ProductId])
)
CREATE INDEX [IX_ProductOptionId] ON [dbo].[ProductOptionProduct]([ProductOptionId])
CREATE INDEX [IX_ProductId] ON [dbo].[ProductOptionProduct]([ProductId])
CREATE TABLE [dbo].[DiscountProduct] (
    [DiscountCouponId] [int] NOT NULL,
    [ProductId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.DiscountProduct] PRIMARY KEY ([DiscountCouponId], [ProductId])
)
CREATE INDEX [IX_DiscountCouponId] ON [dbo].[DiscountProduct]([DiscountCouponId])
CREATE INDEX [IX_ProductId] ON [dbo].[DiscountProduct]([ProductId])
CREATE TABLE [dbo].[WorkflowTranstionActions] (
    [TransitionId] [int] NOT NULL,
    [ActionId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.WorkflowTranstionActions] PRIMARY KEY ([TransitionId], [ActionId])
)
CREATE INDEX [IX_TransitionId] ON [dbo].[WorkflowTranstionActions]([TransitionId])
CREATE INDEX [IX_ActionId] ON [dbo].[WorkflowTranstionActions]([ActionId])
ALTER TABLE [dbo].[AttachmentHistory] ADD CONSTRAINT [FK_dbo.AttachmentHistory_dbo.Attachment_Attachment_Id] FOREIGN KEY ([Attachment_Id]) REFERENCES [dbo].[Attachment] ([Id])
ALTER TABLE [dbo].[BlogAuthor] ADD CONSTRAINT [FK_dbo.BlogAuthor_dbo.OrganizationUser_OrganizationUserId] FOREIGN KEY ([OrganizationUserId]) REFERENCES [dbo].[OrganizationUser] ([Id])
ALTER TABLE [dbo].[Blog] ADD CONSTRAINT [FK_dbo.Blog_dbo.BlogAuthor_BlogAuthorId] FOREIGN KEY ([BlogAuthorId]) REFERENCES [dbo].[BlogAuthor] ([Id])
ALTER TABLE [dbo].[BlogComment] ADD CONSTRAINT [FK_dbo.BlogComment_dbo.Blog_BlogId] FOREIGN KEY ([BlogId]) REFERENCES [dbo].[Blog] ([Id])
ALTER TABLE [dbo].[BlogComment] ADD CONSTRAINT [FK_dbo.BlogComment_dbo.BlogPost_BlogPostId] FOREIGN KEY ([BlogPostId]) REFERENCES [dbo].[BlogPost] ([Id])
ALTER TABLE [dbo].[BlogPost] ADD CONSTRAINT [FK_dbo.BlogPost_dbo.Blog_BlogId] FOREIGN KEY ([BlogId]) REFERENCES [dbo].[Blog] ([Id])
ALTER TABLE [dbo].[OrganizationUser] ADD CONSTRAINT [FK_dbo.OrganizationUser_dbo.Organization_Organization_Id] FOREIGN KEY ([Organization_Id]) REFERENCES [dbo].[Organization] ([Id])
ALTER TABLE [dbo].[ContentControlParameter] ADD CONSTRAINT [FK_dbo.ContentControlParameter_dbo.ContentViewControl_ContentViewControlId] FOREIGN KEY ([ContentViewControlId]) REFERENCES [dbo].[ContentViewControl] ([Id])
ALTER TABLE [dbo].[ContentViewControl] ADD CONSTRAINT [FK_dbo.ContentViewControl_dbo.ContentNode_ContentNodeId] FOREIGN KEY ([ContentNodeId]) REFERENCES [dbo].[ContentNode] ([Id])
ALTER TABLE [dbo].[ContentViewControl] ADD CONSTRAINT [FK_dbo.ContentViewControl_dbo.ContentView_ContentViewId] FOREIGN KEY ([ContentViewId]) REFERENCES [dbo].[ContentView] ([Id])
ALTER TABLE [dbo].[ContentNode] ADD CONSTRAINT [FK_dbo.ContentNode_dbo.ContentNode_ParentNodeId] FOREIGN KEY ([ParentNodeId]) REFERENCES [dbo].[ContentNode] ([Id])
ALTER TABLE [dbo].[ContentLocalization] ADD CONSTRAINT [FK_dbo.ContentLocalization_dbo.ContentNode_ContentNodeId] FOREIGN KEY ([ContentNodeId]) REFERENCES [dbo].[ContentNode] ([Id])
ALTER TABLE [dbo].[ContentNodeRoute] ADD CONSTRAINT [FK_dbo.ContentNodeRoute_dbo.ContentNode_ContentNodeId] FOREIGN KEY ([ContentNodeId]) REFERENCES [dbo].[ContentNode] ([Id])
ALTER TABLE [dbo].[CustomerOrderPayment] ADD CONSTRAINT [FK_dbo.CustomerOrderPayment_dbo.Currency_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[Currency] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CustomerOrderPayment] ADD CONSTRAINT [FK_dbo.CustomerOrderPayment_dbo.CustomerOrder_CustomerOrderId] FOREIGN KEY ([CustomerOrderId]) REFERENCES [dbo].[CustomerOrder] ([Id])
ALTER TABLE [dbo].[CustomerOrderPayment] ADD CONSTRAINT [FK_dbo.CustomerOrderPayment_dbo.CustomerPayment_CustomerPaymentId] FOREIGN KEY ([CustomerPaymentId]) REFERENCES [dbo].[CustomerPayment] ([Id])
ALTER TABLE [dbo].[CustomerOrderPayment] ADD CONSTRAINT [FK_dbo.CustomerOrderPayment_dbo.PaymentOption_PaymentOptionId] FOREIGN KEY ([PaymentOptionId]) REFERENCES [dbo].[PaymentOption] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CustomerOrder] ADD CONSTRAINT [FK_dbo.CustomerOrder_dbo.Address_BillingAddressId] FOREIGN KEY ([BillingAddressId]) REFERENCES [dbo].[Address] ([Id])
ALTER TABLE [dbo].[CustomerOrder] ADD CONSTRAINT [FK_dbo.CustomerOrder_dbo.Currency_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[Currency] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CustomerOrder] ADD CONSTRAINT [FK_dbo.CustomerOrder_dbo.Customer_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id])
ALTER TABLE [dbo].[CustomerOrder] ADD CONSTRAINT [FK_dbo.CustomerOrder_dbo.CustomerPayment_CustomerPaymentId] FOREIGN KEY ([CustomerPaymentId]) REFERENCES [dbo].[CustomerPayment] ([Id])
ALTER TABLE [dbo].[CustomerOrder] ADD CONSTRAINT [FK_dbo.CustomerOrder_dbo.DiscountCoupon_DiscountCouponId] FOREIGN KEY ([DiscountCouponId]) REFERENCES [dbo].[DiscountCoupon] ([Id])
ALTER TABLE [dbo].[CustomerOrder] ADD CONSTRAINT [FK_dbo.CustomerOrder_dbo.PaymentOption_PaymentOptionId] FOREIGN KEY ([PaymentOptionId]) REFERENCES [dbo].[PaymentOption] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CustomerOrder] ADD CONSTRAINT [FK_dbo.CustomerOrder_dbo.Address_ShippingAddressId] FOREIGN KEY ([ShippingAddressId]) REFERENCES [dbo].[Address] ([Id])
ALTER TABLE [dbo].[CustomerOrder] ADD CONSTRAINT [FK_dbo.CustomerOrder_dbo.ShippingOption_ShippingOptionId] FOREIGN KEY ([ShippingOptionId]) REFERENCES [dbo].[ShippingOption] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CustomerOrder] ADD CONSTRAINT [FK_dbo.CustomerOrder_dbo.OrganizationUser_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[OrganizationUser] ([Id])
ALTER TABLE [dbo].[Customer] ADD CONSTRAINT [FK_dbo.Customer_dbo.Address_BillingAddressId] FOREIGN KEY ([BillingAddressId]) REFERENCES [dbo].[Address] ([Id])
ALTER TABLE [dbo].[Customer] ADD CONSTRAINT [FK_dbo.Customer_dbo.Address_CompanyAddressId] FOREIGN KEY ([CompanyAddressId]) REFERENCES [dbo].[Address] ([Id])
ALTER TABLE [dbo].[Customer] ADD CONSTRAINT [FK_dbo.Customer_dbo.OrganizationUser_LoginUserId] FOREIGN KEY ([LoginUserId]) REFERENCES [dbo].[OrganizationUser] ([Id])
ALTER TABLE [dbo].[Customer] ADD CONSTRAINT [FK_dbo.Customer_dbo.Address_ShippingAddressId] FOREIGN KEY ([ShippingAddressId]) REFERENCES [dbo].[Address] ([Id])
ALTER TABLE [dbo].[CustomerPayment] ADD CONSTRAINT [FK_dbo.CustomerPayment_dbo.Customer_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id])
ALTER TABLE [dbo].[CustomerPayment] ADD CONSTRAINT [FK_dbo.CustomerPayment_dbo.PaymentOption_PaymentOptionId] FOREIGN KEY ([PaymentOptionId]) REFERENCES [dbo].[PaymentOption] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ShippingOption] ADD CONSTRAINT [FK_dbo.ShippingOption_dbo.ShippingCarrier_ShippingCarrierId] FOREIGN KEY ([ShippingCarrierId]) REFERENCES [dbo].[ShippingCarrier] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Product] ADD CONSTRAINT [FK_dbo.Product_dbo.Manufacturer_ManufacturerId] FOREIGN KEY ([ManufacturerId]) REFERENCES [dbo].[Manufacturer] ([Id])
ALTER TABLE [dbo].[Product] ADD CONSTRAINT [FK_dbo.Product_dbo.Product_ParentProductId] FOREIGN KEY ([ParentProductId]) REFERENCES [dbo].[Product] ([Id])
ALTER TABLE [dbo].[Product] ADD CONSTRAINT [FK_dbo.Product_dbo.ProductCategory_ProductCategoryId] FOREIGN KEY ([ProductCategoryId]) REFERENCES [dbo].[ProductCategory] ([Id])
ALTER TABLE [dbo].[Product] ADD CONSTRAINT [FK_dbo.Product_dbo.Supplier_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Supplier] ([Id])
ALTER TABLE [dbo].[ProductOptionItem] ADD CONSTRAINT [FK_dbo.ProductOptionItem_dbo.ProductOption_ProductOptionId] FOREIGN KEY ([ProductOptionId]) REFERENCES [dbo].[ProductOption] ([Id])
ALTER TABLE [dbo].[ProductOptionItem] ADD CONSTRAINT [FK_dbo.ProductOptionItem_dbo.Product_RelatedProductId] FOREIGN KEY ([RelatedProductId]) REFERENCES [dbo].[Product] ([Id])
ALTER TABLE [dbo].[ProductCategory] ADD CONSTRAINT [FK_dbo.ProductCategory_dbo.ProductCategory_ParentCategoryId] FOREIGN KEY ([ParentCategoryId]) REFERENCES [dbo].[ProductCategory] ([Id])
ALTER TABLE [dbo].[RelatedProduct] ADD CONSTRAINT [FK_dbo.RelatedProduct_dbo.Product_SimilarProductId] FOREIGN KEY ([SimilarProductId]) REFERENCES [dbo].[Product] ([Id])
ALTER TABLE [dbo].[RelatedProduct] ADD CONSTRAINT [FK_dbo.RelatedProduct_dbo.Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
ALTER TABLE [dbo].[OrderItem] ADD CONSTRAINT [FK_dbo.OrderItem_dbo.CustomerOrder_CustomerOrderId] FOREIGN KEY ([CustomerOrderId]) REFERENCES [dbo].[CustomerOrder] ([Id])
ALTER TABLE [dbo].[OrderItem] ADD CONSTRAINT [FK_dbo.OrderItem_dbo.DiscountCoupon_DiscountCouponId] FOREIGN KEY ([DiscountCouponId]) REFERENCES [dbo].[DiscountCoupon] ([Id])
ALTER TABLE [dbo].[OrderItem] ADD CONSTRAINT [FK_dbo.OrderItem_dbo.Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Lookup] ADD CONSTRAINT [FK_dbo.Lookup_dbo.Lookup_ParentLookup_Id] FOREIGN KEY ([ParentLookup_Id]) REFERENCES [dbo].[Lookup] ([Id])
ALTER TABLE [dbo].[LookupValue] ADD CONSTRAINT [FK_dbo.LookupValue_dbo.Lookup_Parent_Id] FOREIGN KEY ([Parent_Id]) REFERENCES [dbo].[Lookup] ([Id])
ALTER TABLE [dbo].[Message] ADD CONSTRAINT [FK_dbo.Message_dbo.NewsLetter_NewsLetterId] FOREIGN KEY ([NewsLetterId]) REFERENCES [dbo].[NewsLetter] ([Id])
ALTER TABLE [dbo].[Message] ADD CONSTRAINT [FK_dbo.Message_dbo.Subscriber_SubscriberId] FOREIGN KEY ([SubscriberId]) REFERENCES [dbo].[Subscriber] ([Id])
ALTER TABLE [dbo].[AspNetUserRoles] ADD CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AspNetUserRoles] ADD CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ShoppingCartProduct] ADD CONSTRAINT [FK_dbo.ShoppingCartProduct_dbo.DiscountCoupon_DiscountCouponId] FOREIGN KEY ([DiscountCouponId]) REFERENCES [dbo].[DiscountCoupon] ([Id])
ALTER TABLE [dbo].[ShoppingCartProduct] ADD CONSTRAINT [FK_dbo.ShoppingCartProduct_dbo.Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ShoppingCartProduct] ADD CONSTRAINT [FK_dbo.ShoppingCartProduct_dbo.ShoppingCart_ShoppingCartId] FOREIGN KEY ([ShoppingCartId]) REFERENCES [dbo].[ShoppingCart] ([Id])
ALTER TABLE [dbo].[ShoppingCart] ADD CONSTRAINT [FK_dbo.ShoppingCart_dbo.Address_BillingAddressId] FOREIGN KEY ([BillingAddressId]) REFERENCES [dbo].[Address] ([Id])
ALTER TABLE [dbo].[ShoppingCart] ADD CONSTRAINT [FK_dbo.ShoppingCart_dbo.Currency_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[Currency] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ShoppingCart] ADD CONSTRAINT [FK_dbo.ShoppingCart_dbo.DiscountCoupon_DiscountCouponId] FOREIGN KEY ([DiscountCouponId]) REFERENCES [dbo].[DiscountCoupon] ([Id])
ALTER TABLE [dbo].[ShoppingCart] ADD CONSTRAINT [FK_dbo.ShoppingCart_dbo.PaymentOption_PaymentOptionId] FOREIGN KEY ([PaymentOptionId]) REFERENCES [dbo].[PaymentOption] ([Id])
ALTER TABLE [dbo].[ShoppingCart] ADD CONSTRAINT [FK_dbo.ShoppingCart_dbo.Address_ShippingAddressId] FOREIGN KEY ([ShippingAddressId]) REFERENCES [dbo].[Address] ([Id])
ALTER TABLE [dbo].[ShoppingCart] ADD CONSTRAINT [FK_dbo.ShoppingCart_dbo.ShippingOption_ShippingOptionId] FOREIGN KEY ([ShippingOptionId]) REFERENCES [dbo].[ShippingOption] ([Id])
ALTER TABLE [dbo].[ShoppingCart] ADD CONSTRAINT [FK_dbo.ShoppingCart_dbo.OrganizationUser_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[OrganizationUser] ([Id])
ALTER TABLE [dbo].[Subscription] ADD CONSTRAINT [FK_dbo.Subscription_dbo.Organization_Organization_Id] FOREIGN KEY ([Organization_Id]) REFERENCES [dbo].[Organization] ([Id])
ALTER TABLE [dbo].[Subscription] ADD CONSTRAINT [FK_dbo.Subscription_dbo.OrganizationUser_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[OrganizationUser] ([Id])
ALTER TABLE [dbo].[AspNetUserClaims] ADD CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AspNetUserLogins] ADD CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[WorkflowActionAttribute] ADD CONSTRAINT [FK_dbo.WorkflowActionAttribute_dbo.WorkflowAction_WorkflowActionId] FOREIGN KEY ([WorkflowActionId]) REFERENCES [dbo].[WorkflowAction] ([Id])
ALTER TABLE [dbo].[WorkflowAction] ADD CONSTRAINT [FK_dbo.WorkflowAction_dbo.WorkflowClass_WorkflowId] FOREIGN KEY ([WorkflowId]) REFERENCES [dbo].[WorkflowClass] ([Id])
ALTER TABLE [dbo].[WorkflowStageTransition] ADD CONSTRAINT [FK_dbo.WorkflowStageTransition_dbo.WorkflowClass_WorkflowId] FOREIGN KEY ([WorkflowId]) REFERENCES [dbo].[WorkflowClass] ([Id])
ALTER TABLE [dbo].[WorkflowStageTransition] ADD CONSTRAINT [FK_dbo.WorkflowStageTransition_dbo.WorkflowStage_FromStageId] FOREIGN KEY ([FromStageId]) REFERENCES [dbo].[WorkflowStage] ([Id])
ALTER TABLE [dbo].[WorkflowStageTransition] ADD CONSTRAINT [FK_dbo.WorkflowStageTransition_dbo.WorkflowStage_ToStageId] FOREIGN KEY ([ToStageId]) REFERENCES [dbo].[WorkflowStage] ([Id])
ALTER TABLE [dbo].[WorkflowStage] ADD CONSTRAINT [FK_dbo.WorkflowStage_dbo.WorkflowClass_WorkflowId] FOREIGN KEY ([WorkflowId]) REFERENCES [dbo].[WorkflowClass] ([Id])
ALTER TABLE [dbo].[WorkflowObject] ADD CONSTRAINT [FK_dbo.WorkflowObject_dbo.WorkflowClass_WorkflowId] FOREIGN KEY ([WorkflowId]) REFERENCES [dbo].[WorkflowClass] ([Id])
ALTER TABLE [dbo].[ContentNodeViews] ADD CONSTRAINT [FK_dbo.ContentNodeViews_dbo.ContentNode_NodeId] FOREIGN KEY ([NodeId]) REFERENCES [dbo].[ContentNode] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ContentNodeViews] ADD CONSTRAINT [FK_dbo.ContentNodeViews_dbo.ContentView_ViewId] FOREIGN KEY ([ViewId]) REFERENCES [dbo].[ContentView] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ShippingPayment] ADD CONSTRAINT [FK_dbo.ShippingPayment_dbo.ShippingOption_ShippingOptionId] FOREIGN KEY ([ShippingOptionId]) REFERENCES [dbo].[ShippingOption] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ShippingPayment] ADD CONSTRAINT [FK_dbo.ShippingPayment_dbo.PaymentOption_PaymentOptionId] FOREIGN KEY ([PaymentOptionId]) REFERENCES [dbo].[PaymentOption] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ProductOptionProduct] ADD CONSTRAINT [FK_dbo.ProductOptionProduct_dbo.ProductOption_ProductOptionId] FOREIGN KEY ([ProductOptionId]) REFERENCES [dbo].[ProductOption] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ProductOptionProduct] ADD CONSTRAINT [FK_dbo.ProductOptionProduct_dbo.Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[DiscountProduct] ADD CONSTRAINT [FK_dbo.DiscountProduct_dbo.DiscountCoupon_DiscountCouponId] FOREIGN KEY ([DiscountCouponId]) REFERENCES [dbo].[DiscountCoupon] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[DiscountProduct] ADD CONSTRAINT [FK_dbo.DiscountProduct_dbo.Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[WorkflowTranstionActions] ADD CONSTRAINT [FK_dbo.WorkflowTranstionActions_dbo.WorkflowStageTransition_TransitionId] FOREIGN KEY ([TransitionId]) REFERENCES [dbo].[WorkflowStageTransition] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[WorkflowTranstionActions] ADD CONSTRAINT [FK_dbo.WorkflowTranstionActions_dbo.WorkflowAction_ActionId] FOREIGN KEY ([ActionId]) REFERENCES [dbo].[WorkflowAction] ([Id]) ON DELETE CASCADE
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201905242100386_InitialCreate', N'BAP.DB.eCommerce.Migrations.Configuration',  0x1F8B0800000000000400EDBDEB721C39B226F87FCDF61D64FAB53BD6239554553D7DCA543346526289A749892BB25467CE9FB46024988C5664447644A448F6DA3CD9FED847DA575820AEB8DFE39259B036AB160380C3E1F0847F70381CFFDFFFF3FFBEFB1F4FDBF4C5775094499EFDFAF2CDAB1F5EBE00599CAF936CF3EBCB7D75FF5FFFF6F27FFCF7FFFD7F7BF761BD7D7AF1B5ABF723AA075B66E5AF2F1FAA6AF7CBEBD765FC00B651F96A9BC4455EE6F7D5AB38DFBE8ED6F9EBB73FFCF06FAFDFBC790D20899790D68B17EFBEECB32AD982FA0FF8E7599EC56057EDA3F42A5F83B46CBFC3929B9AEA8B4FD11694BB2806BFBE3C3DB97EF5FEF41538CBB75B50C4E0E58B933489201F3720BD7FF922CAB2BC8A2AC8E52FBF97E0A62AF26C73B3831FA2F4F6790760BDFB282D41CBFD2F4375DD81FCF0160DE4F5D0B02315EFCB2ADF1A127CF3632B99D774732BF9BEEC250765F701CAB87A46A3AEE5F7EBCB93F5BA0065F9F205DDD72F676981EA35D2ED45FBEAFDC9E5AB9A4A02CA576DEBBFBC60EAFCA5570CA83FE87F7F7971B64FAB7D017ECDC0BE2AA2F42F2FAEF7776912FF1D3CDFE6DF40F66BB64F539C59C82E2C233EC04FD745BE0345F5FC05DCB743B858BF7CF19A6CF79A6ED837C3DA34A3BBC8AA1FDFBE7CF109761EDDA5A0D7054C1237555E80DF40068AA802EBEBA8AA4091211AA09626D33BD517FA6FD71B543EF82B7AF9E22A7ABA04D9A67AF8F5E5DFE0CFE63C7902EBEE43CBC0EF59027F73B04D55EC01874179A7702E7651F6ACE8FBEDCF7FD5EA5CDED77B50C645B26B3454D8D79B1FDEFEE4A1B3F3A4282BC5B07E1E45A457C97A9D023F5DCB7BBA8C661A62FB7BBE4C32F0667295C53A7FEBDEB9E2E751FF6E27FF4D4213E7A15B792F3770D59A63BD81632BA697E97F263BD9AF648C2EAF1FF20C7CDA6FEF40215B5A47196EDDF787A70A64A57CB5D51BB962A98D9E7C0D53A13C204D27EA29CFAA28AE3E6CA32495DAC55134E716645156411AD5D81664E889413A0A0115002E1FEFB12504FDFB36D9AA455BB75C9FCAD680376FFFE6C93CC24D41729F80B50DA778FB09D8452CC14579DB2F54A74916A1A5125F1CF9FDA84128C2797BF8417B76E00EA850600BF84FAD61FBE38E9C9145B2F8F911B6FCADC8F73BD5CE4183CE3528B6498996F0D284DABBD7C3FE4DBEABABE02AF7B085FB938F09DCD6216593EFEFC85D1DDDBAD9DF855DDDA12D9461E55172779E28B774BA4CA93B82DC3D8CDE51D316FB21FCF5A723C0250766F38341D3A5F629FA9E6CEA01D1EE80DE0ABD7CF105A47595F221D9355E5DCC48AD7A1B775EE4DB2F794A34EE4A57B751B10148C17361959B7C5F7B8F1D6DAEA5B10D56D6D877AABB4F5B90FF72986FD4D3E863FB7CF70F10CB96759FDDA83543E1DD80F6F1F7C2C7C65CED22DB97926EBC39E2F625DF58990A06FDDACB07D0CBF734876B589469B643EBA2A9C16C9BDEE6A60DAF609D49541B694B7DCE076453E907549DA4D52D781AFF77749B542998A427B8CA3FE6C55A263A4F435A3EB83C84BDDC8101E0B0F53C06A797C55E72E9DB8A7EB3E0634FD16D18247B8A6EDB61B5A7384DF3CDC9BE7AC80BA33DC5D02CEC29387B8A24FEE62726C33D52C14B471AE1025EFA519F9AF98826F903DCDD24D2136C3FFD7C2E365196FCAB5629B4F81A6286006B02AC09B04639238B6471E91805D9EF928B5050C90A4705033CA18A187F275DCE7376CA98A2D74B217F2D7DB63EC9ABA01A83A964759DC19531AC0A806AAC005785330DCE7FA5E7A83DC0A0D6AB28C92EB6D106C8BD9F9E7A1B7E51A69827DAC8FD453E041F805500560158296764912C1E02B0EA90931BBAE2A1141EFA32E1ACBE3F935562E4D7565835C885640E2FE3623FA28229F8438DAEF352C21B2AE532D61770B91A4A9D0EDFB1011A43BAB65D407682E3A8B1A15DF7631BB717C5A1DACF6FDE7A42568658A2FB1104F753404901250594B41094E48E417808890B524C31881A820C404A0045BA0A7248D2D77286260DDB86B804350AA064265032B9BF4915F4F3C34F3E0CC8F48EA6806B02AE09B826E09AA5E31A0DFF050FD1B0DE0DAF1E1F0B4823E592013E5690863DDA33803674E30071382E9172F709546454CA68B1CDE3DA334F97DAA6B2677ED85D843DF398294715F17F78897114BF3FAF7970B4FB3A90B4378A3E0E29CB8DC6507C24B59177E323878DE2AA8CCF94350A994D96CBE500B68A0B41C461A3E397C54532750E95607EA6B4C207B9DB1DBCC20A4998D8EBB0A58CEF9653C5C9714B726CB9C309BB9B79E205755DB75E6E38464FD26D9AC7DBC4D3F4E2E5CEF20198E7B0F33DCE9D6F0038AE9E5CCC8221B6DCF066D84D87DD74D84DDB777574F95E97B92DBECC37F9541968CEA318DCE5F9B729FABA7D4CD0F23F455770D9FD06D64936455FBFE5F92605BB745F4ED1DB147D784E4EAC58F2F7BB5D5E4CD4D9C576970274F008D6EDA6B79C24C9CDC75C795EE0B7A3361FD134C13CA7D1EE3DB88FA040919F649A991CFA9C565BB7D54E0329FBEDEC3A2A4B942369920E275355D4D935FCE5BB19CB564637653FF77D4A32434A05388B7655FC10A1AC0F7F07327CE847004387202E40354597BF81EA144445018ADAB3F77E8FFA817823C95CA5872E4F9C412091A8CE5FFD0C64E8EEC3D32E299A0D6232746CA74C7F80BB935DD2783FCFD204DA09A93FCDD34A0627A49D0FFF633949D3FCF1222B410C6DDDC7AADAB9CE73239CF33C5D439EA7309DA7D08E8DD99DF0A0A075FDFB3821A043A1248708562704C804426545FF57E4E97554C0AF956138948046383798E7DC60A179063C457A35BAF635018FADBE193ACC7BF5544CC54F5E8E70A22AC29D8F63F6D3AF1442FF8A97FB812D74FE1AA57B59679EC2EF2FCA2FE09FFBA4E0A48D35B43E8852B4FE9CA5CFEE94BE266572375CE0B036886914838FB5811ADD7119A97E9E5EF4F03C2FB6EDCF72FCD3D15A0F3F14455E5C81B28C3672E8E863A13B2BCBB3342A473FC2FCD39F3B861B24E1DC513D238B6471210703C2BD090BA0B81B1501A65FF19A0F1B18FD56CCC6C6A0A98F0D0F3100F3BD0ED63C6C73961C1EE575D7F1093630B59383BE58B484EAA5D83E783AD6A676522377A4BAFEEC058B7A83E9FE760EF57943027F54B7D166F420F6AEAF33295EF522EAA1AF46DBC7DF17B61D9D827BB84E4DD6DDC97D25DDAA79EAEDDFA3EFD14DBDB68DBEB0DD54CF2950CF9AA7C0BAB0AD09DB9AB0AD09DB9AF1B63508A1C9F633F8368268C2EC61043545FB165175D32BF51839C371344D74C6813E198CA3AEEE63CFD548DA7CB385DA855DD658BB2CD3A889633E5DAA639F261769DDABE2615D6D6869BCB9F9980F5A64BBB1814AF178915D816CEF87128AA3D946CE1107EDFA31A5B6B65D6A3D4DE7B13F6502525FD0F339DF57BE5455B5BA75269270812023481719AAC517D834DBB8E198D6E68CBD8B3F81B87522A74C3AFE29E449ACF80D7AECA5F6208FFFFB6B50D7B803FA027F738A6C777E0683FE7BB38B62E96BA47EBAFA90A11F9BF3A97E17C83BFE992C94FF542FB5B66BFA244922BBBEA20DB1B91BBFBBF155AC0511D7459217F83537644198325398D2B43F7B88B20D382FC03FF7208BB95D30550C7B42A04A1DBDE1699D4927F8E5D771A5670F49BA2E8073EC702D1DB8D78B3CF8F911AD8B78028C0897923EF1C3A87E7934A20F4F704F7C52C11EEEA015914DAF9FF83014297C05201A951D26BDF135BA1BB819FD5C600154B6AFB61776C77BC1A51D5CDA20B8B4834B7B0C9736B291684DE25F25C0BDCC7855C6034CD510797EE96AA69EEB610DF5CB2E9D2349312A5D76D1C64D2DD8B6169FC9BA502ACEA686AF7825DB40A5E03B3FFE082534CF538C09F5338DFF6F4A5F6377EA354514846A97E5659A2E4AB81C5749E47CB5F5A2BC7988BC5CBF40EF36B852F1E435BA281BE572A513D07F40FF01FD2B6764912C2E1EFD0F30D20B4C95C16812C8BAC0D4CB3C8E529B84A39CF601B6CE035B5BD99ED53BB9F183946D1D6FD21BFD7EA0DA45D99E2F05A0108042000A01282C1C28C870026E5915A1AFA2AA225797B0BEAFA0D13A00C23672B46E1CB0C4F1BBC0ECC144AD229340AB630BB59A203CADCEA1827E88E38726D47AD05F3D96F5E72DC65123E0CA535F933C973A4D084980D3014E0738AD9C9145B2782470BA47960A2CCDAD273B33662BBBA1E87D5134718726E8B96D14503367157A2800B804A895C243A69753D250ED15BF674DA3671C65EDF32522D333BFA7B80EA1FD825B2810275B74B8795DC07FD58AF9F20D5CFB6FE04614162BADF3CDF3F64E9AA26C9491F83903BD283D9D82C295265BDFE66ECB30CAF816559D04C7F51607D817605F807DCA1959248B4B807D06A009412550D491E5D7D1F3B68E0B92032850BF4B0F511D0DA558520DAC221A0480359825700F10FA04D274547E2E2B10B3639C48B89ECCCF352C520B488F9196A81D2BD4FB8A68B74295985E4C8753B7DDC15D88DBE060EF4535E015EBE718CF932C291F3C10EAA44C06FC61F2EA4A8C67B1D937B96AC32DFC290DE814AA7E6A0336EBD4B8CE1177888862A3E3E5AE52DD91DE46C3CF6FBF9DEA4FB9FC5654F05806E81AA06B80AE0BF658F62E3E9EBB92833F57430BCC5F29ABC83A2CA5B58D935EE1D44C864134538E05FBA83B20BC89EDA8FA0D84E9B8FA869A23EBFE361A5BF7B7F9752F0CFEEA8F8D6AA61819515B6F5C641347DF39A15FEEFBBFB0F11B3F1E25A4336357205324E8B4194536DCB8433FFBA61BB8F8ECA028FDECC9BD6EF0DF27658C1E8F3E833082434DDEF834495338ACF661705F52F244AE1991D4F7EF635FA3DAA7F9CAF45CEB3E8A391ABFAF9BFD5DE561A7EFC35BD0A967E98358A760677959B98E2D7AF2C151D87E87ED77D87E2B6764912C2E7DFB4D1A67F54E68453710EC81A87AF2DD0F5DD97CAFAAEB43503B0F34BD06EEEE022D66BBAA62669BBF94CCB6D546F702686FFFCDF6FDCE1B7E12C16A8C836E201A06594F310AAAB2E9202E2AB015BDCC8B8E0061B1D8AD24A8C25CAD15D5334D5163E862D1F4AD98385534BC29B201503B0D8D21302D4483A02A2A8641D7B61D88F654D00D54C3D09A0CAAB2E9209075D760BDA9266218952AD8ACAB7871BC39FADC82BB2DB8DBA674B79D274559CD12A08B60FC2C1D5F25EB75AABA3AE76563ADF081B9B9BC541EAEED2ECA9EED1A7FD846893473B7A677CCD479F99067E0D37E7B27BD6A3866E71F9E2A90958A480E1F1E3B90A61A03F5F1FB8E9EA6E9A855B8297E5697F926C9AC5CF6D3F94983F72E78EF82F74E39238B647121DE3BDA4015E01E4519AF1527869A5484E79723F81035DC87BA9E4367A721818BE45CD375395C9355C45C53F51C1D7272BEE968191EE3741D36D59AA8A2A943A837D6725963D53862EE4BC5121EAA8CE9F1D171F668FB79B45C3CC60E083F773FC2B58FE08E389CE81FAF612F2771EDAD9FF24E0F024570EDE2DC1209BB8CB0CB08BB8CB0CB50D01925445FE3C4DA0A6B8AF0901094FA3F7CD40EED368BEA1E21A09BE2D00AD4113402A40B904EAF2F4FAE504FA93F4ECAB204DBBB54E562F6F446711A95E5243DB53F4E943D294AA0DACADF05F5726F35C0C6001B036C54CEC822595C3A6C24BDD37C6F1A151454BFAE8A4481A114C2B3A6539FF1606A35727A3F820E98B2C266249100CE02383B447016104540140151286764912C2E0451882EE4454591700E048C17A808050C6DA3CDF83BBAC694FB4940648DC304A06A2A34467BC88C209C29D66C75443ABAB6CE8AC1A7ECC0045585085354DF0BB8ECC7E6842E5B2A015E067819E0658097015E067819E025328CF0F3F7640D8A93F67061FC2591EEB93E6970373BC7097FC7F03A7A40822274AB428E564890BE936C050449220107061C788838F0A2BC46FA3A2440B63E4CDEA21F433F6EBB0C3DCAD786BDE4187E82BF3DD45339C9F3C15A77A4FC74D52D49A89BBE33B45093058693F2354A93355AC959706B4369786BC43E737791E445BDEC3845A5228FC965FE083110452F6CAA842DC3A62A6CAAC2A66A862800F8E77A1F57E5C96E972668381C3C4EA5C5619A0C705C5E9341E38AEA6EE1980D31DB40CCA67580DF5224FCF7DFDD0D92DF27EA0E06F28FF2489E1FB807614B0C1C11F76552563EE85C95C5CE0B9D24F342267AF241C6D326AB5E66CA072F18BAA5E501455F64F5B2E28FAB987A7A6824EC8B9EE529B2289DA837E4E1832BEEC3E857D67EBF78DFF5F1DB3E591BCFC11F20D93CB8EEC0FF48D6D850ED68BC073B671A1FBD0CA6267205A2125AFDB115E526F91798A8AB93EF5152CBA14D64E88257B5DC136F7FF8C9C74EE91300EBB2F3E4BA2EAA90BDF7F96396E6D1DA390F448D2109AFC94833771D1510B2B51D1A6EDDBF801C65D63BA99C57EBDB228ABF5D64DF212B79E1ECF5A8FD2870A700E1E9A3BB3BF2B6488644DFF664CEE17618FE129D4DF7CDBEDEE3985E9FBE8AB2FD7D1423168C6F5E37CA710627770367C7B0757041051714082EA8E0821AC105D53F0F31AEF3890E0AD4F455E98EE22AEA5766EE385AFA2BA2DEC03CA7987197F1EA984662CACEDD5BFA6DE46727100E97540D46B4826AE629AA315423152A5593152B51412858B296F1A576D2C2CA19A6EB725826AB8899A6EA99B25D730997957EBA256C337559B6A92A42B6E97AC621C52D8292F23B546219EDCA841CF6159CFCD03864B37446E3248247FACFE01D5E50404840FE01F907E4AF9C9145B2B804E46F7A60EB963F07A7114CE59FC1548E7290EACB76D20173847E5A45CDA1750665A029F2544C99A834CFD964800D013604D8A09C9145B2B804D8A0E1686993C80A1F5D63AAAD288821F06BB155E50E2E4E7D634F9786F3C5DC2D27706C88BC77EEA80D49C207724374027A0BE86D5EF4467A28ED8E5B2D9F7E486270B25E0F282CBC4C1D4058006101842D15848D8DBFA4484682D7ECCEC034474337920D87ACAB311EAA810F8C361C36BA20B48E4AC067EA803CCB60AB00EEC60777EDFBDB21042E80A900A602989A1B4C11E642863FFA301FBA09833E043545D84354DD0979D010C90A789044E6C51D9833E0B5BAF64DB24DD2A8103652631691F3C1D4B8338CB8509B124805AB1BAC6EB0BACA1959248B8BB7BA1A91C51611AF82C3226164AC76C42BB18873B9A6DD0C548B817769450622C86B3B21842142D72E6D6EDB3C7823FE0C0E8505F90F022E09B824E012E58C2C92C525E0126D03593B2A1D022BFAF6C1440613396D1A212FCE06F29AA6A9096C9F7B6D7E041651188E01186778F2524BD7CDFEAE823A9E3A72728B68DCA2897527835DD875938E4E8E105FE73DCDBDD7693A0BE03080C3000E9533B2481697000E655E20C2A4719D403DE25B517507F78FA00AE3F811D5338DAFA133E34BB9A62BF3D8A6923788F9A62A5ADEE95770CC71B03185121EBD38D23EA0B44B97F946B54D2036075DA3666F107604C44528241BE206170F2FF8481C5F77946C39F6CDF4EE16A2D4EB9998696F5C2B12EBFBE9E96277B25E1740FAF68A9F9EA6DC1ED5F2FBBD48251DBDFDC1DF4C5D45F143920185B9F5A81AC8B89F6CB017204697245C5A40510C515DE34934E0FB80EF03BE57CEC822595C02BED706759779FE0D316A00E99A2601D08DE5E2F58120DEFEFCB38FE5B39E6902A1A26D09FED9387577F525CA3644EE6E2D6BD3351CD2876B353B4FF388EDB1F326EAB61D3A356D7953819D595B649A188675ED55DF9897655DDEB46E765D80FBE469F4ED48FD6352FC58FC6870D3D5D728DD83F304A4EBB17F9DC3D026ECEE3C492B2928F5F6721BEAADF62A48C1909FACF2010207081C20B0724616C962B352683CA4EB67A968BA53BD9EEBA7AF25A07BA93FB9BE5CD1C17A8E53B9295A91F506B732A798712CF3EA98FABD6B9BCC4F47D250AC2BB47DB00CE2A54C3C2CA70A2F14D6709354D3B3D829D5EDC27689ED0BF232BE69973E94EAA58F297764ADAA28BDE2DE5EFC98608E781765431A9280150356FC5360C5C300547E800A1F4871B18C1550B90265196DCC404ADB2600148E1F0FCEA5FA64D88F65BFCDA7EAE92CDF3D4FD5D7691AC5DFA6ECF0667FF70F10CB608017C7DB69BE96D9374FA7C09FC063790990D21A820D28058449EF8C1B7E5649CFCF2C35DD38DF39C7CEFEFB2CC2EA2636C82600CC00303180799667F1BE80F63A7EBEAAA9D55DE9004F0B6B15906840A29439E0A2D116C8ADF06A031A654B1934CAA962FE66526778A42CE2D558168752218B581527C08CCBCA00330FCD026CE62D9B552AFB65FB79B5787F5729FAF182F49007F163B59D208A52E7C16E3FF0AB7D8A9D6F81ED9E750FEF39048815205680580700B10C32C70C28C5001C0CCD023810D88B78E8F1B77DB236BF86B28D129945F61556E0E5A1A22F60939450485ECC6DB092C14A062B19ACE472ACE4E7621365C9BFEA81DF80E27B9DD3C2C05C72DA07BBC9390B902BA997BDEE51678BA9B7D7F2EB907E60C3459C67AA58442FD3E5217026BCC518504988BF0960E350C046672DD169800C655C25719197F97DF5EAA4DC7D02D5ABAEE1ABF6CA4C01C93DE6C5B75738C5BFBCD06E372093B7BAC8E4C73777F73FFEEDE7BF46EB1FFFFA13F8F1E7E9518AC34A60A80C0A2DF7F5BE8BF01C0AFDD2F8C1E5F87CAFDA6AC311145BCA1C4171AA381D4175F41029FF6ADD515DBE6A234E355F3D4003B2F925745D4CFD6BE8F81DB75F7DBFE643BEDB4116CEA2A2BA767A38834329240195C7DE39A76BF49135D267CAC72EFF9523ADEB2524F36CF381C94E7AFD6CB3FB5F8D55BAD1234C68D97656BF49EB43C3C38E34EC48C38E5439238B6471093B52D9E64223D724071849B24EAA6B33BB108D263E3351F2BABB6673524AAA698DE05A92A7521A7688D152F2BFE2F45C8A46C1ADCC5C3856B770BA7F4C0ECF19A90788AEBF49D44465CD11ACF38506A8B06892DA579A0DB3C947CF5B3842ABB64EA8F9344953C8747BC3C7F4A64A3B64BBD61301F64F7905E4B941BD60E029C1BDCF1DA0EB66B45581B3BC64369106FB4FE6AD0045DBE889CB7CD856846D45D856846D85828EFDB6426400CBD68E1A9FC50B51316998D5B898AE2F40C4643529AEA7EB9AE2FA0E58A9791F6A0AB8EE2AC8F9ED6B8DF0FE00D191DE66D06417E8BCFDC3F1A37A00547501FF442D39FB6455F31D2081237536815403E1FE8FA8271F035DD97614BA9340D7578C41671AA8BA2E3BF1616F3DFE8E5C3126C91EDEE448593D92A69680735428E7B4AEE1F8DCED1D1653677E6DA16E180230B93BA65E3EA84FE9AED347182184FE4994DE42A0E186301005885E8B8A45D916943E646B673A6779065527166462302476B2AFF22F70561FDDEF6940223E040E3585D85ABE0771B2457F5E17F05FF5AFE9E51BB85FB889234453B9A30B9BCEB0E90C9B4EE58C2C92C5856C3A85A806BF7DC1473798D95B91B5319423AAC4A21D614D7F780CEF82C16374A19C43773C76B2DB417454F3D8F0228764A7976D785E1F9D471168A0D9E9E120B3E9C2EC54B742FDDC59A97B8108E63E29B6EE3727AEA3B27CCC8BF5C7A894E57DF07305E606C4FB02EA146156C67B9EF921CFC0A7FDF64EFA3681F7BEBC4DCDED637E0E416A5E78BA247399C7DFF27D050134421CBF57B13100E9087861E7248E41599E4365066B0F61891AD677F4A8EFB3344AB67C7703B58AAEBAAA8365E0D760CC83A09AA9F5BACC3749A6C76A5755CC6A5343C96A5BCD9455444C8FD3B6A698D1BA8292CFA696B7A0FA7A86FC47D5D764971F56BF74B7CA5C31F9F5F429FC387E6C53DD53FB7880D7AEAC7E0DF522E0FFD750935DFEAFA166137EFE9ED4576735EE9A7495EB44F81AF5F9D758D4BF398AB3A97F0EC430A7EE7C9A3540FBE7F207D4CFFB347F3C89D12FE3A482FCDCED91BFC8C09B2EA0111CEB1C20DACA065F8CED30A8027F1E738E044F616128F84CE3796F3F7D81FB08AAFC189691A3D065F36B72DD355D945F9332B91BF24EDA13FA02A2759E0DCF63D95222971A43C77D385B08670B209C2D84B38511CE16C88589EB4120ABAC7A9C4478118495987B18E29A4EF72FE88158E3C000FF787E483AA22280BF79C05FBB5751BFDAE9B53F55AA2C4F9D753FC4808F023E0AF828E0A305E0231CEDF8C746F4298B1A45E9F27D5B445999548D28248CC35FD0060C95574DCF5CF6055585004F549F07F37420AA741CB58592714F5410F24CD6F2024829315821538A4680A8015AFA475F5751926924609D17EBA11F76FD6B30C588B955AB802C03B20CC83220CB3190653C093A13414C159AD31D46BF201B0D046BA51E4A5F597B30430B63DC9C9B0FA66FA31E4A5B557B205D7DD36118606662A720C2CD58250576C66BFAC3CFF6A83960650E8EADB52C7873791D4E0AB983C333C0D2004B032C5D102C35400EB519918086A65C8117DA4A5EA0427B4C650115EA96012A041BEFDFC69F46BB4661A73BB4EDBB9CE8DC36E0918047021E51CEC822595C081EA19D632934CA60DD5E56F31D77ECE493333C6914797AF8E791BA8C76D0CB17469373490139DF67D0967E2839CF3C8F9513B8FC7CF70FA07E84858B2E9BA6015E0678B91817D29F0095F6FDB9A6FCEE44ACC8FAECE7124CC0D2014B072CAD9C9145B2B8102CEDE6DB6BC0CA6AA8CB6231AA8A1089D1F5CC70D87E8BA1B0614CCDB9D545799E469BB21781012A234939A332A84E6B50A4CF50FDF05922A7E40AA0B4370378AF92F863B5858DEB9B9570156126916871F53DFE92D7D79BDBFAEC1A4DD4FFF08414374AEB48AEB6C98FACDC1B094BA47E9354601BEDAE8B242F6A34E720768AD60C72FF946783047F904BF0126E3FD153077AF30347F07C897E2B7AD38357FD515EF5535ED46929DBDA3FC96B7F4C360F7DDD9FD53C13F5FFAAA68D8BE4BFD9EBD3D943946DC07901FEB96FF281BBAB154572E1DA75923E46CFA5AE767D84CB2B02E87ACAF53E4AB0CA0AF5FA03806F586D857A9D02AABE42C5AEF2AC7AC0AA2B34ECFFDA474505B0FAFF4D5EFF7F820897CBDF14BF24F01D25ED682BFF9B85F6B6D9CFD1F2BD2F4D9556F0E61341D3E3A34FE6FA9B19E86FDC20455D058E76BB22FF8ED557A8F07D9DF0CCC972B57285A306286B9ACFB96A681ECC5C95510AB4276A5F3D40EBFC2F6DA091176BEC47A5586C0A5015C2B5466B56BBE7136C30A060527192B3CEA989FDB86E12E4770F53E84DEE673457C34BC07A137CBA7FFE8FDF40F53F75E7185A60D03D4FA06B56BEE6E97E0B18CE7EB6F9D93782F9BCB3DD29887EFA34DD5955054B77A437F5D7DD33907A937E0B9E2AB7D51717579D880F6593CFD3316603233FEBA4104253CC07AA7B026DA836A683FBF8F7F963769994C289A1DB7C89D6490E070FB79AFA1B88BAD1476402A044B1660AA077F600E26F77F913D39D02F175ED383DDA6C2F2EF3FCDB7EE7EC2018C8CCB08D68949A9868853241925FD0E6475799CED33CA25A285409394DC9060A35FAD01EFE98ACE4276599C7493D37C33217C50F0872AD3E4279E4103C907D7EC8D62FDAF4A44CD5159522ABCE85DAD77AF9E20A4E5F82729A4246A1BD7DF58A95B2947C1FD5C623DFB14BF5F25F68396063968BE234CD372BF49F931AA109E540D5E30901952A189392E40C1C634C47AE5FC03D28D0F96084727497F0D79364157B96996471B28B52391B5433CD435024FBBE03BAE43DD8810C9D5FCA65AAD3F3D08ACF43DF157544AB9290A1E6D40611EA6E3DF5B279C62B8A74A7AD63AA420469810E8DAB3D3C0E26521F9E5C75F56756CDB9CE4B0DB5E96B8974E6BA7E36D64C6106A2B3680BD3FD44AAC2C8F2B0F4A4D5F4524F5FBADA267AA330D57CFA0215D25ECBDCD5881EEAD4EA448B4257AD1081D9548B787C066DF4C47AC556E52915F9388E9162713AE068155EAB794BC627046C1108D389ECC7206823FAC9F1719C6AB11675622121BFCBB882B1897E858A39D0E1826E3BDB6F12F95A20A54FF91AACCE1E92748DFE25FE5DF2ABF3B40FAB69F8D314F4C1513E491F9E167DF97827D037B9307418B88E8A96C02294EC6B021EF5F4ABAE69A85AB2958DA52D562954EE6FB1C788B6BECD153E0605C3826612C9602D2C0424EACFEC07E86FE1D7636BBADFA2623E7418C19ACDFDA3E48CA6567E7325419FA654CABA3FB39FF0144A89B335AB52E2F361A094A8D9DC4AD98E049A2EF8B5426F7EB13AA450180D121265A55B5B68AC0E0372ED15FC5ABC2BB101A7D329B4C1FC192A77DB7A6E1DBFCCE328ED76A0067040D44EA2CD78130B4D16F638332250F1359DB2AAE6E4C03001E2A18E5036D14B6E23057C6FC3A0AD303CDBD7CCEA28656ADAADA2701E0E4611EBF37D50D4514E6DA4DEEA6C5F147584B1503B64ADB8AAC86960A48ED20E79FAD80D81EAE40D3D33EF3E67EF410A0DDF8BE65231EC2B2AE368CDDE0F790DD9F1A1C43A4399428B75E6504B8DDB36CBD0E1D56992A649B63959AF0B504A1C2092464A0DB6565DBA235E3844CB38A3B87E96500D6EA6563E81F4B58E5A88960BD140B3E5537FDDB4D7BA235829675F220F7B6D345D160D56441BB5B45F073DA249392F13EAD7F12C802B74E737CA9EB5D58CACEF5DCD28F2B3AA199F9729D58C2F6CBDAD0ADE7276351BE06AAB1B2A45A01BC814CD617BC274C3B5B77C7DF6AF71226E26543991DCF56C67D366366DEB2EE434B1E5AB36B9563BA4E6A37885D369CCD342B29D89126AF5C85148A286BFB3D88E9DB3A8281234F3047B6AC109DAC964D6361915C9EA33CA11B5E9E45AFDFC350538C12AA029211D4E28528BB140E48F47D73E10AD46B645645FA6BFFFE5EC02A5E399C1A471E750870FA2E1EC8ABCBACC37893C1C92ADEA1DA70F94670D7D14F333254C67C4ACD379DF687E8DEAD66AED4D20D5C0BB76D1F467DD060A989952C104F236B1C34BD90976AE39CD7D20597D548FEB1276807C5E66F09C1EE0EE8F3F840E909969418719C6D7B7AE2789DA0930E5D8DA4771369B12527361A28B5D269BB954B24DE0B0BA8AF6F7518CAED18B573C4E5D9EFAF5292EF4158F4799A36E57513670399AAE49989940C32442D6E91D17D1DC4AD56E472AB05D115F540A266A2751B6A18985DA09FBE3ED6C89818CAD832ACEA6D347D59C68ED520952CB51CE3A052B5877EB96BEB6900D27504FAA43B17E4EA9997CA666514DFE84E8B042B65C867276BF34F176975F5DA988D64A3874A1AF7AF6EEFE6E1A9B5B709A3F4FB2B6677C42D29EF1E7C7E7644278C295B29EAB126B38F7EFEC0CFEE637288750C355F7A74AC704CD24CAD65336573A516762ED1375E65D0B15AC4DA78E8A09D1D7CBAEE5DC8AB9A2A752B9325182F0BCEE51D417A07B229EA65C03F9323780C2B3AB1B0D98926D924685CAD44A5BF1548F42D8061A28EF4ADF027B523E2D76265041AD19D072BE132D675FF6C87129812F5DDF60D99365B11051E7A89BA9663B2D7982D14EB8E4092462B0E4CDAE6237FB1D9C1F0D376757D1B32DEDC9F282793ADE46B79E341713EA102D57AD65AA6D339BF67439B19B44DFFD3EF8A4666B2DD42579339E66912D4C144CD1D7143B76F278841A8ADEA913358AF18EB7A88E38E2914FC558875B7CBE263FDBE2CF830E1B64CB1933D6C161D45E41526144DA21A8CFCF5DD75635D13E117DC9B12A57C3FDE99D82A309544E21731D0E88860B5036CD454FD46004755BCE42A7E269528D3BA2054EB55F676A8EA065365B725A6A53C7010BB99F54116D9CE833EFA5C8D5DA2C609DD3664494772CA1EA92D14C0E0D8F244CBD851A8691C5DC56232AB07DA0F128BB93F9438DA513A0E54B5864BC31758FCB4C39465F46A98E8CEFA12D6D21E58F67362D365F4AC9960BD161AD2B3F43D511F57539F77E587E26D732D37B3F8BB8F243E590D2F1E0A89B4E98476C192E1E7DE6A6D64AE9FC1C8EE3473A26A39B1D82C693ABECE2AE7B28189C5B710FF8F207775C16BB79E33BE85E15F7A8B6F84BB992AE9ED7C3D9F037AF88B6B181CD1F42BDE6D4E529724BC54075798439BACA27CCAEACC6C3AF1F006DBB578C1EAF2A1E7C5DCB5C0204F16904700577F9D106AC3E81C7F21254950442B2557902686B990C9E439833788CC3D16CAB9893099617B17C753A1F5ACDB6967403B8D9DF957191DC69E8D250D5B32E6184B9B1443D87A3EB12CBC984BAC4CA57CB81D2B79A4D972E1079382368388A37F5D8AA3C5DC26B4D94B18AC3184717BB5AA8028F394F719262294DA08E6249E8748E5ACD98952EEF3261F5577A34E318D44DF9D9D598566669E9949DCE18E5A0CFDD045AA93F3F3ACC2C24F2813728550C84A4CD441A7A8811121AE39849890F306A021F866EF26C491B95DADAEAEB1212696BF033B1DE1D7E426D6234CA0705B8B54753B9C37C4D403A84A9F5F320DF1220466001390DB1A6B57E2E135D2E03561E179ED43CFF1037194D07DDCE3946D2C0B9CE29D4F23F9CF309622CBAF188B246A3A9E012B29EEA3034B5021E413422773C268BA03A16D1AB0ADA46228EAC88F32E84071F4F488D86D9F66BAF876C4B538DE42A8A497F5CD5B4F02AF9504EB138A65751B1A8F4147568BF0C359546BD3235475B18E70F7915B233B58E1D54C06B7B10D9ACD8F86489754AD482AB5B586523DD1276A2D031AFA11B0417F21F1A5D733461F8FBA11908A2CEE210F7B4576769946CC5D6905F9D2712AAE644C7C602FE1447C775AD910CA65C6213AC6072912C7E19A3D9AF1F0FD157D0A6FA7215B4E54FA1A075AD89149494D80C0A4A8AE4E014140D4A5F3FEBDACB55CF86BDF9226FA4E29A413709792C5E35FFC88B6FF769FED868C4EAA4AA8AE46E5F49D453D882A7A26465C37DAEB8278EB69195FBBA23299D520813289E523C3A3C90446657C39B2ADA80DB22CACAA41954CD965A1905ED642A493531C1E4AA5E95EAE92FED59471742B6B2D41617515B26A4BAA2E5CF96ECC45526AEBF54EE9027FC9572A561F20B9DFDB7D98CA0D6795D0D6B2A8FAB606D1F12FDAA6B4CA25EE47827D72E521407A85CC35AAAAB61588B71D50CEF48A56B2656C583D6716430B9EA71C47350FA479BF2F322DF36EB862908E85B4E0C3E867E4D97427F6E786DDE26D44FE5FCE8F0D2375A9CA2DEE6766ADAB69B5849BB5E97A7A21467332A2835333A9CB44D6657CECF77FF0071B5EAFE542A25555FA68C4D551B1DA43B91E89E3E4C70D23D014713EA9C40F00B34D91F6A1F226C53C116A0E8A2374F5FBE88EB7C015196E555DDEA97DF4B709616685ACB5F5F56C59E5D1411A91B50756ED926EE09EE665E3445BC583246BD281A5515C50F2892EF6302D941AFCFB0B4D83ADA54B9BCF5A54A42A769BE39D9570F79C12334946A111291D06A7C966F45E3C18AB5485DE7A5900E2A5312A18F4B79C4D8235503A22A824A6248DF010A4ECEAA224FAFA3027EADF88C0AAAEA76F135018F6D5B0975AC962EE14FF99AFBCBC28A4D785430A74BEA328FA354324B9C6A2603FE92D7BE73E9A8EB3A6AA2CDFD88844FADBF97A2A4C2E654E113E465C73121AEA4AA4D4E46499B88C658758749446AF30852C1EF0A7264B8238F1E1D45AA49F02C2A8A842F3EAA8A92247939824791BE73A292611743C9915E178CA820813F2FCDA343BED0ADC78F644EC9474B4DC8A1CCDA4A924DB6733DB2ED536DFCA580ACA35E11E867AE588AF4BB522AF56BDFC7E1EA5DFFA890D278B629C9F996B34F0FAF20F3E17BBD7673914A57A624D2A401E291E812046911A8B30D89A9B4398C544ADF241AE1EA7B97BD454162C85CC3A382A7FD514E7497B6843FD543CE1703A474038AEF49CC1D20A79A5ABBEBC80A9616999E4441840E5C90111C821B94AB3427A29CB75273C2B40D48AB68EACEB2D83811718C0A622270CD44AE18CC481B7E289F92365CCF806C1B342627DB065929C80A421178C485510B465DA8296B13A49C5132CA8C7BD0A40B25616D72B5CF464AAFF5EA68D26B5C23327A9D2B8A22883930783BF955BFF9C72A323BFABE16ED59C102B098CABDDFAC1F13E54260FC34526A9D838C4B4DE4C2784D0E5F433468BBBEC25D10AC5CE82AE26150357912695D181259D0443882201C2A5E44D07A3E568D27852F03A28E9C7FBCAA480A832F46210C8298401ABEE4803C3752210C15E44CF7F544C36FFD478AB10F64A61AF8302D0A01F4153547D0D5F724909E9C403022F5B2900F71FBA34513AC7038B5C443612BF3C44279F324A2E1D0E3C885E372F4A23CED4AC57A2BF92A24AA2E9F79412B913A09D6476DB213890F73C9ADCE1E9274DD7A2C59C9096A8A47C76FC09317E92C95084C4092232B19494731B58E58B9849A4A7A23A9EB7A934B434D2C92967D5F22C19CE22BC2AB2D948FA8857278828612C9917E7DB500453D4CA6601C061AC7BE8934EB163663459FC69566DDC364BA491F07AD58C62492D569AD9481061189C439475F6AB1EB74299F02D124DBCF047E94A4B94C089B2805206A2911347522A616B2B08F496D517D8AA6294F7E7D2D9BC2345318ABEE0050CF62B1D4279021FF4591EE409123446903C93865EDB862E41F56CA4429ED82274BEC54D5AF24E9AC9A2A414AB3708A07294AC42912A381FC44C9377137D01031E3597ADA0A68AC79FA2A6722ABC995CC40BFCC55CB40ABF48434932EC1A574BB8BB2671D21515535C644B6F020248AE04442A25F91924989A9AB1E15DD442627A3459E21CCFDE90926C0425E5446AB9334CD1FC19A8E066165A7D54E3C5C9DE63C9932712512916AF5C1112F3D786F326E035356CC20C4E21535518F5AD05226D421B64643AA22FA1C812A26CDC3AF9C0A4E52FFD4254948A53F4B7E26525F3F7A7E06D23155B35F66EA435F915395534B63E1EF2B7B302203ADA9FCA6FDC24EE50B9589479A5B943F305166517B518972884E8470D5E696AAA90F46D5A6D602E14E6366F9BDF6C199BAC2E23E78AA313CFAAD539FA2A3DF3335580C2D04D93D4B7115617190ACF878D5C403E3D4E6896A8868920889478B231A2AD0D3975C86B8CB1515DC299491B089728CA29612D911C1A36A290A7BE0D9462ADA750491D241A33A32A5DA980C996C3A8A54A92EC462F52ED0D5405821C6A1A6E6C8FA064A9119886B203A8990DA173CD5AA4655542F4C447DE7658EA4368968BA28F0B6EF21285C2823510BE5F0040D2552C3C3D8D5E213D117CB514CDF45D7E8F07A89B651553534841AAAB3C651F4269215BD1827DB248D0AC9EF53DE403C4E693B9EF498CB0E1221CA894FB3B231FC8AB58DAEAAD60EAA85B3B6D1F4382252C8DF4152C3CD12B188FA3AEAB174559D85D213E2397B869B32CE72A01EBEE978AC03EBC19A2715450BF1D0E40D791263AE8F4904A7A03EEEEF8EDCB6D177DA545B4FD9A35192DDA1E0DD281F1B4FC15B51FA536315A2D9DECE5A11BCF0E334F955C5C313B4E0476C0E57C8A4E19A7C8A923D3A7F1A9C44A55635615D9DA1A955CC585AF3AA96044CB095748623010DC6A299062390EAAAEDD6E755D75D4EB45DFAC60BD57CEEFC76FDD0775DF31BE80ED4C0896D2CC459DDD9F425755D011AAAA0E069279FE2132BE178A7730D07AA4325AC96EEA054874AC6529AE364890AE752A00A8D56C611640AACE12D526D6A04226543F7CC45D4CE72F4BA2730EE729EF63C86CB8A99DDB63D9317371E51CAD3DBF4269342EB21EC9233B022E555138F8D539B27B43E4B84444C3C521CB90848590BA44E2DD1F62A9607514B3506BCB2581A5DCA0BA5480872A34AA4CD92B1C2F35CB012E1D4120F81ADCC93C890B943220D0E298E34880C1EDE248227EC104B04ABA51EC650D959221829AE270D4B45E22C113C3988F89229A79678186C65AE7BBA492E221107870E471C9C84251E22F39844241A5E0B8D56E2C1AA1BF343F4788955A4617ACA6E26F16EF0F890F83964D5CD062BF17D7811E634FE10E2D9457570BCACBADEF03482E4A94C3C9A729B38589EE85A76EF825F51734CB25B1796629AECCE05D1ABD9A267B7DA192E7306329B7B61536F7824B535C7A8DCE058CA6EFA0D8DEC6577A5ECF45D943A0FC87B90DFC4FE49D933F2BAB233533CB573D2517253BA26D5EF9FAB85A87A345D3662C9B3E93E042A7925DD10FFB8CA56E4F555BCEC2D1E9CC8E76B29AB293DBEE217A87902D27BAE9A1C99F2C16A765BA973814AF944B54070DE8526D426F9F3D5E2D108B5C94E38536A93E0A56A5EC23D8D37AD8931295EB5C606C61D8C0E2DC5C6BE1B8C772975992FD552E23DAC2C1D19F5B4B29394A867900552EA06E35D4AAD5F452DA4A6A2FEB8EAFA7E44D4909AC841247E39962324CD676689D1A91F9AC546C8244495884DFDAEAC90303E4A6F12143D7A2A91A3D63BA9DC41AB5E4AE50C9DCD09AB215CD5DBA8FA73E72059F25554893C25CFA77247C77F409533A63E3BAD86C8F80FA64E28A82E33AF4A4EBC37402523A25E01F52225EAD54F91D6FA9711F13B50094AF89EA56464BC172DBD888CF782A5C5AFDDE342373CB268B0D4095E66D45A84D8B719C75AEED8D718A75051D1E38006E2E5BE27A83564FA45C1B1444BBF21388560E987ED240295BE81C71DA0E8153CCEC0FAE4E41A7213BD7BA7BF984804F6EE7543A67F98AD2F7BF7FA267E00DBA8FDF0EE35AC12835DB58FD2AB7C0DD2B22BB88A6A9F4339B46CBFBCB8D945318A32F9AF372F5F3C6DD3ACFCF5E54355ED7E79FDBAAC4997AFB6495CE4657E5FBD8AF3EDEB689DBF7EFBC30FFFF6FACD9BD7DB86C6EB985871DF51DCF63D55790155852A4539D7D6E03C29CAEA7D544577510967E36CBD65AABD3F153D31D775D06E267A37273B6DA8014A32DFB540FF6EF3FB9E5CBF7A7FFA0AD4F994A146BC12787607C99DC3C1208F743D2EC0FA59D996B0ED4D1C35179DEA87FEFA337138E23CDD6FB3E16F5AE7C4ADD17FC9F6CD177D0A6D6A24961051A04FEF3DC05EADC0E91105FAF46AE560B9C33EEBD3BA4AD6EB14B0C4F0EFFAD42E231E63C3577D4AADD25C425D7F4352234BAC28BE15527C6BA42750C32905A9BF9868DA3E6368B4DFF4A9408B5351226F3F197252F05861DF5B90D1F9CF6447D2A83FE8B7BF7EC833F069BFAD4383703A448121BD0F4F1580169CFEF9D16506BFC0E889C723F6D940F2204D79C4F0EF26F3080D445C7DD846494A4F265EA24FF116645156FD9E2515490FFF6E438D5EE5C91283111700EAFA7BE627807F37A5B63EA57F09C367B3D510C28EE43E016B963FB6D48E32CD2A5D663037C916C085634BFD82B1CF1672446E3F8E25658B6D47CFEF405447BF97CF8F1066FD56E47B4A1CF877436AD7A0D82665D9EC3E189A44294BF9DD6B0A68D170EE3583E728404D03443DF8C8BCBEE3062355E47400A59AC638D072B94BCDA1FC74CF131ED81CBE9A51BA8EAA079652F3D5603901D986A6D37D3B1E337968C6282CF2B32CF2AE5E82E179789775FD707C05BEF7F6830C9094A97D2A5566A098EDAB81843A725F125453A1253E7C35D895C125FAF782DAA0F41FCD76BE7BEA67D67D33A5C22E8AF87783B1EDEFD2A47C009498B0CFC6B490439F4BAD2930A6779B73A9A1CF269EA32D607574F86AA60D276912D55E605A23FA0283DF505ADD82274ADDFB8F26A0AA4A014B09FBAC4FEBEFE0F9312FD6D40087AFC70334960B920F0D021D0AA89F06AAF981E901F035C00D7B2AD109F0891FC8D5007CB2C62301BE24FEC6017DFDD7790E61FC1D9B70FCBEC60EDF3FC0DD4D42AF8EFD47831F071565CB00474E793083C10C063328EB2518B0DE8079305D9646EB70FC1337D0B8564227055B3A9FE7E32A4AB28B6DB4018C63802CD1A738C00B7A16C81283A528DA503F91E64B305BC16C05B325EB2598AD7EE1A90D90B3A71DA36469C484ADC7B165B5DB8CE34933F2EC359B45D2B1D77E33593519979EA1370F898F6753CC24825A5CE725B376E3DF83650996255816592FC1B2108B8607B382C858DA147ED3E51A94F1B647EE46669C0D91BBD90A8626189A6068FEB486864D9EE1647068721686474D621C037452EE3E818A77B4419684A54B97F23297AE70DF2ADCB7A2E3C5C27D2BC1B8BCDE665A3AD45C1A24385EF0C5A76B7505610F35915DCCFBAF8B045A1E419623C03A9CA34FDF0794B7D113B36E349F0E3B6079E98B6C00C54B04C5876F52F0558D0D64674B03980E605ADEFECF97BCE05000F065BEC9B9978E88021319C6E02ECFBF31F488028395F931416FEC30E4F0EF06A34DB26F609D64EC68F1027D7ABFE5F92605BB745F3214A92203404F53326CEF3FD1057A223B2F7814C9127D8A17DB5D0A10A206EBB37D5AEDE142CD1E0B092BE9F7F331E7B98186AFE694DA5B572CB7DC0A062750D1EE3DB88FE038D1D5358EA8B9156CE88BF54354C74053B6D58E8F4AC812738AD75159A21B617CAA43A91965BE7E90256614AFE1CF81A5D67C351EF54D49FFDEB0EFFAD40A7016EDAAF821421715FE0E2838C096DA500671012A09EDA1DC607505D529888A0214B7F93790BDDF17702F5EE792A6965A493DB310AA3368A0128E139A2EB3A1FAE16997140D6A4EC4F4E95AFA3DFD01EE4E76497D63353E4B13B86ED2FB4C7E0D8335040AB995B16C30926AA6A33949D3FCF1222B410C57FF8F55B5E30D8853C90049D6D238CFD335649959D4D9529315B70422BA74D9625C6B68E10759BDFE17797A1D15F06BE57C9429A06AE170D3A6B454DFDBE15C3B6845FD35018FADB869D9F16B18FCF6BAE963C54A15194821AA22D667317C35A3D4257DA56975DF4D66A70656F51BABF4F4E0250618BAFC02FEB94F0A3A9F02FEDD8C5AB4FE9CA5CF2CB5EEBB09B5AF4999DCD15168D867032D49E1CEF163BD58523A821718E875C4F98DF41F0D76BA79B16DD59EDAE9E205C61AF2A128F2A27D7095AB286405837197659D51981A78FF35F8C5835F3CF8C565BD2CCDA7372F46C4CCBE1F788811B4478652224B05852341B74FF91A08305B576405072538D09C269C2816AF1105C6F478FC1983D38E0536969E2C990714F9856B7DF2FCDB68C37119F7251614CF18C04194D8506CB44D44B52B35D6EC53700F5714AE667745C6344FEE2B26DE8B28D1A7F8EFD1F7E8A65E0C487AF87793C3C5E7147025499604501840610085B25E0228A471851F348828D9C3407EEBA5E2BFC3710AD6A79BD4D945F3C990069BA11AFB6C82833EE6B4F4BB6F46F27FBCC8AE40B66724DF7F37A5864ED3B6D18E47B02F32C613C2E9E4951B53E7A7E2640ACD51102739015564B2AA3FE7FB8A551FFCBBC96FF77BB21104BAD165FA54BFC0561985A4BB6F06D26B821E28B9751F0D7E6FD088523FB5FA8BF15E28E561D9EEBB013F31ABBFDD37532AF53901BD201125FA14D1FE95A4D47C319877A881ECA5E4E1AB994DA91F5C2B59CBD27DD7A7F6218BE0FE923272FD47631735B3A7C3BF1B053A71931BE3DF8DD71AC17E7D2831A7186D38F08E29B4A1CB5F694D3367B5E6E4BA48F282895D650A8DE99E3D44D9069C17E09F7B90C57CF24C1DFD5E9075E51EC9100526BFC1945628EEE3DA321A7544C1D94392AE0B402F546491E138D1C3E08C03882C31A37811F3C4D67C35FA2576EF50523FC4EEB319571F9EAA22C25FE5A619642A1804E255D5EE0A40D4402D67F877336E6F20BCFE5C30C78B5491D1B1B6C0F94A9604DF4AF0AD04DF8AAC97E05BC1710142A3FE4EDADC8ED80EC7B7E2DB038246CF72357C35A3C4EE6387AF73ED89BB2354E66880289816915D94D0765649446DADB0CF26B46E1E224ED854F7D584124A3845D369BE4DBF3BBB289BF9A6F9E9BE06BC11F046C01BB25E02DEC0F1C6650E47E527CD0287A23DFE9053592A0E691DB767E8608AE7D16D0AE68DF1714FCD7851B6BE40DA08F59F83150A56285821592FC10AD1AB587D82E22FACA026E7165B2020B154E3730801A6B548D9A1629F0FFCC0D2F918B6BEC584AE55D2C76FD87743796337FC58A9E385731D5DBA6643F0E17C08402400910044FEBC40645F14208B136704D2D079B6411EC2A6E3208EDB8702804B8032ECB01B56A6F09091CC87A7B88E5DF8C2AC4E648941D8C4F3F68EBE12DA7D9BDAB57C51729DCBD86723BC90ADE907D2FB8FFA74D0F5D8A8BAA90A26448E2C09F639D8E7609F65BD04FBDCDAE7B2CAA189AD0375AEA3670F6FC8F1485A996D1D32E398F02FE01E20CCC06CD0890213FF35361666D34F179A444BD562F95C5B6E36608A2A34E7B72521E2182B36E69997B3982A32700F403CB5DD559F28038B7D368020555454B4D1EF3F1A98EA244BCA079AD0F0D55862179CA802AAC864861B50CC4EEDF0DDC0B4E4151D5DD07E32825B28390703B69A8F06A01435608137F6D990961035B3A5C673FA2967423CC99200E402900B404ED64B00722C8AF089E05CA1DBE11CF41CCE4DD24EC02260B61CB4C77BC7CCE20533AF68E5E621A9F5970F9BD9D2F9F1F8FBA48C51E2F933B89AB184D9527DCAA7499AC2C1B6F9FE99673C995273290B48738A4D8E28D148E9E3C9E69BC18AC1822F63D4D5FC38D02122EF47D37C3790D9FEAE62A1F4F0755A44DEE955C921469799EBC5197AD497AB124D89C158A327DE70FBAF0143070C1D30B4AC9780A109A4E3093E3B20E7009AFD83669F0FAEFA7B22D5EFD3AD870AE7B6BB287B1690664B0D1C78EC431DC6EF721CC6FB4B7E9F48F5F99A533B7F1CC3881718FCF6D0E314BC7D25513017840F103240C80021E78790C2D5B700F7E80C772DF70249AA59F425F25F712B2C0E0EFB0D0B708F08983818E0CF8491FD3A96C772879EC4B5EF4918A5C12B375B2FE10A48838BFE6BC002010B042C20EB6569586026FB49AC708ED693A065613B15ED83E574B59CBE12919C946509B6772967BF4C1519AC28E89122CE4A327C36B6E9E2370AB81582CD0C3633D84C592FC16646B81FD98BD1248959584D1581603697623683D9086623988DF9CD8632EA272A8A84F52F718A4D7EAD113AF4D9328F7E12050652A85731F60A01FE7D7106B3959C278BD952733099420AC166069BA94731D8CC603383CDCC36F0F3F7640D8A93D6FDC3379D6C2DFB9E386F5D0BAA042BAD65A5C9107D47234D12B3B0D12A02C1442FC5445F94D768CAE96BBFD86703CFF216CD39E5526EBF9944733139584D2FD5A2F74B50A3924D994A97CD15C5D5FD42D887CDC8127D8A5FA334599F17F99624877D36A4456793E93F9AC4A7F05E3DB279EEA87ED9E7327F84B68E4B93571E806A00AA01A8CA7A591A509DEB1CBDC8D7FBD835FEACA56273762E6A390E4EBAF9FBEF14B0411F02CE1258B01830E62B36FB2D2765C5A1837DD6A77555163B0E2DECB301AD24E391EABF1A508A9E7894FAAFD3E3DAEBFD5D9A940F2C1E220A8CE9D19808FB6C80B9B37A016079230A0C798BB9F98E8812130E2B506451CAA349971950453B70F61D24ECB33EADDF2FDE9354EA0FFAEDFF00C9E681427BDD37032AC99A1E4DFBC964C5DAD134DA4FFA343E7246F3D17C34758B2B1095CCC3C65491C14A9FFC0B7029120506FB80EF5192A2D5E0A202CCD3C254D95C7BBB4F00ACCBCE9D45194AB2C868857D9F3F66691ED12F8093252696AD061DEC0694283089DB42CF67B68DF96F6B6285FA74BF801C657939A1D41BFB6C80FE8B28FE76917D87BCE405B5A7A0CB0CF7A6B7F91790D14F549325265E99DB82F39C5AFBD184CE39DC83EC39CFA90DDF0D7ECBFBDD2EE59DAD62DF4D343ADBDF4731E282A14897196BF519DC796DE034B2F76198E2E025085E82E02590F512BC04CCA2E4E82AC04959F80BE4CDC3E18AEBA63F2CF461A10F0BFD9F76A16F41A29F6B55382D7BD770880F1F6DAD67F6BFA61B5FF44B6B9F2EA35C52784188BE0B562C58B160C5E6B1628D47D49F2543F45CAD199F46B068AE16ED0B48D14F54E089654B8D9D6BA2843654A1E121EBC97A4D1B3DFC7BB07BC1EE05BB27EB25D83D7C1D6A5DFCCEEF42522706F6464F4C611C93D71CB9090F4298D2604CB93F83FA850952F79B4FC1200583140C92AC9760903888DBD11C91C42CAC918A8002FB0B50BF61006AB24D9AAF3C926CA941C08393C90C0B7558A8C342FDA75DA8BB3826D714072D199BDC06C2A6C12D160EF5C3E2AE393761710F8B3BBDB8378F5FBB1F83F4742C967749DBB0BEBBAEEF3E3728E33D8738DA43ED1EEEA99DB1D7F7CF4C6FEF7B7E60F0367AA216F1FEAB21A5FE3D410E3DACCC74267DDD1969838D58724441403B01ED04B423EB25A09D9AB50FE81AD365BE71043B1D190BAC236E3A0ED4A9FB6383F9B0CFA6B4125A3BB1CF86B46EF27D419B67A2C0901E9B2307FB6CE02DDDB56FDE51821F3ECF07E7EA01FD5ED06FEBF55F0D295D45F14392719E41644B4D7984ABD4C986C9A04497998FBC7E5DA6A04F1FD9D2000A022808A040D64B00058D20F3FCDB7EE708091A22168040D470A99E0FDF06AD193F8B50F0EF06A63BABBE44D9869B44042F31A748A738C1BFEB533B4FF348C4215D664395E6922CB1A17853819D88665366A03B7045140C9E2AB2A0490F9D28300813464DD0FB9009E562210A0C604BFD53E7002CECBB29B5AF51BA07E7094899DB3074A90D9F42C258A129DDF324AD18C846949852AC9D813432A08A02040C10304040592FCD0F869FE09A2E33A5CA49664D1404A06A0554EBE5DD0B5AAD2959435641EB7170EBDF01A59CF507931599CE786C9AE7D8FF8BBF294A54C149EB8C1798C6B53372C23E87E8EE605183450D4E95496CD51528CB68E36AA75A2A36B980442DC7B14F68D7CA3D34200A4CCEE6B9D4B0CF26F10BBB672E35A2409FDE691AC5DF8444D952A328897F80983218FD47030EF335B5BA355F0CFC64E0B1BC0455C506A3902546634338E18E9727102F31581B38C2FA6C2CABA605CDD3F0D56084CC61CF8DE1110FAACF5ABCE16B401F017D04F421EB25A00F6A9176042003210B0C226B3C0E0CB94DAA944EDBD47C320B5564C90C5FCD36DD1FAB6D4A2F99DD578343188F29D2DBDCF4ECDA461418D36392740C9F83D90A662B982D592FC16C513B01E7BB761D21ABDB76E2C6E398ADE63D0EE68A42FFD5E0E4611B25746C5CF3C9E4F4C24FA2C12F609394D0F8B3CB115912CC43300FC13CC87A09E6A161ADD84459F2AF081D35DD80E27B12BBFA573914ADEEEF695019C772B0DA66AA5B877393AFDEED30A1DFC357034A719E714EE7B1CFD39E1586D4BEC13E06FB18EC235D6E9A512A4F5D0DE2C51AD4D511290B4B286F3EB7099C695A3AA120CDF638451D398769129310091BB5A0A7ABFB66B033847D320988DB6F8B9936087DEA3FCFA2A27BA1CED52BC152B4714FE85019E7A7E62313808F8C049EB30974F7FCE95803A2C86484079171A26EC34CE6CE0C93E3CAC89CEB536526B1814BCEA1D036AB139073B499531C107C40F001C1CB7A09089E59323D820D47943115BCF0032ECFF64501B298496D8E7F373170CDA3CCFCC72DD8529380F5672479C1AB1974E11220C36992A670B06D60234D992D3597B28034A7786AA0F329AF00B58EB49FE682359E413007FCDACCE0595ED2419044892534F7969EEB367AE20DB7FF1AA05A806A01AAC97A591A5453DA94B2B54C029B32142F07063611283E1E1AC549D9C7C24CFACC28DE279B17832D3538F7838B6812A5B750A12806F1029345BBD8C215A0602C40FFD98CD6878C59FBDB8F267027AB8A28E6DC23204BF4299EECABFC0BC8C023490EFB6C1213041BF066802830D2158E391FBE06731ECC7930E7B25E9666CE6732B948748EA6F6043DD210D75140889A85B5555218C7E07A091A450DA085B94F8A2D13C9429599F848CAF2312FD61FA392BAFA409618180C10EF0B246F7601A08A0CB87CC833F069BFBDA3038188022B7A0289F26B182C818FF939440279C18D3C624B0D16AD3CFE96EF2B085AD062FF7B1553EB155B6C419BC3335D66006FE21894E5395451B0E61C70728ACD3C9AECA22D5BA61710A370964689EB73080C3DC72805018D45FBA111CBECFE05FB6C48AB4938C3126BBF2F52972EF34DE2BA8565E839EA92808678D581D5E1B7EF0913E84915198508D46DD8743578C1581A3B935EFC9117DFEED3FCF1244600E7A4AA8AE46E5FB9864309A85AE88836A571569D93B63F76C9204B427038975E5445BC74EAF87713EEEEA37D5A71565CB2C4C0F55436D7B9280DE9BF9A50FA9A94C91D7D4119FB6C42EB0B88D67946A7BEC3BFEB53237F40F4AF812D0DCE99E09C09CE19592FC139C3593ABC0206679C30193C88F9E721F8F7000DC492E3E778A5CB4CA9726E911105E6C653643683C154510B063318CC60308945036AC006DC165156261E2D2745D5C1842A298D634BFF4CD6EF2A4A32FECD69B2642E4B851284D66A4093230A4CC206B9D4B0CFC18A062B1AACA8AC976045592BEAD376BA5ACCC922F16AF3CC86E00D9F83CD0D7BB9608582150A5668742B547B947C99A1C63D656F8604EDC376CDD5749C46BB0F9237A938C516B4395E4BBA2C98A7609E827992F5B234F3243CA848E17A0DD64DE621F2A48228599CC16BDEE0F064F0DA8741EC2D9E88403079CBDA2D1D9E01ED5B3237EAF1027379B217CDC99260E283890F265ED6CBD24CFCD80619AE89799CB4798C29AB7C525551FC803A5D7D4C4A6824A15EC92E4371AA33D79DFA3A5D15D6D4AF9928599AEEAA0DEF64A5A565973182BC450789ACE7C18ABDDBA8D8001EF2B0860D529ECEF26C5D1FA6BEB8283FEDD3F4D797F7515A3211C59241BF7BCDD5037D55C1F361AF9A8B75BA49B8BBEAB214DBBCAB719CA960C93A6A0A41D083AE70185CA2AE2886EDAC2DE85A3A54C44FF91AACBE26E051AE2C9CDAB4AE6055DA7FA28A1A1AC3D076541844C8839EB06CB9A909A261C696F31C9379B256EDC6934872259F763D026C1233BC15515B431D74FA74D41075FE30435DD1E2D94D7D94A9C946D4A3EB26876A3BBAEB2E2BAF4C73444D685D21EA5DF3F3EA7204CE27EFA81604510F5A2160D2510FC4F96C47D400327F5D3F96FAE63CBAF72BD10455535A23C8FAFA2A21EFC75135D4F9FB0C7543C1ED21EAC8659E7FDBEF56D75101D7A9E60FA96270EBD3DAD07E570B9443CD79C5C5487998721E876E5A390EF2548CDB939ED457F95A6168A809599DAF25CDED40DD89C0297AD1147F3A42B0B65C15194339F03C632B7C0F24C7A9E25626A9D578C84E44D951657CEF6AC57C2E517FC6DEDC12D2A81D17DADAD3D4F6A93588A2A3B6D4247C6B494D7489DA2118ADB35608AE3FACBAFB8D16973086B69A772DE4B7183953A6E8D8710207821EB44BC5AADB6F407C81DD05D376BE79E4ED89920C147495DEF9DF7EE9FF2EBB0F68E6E180AFF23548CBA1DD4DFC00B6513D987217C5B547690DCE93A244A920A3BBA8044D95972FAEDBF423F007FA5C5660FB0A557875F3CFF40C6E0610DEE92A5CC155F31E94D56DFE0D64BFBE7CFBC39BB72F5F9CA44954A23C5AE9FDCB174FDB342B7F89EBD4D65196E5553DF45F5F3E54D5EE97D7AFCBBAC7F2D536898BBCCCEFAB5771BE7D1DADF3D790D68FAFDFBC790DD6DBD774F396AC16951FFEADA35296EB149F6C2C82A073DB3789C5498D78F777C0E85A37B95FC0FD0BD1CAF3EE35DDF01D47A350EFBFBE4C7A10F91B80738E0EC4AEA3AA024536E4AC79F9022D5028AF55BF48BD96926F8EB99A0EB2EF51113F44D092D0B2FCE5225B83A75F5FFEDF75AB5F5E5CFCC7AA1503FAFB2F2FEA570C7F79F1E62F7085FC3D4BFEB987756E8B3D78F1BF5EBEB88A9E2E41B6A91E7E7DF9B71F8CF9836BD92ECA9EF96C62A4DFFEFC579C7655B0293768D244088284F49B1FDEFE644ABBFEC52899FED95C1E57C97A9D0243CA3A1CA313D031186EF5E4122E536FA4B42D9403A3FDD680B68E38CEEA1F935F76EB9470265475188576AB924F9A2DA7857701FC67B293AB973145226BA26C793067B626FDE1A90259A95A217E365E1EA22763A6B5B416A4E9388411D288AB36D5A7741D369F443C34C8C21235CD072344191DF3A5900C2DC28CAF39336F113386A2C602919ABED7F0DF558296661B4A75548FCCBCBDFD9B8DAD206391DC18A56390FC728B05243584118B65F34100A710EAD857C8D16F29F12182881CCBFFB18D9EFE4FEFDD8AA297A6E81B8F6FD2FAA9FC2FE3F5810D77F2D2111E012547FCF2D8A383C5FE07B0D21CFF6FF73CE1C3F9B637736290A3072FC49A69EB48DD259B5A096D4D6930ED8766378355F1D311154069A67444E35EF77E50E99E856D3B12A366EFD0EA25813E7DBE0371A5EDD8A2763D737B9F86A13499173C4BE3AD7F69B437A67C73FAE3589CBAFC9059367FE2B169EAAE8066BF4ECEA4BF39D7752FED4B29553B9FD5BE545940BD61A39CC8E503580F38C518A4B434501229578BDC92BACD5D095DC136FC1FAFDB7C2235A9CF5E0033A95620F124AD6EC113E797EBC6E66D52A5600CC2D03AA1A760E41A6DC37000BA87B5B33C2C2C7EFCFBE039771B3E76BA87BB63D1DE2B9CA6F9E6645F3DE4C5B1EC1592F89BF2CCD31CDE480E7F3556DF41CA0E67EB6E27BEF65CAAB606E65CEA1C39191FFDFF01EE6E12C5B1A90559FAE6A1B9E96529E8EFF9032809A0248092A301257F1240712C50C2C5908E6CE8D9043E87134847261EF74C7C0031E6F6086FEB64A3A38DCA19613C21C1EE07BB1FEC7EB0FBD22E66B6FBF52595A33975ACFDD5D6F6BF95C58810A075DBF862D0FF365FE9EBFF19DD1A3137EF7686DDCDA4230AD7796961EC869661DB1FCC7F30FFC1FC1FABF947AB5CB0FDAD2066DDFBDBF0A98E00B2D8B3AA0EFB7FF8C978A91ADD7B3007BC08E63D98F760DE8379977631A37997E75F3D58337F52EE3E818A3CD6750A9D9B60E5B2BBF731E97265C5E2846B945B3007FC2D74EB8B36C833B7C0B2A400964CAA109ECF0403962CAA82BBCD59B4CC5560487AE654055A249790A9409B51A344053A548DF21468455D5BA529D012C05837FEC32EE338605B40DDA049CE365D6FE7B0F6843B0A3A2DA17DC4E138570C89D496C7B11770C131BD2C468EFAD10FF831BFEC123DB17B202F77C2967BD12CD8C3B0773DB4BDEB9FD0D2E30B2CEA8FF869987A7CC276306C070F6B3B788849EB8E696F75996FF2916EE29F4731B8CBF36F2390BE7D4CD0B23B0265B8C07D03EB241B81F46F79BE49C12EDD9723101F81A46D0A45ADB574BFDBE5C538B42FB6BB14A0E83FB03EDBA7D51EDAAD312EE67FCC35F2CF3AD06D931E8C1266701AEDDE83FB084A07E590186516862E46D5A36DB513E1355FB4AFA3B2442918C6A03F961221DAD7F007E68226DBF1DF94FDAC51A94AB4A814E02CDA55704CE8FEEADF811CEA588C74A00FE2025423F4F01BA84E415414A0A813C2BFDF1749B6817633C95CE482029CCFA0754CD4B9B12D781EA87F78DA2545B3BB48867E6CF4E10F7077B24BEA84317193325FE153B15935A0A05B39FB66BC7E2EF0222B410C2DC2C7AADAB9CC5E2385F33C5D436E47302EA770E9F7455DDBEFD9BEC589FEAFC8D3EBA8805FABA30987B076810AC482CA0FF9A6A35D08C8F0E66C2B0F73671E8F864B782131235201FE64EE938EAA08F7CA7824DB3E29E3F90A498BB99A47DA7C07905E945FC03FF749214C5EA6F5434454A2F5E72C7D76A3F2352993BB2190D96A194FE11EF563BDCEFA76EC44EADFB3B9DE9CE7C5B6FDCD78E6B7D59B0F45911757A02CA38D0A9318AF4567657996422CED9973C7730EC1EABEA8E30F3D1E97792A126291C35949884536C5E018380AF09B968817E43D1232FE94AF81F502DF3476C1C298B09C80B93B17709E94C0D9E6BC8CDA74F8A52BB819E784D9BC00553F98B97F7EF136DAF80EEBEC489F29009EB90007D28D7E7ADFD6B4744FC13D5CF2C6A27E725F29361936C4FF3DFA1EDDD4EB989745ECA67A4E8140CC76B1235EC039B6F62F11978BD90B903C40F200C98F0392237016B0782F0AF4CDFFEBB987E60FAF0FE90DB0A8DED12022CA7B154B0A173471E4C77C987B1B0C0967E8F122BB02D9DE9D0A3A12DE464E0771AD468EA8326D0F9AEF30D89217E5BB72B5D4CFF9BE3256251DD29FA2EFC9C64BD4EA174825DBB85068C37C3C6F694EA035775D25BF40F18F7967A2859D296F6BE1C2A9FF7C6927B17536172197AA0BB5B65CD61E76EFBF74B44DF03B7EEE334C4EE3AFE9AB63098DC78EFE7BB38B62F6111F57CA1F3254D7E940B28B53F37E340505E9F3E9A2560FD44E2ABB7504918E360496F74EDDFBF4B710E2BA48F202BB476015EFD6903A7B88B20D382F00FC5565B113458492740E826D7EA7A9FF9F521D2175F690A4EB0238C5B6D5E34E933872F47A223A17B17F48077F97B751B1017257A2B9A712F1FBE1A92AA293AA2A923BB894CAE7C822BE0305AE5D018815E51EF03756BCDFC0CD576D5A5C941E1A4FEB7310BCED8C19C73083BB447F2387AFE0680C8EC6E0683C0E4763BD4F088EC64E14C68EC639FC801DA39E611E223B8AF76644C750771AE6EB08510D75CDE57A5142A4512591D3CD968BF20672E21A0B8B32BEBA50F0B0FFBD281B7570A1E1EFA07789888BC357405C017105C4751C88EB328FA334247CC2573C5C24A8CCFDA4A239A33943A7E8FE43CFE68FBCE4DDD3B3C23B1765EB8F9EDF1CE34AB044B32CE12F98E7609E83793E0EF3DC1F7C06DB4CCAC38B613ECE8B10BD7CC6B928C00DB818253EC28D283784C54D5DD08D68949FC1FBF1633D65FDE5463979BB8825AD18041BD263BCD633CA11AFBF83B17AB696080A45CC05441810614084878E08F7455147E51C0712BC7D2800B804880CDF31A2B3ECB5224104F49F6CF1045A858BBD66E09D55C66FBD7391A7B80EE4FA822F8A204EB6E8D0E7BA80FF420A0C5731B888DDC411A26B1C8C73F3BCBD5364E23067DCFD48E8A2F47028044D68B6BECD5D228150B692A8BAA90A2CBCDB93CF2F24370F3825E0948053A45DCC8A535017A0A87FD3D7D1334A477B249805320710E0008A240C16C1AD84D42C36806473B79C72F5947DAEB1894D1C2BD15CC489E6E5A666542D4D7BB1F4043C08867CFCC4EAAD02A887DB1DDCAD3B85EC5751510D38C7FAAD94F3244BCA070F843A1913E14F7657DA1A546F33DD5D4B27B5BB853DF4D016DAA8D40686A26C724EC14D8880F2C8D83C50BFA6ABBBFBB058C85A35F894AB6E00CCE0C2E358A645C1610D0603440E103940E46382C847828DED4F767161A0AF9677C68F32C946271C7B5BE298CE6E51089C7CD05D9785A6959B146646A4370FC96E97641BDB4D19DDDE8999056D10DF27658C9E113B83D6C28617BABD8B929C26690A45DCBE1667CE0BDDDE8BC25873C31070DBC8D7F25538C28DA1B67A8F6195B4B0160E8AF5F04EFA667F5739EF2DDD77A79DD697EEA43A3539CBCBCA6D54D1933B373EF787CBDD18861D61D811861DE171EE08C366B09143D807D25EFA42E3B53C8B3814F4BB1E83EE55B25EA7EA286473333A15CCD6C27393A16CBDF8ECED2ECA9EAD99A1DBBBF0A2F1E2E50FE64AA5FF16B325ED915E633E03693ACA73CC633DF3DCAAC2083FDFFAF1483B3F0ED6D4DDA535CAFECED3FE63915B8FB0EB08BB8EB0EB38885D07C7B815E01E852EADA58E64C383FE8EA6C03B2EA366BC2F3AAE3832E7ED5117641176498B3A2D5BD0C9C8495CBB78478C58446B335C91A581631382A625C7F384509E00A102843A2408A50D508835FBCF0E4F08611C313871761478B8A476529625D8DEA56A278DCDCB2CE8B1EA3108B71A32E29389E17A5C000C013004C020ED6246C0407A60FEEC88819446800C62DA1E2043308DC13406D3184CA3B48B298E23FAA8D1A828121B772D43C0EDBE2788D0A9F236DA78DFEF3476CDF01AA70F78D14A26E00B421C016088690780110046001801601C13C0809FBF27F0F77BD2FA4AFDDFE8A13AAA1DA7D25ECCD3CE2E0D9E38847390F7EDFEECE0849446C02662DA5E5E7A820B4F8CA5A6B13A74D9A2F972BAA3A6F10A88794E17F4F02A225C7A7B8A431C256B45AE5375444A1025A625BDAF519AACCF8B7C2B432AFA9486248FF6698F3C3CBF5CBF3E7C993F42E348510B283CA0F080C2030A3F0014AE1F3253E4EB7D7C2CB1BC377FFFDDE08ACCC8F1378D64978C245D93635BA10F685563E084DA2E93B272A77255163B0F5492CC0391E8C99D8807587EBDBF4B93F2C10BA46B697900751759BD4CF8E32A26B3867ABA4C87726D1659948E431C391C94CF245B048EFF7EF1BE23B9AFD7A5A45E7BEFD17185A970FF00C9E6C16D43F647B21EC668974F05EC1C297CF4308C9AC41588CA7D21DF609AABC24DF22F300EE593EF515257BFA8C0D629A9AEE6B5CEB73FFC648C783F01B02E3B4F9FCB6207F9789F3F66691EAD9DC6DADA797C33ED693EAEA302FE165BFA36375888E64EAF98811CB53DA99C17E0DB228ABF5D64DF216779E1B4B3AEF7E9B7F917881E1FDD7C51B785F30BECE7706FB4777C83FD66BFDBA57627F07D4B9749BE8AB2FD7D14A37158F040B676BAB8D568EC1954B10DD4110BC5A709B8BDA71B1C38C181131C38C18123E96246070EBEEE1E8917C7DAE582CB62C97E97B94FF0824D0B362DD8B460D3A45DCC7F28116EE560BB99E55FCAF1FAD4A69559738C6740BFE3F65D75173221763718E860A08381FEB31868745A108C34259060A8A5C709693D5FB6271B747B0FDE66EB3461D2897FCB9B788B708993F57A001473BCC61010859452401401510444E101517467764782279A237887934CAABD8BA173C5361D1701D9C87E46F523927CE741F0CC07331DCC7430D3876CA6C99D97BC4B0B138EED085FAB6BDF24DB248D0A6123B5F9F7B403959B4353FBC78CCA0B6B8AADA85E9CDBB8682918BF60FC82F10BC64FDAC58CC6AF0BB33D92CDA9F586B093C392778221C42AD8B260CB822D0BB6ACFECCD8B2FAB71C4E6EFF63D50BE288AD99E53D6DDB7B67AA63593D2F2D918FC99C0BBABDFB2B95ED8BEF8E0FC6BB9E56BB5E133FC39326D984B7DDECEF2A38D6D4898B5B44E1367A7227D2CD73E92695F1DE216D4203CA25BE71DAAF7D8B829B22AE02EE0CB833E0CE03C79D1FD0CDEFCB7C7324B0B31E0E1E772E58DA4D35A1A19B6CA5CB813E8737F9BE88553CDA31A94CA16841F862D7BE7BEF9BB06F8C5C4BE0F7229563F91F2C457B15C50F4906F85B1B0F538716B7930D9685D38B2CEA574E8B210AC29B4C824B2D409B006D02B491763123B4B9CCF36F7078C7016CACFD698D141C9C693E4F6EDEFEFCB3F18FA4E61F8774364E928BACFA12651B22699D4538604766C8A26741E43CCD23961BDA4D62466960C88DCE4D05762E9490596186666B5F7A62F2A4855A375C1099EB02DC274FBE7706F5EF5989092D34BFA1FC354AF7E03C01A9FC8D7AF3DFECC0F878D4CF93B452204FBB8CF78878BD9A2970874506C6006B03AC0DB0F640616DB33268BD6863B13434D4D5CFD858903E5C3CCE3914AB6FC934C06D657BC9A66FAE7F3C67B833A82DEB916C0F60F70EBB835A12DADB031B13C63EBC62CD1E3770DA893DE9EEC592CB1F155C5AE0C1B37D8A32A96938788D4FB1EB5F1C57879C042BBB7D1522D003160B58EC98B1D8F1411A6B30330E8CB9026589DE3D3C0E08833C46C263469D64A38D341A9BAB0D662CECF06DEE9F4D15A8B1810BF9EE59E7D8D682F4691AC5DF46A47FB3BFFB0788ED6C3E5FBE2A3866EEE03ACDD7727B6473A4FA093C969700FD92CC571ABCAD4B4823143E82C3777689EF87B62E3C7C16CCBF9B5A3554A95199465B8A1FC9D4122E6CEE03170560AC0B8CAD978C9FDC73450598CD87D945FEF81D1465BDDF36009D7A91C301681F0ED0D686BA83713B12B47B9B54A9DD81FE200AA3437D8B87ADF677956F2E5538D7E601F8A7EA63B5F51FF2A7F7C49B050C695FE253ADDB26AFFA85ECC6C1CB16CC7F30FFC76AFE877DE59198FFE6DDD3A113E7B73E3F6CA38463038DF6EC350D7D4061737E8EEA3AD9AA2F60939450F85EAC67307CC1F005C3170C9FA28B190DDFE7621365C9BF6AF237A0F88E6E9B1F8705E4A989E675644624A8CC79237968F920EAFDA9EAAE9B8591BE88F34C1DE2662E5FE76090F9DFF1E1A8DEA230809ABF000B16080B42D44900052F0C40416773BFE4E90C6840E767302202408346FFAA3F2BA32654D9E88D658E94B996BBEF54CB88B0669E65D4BFCD1C765D5858BEA62979A4EF38FDDD282CB8699A3A70A3EF787AC877BB24DB9C454575DD26D93E0EFCED9C77CA3DF595BFCC555DD229274AD721C11AA61C3BD50EC8FC440DFF3159C41611ADDDD3C71D5C72B19676FDF698FB8F2FF83EC326276C72C22647DAC59C477ED8727F24908BC4DFBA8B1B0F7A9BDABBA200596CF1DED9D0D209DADC3C24F55CDA3EEA49B777CAD81A3D6FE1FC59BF2F4A3677E1644980EF34495328E0369EDF9C17BABD53007A3BDBD6CC30049607853FE5155065D333478823025B7F7B35B72D633BB5677929DCECE9DDE1D14955AC45297A920E2B44F3072C1EB078C0E20BC4E212D35BB6065DFFB0D53496AF39083F0E608F0F0975A3400BC627F270214EA2F4162A808BC316B587CB4051C9562B6D4A1FB2B5339DB33CAB8A2856DE88D32276B2AFF22F704E1FDDC20B2101775143852040C11AC4C916FD795DC07FA1DF305CC8E13A7E13478866C851160043000C01301C1E60C0238E2CB26350CD5DF6E9680E2D38689B8D909DE3043DCA18D7FDA24E0E38504370B7C02D1CB2260A01C07D526CDD82FAAEA3B27CCC8BF5C7A864EEEA594556DE80785FC0C9249640B7B7BB1EF20C7CDA6FEFD864A8AEF4BC88F0F6313F87382C2F3CC4585EE6F1B77C5F417C880CDDEF55EC6CEB3A82CEAC9DC43128CB73A87860ED1CFF20321AEA65A76B396308D3591A25C7F2D4E0B2C29A6AC9F23681563FF49A5A93A8D29C9C95665CE69B24F31EDD5653859FBF277510B846905B57B9CE4AA8519F1F3FA7564E8A33CFA693188567DA73EABDB66AFD9117DFEED3FCF12446AC9C545591DC41D07C244BCF493B1CFCF76E634BECEC089C48817851F988CF3D1CF243E0E8744CEBF92D0BD2E03EDAA795ED72CDD1DEB2B927EC82792ECAAF4999DC0D693CEC887C01D13ACF8694DA3654486535DFABD1ED5DB68BC183163C68C183163C68D22E660C7F23D7BA63814B317D423623580A1849314F5AAF68D89357DF31B6A1DDCDB13DBA08B822E08A802B02AE386E5C019568036E8B282B93230218CED0609048800742DA57519269651F3944038E9E21A87F1CE60C604D9D20446ED97FDF300098006002800900E6E801CC91C096068CCDED16A9B908B047487B6E64122C73B0CCC13207CB2CED620196B971EC1E87657636AAB530825115D23E8D76066F763BF530CE8143B0CAC12A07AB1CACB2B40BFF569973AA9A427303D6283722B3CAF90C16EE2C5BFB4663B0F3983482A117D29E7BF77CF040A327EFF68069274D5E9618AB20D5008002000A00280020691733BA25509209880A3EE56BD0FEF36B021E6D700B22A199A21B75610373BA2ECC96ADA695538ABE8E61B38E9B56061D1BA47FC453FE1159F76CA68ECD40A831894CAA40D3D99C2AEFA1E635E929121FBACCF9759347BB9D72FB6CEB041DDDB91E927F9BCE32D39DA160C9E66E733C650A73ED792513553A4C2C9B3173DC999D2A43E701CFAD209ED0FDFAC2404B739E875B65A6D34C7665B863C0DA3A4DAFEDA538D5653883C9853BE33C4EEA8E3AA6AA2A8A1FD0BABFFA9840568A676A2A3F64EBFA4516BC6A37821B90DEBFC23F5FEDD32A41495160DFBFBEFCE1D5AB378C5078F4BA9EF964FB5292FA7F6148434D0105720F4528ED485915111431AB56491627BB2865474555D5F46C2169F744E992F7600732E4B2128E59A7536C92F8FDF7DD50BF0B9544DEBDC63442AE28A769BE59A1FF9CECAB879C4E7633CC2A56059F4EFCB39196A0860CA591744134BC7174A11E884E3F035BB3CE3EDC81D62AC8F26D3A5D1A53DE76C690EABF8FA600534D7D37125D0D9875EEAFF372A289BFC6F23EF7749A8F073FE5F5300E6BBE5B2DA5A33D2CE76CD13F7CEDD999E1C78F789B4D21881C7EC87B29D606BC2A318564819156E04DEB3C7B22BA4DE128FA41B03F818E30C3D2E99349D538DBF2D1A095957C14BEA65863513102A423A88CF6147A585A0C002CCDE26C3A8379F057670F49BA46FF12AF325875624E89EF464A82B5449474A97A5215BC8709B4841EAC4E97D751D136598492A0638972D56679F2A8266F6861BCFB9CBD0729A8C08BC60D03A946651CAD596FCF6BD8B10627F809958029A2CA91299CF0804ED0F3C234EE362A3680F66C33F32C9A5CDE8CFEB9344E7BDEE7D338FEC1EEB41A8778A89F4EC8D395F0B73A8541C4181129745F7C442B153E2E9D5E312E17A83A9C6808A725EBB05467E225C7527596B0EAB46C43A807BF56A058A986E473D2F5948A6691D7095B676CF532996F3F5AC68CD150D5DAF6736BDC651E4769E7B198D5D0E19CF02893E54764EA88811D98AD433C7CC9F7159857777A364464DBC223D29A615407A33275A00528EA188A36D4AD7FFD58AC335D056266FB8FD36CE5389C53FCF02A8CA36D5C818DA46ABC6169A91BF61AF6FCBA46BD9C2C0EAF69CB892098EE1BAD68923509EF5BAC266345D3F00639817AE81DA4314F602F403B0E6F099A5CA9665B740E6BB51961A151E19FB667AE461CCF0A73888BCB0ADD178AB2E7A00C73280329FCD9956180BBBC31D8CEA1A63EC810EBD860D560CA3CA987194E6DDACCA61FE4EDA3559B5F80B807A43C64256910B34C174D025564D7CAC4CC51F54651474A1C1328A5F6153B41F71A77EA16A3A68A9359B12248A7FE4FA7A4E64A32B38E2AAE704EACA267515124107D91A312C32FAA1D77F2FBB21954D3603DF7BC4A76A39E5C058D56C696CBC5203CD935EAA52E86F303C5C9173D1BB4B88C85AEDF5FD6AFAACE16D43BC766738E805EA32D4C3F25F36B47B73E06F7C31C8A40497F7675E83CDD33781FE6F2584FEF7930F158CFEC77E0EB05D718FAC10907A12C266060369D69999C4D75DA5417ABAB687F1FC5D5BE90AC2757513654C267952C3052952EB709019ABB6FA3A807C1EC04BAC1CDDE22E80AE76D6E9568817105B664C21DF12E88A8C59950FE2E484F41066EC4949BD271763462098CAA35D8C0B4F634CA3C4EF328D01790D6C9F7B8898CAC168343D29AE5EA0B392FCB50986EB5519E9458AE3723795DB8A9D8844C8D6BE2E65DAD4CB47E810BD6A07FAA2310FDD5EACFA37387A06D73EBD9AAB9FC3BB935646E621F9B4618DEBE5E883A9C4113BCC98BE7562DBA3F557AD1D7E3CCE85066A3275D6B91BE88A8FBD51BBE1C46D51F62E0FA7AD4359B5B915652C94DA941D3AF3233688B89C9995D4548A4BFBA49B6491A151E4D904C2BA8ED1F4E8D2E3A744B24DBE90A7A24E762F645841C81F8A829E8C604BAB114A5B8D9EFA0E025BEE1BE0211E0D27F5CB811E10F6F1C2D305A1A5ABE669B7F321F77BF353EA9D95AAB3C34646B623EE9A249F6CBFCB4EA62B6C6553A4A0413A89E465A7941C71A79E417A08E8B77D82C4B0127347DF69A37B70524CFD665BF591F0BDFA20FD6A75FB0CCCFD517B250D50CD7475F9221B84FAC32D36BCB05152AD87F1D35FE427FD29C93BB7603D2E98C606F010A32F392328F8E4CBF949829C9E29611AF9E9A51B0CD3C8A34218631D3A065E19643BEC7300FD899ED0E83BED95CD60D8646D14608545F2E205E7476966506ADCBEE862DF816F4BC7A36FD4D677B755BD46A34FB7DAA79F465CE9B55FA1AB3889B5554FABAF9F6EACBCA4A37F10EDE2135DD1236F352655AC8359C85A8D45C97726C946AEEBB395CB53AF89DDCCC8A38EFBEEEF02EA85FE6F9B7FDAE8D4D6CFE106A5D5B8CCF6CF7C968E16A1A31E1877C5A9EF48237B47114021B9D9E1A0C929FEF15B2A6FFAF51BA07AD2E4CA40575971C62EDF7A3D085662CFACA309F1A5C81B28C3660F5093C9697A06232E563D38755C1670FFF6CA40E6DD7E4C5D3EEDB286A201AE438AAD08D45A7AB81B3D935E1667F57C64572278D0DEBAB90D161C3E7856B826890F36BC2C0D96C9A7081C8436923E615CF99E25589E9230B2601A55D978863213F43E1287A450C7B02CD6286A5D327AA386322B8BC4B0CD6DDD799FBC49CC312E5A0E6941FC9293A6F6C3ADD2EE43C9DA74DCB3F595F8EC24D78DA6EAB69739FBBE37C4F9F411EEF5DA823877F1A4A8C46A7BF8564932794E3205EAA9853A1A67CA7C258A3667FA682D0A50541A2A9B5645E1074A8E867DC738405ABCB0C09B90DB565197E7F4259A64F3F1A800CBFBFA5447571D563ACA0AE05EBCA1C8F5058AACCB216146677274BEA6F31BF07E3C4319ECF9936D678BB6528D16CD17D732E3873C4F619ABE8ACA17DED914893CC0D179796AE08F5C45447302E78C75E63BEF9211EF448FA810F49A73F9CC1F90EB30945996F315988A24CB698982A0B626C3E25A9730BC4BD84566769946C253B20B23AB913A2CB263FE7AC99171E74B6A5E3ECA9A8B14FA068ECD0166FBA6865AB5F20395465AB99172A5B5B7A8CCAD60CEDE0940D0DE450756DAE008E99354D3B86635645FB232FBEDDA7F96333D9AB93AA2A92BB7D255136B20531B1749111D6221BF78C483AC0EA8CA240D47026D01FD1F874BA26DBCEAE503755B401B745949549A359355BCAC4F182E65C2D60EA4CB2B4097AD7F859285A8CAAC3B4AC265466F9B07518191A2F56AD15E9CDAC17CDA0C4B32EC4EEBABB90E5186EB2CAB2D356A59AD6B5B9D3DF9638587603E5F7AC3E0DEF939B7123EBBD1045A9F57E2E3DA93B172F3EC7A625CDA00E5049867571564D71438947A13D86C06E317A44A3A9F322DF727E0EEE6BC4C1EA93FEE230A33EF5D3B63885BACD833A1D9C3AB59336BB327DBEFB0788AB55F7E74C36AEE1824BB62B3A2E8BD68E6A8186EC43EDDC856D2AD802145DB479BE06E7495156EFA32ABA8B4A76B541AD6E40D5ED08BBA0CBA680178E79133F806DF4EBCBF55D0E273EBA23E237198DA1C85755143FA028D58F4959D5CF04B11DB175B85DB2D5B43B97F6AAEA4ED9CF699A6F4EF6D5435E70FAC10B79FDE0E51AFD087A10D3D6A27A966F0562224A457DF41534BABACE4B513F4D91A893A654D1031B62C1F4C456E1F5C8D632E859D1ABBA47656FE8670FD03D81AC2AF2F43A2AE0D78A3B5C614D1E0FC2CA7AEC7C4DC063DB56CC095149C204514FAFFF4F39F23C8A3A6E4A253D3615F4872A1FA37270BA5D5DE671948A358B5B4BD23559515FB05FF2FA704B26DDB68A42C46D2D55CFFDF535B6C7BE88DB535FAAEC81974B8AD31BAF1ABF675E4D132E54DD6BF4ABDDA1A42F7937DA3DA865AA254E5D4952178D984EA9725E9754154587F45D04A647BA02AF4BBA8E669F67515124DC49646AC87AED2B29BAA52FFD31BDD215789DD27554F3D945D3B333D99570E7B02B5490BF8AB2FD7D1457FB822B46B298D71159436F3062E524CB2503D35414A27693575FDE695347D971534DAFF3E16D5051D7430D49C7432545B7F43B804CAF74055EA7741DD50FB27FBA8EFD25F645DC9F605FAA4496FDCB081C58D997F131655FACE8E4C3F71A1AF0F6174311AF8BA154D14397DA8DA1DF15F0A877655AB4DB4C6F820EDA52712F6D05D5B2D1E58F62578CAE84BB5874850AF278D633A607BC90D7095EAE54DB21A71647718742BEEA0EE506DBA21B507C4F629EE8B8B5549BA4BEA28205326514D33759CC750594BB4FA06AA21E753B1BC209851D0E55C49D7675D41D73EFA171C001A7161F20702A1AB0A0E85BDDA9AE060BB117512CD1623D73CA44AEB20E25BA867C56CD54A98DB897EA525B47DE6D7B2BC1A4EF36005BDA775B47DE771BA4AEEA5B1857C97020ACC9E34358D9881D25173A9D6BF7C99CC7083B676ACAB8602A9BB0A36242A36BED0EDBA30A61876DB9ACC3B68A6687DD2186B0C7AE82ACCBAE8EBE6F45CBA9C45454F85950251DBB81EF3F557B68696DD946537B138FEF35943B40AA9A72F3A26BC9048FAB2A76BD523EBAAABA2C688638EA2E08268B54DDAA5E24DB083D9A57EC448A77DAB2EA0F68B08ACCB14B5F8B3E2AC3AE92300738B03BD9D18CA03575F64411111D27BD2687A92102744CB1C20F74D8F1D355C4ECB3A74A35DFE2F322A635D3CED310DBE39E5543923F46A28E239B4C0BEAB8AA6F283A87B21B263A70928E71A8E07B80F82159DF8A7B00E638B45662A572887D454F8CCF30A7C45DF21682B3A3E6D41233CE3BF4AB39971DE60929E01B0B860AF710D26EF69BE563C552E7EB80A8FA4883725B042D448241A6D5D94392AED1BFB8BA21A829669F732E59F32F397014B56F1EB9D0A3E128841A387677A3146220EA4E22080E56A649C90E597D88A6BD5FA3251ADE5D1CDED044E3E10D6269A2C18EEA57C48C0A05246A31BA0671421468698B820E7C8AA791BF8978EA16A36BD11CE2A1A34D56BCCE84A2D2693DE2B079D4445139384965888DB538F1F80ECD5FA3B0C9E83F475E6C0B4E471AACE2B494D751289AF2E1D79FC4DA11513734117E248D8558F8CF127671341CB9481B48064605F534031204EC502DC5C13A2D158DE01B47D1D069DA559291A675277D1564186EE3A1E0C7D88AC52296877741682BC7845A31C9F00D5460BAD9E78EDCE7A0E1267C1765CF3A83A6AA1EEEA0E9E75965A366EA7A629FDB52B6FAF95BF8484FFFEA244DF347B0263CFEB23DA24973F190F91176F588E57173122ADC230E0E49792CE0480215EF2C4D9A8B45211EBC74B80B16671BC148A596E6AE51AA26EA21535197C43005A1947EF4D9C33A464D807A319326C0F7AC53D3AE6DBDB1AA231244BE4F4EAD295C9E9319753A57BF4C04D2BCFE0765D63B54AA36EA54CD314DFAF4F09DFA49E94A41F02CB59F5FF24CA2E9DE77BB8AB0706E5620BC6A62F679D1E535F7B2A871725925A30E9A0555103C603DE821A67B4585970B05206CA21C0ACF42C862DAC534F06868960E37E0D98788E8D0701D19516DBCCCF79204D329816C33206F30A1DE48642C0F10F2262431C0973718596FA6174CFB38BCFAB744551C4D10CC01ABF72177F758DA110DD75A846317B5500E86BE79830F48749D464647241CE1D51C07BDA0294B3483AA3A995846D213D256AC6E926D924685E427226FE0FFA7C2BF605537575C9BB2D7079230779B22AA7A1C02182E8A8947DED791F81EA88B6A8DD74170096D42A52763687BC3575FA7006B09AAD06B281E16FF4E6B3D3AF94D5509159EA80435C6169C1869E835F4FFE3994F54E466969E5DD5E657FE70A8778D9A6EE7DB5F0F5D5194796191FCAADE874179D5A8ABAFAD3B4D74ABD545046AAD10D61D5B23A61483046DB095FCAF11E30F95FC6D6B7BC579D5A7F1894FED1C34F00BF31B1C4F98037D28A32B09A57EF839D89C4B2CAA1313ACD6942726138B813EF417DA4E8D56E39AD145044FD103D73D7B10B59BF808626EB19919AA39CF70A7165793BDA3759175094358F9F0AA890743662BA9D9E7E722E1B4629C65822C26B643AD1395B403118F94A835CE4089842B58537E2615F3E1B6495356785E1376B89C5A62C6D9FC2A35DFE2CC29E4A91E99FCA539D0136476B11F2E9E5E453C5CAC96CCE943A77969DD3EA2042E130E174FBC22BE8FC7A925669897EAA5E69A2C900C5994BF85A032147A086362F2AC68EC44355A8DBD2795E49B6961AC3A818C1F714976ACB2EAFEF7AEF38B44233A5956DDFFC68D97128891856F21C882D3F91565A0C636367D96A19B2D1D73AE19938944099C25B5C705CCB38843C3BB23AD7F246B84DAB323AB3EB66367269130E649473D388D3C0F6C694656E4FE622B4DE1FD9A4C57B074792B32BF054714C2CA7A22B14BA6C14B0988EF77BCDD3DC04727D406A6D224DA309108E837C1BBBC82AC1C04352576849F6AB1B1277499E6568EC89FC8ECE5DA52EF42E9121EAA85D2D69C562844624746286DA977A1203EB464D2549C5624536CF9C5AF9C7384A2F9243A31207E8EB87A38F23C94122A4C1A4E0E39714E4D7B21295EEE9648CCE4CD6FEEC005C93789812B3269EAD0D5982D458BD1852D0E25B279897A445D5DAE68C9278F259294BC8DCC1D32912295181A37F3A91FE13B0BA27DD2572907DED3BFA38981486FCB6A897721E04FD62A25217CDF765C71B8AD7F1ED7A2E13556836548F084AB8FD93F009175EF8D1A088CFB44E9918A8B7E51532226E9E39BA3FD00C964D40411418A69B130DEBD6EA8F4EF45F665EF5E37B980DB0FF0CF2A2FA0CCAFF23548CBFAEBBBD75FF6B0F516347FBD0765B21948BC83343350DB89816857E722BBCFAFDBA732298EBA2A5D717F0A5A45EBA88A4E8A2A41172561710CCA32C9362F5FD407CBBFBEFCB0BD03EB8BECF3BEDAED2B3864B0BD4B09673C7A6E53D6FFBBD70CCFEFDA2C003E8600D94CE010C0E7EC749FA4EB9EEFF3282DA95F8688047AC7F33700BF37735915E876CA734FE9539E69126AC5D73F3F7A0BB63B7451A1FC9CDD44DF810D6F702F74093651FC0CBF7F4FEAE0231111F54490627FF73E893645B42D5B1A437BF827D4E1F5F6E9BFFFFF246B4738DE430800 , N'6.2.0-61023')

