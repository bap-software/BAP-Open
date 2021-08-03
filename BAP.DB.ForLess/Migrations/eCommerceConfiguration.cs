namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Linq;
    
    using DAL.Entities;
    using BAP.eCommerce.DAL.Entities;
    using BAP.eCommerce.WorkflowActions;
    using BAP.DAL;
    using BAP.eCommerce.DAL;
    using System.Collections.Generic;
    using BAP.Common;

    internal sealed partial class Configuration : eCommDbMigrationConfig<DB>
    {

        private void AddeCommerceUsers(DB context, Organization organization, string adminUserId)
        {
            var eCommerceContentManagerUserName = "ecmng@app.bap-software.com";
            var supervisorUserName = "sprvsr@app.bap-software.com";

            // eCommerce content manager
            var userId = AddUser(context, eCommerceContentManagerUserName, "ContentManager");
            AddOrgUser(context, organization, adminUserId, userId, eCommerceContentManagerUserName, "eCommerce Content", "Manager", isBuiltIn: true);

            // Supervisor
            userId = AddUser(context, supervisorUserName, "Supervisor");
            AddOrgUser(context, organization, adminUserId, userId, eCommerceContentManagerUserName, "Supervisor", "Supervisor", isBuiltIn: true);

            context.SaveChanges();
        }

        private void UpsertPaymentOptions(DB context, int orgId, string adminUserId)
        {
            DateTime createDateTime = DateTime.Now;
            #region insert data
            PaymentOption pOption = null;
            if (context.PaymentOptions.Any(a => a.Name == "_Test No Payment"))
            {
                context.PaymentOptions.Remove(context.PaymentOptions.FirstOrDefault(a => a.Name == "_Test No Payment"));
            }

            if (!context.PaymentOptions.Any(a => a.Name == "Pay on Delivery"))
            {
                pOption = new PaymentOption
                {
                    Name = "Pay on Delivery",
                    ShortDescription = "No payment this time",
                    Description = "No payment is taken this time, paid on delivery to the courrier",
                    Enabled = true,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = createDateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = adminUserId
                };
                context.PaymentOptions.Add(pOption);
            }

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
                    TenantUnitId = orgId,
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
                    TenantUnitId = orgId,
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
            #endregion
            context.SaveChanges();
        }

        private void InsertShippingCarriers(DB context, int orgId, string adminUserId)
        {
            DateTime createDateTime = DateTime.Now;
            #region insert data
            if (!context.ShippingCarriers.Any(a => a.Name == "USPS"))
            {
                var carrier = new ShippingCarrier
                {
                    Name = "USPS",
                    ShortDescription = "USPS",
                    Description = "USPS Carrier",
                    Enabled = true,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    ShippingProviderAssembly = "BAP.eCommerce.USPSShippingProvider",
                    ShippingProviderClass = "BAP.eCommerce.USPSShippingProvider.UspsProvider",
                    TeaserImage = "fa fa-truck",
                    OptionCode = "USPS",
                    CreateDate = createDateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = adminUserId
                };
                context.ShippingCarriers.Add(carrier);
                context.SaveChanges();

                var shippingOption = new ShippingOption
                {
                    Name = "By Air",
                    ShortDescription = "Shipment by Air",
                    Description = "Delivery Next Day!",
                    Enabled = true,
                    ShippingCarrierId = carrier.Id,
                    TeaserImage = "fa fa-plane",
                    OptionCode = "USPS_AIR",
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = createDateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = adminUserId,
                    AllowedPaymentOptions = null
                };
                context.ShippingOptions.Add(shippingOption);

                shippingOption = new ShippingOption
                {
                    Name = "By Ship",
                    ShortDescription = "Shipment via Sea",
                    Description = "Pick Up In-Store",
                    Enabled = true,
                    ShippingCarrierId = carrier.Id,
                    TeaserImage = "fa fa-ship",
                    OptionCode = "USPS_SHIP",
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = createDateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = adminUserId
                };
                context.ShippingOptions.Add(shippingOption);                
            }
            #endregion
            context.SaveChanges();
        }        

        private void InsertProductsAndCategories(DB context, int orgId, string adminUserId)
        {
            // - Manufacturer	
            var appleMan = AddManufacturer(context, "Apple", "Apple Inc", orgId, adminUserId, "/file/Public/Manufacturers/brand-apple.png");
            var asusdMan = AddManufacturer(context, "ASUS", "Asus Inc", orgId, adminUserId, "/file/Public/Manufacturers/brand-asus.png");
            var samsungMan = AddManufacturer(context, "Samsung", "Samsung Inc", orgId, adminUserId, "/file/Public/Manufacturers/brand-samsung.png");
            var htcMan = AddManufacturer(context, "HTC", "Htc Inc", orgId, adminUserId, "/file/Public/Manufacturers/brand-htc.png");
            var hpMan = AddManufacturer(context, "HP", "HP Inc", orgId, adminUserId, "/file/Public/Manufacturers/brand-hp.png");
            var msMan = AddManufacturer(context, "Microsoft", "Microsoft Inc", orgId, adminUserId, "/file/Public/Manufacturers/brand-microsoft.png");
            var nokiaMan = AddManufacturer(context, "Nokia", "Nokia Inc", orgId, adminUserId, "/file/Public/Manufacturers/brand-nokia.png");
            var sonyMan = AddManufacturer(context, "Sony", "Sony Inc", orgId, adminUserId, "/file/Public/Manufacturers/brand-sony.png");

            // - Product Categories
            var allCompsCat = UpsertProductcategory(context, orgId, "Laptop & Computer", "Laptops and Computers", "<p>Laptops, Desktops, Servers and other similar devices</p>", 1, adminUserId);
            context.SaveChanges();
            var laptopsCat = UpsertProductcategory(context, orgId, "Laptops", "Laptops", "Personal & business laptops", 1, adminUserId, allCompsCat.Id);
            context.SaveChanges();
            var homeLaptopsCat = UpsertProductcategory(context, orgId, "Home laptops", "Home laptops", "Laptops for general purpose home usage.", 1, adminUserId, laptopsCat.Id);
            context.SaveChanges();
            var gameLaptops = UpsertProductcategory(context, orgId, "Gaming laptops", "Gaming laptops", "Gaming laptops", 2, adminUserId, laptopsCat.Id);
            context.SaveChanges();
            var desktopsCat = UpsertProductcategory(context, orgId, "Desktops", "Desktops for home and business", "Veriaty of different desktops for all type of usages: home, small & medium business, enterprise and so on.", 2, adminUserId, allCompsCat.Id);
            context.SaveChanges();
            var serversCat = UpsertProductcategory(context, orgId, "Servers", "Servers for home and business", "Veriaty of different servers for all type of business: small, medium and enterprise", 3, adminUserId, allCompsCat.Id);
            context.SaveChanges();

            var mobilesCat = UpsertProductcategory(context, orgId, "Mobile Phones", "Mobile Phones", null, 2, adminUserId);
            context.SaveChanges();
            var tablesCat = UpsertProductcategory(context, orgId, "Tablets", "Tablets", null, 3, adminUserId);
            context.SaveChanges();
            var tvCat = UpsertProductcategory(context, orgId, "TV", "TV", null, 4, adminUserId);
            context.SaveChanges();
            var speakersCat = UpsertProductcategory(context, orgId, "Speakers", "Speakers", null, 5, adminUserId);
            context.SaveChanges();
            var gadgetsCat = UpsertProductcategory(context, orgId, "Gadgets", "Gadgets", null, 6, adminUserId);
            context.SaveChanges();
            var assesoriesCat = UpsertProductcategory(context, orgId, "Assesories", "Assesories", null, 7, adminUserId);
            context.SaveChanges();

            // - Products
            //UpsertProduct(context, orgId, ""/*SKU*/, ""/*Name*/, ""/*shortDescr*/, ""/*Descr*/, ""/*userId*/, 0/*parCatId*/, 0/*manufacturerId*/, ""/*imageUrl*/, 0/*price*/, 0/*listPrice*/);

            UpsertProduct(context, orgId, "APPLE-TV"/*SKU*/, "Apple TV"/*Name*/, "Apple TV"/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, tvCat.Id/*parCatId*/, appleMan.Id/*manufacturerId*/, "/file/Public/Products/1.png"/*imageUrl*/, 299.99/*price*/, 199.99/*listPrice*/, intStatus: "trending");
            UpsertProduct(context, orgId, "IPHONE-SE"/*SKU*/, "IPhone SE"/*Name*/, "<p>A big step for small.<br />A beloved design.Now with more to love.</p>"/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, mobilesCat.Id/*parCatId*/, appleMan.Id/*manufacturerId*/, "/file/Public/Products/product-iphone-se.png"/*imageUrl*/, 199.99/*price*/, 0/*listPrice*/);
            UpsertProduct(context, orgId, "APPLE-WTCH-STEEL"/*SKU*/, "Apple Watch SS"/*Name*/, "Apple Watch Stainless steel cases"/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, gadgetsCat.Id/*parCatId*/, appleMan.Id/*manufacturerId*/, "/file/Public/Products/product-apple-watch.png"/*imageUrl*/, 599/*price*/, 399.99/*listPrice*/, intStatus: "trending");
            UpsertProduct(context, orgId, "APPLE-WTCH"/*SKU*/, "Apple Watch"/*Name*/, "You. At a glance."/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, gadgetsCat.Id/*parCatId*/, appleMan.Id/*manufacturerId*/, "/file/Public/Products/product-apple-watch-sm.png"/*imageUrl*/, 199/*price*/, 0/*listPrice*/, true);
            UpsertProduct(context, orgId, "APPLE-ASSES"/*SKU*/, "Apple Accessories"/*Name*/, "It’s mini in a massive way."/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, gadgetsCat.Id/*parCatId*/, appleMan.Id/*manufacturerId*/, "/file/Public/Products/5.png"/*imageUrl*/, 99.99/*price*/, 0/*listPrice*/, true);
            UpsertProduct(context, orgId, "MAC-MINI"/*SKU*/, "Mac Mini"/*Name*/, "Redesigned. Rechargeable. Remarkable."/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, desktopsCat.Id/*parCatId*/, appleMan.Id/*manufacturerId*/, "/file/Public/Products/6.png"/*imageUrl*/, 199/*price*/, 0/*listPrice*/, true);
            UpsertProduct(context, orgId, "MAC-PRO"/*SKU*/, "Mac Pro"/*Name*/, "Built for creativity on an epic scale."/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, desktopsCat.Id/*parCatId*/, appleMan.Id/*manufacturerId*/, "/file/Public/Products/product-mac-pro.png"/*imageUrl*/, 1299/*price*/, 0/*listPrice*/, true);
            UpsertProduct(context, orgId, "IPHONE-6S-PLUS"/*SKU*/, "iPhone 6s Plus 16GB"/*Name*/, "iPhone 6s Plus 16GB"/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, mobilesCat.Id/*parCatId*/, appleMan.Id/*manufacturerId*/, "/file/Public/Products/product-iphone.png"/*imageUrl*/, 739/*price*/, 639/*listPrice*/, intStatus: "trending");
            UpsertProduct(context, orgId, "IPAD-PRO"/*SKU*/, "iPad Pro 32GB"/*Name*/, "9.7-inch iPad Pro 32GB"/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, tablesCat.Id/*parCatId*/, appleMan.Id/*manufacturerId*/, "/file/Public/Products/product-ipad-pro.png"/*imageUrl*/, 799/*price*/, 599/*listPrice*/, intStatus: "trending");
            UpsertProduct(context, orgId, "IMAC-RETINA"/*SKU*/, "iMac Retina Display"/*Name*/, "21.5-inch iMac with Retina Display"/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, desktopsCat.Id/*parCatId*/, appleMan.Id/*manufacturerId*/, "/file/Public/Products/product-imac.png"/*imageUrl*/, 1299/*price*/, 1099/*listPrice*/, intStatus: "trending");
            UpsertProduct(context, orgId, "MAC-BOOK-PRO"/*SKU*/, "MacBook Pro"/*Name*/, "MacBook Pro with Retina Display"/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, laptopsCat.Id/*parCatId*/, appleMan.Id/*manufacturerId*/, "/file/Public/Products/product-macbook-pro.png"/*imageUrl*/, 1499/*price*/, 1299/*listPrice*/, intStatus: "trending");
            UpsertProduct(context, orgId, "SAMSUNG-GALAXY-S7"/*SKU*/, "Samsung Galaxy s7 Edge"/*Name*/, "Samsung Galaxy s7 Edge + Geat 360 + Gear VR"/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, mobilesCat.Id/*parCatId*/, samsungMan.Id/*manufacturerId*/, "/file/Public/Products/product-samsung-s7-edge.jpg"/*imageUrl*/, 799/*price*/, 0/*listPrice*/);
            UpsertProduct(context, orgId, "SAMSUNG-GALAXY-NOTE5"/*SKU*/, "Samsung Galaxy Note 5"/*Name*/, "Samsung Galaxy Note 5 Black"/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, mobilesCat.Id/*parCatId*/, samsungMan.Id/*manufacturerId*/, "/file/Public/Products/product-samsung-note5.png"/*imageUrl*/, 799/*price*/, 599/*listPrice*/);
            UpsertProduct(context, orgId, "IPHONE-SE-32G"/*SKU*/, "iPhone SE 64Gb"/*Name*/, "iPhone SE 32/64Gb"/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, mobilesCat.Id/*parCatId*/, appleMan.Id/*manufacturerId*/, "/file/Public/Products/product-iphone-se.png"/*imageUrl*/, 599/*price*/, 499/*listPrice*/, true);
            UpsertProduct(context, orgId, "ASSUS-ZENPHONE"/*SKU*/, "Assus ZenFone 2"/*Name*/, "Assus ZenFone 2 (ZE550ML)"/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, mobilesCat.Id/*parCatId*/, asusdMan.Id/*manufacturerId*/, "/file/Public/Products/product-zenfone2.png"/*imageUrl*/, 453/*price*/, 399/*listPrice*/);
            UpsertProduct(context, orgId, "SONY-XPERIA-Z"/*SKU*/, "Sony Xperia Z"/*Name*/, "Sony Xperia Z Black Color"/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, mobilesCat.Id/*parCatId*/, sonyMan.Id/*manufacturerId*/, "/file/Public/Products/product-xperia-z.png"/*imageUrl*/, 799/*price*/, 599/*listPrice*/);
            UpsertProduct(context, orgId, "MS-LUMIA-531"/*SKU*/, "Microsoft Lumia 531"/*Name*/, "Microsoft Lumia 531 Smartphone Orange"/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, mobilesCat.Id/*parCatId*/, msMan.Id/*manufacturerId*/, "/file/Public/Products/product-lumia-532.png"/*imageUrl*/, 199/*price*/, 99/*listPrice*/);
            UpsertProduct(context, orgId, "SAMSUNG-GALAXY-TAB-S2"/*SKU*/, "Samsung Galaxy Tab S2"/*Name*/, "Samsung Galaxy Tab S2 Black"/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, tablesCat.Id/*parCatId*/, samsungMan.Id/*manufacturerId*/, "/file/Public/Products/product-galaxy-tab2.png"/*imageUrl*/, 499/*price*/, 399/*listPrice*/, intStatus: "trending");
            UpsertProduct(context, orgId, "SAMSUNG-GALAXY-TAB-A"/*SKU*/, "Samsung Galaxy Tab A"/*Name*/, "Samsung Galaxy Tab A 9.7\"16Gb(Wi-Fi)"/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, tablesCat.Id/*parCatId*/, samsungMan.Id/*manufacturerId*/, "/file/Public/Products/product-galaxy-taba.png"/*imageUrl*/, 399.99/*price*/, 349.99/*listPrice*/);
            UpsertProduct(context, orgId, "HP-SPECTRE-X2"/*SKU*/, "HP Spectre x2"/*Name*/, "HP Spectre x2 12-a011nr"/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, tablesCat.Id/*parCatId*/, hpMan.Id/*manufacturerId*/, "/file/Public/Products/2.png"/*imageUrl*/, 850/*price*/, 799/*listPrice*/);
            UpsertProduct(context, orgId, "SONY-XPERIA-Z2"/*SKU*/, "Sony Xperia Z2"/*Name*/, "Sony Xperia Z2 Tablet Black Color"/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, tablesCat.Id/*parCatId*/, sonyMan.Id/*manufacturerId*/, "/file/Public/Products/product-xperia-z2.png"/*imageUrl*/, 259/*price*/, 199/*listPrice*/);
            UpsertProduct(context, orgId, "IPAD-AIR-2"/*SKU*/, "iPad Air 2"/*Name*/, "iPad Air 2 32/64Gb"/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, tablesCat.Id/*parCatId*/, appleMan.Id/*manufacturerId*/, "/file/Public/Products/product-ipad-air.png"/*imageUrl*/, 459/*price*/, 399/*listPrice*/);
            UpsertProduct(context, orgId, "MAC-BOOK-AIR"/*SKU*/, "Macbook Air"/*Name*/, "Thin.Light.Powerful. And ready for anything."/*shortDescr*/, ""/*Descr*/, adminUserId/*userId*/, laptopsCat.Id/*parCatId*/, appleMan.Id/*manufacturerId*/, "/file/Public/Products/109742-apple-macbook-air-13-3-mvfk2ua-a-silver.jpg"/*imageUrl*/, 999/*price*/, 0/*listPrice*/);
            context.SaveChanges();

            // - ProductOption
            // - ProductOptionItem
            // - ProductOptionProduct

        }

        private void AddeCommerceContentNodes(DB context, int orgId, string adminUserId)
        {
            DateTime createDateTime = DateTime.Now;            
            #region insert data
            //eCommerce section
            ContentNode parentShopNode = null;
            var node = new ContentNode
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
                MenuCaption = "$resources:BAP.eCommerce.Resources.ResObject,UIText_Menu_Shop",
                AllowChildren = true,
                View = "Index",
                IsHome = true, //Identified as entry point of the web site driven by the given Organization
                RouteUrl = "shop",
                MenuIcon = "fa fa-shopping-bag",
                NameSpaces = "BAP.Web.Areas.eCommerce.Controllers",
                MenuClicable = true,
                MenuSortOrder = 2,
                TenantUnit = "Organization",
                TenantUnitId = orgId,
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
                Name = "Catalog",
                Alias = "catalog",
                AliasPath = "/eCommerce/Products",
                ShowInMenu = true,
                ShowInSitemap = true,
                NavigationType = NavigationType.MvcRoute,
                Rating = 1,
                Area = "eCommerce",
                Controller = "Products",
                Action = "Index",
                Enabled = true,
                SitemapPriority = SitemapPriority.Normal,
                SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                MenuCaption = "$resources:BAP.eCommerce.Resources.ResObject,UIText_Menu_Catalog",
                AllowChildren = true,
                View = "Index",
                IsHome = false,                
                NameSpaces = "BAP.Web.Areas.eCommerce.Controllers",
                MenuClicable = true,
                MenuSortOrder = 1,
                TenantUnit = "Organization",
                TenantUnitId = orgId,
                CreateDate = createDateTime,
                CreatedBy = adminUserId,
                LastModifiedDate = createDateTime,
                LastModifiedBy = adminUserId,
                OwnerGroup = 127,
                OwnerPermissions = 8143,
                ParentNode = parentShopNode
            };
            context.ContentNodes.Add(node);

            //eCommerce Admin
            node = new ContentNode
            {
                Name = "Addresses",
                Alias = "Addresses",
                AliasPath = "/Administration/Addresses/AdminIndex",
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
                MenuCaption = "$resources:BAP.eCommerce.Resources.ResObject,UIText_Menu_Address",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 2,
                TenantUnit = "Organization",
                TenantUnitId = orgId,
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
                AliasPath = "/Administration/Customers/AdminIndex",
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
                MenuCaption = "$resources:BAP.eCommerce.Resources.ResObject,UIText_Menu_Customers",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 3,
                TenantUnit = "Organization",
                TenantUnitId = orgId,
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
                AliasPath = "/Administration/CustomerOrders/AdminIndex",
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
                MenuCaption = "$resources:BAP.eCommerce.Resources.ResObject,UIText_Menu_CustomerOrders",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 4,
                TenantUnit = "Organization",
                TenantUnitId = orgId,
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
                AliasPath = "/Administration/DiscountCoupons/AdminIndex",
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
                MenuCaption = "$resources:BAP.eCommerce.Resources.ResObject,UIText_Menu_DiscountCoupons",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 5,
                TenantUnit = "Organization",
                TenantUnitId = orgId,
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
                AliasPath = "/Administration/Manufacturers/AdminIndex",
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
                MenuCaption = "$resources:BAP.eCommerce.Resources.ResObject,UIText_Menu_Manufacturers",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 6,
                TenantUnit = "Organization",
                TenantUnitId = orgId,
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
                AliasPath = "/Administration/Products/AdminIndex",
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
                MenuCaption = "$resources:BAP.eCommerce.Resources.ResObject,UIText_Menu_Products",
                ParentNode = parentShopNode,
                Roles = "Administrator,ContentManager,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 7,
                TenantUnit = "Organization",
                TenantUnitId = orgId,
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
                AliasPath = "/Administration/ProductCategories/AdminIndex",
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
                MenuCaption = "$resources:BAP.eCommerce.Resources.ResObject,UIText_Menu_ProductCategory",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 8,
                TenantUnit = "Organization",
                TenantUnitId = orgId,
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
                AliasPath = "/Administration/ProductOptions/AdminIndex",
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
                MenuCaption = "$resources:BAP.eCommerce.Resources.ResObject,UIText_Menu_ProductOptions",
                ParentNode = parentShopNode,
                Roles = "Administrator,ContentManager,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 9,
                TenantUnit = "Organization",
                TenantUnitId = orgId,
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
                AliasPath = "/Administration/PaymentOptions/AdminIndex",
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
                MenuCaption = "$resources:BAP.eCommerce.Resources.ResObject,UIText_Menu_PaymentOptions",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 10,
                TenantUnit = "Organization",
                TenantUnitId = orgId,
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
                AliasPath = "/Administration/ShoppingCarts/AdminIndex",
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
                MenuCaption = "$resources:BAP.eCommerce.Resources.ResObject,UIText_Menu_ShoppingCarts",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 11,
                TenantUnit = "Organization",
                TenantUnitId = orgId,
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
                AliasPath = "/Administration/ShippingCarriers/AdminIndex",
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
                MenuCaption = "$resources:BAP.eCommerce.Resources.ResObject,UIText_Menu_ShippingCarriers",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 12,
                TenantUnit = "Organization",
                TenantUnitId = orgId,
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
                AliasPath = "/Administration/ShippingOptions/AdminIndex",
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
                MenuCaption = "$resources:BAP.eCommerce.Resources.ResObject,UIText_Menu_ShippingOptions",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 13,
                TenantUnit = "Organization",
                TenantUnitId = orgId,
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
                AliasPath = "/Administration/Stores/AdminIndex",
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
                MenuCaption = "$resources:BAP.eCommerce.Resources.ResObject,UIText_Menu_Store",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 14,
                TenantUnit = "Organization",
                TenantUnitId = orgId,
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
                AliasPath = "/Administration/Suppliers/AdminIndex",
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
                MenuCaption = "$resources:BAP.eCommerce.Resources.ResObject,UIText_Menu_Suppliers",
                ParentNode = parentShopNode,
                Roles = "Administrator,Supervisor",
                AllowChildren = true,
                View = "AdminIndex",
                IsHome = false,
                NameSpaces = "BAP.Web.Areas.Administration.Controllers",
                MenuClicable = true,
                MenuSortOrder = 15,
                TenantUnit = "Organization",
                TenantUnitId = orgId,
                CreateDate = createDateTime,
                CreatedBy = adminUserId,
                LastModifiedDate = createDateTime,
                LastModifiedBy = adminUserId,
                OwnerGroup = 127,
                OwnerPermissions = 1843151
            };
            context.ContentNodes.Add(node);
            #endregion
            context.SaveChanges();
        }

        private void AddeCommerceWorkflows(DB context, int orgId, string userId)
        {
            #region insert data
            //Main and full flow =================================================================================
            var mainFlow = UpsertWorkflow(context, "CustomerOrderFlow", "Customer orders full workflow", "Administrator,Supervisor", typeof(CustomerOrder), orgId, userId);

            //Insert Actions
            var mainFlowInitAction = UpsertWorkflowAction(context, "InitOrder", "Runs automatically on workflow init", 1, null,
                mainFlow, typeof(SalesOrderInit), orgId, userId);

            var mainFlowOrderConfirmationEmailAction = UpsertWorkflowAction(context, "Order Confirmation Email",
                "Sending email confirmation when order created", 1, new List<WorkflowActionAttribute> { new WorkflowActionAttribute
            {
                Name = "EmailTemplate",
                ShortDescription = "Name of the email template",
                DefaultValue = "SalesOrderDetailsEmail",
                IsVisible = true
            } },
                mainFlow, typeof(SalesOrderEmailConfirmation), orgId, userId);
            var mainFlowOrderDetailsEmailAction = UpsertWorkflowAction(context, "Send Order Details",
                "Sending order details by request", 2, new List<WorkflowActionAttribute> { new WorkflowActionAttribute
            {
                Name = "EmailTemplate",
                ShortDescription = "Name of the email template",
                DefaultValue = "SalesOrderDetailsEmail",
                IsVisible = true
            } },
                mainFlow, typeof(SalesOrderEmailDetails), orgId, userId);
            var mainFlowAcceptPaymentAction = UpsertWorkflowAction(context, "Sales Order Accept Payment",
                "Performed when order received payment", 2, new List<WorkflowActionAttribute>
                {
                    new WorkflowActionAttribute
                    {
                        Name = "ReferenceId",
                        ShortDescription = "Payment reference Id, returned by the gateway.",
                        IsPublic = true,
                        IsVisible = true
                    },
                    new WorkflowActionAttribute
                    {
                        Name = "TotalPaid",
                        ShortDescription = "Total paid for the order.",
                        AtributeType = AttributeType.Currency,
                        IsPublic = true,
                        IsVisible = true,
                    },
                    new WorkflowActionAttribute
                    {
                        Name = "Notes",
                        ShortDescription = "Extra notes about payment processed.",
                        IsPublic = true,
                        IsVisible = true
                    }
                }, mainFlow, typeof(SalesOrderAcceptPayment), orgId, userId);

            var mainFlowSalesOrderShipmentStartedAction = UpsertWorkflowAction(context, "Sales Order Shipment Started",
                "It's performed when the actual shipment started and shipment number is known.", 2, new List<WorkflowActionAttribute> {
                    new WorkflowActionAttribute
                    {
                        Name = "ShippingReferenceId",
                        ShortDescription = "Shipment reference Id, returned by the shipping company.",
                        IsPublic = true,
                        IsVisible = true
                    }
                }, mainFlow, typeof(SalesOrderShipmentStarted), orgId, userId);
            var mainFlowSalesOrderDeliveredAction = UpsertWorkflowAction(context, "Sales Order Delivered",
                "Order delivered to the customer, taking some notes.", 2, new List<WorkflowActionAttribute> {
                    new WorkflowActionAttribute
                    {
                        Name = "Delivery Notes",
                        ShortDescription = "Extra notes about order delivery.",
                        IsPublic = true,
                        IsVisible = true
                    }
                }, mainFlow, typeof(SalesOrderDelivered), orgId, userId);
            var mainFlowSalesOrderDeliveryDeclinedAction = UpsertWorkflowAction(context, "Sales Order Delivery Declined",
                "Order delivered to the customer, but was declined to be accepted.", 2, new List<WorkflowActionAttribute> {
                    new WorkflowActionAttribute
                    {
                        Name = "Delivery Decline Notes",
                        ShortDescription = "Extra notes about delivery declined.",
                        IsPublic = true,
                        IsVisible = true
                    }
                }, mainFlow, typeof(SalesOrderDeliveryDeclined), orgId, userId);

            //Insert stages
            var wf1CreatedStage = UpsertWorkflowStage(context, "Created", "Order Created", StageType.Initial, mainFlow, orgId, userId);
            var wf1ApprovedStage = UpsertWorkflowStage(context, "Approved", "Order Approved", StageType.Work, mainFlow, orgId, userId);
            var wf1ShippedStage = UpsertWorkflowStage(context, "Shipped", "Order Shipped", StageType.Work, mainFlow, orgId, userId);
            var wf1PaidStage = UpsertWorkflowStage(context, "Paid", "Order Paid", StageType.Work, mainFlow, orgId, userId);
            var wf1DeliveredStage = UpsertWorkflowStage(context, "Delivered", "Order Delivered", StageType.Work, mainFlow, orgId, userId);
            var wf1CompletedStage = UpsertWorkflowStage(context, "Completed", "Order Completed", StageType.Finish, mainFlow, orgId, userId);
            var wf1CancelledStage = UpsertWorkflowStage(context, "Cancelled", "Order Cancelled", StageType.Cancel, mainFlow, orgId, userId);
            var wf1DeliveryDeclinedStage = UpsertWorkflowStage(context, "DeliveryDeclined", "Order Delivery Declined", StageType.Cancel, mainFlow, orgId, userId);

            //Insert stage transitions
            var wf1CreatedToApproved = UpsertWorkflowStageTransition(context, mainFlow, wf1CreatedStage, wf1ApprovedStage, null, orgId, userId);
            var wf1CreatedToCancelled = UpsertWorkflowStageTransition(context, mainFlow, wf1CreatedStage, wf1CancelledStage, null, orgId, userId);
            var wf1ApprovedToCancelled = UpsertWorkflowStageTransition(context, mainFlow, wf1ApprovedStage, wf1CancelledStage, null, orgId, userId);
            var wf1ApprovedToPaid = UpsertWorkflowStageTransition(context, mainFlow, wf1ApprovedStage, wf1PaidStage,
                new List<WorkflowAction> { mainFlowAcceptPaymentAction }, orgId, userId);
            var wf1PaidToShipped = UpsertWorkflowStageTransition(context, mainFlow, wf1PaidStage, wf1ShippedStage,
                new List<WorkflowAction> { mainFlowSalesOrderShipmentStartedAction }, orgId, userId);
            var wf1ShippedToDelivered = UpsertWorkflowStageTransition(context, mainFlow, wf1ShippedStage, wf1DeliveredStage,
                new List<WorkflowAction> { mainFlowSalesOrderDeliveredAction }, orgId, userId);
            var wf1ShippedToDeliveryDeclined = UpsertWorkflowStageTransition(context, mainFlow, wf1ShippedStage, wf1DeliveryDeclinedStage,
                new List<WorkflowAction> { mainFlowSalesOrderDeliveryDeclinedAction }, orgId, userId);
            var wf1DeliveredToCompleted = UpsertWorkflowStageTransition(context, mainFlow, wf1DeliveredStage, wf1CompletedStage, null, orgId, userId);


            // Prepaid flow ======================================================================================
            var prepaidFlow = UpsertWorkflow(context, "CustomerOrderFlowPaid", "Order paid during checkout", "Administrator,Supervisor", typeof(CustomerOrder), orgId, userId);
            //Insert Actions
            var prepaidFlowInitAction = UpsertWorkflowAction(context, "InitOrder", "Runs automatically on workflow init", 1, null,
                prepaidFlow, typeof(SalesOrderInit), orgId, userId);

            var prepaidFlowOrderConfirmationEmailAction = UpsertWorkflowAction(context, "Order Confirmation Email",
                "Sending email confirmation when order created", 1, new List<WorkflowActionAttribute> { new WorkflowActionAttribute
            {
                Name = "EmailTemplate",
                ShortDescription = "Name of the email template",
                DefaultValue = "SalesOrderDetailsEmail",
                IsVisible = true
            } },
                prepaidFlow, typeof(SalesOrderEmailConfirmation), orgId, userId);
            var prepaidFlowOrderDetailsEmailAction = UpsertWorkflowAction(context, "Send Order Details",
                "Sending order details by request", 2, new List<WorkflowActionAttribute> { new WorkflowActionAttribute
            {
                Name = "EmailTemplate",
                ShortDescription = "Name of the email template",
                DefaultValue = "SalesOrderDetailsEmail",
                IsVisible = true
            } },
                prepaidFlow, typeof(SalesOrderEmailDetails), orgId, userId);

            var prepaidFlowSalesOrderShipmentStartedAction = UpsertWorkflowAction(context, "Sales Order Shipment Started",
                "It's performed when the actual shipment started and shipment number is known.", 2, new List<WorkflowActionAttribute> {
                    new WorkflowActionAttribute
                    {
                        Name = "ShippingReferenceId",
                        ShortDescription = "Shipment reference Id, returned by the shipping company.",
                        IsPublic = true,
                        IsVisible = true
                    }
                }, prepaidFlow, typeof(SalesOrderShipmentStarted), orgId, userId);
            var prepaidFlowSalesOrderDeliveredAction = UpsertWorkflowAction(context, "Sales Order Delivered",
                "Order delivered to the customer, taking some notes.", 2, new List<WorkflowActionAttribute> {
                    new WorkflowActionAttribute
                    {
                        Name = "Delivery Notes",
                        ShortDescription = "Extra notes about order delivery.",
                        IsPublic = true,
                        IsVisible = true
                    }
                }, prepaidFlow, typeof(SalesOrderDelivered), orgId, userId);
            var prepaidFlowSalesOrderDeliveryDeclinedAction = UpsertWorkflowAction(context, "Sales Order Delivery Declined",
                "Order delivered to the customer, but was declined to be accepted.", 2, new List<WorkflowActionAttribute> {
                    new WorkflowActionAttribute
                    {
                        Name = "Delivery Decline Notes",
                        ShortDescription = "Extra notes about delivery declined.",
                        IsPublic = true,
                        IsVisible = true
                    }
                }, prepaidFlow, typeof(SalesOrderDeliveryDeclined), orgId, userId);

            //Insert stages
            var wf2CreatedStage = UpsertWorkflowStage(context, "Created", "Order Created", StageType.Initial, prepaidFlow, orgId, userId);
            var wf2ApprovedStage = UpsertWorkflowStage(context, "Approved", "Order Approved", StageType.Work, prepaidFlow, orgId, userId);
            var wf2ShippedStage = UpsertWorkflowStage(context, "Shipped", "Order Shipped", StageType.Work, prepaidFlow, orgId, userId);
            var wf2DeliveredStage = UpsertWorkflowStage(context, "Delivered", "Order Delivered", StageType.Work, prepaidFlow, orgId, userId);
            var wf2CompletedStage = UpsertWorkflowStage(context, "Completed", "Order Completed", StageType.Finish, prepaidFlow, orgId, userId);
            var wf2CancelledStage = UpsertWorkflowStage(context, "Cancelled", "Order Cancelled", StageType.Cancel, prepaidFlow, orgId, userId);
            var wf2DeliveryDeclinedStage = UpsertWorkflowStage(context, "DeliveryDeclined", "Order Delivery Declined", StageType.Cancel, prepaidFlow, orgId, userId);

            //Insert stage transitions
            var wf2CreatedToApproved = UpsertWorkflowStageTransition(context, prepaidFlow, wf2CreatedStage, wf2ApprovedStage, null, orgId, userId);
            var wf2CreatedToCancelled = UpsertWorkflowStageTransition(context, prepaidFlow, wf2CreatedStage, wf2CancelledStage, null, orgId, userId);
            var wf2ApprovedToCancelled = UpsertWorkflowStageTransition(context, prepaidFlow, wf2ApprovedStage, wf2CancelledStage, null, orgId, userId);
            var wf2ApprovedToShipped = UpsertWorkflowStageTransition(context, prepaidFlow, wf2ApprovedStage, wf2ShippedStage,
                new List<WorkflowAction> { prepaidFlowSalesOrderShipmentStartedAction }, orgId, userId);
            var wf2ShippedToDelivered = UpsertWorkflowStageTransition(context, prepaidFlow, wf2ShippedStage, wf2DeliveredStage,
                new List<WorkflowAction> { prepaidFlowSalesOrderDeliveredAction }, orgId, userId);
            var wf2ShippedToDeliveryDeclined = UpsertWorkflowStageTransition(context, prepaidFlow, wf2ShippedStage, wf2DeliveryDeclinedStage,
                new List<WorkflowAction> { prepaidFlowSalesOrderDeliveryDeclinedAction }, orgId, userId);
            var wf2DeliveredToCompleted = UpsertWorkflowStageTransition(context, prepaidFlow, wf2DeliveredStage, wf2CompletedStage, null, orgId, userId);


            
            #endregion
            context.SaveChanges();
        }

        private void AddeCommerceLocalization(DB context, int orgId, string userId)
        {
            #region insert data
            AddLocalization(context, "UIText_Menu_Shop", "Shop", null, "BAP.Resources.Resources", orgId, userId);

            AddLocalization(context, "UIText_Menu_Catalog", "Catalog", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Menu_Address", "Address", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Menu_Customers", "Customers", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Menu_CustomerOrders", "Customer Orders", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Menu_DiscountCoupons", "Discount Coupons", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Menu_Manufacturers", "Manufacturers", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Menu_Products", "Products", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Menu_ProductCategory", "Product Category", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Menu_ProductOptions", "Product Options", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Menu_PaymentOptions", "Payment Options", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Menu_ShoppingCarts", "Shopping Carts", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Menu_ShippingCarriers", "Shipping Carriers", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Menu_ShippingOptions", "Shipping Options", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Menu_Store", "Store", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Menu_Suppliers", "Suppliers", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);


            AddLocalization(context, "FieldLabel_Product_AllowToRenew", "Allow to Renew?", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_AvailableItems", "Available Items", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_CreateDate", "Created At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_CreatedByUserName", "Created By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_CustomData", "Custom Data", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_Depth", "Depth", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_Description", "Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_Enabled", "Enabled?", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_Height", "Height", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_ImagePath", "Image", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_InStoreFrom", "In Store From", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_InternalStatus", "Internal Status", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_IsTrial", "Trial?", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_LastModifiedByUserName", "Last Modified By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_LastModifiedDate", "Last Modified At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_ListPrice", "List Price", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_Manufacturer", "Manufacturer", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_MaxDownloads", "Max. Downloads", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_MaxPrice", "Max. Price", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_MinPrice", "Min. Price", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_MsrpPrice", "MSRP", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_Name", "Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_NeedsShipping", "Shipping?", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_ParentProduct", "Parent Product", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_Price", "Price", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_ProductCategory", "Category", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_ProductType", "Product Type", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_PublicStatus", "Status", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_PublishFrom", "Publish From Date", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_PublishTo", "Publish To Date", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_ReorderAt", "Reorder At Date", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_ShortDescription", "Short Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_SizeMeasure", "Size Measure", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_SKU", "SKU", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_Supplier", "Supplier", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_TrackInventory", "Track Inventory?", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_UID", "Unique ID", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_Weight", "Weight", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_WeightMeasure", "Weight Measure", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_Width", "Width", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_Attachments", "Attachments", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_RelatedProducts", "Related Products", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCartDiscountCoupon_DiscountCoupon", "Discount Coupon", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCartProduct_Count", "Count", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCartProduct_Coupon", "Coupon", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCartProduct_CreateDate", "Created At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCartProduct_CreatedByUserName", "Created By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCartProduct_CustomData", "Custom Data", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCartProduct_LastModifiedByUserName", "Last Modified By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCartProduct_LastModifiedDate", "Last Modified At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCartProduct_Price", "Price", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCartProduct_Product", "Product", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCartProduct_ShoppingCart", "Shopping Cart", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCartProduct_Subtotal", "Subtotal", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCartProduct_TotalDiscount", "Total Discounts", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_BillingAddress", "Billing Address", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_Coupon", "Coupon", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_CreateDate", "Created At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_CreatedByUserName", "Creayed By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_Currency", "Currency", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_CustomData", "Custom Data", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_DscountCoupon", "Discount Coupon", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_LastModifiedByUserName", "Last Modified By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_LastModifiedDate", "Last Modified At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_Notes", "Notes", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_PaymentOption", "Payment Option", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_ShippingAddress", "Shipping Address", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_ShippingCost", "Shipping Cost", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_ShippingOption", "Shipping Option", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_ShoppingCartProducts", "Products", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_Subtotal", "Subtotal", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_TaxTotal", "Total Tax", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_Total", "Total", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_TotalDiscounts", "Total Discounts", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_User", "User", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_AddressLine1", "Address Line 1", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_AddressLine2", "Address Line 2", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_Town_City", "Town/City", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_County_Region", "County/Region", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_State_US_Only", "State (US only)", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_Postcode", "Postcode", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_CellNumber", "Cell No.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_City", "City", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_ContactEmail", "Email", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_Country", "Country", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_County", "County", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_CreateDate", "Created At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_CreatedByUserName", "Created By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_Description", "Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_FaxNumber", "Fax", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_FirstName", "First Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_LastModifiedByUserName", "Last Modified By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_LastModifiedDate", "Last Modified At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_LastName", "Last Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_MiddleName", "Middle Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_Name", "Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_PhoneExtension", "Phone Ext.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_PhoneNumber", "Phone No.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_State", "State", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_Zip", "Zip", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_Amount", "Amount", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_Code", "Code", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_CreateDate", "Created At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_CreatedByUserName", "Created By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_Description", "Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_Enabled", "Enabled?", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_IsPercent", "Percent?", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_LastModifiedByUserName", "Last Modified By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_LastModifiedDate", "Last Modified At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_Name", "Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_ShortDescription", "Short Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Manufacturer_CreateDate", "Created At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Manufacturer_CreatedByUserName", "Created By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Manufacturer_Description", "Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Manufacturer_LastModifiedByUserName", "Last Modified By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Manufacturer_LastModifiedDate", "Last Modified At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Manufacturer_Name", "Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);
            
            AddLocalization(context, "FieldLabel_Manufacturer_ShowIfEmpty", "Show if empty", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Manufacturer_ExternalReferenceId", "External reference id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Manufacturer_ShortDescription", "Short Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_PaymentOption_AsssemblyName", "Assembly", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_PaymentOption_ClassName", "Class", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_PaymentOption_CreateDate", "Created At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_PaymentOption_CreatedByUserName", "Created By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_PaymentOption_Description", "Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_PaymentOption_Enabled", "Enabled?", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_PaymentOption_LastModifiedByUserName", "Last Modified By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_PaymentOption_LastModifiedDate", "Last Modified At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_PaymentOption_Name", "Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_PaymentOption_ShortDescription", "Short Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductCategory_CreateDate", "Created At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductCategory_CreatedByUserName", "Created By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductCategory_Description", "Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductCategory_LastModifiedByUserName", "Last Modified By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductCategory_LastModifiedDate", "Last Modified At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductCategory_Name", "Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductCategory_ShowIfEmpty", "Show if empty", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductCategory_ExternalReferenceId", "External reference id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductCategory_ShortDescription", "Short Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductOptionItem_CreateDate", "Created At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductOptionItem_CreatedByUserName", "Created By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductOptionItem_Description", "Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductOptionItem_LastModifiedByUserName", "Last Modified By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductOptionItem_LastModifiedDate", "Last Modified At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductOptionItem_Name", "Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductOptionItem_Option", "Option", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductOptionItem_Product", "Product", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductOptionItem_ShortDescription", "Short Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductOption_CreateDate", "Created At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductOption_CreatedByUserName", "Created By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductOption_Description", "Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductOption_LastModifiedByUserName", "Last Modified By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductOption_LastModifiedDate", "Last Modified At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductOption_Name", "Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductOption_ShortDescription", "Short Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductOption_Type", "Type", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductOption_UserControl", "User Control", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_RelatedProduct_CreateDate", "Created At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_RelatedProduct_CreatedByUserName", "Created By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_RelatedProduct_LastModifiedByUserName", "Last Modified By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_RelatedProduct_LastModifiedDate", "Last Modified At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingCarrier_CreateDate", "Created At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingCarrier_CreatedByUserName", "Created By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingCarrier_Description", "Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingCarrier_Enabled", "Enabled?", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingCarrier_LastModifiedByUserName", "Last Modified By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingCarrier_LastModifiedDate", "Last Modified At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingCarrier_Name", "Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingCarrier_ShippingOptions", "Shipping Options", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingCarrier_ShortDescription", "Short Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingOption_CreateDate", "Created At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingOption_CreatedByUserName", "Created By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingOption_Description", "Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingOption_Enabled", "Enabled?", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingOption_LastModifiedByUserName", "Last Modified By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingOption_LastModifiedDate", "Last Modified At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingOption_Name", "Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingOption_ShippingCarrier", "Shipping Carrier", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingOption_ShortDescription", "Short Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Supplier_CreateDate", "Created At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Supplier_CreatedByUserName", "Created By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Supplier_Description", "Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Supplier_LastModifiedByUserName", "Last Modified By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Supplier_LastModifiedDate", "Last Modified At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Supplier_Name", "Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Supplier_ShortDescription", "Short Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_ShippingAsBilling", "Same as billing Information", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EntityLabel_ShippingCarrier", "Shipping Carrier", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingCarrier_ShippingProviderAssembly", "Shipping Provider Assembly", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingCarrier_ShippingProviderClass", "Shipping Provider Class", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EntityLabel_Product", "Product", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EntityLabel_ProductCatalog", "Product Catalog", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EntityLabel_ShoppingCart", "Shopping Cart", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EntityLabel_ShippingOption", "Shipping Option", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_PaymentOption_ShippingOptions", "Assosiated Shipping Options", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingCarrier_OptionCode", "Option Code", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingCarrier_TeaserImage", "Teaser Image", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingOption_AllowedPaymentOption", "Payment Options", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingOption_OptionCode", "Option Code", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingOption_TeaserImage", "Tease Image", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EntityLabel_PaymentOption", "Payment Option", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EntityLabel_CustomerOrder", "Customer Order", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_BillingAddress", "Billing Address", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_BillingAddressId", "Billing Address Id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_Coupon", "Coupon", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_CreateDate", "Created At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_CreatedByUserName", "Created By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_Currency", "Currency", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_CurrencyId", "Currency Id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_CustomData", "Custom Data", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_Customer", "Customer", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_CustomerId", "Customer Id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_CustomerPayment", "Customer Payment", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_CustomerPaymentId", "Customer Payment Id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_Description", "Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_DiscountCoupon", "Discount Coupon", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_DiscountCouponId", "Discount Coupon Id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_DiscountsTotal", "Total Discounts", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_Items", "Order Items", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_LastModifiedByUserName", "Last Modified By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_LastModifiedDate", "Last Modified At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_Name", "Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_Notes", "Notes", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_PaymentOption", "Payment Option", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_PaymentOptionId", "Payment Option Id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_ShippingAddress", "Shipping Address", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_ShippingAddressId", "Shipping Address Id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_ShippingCost", "Total Shipping", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_ShippingOption", "Shipping Option", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_ShippingOptionId", "Shipping Option Id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_ShortDescription", "Short Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_Subtotal", "Subtotal", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_TaxTotal", "Total Tax", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_Total", "Total", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_User", "User", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_UserId", "User Id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerPayment_CreateDate", "Created At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerPayment_CreatedByUserName", "Created By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerPayment_Customer", "Customer", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerPayment_CustomerId", "Customer Id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerPayment_Description", "Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerPayment_LastModifiedByUserName", "Last Modified By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerPayment_LastModifiedDate", "Last Modified At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerPayment_Name", "Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerPayment_PaymentOption", "Payment Option", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerPayment_PaymentOptionId", "Payment Option Id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerPayment_ShortDescription", "Short Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_BillingAddress", "Billing address", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_BillingAddressId", "Billing Address Id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_CellNumber", "Cell Phone", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_CompanyAddress", "Company address", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_CompanyAddressId", "Company Address Id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_CompanyName", "Company Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_CreateDate", "Created At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_CreatedByUserName", "Created By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_CustomData", "Custom Data", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_CustomerPayments", "Payment Methods", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_Description", "Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_Email", "Email", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_FaxNumber", "Fax", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_FirstName", "First Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_LastModifiedByUserName", "Last Modified By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_LastModifiedDate", "Last Modified At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_LastName", "Last Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_LoginUser", "Login User", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_LoginUserId", "Login User Id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_MiddleName", "Middle Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_Name", "Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_PhoneNumber", "Phone", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_PrefferedCurrencyId", "Preferred Currency Id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_PrefferedCurrency", "Preferred Currency", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_PrefferedShippingOptionId", "Preferred Shipping Option Id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_PrefferedShippingOption", "Preferred Shipping Option", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_ShippingAddress", "Shipping address", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_ShippingAddressId", "Shipping Address Id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_ShortDescription", "Short Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_OrderItem_Count", "Count", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_OrderItem_CreateDate", "Created At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_OrderItem_CreatedByUserName", "Created By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_OrderItem_CustomData", "Custom Data", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_OrderItem_CustomerOrder", "Customer Order", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_OrderItem_CustomerOrderId", "Customer Order Id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_OrderItem_Description", "Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_OrderItem_DiscountCoupon", "Discount Coupon", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_OrderItem_DiscountCouponId", "Discount Coupon Id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_OrderItem_LastModifiedByUserName", "Last Modified By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_OrderItem_LastModifiedDate", "Last Modified At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_OrderItem_Name", "Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_OrderItem_Price", "Price", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_OrderItem_Product", "Product", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_OrderItem_ProductId", "Product Id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_OrderItem_ShortDescription", "Short Description", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_OrderItem_Subtotal", "Subtotal", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_OrderItem_TotalDiscounts", "Total Discounts", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_OrderItem_TotalTax", "Total Tax", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerPayment_AccountReferenceId", "Account Ref. Id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_PaymentOption_PaymentContainerCss", "Container CSS", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrderPayment_AttemptNo", "Attempt No", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrderPayment_CreateDate", "Created At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrderPayment_CreatedByUserName", "Created By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrderPayment_Currency", "Currency", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrderPayment_CustomerOrder", "Customer Order", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrderPayment_CustomerPayment", "Csutomer Payment", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrderPayment_ErrorCode", "Error Code", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrderPayment_ErrorDescription", "Error Details", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrderPayment_Finished", "Finished At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrderPayment_IsError", "Error?", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrderPayment_LastModifiedByUserName", "Last Modified By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrderPayment_LastModifiedDate", "Last Modified At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrderPayment_PaymentIntent", "Payment Intention", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrderPayment_PaymentOption", "Payment Option", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrderPayment_PaymentStatus", "Payment Status", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrderPayment_Started", "Started At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrderPayment_Total", "Total Paid", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrderPayment_ReferenceId", "Ref. Id", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrderPayment_PaymentNotes", "Notes", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_CompanyName", "Company Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_IsFeatured", "Featured?", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_PublicId", "Order#", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_PhoneExtension", "Phone Ext.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerPayment_LastUsed", "Last Used At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_ShippingPayment_Warning", "Note: If no payment option selected - all payment options are applied to this shipping option.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_AllowLowerPriority", "Allow to apply discounts with lower priority?", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_DiscountType", "Discount Type", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_ExtraCodes", "Extra Codes List", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_Priority", "Priority", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_ProductsAppied", "Products Applied", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_ValidFrom", "Valid From", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_ValidTo", "Valid To", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_ExtraCodesText", "Extra Codes Text", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_Discounts", "Discounts", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EntityLabel_DiscountCoupon", "Discount Coupon", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_CouponApplied", "Your coupon '{0}' has been applied.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_CouponNotApplied", "You coupon '{0}' could not be applied.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_CouponRemoved", "Discount coupon has been removed from the shopping cart.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EntityLabel_ProductCategory", "Product Category", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EntityLabel_ProductOption", "Product Option", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Menu_Shop", "Shop", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductCategory_ParentCategory", "Parent Category", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductCategory_Order", "Order #", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EntityLabel_ProductOptionItem", "Option Items", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EnumValue_ProductOptionType_Attribute", "Attribute", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EnumValue_ProductOptionType_NotSet", "Not set", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EnumValue_ProductOptionType_Product", "Product", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EnumValue_ProductOptionType_Text", "Text", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EnumValue_ProductOptionUserControl_CheckboxHorizontal", "Checkboxes Horizontally", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EnumValue_ProductOptionUserControl_CheckboxVertical", "Checkboxes Vertically", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EnumValue_ProductOptionUserControl_DropDownList", "Dropdown List", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EnumValue_ProductOptionUserControl_NotSet", "Not set", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EnumValue_ProductOptionUserControl_RadioHorizontal", "Radio Horizontally", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EnumValue_ProductOptionUserControl_RadioVertical", "Radio Vertically", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EnumValue_ProductOptionUserControl_Text", "Text", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EnumValue_ProductOptionUserControl_TextArea", "Text Area", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductOptionItem_PriceAdded", "Price+", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductOption_Products", "Products", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_Options", "Options Available", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_PrepaymentAmount", "Prepayment Amount", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "ErrorText_InvalidParentProductCategory", "Invalid parent product category used - it will cause circular dependency.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "ErrorText_IllegalAddToCart", "Illegal attempt to add product to the cart", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCartProduct_OptionsAddedPrice", "Options Price", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCartProduct_OptionsData", "Options", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_ProductOptionsInCart", "Options added:", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "ErrorText_ProductAlreadyOptionItem", "Cannot add product {0}, it is already present as option item.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "ErrorText_ProductAlreadyRelatedProduct", "Cannot add product {0}, it is already present as related product.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "ErrorText_ProductItemAlreadyPresent", "Cannot update item with product {0}, it is already used by another item.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "ErrorText_ProductItemAlreadyProduct", "Cannot update item with product {0}, it is already among products option is assigned to.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "ErrorText_NotaAcceptableUCForProductOptionText", "Chosen user control is not acceptable for Text type of product option", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "ErrorText_NotAcceptableUCForProductOptionAttrOrProduct", "Chosen user control is not acceptable for Product or Attribute type of product option.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_OrderItem_OptionsData", "Options", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "ErrorText_ProductCategory2LevelOnly", "Only two levels of product categories are allowed for a moment.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductOption_Enabled", "Enabled?", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_ApplyCriteria", "Discount conditions", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Customer_RegisteredDaysAgo", "Registered days ago", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_TotalWeight", "Total weight", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_BuyXAmount", "Buy X amount", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_GetYAmount", "Get Y amount", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Store_Organization", "Organization", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Store_AdminUser", "Admin user", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Store_BillingAddress", "Billing address", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Store_ShippingAddress", "Shipping address", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_Stores", "Stores", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Store_StorePaymentOptions", "Payment options", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Store_StoreShippingOptions", "Shipping options", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Store_StoreProductCategories", "Store product categories", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Store_StoreDiscountCoupons", "Store discount coupons", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_DiscountCoupon_IsDefault", "Is default", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Store_IsUnregisteredCheckoutAllowed", "Is unregistered allowed", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_PaymentOption_Stores", "Stores", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingOption_Stores", "Stores", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EntityLabel_Store", "Store", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ProductCategory_Stores", "Stores", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Store_PaymentOptions", "Payment options", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Store_ShippingOptions", "Shipping options", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Store_ProductCategories", "Product categories", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Store_DiscountCoupons", "Discount coupons", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Organization_ChooseUser", "Choose user", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Organization_AddUser", "Add user", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Organization_NoUsersSelected", "No users selected", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Organization_ChooseSubscription", "Choose subscription", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Organization_AddSubscription", "Add subscription", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Organization_NoSubscriptionsSelected", "No subscriptions selected", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EntityLabel_Address", "Address", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Address_FullName", "Full Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EntityLabel_Customer", "Customer", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_ProductAddedToWhishList", "The product has been added to Wishlist.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_CustomerValidationErrorText", "There are some validation errors around eneterd data, please review current and other tabs.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_General_CustomConfigJson", "Custom Config. (JSON)", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_CopyExampleToClipboard", "Copy example to Clipboard", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_ExampleCopied", "Example copied.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingOption_MaxPrice", "Max. Shipping Price", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_CustomDetailsUrl", "Custom Details Url", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_ProductsImported", "Products Imported", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Generic_Attachments", "Attachments", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Attachments", "Attachments", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EntityLabel_Manufacturer", "Manufacturer", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EntityLabel_Supplier", "Supplier", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Store_InvoiceTemplate", "Invoice Template", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Invoice", "Invoice", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Invoices", "Invoices", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Download", "Download", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_SendToCustomer", "Send to customer", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_YourInvoice", "Your invoice", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Manufacturer_LogoImage", "Logo image", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Manufacturer_Slogan", "Slogan", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Manufacturer_Slogan_MaxCharacters", "Maximum 80 characters allowed", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Manufacturer_File", "File", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Product_Categories", "Categories", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_DefaultSorting", "Default sorting", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_RowsPerPage", "Rows per page", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_FilterByPrice", "Filter by Price", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_Recommended", "Recommended", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_Newest", "Newest", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_Grid", "Grid", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_List", "List", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_QuickView", "Quick View", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_PriceAsc", "Price low to high", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_PriceDesc", "Price high to low", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_ProductName", "Product name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_AboutUs", "About us", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Administration", "Administration", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_AllRightReserved", "All rights reserved", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Checkout", "Checkout", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_ContactUs", "Contact us", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Copyright", "Copyright", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_CustomerCare", "Customer Care", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_ExclusivePromotions", "Exclusive Promotions", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_OrderTracker", "Order Tracker", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_PaymentMethod", "Payment method", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_PercentOff", "% off", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_PrivacyPolicy", "Privacy policy", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_SalesAdnRefund", "Sales and refund", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_ShopByBrand", "Shop By Brand", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_ShopByCategories", "Shop by Catgeries", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_ShopByPopularProducts", "Shop By Popular Products", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_ShoppingBagCount", "Shopping Bag ({0})", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_ShowAll", "Show All", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Sitemap", "Sitemap", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_TermsOfUse", "Terms of use", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_TrendingProducts", "Trending Products", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_TrendingProductsPromotion", "Prending Products Promotion", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_ViewCart", "View Cart", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_ViewMore", "View More", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Wishlist", "Wishlist", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_YourCartEmpty", "Your shopping cart is empty", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_ListOfProducts", "List of Products", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Product_SearchResultsFor", "Search Results for \"{0}\"", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_AllProducts", "All Products", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Product_WeFoundItemsFor", "We found {0} Items for \"{1}\"", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_Popular", "Popular", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_NewArrival", "New Arrival", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_Discount", "Discount", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Product_FilterBy", "Filter By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Product_Keywords", "Keywords", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Product_To", "to", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Product_Filter", "Filter", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Product_Manufactures", "Manufactures", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "DataWizardController_Json_Deserialization_error", "Json deserialization error", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "DataWizardController_Category_Successfull_Upload", "{0} categories successfully uploaded to database.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "DataWizardController_Validation_Error", "Json validation error", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "DataWizard_Alert", "Json verified, click next to upload", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "DataWizard_Header_One", "Upload JSON File", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "DataWizard_Header_Two", "Result", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_DataWizardText", "Product Category Bulk Upload", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "DataWizardController_Product_Successfull_Upload", "{0} products successfully uploaded to database.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_ProductUploadWizardText", "Product upload wizard", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_ShippingPayment", "Shipping &amp; Payment", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_ChoosePaymentMethod", "Choose a payment method", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_Back", "Back", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_Confirm", "Confirm", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_Continue", "Continue", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_ContinueShopping", "Continue Shopping", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_Checkout", "Checkout", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_OneToMaxOrder", "1 to max order", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_ApplyCoupon", "apply coupon", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_UpdateCoupon", "update cart", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_ContinueAsUnregistered", "Checkout as Unregistered", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_BillingInformation", "Billing information", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_ShippingInformation", "Shipping information", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_ShippingPolicy", "Shipping Policy", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_SignatureMayBeRequiredForDelivery", "Signature may be required for delivery", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_WeDoNotShipToPOBoxes", "We do not ship to P.O. boxes", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_DeliveryEstimatesBelowInclude", "Delivery estimates below include item preparation and shipping time", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_WeDoNotShipDirectly", "We do not ship directly to APO/FPO addresses.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_OrderReview", "Order Review", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_PaymentMethod", "Payment Method", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_ShippingMethod", "Shipping Method", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_OrderDetails", "Order Details", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_AdditionalInformation", "Additional Information", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_TermsAndConditions", "Terms and Conditions", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_IAgreeToThe", "I agree to the ", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_PaymentBy", "Payment By", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingCart_ChooseDeliveryMethod", "Choose your Delivery method", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingOptions_Carrier", "Carrier", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingOptions_Method", "Method", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingOptions_Information", "Information", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShippingOptions_Price", "Price", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_BaseOnlineUrl", "Product URL", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_IsOnline", "Online?", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_SourcePrice", "Source Price", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_OutOfStock", "Out of Stock", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrderPayment_InvoiceFileName", "Invoice File Name", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Preview", "Preview", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_FileInformation", "File Information", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_FileDetails", "File details", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CopyLinkToClipboard", "Copy link to clipboard", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_NA", "N/A", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrderInvoice", "Customer Order Invoice", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_YourAccount", "Your Account", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ModifyOrderAndUpdateAccount", "Modify an order, track a shipment, and update your account info.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_AllYouNeedInOnePlace", "All you need in one place. All with a few simple clicks.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Orders", "Orders", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_AccountSettings", "Account Settings", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_UpdateYourEmailAddressAndPassword", "Update your email address and password", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_PaymentsAndFinancing", "Payments &amp; Financing", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CheckTheBalanceOfGiftCard", "Check the balance of a gift card", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CheckStatusOfRebate", "Check the status of a rebate", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ChangePreferablePaymentMethod", "Change preferable payment method", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Specialists", "Specialists", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ViewYourPreviousActivity", "View your previous activity", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ChangeYourDefaultShippingOrBillingInfo", "Change your default shipping or billing info", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ManageEmailSubscriptions", "Manage email subscriptions", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CheckStatusOfOrder", "Check the status of an order", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_TrackShipment", "Track a shipment", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_PreSignForDelivery", "Pre-sign for a delivery", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CancelItems", "Cancel items", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_PrintInvoice", "Print an invoice", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ReturnItems", "Return items", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ChangeShippingOrBillingInfoForOrder", "Change shipping or billing info for an order", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_EditGiftMessagingOrEngraving", "Edit gift messaging or engraving", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ViewOrderHistory", "View order history", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EmailText_OrderConfirationSubject", "Sales order confirmation", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EmailText_OrderDetailsSubject", "Order details", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "EmailText_OrderSubject", "About your order", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "ErrorText_PaymentCannotBeAppliedOnOrder", "Payment could not be applied on the order, contact Support for more details", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Product_IsDownloadable", "For download?", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_OrderItem_DownloadUrl", "Download URL", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_OrderItem_OnlineProductUrl", "Online URL", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_EditDetails", "Edit Details", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_RecentOrders", "Recent Orders", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_OrderNo", "Order No.", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Date", "Date", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Qty", "Qty", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_PriceIncVat", "Price inc. VAT", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_TotalIncVat", "Total Inc. Vat", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_View", "View", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Pay", "Pay", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ViewAllOrders", "View All Orders", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_YourDetails", "Your Details", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_BackToOrders", "Back to Orders", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_ShoppingBasket", "Shopping Basket", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_GoodsTotal", "Goods Total", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_PayForYourOrder", "Pay for Your Order", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_Paid", "Paid", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_PayForOrder", "Pay for your Order", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "UIText_ViewAllOrders", "View All Orders", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_Store_QuickShoppingCart", "Quick shopping cart?", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_OrderDeliveredAt", "Delivered At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_ShipmentDeclined", "Shipment Declined?", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_ShipmentDeclinedAt", "Shipment Declined At", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_ShipmentInitiatedAt", "Shipment Started", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);

            AddLocalization(context, "FieldLabel_CustomerOrder_ShippingReferenceId", "Shipment Ref. #", null, "BAP.eCommerce.Resources.ResObject", orgId, userId);
            #endregion
            context.SaveChanges();
        }
    }
}
