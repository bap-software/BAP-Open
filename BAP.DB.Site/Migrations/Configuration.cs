using System.Collections.Generic;

namespace BAP.DB.Migrations
{
    using System;
    using System.Linq;
    using System.Data.Entity.Migrations;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using BL.AspNetIdentity;
    using DAL.Entities;
    using BAP.eCommerce.DAL.Entities;
    using System.Data.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<BAP.DB.DB>
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
            var adminUserName = "admin@bap-software.com";
            var jobRunnerUserName = "worker@bap-software.com";
            var contentManagerUserName = "cmng@bap-software.com";
            var siteContentManagerUserName = "scmng@bap-software.com";
            var eCommerceContentManagerUserName = "ecmng@bap-software.com";
            var blogContentManagerUserName = "bgmng@bap-software.com";
            var supervisorUserName = "sprvsr@bap-software.com";
            var createDateTime = DateTime.Now;

            //Insert User Roles
            AddRole(context, "Administrator");
            AddRole(context, "ContentManager");
            AddRole(context, "Supervisor");
            AddRole(context, "User");

            //Insert Users
            var adminUserId = AddUser(context, adminUserName, "Administrator");

            //Insert Organization - initiate tenant and make application functioning
            var organization = context.Organizations.FirstOrDefault(a => a.Name == "BAP Web Site");
            if (organization == null)
            {
                organization = new Organization
                {
                    Name = "BAP Web Site",
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
                    PhoneNumber = "+353 87 785 6746",
                    OwnerGroup = 127,
                    OwnerPermissions = 310991,
                    FacebookUrl = "http://facebook.com/bapsoftware",
                    TwitterUrl = "http://twitter.com",
                    LinkedinUrl = "http://linkedin.com",
                    GoogleplusUrl = "http://plus.google.com",
                    InstagramUrl = "https://www.instagram.com",
                    ContactEmail = "info@bap-software.com",
                    SupportEmail = "support@bap-software.com",
                    ImplementedCulturesText = "en-US",
                    HostName = "127.0.0.1",
                    HostNameAliasesText = "localhost:50678,bap-software.comd,dev.bap-software.com",
                    BapDefaultFromEmail = "support@bap-software.com",
                    BapDefaultContactEmail = "info@bap-software.com",
                    SmtpUserName = "support@bap-software.com",
                    SmtpUserPassword = "Test$123",
                    SmtpHostName = "mail.bap-software.com",
                    SmtpPort = 8889,
                    SmtpUseSsl = false,
                    reCaptchaSiteKey = "6LdqCgsUAAAAAO5ysJIQzLm0Lbk1cLAKYytYnMiW",
                    reCaptchaSecretKey = "6LdqCgsUAAAAAErowDwY0Gi04cJaZZUMBqjVALks",
                    GetBearrerTokenDuringLogin = true,
                    AuthCookieName = "bapweb-base-cookiie-name",
                    AuthCookieExpirationTime = 20,
                    WebApiPublicClientId = "bapweb-web-api-client",
                    BearerTokenExpirationTime = 14,
                    WebApiAllowInsecureHttp = true,
                    PublicFolderText = "/Files/BAPWeb/Public/",
                    BaseFolderText = "/Files/BAPWeb/",
                    StatusDate = createDateTime,
                    CookiesPopupEnabled = true,
                    GdprPopupEnabled = false
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
                    CellNumber = "0877856746",
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

            //Job runner built-in user
            var userId = AddUser(context, jobRunnerUserName, "User",
                "ujhg234jhjf6543543hj5%Kj5hfnbv!ghgffgkhggfh^&&^f&^7f77^$^%#%$39887h");
            orgUser = context.OrganizationUsers.FirstOrDefault(a =>
                a.AspNetUserId == userId && a.TenantUnit == "Organization" && a.TenantUnitId == organization.Id);
            if (orgUser == null)
            {
                orgUser = new OrganizationUser
                {
                    AspNetUserId = userId,
                    FirstName = "Job",
                    LastName = "Runner",
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

            //Content manager user - default one
            userId = AddUser(context, contentManagerUserName, "ContentManager");
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

            // eCommerce content manager
            userId = AddUser(context, eCommerceContentManagerUserName, "ContentManager");
            orgUser = context.OrganizationUsers.FirstOrDefault(a =>
                a.AspNetUserId == userId && a.TenantUnit == "Organization" && a.TenantUnitId == organization.Id);
            if (orgUser == null)
            {
                orgUser = new OrganizationUser
                {
                    AspNetUserId = userId,
                    FirstName = "eCommerce Content",
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

            // Blog content manager
            userId = AddUser(context, blogContentManagerUserName, "ContentManager");
            orgUser = context.OrganizationUsers.FirstOrDefault(a =>
                a.AspNetUserId == userId && a.TenantUnit == "Organization" && a.TenantUnitId == organization.Id);
            if (orgUser == null)
            {
                orgUser = new OrganizationUser
                {
                    AspNetUserId = userId,
                    FirstName = "Blog Content",
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

            // Supervisor
            userId = AddUser(context, supervisorUserName, "Supervisor");
            orgUser = context.OrganizationUsers.FirstOrDefault(a =>
                a.AspNetUserId == userId && a.TenantUnit == "Organization" && a.TenantUnitId == organization.Id);
            if (orgUser == null)
            {
                orgUser = new OrganizationUser
                {
                    AspNetUserId = userId,
                    FirstName = "Supervisor",
                    LastName = "Supervisor",
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
            Lookup lookup = null;
            lookup = context.Lookups.FirstOrDefault(a => a.Name == "SizeType");
            if (lookup == null)
            {
                lookup = new Lookup
                {
                    Name = "SizeType",
                    Description = "Size Type",
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
            UpsertLookupValue(context, organization.Id, lookup, "in"/*key*/, "in"/*text*/, "Inches"/*description*/, "en-US", 1, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "cm"/*key*/, "cm"/*text*/, "Cantimeters"/*description*/, "en-US", 2, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "m"/*key*/, "m"/*text*/, "Metres"/*description*/, "en-US", 3, adminUserId);


            lookup = context.Lookups.FirstOrDefault(a => a.Name == "WeightType");
            if (lookup == null)
            {
                lookup = new Lookup
                {
                    Name = "WeightType",
                    Description = "Weight Type",
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
            UpsertLookupValue(context, organization.Id, lookup, "lb"/*key*/, "lb"/*text*/, "Lbs"/*description*/, "en-US", 1, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "kg"/*key*/, "kg"/*text*/, "Kilograms"/*description*/, "en-US", 2, adminUserId);

            lookup = context.Lookups.FirstOrDefault(a => a.Name == "ProductInternalStatus");
            if (lookup == null)
            {
                lookup = new Lookup
                {
                    Name = "ProductInternalStatus",
                    Description = "Product Internal Status",
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
            UpsertLookupValue(context, organization.Id, lookup, "discounted"/*key*/, "Discounted"/*text*/, "Marked as discounted"/*description*/, "en-US", 1, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "newmodel"/*key*/, "New Model"/*text*/, "New model of the product recently arrived"/*description*/, "en-US", 2, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "trendng"/*key*/, "Trending Product"/*text*/, "Product currently trending on the market"/*description*/, "en-US", 3, adminUserId);

            lookup = context.Lookups.FirstOrDefault(a => a.Name == "ProductPublicStatus");
            if (lookup == null)
            {
                lookup = new Lookup
                {
                    Name = "ProductPublicStatus",
                    Description = "Product Public Status",
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
            UpsertLookupValue(context, organization.Id, lookup, "bestseller"/*key*/, "Bestseller"/*text*/, "Bestseller product"/*description*/, "en-US", 1, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "new"/*key*/, "New"/*text*/, "New arrival"/*description*/, "en-US", 2, adminUserId);


            lookup = context.Lookups.FirstOrDefault(a => a.Name == "ProductType");
            if (lookup == null)
            {
                lookup = new Lookup
                {
                    Name = "ProductType",
                    Description = "Product Type",
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
            UpsertLookupValue(context, organization.Id, lookup, "main"/*key*/, "Main"/*text*/, "Main product type sold by the system"/*description*/, "en-US", 1, adminUserId);
            UpsertLookupValue(context, organization.Id, lookup, "option"/*key*/, "Option"/*text*/, "Product option"/*description*/, "en-US", 2, adminUserId);

            lookup = context.Lookups.FirstOrDefault(a => a.Name == "AttachmentType");
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
            context.ContentNodes.RemoveRange(context.ContentNodes);
            context.SaveChanges();
            node = new ContentNode
            {
                Name = "Site",
                Alias = "Site",
                AliasPath = "/",
                ShowInMenu = true,
                ShowInSitemap = true,
                NavigationType = NavigationType.MvcRoute,
                Rating = 1,
                Controller = "Home",
                Action = "Index",
                Enabled = true,
                SitemapPriority = SitemapPriority.Normal,
                SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                MenuCaption = "Home",
                AllowChildren = true,
                View = "Index",
                IsHome = true,
                RouteUrl = "{controller}/{action}/{id}",
                NameSpaces = "BAP.Web.Controllers",
                MenuClicable = true,
                MenuSortOrder = 1,
                TenantUnit = "Organization",
                TenantUnitId = organization.Id,
                CreateDate = createDateTime,
                CreatedBy = adminUserId,
                LastModifiedDate = createDateTime,
                LastModifiedBy = adminUserId,
                OwnerGroup = 127,
                OwnerPermissions = 8143
            };
            context.ContentNodes.Add(node);
            parentNode = node;
            
            node = new ContentNode
            {
                Name = "About",
                Alias = "about",
                AliasPath = "/about",
                ShowInMenu = true,
                ShowInSitemap = true,
                NavigationType = NavigationType.MvcRoute,
                Rating = 1,
                Area = "",
                Controller = "Home",
                Action = "About",
                Enabled = true,
                SitemapPriority = SitemapPriority.Normal,
                SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                MenuCaption = "About",
                AllowChildren = true,
                View = "About",
                IsHome = false,
                RouteUrl = "about",
                NameSpaces = "BAP.Web.Controllers",
                MenuClicable = true,
                MenuSortOrder = 2,
                TenantUnit = "Organization",
                TenantUnitId = organization.Id,
                CreateDate = createDateTime,
                CreatedBy = adminUserId,
                LastModifiedDate = createDateTime,
                LastModifiedBy = adminUserId,
                OwnerGroup = 127,
                OwnerPermissions = 8143
            };
            context.ContentNodes.Add(node);

            node = new ContentNode
            {
                Name = "Services",
                Alias = "services",
                AliasPath = "/services",
                ShowInMenu = true,
                ShowInSitemap = true,
                NavigationType = NavigationType.MvcRoute,
                Rating = 1,
                Area = "",
                Controller = "Home",
                Action = "Services",
                Enabled = true,
                SitemapPriority = SitemapPriority.Normal,
                SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                MenuCaption = "Services",
                AllowChildren = true,
                View = "Services",
                IsHome = false,
                RouteUrl = "services",
                NameSpaces = "BAP.Web.Controllers",
                MenuClicable = true,
                MenuSortOrder = 3,
                TenantUnit = "Organization",
                TenantUnitId = organization.Id,
                CreateDate = createDateTime,
                CreatedBy = adminUserId,
                LastModifiedDate = createDateTime,
                LastModifiedBy = adminUserId,
                OwnerGroup = 127,
                OwnerPermissions = 8143
            };
            context.ContentNodes.Add(node);

            node = new ContentNode
            {
                Name = "Contact",
                Alias = "contact",
                AliasPath = "/contact",
                ShowInMenu = true,
                ShowInSitemap = true,
                NavigationType = NavigationType.MvcRoute,
                Rating = 1,
                Area = "",
                Controller = "Home",
                Action = "Contact",
                Enabled = true,
                SitemapPriority = SitemapPriority.Normal,
                SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                MenuCaption = "Contact",
                AllowChildren = true,
                View = "Contact",
                IsHome = false,
                RouteUrl = "contact",
                NameSpaces = "BAP.Web.Controllers",
                MenuClicable = true,
                MenuSortOrder = 4,
                TenantUnit = "Organization",
                TenantUnitId = organization.Id,
                CreateDate = createDateTime,
                CreatedBy = adminUserId,
                LastModifiedDate = createDateTime,
                LastModifiedBy = adminUserId,
                OwnerGroup = 127,
                OwnerPermissions = 8143
            };
            context.ContentNodes.Add(node);

            node = new ContentNode
            {
                Name = "Pricing",
                Alias = "pricing",
                AliasPath = "/pricing",
                ShowInMenu = true,
                ShowInSitemap = true,
                NavigationType = NavigationType.MvcRoute,
                Rating = 1,
                Area = "",
                Controller = "Home",
                Action = "Pricing",
                Enabled = true,
                SitemapPriority = SitemapPriority.Normal,
                SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                MenuCaption = "Pricing",
                AllowChildren = true,
                View = "Pricing",
                IsHome = false,
                RouteUrl = "pricing",
                NameSpaces = "BAP.Web.Controllers",
                MenuClicable = true,
                MenuSortOrder = 5,
                TenantUnit = "Organization",
                TenantUnitId = organization.Id,
                CreateDate = createDateTime,
                CreatedBy = adminUserId,
                LastModifiedDate = createDateTime,
                LastModifiedBy = adminUserId,
                OwnerGroup = 127,
                OwnerPermissions = 8143
            };
            context.ContentNodes.Add(node);


            node = new ContentNode
            {
                Name = "PrivacyPolicy",
                Alias = "privacypolicy",
                AliasPath = "/privacypolicy",
                ShowInMenu = false,
                ShowInSitemap = true,
                NavigationType = NavigationType.MvcRoute,
                Rating = 1,
                Area = "",
                Controller = "Home",
                Action = "PrivacyPolicy",
                Enabled = true,
                SitemapPriority = SitemapPriority.Normal,
                SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                MenuCaption = "PrivacyPolicy",
                AllowChildren = false,
                View = "PrivacyPolicy",
                IsHome = false,
                RouteUrl = "privacypolicy",
                NameSpaces = "BAP.Web.Controllers",                
                MenuClicable = false,
                MenuSortOrder = 6,
                TenantUnit = "Organization",
                TenantUnitId = organization.Id,
                CreateDate = createDateTime,
                CreatedBy = adminUserId,
                LastModifiedDate = createDateTime,
                LastModifiedBy = adminUserId,
                OwnerGroup = 127,
                OwnerPermissions = 8143
            };
            context.ContentNodes.Add(node);

            //eCommerce Admin
            ContentNode parentShopNode = null;
            node = new ContentNode
            {
                Name = "Shop",
                Alias = "shop",
                AliasPath = "/shop",
                ShowInMenu = true,
                ShowInSitemap = true,
                NavigationType = NavigationType.MvcRoute,
                Rating = 1,
                Area = "eCommerce",
                Controller = "eShop",
                Action = "Index",
                Enabled = true,
                SitemapPriority = SitemapPriority.Normal,
                SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                MenuCaption = "Shop",
                AllowChildren = true,
                Roles = "Administrator,Supervisor",
                View = "Index",
                IsHome = false,
                RouteUrl = "shop",
                MenuIcon = "fa fa-shopping-bag",
                NameSpaces = "BAP.Web.Areas.eCommerce.Controllers",
                MenuClicable = true,
                MenuSortOrder = 5,
                TenantUnit = "Organization",
                TenantUnitId = organization.Id,
                CreateDate = createDateTime,
                CreatedBy = adminUserId,
                LastModifiedDate = createDateTime,
                LastModifiedBy = adminUserId,
                OwnerGroup = 127,
                OwnerPermissions = 8143
            };
            context.ContentNodes.Add(node);
            parentShopNode = node;

            node = new ContentNode
            {
                Name = "Addresses",
                Alias = "Addresses",
                AliasPath = "/Addresses/AdminIndex",
                ShowInMenu = true,
                ShowInSitemap = true,
                NavigationType = NavigationType.MvcRoute,
                Rating = 1,
                Area = "Administration",
                Controller = "Addresses",
                Action = "AdminIndex",
                Enabled = true,
                SitemapPriority = SitemapPriority.Normal,
                SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                MenuCaption = "Address",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 2,
                TenantUnit = "Organization",
                TenantUnitId = organization.Id,
                CreateDate = createDateTime,
                CreatedBy = adminUserId,
                LastModifiedDate = createDateTime,
                LastModifiedBy = adminUserId,
                OwnerGroup = 127,
                OwnerPermissions = 1843151
            };
            context.ContentNodes.Add(node);
            node = new ContentNode
            {
                Name = "Customers",
                Alias = "Customers",
                AliasPath = "/Customers/AdminIndex",
                ShowInMenu = true,
                ShowInSitemap = true,
                NavigationType = NavigationType.MvcRoute,
                Rating = 1,
                Area = "Administration",
                Controller = "Customers",
                Action = "AdminIndex",
                Enabled = true,
                SitemapPriority = SitemapPriority.Normal,
                SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                MenuCaption = "Customers",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 3,
                TenantUnit = "Organization",
                TenantUnitId = organization.Id,
                CreateDate = createDateTime,
                CreatedBy = adminUserId,
                LastModifiedDate = createDateTime,
                LastModifiedBy = adminUserId,
                OwnerGroup = 127,
                OwnerPermissions = 1843151
            };
            context.ContentNodes.Add(node);
            node = new ContentNode
            {
                Name = "CustomerOrders",
                Alias = "CustomerOrders",
                AliasPath = "/CustomerOrders/AdminIndex",
                ShowInMenu = true,
                ShowInSitemap = true,
                NavigationType = NavigationType.MvcRoute,
                Rating = 1,
                Area = "Administration",
                Controller = "CustomerOrders",
                Action = "AdminIndex",
                Enabled = true,
                SitemapPriority = SitemapPriority.Normal,
                SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                MenuCaption = "Customer Orders",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 4,
                TenantUnit = "Organization",
                TenantUnitId = organization.Id,
                CreateDate = createDateTime,
                CreatedBy = adminUserId,
                LastModifiedDate = createDateTime,
                LastModifiedBy = adminUserId,
                OwnerGroup = 127,
                OwnerPermissions = 1843151
            };
            context.ContentNodes.Add(node);
            node = new ContentNode
            {
                Name = "DiscountCoupons",
                Alias = "DiscountCoupons",
                AliasPath = "/DiscountCoupons/AdminIndex",
                ShowInMenu = true,
                ShowInSitemap = true,
                NavigationType = NavigationType.MvcRoute,
                Rating = 1,
                Area = "Administration",
                Controller = "DiscountCoupons",
                Action = "AdminIndex",
                Enabled = true,
                SitemapPriority = SitemapPriority.Normal,
                SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                MenuCaption = "Discount Coupons",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 5,
                TenantUnit = "Organization",
                TenantUnitId = organization.Id,
                CreateDate = createDateTime,
                CreatedBy = adminUserId,
                LastModifiedDate = createDateTime,
                LastModifiedBy = adminUserId,
                OwnerGroup = 127,
                OwnerPermissions = 1843151
            };
            context.ContentNodes.Add(node);
            node = new ContentNode
            {
                Name = "Manufacturers",
                Alias = "Manufacturers",
                AliasPath = "/Manufacturers/AdminIndex",
                ShowInMenu = true,
                ShowInSitemap = true,
                NavigationType = NavigationType.MvcRoute,
                Rating = 1,
                Area = "Administration",
                Controller = "Manufacturers",
                Action = "AdminIndex",
                Enabled = true,
                SitemapPriority = SitemapPriority.Normal,
                SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                MenuCaption = "Manufacturers",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 6,
                TenantUnit = "Organization",
                TenantUnitId = organization.Id,
                CreateDate = createDateTime,
                CreatedBy = adminUserId,
                LastModifiedDate = createDateTime,
                LastModifiedBy = adminUserId,
                OwnerGroup = 127,
                OwnerPermissions = 1843151
            };
            context.ContentNodes.Add(node);
            node = new ContentNode
            {
                Name = "Products",
                Alias = "Products",
                AliasPath = "/Products/AdminIndex",
                ShowInMenu = true,
                ShowInSitemap = true,
                NavigationType = NavigationType.MvcRoute,
                Rating = 1,
                Area = "Administration",
                Controller = "Products",
                Action = "AdminIndex",
                Enabled = true,
                SitemapPriority = SitemapPriority.Normal,
                SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                MenuCaption = "Products",
                ParentNode = parentShopNode,
                Roles = "Administrator,ContentManager,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 7,
                TenantUnit = "Organization",
                TenantUnitId = organization.Id,
                CreateDate = createDateTime,
                CreatedBy = adminUserId,
                LastModifiedDate = createDateTime,
                LastModifiedBy = adminUserId,
                OwnerGroup = 127,
                OwnerPermissions = 1843151
            };
            context.ContentNodes.Add(node);
            node = new ContentNode
            {
                Name = "ProductCategories",
                Alias = "ProductCategories",
                AliasPath = "/ProductCategories/AdminIndex",
                ShowInMenu = true,
                ShowInSitemap = true,
                NavigationType = NavigationType.MvcRoute,
                Rating = 1,
                Area = "Administration",
                Controller = "ProductCategories",
                Action = "AdminIndex",
                Enabled = true,
                SitemapPriority = SitemapPriority.Normal,
                SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                MenuCaption = "Product Category",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 8,
                TenantUnit = "Organization",
                TenantUnitId = organization.Id,
                CreateDate = createDateTime,
                CreatedBy = adminUserId,
                LastModifiedDate = createDateTime,
                LastModifiedBy = adminUserId,
                OwnerGroup = 127,
                OwnerPermissions = 1843151
            };
            context.ContentNodes.Add(node);
            node = new ContentNode
            {
                Name = "ProductOptions",
                Alias = "ProductOptions",
                AliasPath = "/ProductOptions/AdminIndex",
                ShowInMenu = true,
                ShowInSitemap = true,
                NavigationType = NavigationType.MvcRoute,
                Rating = 1,
                Area = "Administration",
                Controller = "ProductOptions",
                Action = "AdminIndex",
                Enabled = true,
                SitemapPriority = SitemapPriority.Normal,
                SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                MenuCaption = "Product Options",
                ParentNode = parentShopNode,
                Roles = "Administrator,ContentManager,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 9,
                TenantUnit = "Organization",
                TenantUnitId = organization.Id,
                CreateDate = createDateTime,
                CreatedBy = adminUserId,
                LastModifiedDate = createDateTime,
                LastModifiedBy = adminUserId,
                OwnerGroup = 127,
                OwnerPermissions = 1843151
            };
            context.ContentNodes.Add(node);
            node = new ContentNode
            {
                Name = "PaymentOptions",
                Alias = "PaymentOptions",
                AliasPath = "/PaymentOptions/AdminIndex",
                ShowInMenu = true,
                ShowInSitemap = true,
                NavigationType = NavigationType.MvcRoute,
                Rating = 1,
                Area = "Administration",
                Controller = "PaymentOptions",
                Action = "AdminIndex",
                Enabled = true,
                SitemapPriority = SitemapPriority.Normal,
                SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                MenuCaption = "Payment Options",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 10,
                TenantUnit = "Organization",
                TenantUnitId = organization.Id,
                CreateDate = createDateTime,
                CreatedBy = adminUserId,
                LastModifiedDate = createDateTime,
                LastModifiedBy = adminUserId,
                OwnerGroup = 127,
                OwnerPermissions = 1843151
            };
            context.ContentNodes.Add(node);
            node = context.ContentNodes.FirstOrDefault(a => a.Name == "ShoppingCarts");
            node = new ContentNode
            {
                Name = "ShoppingCarts",
                Alias = "ShoppingCarts",
                AliasPath = "/ShoppingCarts/AdminIndex",
                ShowInMenu = true,
                ShowInSitemap = true,
                NavigationType = NavigationType.MvcRoute,
                Rating = 1,
                Area = "Administration",
                Controller = "ShoppingCarts",
                Action = "AdminIndex",
                Enabled = true,
                SitemapPriority = SitemapPriority.Normal,
                SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                MenuCaption = "Shopping Carts",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 11,
                TenantUnit = "Organization",
                TenantUnitId = organization.Id,
                CreateDate = createDateTime,
                CreatedBy = adminUserId,
                LastModifiedDate = createDateTime,
                LastModifiedBy = adminUserId,
                OwnerGroup = 127,
                OwnerPermissions = 1843151
            };
            context.ContentNodes.Add(node);
            node = new ContentNode
            {
                Name = "ShippingCarriers",
                Alias = "ShippingCarriers",
                AliasPath = "/ShippingCarriers/AdminIndex",
                ShowInMenu = true,
                ShowInSitemap = true,
                NavigationType = NavigationType.MvcRoute,
                Rating = 1,
                Area = "Administration",
                Controller = "ShippingCarriers",
                Action = "AdminIndex",
                Enabled = true,
                SitemapPriority = SitemapPriority.Normal,
                SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                MenuCaption = "Shipping Carriers",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 12,
                TenantUnit = "Organization",
                TenantUnitId = organization.Id,
                CreateDate = createDateTime,
                CreatedBy = adminUserId,
                LastModifiedDate = createDateTime,
                LastModifiedBy = adminUserId,
                OwnerGroup = 127,
                OwnerPermissions = 1843151
            };
            context.ContentNodes.Add(node);
            node = new ContentNode
            {
                Name = "ShippingOptions",
                Alias = "ShippingOptions",
                AliasPath = "/ShippingOptions/AdminIndex",
                ShowInMenu = true,
                ShowInSitemap = true,
                NavigationType = NavigationType.MvcRoute,
                Rating = 1,
                Area = "Administration",
                Controller = "ShippingOptions",
                Action = "AdminIndex",
                Enabled = true,
                SitemapPriority = SitemapPriority.Normal,
                SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                MenuCaption = "Shipping Options",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 13,
                TenantUnit = "Organization",
                TenantUnitId = organization.Id,
                CreateDate = createDateTime,
                CreatedBy = adminUserId,
                LastModifiedDate = createDateTime,
                LastModifiedBy = adminUserId,
                OwnerGroup = 127,
                OwnerPermissions = 1843151
            };
            context.ContentNodes.Add(node);
            node = new ContentNode
            {
                Name = "Stores",
                Alias = "Stores",
                AliasPath = "/Stores/AdminIndex",
                ShowInMenu = true,
                ShowInSitemap = true,
                NavigationType = NavigationType.MvcRoute,
                Rating = 1,
                Area = "Administration",
                Controller = "Stores",
                Action = "AdminIndex",
                Enabled = true,
                SitemapPriority = SitemapPriority.Normal,
                SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                MenuCaption = "Store",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 14,
                TenantUnit = "Organization",
                TenantUnitId = organization.Id,
                CreateDate = createDateTime,
                CreatedBy = adminUserId,
                LastModifiedDate = createDateTime,
                LastModifiedBy = adminUserId,
                OwnerGroup = 127,
                OwnerPermissions = 1843151
            };
            context.ContentNodes.Add(node);
            node = new ContentNode
            {
                Name = "Suppliers",
                Alias = "Suppliers",
                AliasPath = "/Suppliers/AdminIndex",
                ShowInMenu = true,
                ShowInSitemap = true,
                NavigationType = NavigationType.MvcRoute,
                Rating = 1,
                Area = "Administration",
                Controller = "Suppliers",
                Action = "AdminIndex",
                Enabled = true,
                SitemapPriority = SitemapPriority.Normal,
                SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                MenuCaption = "Suppliers",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 15,
                TenantUnit = "Organization",
                TenantUnitId = organization.Id,
                CreateDate = createDateTime,
                CreatedBy = adminUserId,
                LastModifiedDate = createDateTime,
                LastModifiedBy = adminUserId,
                OwnerGroup = 127,
                OwnerPermissions = 1843151
            };
            context.ContentNodes.Add(node);
            context.SaveChanges();

            //eCommerce settings
            // - PaymentOption
            PaymentOption pOption = null;            
            if (!context.PaymentOptions.Any(a => a.Name == "PayPal"))
            {
                pOption = new PaymentOption
                {
                    Name = "PayPal",
                    ShortDescription = "PayPal",
                    Description = "PayPal Payment Provider",
                    Enabled = true,
                    AsssemblyName = "BAP.eCommerce.PaypalPaymentProvider",
                    ClassName = "BAP.eCommerce.PaypalPaymentProvider.PayPalPaymentProvider",
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    TenantUnit = "Organization",
                    TenantUnitId = organization.Id,
                    CreateDate = createDateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = adminUserId                    
                };
                context.PaymentOptions.Add(pOption);
            }
            else
            {
                pOption = context.PaymentOptions.First(a => a.Name == "PayPal");
                pOption.ClassName = "BAP.eCommerce.PaypalPaymentProvider.PayPalPaymentProvider";
                pOption.OwnerGroup = 127;
                pOption.OwnerPermissions = 1875535;
            }

            context.SaveChanges();

            if (!context.PaymentOptions.Any(a => a.Name == "Credit Card"))
            {
                pOption = new PaymentOption
                {
                    Name = "Credit Card",
                    ShortDescription = "Credit Car via Authorize.Net",
                    Description = "Payment is taken from credit card using Authorize.Net as payment gateway.",
                    Enabled = true,
                    AsssemblyName = "BAP.eCommerce.AuthorizeNetPaymentProvider",
                    ClassName = "BAP.eCommerce.AuthorizeNetPaymentProvider.AuthorizeNetPaymentProvider",
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    TenantUnit = "Organization",
                    TenantUnitId = organization.Id,
                    CreateDate = createDateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = adminUserId
                };
                context.PaymentOptions.Add(pOption);
            }
            else
            {
                pOption = context.PaymentOptions.First(a => a.Name == "Credit Card");
                pOption.ClassName = "BAP.eCommerce.AuthorizeNetPaymentProvider.AuthorizeNetPaymentProvider";
                pOption.OwnerGroup = 127;
                pOption.OwnerPermissions = 1875535;
            }

            context.SaveChanges();

            
            // - Manufacturer	
            var bapMan = AddManufacturer(context, "BAP", "BAP Software LLC", organization.Id, userId, "/file/Public/Manufacturers/brand-apple.png");
            
            // - Product Categories
            var softwareCat = UpsertProductcategory(context, organization.Id, "Software", "Software", "Software to download and use.", 1, adminUserId);
            context.SaveChanges();            
            var assesoriesCat = UpsertProductcategory(context, organization.Id, "Assesories", "Assesories", null, 7, adminUserId);
            context.SaveChanges();

            // - Products
            //UpsertProduct(context, organization.Id, ""/*SKU*/, ""/*Name*/, ""/*shortDescr*/, ""/*Descr*/, ""/*userId*/, 0/*parCatId*/, 0/*manufacturerId*/, ""/*imageUrl*/, 0/*price*/, 0/*listPrice*/);

            UpsertProduct(context, organization.Id, "CMS"/*SKU*/, "BAP CMS"/*Name*/, "BAP Content Management"/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, softwareCat.Id/*parCatId*/, bapMan.Id/*manufacturerId*/, "/file/Public/Products/1.png"/*imageUrl*/, 0/*price*/, 0/*listPrice*/, intStatus: "trending");
            UpsertProduct(context, organization.Id, "BLOG"/*SKU*/, "BAP Blog"/*Name*/, "BAP Blogging Solution with CMS"/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, softwareCat.Id/*parCatId*/, bapMan.Id/*manufacturerId*/, "/file/Public/Products/product-iphone-se.png"/*imageUrl*/, 299.99/*price*/, 0/*listPrice*/);
            UpsertProduct(context, organization.Id, "ECOMM"/*SKU*/, "BAP eCommerce"/*Name*/, "BAP eCommerce Solution with CMS"/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, softwareCat.Id/*parCatId*/, bapMan.Id/*manufacturerId*/, "/file/Public/Products/product-apple-watch.png"/*imageUrl*/, 2999.99/*price*/, 0/*listPrice*/, intStatus: "trending");
            context.SaveChanges();
            
            // - Document Templates
            UpsertDocumentTemplate(context: context, orgId: organization.Id, name: "Customer Order Invoice", shortDescr: "Customer Order Invoice PDF Template", typeName: "financial", fileUrl: "/file/Public/DocumentTemplates/Financial/Customer Order Invoice.html", adminUserId);
            UpsertDocumentTemplate(context: context, orgId: organization.Id, name: "Order Confirmation Email", shortDescr: "Order Confirmation Email Body Template", typeName: "email", fileUrl: "/file/Public/DocumentTemplates/EmailTemplates/Order Confirmation Email.html", adminUserId);
            UpsertDocumentTemplate(context: context, orgId: organization.Id, name: "Customer Order Details", shortDescr: "Customer Order Details Email Body Template", typeName: "email", fileUrl: "/file/Public/DocumentTemplates/EmailTemplates/Customer Order Details.html", adminUserId);

            //Content management
            if (!context.ContentControlTypes.Any(a => a.Name == "Banner"))
            {
                var cct = new ContentControlType
                {
                    Name = "Banner",
                    IsEnabled = true,
                    TenantUnit = "Organization",
                    TenantUnitId = organization.Id,
                    CreateDate = createDateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 31,
                    OwnerPermissions = 1875535
                };
                context.ContentControlTypes.Add(cct);
            }

            if (!context.ContentControlTypes.Any(a => a.Name == "BannerGroup"))
            {
                var cct = new ContentControlType
                {
                    Name = "BannerGroup",
                    IsEnabled = true,
                    TenantUnit = "Organization",
                    TenantUnitId = organization.Id,
                    CreateDate = createDateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 31,
                    OwnerPermissions = 1875535
                };
                context.ContentControlTypes.Add(cct);
            }

            AddModule(context, "Content Management", organization, adminUserId, createDateTime);
            AddModule(context, "eCommerce", organization, adminUserId, createDateTime);
            AddModule(context, "Blog", organization, adminUserId, createDateTime);

            context.SaveChanges();

            //Data fixes
            ExtraDataFixes(context);
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
                    CultureCode = "en-US",
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
            foreach (var cc in context.Addresses)
            {
                cc.OwnerGroup = 127;
                cc.OwnerPermissions = 1850975;
            }
            foreach (var cc in context.Customers)
            {
                cc.OwnerGroup = 127;
                cc.OwnerPermissions = 1851007;
            }
            foreach (var cc in context.CustomerOrders)
            {
                cc.OwnerGroup = 127;
                cc.OwnerPermissions = 1851007;
            }
            foreach (var cc in context.CustomerPayments)
            {
                cc.OwnerGroup = 127;
                cc.OwnerPermissions = 1851007;
            }
            foreach (var cc in context.CustomerOrderPayments)
            {
                cc.OwnerGroup = 127;
                cc.OwnerPermissions = 1851007;
            }
            foreach (var cc in context.CustomConfigurations)
            {
                cc.OwnerGroup = 123;
                cc.OwnerPermissions = 2072079;
            }
            foreach (var cc in context.DiscountCoupons)
            {
                cc.OwnerGroup = 127;
                cc.OwnerPermissions = 1842703;
            }
            foreach (var cc in context.Manufacturers)
            {
                cc.OwnerGroup = 127;
                cc.OwnerPermissions = 1842703;
            }
            foreach (var cc in context.Products)
            {
                cc.OwnerGroup = 127;
                cc.OwnerPermissions = 1843151;
            }
            foreach (var cc in context.ProductCategories)
            {
                cc.OwnerGroup = 127;
                cc.OwnerPermissions = 1875535;
            }
            foreach (var cc in context.ProductOptions)
            {
                cc.OwnerGroup = 127;
                cc.OwnerPermissions = 1843151;
            }
            foreach (var cc in context.PaymentOptions)
            {
                cc.OwnerGroup = 127;
                cc.OwnerPermissions = 1875535;
            }
            foreach (var cc in context.ShoppingCarts)
            {
                cc.OwnerGroup = 127;
                cc.OwnerPermissions = 1867775;
            }
            foreach (var cc in context.ShoppingCartProducts)
            {
                cc.OwnerGroup = 127;
                cc.OwnerPermissions = 1867775;
            }
            foreach (var cc in context.ShippingCarriers)
            {
                cc.OwnerGroup = 127;
                cc.OwnerPermissions = 1875535;
            }
            foreach (var cc in context.ShippingOptions)
            {
                cc.OwnerGroup = 127;
                cc.OwnerPermissions = 1875535;
            }
            foreach (var cc in context.Stores)
            {
                cc.OwnerGroup = 127;
                cc.OwnerPermissions = 1842703;
            }
            foreach (var cc in context.Suppliers)
            {
                cc.OwnerGroup = 127;
                cc.OwnerPermissions = 1842703;
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
            if (thisLoookup != null && thisLoookup.Values != null && thisLoookup.Values.Any(a => a.Key == key && a.CultureCode == culture))
            {
                lValue = thisLoookup.Values.First(a => a.Key == key && a.CultureCode == culture);
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
                    CultureCode = culture,
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
        private Manufacturer AddManufacturer(DB context, string name, string description, int orgId, string userId, string logo)
        {
            var manufacturer = context.Manufacturers.FirstOrDefault(a => a.Name == name && a.TenantUnit == "Organization" && a.TenantUnitId == orgId);
            if (manufacturer == null)
            {
                var dateTime = DateTime.Now;
                manufacturer = new Manufacturer
                {
                    Name = name,
                    ShortDescription = description,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = userId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = userId,
                    OwnerGroup = 31,
                    OwnerPermissions = 7695,
                    CultureCode = "en-US",
                    LocalizationId = Guid.NewGuid(),
                    LogoImage = logo
                };
                context.Manufacturers.Add(manufacturer);
            }
            else
            {
                manufacturer.Name = name;
                manufacturer.ShortDescription = description;
                manufacturer.Description = string.Empty;
                manufacturer.LogoImage = logo;
                manufacturer.LocalizationId = Guid.NewGuid();
            }
            context.SaveChanges();
            return manufacturer;
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

        private ProductCategory UpsertProductcategory(DB context, int orgId, string name, string shortDescription, string description, int order, string upsertUserId, int parentCategoryId = 0)
        {
            ProductCategory prodCat = null;
            if (!context.ProductCategories.Any(a => a.Name == name))
            {
                DateTime createDateTime = DateTime.Now;
                prodCat = new ProductCategory
                {
                    Name = name,
                    Description = description,
                    ShortDescription = shortDescription,
                    ParentCategoryId = parentCategoryId > 0 ? (int?)parentCategoryId : null,
                    Order = order,
                    OwnerGroup = 27,
                    OwnerPermissions = 7695,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = createDateTime,
                    CreatedBy = upsertUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = upsertUserId
                };
                context.ProductCategories.Add(prodCat);
            }
            else
            {
                prodCat = context.ProductCategories.First(a => a.Name == name);
                DateTime updateDateTime = DateTime.Now;
                if (prodCat != null)
                {
                    prodCat.Description = description;
                    prodCat.ShortDescription = shortDescription;
                    prodCat.ParentCategoryId = parentCategoryId > 0 ? (int?)parentCategoryId : null;
                    prodCat.TenantUnitId = orgId;
                    prodCat.LastModifiedBy = upsertUserId;
                    prodCat.LastModifiedDate = updateDateTime;
                }
            }

            return prodCat;
        }

        private Product UpsertProduct(DB context, int orgId, string sku, string name, string shortDescription, string description, string upsertUserId, int parentCategoryId, int manufacturerId, string imageUrl, double price, double listPrice = 0, bool featured = false, string intStatus = "")
        {
            Product prod = null;
            DateTime currDateTime = DateTime.Now;
            if (!context.Products.Any(a => a.SKU == sku))
            {
                prod = new Product
                {
                    UID = Guid.NewGuid(),
                    SKU = sku,
                    Name = name,
                    ShortDescription = shortDescription,
                    Description = description,
                    Price = (float)price,
                    ListPrice = (float)listPrice,
                    Enabled = true,
                    ImagePath = imageUrl,
                    ProductType = "main",
                    ProductCategoryId = parentCategoryId > 0 ? (int?)parentCategoryId : null,
                    ManufacturerId = manufacturerId > 0 ? (int?)manufacturerId : null,
                    OwnerGroup = 27,
                    OwnerPermissions = 7695,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = currDateTime,
                    CreatedBy = upsertUserId,
                    LastModifiedDate = currDateTime,
                    LastModifiedBy = upsertUserId,
                    PublishFrom = currDateTime,
                    PublishTo = currDateTime.AddYears(10),
                    InStoreFrom = currDateTime,
                    ReorderAt = currDateTime.AddYears(10),
                    IsFeatured = featured,
                    InternalStatus = intStatus
                };
                context.Products.Add(prod);
            }
            else
            {
                prod = context.Products.First(a => a.SKU == sku);
                prod.Name = name;
                prod.ShortDescription = shortDescription;
                prod.Description = description;
                prod.ProductCategoryId = parentCategoryId > 0 ? (int?)parentCategoryId : null;
                prod.ManufacturerId = manufacturerId > 0 ? (int?)manufacturerId : null;
                prod.Price = (float)price;
                prod.ListPrice = (float)listPrice;
                prod.ImagePath = imageUrl;
                prod.LastModifiedBy = upsertUserId;
                prod.LastModifiedDate = currDateTime;
                prod.IsFeatured = featured;
                prod.InternalStatus = intStatus;
            }

            return prod;
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
                    IconClass = "fa fa-external-link",
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
    }
}
