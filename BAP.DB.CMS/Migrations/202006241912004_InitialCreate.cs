namespace BAP.CMSDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Subscription", "UserId", "dbo.OrganizationUser");
            DropForeignKey("dbo.OrganizationUser", "Organization_Id", "dbo.Organization");
            DropForeignKey("dbo.Subscription", "OrganizationId", "dbo.Organization");
            DropForeignKey("dbo.OrganizationModule", "OrganizationId", "dbo.Organization");
            DropForeignKey("dbo.OrganizationModule", "ModuleId", "dbo.Module");
            DropForeignKey("dbo.Message", "SubscriberId", "dbo.Subscriber");
            DropForeignKey("dbo.Message", "NewsLetterId", "dbo.NewsLetter");
            DropForeignKey("dbo.LookupValue", "Parent_Id", "dbo.Lookup");
            DropForeignKey("dbo.Lookup", "ParentLookup_Id", "dbo.Lookup");
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
            DropForeignKey("dbo.AttachmentAccess", "AttachmentId", "dbo.Attachment");
            DropForeignKey("dbo.AttachmentHistory", "Attachment_Id", "dbo.Attachment");
            DropIndex("dbo.ContentNodeViews", new[] { "ViewId" });
            DropIndex("dbo.ContentNodeViews", new[] { "NodeId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OrganizationService", new[] { "OwnerPermissions" });
            DropIndex("dbo.OrganizationService", new[] { "OwnerGroup" });
            DropIndex("dbo.OrganizationService", "IX_OrganizationServiceTenant");
            DropIndex("dbo.OrganizationService", new[] { "LocalizationId" });
            DropIndex("dbo.OrganizationService", new[] { "CultureCode" });
            DropIndex("dbo.OrganizationService", "IX_OrganizationServiceName");
            DropIndex("dbo.OrganizationUser", new[] { "Organization_Id" });
            DropIndex("dbo.OrganizationUser", new[] { "OwnerPermissions" });
            DropIndex("dbo.OrganizationUser", new[] { "OwnerGroup" });
            DropIndex("dbo.OrganizationUser", "IX_Tenant");
            DropIndex("dbo.OrganizationUser", "IX_OrgUserName");
            DropIndex("dbo.Subscription", new[] { "OwnerPermissions" });
            DropIndex("dbo.Subscription", new[] { "OwnerGroup" });
            DropIndex("dbo.Subscription", "IX_Tenant");
            DropIndex("dbo.Subscription", new[] { "UserId" });
            DropIndex("dbo.Subscription", new[] { "OrganizationId" });
            DropIndex("dbo.Organization", new[] { "OwnerPermissions" });
            DropIndex("dbo.Organization", new[] { "OwnerGroup" });
            DropIndex("dbo.Organization", "IX_Tenant");
            DropIndex("dbo.Organization", "IX_OrganizationName");
            DropIndex("dbo.OrganizationModule", new[] { "OwnerPermissions" });
            DropIndex("dbo.OrganizationModule", new[] { "OwnerGroup" });
            DropIndex("dbo.OrganizationModule", "IX_Tenant");
            DropIndex("dbo.OrganizationModule", new[] { "OrganizationId" });
            DropIndex("dbo.OrganizationModule", new[] { "ModuleId" });
            DropIndex("dbo.OrganizationModule", "IX_Module");
            DropIndex("dbo.Module", new[] { "OwnerPermissions" });
            DropIndex("dbo.Module", new[] { "OwnerGroup" });
            DropIndex("dbo.Module", "IX_Tenant");
            DropIndex("dbo.Module", "IX_Module");
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
            DropTable("dbo.ContentNodeViews");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OrganizationService");
            DropTable("dbo.OrganizationUser");
            DropTable("dbo.Subscription");
            DropTable("dbo.Organization");
            DropTable("dbo.OrganizationModule");
            DropTable("dbo.Module");
            DropTable("dbo.Subscriber");
            DropTable("dbo.NewsLetter");
            DropTable("dbo.Message");
            DropTable("dbo.LookupValue");
            DropTable("dbo.Lookup");
            DropTable("dbo.EventLog");
            DropTable("dbo.DocumentTemplate");
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
            DropTable("dbo.AttachmentAccess");
            DropTable("dbo.Attachment");
            DropTable("dbo.AttachmentHistory");
        }
    }
}
