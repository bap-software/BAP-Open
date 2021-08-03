namespace BAP.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        CompanyName = c.String(maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        AddressLine1 = c.String(nullable: false, maxLength: 80),
                        AddressLine2 = c.String(maxLength: 80),
                        City = c.String(nullable: false, maxLength: 80),
                        County = c.String(maxLength: 80),
                        State = c.String(nullable: false, maxLength: 80),
                        Country = c.String(nullable: false, maxLength: 80),
                        Zip = c.String(nullable: false, maxLength: 5),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        PhoneExtension = c.String(maxLength: 5),
                        FaxNumber = c.String(maxLength: 20),
                        CellNumber = c.String(maxLength: 20),
                        ContactEmail = c.String(nullable: false, maxLength: 255),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_AddressName")
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.AttachmentHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        FileName = c.String(),
                        FilePath = c.String(),
                        Length = c.Long(),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                        Attachment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attachment", t => t.Attachment_Id)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions)
                .Index(t => t.Attachment_Id);
            
            CreateTable(
                "dbo.Attachment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(maxLength: 1024),
                        AttachmentType = c.String(maxLength: 255),
                        Object = c.String(maxLength: 255),
                        ObjectId = c.Int(nullable: false),
                        PathUrl = c.String(maxLength: 255),
                        Status = c.String(maxLength: 80),
                        StatusDate = c.DateTime(nullable: false),
                        Published = c.Boolean(),
                        PublishFrom = c.DateTime(),
                        PublishTo = c.DateTime(),
                        MimeType = c.String(maxLength: 255),
                        PathAliases = c.String(),
                        AltText = c.String(maxLength: 255),
                        TitleText = c.String(maxLength: 255),
                        Keywords = c.String(maxLength: 255),
                        IsSecured = c.Boolean(),
                        AllowedToRoles = c.String(maxLength: 1024),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        Length = c.Long(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.Name, t.AttachmentType, t.Object, t.ObjectId, t.TenantUnit, t.TenantUnitId }, unique: true, name: "IX_AttachmentNameObect")
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.AttachmentAccess",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        AttachmentId = c.Int(),
                        PublicAccessToken = c.String(maxLength: 1024),
                        AccessTokenExpiresAt = c.DateTime(),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attachment", t => t.AttachmentId)
                .Index(t => t.AttachmentId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.BlogAuthor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NickName = c.String(maxLength: 80),
                        FirstName = c.String(maxLength: 80),
                        LastName = c.String(maxLength: 80),
                        Email = c.String(maxLength: 256),
                        WebSite = c.String(maxLength: 256),
                        OrganizationUserId = c.Int(),
                        CultureCode = c.String(maxLength: 10),
                        LocalizationId = c.Guid(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrganizationUser", t => t.OrganizationUserId)
                .Index(t => new { t.FirstName, t.LastName }, unique: true, name: "IX_BlogAuthorName")
                .Index(t => t.OrganizationUserId)
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Description = c.String(maxLength: 4000),
                        MainImageUrl = c.String(maxLength: 1024),
                        BlogAuthorId = c.Int(),
                        Tags = c.String(maxLength: 256),
                        CultureCode = c.String(maxLength: 10),
                        CategoryCode = c.String(maxLength: 10),
                        FacebookUrl = c.String(maxLength: 255),
                        TwitterUrl = c.String(maxLength: 255),
                        LinkedinUrl = c.String(maxLength: 255),
                        GoogleplusUrl = c.String(maxLength: 255),
                        InstagramUrl = c.String(maxLength: 255),
                        LocalizationId = c.Guid(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogAuthor", t => t.BlogAuthorId)
                .Index(t => t.Name, unique: true, name: "IX_BlogName")
                .Index(t => t.BlogAuthorId)
                .Index(t => t.CultureCode)
                .Index(t => t.CategoryCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.BlogComment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentCommentId = c.Int(),
                        Title = c.String(maxLength: 80),
                        Author = c.String(maxLength: 80),
                        Text = c.String(maxLength: 4000),
                        BlogId = c.Int(),
                        BlogPostId = c.Int(),
                        LikeNumber = c.Int(nullable: false),
                        DislikeNumber = c.Int(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                        NotifyAuthorByEmail = c.Boolean(nullable: false),
                        CommentAuthorUserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blog", t => t.BlogId)
                .ForeignKey("dbo.BlogComment", t => t.ParentCommentId)
                .ForeignKey("dbo.BlogPost", t => t.BlogPostId)
                .ForeignKey("dbo.OrganizationUser", t => t.CommentAuthorUserId)
                .Index(t => t.ParentCommentId)
                .Index(t => new { t.Title, t.Author, t.BlogId }, unique: true, name: "IX_BlogComment")
                .Index(t => t.BlogPostId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions)
                .Index(t => t.CommentAuthorUserId);
            
            CreateTable(
                "dbo.BlogPost",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Text = c.String(maxLength: 4000),
                        MainImageUrl = c.String(maxLength: 1024),
                        BlogId = c.Int(),
                        CultureCode = c.String(maxLength: 10),
                        LocalizationId = c.Guid(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blog", t => t.BlogId)
                .Index(t => new { t.Title, t.ShortDescription }, unique: true, name: "IX_BlogPost")
                .Index(t => t.BlogId)
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.OrganizationUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsBuiltIn = c.Boolean(nullable: false),
                        AspNetUserId = c.String(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        FirstName = c.String(maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        AddressLine1 = c.String(maxLength: 80),
                        AddressLine2 = c.String(maxLength: 80),
                        City = c.String(maxLength: 80),
                        County = c.String(maxLength: 80),
                        State = c.String(maxLength: 80),
                        Country = c.String(maxLength: 80),
                        Zip = c.String(maxLength: 5),
                        PhoneNumber = c.String(maxLength: 20),
                        CellNumber = c.String(maxLength: 20),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        UserName = c.String(),
                        Organization_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organization", t => t.Organization_Id)
                .Index(t => new { t.FirstName, t.MiddleName, t.LastName }, unique: true, name: "IX_OrgUserName")
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions)
                .Index(t => t.Organization_Id);
            
            CreateTable(
                "dbo.Organization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 80),
                        Description = c.String(maxLength: 255),
                        TaxId = c.String(maxLength: 80),
                        Status = c.String(maxLength: 80),
                        StatusDate = c.DateTime(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OrganizationType = c.Int(nullable: false),
                        AddressLine1 = c.String(maxLength: 80),
                        AddressLine2 = c.String(maxLength: 80),
                        City = c.String(maxLength: 80),
                        County = c.String(maxLength: 80),
                        State = c.String(maxLength: 80),
                        Country = c.String(maxLength: 80),
                        Zip = c.String(maxLength: 5),
                        PhoneNumber = c.String(maxLength: 20),
                        PhoneExtension = c.String(maxLength: 5),
                        FaxNumber = c.String(maxLength: 20),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                        LogoPathUrl = c.String(maxLength: 255),
                        FacebookUrl = c.String(maxLength: 255),
                        TwitterUrl = c.String(maxLength: 255),
                        LinkedinUrl = c.String(maxLength: 255),
                        GoogleplusUrl = c.String(maxLength: 255),
                        InstagramUrl = c.String(maxLength: 255),
                        Url = c.String(maxLength: 255),
                        BlogUrl = c.String(maxLength: 255),
                        ContactEmail = c.String(maxLength: 255),
                        SupportEmail = c.String(maxLength: 255),
                        ImplementedCulturesText = c.String(maxLength: 255),
                        HostName = c.String(maxLength: 255),
                        HostNameAliasesText = c.String(maxLength: 2048),
                        BapDefaultFromEmail = c.String(maxLength: 255),
                        BapDefaultContactEmail = c.String(maxLength: 255),
                        SmtpUserName = c.String(maxLength: 255),
                        SmtpUserPassword = c.String(maxLength: 255),
                        SmtpHostName = c.String(maxLength: 255),
                        SmtpPort = c.Int(nullable: false),
                        SmtpUseSsl = c.Boolean(nullable: false),
                        reCaptchaSiteKey = c.String(maxLength: 255),
                        reCaptchaSecretKey = c.String(maxLength: 255),
                        GetBearrerTokenDuringLogin = c.Boolean(nullable: false),
                        AuthCookieName = c.String(maxLength: 255),
                        AuthCookieExpirationTime = c.Int(nullable: false),
                        WebApiPublicClientId = c.String(maxLength: 255),
                        BearerTokenExpirationTime = c.Int(nullable: false),
                        WebApiAllowInsecureHttp = c.Boolean(nullable: false),
                        PublicFolderText = c.String(maxLength: 255),
                        BaseFolderText = c.String(maxLength: 255),
                        CookiesPopupEnabled = c.Boolean(nullable: false),
                        GdprPopupEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_OrganizationName")
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.OrganizationModule",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 80),
                        ModuleId = c.Int(),
                        OrganizationId = c.Int(),
                        Enabled = c.Boolean(nullable: false),
                        Order = c.Int(nullable: false),
                        UrlAlias = c.String(maxLength: 512),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Module", t => t.ModuleId)
                .ForeignKey("dbo.Organization", t => t.OrganizationId)
                .Index(t => t.Name, unique: true, name: "IX_Module")
                .Index(t => t.ModuleId)
                .Index(t => t.OrganizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.Module",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Description = c.String(maxLength: 4000),
                        Enabled = c.Boolean(nullable: false),
                        GlobalId = c.Guid(nullable: false),
                        Roles = c.String(maxLength: 200),
                        BitMask = c.Int(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_Module")
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.Subscription",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubscriptionType = c.String(maxLength: 20),
                        OrganizationId = c.Int(),
                        UserId = c.Int(),
                        InitialTerm = c.Int(nullable: false),
                        TermStart = c.DateTime(nullable: false),
                        TermEnd = c.DateTime(nullable: false),
                        ContractDate = c.DateTime(nullable: false),
                        AutoRenew = c.Boolean(nullable: false),
                        RenewalTerm = c.Int(nullable: false),
                        SubTotal = c.Decimal(precision: 18, scale: 2),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organization", t => t.OrganizationId)
                .ForeignKey("dbo.OrganizationUser", t => t.UserId)
                .Index(t => t.OrganizationId)
                .Index(t => t.UserId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.BlogCommentUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentId = c.Int(),
                        AspNetUserId = c.String(),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        LikeNumber = c.Int(nullable: false),
                        DislikeNumber = c.Int(nullable: false),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogComment", t => t.CommentId)
                .Index(t => t.CommentId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.ContentControlParameter",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Description = c.String(),
                        ContentViewControlId = c.Int(),
                        ParameterName = c.String(maxLength: 40),
                        DataType = c.String(maxLength: 40),
                        DataSource = c.String(maxLength: 512),
                        DefaultValue = c.String(maxLength: 1024),
                        IsRequired = c.Boolean(nullable: false),
                        IsReadOnly = c.Boolean(nullable: false),
                        IsVisible = c.Boolean(nullable: false),
                        PlaceHolder = c.String(maxLength: 80),
                        Caption = c.String(maxLength: 40),
                        FormControl = c.String(maxLength: 80),
                        DefaultErrorMessage = c.String(maxLength: 256),
                        CssClass = c.String(maxLength: 80),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContentViewControl", t => t.ContentViewControlId)
                .Index(t => t.Name, name: "IX_ContentControlParameterName")
                .Index(t => t.ContentViewControlId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_ContentControlParameterTenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.ContentViewControl",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 80),
                        Description = c.String(),
                        ContentNodeId = c.Int(),
                        ContentViewId = c.Int(),
                        ContentControlId = c.Int(),
                        ControlType = c.String(maxLength: 80),
                        ControlId = c.String(maxLength: 80),
                        ControlTitle = c.String(maxLength: 40),
                        IsVisible = c.Boolean(nullable: false),
                        IsReadOnly = c.Boolean(nullable: false),
                        ContainerTag = c.String(maxLength: 20),
                        ContainerCss = c.String(maxLength: 40),
                        ContainerContent = c.String(maxLength: 1024),
                        ContentBefore = c.String(maxLength: 1024),
                        ContentAfter = c.String(maxLength: 1024),
                        JavaScript = c.String(),
                        StyleContent = c.String(),
                        CultureCode = c.String(maxLength: 10),
                        LocalizationId = c.Guid(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContentControl", t => t.ContentControlId)
                .ForeignKey("dbo.ContentNode", t => t.ContentNodeId)
                .ForeignKey("dbo.ContentView", t => t.ContentViewId)
                .Index(t => t.Name, name: "IX_ContentViewControlName")
                .Index(t => t.ContentNodeId)
                .Index(t => t.ContentViewId)
                .Index(t => t.ContentControlId)
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_ContentViewControlTenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.ContentControl",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        Description = c.String(maxLength: 1024),
                        IsEnabled = c.Boolean(nullable: false),
                        ContentControlTypeId = c.Int(),
                        DisplayName = c.String(maxLength: 50),
                        HasDialog = c.Boolean(nullable: false),
                        HasCKEditor = c.Boolean(nullable: false),
                        ContentBefore = c.String(maxLength: 1024),
                        ContentAfter = c.String(maxLength: 1024),
                        MainCss = c.String(maxLength: 50),
                        IconCss = c.String(maxLength: 50),
                        ContainerTag = c.String(maxLength: 20),
                        DialogContent = c.String(maxLength: 1024),
                        ContentHolderFieldId = c.String(maxLength: 50),
                        JavaScriptContent = c.String(maxLength: 1024),
                        CultureCode = c.String(maxLength: 10),
                        LocalizationId = c.Guid(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContentControlType", t => t.ContentControlTypeId)
                .Index(t => t.Name, unique: true, name: "IX_ContentControlTypeName")
                .Index(t => t.ContentControlTypeId)
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.ContentControlType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        Description = c.String(maxLength: 1024),
                        IsEnabled = c.Boolean(nullable: false),
                        CultureCode = c.String(maxLength: 10),
                        LocalizationId = c.Guid(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_ContentControlTypeName")
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.ContentNode",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Description = c.String(),
                        Alias = c.String(nullable: false, maxLength: 80),
                        AliasPath = c.String(nullable: false, maxLength: 1024),
                        IsHome = c.Boolean(nullable: false),
                        ShowInMenu = c.Boolean(nullable: false),
                        ShowInSitemap = c.Boolean(nullable: false),
                        ContentDescription = c.String(maxLength: 256),
                        ContentKeywords = c.String(maxLength: 256),
                        ContentAuthor = c.String(maxLength: 128),
                        LayoutPath = c.String(maxLength: 1024),
                        NavigationType = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Culture = c.String(maxLength: 20),
                        Area = c.String(maxLength: 80),
                        Controller = c.String(maxLength: 80),
                        Action = c.String(maxLength: 80),
                        ActionParams = c.String(maxLength: 256),
                        View = c.String(maxLength: 80),
                        RouteUrl = c.String(maxLength: 256),
                        NameSpaces = c.String(maxLength: 256),
                        Enabled = c.Boolean(nullable: false),
                        DefaultCss = c.String(maxLength: 80),
                        UrlAliases = c.String(),
                        ContentTitle = c.String(maxLength: 80),
                        ContentTagGroup = c.String(maxLength: 80),
                        ContentTags = c.String(maxLength: 256),
                        SitemapPriority = c.Int(nullable: false),
                        SitemapChangeFrequency = c.Int(nullable: false),
                        MenuCaption = c.String(maxLength: 80),
                        Roles = c.String(maxLength: 256),
                        AllowChildren = c.Boolean(nullable: false),
                        MenuClicable = c.Boolean(nullable: false),
                        MenuIcon = c.String(maxLength: 256),
                        UrlTarget = c.String(maxLength: 40),
                        MenuExtraAttributes = c.String(maxLength: 512),
                        HttpMethod = c.String(maxLength: 10),
                        MenuSortOrder = c.Int(nullable: false),
                        ParentNodeId = c.Int(),
                        CultureCode = c.String(maxLength: 10),
                        LocalizationId = c.Guid(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                        PageSettingsJson = c.String(maxLength: 2048),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContentNode", t => t.ParentNodeId)
                .Index(t => t.Name, unique: true, name: "IX_ContentNodeName")
                .Index(t => new { t.Area, t.Controller, t.Action, t.View }, unique: true, name: "IX_ContentNodeRoute")
                .Index(t => t.ParentNodeId)
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_ContentNodeTenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.ContentView",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 80),
                        Description = c.String(),
                        ViewName = c.String(maxLength: 80),
                        ViewPath = c.String(maxLength: 1024),
                        LayoutPath = c.String(maxLength: 1024),
                        ViewContent = c.String(),
                        Roles = c.String(maxLength: 80),
                        IsPartial = c.Boolean(nullable: false),
                        IsShared = c.Boolean(nullable: false),
                        IsMain = c.Boolean(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        IsLayout = c.Boolean(nullable: false),
                        CultureCode = c.String(maxLength: 10),
                        LocalizationId = c.Guid(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_ContentViewName")
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_ContentViewTenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.ContentLocalization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 80),
                        CultureCode = c.String(maxLength: 20),
                        LocalizationId = c.Guid(nullable: false),
                        ContentNodeId = c.Int(),
                        Text = c.String(),
                        IsDefault = c.Boolean(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContentNode", t => t.ContentNodeId)
                .Index(t => t.Name, name: "IX_ContentLocalizationName")
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => t.ContentNodeId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_ContentLocalizationTenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.ContentNodeRoute",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 80),
                        Description = c.String(),
                        ContentNodeId = c.Int(),
                        RouteName = c.String(maxLength: 80),
                        Controller = c.String(maxLength: 80),
                        Action = c.String(maxLength: 80),
                        Area = c.String(maxLength: 80),
                        DataTokens = c.String(maxLength: 256),
                        RouteParameters = c.String(maxLength: 1024),
                        NameSpaces = c.String(maxLength: 1024),
                        Url = c.String(maxLength: 1024),
                        Roles = c.String(maxLength: 256),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContentNode", t => t.ContentNodeId)
                .Index(t => t.Name, name: "IX_ContentNodeRouteName")
                .Index(t => t.ContentNodeId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_ContentNodeRouteTenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        ShortName = c.String(nullable: false, maxLength: 64),
                        Description = c.String(maxLength: 1024),
                        TwoLetterCode = c.String(nullable: false, maxLength: 5),
                        ThreeLetterCode = c.String(nullable: false, maxLength: 5),
                        FlagSvg11Path = c.String(maxLength: 512),
                        FlagSvg43Path = c.String(maxLength: 512),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TwoLetterCode, unique: true, name: "IX_CountryTwoLetterCode")
                .Index(t => t.ThreeLetterCode, unique: true, name: "IX_CountryThreeLetterCode")
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        ShortName = c.String(nullable: false, maxLength: 64),
                        Description = c.String(maxLength: 1024),
                        TwoLetterCode = c.String(nullable: false, maxLength: 5),
                        ThreeLetterCode = c.String(maxLength: 5),
                        CountryId = c.Int(),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .Index(t => t.TwoLetterCode, unique: true, name: "IX_StateTwoLetterCode")
                .Index(t => t.ThreeLetterCode, unique: true, name: "IX_StateThreeLetterCode")
                .Index(t => t.CountryId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.Currency",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThreeLetterCode = c.String(nullable: false, maxLength: 5),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 255),
                        ExchangeRate = c.Decimal(precision: 18, scale: 2),
                        Symbol = c.String(nullable: false, maxLength: 5),
                        IsMain = c.Boolean(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                        RoundTo = c.Int(nullable: false),
                        FormatString = c.String(maxLength: 20),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ThreeLetterCode, unique: true, name: "IX_CurrencyCode")
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.CustomConfiguration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 80),
                        AssemblyName = c.String(maxLength: 256),
                        ClassName = c.String(maxLength: 256),
                        DefaultConfiguration = c.String(maxLength: 4000),
                        CurrentConfiguration = c.String(maxLength: 4000),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_CustomConfigurationName")
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.CustomerOrderPayment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReferenceId = c.String(maxLength: 512),
                        CustomerOrderId = c.Int(),
                        PaymentOptionId = c.Int(nullable: false),
                        CustomerPaymentId = c.Int(),
                        PaymentStatus = c.Int(nullable: false),
                        AttemptNo = c.Int(nullable: false),
                        Started = c.DateTime(nullable: false),
                        Finished = c.DateTime(nullable: false),
                        PaymentIntent = c.Int(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                        Total = c.Single(nullable: false),
                        IsError = c.Boolean(nullable: false),
                        ErrorCode = c.String(maxLength: 40),
                        ErrorDescription = c.String(maxLength: 512),
                        PaymentNotes = c.String(maxLength: 256),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currency", t => t.CurrencyId, cascadeDelete: true)
                .ForeignKey("dbo.CustomerOrder", t => t.CustomerOrderId)
                .ForeignKey("dbo.CustomerPayment", t => t.CustomerPaymentId)
                .ForeignKey("dbo.PaymentOption", t => t.PaymentOptionId, cascadeDelete: true)
                .Index(t => t.CustomerOrderId)
                .Index(t => t.PaymentOptionId)
                .Index(t => t.CustomerPaymentId)
                .Index(t => t.CurrencyId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_CustomerOrderPaymentTenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.CustomerOrder",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Description = c.String(),
                        CustomerId = c.Int(),
                        CustomerPaymentId = c.Int(),
                        UserId = c.Int(),
                        CurrencyId = c.Int(nullable: false),
                        ShippingOptionId = c.Int(),
                        PaymentOptionId = c.Int(),
                        DiscountCouponId = c.Int(),
                        BillingAddressId = c.Int(nullable: false),
                        ShippingAddressId = c.Int(nullable: false),
                        Coupon = c.String(maxLength: 200),
                        Notes = c.String(maxLength: 1024),
                        CustomData = c.String(maxLength: 1024),
                        Subtotal = c.Single(nullable: false),
                        Total = c.Single(nullable: false),
                        DiscountsTotal = c.Single(nullable: false),
                        ShippingCost = c.Single(nullable: false),
                        TaxTotal = c.Single(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.BillingAddressId)
                .ForeignKey("dbo.Currency", t => t.CurrencyId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .ForeignKey("dbo.CustomerPayment", t => t.CustomerPaymentId)
                .ForeignKey("dbo.DiscountCoupon", t => t.DiscountCouponId)
                .ForeignKey("dbo.PaymentOption", t => t.PaymentOptionId)
                .ForeignKey("dbo.Address", t => t.ShippingAddressId)
                .ForeignKey("dbo.ShippingOption", t => t.ShippingOptionId)
                .ForeignKey("dbo.OrganizationUser", t => t.UserId)
                .Index(t => t.Name, unique: true, name: "IX_CustomerOrderName")
                .Index(t => t.CustomerId)
                .Index(t => t.CustomerPaymentId)
                .Index(t => t.UserId)
                .Index(t => t.CurrencyId)
                .Index(t => t.ShippingOptionId)
                .Index(t => t.PaymentOptionId)
                .Index(t => t.DiscountCouponId)
                .Index(t => t.BillingAddressId)
                .Index(t => t.ShippingAddressId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_CustomerOrderTenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Description = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        BillingAddressId = c.Int(),
                        ShippingAddressId = c.Int(),
                        CompanyAddressId = c.Int(),
                        Email = c.String(nullable: false, maxLength: 200),
                        PhoneNumber = c.String(nullable: false, maxLength: 200),
                        PhoneExtension = c.String(maxLength: 5),
                        CellNumber = c.String(maxLength: 20),
                        FaxNumber = c.String(maxLength: 20),
                        CompanyName = c.String(maxLength: 50),
                        LoginUserId = c.Int(),
                        CustomData = c.String(maxLength: 1024),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                        PrefferedShippingOptionId = c.Int(),
                        PrefferedCurrencyId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.BillingAddressId)
                .ForeignKey("dbo.Address", t => t.CompanyAddressId)
                .ForeignKey("dbo.OrganizationUser", t => t.LoginUserId)
                .ForeignKey("dbo.Currency", t => t.PrefferedCurrencyId)
                .ForeignKey("dbo.ShippingOption", t => t.PrefferedShippingOptionId)
                .ForeignKey("dbo.Address", t => t.ShippingAddressId)
                .Index(t => t.Name, unique: true, name: "IX_CustomerName")
                .Index(t => t.BillingAddressId)
                .Index(t => t.ShippingAddressId)
                .Index(t => t.CompanyAddressId)
                .Index(t => t.LoginUserId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_CustomerTenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions)
                .Index(t => t.PrefferedShippingOptionId)
                .Index(t => t.PrefferedCurrencyId);
            
            CreateTable(
                "dbo.CustomerPayment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Description = c.String(),
                        CustomerId = c.Int(),
                        PaymentOptionId = c.Int(nullable: false),
                        AccountReferenceId = c.String(maxLength: 512),
                        LastUsed = c.DateTime(),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .ForeignKey("dbo.PaymentOption", t => t.PaymentOptionId, cascadeDelete: true)
                .Index(t => t.Name, unique: true, name: "IX_CustomerPaymentName")
                .Index(t => t.CustomerId)
                .Index(t => t.PaymentOptionId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_CustomerPaymentTenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.PaymentOption",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        Enabled = c.Boolean(nullable: false),
                        AsssemblyName = c.String(maxLength: 256),
                        ClassName = c.String(maxLength: 256),
                        PaymentContainerCss = c.String(maxLength: 40),
                        CustomConfigJson = c.String(),
                        CultureCode = c.String(maxLength: 10),
                        LocalizationId = c.Guid(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_PaymentOptionName")
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.ShippingOption",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        Enabled = c.Boolean(nullable: false),
                        CustomConfigJson = c.String(),
                        MaxPrice = c.Single(),
                        CultureCode = c.String(maxLength: 10),
                        LocalizationId = c.Guid(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                        ShippingCarrierId = c.Int(nullable: false),
                        TeaserImage = c.String(maxLength: 256),
                        OptionCode = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShippingCarrier", t => t.ShippingCarrierId, cascadeDelete: true)
                .Index(t => t.Name, unique: true, name: "IX_ShippingOptionName")
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions)
                .Index(t => t.ShippingCarrierId);
            
            CreateTable(
                "dbo.ShippingCarrier",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        Enabled = c.Boolean(nullable: false),
                        CustomConfigJson = c.String(),
                        CultureCode = c.String(maxLength: 10),
                        LocalizationId = c.Guid(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                        ShippingProviderAssembly = c.String(maxLength: 1024),
                        ShippingProviderClass = c.String(maxLength: 80),
                        TeaserImage = c.String(maxLength: 256),
                        OptionCode = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_ShippingCarrierName")
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.Store",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        InvoiceTemplate = c.String(maxLength: 80),
                        OrganizationId = c.Int(nullable: false),
                        AdminUserId = c.Int(nullable: false),
                        BillingAddressId = c.Int(),
                        ShippingAddressId = c.Int(),
                        IsDefault = c.Boolean(nullable: false),
                        IsUnregisteredCheckoutAllowed = c.Boolean(nullable: false),
                        QuickShoppingCart = c.Boolean(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrganizationUser", t => t.AdminUserId, cascadeDelete: true)
                .ForeignKey("dbo.Address", t => t.BillingAddressId)
                .ForeignKey("dbo.Organization", t => t.OrganizationId, cascadeDelete: true)
                .ForeignKey("dbo.Address", t => t.ShippingAddressId)
                .Index(t => t.Name, unique: true, name: "IX_DiscountCouponName")
                .Index(t => t.OrganizationId)
                .Index(t => t.AdminUserId)
                .Index(t => t.BillingAddressId)
                .Index(t => t.ShippingAddressId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.DiscountCoupon",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        Enabled = c.Boolean(nullable: false),
                        IsPercent = c.Boolean(nullable: false),
                        Amount = c.Single(nullable: false),
                        Code = c.String(maxLength: 200),
                        ExtraCodesText = c.String(),
                        CustomData = c.String(),
                        DiscountType = c.Int(nullable: false),
                        ValidFrom = c.DateTime(nullable: false),
                        ValidTo = c.DateTime(nullable: false),
                        Priority = c.Int(nullable: false),
                        AllowLowerPriority = c.Boolean(nullable: false),
                        CultureCode = c.String(maxLength: 10),
                        LocalizationId = c.Guid(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                        BuyXAmount = c.Int(),
                        GetYAmount = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_DiscountCouponName")
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SKU = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 80),
                        ShortDescription = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        SourcePrice = c.Single(nullable: false),
                        Price = c.Single(nullable: false),
                        ListPrice = c.Single(nullable: false),
                        MsrpPrice = c.Single(nullable: false),
                        MinPrice = c.Single(nullable: false),
                        MaxPrice = c.Single(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        PublishFrom = c.DateTime(nullable: false),
                        PublishTo = c.DateTime(nullable: false),
                        InStoreFrom = c.DateTime(nullable: false),
                        PublicStatus = c.String(maxLength: 50),
                        InternalStatus = c.String(maxLength: 50),
                        ImagePath = c.String(maxLength: 512),
                        UID = c.Guid(nullable: false),
                        Weight = c.Single(nullable: false),
                        Width = c.Single(nullable: false),
                        Depth = c.Single(nullable: false),
                        Height = c.Single(nullable: false),
                        WeightMeasure = c.String(maxLength: 50),
                        SizeMeasure = c.String(maxLength: 50),
                        AvailableItems = c.Int(nullable: false),
                        CustomData = c.String(maxLength: 2048),
                        NeedsShipping = c.Boolean(nullable: false),
                        MaxDownloads = c.Int(nullable: false),
                        ProductType = c.String(maxLength: 50),
                        ParentProductId = c.Int(),
                        ReorderAt = c.DateTime(nullable: false),
                        TrackInventory = c.Boolean(nullable: false),
                        AllowToRenew = c.Boolean(nullable: false),
                        IsTrial = c.Boolean(nullable: false),
                        IsFeatured = c.Boolean(nullable: false),
                        IsOnline = c.Boolean(nullable: false),
                        BaseOnlineUrl = c.String(),
                        IsDownloadable = c.Boolean(nullable: false),
                        SupplierId = c.Int(),
                        ManufacturerId = c.Int(),
                        ProductCategoryId = c.Int(),
                        CultureCode = c.String(maxLength: 10),
                        LocalizationId = c.Guid(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                        CustomDetailsUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturer", t => t.ManufacturerId)
                .ForeignKey("dbo.Product", t => t.ParentProductId)
                .ForeignKey("dbo.ProductCategory", t => t.ProductCategoryId)
                .ForeignKey("dbo.Supplier", t => t.SupplierId)
                .Index(t => t.Name, unique: true, name: "IX_ProductName")
                .Index(t => t.ParentProductId)
                .Index(t => t.SupplierId)
                .Index(t => t.ManufacturerId)
                .Index(t => t.ProductCategoryId)
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.Manufacturer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        LogoImage = c.String(maxLength: 1024),
                        Slogan = c.String(maxLength: 80),
                        CultureCode = c.String(maxLength: 10),
                        LocalizationId = c.Guid(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_ManufacturerName")
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.ProductOption",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        ShortDescription = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        Type = c.Int(nullable: false),
                        UserControl = c.Int(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        CultureCode = c.String(maxLength: 10),
                        LocalizationId = c.Guid(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_ProductOptionName")
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.ProductOptionItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        ShortDescription = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        RelatedProductId = c.Int(),
                        ProductOptionId = c.Int(),
                        PriceAdded = c.Single(nullable: false),
                        CultureCode = c.String(maxLength: 10),
                        LocalizationId = c.Guid(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductOption", t => t.ProductOptionId)
                .ForeignKey("dbo.Product", t => t.RelatedProductId)
                .Index(t => new { t.Name, t.ProductOptionId }, unique: true, name: "IX_ProductOptionItemName")
                .Index(t => t.RelatedProductId)
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentCategoryId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 80),
                        ShortDescription = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        Order = c.Int(),
                        CultureCode = c.String(maxLength: 10),
                        LocalizationId = c.Guid(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategory", t => t.ParentCategoryId)
                .Index(t => t.ParentCategoryId)
                .Index(t => t.Name, unique: true, name: "IX_ProductCategoryName")
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.RelatedProduct",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        SimilarProductId = c.Int(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.SimilarProductId })
                .ForeignKey("dbo.Product", t => t.SimilarProductId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => new { t.ProductId, t.SimilarProductId }, unique: true, name: "IX_RelatedProduct")
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        CultureCode = c.String(maxLength: 10),
                        LocalizationId = c.Guid(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_SupplierName")
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Description = c.String(),
                        ProductId = c.Int(nullable: false),
                        DownloadUrl = c.String(maxLength: 1024),
                        OnlineProductUrl = c.String(maxLength: 1024),
                        DiscountCouponId = c.Int(),
                        CustomerOrderId = c.Int(),
                        Price = c.Single(nullable: false),
                        Count = c.Int(nullable: false),
                        Subtotal = c.Single(nullable: false),
                        TotalTax = c.Single(nullable: false),
                        TotalDiscounts = c.Single(nullable: false),
                        CustomData = c.String(maxLength: 1024),
                        OptionsData = c.String(maxLength: 1024),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerOrder", t => t.CustomerOrderId)
                .ForeignKey("dbo.DiscountCoupon", t => t.DiscountCouponId)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.Name, unique: true, name: "IX_OrderItemName")
                .Index(t => t.ProductId)
                .Index(t => t.DiscountCouponId)
                .Index(t => t.CustomerOrderId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_OrderItemTenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.DocumentTemplate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        ShortDescription = c.String(nullable: false, maxLength: 255),
                        Description = c.String(maxLength: 4000),
                        TemplateBody = c.String(),
                        TemplateBodyUrl = c.String(maxLength: 1024),
                        IsEnabled = c.Boolean(nullable: false),
                        TemplateType = c.String(maxLength: 64),
                        CultureCode = c.String(maxLength: 10),
                        LocalizationId = c.Guid(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.Name, t.TenantUnit, t.TenantUnitId }, unique: true, name: "IX_DocumentTemplateName")
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.EventLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventType = c.String(maxLength: 10),
                        EventTime = c.DateTime(nullable: false),
                        EventSource = c.String(maxLength: 100),
                        EventCode = c.String(maxLength: 100),
                        IpAddress = c.String(maxLength: 100),
                        Description = c.String(),
                        EventUrl = c.String(maxLength: 2000),
                        EventMachineName = c.String(maxLength: 100),
                        EventUserAgent = c.String(),
                        EventUrlReferrer = c.String(maxLength: 2000),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.Lookup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 80),
                        Description = c.String(maxLength: 255),
                        LookupType = c.Int(nullable: false),
                        IntRangeFrom = c.Int(),
                        IntRangeTo = c.Int(),
                        FloatRangeFrom = c.Single(),
                        FloatRangeTo = c.Single(),
                        FloatRangeStep = c.Single(),
                        DateRangeFrom = c.DateTime(),
                        DateRangeTo = c.DateTime(),
                        RangePrefix = c.String(maxLength: 10),
                        EntityName = c.String(maxLength: 255),
                        EntityValueField = c.String(maxLength: 80),
                        EntityNameField = c.String(maxLength: 80),
                        EntityFilter = c.String(maxLength: 1024),
                        EntityOrderBy = c.String(maxLength: 512),
                        CultureCode = c.String(maxLength: 10),
                        LocalizationId = c.Guid(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        EntityAssembly = c.String(maxLength: 512),
                        EntityClass = c.String(maxLength: 512),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                        ParentLookup_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lookup", t => t.ParentLookup_Id)
                .Index(t => t.Name, unique: true, name: "IX_LookupName")
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions)
                .Index(t => t.ParentLookup_Id);
            
            CreateTable(
                "dbo.LookupValue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(maxLength: 50),
                        Text = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        CultureCode = c.String(maxLength: 10),
                        LocalizationId = c.Guid(nullable: false),
                        ParentKey = c.String(maxLength: 50),
                        Order = c.Int(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                        Parent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lookup", t => t.Parent_Id)
                .Index(t => new { t.Key, t.Text, t.Description }, unique: true, name: "IX_LookupValue")
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions)
                .Index(t => t.Parent_Id);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FromAddress = c.String(maxLength: 255),
                        ToAddress = c.String(maxLength: 255),
                        CopyAddress = c.String(maxLength: 255),
                        BlackCopyAddress = c.String(maxLength: 255),
                        Subject = c.String(maxLength: 80),
                        Body = c.String(),
                        NewsLetterId = c.Int(),
                        SubscriberId = c.Int(),
                        Object = c.String(maxLength: 255),
                        ObjectId = c.Int(nullable: false),
                        Sent = c.Boolean(),
                        SentDate = c.DateTime(),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewsLetter", t => t.NewsLetterId)
                .ForeignKey("dbo.Subscriber", t => t.SubscriberId)
                .Index(t => new { t.FromAddress, t.ToAddress, t.Subject, t.CreateDate }, unique: true, name: "IX_MessageUnique")
                .Index(t => t.NewsLetterId)
                .Index(t => t.SubscriberId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.NewsLetter",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Subtitle = c.String(maxLength: 80),
                        TextHtml = c.String(maxLength: 2000),
                        ImagePath = c.String(maxLength: 255),
                        PublishDate = c.DateTime(nullable: false),
                        Published = c.Boolean(nullable: false),
                        CultureCode = c.String(maxLength: 10),
                        LocalizationId = c.Guid(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.Title, t.Subtitle }, unique: true, name: "IX_NewsLetterName")
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.Subscriber",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublicId = c.Guid(nullable: false),
                        Email = c.String(maxLength: 512),
                        Enabled = c.Boolean(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        LastNewsletterIdReceived = c.Int(),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "IX_SubscriberEmail")
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.OrganizationService",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Description = c.String(),
                        ImageUrl = c.String(maxLength: 512),
                        IconClass = c.String(maxLength: 80),
                        Order = c.Int(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        CultureCode = c.String(maxLength: 10),
                        LocalizationId = c.Guid(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, name: "IX_OrganizationServiceName")
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_OrganizationServiceTenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ScheduledTask",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        ShortName = c.String(nullable: false, maxLength: 64),
                        Description = c.String(maxLength: 1024),
                        UniqueId = c.String(maxLength: 64),
                        Recurring = c.Boolean(nullable: false),
                        Running = c.Boolean(nullable: false),
                        Executions = c.Int(nullable: false),
                        LastRun = c.DateTime(),
                        NextRun = c.DateTime(),
                        Interval = c.String(),
                        JobClass = c.String(nullable: false),
                        JobAssembly = c.String(nullable: false),
                        JobData = c.String(),
                        LastResult = c.Boolean(nullable: false),
                        LastMessage = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UniqueId, unique: true, name: "IX_ScheduledTaskUniqueId")
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.ShoppingCartProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Subtotal = c.Single(nullable: false),
                        TotalDiscount = c.Single(nullable: false),
                        ProductId = c.Int(nullable: false),
                        DiscountCouponId = c.Int(),
                        Coupon = c.String(maxLength: 200),
                        ShoppingCartId = c.Int(),
                        CustomData = c.String(maxLength: 1024),
                        OptionsData = c.String(maxLength: 1024),
                        OptionsAddedPrice = c.Single(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DiscountCoupon", t => t.DiscountCouponId)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingCart", t => t.ShoppingCartId)
                .Index(t => t.ProductId)
                .Index(t => t.DiscountCouponId)
                .Index(t => t.ShoppingCartId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.ShoppingCart",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        CurrencyId = c.Int(nullable: false),
                        ShippingOptionId = c.Int(),
                        PaymentOptionId = c.Int(),
                        DiscountCouponId = c.Int(),
                        BillingAddressId = c.Int(),
                        ShippingAddressId = c.Int(),
                        Coupon = c.String(maxLength: 200),
                        Notes = c.String(maxLength: 1024),
                        CustomData = c.String(maxLength: 1024),
                        Subtotal = c.Single(nullable: false),
                        Total = c.Single(nullable: false),
                        ShippingCost = c.Single(),
                        TotalDiscounts = c.Single(),
                        TaxTotal = c.Single(),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                        ShippingAsBilling = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.BillingAddressId)
                .ForeignKey("dbo.Currency", t => t.CurrencyId, cascadeDelete: true)
                .ForeignKey("dbo.DiscountCoupon", t => t.DiscountCouponId)
                .ForeignKey("dbo.PaymentOption", t => t.PaymentOptionId)
                .ForeignKey("dbo.Address", t => t.ShippingAddressId)
                .ForeignKey("dbo.ShippingOption", t => t.ShippingOptionId)
                .ForeignKey("dbo.OrganizationUser", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CurrencyId)
                .Index(t => t.ShippingOptionId)
                .Index(t => t.PaymentOptionId)
                .Index(t => t.DiscountCouponId)
                .Index(t => t.BillingAddressId)
                .Index(t => t.ShippingAddressId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.WorkflowActionAttribute",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AtributeType = c.Int(nullable: false),
                        AtributeDirection = c.Int(nullable: false),
                        Name = c.String(maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        DataSource = c.String(maxLength: 1024),
                        DefaultValue = c.String(),
                        IsPublic = c.Boolean(nullable: false),
                        IsVisible = c.Boolean(nullable: false),
                        IsReadonly = c.Boolean(nullable: false),
                        WorkflowActionId = c.Int(),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkflowAction", t => t.WorkflowActionId)
                .Index(t => t.Name, unique: true, name: "IX_WorkflowActionAttributeName")
                .Index(t => t.WorkflowActionId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.WorkflowAction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActionType = c.Int(nullable: false),
                        Name = c.String(maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        ActionAssembly = c.String(maxLength: 1024),
                        ActionClass = c.String(maxLength: 1024),
                        WorkflowId = c.Int(),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkflowClass", t => t.WorkflowId)
                .Index(t => t.Name, unique: true, name: "IX_WorkflowActionName")
                .Index(t => t.WorkflowId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.WorkflowStageTransition",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        MainImageUrl = c.String(maxLength: 1024),
                        WorkflowId = c.Int(),
                        FromStageId = c.Int(),
                        ToStageId = c.Int(),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkflowClass", t => t.WorkflowId)
                .ForeignKey("dbo.WorkflowStage", t => t.FromStageId)
                .ForeignKey("dbo.WorkflowStage", t => t.ToStageId)
                .Index(t => t.Name, unique: true, name: "IX_WorkflowTransitionName")
                .Index(t => t.WorkflowId)
                .Index(t => t.FromStageId)
                .Index(t => t.ToStageId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.WorkflowStage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StageType = c.Int(nullable: false),
                        Name = c.String(maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        WorkflowId = c.Int(),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkflowClass", t => t.WorkflowId)
                .Index(t => t.Name, unique: true, name: "IX_WorkflowStageName")
                .Index(t => t.WorkflowId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.WorkflowClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        BapEntityAssembly = c.String(maxLength: 1024),
                        BapEntityClass = c.String(maxLength: 1024),
                        ScheduledTaskId = c.Int(),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                        AllowedRoles = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ScheduledTask", t => t.ScheduledTaskId)
                .Index(t => t.Name, unique: true, name: "IX_WorkflowClassName")
                .Index(t => t.ScheduledTaskId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.WorkflowObject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        WorkflowId = c.Int(),
                        BapEntityAssembly = c.String(maxLength: 1024),
                        BapEntityClass = c.String(maxLength: 1024),
                        BapEntityId = c.Int(nullable: false),
                        WorkflowData = c.String(),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkflowClass", t => t.WorkflowId)
                .Index(t => t.Name, unique: true, name: "IX_WorkflowObjectName")
                .Index(t => t.WorkflowId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.ContentNodeViews",
                c => new
                    {
                        NodeId = c.Int(nullable: false),
                        ViewId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NodeId, t.ViewId })
                .ForeignKey("dbo.ContentNode", t => t.NodeId, cascadeDelete: true)
                .ForeignKey("dbo.ContentView", t => t.ViewId, cascadeDelete: true)
                .Index(t => t.NodeId)
                .Index(t => t.ViewId);
            
            CreateTable(
                "dbo.ShippingPayment",
                c => new
                    {
                        ShippingOptionId = c.Int(nullable: false),
                        PaymentOptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ShippingOptionId, t.PaymentOptionId })
                .ForeignKey("dbo.ShippingOption", t => t.ShippingOptionId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentOption", t => t.PaymentOptionId, cascadeDelete: true)
                .Index(t => t.ShippingOptionId)
                .Index(t => t.PaymentOptionId);
            
            CreateTable(
                "dbo.ProductOptionProduct",
                c => new
                    {
                        ProductOptionId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductOptionId, t.ProductId })
                .ForeignKey("dbo.ProductOption", t => t.ProductOptionId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductOptionId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.DiscountProduct",
                c => new
                    {
                        DiscountCouponId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DiscountCouponId, t.ProductId })
                .ForeignKey("dbo.DiscountCoupon", t => t.DiscountCouponId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.DiscountCouponId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.StoreDiscountCoupon",
                c => new
                    {
                        StoreId = c.Int(nullable: false),
                        DiscountCouponId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StoreId, t.DiscountCouponId })
                .ForeignKey("dbo.Store", t => t.StoreId, cascadeDelete: true)
                .ForeignKey("dbo.DiscountCoupon", t => t.DiscountCouponId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.DiscountCouponId);
            
            CreateTable(
                "dbo.StorePaymentOption",
                c => new
                    {
                        StoreId = c.Int(nullable: false),
                        PaymentOptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StoreId, t.PaymentOptionId })
                .ForeignKey("dbo.Store", t => t.StoreId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentOption", t => t.PaymentOptionId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.PaymentOptionId);
            
            CreateTable(
                "dbo.StoreProductCategory",
                c => new
                    {
                        StoreId = c.Int(nullable: false),
                        ProductCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StoreId, t.ProductCategoryId })
                .ForeignKey("dbo.Store", t => t.StoreId, cascadeDelete: true)
                .ForeignKey("dbo.ProductCategory", t => t.ProductCategoryId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.ProductCategoryId);
            
            CreateTable(
                "dbo.StoreShippingOption",
                c => new
                    {
                        StoreId = c.Int(nullable: false),
                        ShippingOptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StoreId, t.ShippingOptionId })
                .ForeignKey("dbo.Store", t => t.StoreId, cascadeDelete: true)
                .ForeignKey("dbo.ShippingOption", t => t.ShippingOptionId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.ShippingOptionId);
            
            CreateTable(
                "dbo.WorkflowTranstionActions",
                c => new
                    {
                        TransitionId = c.Int(nullable: false),
                        ActionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TransitionId, t.ActionId })
                .ForeignKey("dbo.WorkflowStageTransition", t => t.TransitionId, cascadeDelete: true)
                .ForeignKey("dbo.WorkflowAction", t => t.ActionId, cascadeDelete: true)
                .Index(t => t.TransitionId)
                .Index(t => t.ActionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkflowObject", "WorkflowId", "dbo.WorkflowClass");
            DropForeignKey("dbo.WorkflowStageTransition", "ToStageId", "dbo.WorkflowStage");
            DropForeignKey("dbo.WorkflowStageTransition", "FromStageId", "dbo.WorkflowStage");
            DropForeignKey("dbo.WorkflowStageTransition", "WorkflowId", "dbo.WorkflowClass");
            DropForeignKey("dbo.WorkflowStage", "WorkflowId", "dbo.WorkflowClass");
            DropForeignKey("dbo.WorkflowClass", "ScheduledTaskId", "dbo.ScheduledTask");
            DropForeignKey("dbo.WorkflowAction", "WorkflowId", "dbo.WorkflowClass");
            DropForeignKey("dbo.WorkflowTranstionActions", "ActionId", "dbo.WorkflowAction");
            DropForeignKey("dbo.WorkflowTranstionActions", "TransitionId", "dbo.WorkflowStageTransition");
            DropForeignKey("dbo.WorkflowActionAttribute", "WorkflowActionId", "dbo.WorkflowAction");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ShoppingCart", "UserId", "dbo.OrganizationUser");
            DropForeignKey("dbo.ShoppingCartProduct", "ShoppingCartId", "dbo.ShoppingCart");
            DropForeignKey("dbo.ShoppingCart", "ShippingOptionId", "dbo.ShippingOption");
            DropForeignKey("dbo.ShoppingCart", "ShippingAddressId", "dbo.Address");
            DropForeignKey("dbo.ShoppingCart", "PaymentOptionId", "dbo.PaymentOption");
            DropForeignKey("dbo.ShoppingCart", "DiscountCouponId", "dbo.DiscountCoupon");
            DropForeignKey("dbo.ShoppingCart", "CurrencyId", "dbo.Currency");
            DropForeignKey("dbo.ShoppingCart", "BillingAddressId", "dbo.Address");
            DropForeignKey("dbo.ShoppingCartProduct", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ShoppingCartProduct", "DiscountCouponId", "dbo.DiscountCoupon");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Message", "SubscriberId", "dbo.Subscriber");
            DropForeignKey("dbo.Message", "NewsLetterId", "dbo.NewsLetter");
            DropForeignKey("dbo.LookupValue", "Parent_Id", "dbo.Lookup");
            DropForeignKey("dbo.Lookup", "ParentLookup_Id", "dbo.Lookup");
            DropForeignKey("dbo.CustomerOrderPayment", "PaymentOptionId", "dbo.PaymentOption");
            DropForeignKey("dbo.CustomerOrderPayment", "CustomerPaymentId", "dbo.CustomerPayment");
            DropForeignKey("dbo.CustomerOrderPayment", "CustomerOrderId", "dbo.CustomerOrder");
            DropForeignKey("dbo.CustomerOrder", "UserId", "dbo.OrganizationUser");
            DropForeignKey("dbo.CustomerOrder", "ShippingOptionId", "dbo.ShippingOption");
            DropForeignKey("dbo.CustomerOrder", "ShippingAddressId", "dbo.Address");
            DropForeignKey("dbo.CustomerOrder", "PaymentOptionId", "dbo.PaymentOption");
            DropForeignKey("dbo.OrderItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderItem", "DiscountCouponId", "dbo.DiscountCoupon");
            DropForeignKey("dbo.OrderItem", "CustomerOrderId", "dbo.CustomerOrder");
            DropForeignKey("dbo.CustomerOrder", "DiscountCouponId", "dbo.DiscountCoupon");
            DropForeignKey("dbo.CustomerOrder", "CustomerPaymentId", "dbo.CustomerPayment");
            DropForeignKey("dbo.CustomerOrder", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Customer", "ShippingAddressId", "dbo.Address");
            DropForeignKey("dbo.Customer", "PrefferedShippingOptionId", "dbo.ShippingOption");
            DropForeignKey("dbo.Customer", "PrefferedCurrencyId", "dbo.Currency");
            DropForeignKey("dbo.Customer", "LoginUserId", "dbo.OrganizationUser");
            DropForeignKey("dbo.CustomerPayment", "PaymentOptionId", "dbo.PaymentOption");
            DropForeignKey("dbo.StoreShippingOption", "ShippingOptionId", "dbo.ShippingOption");
            DropForeignKey("dbo.StoreShippingOption", "StoreId", "dbo.Store");
            DropForeignKey("dbo.StoreProductCategory", "ProductCategoryId", "dbo.ProductCategory");
            DropForeignKey("dbo.StoreProductCategory", "StoreId", "dbo.Store");
            DropForeignKey("dbo.StorePaymentOption", "PaymentOptionId", "dbo.PaymentOption");
            DropForeignKey("dbo.StorePaymentOption", "StoreId", "dbo.Store");
            DropForeignKey("dbo.StoreDiscountCoupon", "DiscountCouponId", "dbo.DiscountCoupon");
            DropForeignKey("dbo.StoreDiscountCoupon", "StoreId", "dbo.Store");
            DropForeignKey("dbo.DiscountProduct", "ProductId", "dbo.Product");
            DropForeignKey("dbo.DiscountProduct", "DiscountCouponId", "dbo.DiscountCoupon");
            DropForeignKey("dbo.Product", "SupplierId", "dbo.Supplier");
            DropForeignKey("dbo.RelatedProduct", "ProductId", "dbo.Product");
            DropForeignKey("dbo.RelatedProduct", "SimilarProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "ProductCategoryId", "dbo.ProductCategory");
            DropForeignKey("dbo.ProductCategory", "ParentCategoryId", "dbo.ProductCategory");
            DropForeignKey("dbo.Product", "ParentProductId", "dbo.Product");
            DropForeignKey("dbo.ProductOptionProduct", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductOptionProduct", "ProductOptionId", "dbo.ProductOption");
            DropForeignKey("dbo.ProductOptionItem", "RelatedProductId", "dbo.Product");
            DropForeignKey("dbo.ProductOptionItem", "ProductOptionId", "dbo.ProductOption");
            DropForeignKey("dbo.Product", "ManufacturerId", "dbo.Manufacturer");
            DropForeignKey("dbo.Store", "ShippingAddressId", "dbo.Address");
            DropForeignKey("dbo.Store", "OrganizationId", "dbo.Organization");
            DropForeignKey("dbo.Store", "BillingAddressId", "dbo.Address");
            DropForeignKey("dbo.Store", "AdminUserId", "dbo.OrganizationUser");
            DropForeignKey("dbo.ShippingOption", "ShippingCarrierId", "dbo.ShippingCarrier");
            DropForeignKey("dbo.ShippingPayment", "PaymentOptionId", "dbo.PaymentOption");
            DropForeignKey("dbo.ShippingPayment", "ShippingOptionId", "dbo.ShippingOption");
            DropForeignKey("dbo.CustomerPayment", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Customer", "CompanyAddressId", "dbo.Address");
            DropForeignKey("dbo.Customer", "BillingAddressId", "dbo.Address");
            DropForeignKey("dbo.CustomerOrder", "CurrencyId", "dbo.Currency");
            DropForeignKey("dbo.CustomerOrder", "BillingAddressId", "dbo.Address");
            DropForeignKey("dbo.CustomerOrderPayment", "CurrencyId", "dbo.Currency");
            DropForeignKey("dbo.State", "CountryId", "dbo.Country");
            DropForeignKey("dbo.ContentNodeRoute", "ContentNodeId", "dbo.ContentNode");
            DropForeignKey("dbo.ContentLocalization", "ContentNodeId", "dbo.ContentNode");
            DropForeignKey("dbo.ContentControlParameter", "ContentViewControlId", "dbo.ContentViewControl");
            DropForeignKey("dbo.ContentViewControl", "ContentViewId", "dbo.ContentView");
            DropForeignKey("dbo.ContentViewControl", "ContentNodeId", "dbo.ContentNode");
            DropForeignKey("dbo.ContentNodeViews", "ViewId", "dbo.ContentView");
            DropForeignKey("dbo.ContentNodeViews", "NodeId", "dbo.ContentNode");
            DropForeignKey("dbo.ContentNode", "ParentNodeId", "dbo.ContentNode");
            DropForeignKey("dbo.ContentViewControl", "ContentControlId", "dbo.ContentControl");
            DropForeignKey("dbo.ContentControl", "ContentControlTypeId", "dbo.ContentControlType");
            DropForeignKey("dbo.BlogCommentUser", "CommentId", "dbo.BlogComment");
            DropForeignKey("dbo.BlogAuthor", "OrganizationUserId", "dbo.OrganizationUser");
            DropForeignKey("dbo.BlogComment", "CommentAuthorUserId", "dbo.OrganizationUser");
            DropForeignKey("dbo.OrganizationUser", "Organization_Id", "dbo.Organization");
            DropForeignKey("dbo.Subscription", "UserId", "dbo.OrganizationUser");
            DropForeignKey("dbo.Subscription", "OrganizationId", "dbo.Organization");
            DropForeignKey("dbo.OrganizationModule", "OrganizationId", "dbo.Organization");
            DropForeignKey("dbo.OrganizationModule", "ModuleId", "dbo.Module");
            DropForeignKey("dbo.BlogComment", "BlogPostId", "dbo.BlogPost");
            DropForeignKey("dbo.BlogPost", "BlogId", "dbo.Blog");
            DropForeignKey("dbo.BlogComment", "ParentCommentId", "dbo.BlogComment");
            DropForeignKey("dbo.BlogComment", "BlogId", "dbo.Blog");
            DropForeignKey("dbo.Blog", "BlogAuthorId", "dbo.BlogAuthor");
            DropForeignKey("dbo.AttachmentAccess", "AttachmentId", "dbo.Attachment");
            DropForeignKey("dbo.AttachmentHistory", "Attachment_Id", "dbo.Attachment");
            DropIndex("dbo.WorkflowTranstionActions", new[] { "ActionId" });
            DropIndex("dbo.WorkflowTranstionActions", new[] { "TransitionId" });
            DropIndex("dbo.StoreShippingOption", new[] { "ShippingOptionId" });
            DropIndex("dbo.StoreShippingOption", new[] { "StoreId" });
            DropIndex("dbo.StoreProductCategory", new[] { "ProductCategoryId" });
            DropIndex("dbo.StoreProductCategory", new[] { "StoreId" });
            DropIndex("dbo.StorePaymentOption", new[] { "PaymentOptionId" });
            DropIndex("dbo.StorePaymentOption", new[] { "StoreId" });
            DropIndex("dbo.StoreDiscountCoupon", new[] { "DiscountCouponId" });
            DropIndex("dbo.StoreDiscountCoupon", new[] { "StoreId" });
            DropIndex("dbo.DiscountProduct", new[] { "ProductId" });
            DropIndex("dbo.DiscountProduct", new[] { "DiscountCouponId" });
            DropIndex("dbo.ProductOptionProduct", new[] { "ProductId" });
            DropIndex("dbo.ProductOptionProduct", new[] { "ProductOptionId" });
            DropIndex("dbo.ShippingPayment", new[] { "PaymentOptionId" });
            DropIndex("dbo.ShippingPayment", new[] { "ShippingOptionId" });
            DropIndex("dbo.ContentNodeViews", new[] { "ViewId" });
            DropIndex("dbo.ContentNodeViews", new[] { "NodeId" });
            DropIndex("dbo.WorkflowObject", new[] { "OwnerPermissions" });
            DropIndex("dbo.WorkflowObject", new[] { "OwnerGroup" });
            DropIndex("dbo.WorkflowObject", "IX_Tenant");
            DropIndex("dbo.WorkflowObject", new[] { "WorkflowId" });
            DropIndex("dbo.WorkflowObject", "IX_WorkflowObjectName");
            DropIndex("dbo.WorkflowClass", new[] { "OwnerPermissions" });
            DropIndex("dbo.WorkflowClass", new[] { "OwnerGroup" });
            DropIndex("dbo.WorkflowClass", "IX_Tenant");
            DropIndex("dbo.WorkflowClass", new[] { "ScheduledTaskId" });
            DropIndex("dbo.WorkflowClass", "IX_WorkflowClassName");
            DropIndex("dbo.WorkflowStage", new[] { "OwnerPermissions" });
            DropIndex("dbo.WorkflowStage", new[] { "OwnerGroup" });
            DropIndex("dbo.WorkflowStage", "IX_Tenant");
            DropIndex("dbo.WorkflowStage", new[] { "WorkflowId" });
            DropIndex("dbo.WorkflowStage", "IX_WorkflowStageName");
            DropIndex("dbo.WorkflowStageTransition", new[] { "OwnerPermissions" });
            DropIndex("dbo.WorkflowStageTransition", new[] { "OwnerGroup" });
            DropIndex("dbo.WorkflowStageTransition", "IX_Tenant");
            DropIndex("dbo.WorkflowStageTransition", new[] { "ToStageId" });
            DropIndex("dbo.WorkflowStageTransition", new[] { "FromStageId" });
            DropIndex("dbo.WorkflowStageTransition", new[] { "WorkflowId" });
            DropIndex("dbo.WorkflowStageTransition", "IX_WorkflowTransitionName");
            DropIndex("dbo.WorkflowAction", new[] { "OwnerPermissions" });
            DropIndex("dbo.WorkflowAction", new[] { "OwnerGroup" });
            DropIndex("dbo.WorkflowAction", "IX_Tenant");
            DropIndex("dbo.WorkflowAction", new[] { "WorkflowId" });
            DropIndex("dbo.WorkflowAction", "IX_WorkflowActionName");
            DropIndex("dbo.WorkflowActionAttribute", new[] { "OwnerPermissions" });
            DropIndex("dbo.WorkflowActionAttribute", new[] { "OwnerGroup" });
            DropIndex("dbo.WorkflowActionAttribute", "IX_Tenant");
            DropIndex("dbo.WorkflowActionAttribute", new[] { "WorkflowActionId" });
            DropIndex("dbo.WorkflowActionAttribute", "IX_WorkflowActionAttributeName");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ShoppingCart", new[] { "OwnerPermissions" });
            DropIndex("dbo.ShoppingCart", new[] { "OwnerGroup" });
            DropIndex("dbo.ShoppingCart", "IX_Tenant");
            DropIndex("dbo.ShoppingCart", new[] { "ShippingAddressId" });
            DropIndex("dbo.ShoppingCart", new[] { "BillingAddressId" });
            DropIndex("dbo.ShoppingCart", new[] { "DiscountCouponId" });
            DropIndex("dbo.ShoppingCart", new[] { "PaymentOptionId" });
            DropIndex("dbo.ShoppingCart", new[] { "ShippingOptionId" });
            DropIndex("dbo.ShoppingCart", new[] { "CurrencyId" });
            DropIndex("dbo.ShoppingCart", new[] { "UserId" });
            DropIndex("dbo.ShoppingCartProduct", new[] { "OwnerPermissions" });
            DropIndex("dbo.ShoppingCartProduct", new[] { "OwnerGroup" });
            DropIndex("dbo.ShoppingCartProduct", "IX_Tenant");
            DropIndex("dbo.ShoppingCartProduct", new[] { "ShoppingCartId" });
            DropIndex("dbo.ShoppingCartProduct", new[] { "DiscountCouponId" });
            DropIndex("dbo.ShoppingCartProduct", new[] { "ProductId" });
            DropIndex("dbo.ScheduledTask", new[] { "OwnerPermissions" });
            DropIndex("dbo.ScheduledTask", new[] { "OwnerGroup" });
            DropIndex("dbo.ScheduledTask", "IX_Tenant");
            DropIndex("dbo.ScheduledTask", "IX_ScheduledTaskUniqueId");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OrganizationService", new[] { "OwnerPermissions" });
            DropIndex("dbo.OrganizationService", new[] { "OwnerGroup" });
            DropIndex("dbo.OrganizationService", "IX_OrganizationServiceTenant");
            DropIndex("dbo.OrganizationService", new[] { "LocalizationId" });
            DropIndex("dbo.OrganizationService", new[] { "CultureCode" });
            DropIndex("dbo.OrganizationService", "IX_OrganizationServiceName");
            DropIndex("dbo.Subscriber", new[] { "OwnerPermissions" });
            DropIndex("dbo.Subscriber", new[] { "OwnerGroup" });
            DropIndex("dbo.Subscriber", "IX_Tenant");
            DropIndex("dbo.Subscriber", "IX_SubscriberEmail");
            DropIndex("dbo.NewsLetter", new[] { "OwnerPermissions" });
            DropIndex("dbo.NewsLetter", new[] { "OwnerGroup" });
            DropIndex("dbo.NewsLetter", "IX_Tenant");
            DropIndex("dbo.NewsLetter", new[] { "LocalizationId" });
            DropIndex("dbo.NewsLetter", new[] { "CultureCode" });
            DropIndex("dbo.NewsLetter", "IX_NewsLetterName");
            DropIndex("dbo.Message", new[] { "OwnerPermissions" });
            DropIndex("dbo.Message", new[] { "OwnerGroup" });
            DropIndex("dbo.Message", "IX_Tenant");
            DropIndex("dbo.Message", new[] { "SubscriberId" });
            DropIndex("dbo.Message", new[] { "NewsLetterId" });
            DropIndex("dbo.Message", "IX_MessageUnique");
            DropIndex("dbo.LookupValue", new[] { "Parent_Id" });
            DropIndex("dbo.LookupValue", new[] { "OwnerPermissions" });
            DropIndex("dbo.LookupValue", new[] { "OwnerGroup" });
            DropIndex("dbo.LookupValue", "IX_Tenant");
            DropIndex("dbo.LookupValue", new[] { "LocalizationId" });
            DropIndex("dbo.LookupValue", new[] { "CultureCode" });
            DropIndex("dbo.LookupValue", "IX_LookupValue");
            DropIndex("dbo.Lookup", new[] { "ParentLookup_Id" });
            DropIndex("dbo.Lookup", new[] { "OwnerPermissions" });
            DropIndex("dbo.Lookup", new[] { "OwnerGroup" });
            DropIndex("dbo.Lookup", "IX_Tenant");
            DropIndex("dbo.Lookup", new[] { "LocalizationId" });
            DropIndex("dbo.Lookup", new[] { "CultureCode" });
            DropIndex("dbo.Lookup", "IX_LookupName");
            DropIndex("dbo.EventLog", new[] { "OwnerPermissions" });
            DropIndex("dbo.EventLog", new[] { "OwnerGroup" });
            DropIndex("dbo.EventLog", "IX_Tenant");
            DropIndex("dbo.DocumentTemplate", new[] { "OwnerPermissions" });
            DropIndex("dbo.DocumentTemplate", new[] { "OwnerGroup" });
            DropIndex("dbo.DocumentTemplate", "IX_Tenant");
            DropIndex("dbo.DocumentTemplate", new[] { "LocalizationId" });
            DropIndex("dbo.DocumentTemplate", new[] { "CultureCode" });
            DropIndex("dbo.DocumentTemplate", "IX_DocumentTemplateName");
            DropIndex("dbo.OrderItem", new[] { "OwnerPermissions" });
            DropIndex("dbo.OrderItem", new[] { "OwnerGroup" });
            DropIndex("dbo.OrderItem", "IX_OrderItemTenant");
            DropIndex("dbo.OrderItem", new[] { "CustomerOrderId" });
            DropIndex("dbo.OrderItem", new[] { "DiscountCouponId" });
            DropIndex("dbo.OrderItem", new[] { "ProductId" });
            DropIndex("dbo.OrderItem", "IX_OrderItemName");
            DropIndex("dbo.Supplier", new[] { "OwnerPermissions" });
            DropIndex("dbo.Supplier", new[] { "OwnerGroup" });
            DropIndex("dbo.Supplier", "IX_Tenant");
            DropIndex("dbo.Supplier", new[] { "LocalizationId" });
            DropIndex("dbo.Supplier", new[] { "CultureCode" });
            DropIndex("dbo.Supplier", "IX_SupplierName");
            DropIndex("dbo.RelatedProduct", new[] { "OwnerPermissions" });
            DropIndex("dbo.RelatedProduct", new[] { "OwnerGroup" });
            DropIndex("dbo.RelatedProduct", "IX_Tenant");
            DropIndex("dbo.RelatedProduct", "IX_RelatedProduct");
            DropIndex("dbo.ProductCategory", new[] { "OwnerPermissions" });
            DropIndex("dbo.ProductCategory", new[] { "OwnerGroup" });
            DropIndex("dbo.ProductCategory", "IX_Tenant");
            DropIndex("dbo.ProductCategory", new[] { "LocalizationId" });
            DropIndex("dbo.ProductCategory", new[] { "CultureCode" });
            DropIndex("dbo.ProductCategory", "IX_ProductCategoryName");
            DropIndex("dbo.ProductCategory", new[] { "ParentCategoryId" });
            DropIndex("dbo.ProductOptionItem", new[] { "OwnerPermissions" });
            DropIndex("dbo.ProductOptionItem", new[] { "OwnerGroup" });
            DropIndex("dbo.ProductOptionItem", "IX_Tenant");
            DropIndex("dbo.ProductOptionItem", new[] { "LocalizationId" });
            DropIndex("dbo.ProductOptionItem", new[] { "CultureCode" });
            DropIndex("dbo.ProductOptionItem", new[] { "RelatedProductId" });
            DropIndex("dbo.ProductOptionItem", "IX_ProductOptionItemName");
            DropIndex("dbo.ProductOption", new[] { "OwnerPermissions" });
            DropIndex("dbo.ProductOption", new[] { "OwnerGroup" });
            DropIndex("dbo.ProductOption", "IX_Tenant");
            DropIndex("dbo.ProductOption", new[] { "LocalizationId" });
            DropIndex("dbo.ProductOption", new[] { "CultureCode" });
            DropIndex("dbo.ProductOption", "IX_ProductOptionName");
            DropIndex("dbo.Manufacturer", new[] { "OwnerPermissions" });
            DropIndex("dbo.Manufacturer", new[] { "OwnerGroup" });
            DropIndex("dbo.Manufacturer", "IX_Tenant");
            DropIndex("dbo.Manufacturer", new[] { "LocalizationId" });
            DropIndex("dbo.Manufacturer", new[] { "CultureCode" });
            DropIndex("dbo.Manufacturer", "IX_ManufacturerName");
            DropIndex("dbo.Product", new[] { "OwnerPermissions" });
            DropIndex("dbo.Product", new[] { "OwnerGroup" });
            DropIndex("dbo.Product", "IX_Tenant");
            DropIndex("dbo.Product", new[] { "LocalizationId" });
            DropIndex("dbo.Product", new[] { "CultureCode" });
            DropIndex("dbo.Product", new[] { "ProductCategoryId" });
            DropIndex("dbo.Product", new[] { "ManufacturerId" });
            DropIndex("dbo.Product", new[] { "SupplierId" });
            DropIndex("dbo.Product", new[] { "ParentProductId" });
            DropIndex("dbo.Product", "IX_ProductName");
            DropIndex("dbo.DiscountCoupon", new[] { "OwnerPermissions" });
            DropIndex("dbo.DiscountCoupon", new[] { "OwnerGroup" });
            DropIndex("dbo.DiscountCoupon", "IX_Tenant");
            DropIndex("dbo.DiscountCoupon", new[] { "LocalizationId" });
            DropIndex("dbo.DiscountCoupon", new[] { "CultureCode" });
            DropIndex("dbo.DiscountCoupon", "IX_DiscountCouponName");
            DropIndex("dbo.Store", new[] { "OwnerPermissions" });
            DropIndex("dbo.Store", new[] { "OwnerGroup" });
            DropIndex("dbo.Store", "IX_Tenant");
            DropIndex("dbo.Store", new[] { "ShippingAddressId" });
            DropIndex("dbo.Store", new[] { "BillingAddressId" });
            DropIndex("dbo.Store", new[] { "AdminUserId" });
            DropIndex("dbo.Store", new[] { "OrganizationId" });
            DropIndex("dbo.Store", "IX_DiscountCouponName");
            DropIndex("dbo.ShippingCarrier", new[] { "OwnerPermissions" });
            DropIndex("dbo.ShippingCarrier", new[] { "OwnerGroup" });
            DropIndex("dbo.ShippingCarrier", "IX_Tenant");
            DropIndex("dbo.ShippingCarrier", new[] { "LocalizationId" });
            DropIndex("dbo.ShippingCarrier", new[] { "CultureCode" });
            DropIndex("dbo.ShippingCarrier", "IX_ShippingCarrierName");
            DropIndex("dbo.ShippingOption", new[] { "ShippingCarrierId" });
            DropIndex("dbo.ShippingOption", new[] { "OwnerPermissions" });
            DropIndex("dbo.ShippingOption", new[] { "OwnerGroup" });
            DropIndex("dbo.ShippingOption", "IX_Tenant");
            DropIndex("dbo.ShippingOption", new[] { "LocalizationId" });
            DropIndex("dbo.ShippingOption", new[] { "CultureCode" });
            DropIndex("dbo.ShippingOption", "IX_ShippingOptionName");
            DropIndex("dbo.PaymentOption", new[] { "OwnerPermissions" });
            DropIndex("dbo.PaymentOption", new[] { "OwnerGroup" });
            DropIndex("dbo.PaymentOption", "IX_Tenant");
            DropIndex("dbo.PaymentOption", new[] { "LocalizationId" });
            DropIndex("dbo.PaymentOption", new[] { "CultureCode" });
            DropIndex("dbo.PaymentOption", "IX_PaymentOptionName");
            DropIndex("dbo.CustomerPayment", new[] { "OwnerPermissions" });
            DropIndex("dbo.CustomerPayment", new[] { "OwnerGroup" });
            DropIndex("dbo.CustomerPayment", "IX_CustomerPaymentTenant");
            DropIndex("dbo.CustomerPayment", new[] { "PaymentOptionId" });
            DropIndex("dbo.CustomerPayment", new[] { "CustomerId" });
            DropIndex("dbo.CustomerPayment", "IX_CustomerPaymentName");
            DropIndex("dbo.Customer", new[] { "PrefferedCurrencyId" });
            DropIndex("dbo.Customer", new[] { "PrefferedShippingOptionId" });
            DropIndex("dbo.Customer", new[] { "OwnerPermissions" });
            DropIndex("dbo.Customer", new[] { "OwnerGroup" });
            DropIndex("dbo.Customer", "IX_CustomerTenant");
            DropIndex("dbo.Customer", new[] { "LoginUserId" });
            DropIndex("dbo.Customer", new[] { "CompanyAddressId" });
            DropIndex("dbo.Customer", new[] { "ShippingAddressId" });
            DropIndex("dbo.Customer", new[] { "BillingAddressId" });
            DropIndex("dbo.Customer", "IX_CustomerName");
            DropIndex("dbo.CustomerOrder", new[] { "OwnerPermissions" });
            DropIndex("dbo.CustomerOrder", new[] { "OwnerGroup" });
            DropIndex("dbo.CustomerOrder", "IX_CustomerOrderTenant");
            DropIndex("dbo.CustomerOrder", new[] { "ShippingAddressId" });
            DropIndex("dbo.CustomerOrder", new[] { "BillingAddressId" });
            DropIndex("dbo.CustomerOrder", new[] { "DiscountCouponId" });
            DropIndex("dbo.CustomerOrder", new[] { "PaymentOptionId" });
            DropIndex("dbo.CustomerOrder", new[] { "ShippingOptionId" });
            DropIndex("dbo.CustomerOrder", new[] { "CurrencyId" });
            DropIndex("dbo.CustomerOrder", new[] { "UserId" });
            DropIndex("dbo.CustomerOrder", new[] { "CustomerPaymentId" });
            DropIndex("dbo.CustomerOrder", new[] { "CustomerId" });
            DropIndex("dbo.CustomerOrder", "IX_CustomerOrderName");
            DropIndex("dbo.CustomerOrderPayment", new[] { "OwnerPermissions" });
            DropIndex("dbo.CustomerOrderPayment", new[] { "OwnerGroup" });
            DropIndex("dbo.CustomerOrderPayment", "IX_CustomerOrderPaymentTenant");
            DropIndex("dbo.CustomerOrderPayment", new[] { "CurrencyId" });
            DropIndex("dbo.CustomerOrderPayment", new[] { "CustomerPaymentId" });
            DropIndex("dbo.CustomerOrderPayment", new[] { "PaymentOptionId" });
            DropIndex("dbo.CustomerOrderPayment", new[] { "CustomerOrderId" });
            DropIndex("dbo.CustomConfiguration", new[] { "OwnerPermissions" });
            DropIndex("dbo.CustomConfiguration", new[] { "OwnerGroup" });
            DropIndex("dbo.CustomConfiguration", "IX_Tenant");
            DropIndex("dbo.CustomConfiguration", "IX_CustomConfigurationName");
            DropIndex("dbo.Currency", new[] { "OwnerPermissions" });
            DropIndex("dbo.Currency", new[] { "OwnerGroup" });
            DropIndex("dbo.Currency", "IX_Tenant");
            DropIndex("dbo.Currency", "IX_CurrencyCode");
            DropIndex("dbo.State", new[] { "OwnerPermissions" });
            DropIndex("dbo.State", new[] { "OwnerGroup" });
            DropIndex("dbo.State", "IX_Tenant");
            DropIndex("dbo.State", new[] { "CountryId" });
            DropIndex("dbo.State", "IX_StateThreeLetterCode");
            DropIndex("dbo.State", "IX_StateTwoLetterCode");
            DropIndex("dbo.Country", new[] { "OwnerPermissions" });
            DropIndex("dbo.Country", new[] { "OwnerGroup" });
            DropIndex("dbo.Country", "IX_Tenant");
            DropIndex("dbo.Country", "IX_CountryThreeLetterCode");
            DropIndex("dbo.Country", "IX_CountryTwoLetterCode");
            DropIndex("dbo.ContentNodeRoute", new[] { "OwnerPermissions" });
            DropIndex("dbo.ContentNodeRoute", new[] { "OwnerGroup" });
            DropIndex("dbo.ContentNodeRoute", "IX_ContentNodeRouteTenant");
            DropIndex("dbo.ContentNodeRoute", new[] { "ContentNodeId" });
            DropIndex("dbo.ContentNodeRoute", "IX_ContentNodeRouteName");
            DropIndex("dbo.ContentLocalization", new[] { "OwnerPermissions" });
            DropIndex("dbo.ContentLocalization", new[] { "OwnerGroup" });
            DropIndex("dbo.ContentLocalization", "IX_ContentLocalizationTenant");
            DropIndex("dbo.ContentLocalization", new[] { "ContentNodeId" });
            DropIndex("dbo.ContentLocalization", new[] { "LocalizationId" });
            DropIndex("dbo.ContentLocalization", new[] { "CultureCode" });
            DropIndex("dbo.ContentLocalization", "IX_ContentLocalizationName");
            DropIndex("dbo.ContentView", new[] { "OwnerPermissions" });
            DropIndex("dbo.ContentView", new[] { "OwnerGroup" });
            DropIndex("dbo.ContentView", "IX_ContentViewTenant");
            DropIndex("dbo.ContentView", new[] { "LocalizationId" });
            DropIndex("dbo.ContentView", new[] { "CultureCode" });
            DropIndex("dbo.ContentView", "IX_ContentViewName");
            DropIndex("dbo.ContentNode", new[] { "OwnerPermissions" });
            DropIndex("dbo.ContentNode", new[] { "OwnerGroup" });
            DropIndex("dbo.ContentNode", "IX_ContentNodeTenant");
            DropIndex("dbo.ContentNode", new[] { "LocalizationId" });
            DropIndex("dbo.ContentNode", new[] { "CultureCode" });
            DropIndex("dbo.ContentNode", new[] { "ParentNodeId" });
            DropIndex("dbo.ContentNode", "IX_ContentNodeRoute");
            DropIndex("dbo.ContentNode", "IX_ContentNodeName");
            DropIndex("dbo.ContentControlType", new[] { "OwnerPermissions" });
            DropIndex("dbo.ContentControlType", new[] { "OwnerGroup" });
            DropIndex("dbo.ContentControlType", "IX_Tenant");
            DropIndex("dbo.ContentControlType", new[] { "LocalizationId" });
            DropIndex("dbo.ContentControlType", new[] { "CultureCode" });
            DropIndex("dbo.ContentControlType", "IX_ContentControlTypeName");
            DropIndex("dbo.ContentControl", new[] { "OwnerPermissions" });
            DropIndex("dbo.ContentControl", new[] { "OwnerGroup" });
            DropIndex("dbo.ContentControl", "IX_Tenant");
            DropIndex("dbo.ContentControl", new[] { "LocalizationId" });
            DropIndex("dbo.ContentControl", new[] { "CultureCode" });
            DropIndex("dbo.ContentControl", new[] { "ContentControlTypeId" });
            DropIndex("dbo.ContentControl", "IX_ContentControlTypeName");
            DropIndex("dbo.ContentViewControl", new[] { "OwnerPermissions" });
            DropIndex("dbo.ContentViewControl", new[] { "OwnerGroup" });
            DropIndex("dbo.ContentViewControl", "IX_ContentViewControlTenant");
            DropIndex("dbo.ContentViewControl", new[] { "LocalizationId" });
            DropIndex("dbo.ContentViewControl", new[] { "CultureCode" });
            DropIndex("dbo.ContentViewControl", new[] { "ContentControlId" });
            DropIndex("dbo.ContentViewControl", new[] { "ContentViewId" });
            DropIndex("dbo.ContentViewControl", new[] { "ContentNodeId" });
            DropIndex("dbo.ContentViewControl", "IX_ContentViewControlName");
            DropIndex("dbo.ContentControlParameter", new[] { "OwnerPermissions" });
            DropIndex("dbo.ContentControlParameter", new[] { "OwnerGroup" });
            DropIndex("dbo.ContentControlParameter", "IX_ContentControlParameterTenant");
            DropIndex("dbo.ContentControlParameter", new[] { "ContentViewControlId" });
            DropIndex("dbo.ContentControlParameter", "IX_ContentControlParameterName");
            DropIndex("dbo.BlogCommentUser", new[] { "OwnerPermissions" });
            DropIndex("dbo.BlogCommentUser", new[] { "OwnerGroup" });
            DropIndex("dbo.BlogCommentUser", "IX_Tenant");
            DropIndex("dbo.BlogCommentUser", new[] { "CommentId" });
            DropIndex("dbo.Subscription", new[] { "OwnerPermissions" });
            DropIndex("dbo.Subscription", new[] { "OwnerGroup" });
            DropIndex("dbo.Subscription", "IX_Tenant");
            DropIndex("dbo.Subscription", new[] { "UserId" });
            DropIndex("dbo.Subscription", new[] { "OrganizationId" });
            DropIndex("dbo.Module", new[] { "OwnerPermissions" });
            DropIndex("dbo.Module", new[] { "OwnerGroup" });
            DropIndex("dbo.Module", "IX_Tenant");
            DropIndex("dbo.Module", "IX_Module");
            DropIndex("dbo.OrganizationModule", new[] { "OwnerPermissions" });
            DropIndex("dbo.OrganizationModule", new[] { "OwnerGroup" });
            DropIndex("dbo.OrganizationModule", "IX_Tenant");
            DropIndex("dbo.OrganizationModule", new[] { "OrganizationId" });
            DropIndex("dbo.OrganizationModule", new[] { "ModuleId" });
            DropIndex("dbo.OrganizationModule", "IX_Module");
            DropIndex("dbo.Organization", new[] { "OwnerPermissions" });
            DropIndex("dbo.Organization", new[] { "OwnerGroup" });
            DropIndex("dbo.Organization", "IX_Tenant");
            DropIndex("dbo.Organization", "IX_OrganizationName");
            DropIndex("dbo.OrganizationUser", new[] { "Organization_Id" });
            DropIndex("dbo.OrganizationUser", new[] { "OwnerPermissions" });
            DropIndex("dbo.OrganizationUser", new[] { "OwnerGroup" });
            DropIndex("dbo.OrganizationUser", "IX_Tenant");
            DropIndex("dbo.OrganizationUser", "IX_OrgUserName");
            DropIndex("dbo.BlogPost", new[] { "OwnerPermissions" });
            DropIndex("dbo.BlogPost", new[] { "OwnerGroup" });
            DropIndex("dbo.BlogPost", "IX_Tenant");
            DropIndex("dbo.BlogPost", new[] { "LocalizationId" });
            DropIndex("dbo.BlogPost", new[] { "CultureCode" });
            DropIndex("dbo.BlogPost", new[] { "BlogId" });
            DropIndex("dbo.BlogPost", "IX_BlogPost");
            DropIndex("dbo.BlogComment", new[] { "CommentAuthorUserId" });
            DropIndex("dbo.BlogComment", new[] { "OwnerPermissions" });
            DropIndex("dbo.BlogComment", new[] { "OwnerGroup" });
            DropIndex("dbo.BlogComment", "IX_Tenant");
            DropIndex("dbo.BlogComment", new[] { "BlogPostId" });
            DropIndex("dbo.BlogComment", "IX_BlogComment");
            DropIndex("dbo.BlogComment", new[] { "ParentCommentId" });
            DropIndex("dbo.Blog", new[] { "OwnerPermissions" });
            DropIndex("dbo.Blog", new[] { "OwnerGroup" });
            DropIndex("dbo.Blog", "IX_Tenant");
            DropIndex("dbo.Blog", new[] { "LocalizationId" });
            DropIndex("dbo.Blog", new[] { "CategoryCode" });
            DropIndex("dbo.Blog", new[] { "CultureCode" });
            DropIndex("dbo.Blog", new[] { "BlogAuthorId" });
            DropIndex("dbo.Blog", "IX_BlogName");
            DropIndex("dbo.BlogAuthor", new[] { "OwnerPermissions" });
            DropIndex("dbo.BlogAuthor", new[] { "OwnerGroup" });
            DropIndex("dbo.BlogAuthor", "IX_Tenant");
            DropIndex("dbo.BlogAuthor", new[] { "LocalizationId" });
            DropIndex("dbo.BlogAuthor", new[] { "CultureCode" });
            DropIndex("dbo.BlogAuthor", new[] { "OrganizationUserId" });
            DropIndex("dbo.BlogAuthor", "IX_BlogAuthorName");
            DropIndex("dbo.AttachmentAccess", new[] { "OwnerPermissions" });
            DropIndex("dbo.AttachmentAccess", new[] { "OwnerGroup" });
            DropIndex("dbo.AttachmentAccess", "IX_Tenant");
            DropIndex("dbo.AttachmentAccess", new[] { "AttachmentId" });
            DropIndex("dbo.Attachment", new[] { "OwnerPermissions" });
            DropIndex("dbo.Attachment", new[] { "OwnerGroup" });
            DropIndex("dbo.Attachment", "IX_Tenant");
            DropIndex("dbo.Attachment", "IX_AttachmentNameObect");
            DropIndex("dbo.AttachmentHistory", new[] { "Attachment_Id" });
            DropIndex("dbo.AttachmentHistory", new[] { "OwnerPermissions" });
            DropIndex("dbo.AttachmentHistory", new[] { "OwnerGroup" });
            DropIndex("dbo.AttachmentHistory", "IX_Tenant");
            DropIndex("dbo.Address", new[] { "OwnerPermissions" });
            DropIndex("dbo.Address", new[] { "OwnerGroup" });
            DropIndex("dbo.Address", "IX_Tenant");
            DropIndex("dbo.Address", "IX_AddressName");
            DropTable("dbo.WorkflowTranstionActions");
            DropTable("dbo.StoreShippingOption");
            DropTable("dbo.StoreProductCategory");
            DropTable("dbo.StorePaymentOption");
            DropTable("dbo.StoreDiscountCoupon");
            DropTable("dbo.DiscountProduct");
            DropTable("dbo.ProductOptionProduct");
            DropTable("dbo.ShippingPayment");
            DropTable("dbo.ContentNodeViews");
            DropTable("dbo.WorkflowObject");
            DropTable("dbo.WorkflowClass");
            DropTable("dbo.WorkflowStage");
            DropTable("dbo.WorkflowStageTransition");
            DropTable("dbo.WorkflowAction");
            DropTable("dbo.WorkflowActionAttribute");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ShoppingCart");
            DropTable("dbo.ShoppingCartProduct");
            DropTable("dbo.ScheduledTask");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OrganizationService");
            DropTable("dbo.Subscriber");
            DropTable("dbo.NewsLetter");
            DropTable("dbo.Message");
            DropTable("dbo.LookupValue");
            DropTable("dbo.Lookup");
            DropTable("dbo.EventLog");
            DropTable("dbo.DocumentTemplate");
            DropTable("dbo.OrderItem");
            DropTable("dbo.Supplier");
            DropTable("dbo.RelatedProduct");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.ProductOptionItem");
            DropTable("dbo.ProductOption");
            DropTable("dbo.Manufacturer");
            DropTable("dbo.Product");
            DropTable("dbo.DiscountCoupon");
            DropTable("dbo.Store");
            DropTable("dbo.ShippingCarrier");
            DropTable("dbo.ShippingOption");
            DropTable("dbo.PaymentOption");
            DropTable("dbo.CustomerPayment");
            DropTable("dbo.Customer");
            DropTable("dbo.CustomerOrder");
            DropTable("dbo.CustomerOrderPayment");
            DropTable("dbo.CustomConfiguration");
            DropTable("dbo.Currency");
            DropTable("dbo.State");
            DropTable("dbo.Country");
            DropTable("dbo.ContentNodeRoute");
            DropTable("dbo.ContentLocalization");
            DropTable("dbo.ContentView");
            DropTable("dbo.ContentNode");
            DropTable("dbo.ContentControlType");
            DropTable("dbo.ContentControl");
            DropTable("dbo.ContentViewControl");
            DropTable("dbo.ContentControlParameter");
            DropTable("dbo.BlogCommentUser");
            DropTable("dbo.Subscription");
            DropTable("dbo.Module");
            DropTable("dbo.OrganizationModule");
            DropTable("dbo.Organization");
            DropTable("dbo.OrganizationUser");
            DropTable("dbo.BlogPost");
            DropTable("dbo.BlogComment");
            DropTable("dbo.Blog");
            DropTable("dbo.BlogAuthor");
            DropTable("dbo.AttachmentAccess");
            DropTable("dbo.Attachment");
            DropTable("dbo.AttachmentHistory");
            DropTable("dbo.Address");
        }
    }
}
