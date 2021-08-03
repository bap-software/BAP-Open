// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="Configuration.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Linq;
    using System.Data.Entity.Migrations;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using BL.AspNetIdentity;
    using DAL.Entities;
    using BAP.eCommerce.DAL;

    /// <summary>
    /// Class Configuration. This class cannot be inherited.
    /// Implements the <see cref="BAP.eCommerce.DAL.eCommDbMigrationConfig{BAP.DB.eCommerce.DB}" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.DAL.eCommDbMigrationConfig{BAP.DB.eCommerce.DB}" />
    public sealed partial class Configuration : eCommDbMigrationConfig<DB>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// This method will be called after migrating to the latest version.
        /// </summary>
        /// <param name="context">Current DB context object</param>
        /// <remarks>Note that the database may already contain seed data when this method runs. This means that
        /// implementations of this method must check whether or not seed data is present and/or up-to-date
        /// and then only make changes if necessary and in a non-destructive way. The
        /// <see cref="M:System.Data.Entity.Migrations.DbSetMigrationsExtensions.AddOrUpdate``1(System.Data.Entity.IDbSet{``0},``0[])" />
        /// can be used to help with this, but for seeding large amounts of data it may be necessary to do less
        /// granular checks if performance is an issue.
        /// If the <see cref="T:System.Data.Entity.MigrateDatabaseToLatestVersion`2" /> database
        /// initializer is being used, then this method will be called each time that the initializer runs.
        /// If one of the <see cref="T:System.Data.Entity.DropCreateDatabaseAlways`1" />, <see cref="T:System.Data.Entity.DropCreateDatabaseIfModelChanges`1" />,
        /// or <see cref="T:System.Data.Entity.CreateDatabaseIfNotExists`1" /> initializers is being used, then this method will not be
        /// called and the Seed method defined in the initializer should be used instead.</remarks>
        protected override void Seed(DB context)
        {
            context.Configuration.ValidateOnSaveEnabled = false;
            context.SaveChanges();

            // Main BAP data insert =========================================================================================================================
            var adminUserName = "admin@app.bap-software.com";
            var jobRunnerUserName = "worker@app.bap-siftware.com";
            var contentManagerUserName = "cmng@app.bap-software.com";
            var siteContentManagerUserName = "scmng@app.bap-software.com";
            var blogContentManagerUserName = "bgmng@app.bap-software.com";
            var createDateTime = DateTime.Now;

            //Insert User Roles
            AddRole(context, "Administrator");
            AddRole(context, "ContentManager");
            AddRole(context, "Supervisor");
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
                    ImplementedCulturesText = "en-US,fr-CA,uk-UA,ru-RU",
                    HostName = "127.0.0.1",
                    HostNameAliasesText = "localhost:50678,app.bap-software.comd,app-dev.bap-software.com",
                    BapDefaultFromEmail = "support@yako-paddle.com",
                    BapDefaultContactEmail = "info@yako-paddle.com",
                    SmtpUserName = "support@bap-software.com",
                    SmtpUserPassword = "Test$123",
                    SmtpHostName = "mail.bap-software.com",
                    SmtpPort = 8889,
                    SmtpUseSsl = false,
                    reCaptchaSiteKey = "6LdeCwsUAAAAACxUJpxWB9Dfk036Rf8gEEccdOeI",
                    reCaptchaSecretKey = "6LdeCwsUAAAAAP5SOPqX4_2m-BVMGfWJc43BDfgE",
                    GetBearrerTokenDuringLogin = true,
                    AuthCookieName = "appbap-base-cookiie-name",
                    AuthCookieExpirationTime = 20,
                    WebApiPublicClientId = "appbap-web-api-client",
                    BearerTokenExpirationTime = 14,
                    WebApiAllowInsecureHttp = true,
                    PublicFolderText = "/Files/BapApplication/Public/",
                    BaseFolderText = "/Files/BapApplication/",
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
            var orgUser = AddOrgUser(context, organization, adminUserId, adminUserId, adminUserName, "Victor", "Mamray", "Urlivs'ka st. 16, apt. 173.",
                                        null, "Kyiv", "Kyiv", "UA", "02095", "506831998", null);                                
            //Job runner built-in user
            var userId = AddUser(context, jobRunnerUserName, "User",
                "ujhg234jhgjkghh5hj5%Kj5hfnbv!ghgffgkhggfh^&&^f&^7f77^$^%#%$39887h");
            orgUser = AddOrgUser(context, organization, adminUserId, userId, jobRunnerUserName, "Job", "Runner", isBuiltIn: true);
            
            //Content manager user - default one
            userId = AddUser(context, contentManagerUserName, "ContentManager");
            orgUser = AddOrgUser(context, organization, adminUserId, userId, contentManagerUserName, "Content", "Manager", isBuiltIn: true);
            
            //Site content manager
            userId = AddUser(context, siteContentManagerUserName, "ContentManager");
            orgUser = AddOrgUser(context, organization, adminUserId, userId, siteContentManagerUserName, "Site Content", "Manager", isBuiltIn: true);                        

            // Blog content manager
            userId = AddUser(context, blogContentManagerUserName, "ContentManager");
            orgUser = AddOrgUser(context, organization, adminUserId, userId, blogContentManagerUserName, "Blog Content", "Manager", isBuiltIn: true);                        

            //Localizations
            AddLocalizations(context, organization.Id, adminUserId);
            
            //Organization Services
            AddOrganizationServices(context, organization.Id, adminUserId);

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
            FillLookups(context, organization.Id, adminUserId);

            // - Document Templates
            UpsertDocumentTemplate(context: context, orgId: organization.Id, name: "Customer Order Invoice", shortDescr: "Customer Order Invoice PDF Template", typeName: "financial", fileUrl: "/file/Public/DocumentTemplates/Financial/Customer Order Invoice.html", upsertUserId: adminUserId);
            UpsertDocumentTemplate(context: context, orgId: organization.Id, name: "Order Confirmation Email", shortDescr: "Order Confirmation Email Body Template", typeName: "email", fileUrl: "/file/Public/DocumentTemplates/EmailTemplates/Order Confirmation Email.html", upsertUserId: adminUserId);
            UpsertDocumentTemplate(context: context, orgId: organization.Id, name: "Customer Order Details", shortDescr: "Customer Order Details Email Body Template", typeName: "email", fileUrl: "/file/Public/DocumentTemplates/EmailTemplates/Customer Order Details.html", upsertUserId: adminUserId);

            // - Organization modules
            AddModule(context, "Content Management", organization, adminUserId, createDateTime);
            AddModule(context, "eCommerce", organization, adminUserId, createDateTime);
            AddModule(context, "Blog", organization, adminUserId, createDateTime);            

            //Content Management
            // - ContentNode
            UpsertContentNodes(context, organization.Id, adminUserId);

            //eCommerce settings ============================================================================================================================
            //Add eCommerce specific users
            AddeCommerceUsers(context, organization, adminUserId);

            //eCommerce en-US only 
            AddeCommerceLocalization(context, organization.Id, adminUserId);

            // - PaymentOption
            UpsertPaymentOptions(context, organization.Id, adminUserId);

            // - ShippingCarrier
            InsertShippingCarriers(context, organization.Id, adminUserId);

            // - Product catalog
            InsertProductsAndCategories(context, organization.Id, adminUserId);

            // - Site content
            AddeCommerceContentNodes(context, organization.Id, adminUserId);

            // - eCommerce Workflows
            AddeCommerceWorkflows(context, organization.Id, adminUserId);

            //Data fixes ====================================================================================================================================
            ExtraDataFixes(context);
        }

        /// <summary>
        /// Upserts the content nodes.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="orgId">The org identifier.</param>
        /// <param name="adminUserId">The admin user identifier.</param>
        private void UpsertContentNodes(DB context, int orgId, string adminUserId)
        {
            DateTime createDateTime = DateTime.Now;

            //Static data
            if (!context.ContentControlTypes.Any(a => a.Name == "Banner"))
            {
                var cct = new ContentControlType
                {
                    Name = "Banner",
                    IsEnabled = true,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
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
                    TenantUnitId = orgId,
                    CreateDate = createDateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 31,
                    OwnerPermissions = 1875535
                };
                context.ContentControlTypes.Add(cct);
            }

            //Content nodes
            ContentNode node = null;
            ContentNode parentNode = null;            
            //Application root page            
            node = UpsertContentNode(context, "Application", "$resources:BAP.Resources.Resources,UIText_Menu_BAP",
                        "/", null, "Home", "Index", null, "BAP.Web.Controllers",
                        null, 1, orgId, adminUserId, null, true, true, true, true, true, "{controller}/{action}/{id}");
            node.IsHome = true;
            parentNode = node;

            #region BAP system administration pages
            var adminNode = UpsertContentNode(context, "Administration", "$resources:BAP.Resources.Resources,UIText_Menu_Administration", 
                        "/admin", "Administration", "Home", "Index", "fa fa-laptop", "BAP.Web.Areas.Administration.Controllers", 
                        "Administrator,ContentManager,Supervisor", 999, orgId, adminUserId, null, true, true, true, true, true);

            node = UpsertContentNode(context, "Attachments", "$resources:BAP.Resources.Resources,UIText_Menu_Attachments",
                        "/Administration/Attachments/Index", "Administration", "Attachments", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator,ContentManager", 1, orgId, adminUserId, adminNode, true, true, true, true, true);


            node = UpsertContentNode(context, "Blogs", "$resources:BAP.Resources.Resources,UIText_Menu_Blogs",
                        "/Administration/Blogs/Index", "Administration", "Blogs", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator,ContentManager", 2, orgId, adminUserId, adminNode, true, true, true, true, true);


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


            node = UpsertContentNode(context, "ScheduledTasks", "$resources:BAP.Resources.Resources,UIText_Menu_ScheduledTasks",
                        "/Administration/ScheduledTasks/Index", "Administration", "ScheduledTasks", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator", 20, orgId, adminUserId, adminNode, true, true, true, true, true);


            node = UpsertContentNode(context, "Subscriptions", "$resources:BAP.Resources.Resources,UIText_Menu_Subscriptions",
                        "/Administration/Subscriptions/Index", "Administration", "Subscriptions", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator", 21, orgId, adminUserId, adminNode, true, true, true, true, true);


            node = UpsertContentNode(context, "OrganizationUsers", "$resources:BAP.Resources.Resources,UIText_Menu_Users",
                        "/Administration/OrganizationUsers/Index", "Administration", "OrganizationUsers", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator", 22, orgId, adminUserId, adminNode, true, true, true, true, true);


            node = UpsertContentNode(context, "WorkflowClasses", "$resources:BAP.Resources.Resources,UIText_Menu_WorkflowClasses",
                        "/Administration/WorkflowClasses/Index", "Administration", "WorkflowClasses", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator", 23, orgId, adminUserId, adminNode, true, true, true, true, true);


            node = UpsertContentNode(context, "WorkflowActions", "$resources:BAP.Resources.Resources,UIText_Menu_WorkflowActions",
                        "/Administration/WorkflowActions/Index", "Administration", "WorkflowActions", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator", 24, orgId, adminUserId, adminNode, true, true, true, true, true);


            node = UpsertContentNode(context, "WorkflowStages", "$resources:BAP.Resources.Resources,UIText_Menu_WorkflowStages",
                        "/Administration/WorkflowStages/Index", "Administration", "WorkflowStages", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator", 25, orgId, adminUserId, adminNode, true, true, true, true, true);


            node = UpsertContentNode(context, "WorkflowStageTransitions", "$resources:BAP.Resources.Resources,UIText_Menu_WorkflowStageTransitions",
                        "/Administration/WorkflowStageTransitions/Index", "Administration", "WorkflowStageTransitions", "Index", null,
                        "BAP.Web.Areas.Administration.Controllers", "Administrator", 26, orgId, adminUserId, adminNode, true, true, true, true, true);


            #endregion

            context.SaveChanges();
        }

        /// <summary>
        /// Extras the data fixes.
        /// </summary>
        /// <param name="context">The context.</param>
        private void ExtraDataFixes(DB context)
        {
            #region insert data fixes
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
            #endregion
            context.SaveChanges();
        }

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name.</param>
        /// <param name="role">The role.</param>
        /// <param name="password">The password.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="Exception">Could not create user, error: " + errorText</exception>
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

        /// <summary>
        /// Fills the lookups.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="orgId">The org identifier.</param>
        /// <param name="adminUserId">The admin user identifier.</param>
        private void FillLookups(DB context, int orgId, string adminUserId)
        {
            DateTime createDateTime = DateTime.Now;
            Lookup lookup = null;
            #region insert data
            lookup = context.Lookups.FirstOrDefault(a => a.Name == "SizeType");
            if (lookup == null)
            {
                lookup = new Lookup
                {
                    Name = "SizeType",
                    Description = "Size Type",
                    LookupType = LookupType.OptionList,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
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
            UpsertLookupValue(context, orgId, lookup, "in"/*key*/, "in"/*text*/, "Inches"/*description*/, 1, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "cm"/*key*/, "cm"/*text*/, "Cantimeters"/*description*/, 2, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "m"/*key*/, "m"/*text*/, "Metres"/*description*/, 3, adminUserId);


            lookup = context.Lookups.FirstOrDefault(a => a.Name == "WeightType");
            if (lookup == null)
            {
                lookup = new Lookup
                {
                    Name = "WeightType",
                    Description = "Weight Type",
                    LookupType = LookupType.OptionList,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
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
            UpsertLookupValue(context, orgId, lookup, "lb"/*key*/, "lb"/*text*/, "Lbs"/*description*/, 1, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "kg"/*key*/, "kg"/*text*/, "Kilograms"/*description*/, 2, adminUserId);

            lookup = context.Lookups.FirstOrDefault(a => a.Name == "ProductInternalStatus");
            if (lookup == null)
            {
                lookup = new Lookup
                {
                    Name = "ProductInternalStatus",
                    Description = "Product Internal Status",
                    LookupType = LookupType.OptionList,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
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
            UpsertLookupValue(context, orgId, lookup, "discounted"/*key*/, "Discounted"/*text*/, "Marked as discounted"/*description*/, 1, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "newmodel"/*key*/, "New Model"/*text*/, "New model of the product recently arrived"/*description*/, 2, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "trendng"/*key*/, "Trending Product"/*text*/, "Product currently trending on the market"/*description*/, 3, adminUserId);

            lookup = context.Lookups.FirstOrDefault(a => a.Name == "ProductPublicStatus");
            if (lookup == null)
            {
                lookup = new Lookup
                {
                    Name = "ProductPublicStatus",
                    Description = "Product Public Status",
                    LookupType = LookupType.OptionList,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
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
            UpsertLookupValue(context, orgId, lookup, "bestseller"/*key*/, "Bestseller"/*text*/, "Bestseller product"/*description*/, 1, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "new"/*key*/, "New"/*text*/, "New arrival"/*description*/, 2, adminUserId);


            lookup = context.Lookups.FirstOrDefault(a => a.Name == "ProductType");
            if (lookup == null)
            {
                lookup = new Lookup
                {
                    Name = "ProductType",
                    Description = "Product Type",
                    LookupType = LookupType.OptionList,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
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
            UpsertLookupValue(context, orgId, lookup, "main"/*key*/, "Main"/*text*/, "Main product type sold by the system"/*description*/, 1, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "option"/*key*/, "Option"/*text*/, "Product option"/*description*/, 2, adminUserId);

            lookup = context.Lookups.FirstOrDefault(a => a.Name == "AttachmentType");
            if (lookup == null)
            {
                lookup = new Lookup
                {
                    Name = "AttachmentType",
                    Description = "Attachment Type",
                    LookupType = LookupType.OptionList,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
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
            UpsertLookupValue(context, orgId, lookup, "photo"/*key*/, "Photo"/*text*/, "Photo"/*description*/, 1, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "picture"/*key*/, "Picture"/*text*/, "picture"/*description*/, 2, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "pdf"/*key*/, "PDF"/*text*/, "PDF"/*description*/, 3, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "json"/*key*/, "JSON"/*text*/, "JSON"/*description*/, 4, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "word"/*key*/, "Word"/*text*/, "Word"/*description*/, 5, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "excel"/*key*/, "Excel"/*text*/, "Excel"/*description*/, 6, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "text"/*key*/, "Text"/*text*/, "Text"/*description*/, 7, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "archive"/*key*/, "Archive"/*text*/, "Archive"/*description*/, 8, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "icon"/*key*/, "Icon"/*text*/, "Icon"/*description*/, 9, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "executable"/*key*/, "Executable"/*text*/, "Executable"/*description*/, 10, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "installation"/*key*/, "Installation"/*text*/, "Installation"/*description*/, 11, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "file"/*key*/, "File"/*text*/, "File"/*description*/, 99, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "video"/*key*/, "Video"/*text*/, "Video"/*description*/, 99, adminUserId);

            lookup = context.Lookups.FirstOrDefault(a => a.Name == "TemplateType");
            if (lookup == null)
            {
                lookup = new Lookup
                {
                    Name = "TemplateType",
                    Description = "Template Type",
                    LookupType = LookupType.OptionList,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
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
            UpsertLookupValue(context, orgId, lookup, "email"/*key*/, "Email"/*text*/, "Email"/*description*/, 1, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "financial"/*key*/, "Financial"/*text*/, "Financial"/*description*/, 2, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "common"/*key*/, "Common"/*text*/, "Common"/*description*/, 3, adminUserId);

            lookup = context.Lookups.FirstOrDefault(a => a.Name == "AttachmentStatus");
            if (lookup == null)
            {
                lookup = new Lookup
                {
                    Name = "AttachmentStatus",
                    Description = "Attachment Status",
                    LookupType = LookupType.OptionList,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
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
            UpsertLookupValue(context, orgId, lookup, "new"/*key*/, "New"/*text*/, "New"/*description*/, 1, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "published"/*key*/, "Published"/*text*/, "Published"/*description*/, 1, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "disabled"/*key*/, "Disabled"/*text*/, "Disabled"/*description*/, 1, adminUserId);

            lookup = context.Lookups.FirstOrDefault(a => a.Name == "CategoryCode");
            if (lookup == null)
            {
                lookup = new Lookup
                {
                    Name = "CategoryCode",
                    Description = "Category Code",
                    LookupType = LookupType.OptionList,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
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
            UpsertLookupValue(context, orgId, lookup, "sport"/*key*/, "Sport"/*text*/, "Sport"/*description*/, 1, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "life"/*key*/, "Life"/*text*/, "Life"/*description*/, 2, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "art"/*key*/, "Art"/*text*/, "Art"/*description*/, 3, adminUserId);
            UpsertLookupValue(context, orgId, lookup, "hobbies"/*key*/, "Hobbies"/*text*/, "Hobbies"/*description*/, 4, adminUserId);
            #endregion
            context.SaveChanges();
        }

        /// <summary>
        /// Updates the lookup value.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="lookup">The lookup.</param>
        private void UpdateLookupValue(DB context, Lookup lookup)
        {
            lookup.OwnerGroup = 127;
            lookup.OwnerPermissions = 302799;
        }

        /// <summary>
        /// Fills the countries.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="orgId">The org identifier.</param>
        /// <param name="adminUserId">The admin user identifier.</param>
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
        /// <summary>
        /// Fills the states.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="orgId">The org identifier.</param>
        /// <param name="adminUserId">The admin user identifier.</param>
        /// <param name="countryId">The country identifier.</param>
        private void FillStates(DB context, int orgId, string adminUserId, int countryId)
        {
            var dateTime = DateTime.Now;
            #region insert US states
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
            #endregion
            foreach (var state in states)
                if (!context.States.Any(s => s.ShortName == state.ShortName))
                    context.States.Add(state);

            context.SaveChanges();
        }

        /// <summary>
        /// Adds the organization services.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="orgId">The org identifier.</param>
        /// <param name="userId">The user identifier.</param>
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

            AddLocalization(context, "FieldLabel_Blog_BAPSoftware", "BAP Software Ltd.", null, "BAP.Resources.Resources", orgId, userId);

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

            //some french

            AddLocalization(context, "CodeText_AboutApplicationDescription", "Page de description de votre application.", "fr-CA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "CodeText_AddUser", "Ajouter un utilisateur", "fr-CA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_LoginLink", "S'identifier", "fr-CA", "BAP.Resources.Resources", orgId, userId);

            //some russian

            AddLocalization(context, "CodeText_AboutApplicationDescription", "Описание вашего приложения.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "CodeText_ContactPageDescription", "Ваша контактная информация.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "CodeText_ContactVia", "Контакт через", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "CodeText_From", "из", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_Agent", "Агент", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_Attachment", "Вложение", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_Property", "Недвижимость", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_AgentHasNoEmail", "Агент не имеет электронной почты", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_GeneralCannotSendEmail", "Что-то пошло не так, не может отправить электронную почту. Пожалуйста, обратитесь к Системному Администратору.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_InvalidLoginAttempt", "Ошибка входа. ", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_InvalidVerifiedCode", "Неправильный код.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_ManageLoginsGeneric", "Произошла ошибка.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_NewPasswordConfirmation", "Подтверждение нового пароля не совпадает с оригиналом.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_NoAgentFound", "Не найдено информации об агенте.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_NoDefaultOrganization", "Невозможно зарегистрировать пользователя - основная организация не установлена. Пожалуйста, обратитесь к Системному Администратору.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_NoEmailRequest", "Отсутствует запрос на отправку почты.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_NoMailServiceConfigured", "Сервис электронной почты не настроен.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_PasswordLength", "{0} должен быть не менее {2} символов.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_VerifyPhoneNumberFailed", "Не удалось проверить телефон", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_AddressLine1", "Адрес 1", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_AddressLine2", "Адрес 2", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_CellNumber", "Мобильный", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_City", "Город", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_Country", "Страна", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_County", "Страна", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_CreateDate", "Дата создания", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_CreatedByUserName", "Создано", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_Description", "Описание", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_Email", "Электронная почта", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_FaxNumber", "Факс", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_FirstName", "Имя", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_FullAddress", "Адрес", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_FullName", "Имя/Название", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_Id", "№", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_InsuranceId", "Номер страхования", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_LastModifiedByUserName", "Изменено", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_LastModifiedDate", "Дата изменения", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_LastName", "Фамилия", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_LicenceId", "Лицензия №", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_MiddleName", "Отчество", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_PersonalId", "Персональный номер", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_PhoneNumber", "Телефон", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_State", "Состояние", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_TaxId", "ИНН", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_Zip", "Почтовый индекс", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_AttachmentType", "Тип", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_CreateDate", "Дата создания", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_CreatedByUserName", "Создано", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_File", "Загрузить файл", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_Id", "№", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_LastModifiedByUserName", "Изменено", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_LastModifiedDate", "Дата изменения", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_Length", "Размер", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_Name", "Имя/Название", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_PathUrl", "Путь Url", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_Published", "Опубликованный", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_PublishFrom", "Опубликовать от", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_PublishTo", "Опубликовать в", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_Status", "Состояние", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_StatusDate", "Дата состояния", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_AttachmentHistory_Attachment", "Вложение", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_AttachmentHistory_CreateDate", "Дата создания", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_AttachmentHistory_CreatedByUserName", "Создано", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_AttachmentHistory_FileName", "Имя файла", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_AttachmentHistory_FilePath", "Путь к файлу", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_AttachmentHistory_Id", "№", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_CreateDate", "Дата создания", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_CreatedByUserName", "Создано", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_Description", "Описание", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_ExchangeRate", "Курс обмена", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_LastModifiedByUserName", "Дата изменения", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_LastModifiedDate", "Изменено", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_Name", "Название", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_Symbol", "Символ", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_ThreeLetterCode", "Код", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_CreateDate", "Дата создания", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_CreatedByUserName", "Создано", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_Description", "Описание", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventCode", "Код события", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventMachineName", "Название сервера", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventSource", "Источник события", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventTime", "Время события", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventType", "Тип события", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventUrl", "URL события", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventUrlReferrer", "URL ссылка", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventUserAgent", "Агент пользователя", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_Id", "№", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_IpAddress", "IP адрес", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_LastModifiedByUserName", "Изменено", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_LastModifiedDate", "Дата изменения", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_Code", "Код", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_ConfirmPassword", "Подтвердите пароль", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_CurrentPassword", "Текущий пароль", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_Email", "Электронная почта", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_Password", "Пароль", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_PhoneNumber", "Телефон", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_RememberBrowser", "Запомнить этот браузер?", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_RememberMe", "Запомнить меня?", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_CreateDate", "Дата создания", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_CreatedByUserName", "Создано", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_DateRangeFrom", "Промежуток дат с", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_DateRangeTo", "Промежуток дат по", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_Description", "Описание", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_EntityFilter", "Фильтр по сущности", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_EntityName", "Имя сущности", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_EntityNameField", "Поле названия", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_EntityOrderBy", "Выражение сортировки", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_EntityValueField", "Поле значения", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_FloatRangeFrom", "Числовой промежуток с", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_FloatRangeStep", "Шаг промежутка", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_FloatRangeTo", "Числовой промежуток по", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_Id", "№", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_IntRangeFrom", "Целочисленный промежуток с", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_IntRangeTo", "Целочисленный промежуток по", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_LastModifiedByUserName", "Изменено", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_LastModifiedDate", "Дата изменения", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_Name", "Имя", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_ParentLookup", "Родительский список", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_RangePrefix", "Префикс промежутка", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_Type", "Тип списка", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_CreateDate", "Дата создания", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_CreatedBy", "Создано", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_CreatedByUserName", "Создано", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_CultureCode", "Код языка", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_Description", "Описание", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_Id", "№", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_Key", "Поиск ключа", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_LastModifiedBy", "Изменено", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_LastModifiedByUserName", "Изменено", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_LastModifiedDate", "Дата изменения", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_Order", "Заказ", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_ParentKey", "Родительский ключ", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_Text", "Текст", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_CreateDate", "Дата создания", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_CreatedByUserName", "Создано", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_Description", "Описание", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_Id", "№", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_LastModifiedByUserName", "Изменено", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_LastModifiedDate", "Дата изменения", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_Name", "Имя/Название", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_Status", "Состояние", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_StatusDate", "Дата состояния", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_TaxId", "ИНН", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_AddedDate", "Дата добавления", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_AddressLine1", "Адрес 1", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_AddressLine2", "Адрес 2", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_AssetNo", "Имущественный номер", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_CellNumber", "Мобильный номер", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_City", "Город", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Comments", "Комментарии", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Country", "Страна", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_County", "Район", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_CreateDate", "Дата создания", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_CreatedByUserName", "Создано", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Currency", "Валюта", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Description", "Описание", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Electricity", "Электричество?", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_ElectricWaterHeating", "Электрический обогрев воды?", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Email", "Электронная почта", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_EnergySavingRate", "Рейтинг энергозбережения", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_FaxNumber", "Факс", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Garage", "Гараж?", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Gas", "Газ?", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_GasWhaterHeating", "Газовое водонагревание?", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_GlobalCentralHeating", "Центральное отопление?", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Height", "Высота", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_HotWaterSuply", "Горячее водоснабжение?", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Id", "№", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_InternalStatus", "Внутренний статус", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_InternalStatusSetByUserName", "", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_InternaStatusDate", "", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_KitchenSquare", "Площадь кухни", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_LastModifiedByUserName", "Изменено", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_LastModifiedDate", "Дата изменения", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Latitude", "Широта", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_ListPrice", "Цена", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_LivingSquare", "Жилая площадь", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_LoanNo", "Номер кредита", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_LocalCentralHeating", "Местное центральное отопление?", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Longitude", "Долгота", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_MainImageUrl", "Основное URL изображение", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_MapUrl", "URL карты", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Mark", "Оценка", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_NoOfGarages", "Гаражи", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_OriginalListPrice", "Начальная цена", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_PhoneNumber", "Телефон", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Pool", "Бассейн?", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_PriceType", "Тип цены", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_PropertyType", "Тип недвижимости", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Published", "Опубликовано?", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_PublishFrom", "Опубликовать от", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_PublishTo", "Опубликовать в", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_SectionNo", "Секция №", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_SecureParking", "Охраняемая парковка?", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_ShortDescription", "Краткое описание", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Spa", "Спа?", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_State", "Область", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Status", "Состояние", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_StatusDate", "Дата состояния", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_StoreNo", "Номер этажа", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_TotalBathrooms", "Всего ванных комнат", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_TotalBedrooms", "Всего спален", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_TotalRooms", "Количество комнат", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_TotalSquare", "Общая площадь", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_TotalStores", "Всего этажей", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_TotalUnits", "Всего строений", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_UnitNo", "Номер строения", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_UploadAttachment", "Дополнительные документы", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_UploadedAttachmentType", "Тип", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_UploadPhoto", "Загрузите фото", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_VideoUrl", "Видео URL", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_WaterSuply", "Водоснабжение?", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Website", "Веб сайт", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Zip", "Почтовый индекс", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_CreateDate", "Дата создания", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_CreatedByUserName", "Создано", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_Description", "Описание", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_Id", "№", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_LastModifiedByUserName", "Изменено", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_LastModifiedDate", "Дата изменения", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_Name", "Имя/Название", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_Published", "Опубликовано?", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_PublishFrom", "Опубликовать от", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_PublishTo", "Опубликовать в", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_CreateDate", "Дата создания", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_CreatedByUserName", "Создано", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_Feature", "Особенность", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_Id", "№", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_LastModifiedByUserName", "Изменено", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_LastModifiedDate", "Дата изменения", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_Published", "Опубликовано?", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_PublishFrom", "Опубликовать от", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_PublishTo", "Опубликовать в", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkService_CreateDate", "Дата создания", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkService_CreatedByUserName", "Создано", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkService_Id", "№", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkService_LastModifiedByUserName", "Изменено", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkService_LastModifiedDate", "Дата изменения", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkService_Name", "Имя/Название", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkService_ServiceType", "Тип обслуживания", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "StatusText_AddPhoneSuccess", "Добавлен ваш номер телефона.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "StatusText_PasswordChanged", "Ваш пароль был изменен.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "StatusText_PasswordRemoved", "Удален внешний пользователь.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "StatusText_PasswordSet", "Ваш пароль был установлен.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "StatusText_RemovePhoneSuccess", "Ваш номер телефона был удален.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "StatusText_SetTwoFactorSuccess", "Установлено проводника для двух-шаговой аутификации.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_AddToFavorites", "Добавить в избранное", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ApplicationLogo", "B.A.P.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ApplicationTitle", "B.A.P. приложение", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Attachments", "Вложения", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Back", "Назад", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_BackToList", "Назад к списку", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Bathrooms", "Ванные комнаты", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Bedrooms", "Спальни", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Cancel", "Отмена", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ChooseLookupType", "Выберите тип", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ContactAddress", "", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ContactEmail", "info@bap-software.com", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ContactPhone", "+353 1 254 8862", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ContactUsQuick", "Быстренько с нами связаться", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Create", "Создать", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_CreateNewAccount", "Быстрая регистрация пользователя у нас", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_DefaultOrder", "По умолчанию", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Details", "Подробнее", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_DropDown_SelectOption", "Выберите", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Edit", "Редактировать", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Features", "Особенности", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Garages", "Гаражи", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Hello", "Привет", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_HomePage", "Главная страница", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_LoginAccount", "Войти", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_LoginLink", "Вход", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_LogOffLink", "Выйти", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MainPhoto", "Главное фото", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ManageLink", "Управление", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Map", "Карта", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Marketing", "Маркетинг", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MarketingEmail", "marketing@bap-software.com", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_About", "О нас", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Administration", "Администрирование", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Appartment", "Апартаменты", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_AppartmentBuilding", "Многоэтажка", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Condominium", "ОСМД", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Contact", "Контакт", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_ForRent", "Оренда", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_ForSale", "На продажу", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Index", "Главная", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Office", "Офис", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Property", "Недвижимость", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_SingleHome", "Инд. дом", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Status", "Состояние", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Types", "Типы жилья", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Villa", "Усадьба", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MoreDetails", "Подробнее", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_OrderDateNew", "От новых к старым", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_OrderDateOld", "От старых к новым", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_OrderPriceHigh", "Цена от высокой к низкой", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_OrderPriceLow", "Цена от низкого до высокого", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_OrWord", "или", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Print", "Печатать", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertiesPageDescription", "Список собственности", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertiesPageTitle", "Собственность", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertyID", "Собственность №", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_QuickLinks", "Быстрые ссылки", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_RegisterLink", "Регистрировать", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_RegisterNewUser", "Регистрировать нового пользователя", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_SearchResults", "Результат поиска", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ShareThis", "Поделиться этим", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_SortBy", "Сортировать по", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_SquareMeasure", "кв. м.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Support", "Поддержка", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_SupportEmail", "support@bap-software.com", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_UseLocalAccount", "Войти с локальным пользователем.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Video", "Видео", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Featured", "Выделено", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Additional", "Дополнительные свойства", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Address", "Адрес", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_AgentName", "Имя агента", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Agents", "Агенты", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Chooselocationtype", "Выбор типа координат", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Chosen", "Выбрать", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Coordinates", "Координаты", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Extrainformation", "Дополнительные сведения", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Identity", "Идентификация", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Location", "На карте", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Media", "Фото и видео", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Photo", "Фото", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Primary", "Основная", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Save", "Сохранить", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Specification", "Спецификация", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_OrganizationUser", "Пользователи", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_UploadedAttachmentName", "Имя", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_add", "Добавить", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Attachment", "Вложение", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Filesmustbe", "Файлы должны быть", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Image", "Изображение", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Images", "Изображения", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Main", "Основной", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Maxsize10mb", "Максимальный размер 10 Мб", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Maxsize2mb", "Максимальный размер 2 Мб", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertyImage", "Изображение недвижимости", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertySpecificationDescription", "Описание", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertySpecificationName", "Свойства", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_UploadedPhotoName", "Название", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_CodeFromVideoHosting", "Код только из Youtube или Vimeo", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_PutDescriptionHere", "Добавьте полное описание...", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_AgentsAndCompanies", "АГЕНТЫ И КОМПАНИИ ПРИСОЕДИНЯЙТЕСЬ!", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_FindAProperty", "Поиск недвижимости", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_GettingStarted", "Старт", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Keyword", "Ключевые слова", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ManageYourProperties", "УПРАВЛЯЙ СВОЕЙ НЕДВИЖИМОСТЬЮ", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MaxArea", "Площадь до", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MaxPrice", "Цена до", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MinArea", "Площадь от", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MinBaths", "Ванных от", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MinBeds", "Комнат от", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MinPrice", "Цена от", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertyStatus", "Статус", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertyType", "Тип", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_SearchLocation", "Адрес", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_TakeATour", "Ознакомление", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_FeaturedProperties", "Выделенные объекты", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Search", "Искать", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ViewFeaturedList", "Просмотреть список имеющейся недвижимости.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Keyword", "Введите слова", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_MaxArea", "м. кв.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_MinArea", "м. кв.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_SearchLocation", "Введите адрес", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Ok", "Готово", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "CodeText_ResetPasswordEmail", "Пожалуйста, сбросьте пароль перейдя по ссылке &lt;a href=\"{0}\"&gt;сюда&lt;/a&gt;", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ResetPassword", "Сброс Пароля", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ResetPasswordConfirmation", "Письмо сброса пароля было отправлено по этому адресу {0}, спасибо!", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ResetPasswordNotice", "Эта форма отправит письмо для сброса пароля следующему пользователю:", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Address1", "Введите адрес", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Address2", "Дополнительный адрес", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_City", "Город", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_County", "Район", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_ESR", "Индекс", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Garages", "Количество", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_KitchenSquare", "м. кв.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Latitude", "Широта", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_LivingSquare", "м. кв.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Longitude", "Долгота", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_MapURL", "Ссылка с Google карт", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_PropertyDescription", "Описание", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_PropertyName", "Название", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_State", "Область", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_TotalBathrooms", "Количество", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_TotalBedrooms", "Количество", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_TotalRooms", "Количество", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_TotalSquare", "м. кв.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_TotalUnits", "Количество", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Zip", "Почтовый индекс", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_NoAgentsAreAvailable", "Не найдено доступных агентов недвижимости.", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_NoAttachmentsLoadedYet", "Еще не загружено приложений", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_NoImagesLoadedYet", "Еще не загружено изображений", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_AssetNo", "Номер", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Comments", "Добавьте заметки...", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_ListPrice", "Цена", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_LoanNo", "Номер", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Name", "Имя", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_OriginalListPrice", "Цена", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_ShortDescription", "Добавьте короткое описание...", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_VideoHTMLCode", "Видео HTML-код", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Paging", "Страниц", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Navigation", "Разделы", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_AccessFailedCount", "Кол-во ошибок входа", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_AddressLine1", "Адрес", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_AddressLine2", "Доп. адрес", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_CellNumber", "Мобильный телефон", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_City", "Город", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_Country", "Страна", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_County", "Район", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_Email", "Эл. адрес", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_EmailConfirmed", "Эл. адрес подтвержден", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_FullName", "Имя", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_LastModifiedByUserName", "Последнее изменение", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_LastModifiedDate", "Изменено", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_LockoutEnabled", "Блокировка", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_LockoutEndDateUtc", "Блокировка до", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_PhoneNumber", "Домашний телефон", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_Roles", "Роли", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_State", "Область", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_TwoFactorEnabled", "2-х фазный вход", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_UserName", "Пользователь", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_Zip", "Индекс", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Actions", "Действие", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Agents", "Агенты", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Currencies", "Валюти", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_EmailNotifications", "Оповещения", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_EventLog", "Журнал событий", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Lookups", "Словари", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Organizations", "Организации", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Services", "Сервисы", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_SocialNetworks", "Социальные сети", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Subscriptions", "Подписки", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Users", "Пользователи", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Workflows", "Бизнес процессы", "ru-RU", "BAP.Resources.Resources", orgId, userId);

            //some ukrainian

            AddLocalization(context, "CodeText_AboutApplicationDescription", "Опис вашого додатку.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "CodeText_ContactPageDescription", "Ваша контактна інформація.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "CodeText_ContactVia", "Зв’язатися через", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "CodeText_From", "від", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_Agent", "Агент", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_Attachment", "Додаток", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_Property", "Нерухомість", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_AgentHasNoEmail", "Агент не має електронної пошти", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_GeneralCannotSendEmail", "Щось пішло не так, не може відправити электронну пошту. Будь ласка, зверніться до Системного Адміністратора.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_InvalidLoginAttempt", "Помилка входу.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_InvalidVerifiedCode", "Неправильний код.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_ManageLoginsGeneric", "Сталася помилка.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_NewPasswordConfirmation", "Підтвердження нового паролю не співпадає з оригіналом.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_NoAgentFound", "Не знайдено інформації про агента.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_NoDefaultOrganization", "Не можу зареєструвати користувача - основна організація не встановлена. Будь ласка, зверніться до Системного Адміністратора.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_NoEmailRequest", "Нема запиту на відсилання пошти.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_NoMailServiceConfigured", "Сервіс електронної пошти не налаштовано.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_PasswordLength", "{0} має бути принаймні {2} символів.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "ErrorText_VerifyPhoneNumberFailed", "Не вдалося перевірити телефон", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_AddressLine1", "Адреса 1", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_AddressLine2", "Адреса 2", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_CellNumber", "Мобільний", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_City", "Місто", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_Country", "Країна", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_County", "Країна", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_CreateDate", "Дата створення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_CreatedByUserName", "Створено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_Description", "Опис", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_Email", "Електронна пошта", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_FaxNumber", "Факс", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_FirstName", "Ім\"я", "uk - UA", "BAP.Resources.Resources", orgId, userId);
            

            AddLocalization(context, "FieldLabel_Agent_FullAddress", "Адреса", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_FullName", "Ім\"я / Назва", "uk - UA", "BAP.Resources.Resources", orgId, userId);
            

            AddLocalization(context, "FieldLabel_Agent_Id", "№", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_InsuranceId", "Номер страхування", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_LastModifiedByUserName", "Змінено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_LastModifiedDate", "Дата змінення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_LastName", "Прізвище", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_LicenceId", "Ліцензія №", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_MiddleName", "По батькові", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_PersonalId", "Персональний код", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_PhoneNumber", "Телефон", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_State", "Стан", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_TaxId", "ІПН", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Agent_Zip", "Поштовий індекс", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_AttachmentType", "Тип", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_CreateDate", "Дата створення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_CreatedByUserName", "Створено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_File", "Завантажити файл", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_Id", "№", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_LastModifiedByUserName", "Змінено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_LastModifiedDate", "Дата змінення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_Length", "Розмір", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_Name", "Ім\"я / Назва", "uk-UA", "BAP.Resources.Resources", orgId, userId);
            

            AddLocalization(context, "FieldLabel_Attachment_PathUrl", "Шлях Url", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_Published", "Опублікований", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_PublishFrom", "Опублікувати від", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_PublishTo", "Опублікувати в", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_Status", "Стан", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachment_StatusDate", "Дата стану", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_AttachmentHistory_Attachment", "Додаток", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_AttachmentHistory_CreateDate", "Дата створення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_AttachmentHistory_CreatedByUserName", "Створено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_AttachmentHistory_FileName", "Ім\"я файла", "uk-UA", "BAP.Resources.Resources", orgId, userId);
            

            AddLocalization(context, "FieldLabel_AttachmentHistory_FilePath", "Шлях до файлу", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_AttachmentHistory_Id", "№", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_CreateDate", "Дата створення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_CreatedByUserName", "Створено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_Description", "Опис", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_ExchangeRate", "Курс обміну", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_LastModifiedByUserName", "Дата змінення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_LastModifiedDate", "Змінено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_Name", "Назва", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_Symbol", "Символ", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Currency_ThreeLetterCode", "Код", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_CreateDate", "Дата створення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_CreatedByUserName", "Створено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_Description", "Опис", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventCode", "Код події", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventMachineName", "Назва сервера", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventSource", "Джерело події", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventTime", "Час події", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventType", "Тип події", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventUrl", "URL події", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventUrlReferrer", "URL посилання", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_EventUserAgent", "Агент користувача", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_Id", "№", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_IpAddress", "IP адреса", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_LastModifiedByUserName", "Змінено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_EventLog_LastModifiedDate", "Дата змінення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_Code", "Код", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_ConfirmPassword", "Підтвердіть пароль", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_CurrentPassword", "Поточний пароль", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_Email", "Електронна пошта", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_Password", "Пароль", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_PhoneNumber", "Телефон", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_RememberBrowser", "Запамятати цей браузер?", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Login_RememberMe", "Пам\"ятати мене ? ", "uk-UA", "BAP.Resources.Resources", orgId, userId);
            

            AddLocalization(context, "FieldLabel_Lookup_CreateDate", "Дата створення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_CreatedByUserName", "Створено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_DateRangeFrom", "Проміжок дат з", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_DateRangeTo", "Проміжок дат по", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_Description", "Опис", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_EntityFilter", "Фільтр за сутністю", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_EntityName", "Назва сутності", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_EntityNameField", "Поле назви", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_EntityOrderBy", "Вираз сортування", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_EntityValueField", "Поле значення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_FloatRangeFrom", "Числовий проміжок з", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_FloatRangeStep", "Крок проміжку", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_FloatRangeTo", "Числовий проміжок по", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_Id", "№", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_IntRangeFrom", "Цілочисловий проміжок з", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_IntRangeTo", "Цілочисловий проміжок по", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_LastModifiedByUserName", "Змінено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_LastModifiedDate", "Дата змінення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_Name", "Назва", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_ParentLookup", "Материнський список", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_RangePrefix", "Префікс проміжку", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Lookup_Type", "Тип списку", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_CreateDate", "Дата створення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_CreatedBy", "Створено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_CreatedByUserName", "Створено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_CultureCode", "Код мови", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_Description", "Опис", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_Id", "№", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_Key", "Пошук ключа", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_LastModifiedBy", "Змінено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_LastModifiedByUserName", "Змінено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_LastModifiedDate", "Дата змінення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_Order", "Замовлення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_ParentKey", "Материнський ключ", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_LookupValue_Text", "Текст", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_CreateDate", "Дата створення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_CreatedByUserName", "Створено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_Description", "Опис", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_Id", "№", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_LastModifiedByUserName", "Змінено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_LastModifiedDate", "Дата змінення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_Name", "Ім\"я / Назва", "uk-UA", "BAP.Resources.Resources", orgId, userId);
            

            AddLocalization(context, "FieldLabel_Organization_Status", "Стан", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_StatusDate", "Дата стану", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Organization_TaxId", "ІПН", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_AddedDate", "Дата додавання", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_AddressLine1", "Адреса 1", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_AddressLine2", "Адреса 2", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_AssetNo", "Майновий номер", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_CellNumber", "Мобільний номер", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_City", "Місто", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Comments", "Коментарі", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Country", "Країна", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_County", "Район", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_CreateDate", "Дата створення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_CreatedByUserName", "Створено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Currency", "Валюта", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Description", "Опис", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Electricity", "Електрика?", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_ElectricWaterHeating", "Електричний обігрів води?", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Email", "Електронна пошта", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_EnergySavingRate", "Рейтинг енергозбереження", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_FaxNumber", "Факс", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Garage", "Гараж?", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Gas", "Газ?", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_GasWhaterHeating", "Газове водонагрівання?", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_GlobalCentralHeating", "Центральне опалення?", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Height", "Висота", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_HotWaterSuply", "Гаряче водопостачання?", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Id", "№", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_InternalStatus", "Внутрішній статус", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_InternalStatusSetByUserName", "Статус встановлено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_InternaStatusDate", "Дата статусу", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_KitchenSquare", "Площа кухні", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_LastModifiedByUserName", "Змінено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_LastModifiedDate", "Дата змінення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Latitude", "Широта", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_ListPrice", "Ціна", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_LivingSquare", "Житлова площа", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_LoanNo", "Номер позики", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_LocalCentralHeating", "Місцеве центральне опалення?", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Longitude", "Довгота", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_MainImageUrl", "Основне URL зображення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_MapUrl", "URL мапи", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Mark", "Оцінка", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_NoOfGarages", "Гаражі", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_OriginalListPrice", "Початкова ціна", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_PhoneNumber", "Телефон", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Pool", "Басейн?", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_PriceType", "Тип ціни", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_PropertyType", "Тип нерухомості", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Published", "Опубліковано?", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_PublishFrom", "Опублікувати від", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_PublishTo", "Опублікувати в", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_SectionNo", "Секція №", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_SecureParking", "Парковка під охороною?", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_ShortDescription", "Короткий опис", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Spa", "Спа?", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_State", "Область", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Status", "Стан", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_StatusDate", "Дата стану", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_StoreNo", "Номер поверху", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_TotalBathrooms", "Всього ванних кімнат", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_TotalBedrooms", "Всього спалень", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_TotalRooms", "Кількість кімнат", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_TotalSquare", "Загальна площа", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_TotalStores", "Всього поверхів", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_TotalUnits", "Всього будов", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_UnitNo", "Номер будови", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_UploadAttachment", "Завантажте додаткові документи", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_UploadedAttachmentType", "Тип", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_UploadPhoto", "Завантажте фото", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_VideoUrl", "Відео URL", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_WaterSuply", "Водопостачання?", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Website", "Веб сайт", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Zip", "Поштовий індекс", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_CreateDate", "Дата створення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_CreatedByUserName", "Створено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_Description", "Опис", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_Id", "№", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_LastModifiedByUserName", "Змінено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_LastModifiedDate", "Дата змінення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_Name", "Ім\"я / Назва", "uk-UA", "BAP.Resources.Resources", orgId, userId);
            

            AddLocalization(context, "FieldLabel_PropertyDetail_Published", "Опубліковано?", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_PublishFrom", "Опублікувати від", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyDetail_PublishTo", "Опублікувати в", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_CreateDate", "Дата створення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_CreatedByUserName", "Створено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_Feature", "Особливість", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_Id", "№", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_LastModifiedByUserName", "Змінено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_LastModifiedDate", "Дата змінення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_Published", "Опубліковано?", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_PublishFrom", "Опублікувати від", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_PropertyFeature_PublishTo", "Опублікувати в", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkService_CreateDate", "Дата створення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkService_CreatedByUserName", "Створено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkService_Id", "№", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkService_LastModifiedByUserName", "Змінено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkService_LastModifiedDate", "Дата змінення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_WorkService_Name", "Ім\"я / Назва", "uk-UA", "BAP.Resources.Resources", orgId, userId);
            

            AddLocalization(context, "FieldLabel_WorkService_ServiceType", "Тип обслуговування", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "StatusText_AddPhoneSuccess", "Додано ваш номер телефону.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "StatusText_PasswordChanged", "Ваш пароль було змінено.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "StatusText_PasswordRemoved", "Видалено зовнішнього кориуставача.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "StatusText_PasswordSet", "Ваш пароль було встановлено.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "StatusText_RemovePhoneSuccess", "Номер вашого телефону було видалено.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "StatusText_SetTwoFactorSuccess", "Встановлено провідника для дво-крокової аутификації.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_AddToFavorites", "Додати в обране", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ApplicationLogo", "B.A.P.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ApplicationTitle", "B.A.P. додаток", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Attachments", "Прикріплення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Back", "Назад", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_BackToList", "Назад до Списку", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Bathrooms", "Ванні кімнати", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Bedrooms", "Спальні", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Cancel", "Скасувати", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ChooseLookupType", "Виберіть тип", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ContactAddress", "", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ContactEmail", "info@bap-software.com", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ContactPhone", "+353 1 254 8862", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ContactUsQuick", "Швиденько з нами зв\"язатися", "uk-UA", "BAP.Resources.Resources", orgId, userId);
            

            AddLocalization(context, "UIText_Create", "Створити", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_CreateNewAccount", "Швидка реєстрація користувача в нас", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_DefaultOrder", "Типово", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Details", "Детальніше", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_DropDown_SelectOption", "Виберіть", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Edit", "Редагувати", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Features", "Особливості", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Garages", "Гаражі", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Hello", "Привіт", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_HomePage", "Головна сторінка", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_LoginAccount", "Увійти", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_LoginLink", "Вхід", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_LogOffLink", "Вийти", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MainPhoto", "Головне фото", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ManageLink", "Керування", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Map", "Карта", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Marketing", "Маркетинг", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MarketingEmail", "marketing@bap-software.com", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_About", "Про нас", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Administration", "Адміністрування", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Appartment", "Апартаменти", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_AppartmentBuilding", "Багатоповерхівка", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Condominium", "ОСББ", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Contact", "Контакт", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_ForRent", "Оренда", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_ForSale", "На продаж", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Index", "Головна", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Office", "Офіс", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Property", "Нерухомість", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_SingleHome", "Інд. будинок", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Status", "Стан", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Types", "Типи житла", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Villa", "Садиба", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MoreDetails", "Детальніше", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_OrderDateNew", "Від нових до старих", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_OrderDateOld", "Від старих до нових", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_OrderPriceHigh", "Ціна від високої до низької", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_OrderPriceLow", "Ціна від низького до високого", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_OrWord", "або", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Print", "Друк", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertiesPageDescription", "Список власності", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertiesPageTitle", "Власність", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertyID", "Власність №", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_QuickLinks", "Швидкі посилання", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_RegisterLink", "Реєструвати", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_RegisterNewUser", "Реєструвати нового користувача", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_SearchResults", "Результат пошуку", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ShareThis", "Поділитися цим", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_SortBy", "Сортувати за", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_SquareMeasure", "кв. м.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Support", "Підтримка", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_SupportEmail", "support@bap-software", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_UseLocalAccount", "Увійти з локальним користувачем.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Video", "Відео", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_Featured", "Виділена", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Additional", "Додаткові властивості", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Address", "Адреса", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_AgentName", "Ім'я агента", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Agents", "Агенти", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Chooselocationtype", "Вибір типу координат", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Chosen", "Обрати", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Coordinates", "Координати", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Extrainformation", "Додаткові відомості", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Identity", "Ідентифікація", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Location", "На мапі", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Media", "Фото та відео", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Photo", "Фото", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Primary", "Основна", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Save", "Зберегти", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Specification", "Специфікація", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "EntityLabel_OrganizationUser", "Користувачі", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_UploadedAttachmentName", "Ім'я", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_add", "Додати", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Attachment", "Прикріплення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Filesmustbe", "Файли повинні бути", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Image", "Зображення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Images", "Зображення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Main", "Основний", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Maxsize10mb", "Максимальний розмір 10 Мб", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Maxsize2mb", "Максимальний розмір 2 Мб", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertyImage", "Зображення нерухомості", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertySpecificationDescription", "Опис", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertySpecificationName", "Властивість", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_Property_UploadedPhotoName", "Назва", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_CodeFromVideoHosting", "Код тільки з Youtube або Vimeo", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_PutDescriptionHere", "Додайте розширений опис...", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_AgentsAndCompanies", "АГЕНТИ ТА КОМПАНІЇ ПРИЄДНУЙТЕСЬ!", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_FindAProperty", "Пошук нерухомості", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_GettingStarted", "Почати", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Keyword", "Ключові слова", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ManageYourProperties", "КЕРУЙ СВОЄЮ НЕРУХОМІСТЮ", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MaxArea", "Площа до", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MaxPrice", "Ціна до", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MinArea", "Площа від", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MinBaths", "Ванних від", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MinBeds", "Кімнат від", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_MinPrice", "Ціна від", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertyStatus", "Стан", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_PropertyType", "Тип", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_SearchLocation", "Адреса", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_TakeATour", "Ознайомитися", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_FeaturedProperties", "Виділені об'єкти", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Search", "Шукати", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ViewFeaturedList", "Переглянути список наявної нерухомості.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Keyword", "Введіть слова", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_MaxArea", "м. кв.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_MinArea", "м. кв.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_SearchLocation", "Введіть адресу", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Ok", "Гаразд", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "CodeText_ResetPasswordEmail", "Будь ласка, скиньте пароль перейшовши за посиланням &lt;a href=\"{0}\"&gt;сюди&lt;/a&gt;", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ResetPassword", "Скидання Пароля", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ResetPasswordConfirmation", "Ми відправили листа для скидання пароля за цією адресою {0}, дякуємо!", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_ResetPasswordNotice", "Ця форма віправляє листа для перевстановлення пароля цьому користувачу:", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Address1", "Введіть адресу", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Address2", "Додаткова адреса", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_City", "Місто", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_County", "Район", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_ESR", "Індекс", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Garages", "Кількість", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_KitchenSquare", "м. кв.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Latitude", "Широта", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_LivingSquare", "м. кв.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Longitude", "Довгота", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_MapURL", "Посилання з Google мап", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_PropertyDescription", "Опис", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_PropertyName", "Назва", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_State", "Область", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_TotalBathrooms", "Кількість", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_TotalBedrooms", "Кількість", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_TotalRooms", "Кількість", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_TotalSquare", "м. кв.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_TotalUnits", "Кількість", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Zip", "Почтовий індекс", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_NoAgentsAreAvailable", "Не знайдено доступних агентів нерухомості.", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_NoAttachmentsLoadedYet", "Ще не завантажано додатків", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_NoImagesLoadedYet", "Ще не завантажано зображень", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_AssetNo", "Номер", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Comments", "Додайте нотатки...", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_ListPrice", "Ціна", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_LoanNo", "Номер", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_Name", "Ім'я", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_OriginalListPrice", "Ціна", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_ShortDescription", "Додайте короткий опис...", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIWatermark_VideoHTMLCode", "Відео HTML-код", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Paging", "Сторінок", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Navigation", "Розділи", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_AccessFailedCount", "Кіл-ть помилок входу", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_AddressLine1", "Адреса ", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_AddressLine2", "Дод. адреса", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_CellNumber", "Мобільний телефон", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_City", "Місто", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_Country", "Країна", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_County", "Район", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_Email", "Ел. адреса", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_EmailConfirmed", "Эл. адреса підтверджена", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_FullName", "Ім'я", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_LastModifiedByUserName", "Остання зміна", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_LastModifiedDate", "Змінено", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_LockoutEnabled", "Блокування", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_LockoutEndDateUtc", "Блокування до", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_PhoneNumber", "Домашній телефон", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_Roles", "Ролі", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_State", "Область", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_TwoFactorEnabled", "2х-фазний вхід", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_UserName", "Користувач", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "FieldLabel_OrganizationUser_Zip", "Індекс", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Actions", "Дія", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Agents", "Агенти", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Currencies", "Валюти", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_EmailNotifications", "Оповіщення", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_EventLog", "Журнал подій", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Lookups", "Словники", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Organizations", "Організації", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Services", "Сервіси", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_SocialNetworks", "Соціальні мережі", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Subscriptions", "Підписки", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Users", "Користувачі", "uk-UA", "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Workflows", "Бізнес процеси", "uk-UA", "BAP.Resources.Resources", orgId, userId);
            
            #endregion

            context.SaveChanges();
        }                       
    }
}
