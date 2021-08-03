namespace BAP.CMSDB.Migrations
{
    using BAP.BL.AspNetIdentity;
    using BAP.DAL.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// This method will be called after migrating to the latest version.
        /// </summary>
        /// <param name="context">Current DB context object</param>
        protected override void Seed(DB context)
        {
            var adminUserName = "admin@app.bap-software.com";
            var contentManagerUserName = "cmng@app.bap-software.com";
            var siteContentManagerUserName = "scmng@app.bap-software.com";
            var createDateTime = DateTime.Now;

            //Insert User Roles
            AddRole(context, "Administrator");
            AddRole(context, "ContentManager");
            AddRole(context, "User");

            //Insert Users
            var adminUserId = AddUser(context, adminUserName, "Administrator");

            //Insert Organization - initiate tenant and make application functioning
            var organization = context.Organizations.FirstOrDefault(a => a.Name == "BAP Application");
            if (organization == null)
            {
                organization = new Organization
                {
                    Name = "BAP Application",
                    Status = "Final",
                    CreateDate = createDateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = adminUserId,
                    TenantUnit = "Organization",
                    OrganizationType = 1,
                    AddressLine1 = "31 Ashgrove, Glencairin, Dooradoyle",
                    City = "Limerick",
                    County = "Limerick",
                    State = "Munster",
                    Country = "Ireland",
                    PhoneNumber = "(555) 123-1212",
                    OwnerGroup = 127,
                    OwnerPermissions = 310991,
                    FacebookUrl = "http://facebook.com/bapsoftware",
                    TwitterUrl = "http://twitter.com",
                    LinkedinUrl = "http://linkedin.com",
                    GoogleplusUrl = "http://plus.google.com",
                    InstagramUrl = "https://www.instagram.com",
                    ContactEmail = "info@app.bap-software.com",
                    SupportEmail = "support@app.bap-software.com",
                    ImplementedCulturesText = "en-US",
                    HostName = "127.0.0.1",
                    HostNameAliasesText = "localhost:50678,app.bap-software.comd,app-dev.bap-software.com",
                    BapDefaultFromEmail = "support@app.bap-software.com",
                    BapDefaultContactEmail = "info@app.bap-software.com",
                    SmtpUserName = "support@bap-software.com",
                    SmtpUserPassword = "Test$123",
                    SmtpHostName = "mail.bap-software.com",
                    SmtpPort = 8889,
                    SmtpUseSsl = false,
                    reCaptchaSiteKey = "6LdqCgsUAAAAAO5ysJIQzLm0Lbk1cLAKYytYnMiW",
                    reCaptchaSecretKey = "6LdqCgsUAAAAAErowDwY0Gi04cJaZZUMBqjVALks",
                    GetBearrerTokenDuringLogin = true,
                    AuthCookieName = "appbapcms-base-cookiie-name",
                    AuthCookieExpirationTime = 20,
                    WebApiPublicClientId = "appbapcms-web-api-client",
                    BearerTokenExpirationTime = 14,
                    WebApiAllowInsecureHttp = true,
                    PublicFolderText = "/Files/BapCMS/Public/",
                    BaseFolderText = "/Files/BapCMS/",
                    StatusDate = createDateTime
                };
                context.Organizations.Add(organization);
                context.SaveChanges();

                //Setting tenant unit Id to itself
                organization.TenantUnitId = organization.Id;
                context.Organizations.AddOrUpdate(organization);
            }
            else
            {
                organization.OwnerGroup = 127;
                organization.OwnerPermissions = 310991;
            }
            context.SaveChanges();

            //Assign Administrator user with Organization
            var orgUser = context.OrganizationUsers.FirstOrDefault(a =>
                a.AspNetUserId == adminUserId && a.TenantUnit == "Organization" && a.TenantUnitId == organization.Id);
            if (orgUser == null)
            {
                orgUser = new OrganizationUser
                {
                    AspNetUserId = adminUserId,
                    FirstName = "Victor",
                    LastName = "Mamray",
                    AddressLine1 = "Urlivs'ka st. 16, apt. 173.",
                    City = "Kyiv",
                    State = "Kyiv",
                    Country = "UA",
                    Zip = "02095",
                    PhoneNumber = "506831998",
                    CellNumber = "876576557",
                    TenantUnit = "Organization",
                    TenantUnitId = organization.Id,
                    OwnerGroup = 127,
                    OwnerPermissions = 310991,
                    Organization = organization,
                    CreateDate = createDateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = adminUserId,
                    Email = adminUserName,
                    EmailConfirmed = true
                };
                context.OrganizationUsers.Add(orgUser);
                context.SaveChanges();
            }

            //Organization Services
            AddOrganizationServices(context, organization.Id, adminUserId);            

            //Content manager user - default one
            var userId = AddUser(context, contentManagerUserName, "ContentManager");
            orgUser = context.OrganizationUsers.FirstOrDefault(a =>
                a.AspNetUserId == userId && a.TenantUnit == "Organization" && a.TenantUnitId == organization.Id);
            if (orgUser == null)
            {
                orgUser = new OrganizationUser
                {
                    AspNetUserId = userId,
                    FirstName = "Content",
                    LastName = "Manager",
                    TenantUnit = "Organization",
                    TenantUnitId = organization.Id,
                    OwnerGroup = 127,
                    OwnerPermissions = 310991,
                    Organization = organization,
                    CreateDate = createDateTime,
                    CreatedBy = userId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = userId,
                    Email = adminUserName,
                    EmailConfirmed = true,
                    IsBuiltIn = true
                };
                context.OrganizationUsers.Add(orgUser);
                context.SaveChanges();
            }

            //Site content manager
            userId = AddUser(context, siteContentManagerUserName, "ContentManager");
            orgUser = context.OrganizationUsers.FirstOrDefault(a =>
                a.AspNetUserId == userId && a.TenantUnit == "Organization" && a.TenantUnitId == organization.Id);
            if (orgUser == null)
            {
                orgUser = new OrganizationUser
                {
                    AspNetUserId = userId,
                    FirstName = "Site Content",
                    LastName = "Manager",
                    TenantUnit = "Organization",
                    TenantUnitId = organization.Id,
                    OwnerGroup = 127,
                    OwnerPermissions = 310991,
                    Organization = organization,
                    CreateDate = createDateTime,
                    CreatedBy = userId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = userId,
                    Email = adminUserName,
                    EmailConfirmed = true,
                    IsBuiltIn = true
                };
                context.OrganizationUsers.Add(orgUser);
                context.SaveChanges();
            }

            //Localizations
            AddLocalizations(context, organization.Id, adminUserId);

            //Add extra dictionaries
            // - Currency			
            AddCurrency(context, "USD", "US Dollar", "$", "United States Dollar", organization.Id, adminUserId, true);
            AddCurrency(context, "EUR", "Euro", "#", "European Union Euro", organization.Id, adminUserId);

            // - Country
            FillCountries(context, organization.Id, adminUserId);

            // - State
            var usa = context.Countries.FirstOrDefault(c => c.ThreeLetterCode == "USA");
            if (usa != null)
                FillStates(context, organization.Id, adminUserId, usa.Id);

            // - Lookup
            // - LookupValue			
            Lookup lookup = context.Lookups.FirstOrDefault(a => a.Name == "AttachmentType");
            if (lookup == null)
            {
                lookup = new Lookup
                {
                    Name = "AttachmentType",
                    Description = "Attachment Type",
                    LookupType = LookupType.OptionList,
                    TenantUnit = "Organization",
                    TenantUnitId = organization.Id,
                    CreateDate = createDateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 302799
                };
                context.Lookups.Add(lookup);
            }
            else
            {
                UpdateLookupValue(context, lookup);
            }
            UpsertLookupValue(context, organization.Id, lookup, "photo"/*key*/, "Photo"/*text*/, "Photo"/*description*/, "en-US", 1, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "picture"/*key*/, "Picture"/*text*/, "picture"/*description*/, "en-US", 2, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "pdf"/*key*/, "PDF"/*text*/, "PDF"/*description*/, "en-US", 3, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "json"/*key*/, "JSON"/*text*/, "JSON"/*description*/, "en-US", 4, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "word"/*key*/, "Word"/*text*/, "Word"/*description*/, "en-US", 5, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "excel"/*key*/, "Excel"/*text*/, "Excel"/*description*/, "en-US", 6, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "text"/*key*/, "Text"/*text*/, "Text"/*description*/, "en-US", 7, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "archive"/*key*/, "Archive"/*text*/, "Archive"/*description*/, "en-US", 8, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "icon"/*key*/, "Icon"/*text*/, "Icon"/*description*/, "en-US", 9, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "executable"/*key*/, "Executable"/*text*/, "Executable"/*description*/, "en-US", 10, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "installation"/*key*/, "Installation"/*text*/, "Installation"/*description*/, "en-US", 11, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "file"/*key*/, "File"/*text*/, "File"/*description*/, "en-US", 99, adminUserId);

            lookup = context.Lookups.FirstOrDefault(a => a.Name == "TemplateType");
            if (lookup == null)
            {
                lookup = new Lookup
                {
                    Name = "TemplateType",
                    Description = "Template Type",
                    LookupType = LookupType.OptionList,
                    TenantUnit = "Organization",
                    TenantUnitId = organization.Id,
                    CreateDate = createDateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 302799
                };
                context.Lookups.Add(lookup);
            }
            else
            {
                UpdateLookupValue(context, lookup);
            }
            UpsertLookupValue(context, organization.Id, lookup, "email"/*key*/, "Email"/*text*/, "Email"/*description*/, "en-US", 1, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "financial"/*key*/, "Financial"/*text*/, "Financial"/*description*/, "en-US", 2, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "common"/*key*/, "Common"/*text*/, "Common"/*description*/, "en-US", 3, adminUserId);

            lookup = context.Lookups.FirstOrDefault(a => a.Name == "AttachmentStatus");
            if (lookup == null)
            {
                lookup = new Lookup
                {
                    Name = "AttachmentStatus",
                    Description = "Attachment Status",
                    LookupType = LookupType.OptionList,
                    TenantUnit = "Organization",
                    TenantUnitId = organization.Id,
                    CreateDate = createDateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 302799
                };
                context.Lookups.Add(lookup);
            }
            else
            {
                UpdateLookupValue(context, lookup);
            }
            UpsertLookupValue(context, organization.Id, lookup, "new"/*key*/, "New"/*text*/, "New"/*description*/, "en-US", 1, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "published"/*key*/, "Published"/*text*/, "Published"/*description*/, "en-US", 1, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "disabled"/*key*/, "Disabled"/*text*/, "Disabled"/*description*/, "en-US", 1, adminUserId);

            lookup = context.Lookups.FirstOrDefault(a => a.Name == "CategoryCode");
            if (lookup == null)
            {
                lookup = new Lookup
                {
                    Name = "CategoryCode",
                    Description = "Category Code",
                    LookupType = LookupType.OptionList,
                    TenantUnit = "Organization",
                    TenantUnitId = organization.Id,
                    CreateDate = createDateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 302799
                };
                context.Lookups.Add(lookup);
            }
            else
            {
                UpdateLookupValue(context, lookup);
            }
            UpsertLookupValue(context, organization.Id, lookup, "sport"/*key*/, "Sport"/*text*/, "Sport"/*description*/, "en-US", 1, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "life"/*key*/, "Life"/*text*/, "Life"/*description*/, "en-US", 2, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "art"/*key*/, "Art"/*text*/, "Art"/*description*/, "en-US", 3, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "hobbies"/*key*/, "Hobbies"/*text*/, "Hobbies"/*description*/, "en-US", 4, adminUserId);

            context.SaveChanges();

            //Content Management
            // - ContentNode
            ContentNode node = null;
            ContentNode parentNode = null;            
            //Application root page            
            node = UpsertContentNode(context, "Application", "$resources:BAP.Resources.Resources,UIText_Menu_BAP",
                        "/", null, "Home", "Index", null, "BAP.Web.Controllers",
                        null, 1, organization.Id, adminUserId, null, true, true, true, true, true, "{controller}/{action}/{id}");
            node.IsHome = true;
            parentNode = node;


            #region BAP system administration pages
            var orgId = organization.Id;
            var adminNode = UpsertContentNode(context, "Administration", "$resources:BAP.Resources.Resources,UIText_Menu_Administration",
                        "/admin", "Administration", "Home", "Index", "fa fa-laptop", "BAP.Web.Areas.Administration.Controllers",
                        "Administrator,ContentManager,Supervisor", 999, orgId, adminUserId, null, true, true, true, true, true);

            node = UpsertContentNode(context, "Attachments", "$resources:BAP.Resources.Resources,UIText_Menu_Attachments",
                        "/Administration/Attachments/Index", "Administration", "Attachments", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator,ContentManager", 1, orgId, adminUserId, adminNode, true, true, true, true, true);
            

            node = UpsertContentNode(context, "ContentControls", "$resources:BAP.Resources.Resources,UIText_Menu_ContentControls",
                        "/Administration/ContentControls/Index", "Administration", "ContentControls", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator,ContentManager", 3, orgId, adminUserId, adminNode, true, true, true, true, true);


            node = UpsertContentNode(context, "ContentControlTypes", "$resources:BAP.Resources.Resources,UIText_Menu_ContentControlTypes",
                        "/Administration/ContentControlTypes/Index", "Administration", "ContentControlTypes", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator", 4, orgId, adminUserId, adminNode, true, true, true, true, true);


            node = UpsertContentNode(context, "ContentManagement", "$resources:BAP.Resources.Resources,UIText_Menu_ContentManagement",
                        "/Administration/ContentManagement/Index", "Administration", "ContentManagement", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator,ContentManager", 5, orgId, adminUserId, adminNode, true, true, true, true, true);


            node = UpsertContentNode(context, "Countries", "$resources:BAP.Resources.Resources,UIText_Menu_Countries",
                        "/Administration/Countries/Index", "Administration", "Countries", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator", 6, orgId, adminUserId, adminNode, true, true, true, true, true);


            node = UpsertContentNode(context, "Currencies", "$resources:BAP.Resources.Resources,UIText_Menu_Currencies",
                        "/Administration/Currencies/Index", "Administration", "Currencies", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator,Supervisor", 7, orgId, adminUserId, adminNode, true, true, true, true, true);


            node = UpsertContentNode(context, "CustomConfigurations", "$resources:BAP.Resources.Resources,UIText_Menu_CustomConfigurations",
                        "/Administration/CustomConfigurations/Index", "Administration", "CustomConfigurations", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator", 8, orgId, adminUserId, adminNode, true, true, true, true, true);


            node = UpsertContentNode(context, "DocumentTemplates", "$resources:BAP.Resources.Resources,UIText_Menu_DocumentTemplates",
                        "/Administration/DocumentTemplates/Index", "Administration", "DocumentTemplates", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator,Supervisor", 9, orgId, adminUserId, adminNode, true, true, true, true, true);


            node = UpsertContentNode(context, "FileSystem", "$resources:BAP.Resources.Resources,UIText_Menu_FileSystem",
                        "/Administration/FileSystem/Index", "Administration", "FileSystem", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator,ContentManager", 10, orgId, adminUserId, adminNode, true, true, true, true, true);


            node = UpsertContentNode(context, "EventLogs", "$resources:BAP.Resources.Resources,UIText_Menu_EventLog",
                        "/Administration/EventLogs/Index", "Administration", "EventLogs", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator,Supervisor", 11, orgId, adminUserId, adminNode, true, true, true, true, true);

            node = UpsertContentNode(context, "Localizations", "$resources:BAP.Resources.Resources,UIText_Menu_Localizations",
                        "/Administration/Localizations/Index", "Administration", "Localizations", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator", 12, orgId, adminUserId, adminNode, true, true, true, true, true);

            node = UpsertContentNode(context, "Lookups", "$resources:BAP.Resources.Resources,UIText_Menu_Lookups",
                        "/Administration/Lookups/Index", "Administration", "Lookups", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator,ContentManager", 13, orgId, adminUserId, adminNode, true, true, true, true, true);


            node = UpsertContentNode(context, "Messages", "$resources:BAP.Resources.Resources,UIText_Menu_Messages",
                        "/Administration/Messages/Index", "Administration", "Messages", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator,Supervisor", 14, orgId, adminUserId, adminNode, true, true, true, true, true);


            node = UpsertContentNode(context, "Modules", "$resources:BAP.Resources.Resources,UIText_Menu_Modules",
                        "/Administration/Modules/Index", "Administration", "Modules", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator", 15, orgId, adminUserId, adminNode, true, true, true, true, true);


            node = UpsertContentNode(context, "NewsLetters", "$resources:BAP.Resources.Resources,UIText_Menu_NewsLetters",
                        "/Administration/NewsLetters/Index", "Administration", "NewsLetters", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator,Supervisor", 16, orgId, adminUserId, adminNode, true, true, true, true, true);


            node = UpsertContentNode(context, "Subscribers", "$resources:BAP.Resources.Resources,UIText_Menu_Subscribers",
                        "/Administration/Subscribers/Index", "Administration", "Subscribers", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator,Supervisor", 17, orgId, adminUserId, adminNode, true, true, true, true, true);


            node = UpsertContentNode(context, "Organizations", "$resources:BAP.Resources.Resources,UIText_Menu_Organization",
                        "/Administration/Organizations/Index", "Administration", "Organizations", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator", 18, orgId, adminUserId, adminNode, true, true, true, true, true);


            node = UpsertContentNode(context, "OrganizationServices", "$resources:BAP.Resources.Resources,UIText_Menu_OrganizationServices",
                        "/Administration/OrganizationServices/Index", "Administration", "OrganizationServices", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator", 19, orgId, adminUserId, adminNode, true, true, true, true, true);

             
            node = UpsertContentNode(context, "OrganizationUsers", "$resources:BAP.Resources.Resources,UIText_Menu_Users",
                        "/Administration/OrganizationUsers/Index", "Administration", "OrganizationUsers", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator", 22, orgId, adminUserId, adminNode, true, true, true, true, true);
           
            #endregion

            context.SaveChanges();

            AddModule(context, "Content Management", organization, adminUserId, createDateTime);
            
            context.SaveChanges();

            //Data fixes
            ExtraDataFixes(context);
        }

        ContentNode UpsertContentNode(DB db, string name, string caption, string aliasPath, string area, string controller, string action, string icon, string namespaces, string roles, int menuIndex, int orgId, string adminUserId, ContentNode parent = null, bool enabled = true, bool clicable = true, bool allowChldren = false, bool showInMenu = true, bool showInSitemap = true, string routeUrl = null, int owners = 127, int ownerPermissions = 8143)
        {
            DateTime createDateTime = DateTime.Now;
            ContentNode node = null;
            var contentNodes = db.Set<ContentNode>();
            if (!contentNodes.Any(a => a.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
            {
                node = new ContentNode
                {
                    Name = name,
                    Alias = name,
                    AliasPath = aliasPath,
                    Area = area,
                    Controller = controller,
                    Action = action,
                    MenuCaption = caption,
                    View = action,
                    RouteUrl = routeUrl,
                    NameSpaces = namespaces,
                    MenuSortOrder = menuIndex,
                    MenuIcon = icon,
                    Roles = roles,

                    ParentNode = parent,
                    MenuClicable = clicable,
                    AllowChildren = allowChldren,
                    ShowInMenu = showInMenu,
                    ShowInSitemap = showInSitemap,
                    Enabled = enabled,

                    NavigationType = NavigationType.MvcRoute,
                    Rating = 1,
                    SitemapPriority = SitemapPriority.Normal,
                    SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = createDateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = owners,
                    OwnerPermissions = ownerPermissions
                };
                contentNodes.Add(node);
            }
            else
            {
                node = contentNodes.SingleOrDefault(a => a.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

                node.AliasPath = aliasPath;
                node.Area = area;
                node.Controller = controller;
                node.Action = action;
                node.MenuCaption = caption;
                node.View = action;
                node.RouteUrl = routeUrl;
                node.NameSpaces = namespaces;
                node.MenuSortOrder = menuIndex;
                node.MenuIcon = icon;
                node.Roles = roles;

                node.MenuClicable = clicable;
                node.AllowChildren = allowChldren;
                node.ShowInMenu = showInMenu;
                node.ShowInSitemap = showInSitemap;
                node.Enabled = enabled;

                node.LastModifiedDate = createDateTime;
                node.LastModifiedBy = adminUserId;
            }
            return node;
        }

        private void UpsertDocumentTemplate(DB context, int orgId, string name, string shortDescr, string typeName, string fileUrl, string upsertUserId)
        {
            var docTemplate = context.DocumentTemplates.SingleOrDefault(a => a.Name == name);
            var currDateTime = DateTime.Now;
            if (docTemplate == null)
            {
                docTemplate = new DocumentTemplate
                {
                    Name = name,
                    ShortDescription = shortDescr,
                    TemplateType = typeName,
                    TemplateBodyUrl = fileUrl,                    
                    OwnerGroup = 123,
                    OwnerPermissions = 2072079,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = currDateTime,
                    CreatedBy = upsertUserId,
                    LastModifiedDate = currDateTime,
                    LastModifiedBy = upsertUserId
                };
                context.DocumentTemplates.Add(docTemplate);
            }
            else
            {
                docTemplate.ShortDescription = shortDescr;
                docTemplate.TemplateType = typeName;
                docTemplate.TemplateBodyUrl = fileUrl;
                docTemplate.LastModifiedDate = currDateTime;
                docTemplate.LastModifiedBy = upsertUserId;
            }
            context.SaveChanges();
        }

        private void ExtraDataFixes(DB context)
        {
            
            foreach (var cc in context.CustomConfigurations)
            {
                cc.OwnerGroup = 123;
                cc.OwnerPermissions = 2072079;
            }
            
            foreach (var cc in context.EventLogs)
            {
                cc.OwnerGroup = 127;
                cc.OwnerPermissions = 1944095;
            }
            context.SaveChanges();
        }

        private void AddModule(DB context, string name, Organization organization, string adminUserId, DateTime createDateTime)
        {
            if (!context.Modules.Any(m => m.Name == name))
            {
                var module = new Module
                {
                    Name = name,
                    ShortDescription = name,
                    Description = name,
                    Enabled = true,
                    GlobalId = Guid.NewGuid(),
                    Roles = "Administrator,ContentManager",
                    BitMask = 299599,
                    TenantUnit = "Organization",
                    TenantUnitId = organization.Id,
                    CreateDate = createDateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 299599
                };
                context.Modules.Add(module);

                var organizationModule = new OrganizationModule
                {
                    Name = $"{organization.Name} {module.Name}",
                    OrganizationId = organization.Id,
                    ModuleId = module.Id,
                    TenantUnit = "Organization",
                    TenantUnitId = organization.Id,
                    CreateDate = createDateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 299599
                };
                context.OrganizationModules.Add(organizationModule);

                context.SaveChanges();
            }
        }
        private void AddRole(DB context, string name)
        {
            if (!context.Roles.Any(r => r.Name == name))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = name };

                manager.Create(role);
            }
        }
        private string AddUser(DB context, string name, string role = "", string password = "Test$123")
        {
            var adminUserId = string.Empty;
            if (!context.Users.Any(u => u.UserName == name))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                manager.UserValidator = new UserValidator<ApplicationUser>(manager)
                { AllowOnlyAlphanumericUserNames = false };

                var user = new ApplicationUser { UserName = name, Email = name, EmailConfirmed = true };

                var identityResult = manager.Create(user, password);
                if (identityResult.Succeeded)
                {
                    if (!string.IsNullOrEmpty(role))
                    {
                        manager.AddToRole(user.Id, role);
                    }
                    else if (context.Roles.Any(r => r.Name == "User"))
                    {
                        manager.AddToRole(user.Id, "User");
                    }

                    adminUserId = user.Id;
                }
                else
                {
                    var errorText = "";
                    if (identityResult.Errors != null)
                    {
                        foreach (var txt in identityResult.Errors)
                        {
                            if (!string.IsNullOrEmpty(errorText))
                                errorText = errorText + ", ";
                            errorText += txt;
                        }
                    }

                    throw new Exception("Could not create user, error: " + errorText);
                }

            }
            else
            {
                adminUserId = context.Users.FirstOrDefault(a => a.UserName == name).Id;
            }

            return adminUserId;
        }

        private LookupValue UpsertLookupValue(DB context, int orgId, Lookup lookup, string key, string text, string description, string culture, int order, string userId)
        {
            if (context == null || orgId == 0 || lookup == null)
                return null;

            IQueryable<Lookup> query = context.Lookups;
            query = query.Where(a => a.Id == lookup.Id);
            query = query.Include(a => a.Values);
            var thisLoookup = query.SingleOrDefault();

            var currDateTime = DateTime.Now;
            LookupValue lValue = null;
            if (thisLoookup != null && thisLoookup.Values != null && thisLoookup.Values.Any(a => a.Key == key))
            {
                lValue = thisLoookup.Values.First(a => a.Key == key);
                if (lValue != null)
                {
                    lValue.Text = text;
                    lValue.Description = description;
                    lValue.LastModifiedBy = userId;
                    lValue.LastModifiedDate = currDateTime;
                    context.SaveChanges();
                }
            }
            else
            {
                lValue = new LookupValue
                {
                    Key = key,
                    Text = text,
                    Description = description,                    
                    Order = order,
                    Parent = lookup,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = currDateTime,
                    CreatedBy = userId,
                    LastModifiedDate = currDateTime,
                    LastModifiedBy = userId,
                    OwnerGroup = 127,
                    OwnerPermissions = 302799
                };
                context.LookupValues.Add(lValue);
            }

            return lValue;
        }

        private void UpdateLookupValue(DB context, Lookup lookup)
        {
            lookup.OwnerGroup = 127;
            lookup.OwnerPermissions = 302799;
        }

        private void AddCurrency(DB context, string threeLetterCode, string name, string symbol, string description,
            int orgId, string adminUserId, bool isMain = false, decimal xchRate = 1)
        {
            var currency = context.Currencies.FirstOrDefault(a =>
                a.ThreeLetterCode == threeLetterCode && a.TenantUnit == "Organization" && a.TenantUnitId == orgId);
            if (currency == null)
            {
                var dateTime = DateTime.Now;
                currency = new Currency
                {
                    ThreeLetterCode = threeLetterCode,
                    Name = name,
                    Description = description,
                    ExchangeRate = xchRate,
                    Symbol = symbol,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    IsMain = isMain,
                    IsEnabled = true,
                    RoundTo = 2,
                    FormatString = "${0:n2}"
                };
                context.Currencies.Add(currency);
            }
            else
            {
                currency.OwnerGroup = 127;
                currency.OwnerPermissions = 1875535;
            }
            context.SaveChanges();
        }
        
        private void FillCountries(DB context, int orgId, string adminUserId)
        {
            var countries = Maddalena.Country.All;
            foreach (var cntr in countries)
            {
                var dateTime = DateTime.Now;
                var country = context.Countries.FirstOrDefault(a =>
                    a.Name == cntr.CommonName && a.TwoLetterCode == cntr.CountryCode.ToString() &&
                    a.ThreeLetterCode == cntr.ISO3.ToString() && a.TenantUnit == "Organization" &&
                    a.TenantUnitId == orgId);
                if (country == null && !string.IsNullOrWhiteSpace(cntr.CIOC))
                {
                    country = new Country
                    {
                        Name = cntr.CommonName,
                        ShortName = cntr.CIOC,
                        Description = cntr.OfficialName,
                        TwoLetterCode = cntr.CountryCode.ToString(),
                        ThreeLetterCode = cntr.ISO3.ToString(),
                        FlagSvg11Path = $"/file/Public/flags/1x1/{cntr.CountryCode}.svg",
                        FlagSvg43Path = $"/file/Public/flags/4x3/{cntr.CountryCode}.svg",
                        TenantUnit = "Organization",
                        TenantUnitId = orgId,
                        CreateDate = dateTime,
                        CreatedBy = adminUserId,
                        LastModifiedDate = dateTime,
                        LastModifiedBy = adminUserId,
                        OwnerGroup = 127,
                        OwnerPermissions = 1875535
                    };
                    context.Countries.Add(country);
                }
                else if (country != null)
                {
                    country.OwnerGroup = 127;
                    country.OwnerPermissions = 1875535;
                }
            }

            context.SaveChanges();
        }
        private void FillStates(DB context, int orgId, string adminUserId, int countryId)
        {
            var dateTime = DateTime.Now;
            var states = new List<State>
            {
                new State
                {
                    Name = "Alabama",
                    ShortName = "AL",
                    Description = "Alabama",
                    TwoLetterCode = "AL",
                    ThreeLetterCode = "AL",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Alaska",
                    ShortName = "AK",
                    Description = "Alaska",
                    TwoLetterCode = "AK",
                    ThreeLetterCode = "AK",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Arizona",
                    ShortName = "AZ",
                    Description = "Arizona",
                    TwoLetterCode = "AZ",
                    ThreeLetterCode = "AZ",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Arkansas",
                    ShortName = "AR",
                    Description = "Arkansas",
                    TwoLetterCode = "AR",
                    ThreeLetterCode = "AR",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "California",
                    ShortName = "CA",
                    Description = "California",
                    TwoLetterCode = "CA",
                    ThreeLetterCode = "CA",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Colorado",
                    ShortName = "CO",
                    Description = "Colorado",
                    TwoLetterCode = "CO",
                    ThreeLetterCode = "CO",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Connecticut",
                    ShortName = "CT",
                    Description = "Connecticut",
                    TwoLetterCode = "CT",
                    ThreeLetterCode = "CT",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Delaware",
                    ShortName = "DE",
                    Description = "Delaware",
                    TwoLetterCode = "DE",
                    ThreeLetterCode = "DE",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "District Of Columbia",
                    ShortName = "DC",
                    Description = "District Of Columbia",
                    TwoLetterCode = "DC",
                    ThreeLetterCode = "DC",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Florida",
                    ShortName = "FL",
                    Description = "Florida",
                    TwoLetterCode = "FL",
                    ThreeLetterCode = "FL",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Georgia",
                    ShortName = "GA",
                    Description = "Georgia",
                    TwoLetterCode = "GA",
                    ThreeLetterCode = "GA",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Hawaii",
                    ShortName = "HI",
                    Description = "Hawaii",
                    TwoLetterCode = "HI",
                    ThreeLetterCode = "HI",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Idaho",
                    ShortName = "ID",
                    Description = "Idaho",
                    TwoLetterCode = "ID",
                    ThreeLetterCode = "ID",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Illinois",
                    ShortName = "IL",
                    Description = "Illinois",
                    TwoLetterCode = "IL",
                    ThreeLetterCode = "IL",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Indiana",
                    ShortName = "IN",
                    Description = "Indiana",
                    TwoLetterCode = "IN",
                    ThreeLetterCode = "IN",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Iowa",
                    ShortName = "IA",
                    Description = "Iowa",
                    TwoLetterCode = "IA",
                    ThreeLetterCode = "IA",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Kansas",
                    ShortName = "KS",
                    Description = "Kansas",
                    TwoLetterCode = "KS",
                    ThreeLetterCode = "KS",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Kentucky",
                    ShortName = "KY",
                    Description = "Kentucky",
                    TwoLetterCode = "KY",
                    ThreeLetterCode = "KY",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Louisiana",
                    ShortName = "LA",
                    Description = "Louisiana",
                    TwoLetterCode = "LA",
                    ThreeLetterCode = "LA",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Maine",
                    ShortName = "ME",
                    Description = "Maine",
                    TwoLetterCode = "ME",
                    ThreeLetterCode = "ME",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Maryland",
                    ShortName = "MD",
                    Description = "Maryland",
                    TwoLetterCode = "MD",
                    ThreeLetterCode = "MD",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Massachusetts",
                    ShortName = "MA",
                    Description = "Massachusetts",
                    TwoLetterCode = "MA",
                    ThreeLetterCode = "MA",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Michigan",
                    ShortName = "MI",
                    Description = "Michigan",
                    TwoLetterCode = "MI",
                    ThreeLetterCode = "MI",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Minnesota",
                    ShortName = "MN",
                    Description = "Minnesota",
                    TwoLetterCode = "MN",
                    ThreeLetterCode = "MN",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Mississippi",
                    ShortName = "MS",
                    Description = "Mississippi",
                    TwoLetterCode = "MS",
                    ThreeLetterCode = "MS",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Missouri",
                    ShortName = "MO",
                    Description = "Missouri",
                    TwoLetterCode = "MO",
                    ThreeLetterCode = "MO",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Montana",
                    ShortName = "MT",
                    Description = "Montana",
                    TwoLetterCode = "MT",
                    ThreeLetterCode = "MT",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Nebraska",
                    ShortName = "NE",
                    Description = "Nebraska",
                    TwoLetterCode = "NE",
                    ThreeLetterCode = "NE",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Nevada",
                    ShortName = "NV",
                    Description = "Nevada",
                    TwoLetterCode = "NV",
                    ThreeLetterCode = "NV",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "New Hampshire",
                    ShortName = "NH",
                    Description = "New Hampshire",
                    TwoLetterCode = "NH",
                    ThreeLetterCode = "NH",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "New Jersey",
                    ShortName = "NJ",
                    Description = "New Jersey",
                    TwoLetterCode = "NJ",
                    ThreeLetterCode = "NJ",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "New Mexico",
                    ShortName = "NM",
                    Description = "New Mexico",
                    TwoLetterCode = "NM",
                    ThreeLetterCode = "NM",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "New York",
                    ShortName = "NY",
                    Description = "New York",
                    TwoLetterCode = "NY",
                    ThreeLetterCode = "NY",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "North Carolina",
                    ShortName = "NC",
                    Description = "North Carolina",
                    TwoLetterCode = "NC",
                    ThreeLetterCode = "NC",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "North Dakota",
                    ShortName = "ND",
                    Description = "North Dakota",
                    TwoLetterCode = "ND",
                    ThreeLetterCode = "ND",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Ohio",
                    ShortName = "OH",
                    Description = "Ohio",
                    TwoLetterCode = "OH",
                    ThreeLetterCode = "OH",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Oklahoma",
                    ShortName = "OK",
                    Description = "Oklahoma",
                    TwoLetterCode = "OK",
                    ThreeLetterCode = "OK",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Oregon",
                    ShortName = "OR",
                    Description = "Oregon",
                    TwoLetterCode = "OR",
                    ThreeLetterCode = "OR",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Pennsylvania",
                    ShortName = "PA",
                    Description = "Pennsylvania",
                    TwoLetterCode = "PA",
                    ThreeLetterCode = "PA",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Rhode Island",
                    ShortName = "RI",
                    Description = "Rhode Island",
                    TwoLetterCode = "RI",
                    ThreeLetterCode = "RI",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "South Carolina",
                    ShortName = "SC",
                    Description = "South Carolina",
                    TwoLetterCode = "SC",
                    ThreeLetterCode = "SC",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "South Dakota",
                    ShortName = "SD",
                    Description = "South Dakota",
                    TwoLetterCode = "SD",
                    ThreeLetterCode = "SD",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Tennessee",
                    ShortName = "TN",
                    Description = "Tennessee",
                    TwoLetterCode = "TN",
                    ThreeLetterCode = "TN",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Texas",
                    ShortName = "TX",
                    Description = "Texas",
                    TwoLetterCode = "TX",
                    ThreeLetterCode = "TX",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Utah",
                    ShortName = "UT",
                    Description = "Utah",
                    TwoLetterCode = "UT",
                    ThreeLetterCode = "UT",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Vermont",
                    ShortName = "VT",
                    Description = "Vermont",
                    TwoLetterCode = "VT",
                    ThreeLetterCode = "VT",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Virginia",
                    ShortName = "VA",
                    Description = "Virginia",
                    TwoLetterCode = "VA",
                    ThreeLetterCode = "VA",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Washington",
                    ShortName = "WA",
                    Description = "Washington",
                    TwoLetterCode = "WA",
                    ThreeLetterCode = "WA",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "West Virginia",
                    ShortName = "WV",
                    Description = "West Virginia",
                    TwoLetterCode = "WV",
                    ThreeLetterCode = "WV",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Wisconsin",
                    ShortName = "WI",
                    Description = "Wisconsin",
                    TwoLetterCode = "WI",
                    ThreeLetterCode = "WI",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                },
                new State
                {
                    Name = "Wyoming",
                    ShortName = "WY",
                    Description = "Wyoming",
                    TwoLetterCode = "WY",
                    ThreeLetterCode = "WY",
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    CountryId = countryId
                }
            };

            foreach (var state in states)
                if (!context.States.Any(s => s.ShortName == state.ShortName))
                    context.States.Add(state);

            context.SaveChanges();
        }
             
        private void AddOrganizationServices(DB context, int orgId, string userId)
        {
            DateTime currDateTime = DateTime.Now;
            context.OrganizationServices.AddOrUpdate(p => p.Name,
                new OrganizationService
                {
                    Name = "System Integration",
                    ShortDescription = "BAP as Integration Platform",
                    Description = "BAP gives you ability to easily integrate different kind of applications into single solution. That may include combination of legacy and new applications.",
                    Enabled = true,
                    IconClass = "fa fa-arrows-alt",
                    Order = 1,
                    OwnerGroup = 127,
                    OwnerPermissions = 302799,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = currDateTime,
                    CreatedBy = userId,
                    LastModifiedDate = currDateTime,
                    LastModifiedBy = userId
                },
                new OrganizationService
                {
                    Name = "Workflows & Scheduling",
                    ShortDescription = "Custom Workflow Management",
                    Description = "BAP gives set of abilities to build your custom business worflows. Those can be applied to your specific business entities. There is also scheduling available.",
                    Enabled = true,
                    IconClass = "fa fa-refresh",
                    Order = 2,
                    OwnerGroup = 127,
                    OwnerPermissions = 302799,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = currDateTime,
                    CreatedBy = userId,
                    LastModifiedDate = currDateTime,
                    LastModifiedBy = userId
                },
                new OrganizationService
                {
                    Name = "Tracking & Reporting",
                    ShortDescription = "Events Monitoring & Reporting",
                    Description = "This has ability to monitor application activity and build ad-hoc reports around custom business entities. Result delivery via Email is available.",
                    Enabled = true,
                    IconClass = "fa fa-list-alt",
                    Order = 3,
                    OwnerGroup = 127,
                    OwnerPermissions = 302799,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = currDateTime,
                    CreatedBy = userId,
                    LastModifiedDate = currDateTime,
                    LastModifiedBy = userId
                },
                new OrganizationService
                {
                    Name = "Responsive",
                    ShortDescription = "Responsive Web Design",
                    Description = "We use modern web development frameworks like Bootstrap 3.0. This brings ability to built front-end application for most types of devices (including mobile).",
                    Enabled = true,
                    IconClass = "fa fa-window-restore",
                    Order = 4,
                    OwnerGroup = 127,
                    OwnerPermissions = 302799,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = currDateTime,
                    CreatedBy = userId,
                    LastModifiedDate = currDateTime,
                    LastModifiedBy = userId
                },
                new OrganizationService
                {
                    Name = "Email Notifications",
                    ShortDescription = "Email-based Events Broadcasting",
                    Description = "This gives ability to receive notifications about various events in the system via email. BAP gives ability to easily manage list of subscribers and types of event deliver.",
                    Enabled = true,
                    IconClass = "fa fa-envelope-o",
                    Order = 5,
                    OwnerGroup = 127,
                    OwnerPermissions = 302799,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = currDateTime,
                    CreatedBy = userId,
                    LastModifiedDate = currDateTime,
                    LastModifiedBy = userId
                },
                new OrganizationService
                {
                    Name = "Social",
                    ShortDescription = "Social Networks Integration",
                    Description = "Here you can include social networks (e.g. FaceBook, Google+, Twitter, Instagramm) into workflows. This means ability to communicate with social networks from the app.",
                    Enabled = true,
                    IconClass = "fa fa-group",
                    Order = 6,
                    OwnerGroup = 127,
                    OwnerPermissions = 302799,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = currDateTime,
                    CreatedBy = userId,
                    LastModifiedDate = currDateTime,
                    LastModifiedBy = userId
                },
                new OrganizationService
                {
                    Name = "Analytics",
                    ShortDescription = "SEO & Analytics",
                    Description = "We support Google Tag Manager as automated host for any kind of analytical tags (e.g. Google Analitics, Bing).",
                    Enabled = true,
                    IconClass = "fa fa-line-chart",
                    Order = 7,
                    OwnerGroup = 127,
                    OwnerPermissions = 302799,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = currDateTime,
                    CreatedBy = userId,
                    LastModifiedDate = currDateTime,
                    LastModifiedBy = userId
                },
                new OrganizationService
                {
                    Name = "Cloud Storage",
                    ShortDescription = "Cloud-based Content Storage",
                    Description = "We use modern cloud-bases solutions to store large amounts of content. This brings better realibility and flexibility of content management.",
                    Enabled = true,
                    IconClass = "fa fa-cloud",
                    Order = 8,
                    OwnerGroup = 127,
                    OwnerPermissions = 302799,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = currDateTime,
                    CreatedBy = userId,
                    LastModifiedDate = currDateTime,
                    LastModifiedBy = userId
                },
                new OrganizationService
                {
                    Name = "Secure Communication",
                    ShortDescription = "Secure Communication Protocols",
                    Description = "BAP has built-in suppport to secure socket layer protocol (SSL) for dealing with sensitive data. This makes sure all transactions are processed in secure and reliable way.",
                    Enabled = true,
                    IconClass = "fa fa-expeditedssl",
                    Order = 9,
                    OwnerGroup = 127,
                    OwnerPermissions = 302799,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = currDateTime,
                    CreatedBy = userId,
                    LastModifiedDate = currDateTime,
                    LastModifiedBy = userId
                },
                new OrganizationService
                {
                    Name = "Multi-lingual",
                    ShortDescription = "Multiple Languages Support",
                    Description = "BAP provides ability to easily develop application with multi-language support. It also gives ability to manage multi-lingual dictionaries.",
                    Enabled = true,
                    IconClass = "fa-language",
                    Order = 10,
                    OwnerGroup = 127,
                    OwnerPermissions = 302799,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = currDateTime,
                    CreatedBy = userId,
                    LastModifiedDate = currDateTime,
                    LastModifiedBy = userId
                },
                new OrganizationService
                {
                    Name = "Multi-tenant",
                    ShortDescription = "Software as a Service (Saas)",
                    Description = "BAP is built on the principles of Software as a Service (SaaS) architecture. This allows to develop application where multiple customers can use it independently.",
                    Enabled = true,
                    IconClass = "fa fa-clone",
                    Order = 11,
                    OwnerGroup = 127,
                    OwnerPermissions = 302799,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = currDateTime,
                    CreatedBy = userId,
                    LastModifiedDate = currDateTime,
                    LastModifiedBy = userId
                },
                new OrganizationService
                {
                    Name = "CMS",
                    ShortDescription = "Basic Content Management System",
                    Description = "BAP provides set of basic functions to manage content on the backend. This functionality can be customized and extended via customer request.",
                    Enabled = true,
                    IconClass = "fa fa-code",
                    Order = 12,
                    OwnerGroup = 127,
                    OwnerPermissions = 302799,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = currDateTime,
                    CreatedBy = userId,
                    LastModifiedDate = currDateTime,
                    LastModifiedBy = userId
                });
        }

        /// <summary>
        /// Adds the localizations.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="orgId">The org identifier.</param>
        /// <param name="userId">The user identifier.</param>
        private void AddLocalizations(DB context, int orgId, string userId)
        {
            context.Localizations.RemoveRange(context.Localizations);
            context.SaveChanges();

            #region insert data            

            AddLocalization(context, "UIText_Menu_BAP", "BAP", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_Users", "Users", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_Subscriptions", "Subscriptions", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_Subscriber", "Subscriber", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "CodeText_AboutApplicationDescription", "Your application description page.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "CodeText_ContactPageDescription", "Your contact page.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "CodeText_ContactVia", "Contact via", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "CodeText_From", "from", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_Agent", "Agent", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_Attachment", "Attachment", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_Property", "Property", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_AgentHasNoEmail", "Agent has no email address", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_GeneralCannotSendEmail", "Something went wrong, cannot send email. Please contact System Administrator.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_InvalidLoginAttempt", "Invalid login attempt.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_InvalidVerifiedCode", "Invalid code.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_ManageLoginsGeneric", "An error has occurred.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_NewPasswordConfirmation", "The new password and confirmation password do not match.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_NoAgentFound", "No agent details found.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_NoDefaultOrganization", "Cannot register user - default organization is not set. Please contact system administratot.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_NoEmailRequest", "No email request received.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_NoMailServiceConfigured", "No mailing service configured.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_PasswordLength", "The {0} must be at least {2} characters long.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_VerifyPhoneNumberFailed", "Failed to verify phone", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_AddressLine1", "Address 1", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_AddressLine2", "Address 2", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_CellNumber", "Mobile", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_City", "City", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_Country", "Country", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_County", "County", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_Email", "Email", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_FaxNumber", "Fax", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_FirstName", "First Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_FullAddress", "Address", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_FullName", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_Id", "Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_InsuranceId", "Insurance Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_LastName", "Last Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_LicenceId", "Licence Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_MiddleName", "Middle Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_PersonalId", "Personal Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_PhoneNumber", "Phone", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_State", "State", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_TaxId", "Tax Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_Zip", "Zip", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_AttachmentType", "Type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_File", "Upload File", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_Id", "Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_Length", "Size", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_PathUrl", "Path Url", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_Published", "Published", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_PublishFrom", "Publish From", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_PublishTo", "Publish To", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_Status", "Status", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_StatusDate", "Status Date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_AttachmentHistory_Attachment", "Attachment", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_AttachmentHistory_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_AttachmentHistory_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_AttachmentHistory_FileName", "File Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_AttachmentHistory_FilePath", "File Path", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_AttachmentHistory_Id", "Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_ExchangeRate", "Exchange Rate", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_Symbol", "Symbol", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_ThreeLetterCode", "Three Letter Code", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventCode", "Event Code", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventMachineName", "Machine Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventSource", "Event Source", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventTime", "Event Time", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventType", "Event Type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventUrl", "Event URL", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventUrlReferrer", "URL Referrer", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventUserAgent", "User Agent", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_Id", "Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_IpAddress", "IP Address", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_Code", "Code", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_ConfirmPassword", "Confirm password", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_CurrentPassword", "Current password", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_Email", "Email", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_Password", "Password", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_PhoneNumber", "Phone Number", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_RememberBrowser", "Remember this browser?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_RememberMe", "Remember me?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_CreateDate", "Create Date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_DateRangeFrom", "Date Range From", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_DateRangeTo", "Date Range To", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_EntityFilter", "Entity Filter", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_EntityName", "Entity Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_EntityNameField", "Entity Name Field", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_EntityOrderBy", "Entity Order By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_EntityValueField", "Entity Value Field", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_FloatRangeFrom", "Float Range From", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_FloatRangeStep", "Float Range Step", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_FloatRangeTo", "Float Range To", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_Id", "Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_IntRangeFrom", "Int. Range From", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_IntRangeTo", "Int. Range To", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_ParentLookup", "Parent Lookup", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_RangePrefix", "Range Prefix", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_Type", "Type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_CreateDate", "Create Date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_CreatedBy", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_CultureCode", "Culture Code", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_Id", "Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_Key", "Lookup Key", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_LastModifiedBy", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_Order", "Order", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_ParentKey", "Parent Key", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_Text", "Text", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_Id", "Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_Status", "Status", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_StatusDate", "Status Date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_TaxId", "Tax Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_AddedDate", "Added At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_AddressLine1", "Address 1", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_AddressLine2", "Address 2", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_AssetNo", "Asset No", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_CellNumber", "Cell No", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_City", "City", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Comments", "Comments", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Country", "Country", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_County", "County", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_CreateDate", "Create At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Currency", "Currency", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Electricity", "Electricity?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_ElectricWaterHeating", "Electric Water Heating?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Email", "Email", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_EnergySavingRate", "ESR", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_FaxNumber", "Fax", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Garage", "Garage?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Gas", "Gas?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_GasWhaterHeating", "Gas Whater Heating?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_GlobalCentralHeating", "Global Central Heating?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Height", "Height", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_HotWaterSuply", "Hot Water Suply?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Id", "Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_InternalStatus", "Internal Status", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_InternalStatusSetByUserName", "Status Set By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_InternaStatusDate", "Internal Status Date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_KitchenSquare", "Kitchen Square", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Latitude", "Latitude", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_ListPrice", "List Price", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_LivingSquare", "Living Square", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_LoanNo", "Loan No", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_LocalCentralHeating", "Local Central Heating?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Longitude", "Longitude", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_MainImageUrl", "Main Image Url", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_MapUrl", "Map URL", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Mark", "Mark", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_NoOfGarages", "Garages", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_OriginalListPrice", "Original List Price", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_PhoneNumber", "Phone", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Pool", "Pool?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_PriceType", "Price Type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_PropertyType", "Property Type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Published", "Published?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_PublishFrom", "Publish From", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_PublishTo", "Publish To", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_SectionNo", "Section No", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_SecureParking", "Secure Parking?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_ShortDescription", "Short Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Spa", "Spa?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_State", "State", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Status", "Status", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_StatusDate", "Status Date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_StoreNo", "Store No", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_TotalBathrooms", "Total Bathrooms", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_TotalBedrooms", "Total Bedrooms", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_TotalRooms", "Total Rooms", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_TotalSquare", "Total Square", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_TotalStores", "Total Stores", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_TotalUnits", "Total Units", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_UnitNo", "Unit No", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_UploadAttachment", "Attachment File", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_UploadedAttachmentType", "Type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_UploadPhoto", "Image file", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_VideoUrl", "Video Url", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_WaterSuply", "Water Suply?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Website", "Website", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Zip", "Zip", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_Id", "Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_Published", "Published?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_PublishFrom", "Publish From", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_PublishTo", "Publish To", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_Feature", "Feature", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_Id", "Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_Published", "Published?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_PublishFrom", "Publish From", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_PublishTo", "Publish To", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkService_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkService_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkService_Id", "Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkService_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkService_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkService_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkService_ServiceType", "Service Type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "StatusText_AddPhoneSuccess", "Your phone number was added.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "StatusText_PasswordChanged", "Your password has been changed.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "StatusText_PasswordRemoved", "The external login was removed.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "StatusText_PasswordSet", "Your password has been set.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "StatusText_RemovePhoneSuccess", "Your phone number was removed.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "StatusText_SetTwoFactorSuccess", "Your two-factor authentication provider has been set.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_AddToFavorites", "Add to Favorites", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ApplicationLogo", "B.A.P.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ApplicationTitle", "B.A.P. Application", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Attachments", "Attachments", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Back", "Back", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_BackToList", "Back to List", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Bathrooms", "Bathrooms", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Bedrooms", "Bedrooms", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Cancel", "Cancel", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Resend", "Resend", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ChooseLookupType", "Choose Type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ContactAddress", "", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ContactEmail", "info@bap-software.com", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ContactPhone", "+353 1 254 8862", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ContactUsQuick", "Contact us quickly", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Create", "Create", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_CreateNewAccount", "Quickly register new account with us", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_DefaultOrder", "Default Order", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Details", "Details", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_DropDown_SelectOption", "Select", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Edit", "Edit", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Features", "Features", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Garages", "Garages", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Hello", "Hello", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_HomePage", "Home Page", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_LoginAccount", "Login as account", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_LoginLink", "Log in", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_LogOffLink", "Log off", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MainPhoto", "Main Photo", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ManageLink", "Manage", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Map", "Map", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Marketing", "Marketing", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MarketingEmail", "Marketing@bap-software.com", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_About", "About", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Administration", "Administration", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Appartment", "Appartment", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_AppartmentBuilding", "Apartment Building", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Condominium", "Condominium", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Contact", "Contact", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_ForRent", "For Rent", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_ForSale", "For Sale", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Index", "Home", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Office", "Office", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Property", "Property", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_SingleHome", "Single Family Home", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Status", "Status", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Types", "Types", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Villa", "Villa", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MoreDetails", "More Details", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_OrderDateNew", "Date New to Old", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_OrderDateOld", "Date Old to New", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_OrderPriceHigh", "Price High to Low", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_OrderPriceLow", "Price Low to High", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_OrWord", "OR", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Print", "Print", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertiesPageDescription", "List of properties", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertiesPageTitle", "Properties", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertyID", "Property ID", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_QuickLinks", "Quick links", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_RegisterLink", "Register to", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_RegisterNewUser", "Register as a new user", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_SearchResults", "Search result", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ShareThis", "Share this", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_SortBy", "Sort By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_SquareMeasure", "Sq Ft", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Support", "Support", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_SupportEmail", "support@bap-software.com", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_UseLocalAccount", "Login to", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Video", "Video", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_UploadedAttachmentName", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_UploadedPhotoName", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Save", "Save", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Delete", "Delete", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Lock", "Lock", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Unlock", "Unlock", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_AttachmentHistory_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_AttachmentHistory_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_MapZoom", "Map Zoom", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Featured", "Featured?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_Organization", "Organization", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_OrganizationType", "Organization type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_AddressLine1", "Address", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_AddressLine2", "Additional Address", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_City", "City", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_CompanyName", "Company Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_CompanyNumber", "Company Number", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_CompanyDescription", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_Country", "Country", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_County", "County", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_FaxNumber", "Fax", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_FirstName", "First Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_HomePhone", "Home Phone", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_InsuranceNumber", "Insurance No", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_LastName", "Last Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_LicenceNumber", "Licence No", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_MiddleName", "Middle Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_MobilePhone", "Mobile Phone", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_RegistrationType", "Registration Type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_State", "State", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_SubscriptionTerm", "Subscription Term", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_SubscriptionType", "Subscription Type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_TaxNumber", "Tax No", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_Url", "Web Site", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_WorkPhone", "Work Phone", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_WorkPhoneEx", "Ext.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_Zip", "Zip", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_AddressLine1", "Address 1", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_AddressLine2", "Address 2", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_CellNumber", "Cell Phone", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_City", "City", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_Country", "Country", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_County", "County", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_FirstName", "First Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_LastName", "Last Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_MiddleName", "Middle Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_PhoneNumber", "Home Phone", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_State", "State", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_Zip", "Zip", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_AddressLine1", "Address 1", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_AddressLine2", "Address 2", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_City", "City", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_Country", "Country", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_County", "County", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_FaxNumber", "Fax", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_PhoneExtension", "Ext.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_PhoneNumber", "Phone", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_State", "State", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_Zip", "Zip", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_Subscription", "Subscription", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Subscription_AutoRenew", "Auto Renew?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Subscription_ContractDate", "Contract Effective Date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Subscription_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Subscription_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Subscription_InitialTerm", "Initial Term", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Subscription_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Subscription_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Subscription_Organization", "Organization", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Subscription_RenewalTerm", "Renewal Term", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Subscription_SubscriptionType", "Subscription Type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Subscription_SubTotal", "Subtotal", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Subscription_TermEnd", "Term Ends", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Subscription_TermStart", "Term Starts", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Subscription_User", "User", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_NoDataFound", "No data found", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_SureToDelete", "Are you sure you want to delete this", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_EntityAssembly", "Assembly", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_EntityClass", "Class", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_AttachmentHistory", "History Item", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_AttachmentHistoryItems", "History Items", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_Currency", "Currency", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_Lookup", "Lookup", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_LookupValue", "Lookup Value", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_EventLog", "Event Log", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_Messages", "Messages", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Search", "Search", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ChangePassword", "Change Password", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ChPasswordTitle", "Change your password here", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Additional", "Additional", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Address", "Address", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_AgentName", "Agent Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Agents", "Agent(s)", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Chooselocationtype", "Choose location type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Chosen", "Chosen", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Coordinates", "Coordinates", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Extrainformation", "Extra information", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Identity", "Identity", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Location", "Location", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Media", "Media", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Photo", "Photo", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Primary", "Primary", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Specification", "Specification", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_OrganizationUser", "User", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_FullName", "Full Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_UserName", "User Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Actions", "Actions", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_AccessFailedCount", "Access Failed Count", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_Email", "User Email", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_EmailConfirmed", "Email Confirmed?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_LockoutEnabled", "Lockout?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_LockoutEndDateUtc", "Lockout When", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_Roles", "Roles", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_TwoFactorEnabled", "Two Factor?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Attachment", "Attachment", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Filesmustbe", "Files must be", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Image", "Image", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Images", "Images", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Main", "Main", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Maxsize10mb", "Max size 10mb", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Maxsize2mb", "Max size 2mb", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertyImage", "Property Image", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertySpecificationDescription", "Property Specification Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertySpecificationName", "Property Specification Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_CodeFromVideoHosting", "Code from Youtube or Vimeo only", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_PutDescriptionHere", "Put some description...", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_AgentsAndCompanies", "AGENTS &amp; COMPANIES - START NOW!", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_FindAProperty", "Find A Property", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_GettingStarted", "Getting started", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Keyword", "Keyword", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ManageYourProperties", "Manage your properties with iRealty.guru", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MaxArea", "Max Area", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MaxPrice", "Max Price", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MinArea", "Min Area", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MinBaths", "Min Baths", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MinBeds", "Min Beds", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MinPrice", "Min Price", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertyStatus", "Property Status", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertyType", "Property Type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_SearchLocation", "Location", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_TakeATour", "Take a tour", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_FeaturedProperties", "Featured Properties", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ViewFeaturedList", "View a list of Featured Properties.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Keyword", "Any", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_MaxArea", "Sq Ft", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_MinArea", "Sq Ft", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_SearchLocation", "Any", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "CodeText_ResetPasswordEmail", "Please reset your password by clicking &lt;a href=\"{0}\"&gt;here.&lt;/a&gt;", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Ok", "Ok", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ResetPassword", "Reset Password", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ResetPasswordConfirmation", "Password reset email has been sent to this email {0}, thank you!", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ResetPasswordNotice", "By submitting this form you will send password reset email to the following user:", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_AssignedTo", "Assigned To", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ExternalLogins", "External Logins", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_NotImplemented", "Sorry, not implemented yet.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ObjectAcccess", "Object Access", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Subscriptions", "Subscriptions", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Address1", "Address line", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Address2", "Additional address line", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_City", "City", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_County", "County", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_ESR", "Energy saving rate", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Garages", "Number", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_KitchenSquare", "Sq Ft", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Latitude", "Latitude", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_LivingSquare", "Sq Ft", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Longitude", "Longitude", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_MapURL", "Google Maps Link", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_PropertyDescription", "Value", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_PropertyName", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_State", "State", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_TotalBathrooms", "Number", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_TotalBedrooms", "Number", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_TotalRooms", "Number", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_TotalSquare", "Sq Ft", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_TotalUnits", "Number of units", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Zip", "Zip", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_NoAgentsAreAvailable", "No agents are available to assign to the property.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_NoAttachmentsLoadedYet", "No attachments loaded yet", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_NoImagesLoadedYet", "No images loaded yet", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_AssetNo", "Number", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Comments", "Put some comments...", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_ListPrice", "Price", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_LoanNo", "Number", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_OriginalListPrice", "Price", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_ShortDescription", "Put some short description...", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_VideoHTMLCode", "Video HTML-code", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Paging", "Paging", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Navigation", "Navigation", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_BasicSettings", "Basic Settings", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Agents", "Agents", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Companies", "Companies", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Countries", "Countries", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Currencies", "Currencies", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_CustomConfigurations", "Custom Configurations", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_EmailNotifications", "Email Notifications", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_EventLog", "Event Log", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Messages", "Messages", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Lookups", "Lookups", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Localizations", "Localizations", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Organizations", "Organizations", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Organization", "Organization", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Services", "Services", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_SocialNetworks", "Social Networks", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Subscriptions", "Subscriptions", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_NewsLetters", "News Letters", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Users", "Users", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Workflows", "Workflows", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Any", "Any", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Pricing", "Pricing", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_NoAgentCreated", "Agent cannot be created.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_NoAgentUserCreated", "User cannot be created for an agent.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "CodeText_AddUser", "Add user", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "CodeText_AddUserSuccess", "User has been added to the this agent.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "CodeText_CreateUserSuccess", "User has been created and added to this agent.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "CodeText_RemoveAgentUserSuccess", "User has been removed from agent, but it's still available within list of logins.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_AgentUser", "Agent's User", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_ContactEmail", "Contact email", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_FacebookUrl", "Facebook", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_GoogleplusUrl", "Google+", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_LinkedinUrl", "Linkedin", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_InstagramUrl", "Instagram", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_LogoFile", "Upload logo", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_LogoPathUrl", "Logo file", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_SupportEmail", "Support email", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_TwitterUrl", "Twitter", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_Url", "Web site", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_BlogUrl", "Blog url", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Navigate", "Navigate", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_Blog", "Blog", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_BlogAuthor", "BlogAuthor", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_BlogComment", "Blog Comment", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_BlogPost", "Blog Post", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Blog", "Blog", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogAuthor_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogAuthor_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogAuthor_Email", "Email", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogAuthor_FirstName", "First Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogAuthor_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogAuthor_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogAuthor_LastName", "Last Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogAuthor_Login", "LoginUser", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogAuthor_NickName", "Nick Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogAuthor_WebSite", "Web Site", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_BlogAuthor", "Author", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_BlogComments", "Comments", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_BlogPosts", "Posts", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_Blogs", "Blogs", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_CreateDate", "Create At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_MainImageUrl", "Image", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_ShortDescription", "Short Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_Tags", "Tags", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_FormatString", "Format string", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_IsEnabled", "Enabled?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_IsMain", "Is Main", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_RoundTo", "Round to", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_RequiredField", "This is required field", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Submit", "Submit", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowActionAttribute_AttributeType", "Attribute Type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowActionAttribute_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowActionAttribute_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowActionAttribute_DataSource", "Data Source", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowActionAttribute_DeafultValue", "Default Value", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowActionAttribute_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowActionAttribute_IsPublic", "Public?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowActionAttribute_IsReadonly", "Readonly?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowActionAttribute_IsVisisble", "Visisble?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowActionAttribute_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowActionAttribute_LastModifiedDate", "Last modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowActionAttribute_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowActionAttribute_ShortDescription", "Short Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowActionAttribute_WorkflowAction", "Action", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowAction_ActionAssembly", "Action Assembly", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowAction_ActionClass", "Action Class", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowAction_ActionType", "Action Type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowAction_Attributes", "Attributes", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowAction_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowAction_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowAction_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowAction_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowAction_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowAction_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowAction_ShortDescription", "Short Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowAction_Workflow", "Workflow", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowClass_Actions", "Actions", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowClass_AllowedRoles", "Allowed Roles", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowClass_BapEntityAssembly", "Entity Assembly", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowClass_BapEntityClass", "Entity Class", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowClass_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowClass_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowClass_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowClass_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowClass_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowClass_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowClass_ShortDescription", "Short Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowClass_Stages", "Stages", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowClass_Transitions", "Transitions", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowObject_BapEntityAssembly", "Entity Assembly", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowObject_BapEntityClass", "Entity Class", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowObject_BapEntityId", "Entity Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowObject_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowObject_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowObject_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowObject_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowObject_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowObject_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowObject_ShortDescription", "Short Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowObject_Workflow", "Workflow", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowObject_WorkflowData", "Workflow Data", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowStageTransition_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowStageTransition_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowStageTransition_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowStageTransition_FromStage", "From Stage", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowStageTransition_InjectedActions", "Injected Actions", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowStageTransition_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowStageTransition_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowStageTransition_MainImageUrl", "Main Image Url", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowStageTransition_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowStageTransition_ShortDescription", "Short Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowStageTransition_ToStage", "To Stage", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowStageTransition_Workflow", "Workflow", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowStage_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowStage_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowStage_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowStage_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowStage_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowStage_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowStage_ShortDescription", "Short Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowStage_StageType", "Stage Type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowStage_Workflow", "Workflow", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_WorkflowClasses", "Workflows", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_WorkflowClass", "Workflows", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_WorkflowAction", "Workflow Action", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_WorkflowActionAttribute", "Workflow Action Attribute", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_WorkflowStage", "Workflow Stage", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_WorkflowStageTransitions", "Workflow Stage Transition", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_WorkflowActionAttributes", "WF Action Attributes", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_WorkflowActions", "Workflow Actions", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_WorkflowStages", "Workflow Stages", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_WorkflowStageTransitions", "WF Stage Transitions", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_FileSystem", "File System", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_FileSystem", "File System and Media Manager", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MediaResources", "Media Resources", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Upload", "Upload", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BAPFileSystemFolder_CurrentFileFilter", "File Filter", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BAPFileSystemFolder_CurrentFileSort", "File Sort", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BAPFileSystemFolder_CurrentFolder", "Current Folder", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BAPFileSystemFolder_CurrentFolderFiles", "Current Folder Files", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BAPFileSystemFolder_FilesPerPage", "Files Per Page", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BAPFileSystemFolder_RootFolders", "Root Folder", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BAPFile_Description", "File Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BAPFile_LastModified", "Last Modified", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BAPFile_MimeType", "Mime Type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BAPFile_Name", "File Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BAPFile_Size", "Size", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BAPFile_Type", "File Type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BAPFolder_ChildFolders", "Child Folders", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BAPFolder_Description", "Folder Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BAPFolder_FullRelativePath", "Folder Relative Path", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BAPFolder_Name", "Folder Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BAPFolder_ParentFolder", "Parent Folder", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BAPFileSystemFolder_PageNumber", "Page #", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BAPFileSystemFolder_PageCount", "Page Count", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PleaseConfirm", "Please confirm", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_AttachmentHistory_Length", "Length", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_AltText", "Alt Text", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_Keywords", "Keywords", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_MimeType", "Mime Type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_PathAliases", "Path Aliases", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_TitleText", "Title Text", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Attachments", "Attachments", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_ContentManagement", "Content Management", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ContentManagement", "Content Management", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_ContentManagement", "Content Management", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_Action", "Action", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_ActionParams", "Action Parameters", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_Alias", "Alias", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_AliasPath", "Alias Path", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_Area", "Routing Area", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_ChildNodes", "Children", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_ContentAuthor", "Content Author", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_ContentDescription", "Content Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_ContentKeywords", "Content Keywords", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_ContentTagGroup", "Content Tag Group", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_ContentTags", "Content Tags", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_ContentTitle", "Content Title", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_Controller", "Controller", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_Culture", "Culture", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_DefaultCss", "Defalt CSS", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_Enabled", "Enabled?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_LayoutPath", "Layout Path", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_MenuCaption", "Menu Caption", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_NavigationType", "Navigation Type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_ParentNode", "Parent Node", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_Rating", "Rating", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_ShortDescription", "Short Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_ShowInMenu", "Show in menu?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_ShowInSitemap", "Show in sitemap?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_SitemapChangeFrequency", "Sitemap Change Frequency", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_SitemapPriority", "Sitemap Priority", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_UrlAliases", "URL Aliases", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_AllowChildren", "Allow children?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_Roles", "Roles", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControlParameter_Caption", "Caption", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControlParameter_ContentViewControl", "View Control", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControlParameter_ContentViewControlId", "Control Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControlParameter_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControlParameter_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControlParameter_CssClass", "CSS Class", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControlParameter_DataSource", "Data Source", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControlParameter_DataType", "Data Type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControlParameter_DefaultErrorMessage", "Default Error Message", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControlParameter_DefaultValue", "Default Value", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControlParameter_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControlParameter_FormControl", "Form Control", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControlParameter_IsReadOnly", "Read only?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControlParameter_IsRequired", "Required?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControlParameter_IsVisible", "Visible?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControlParameter_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControlParameter_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControlParameter_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControlParameter_ParameterName", "Parameter Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControlParameter_PlaceHolder", "Place Holder", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControlParameter_ShortDescription", "Short Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentLocalization_ContentNode", "Content Node", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentLocalization_ContentNodeId", "Content Node Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentLocalization_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentLocalization_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentLocalization_CultureCode", "Culture", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentLocalization_IsDefault", "Default?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentLocalization_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentLocalization_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentLocalization_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentLocalization_Text", "Text", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNodeRoute_Action", "Action", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNodeRoute_Area", "Area", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNodeRoute_ContentNode", "Content Node", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNodeRoute_ContentNodeId", "Content Node Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNodeRoute_Controller", "Controller", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNodeRoute_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNodeRoute_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNodeRoute_DataTokens", "Data Tokens", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNodeRoute_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNodeRoute_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNodeRoute_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNodeRoute_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNodeRoute_NameSpaces", "Namespaces", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNodeRoute_Roles", "Roles", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNodeRoute_RouteName", "Route Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNodeRoute_RouteParameters", "Route Parameters", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNodeRoute_Url", "Url", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_ContainerContent", "Container Content", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_ContainerCss", "Container CSS", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_ContainerTag", "Container Tag", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_ContentAfter", "Content After", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_ContentBefore", "Content Before", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_ContentNode", "Content Node", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_ContentNodeId", "Node Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_ContentView", "Content View", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_ContentViewId", "Content View Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_ControlId", "Control Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_ControlTitle", "Control Title", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_ControlType", "Control Type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_IsReadOnly", "Read only?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_IsVisible", "Visible?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_JavaScript", "JavaScript", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_StyleContent", "Style", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentView_ContentNode", "Content Node", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentView_ContentNodeId", "Node Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentView_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentView_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentView_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentView_IsPartial", "Partial?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentView_IsShared", "Shared?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentView_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentView_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentView_LayoutPath", "Layout Path", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentView_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentView_Roles", "Roles", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentView_ViewName", "View Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentView_ViewPath", "View Path", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_View", "View", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentView_Enabled", "Enabled?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentView_IsMain", "Main?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_Views", "Content Views", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_IsHome", "Home page?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_NameSpaces", "Namespaces", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_RouteUrl", "Route Pattern", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_WebSiteRoot", "Web Site Root", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_AuthCookieExpirationTime", "Authentication Cookie Expiration Time", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_AuthCookieName", "Authentication Cookie Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_BapDefaultContactEmail", "Default Coontact Email", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_BapDefaultFromEmail", "Default From Email", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_BaseFolder", "Base Folder", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_BaseFolderText", "Base Folder", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_BearerTokenExpirationTime", "Bearer Token Expiration Time", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_GetBearrerTokenDuringLogin", "Get Bearer Token on Login?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_HostName", "Host Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_HostNameAliases", "Host Name Aliases", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_HostNameAliasesText", "Host Name Aliases", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_ImplementedCultures", "Imlemented Cultures", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_ImplementedCulturesText", "Implemented Cultures", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_PublicFolder", "Public Folder", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_PublicFolderText", "Public Folder", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_reCaptchaSecretKey", "reCaptcha Secret Key", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_reCaptchaSiteKey", "reCaptcha Site Key", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_SmtpHostName", "SMTP Host Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_SmtpPort", "SMTP Port", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_SmtpUserName", "SMTP User Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_SmtpUserPassword", "SMTP User Password", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_SmtpUseSsl", "SMTP Use SSL?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_WebApiAllowInsecureHttp", "Web API Allow Insecure HTTP", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_WebApiPublicClientId", "Web API Publid Client Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentView_IsLayout", "Layout?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Select", "Select", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_Error", "Error", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Item", "Item", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_RegisteredDaysAgo", "Registered days ago", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_CriteriaCompareOperator_Between", "between", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_CriteriaCompareOperator_Contains", "contains", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_CriteriaCompareOperator_Custom", "custom", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_CriteriaCompareOperator_EndWith", "end with", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_CriteriaCompareOperator_Equal", "=", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_CriteriaCompareOperator_IsOneOf", "is one of", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_CriteriaCompareOperator_Less", "&lt;", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_CriteriaCompareOperator_LessEqual", "&lt;=", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_CriteriaCompareOperator_More", "&gt;", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_CriteriaCompareOperator_MoreEqual", "&gt;=", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_CriteriaCompareOperator_None", "None", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_CriteriaCompareOperator_NotEqual", "&lt;&gt;", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_CriteriaCompareOperator_NotOneOf", "not one of", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_CriteriaCompareOperator_StartWith", "start with", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ChooseOperator", "Choose operator", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_ValueGoesHere", "value goes here", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentView_ViewContent", "View Content", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentView_ContentNodes", "Nodes", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_NoStaticHtmlAllowed", "Static HTML is not allowed on the root of the web site. Please choose parent folder for it.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationService_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationService_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationService_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationService_Enabled", "Enabled?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationService_IconClass", "Icon CSS", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationService_ImageUrl", "Image URL", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationService_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationService_LastModifiedDate", "Last Modified At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationService_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationService_Order", "Order No", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationService_ShortDescription", "Short Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_HttpMethod", "HTTP Method", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_MenuClicable", "Menu Clickable?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_MenuExtraAttributes", "Menu Extra Attributes", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_MenuIcon", "Menu Icon", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_MenuSortOrder", "Menu Sort Order", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentNode_UrlTarget", "Url Target", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_OrganizationServices", "Services", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_OrganizationService", "Organization Services", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Subscriber_Email", "Email", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Subscriber_Enabled", "Enabled", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Subscriber_RegisterDate", "Register Date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Subscriber_LastNewsletterIdReceived", "Last Newsletter", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Subscriber_CreateDate", "Create Date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Subscriber_LastModifiedDate", "Last Modified Date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Subscriber_CreatedByUserName", "Created By Username", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Subscriber_LastModifiedByUserName", "Last Modified By Username", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_NoProductsFound", "No Products match the search criteria.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_NoShipping", "This Product doesn't need shipping.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ShippingOptionsAvailable", "The following shipping options are available", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_YouMustAgree", "You need to agree to terms and conditions before proceeding further.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Cookies_Button", "I have read this notice", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Cookies_Header", "Important information regarding cookies", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Cookies_Link", "You can find out more here.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Privacy_Policy", "Privacy Policy", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Cookies_Text_Start", "We use cookies to improve website performance, analysis, and personalization of websites. By using the site or by clicking I agree you agree to our", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Cookies_Text_End", "for the use of cookies.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Gdpr_Button", "I agree and wish to proceed", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Gdpr_Header", "Please sign GDPR agreement", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Gdpr_Link", "You can find out more here.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Gdpr_Text", "Our site is under compliance with the General Data Protection Regulation (GDPR). The GDPR is an EU legislation that is designed to protect the fundamental rights of citizens and their personal data. This law ensures that people not only know where their private data is kept, but it also holds organizations accountable and transparent in their practices.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Generic_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Generic_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Generic_IsEnabled", "Is enabled", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Generic_CreateDate", "Create date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Generic_LastModifiedDate", "Last modified date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Generic_CreatedByUserName", "Created by user name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Generic_LastModifiedByUserName", "Last modified by user name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControl_Type", "Content Control Type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_ContentControlTypes", "Content Control Types", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_ContentControls", "Content Controls", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_ContentControlType", "Content Control Type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_ContentControl", "Content Control", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Stores", "Stores", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_ContentControlId", "Content Control Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentViewControl_ContentControl", "Content Control", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Store_ChoosePayment", "Choose payment to add:", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Store_AddPaymentOption", "Add Payment Option", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Store_NoPaymentOptionsSelected", "No payment options selected", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Store_ChooseShipping", "Choose shipping to add:", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Store_AddShippingOption", "Add Shipping Option", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Store_NoShippingOptionsSelected", "No shipping options selected", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Store_ChooseProductCategories", "Choose product categories to add:", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Store_AddProductCategory", "Add Product Category", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Store_NoProductCategoriesSelected", "No product categories selected", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Store_ChooseDiscountCoupons", "Choose discount coupons to add:", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Store_AddDiscountCoupon", "Add Discount Coupon", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Store_NoDiscountCouponsSelected", "No discount coupons selected", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Subscription_TermRange", "Term range", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControl_ContainerTag", "HTML Tag", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControl_ContentAfter", "Content After", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControl_ContentBefore", "Content Before", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControl_ContentHolderFieldId", "Content Holder Field Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControl_DialogContent", "Dialog Content", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControl_HasCKEditor", "Use CKEditor?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControl_HasDialog", "Has dialog?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControl_IconCss", "Icon CSS", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControl_JavaScriptContent", "Javascript Content", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ContentControl_MainCss", "Main CSS", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Generic_DisplayName", "Display Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Store_NoPaymentMethodsSelected", "No payment methods selected", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ChangeTwoFactorAuthQuestion", "Do you want to toggle two factor authentication?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ChangeYourPassword", "Change your password", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_DisableTwoFactorAuth", "Disable two factor authentication", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_EnableTwoFactorAuth", "Enable two factor authentication", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MyAccountDetails", "My account details", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_SetPassword", "Set Password", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Code_SelectedProvider", "Selected Provider", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_404Error", "We couldn't find it...", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ErrorDetails", "Error Details", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_GeneralErrorText", "An error occurred while processing your request.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_NewsLetter", "News Letter", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_Module", "Module", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_NewsLetter_Title", "Title", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_NewsLetter_Subtitle", "Subtitle", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_NewsLetter_TextHtml", "Text html", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_NewsLetter_ImagePath", "Image path", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_NewsLetter_PublishDate", "Publish date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_NewsLetter_Published", "Published", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_NewsLetter_CreateDate", "Create date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_ScheduledTasks", "Scheduled Tasks", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_ScheduledTask", "Scheduled Tasks", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ScheduledTask_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ScheduledTask_ShortName", "Short Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ScheduledTask_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ScheduledTask_UniqueId", "Unique Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ScheduledTask_Recurring", "Recurring", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ScheduledTask_Running", "Running", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ScheduledTask_Executions", "Executions", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ScheduledTask_LastRun", "Last Run", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ScheduledTask_NextRun", "Next Run", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ScheduledTask_Interval", "Interval", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ScheduledTask_JobClass", "Job Class", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ScheduledTask_JobAssembly", "Job Assembly", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ScheduledTask_JobData", "Job Data", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ScheduledTask_LastResult", "Last Result", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ScheduledTask_LastMessage", "Last Message", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ScheduledTask_Enabled", "Enabled", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ScheduledTask_CreateDate", "Create Date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ScheduledTask_LastModifiedDate", "Last Modified Date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ScheduledTask_CreatedByUserName", "Created By User Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_ScheduledTask_LastModifiedByUserName", "Last Modified By User Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ViewHangfireDashboard", "View Hangfire Dashboard", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_SeeMoreAttachments", "See more attachments...", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ErrorNoFileNoAttachment", "Cannot create attachment if file is not uploaded.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_Thumbnail", "Thumbnail", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Generic_CultureCode", "Culture code", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Generic_CategoryCode", "Category code", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Generic_LocalizationId", "Localization Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Subscribers", "Newsletter Subscribers", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ThanksRegisteringNewsletters", "Thanks for registering your email {0} to receive our newsletters!", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_CloneLocale", "Clone to different language", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_LocalizagionCloneDone", "Entity {0} with Id = {1}, has been cloned to the {2} culture. You can see it under appropriate locale.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_FileNotFound", "File not found", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_FilePathNotFound", "File not found: {0}.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_FileSystemNotConfigured", "File system is not configured", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Blogs", "Blogs", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogPost_Title", "Title", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogPost_ShortDescription", "Short description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogPost_Text", "Text", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogPost_MainImageUrl", "Main Image Url", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogPost_Blog", "Blog", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogPost_CreateDate", "Create date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogPost_LastModifiedDate", "Last modified date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogPost_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogPost_LastModifiedByUserName", "Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogPost_BlogComments", "Blog Comments", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogPost_PostImages", "Blog Images", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_SeeMoreBlogPosts", "See more blog posts...", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_SeeMoreBlogComments", "See more blog comments...", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogComment_Title", "Title", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogComment_Author", "Author", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogComment_Text", "Text", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogComment_Blog", "Blog", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogPost_BlogPost", "Blog post", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogComment_CreateDate", "Created At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogComment_LastModifiedDate", "Last Modified", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogComment_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogComment_LastModifiedByUserName", "Last Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_Description_MaxCharacters", "Maximum 4000 characters allowed", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogComment_Text_MaxCharacters", "Maximum 4000 characters allowed", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogPost_Text_MaxCharacters", "Maximum 4000 characters allowed", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PostComment", "post comment", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_LeaveComments", "Leave Comments", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogComment_AuthNeeded", "You need to sign-up to leave comments", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Message_FromAddress", "From", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Message_ToAddress", "To", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Message_CopyAddress", "Copy", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Message_BlackCopyAddress", "Black copy", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Message_Subject", "Subject", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Message_Body", "Body", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Message_Sent", "Sent", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Message_SentDate", "Sent date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Message_CreateDate", "Create date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Message_LastModifiedDate", "Last modified date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Message_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Message_LastModifiedByUserName", "Modified By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_MessageWasSent", "Message was sent", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_DocumentTemplate_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_DocumentTemplate_ShortDescription", "Short description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_DocumentTemplate_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_DocumentTemplate_TemplateBody", "Template body", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_DocumentTemplate_IsEnabled", "Enabled", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_DocumentTemplate_TemplateType", "Template type", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_DocumentTemplate_CreateDate", "Created", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_DocumentTemplate_LastModifiedDate", "Last modified", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_DocumentTemplate_CreatedByUserName", "Created By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_DocumentTemplate_LastModifiedByUserName", "Last modified by", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_DocumentTemplates", "Document Templates", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_DocumentTemplate", "Document Template", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_DocumentTemplate_Description_MaxCharacters", "Maximum 4000 characters allowed", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Module_BitMask", "Bitmask", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Module_CreateDate", "Create date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Module_CreatedByUserName", "Created by", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Module_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Module_Enabled", "Enabled", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Module_GlobalId", "Global Id", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Module_LastModifiedByUserName", "Last modified by", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Module_LastModifiedDate", "Last modified date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Module_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Module_Roles", "Roles", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Module_ShortDescription", "Short description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Modules", "Modules", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_Modules", "Modules", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Module_Organizations", "Organizations", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationModule_Module", "Module", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationModule_Organization", "Organization", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_OrganizationModules", "Modules", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Organization_AddOrganizationModule", "Add module", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Organization_ChooseOrganizationModules", "Choose modules to add:", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Organization_NoOrganizationModulesSelected", "No organization modules selected", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Common_CreateDate", "Created", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Common_CreatedBy", "Created by", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Common_CreatedByUserName", "Created by", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Common_Description", "Description", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Common_LastModifiedBy", "Last modified by", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Common_LastModifiedByUserName", "Last modified by", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Common_LastModifiedDate", "Last modified", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Common_Name", "Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Common_ShortName", "Short name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Country_FlagSvg11Path", "Flag SVG 1x1", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Country_FlagSvg43Path", "Flag SVG 4x3", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Country_ThreeLetterCode", "Three letters code", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Country_TwoLetterCode", "Two letters code", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_Country", "Country", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_State_ThreeLetterCode", "Three letters code", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_State_TwoLetterCode", "Two letters code", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_State_Country", "Country", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Country_States", "States", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_State", "State", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_SeeMoreStates", "See more states...", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_State_Text_MaxCharacters", "Maximum 1000 characters allowed", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_Categories", "Categories", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_FollowUs", "Follow Us", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_RecentPost", "Recent Post", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_BAPBlog", "BAP Blog", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_BAPSoftware", "BAP-Software LLC", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_ContactUs", "Contact us", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_PoweredBy", "Powered by BAP-Software", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_Uncategorized", "Uncategorized", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_Archives", "Archives", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_AddComment", "Add a Comment", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_Comment_Reply", "Reply", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_Comment_LikeOrDislike", "Like or Dislike", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_Comment_NotifyMe", "Notify me of follow-up comments by email", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_Comment_Submit", "Submit Comment", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_Comment_YourName", "Your Name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_Comment_YourTitle", "Your Title", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_Comment", "Comment", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_Search", "Search Our Stories...", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_SearchFor", "Search for:", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogComment_LikeNumber", "Like number", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogComment_DislikeNumber", "Dislike number", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogComment_NotifyAuthorByEmail", "Notify author by email", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_BlogComment_CommentAuthorUser", "Comment author user", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_LatestBlogPosts", "Latest Blog Posts", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_LatestRecentPosts", "Recent Posts", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_PostedBy", "Posted By", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Blog_ReadMore", "Read More", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomConfiguration_AssemblyName", "Assembly name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomConfiguration_ClassName", "Class name", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomConfiguration_DefaultConfiguration", "Default сonfiguration", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomConfiguration_CurrentConfiguration", "Current сonfiguration", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_CustomConfiguration", "Custom configuration", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Assemblies", "Assemblies", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Assemblies_Classes", "Assemblies and classes", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_CustomConfiguration_Saved", "Custom configuration was saved!", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Useful_Links", "Useful Links", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Review_ValidationErrors", "Please review validation errors below:", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "Account_UserWithEmail_NotRegistered", "A user with email {0} is not registered", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationModule_Order", "Order", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationModule_UrlAlias", "Url", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ApplicationSlogan", "We Fuel Your Business!", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UITtext_Error_UnknownOrganization", "Organization is unknown", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_WorkflowActionAlreadyWorkflowTranstionAction", "Cannot add workflow action {0}, it is already present as action item.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Workflow_AlreadyAdded", "Action already added to the transition.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Workflow_NotWork", "Only action of Work type can be added as required to the transition.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkflowActionAttribute_AttributeDirection", "Direction", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_NoWorkflow", "No workflow found for the object", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_WFActionDoIt", "Do It", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_WFActionErrorOccured", "Sorry,it look like an error occured while performing the given action, please contact support for more details and resolution.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_WFActionsRRequiredTitle", "Actions are required to perform:", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_WFBusProcessTitle", "Business Process", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_WFChooseTrans", "Choose", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_WFCommentsHere", "Put stage comment here...", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_WFPutCommentsTitle", "Put some comments before move:", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_WFTransIsNotPossible", "Transition is not possible - conditions are not met yet, please check required action to complete if any.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Close", "Close", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_NoPageRenamed", "Page rename could not be performed.", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_DocumentTemplate_TemplateBodyText", "Template Text", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_DocumentTemplate_TemplateBodyUrl", "Template URL", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_WFAttachDocument", "Attach Document", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Add", "Add", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_AccessTokenExpiresAt", "Token Expires At", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_AllowedToRoles", "Allowed to Roles", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_IsSecured", "Secured?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_PublicAccessToken", "Access Token", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_AttributeType_None", "None", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_AttributeType_Text", "Text", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_AttributeType_Number", "Number", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_AttributeType_Currency", "Currency", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_AttributeType_Date", "Date", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_AttributeType_Time", "Time", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_AttributeType_DateTime", "DateTime", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_AttributeType_File", "File", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_AttributeType_Url", "Url", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_AttributeType_Email", "Email", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_AttributeDirection_None", "None", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_AttributeDirection_Input", "Input", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_AttributeDirection_Output", "Output", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EnumValue_AttributeDirection_Both", "Both", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_CookiesPopupEnabled", "Cookues Popup?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_GdprPopupEnabled", "GDPR Popup?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ForgotYourPassword", "Forgot your password?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_AlreadyHaveAccount", "Already have an account?", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ForgotPassword", "Forgot Password", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ButtonAddViews", "Add Views", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ButtonClearCache", "Clear Cache", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ButtonCustomize", "Customize", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ButtonPublish", "Publish", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_InputWFActionAttribs", "Enter Action Attributes", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ShowWFActionAttribs", "Action Attributes", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_AttributesRequired", "Attributes required:", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ChooseBusinessFlow", "Choose business flow:", null, "BAP.Resources.Resources", orgId, userId);
            
            #endregion

            context.SaveChanges();
        }

        /// <summary>
        /// Adds the localization.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="locale">The locale.</param>
        /// <param name="resourceSet">The resource set.</param>
        /// <param name="orgId">The org identifier.</param>
        /// <param name="userId">The user identifier.</param>
        private void AddLocalization(DB context, string name, string value, string locale, string resourceSet, int orgId, string userId)
        {
            DateTime currDateTime = DateTime.Now;
            var localization = new Localization
            {
                Name = name,
                Value = value,
                CultureCode = locale,
                ResourceSet = resourceSet,
                OwnerGroup = 127,
                OwnerPermissions = 302799,
                TenantUnit = "Organization",
                TenantUnitId = orgId,
                CreateDate = currDateTime,
                CreatedBy = userId,
                LastModifiedDate = currDateTime,
                LastModifiedBy = userId
            };
            context.Set<Localization>().Add(localization);
        }
    }
}
