namespace BAP.CMSDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlatformSync : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ContentViewControl", new[] { "CultureCode" });
            DropIndex("dbo.ContentViewControl", new[] { "LocalizationId" });
            DropIndex("dbo.ContentControl", new[] { "CultureCode" });
            DropIndex("dbo.ContentControl", new[] { "LocalizationId" });
            DropIndex("dbo.ContentControlType", new[] { "CultureCode" });
            DropIndex("dbo.ContentControlType", new[] { "LocalizationId" });
            DropIndex("dbo.ContentNode", "IX_ContentNodeName");
            DropIndex("dbo.ContentNode", "IX_ContentNodeRoute");
            DropIndex("dbo.ContentNode", new[] { "CultureCode" });
            DropIndex("dbo.ContentNode", new[] { "LocalizationId" });
            DropIndex("dbo.ContentView", "IX_ContentViewName");
            DropIndex("dbo.ContentView", new[] { "CultureCode" });
            DropIndex("dbo.ContentView", new[] { "LocalizationId" });
            DropIndex("dbo.ContentLocalization", new[] { "CultureCode" });
            DropIndex("dbo.ContentLocalization", new[] { "LocalizationId" });
            DropIndex("dbo.DocumentTemplate", new[] { "CultureCode" });
            DropIndex("dbo.DocumentTemplate", new[] { "LocalizationId" });
            DropIndex("dbo.Lookup", new[] { "CultureCode" });
            DropIndex("dbo.Lookup", new[] { "LocalizationId" });
            DropIndex("dbo.LookupValue", new[] { "CultureCode" });
            DropIndex("dbo.LookupValue", new[] { "LocalizationId" });
            DropIndex("dbo.NewsLetter", new[] { "CultureCode" });
            DropIndex("dbo.NewsLetter", new[] { "LocalizationId" });
            DropIndex("dbo.OrganizationService", new[] { "CultureCode" });
            DropIndex("dbo.OrganizationService", new[] { "LocalizationId" });
            AddColumn("dbo.Subscription", "Object", c => c.String(maxLength: 255));
            AddColumn("dbo.Subscription", "ObjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.ContentNode", new[] { "Name", "TenantUnit", "TenantUnitId" }, unique: true, name: "IX_ContentNodeName");
            CreateIndex("dbo.ContentNode", new[] { "Area", "Controller", "Action", "View", "TenantUnit", "TenantUnitId" }, unique: true, name: "IX_ContentNodeRoute");
            CreateIndex("dbo.ContentView", new[] { "Name", "TenantUnit", "TenantUnitId" }, unique: true, name: "IX_ContentViewName");
            DropColumn("dbo.ContentViewControl", "CultureCode");
            DropColumn("dbo.ContentViewControl", "LocalizationId");
            DropColumn("dbo.ContentControl", "CultureCode");
            DropColumn("dbo.ContentControl", "LocalizationId");
            DropColumn("dbo.ContentControlType", "CultureCode");
            DropColumn("dbo.ContentControlType", "LocalizationId");
            DropColumn("dbo.ContentNode", "CultureCode");
            DropColumn("dbo.ContentNode", "LocalizationId");
            DropColumn("dbo.ContentView", "CultureCode");
            DropColumn("dbo.ContentView", "LocalizationId");
            DropColumn("dbo.ContentLocalization", "CultureCode");
            DropColumn("dbo.ContentLocalization", "LocalizationId");
            DropColumn("dbo.DocumentTemplate", "CultureCode");
            DropColumn("dbo.DocumentTemplate", "LocalizationId");
            DropColumn("dbo.Lookup", "CultureCode");
            DropColumn("dbo.Lookup", "LocalizationId");
            DropColumn("dbo.LookupValue", "CultureCode");
            DropColumn("dbo.LookupValue", "LocalizationId");
            DropColumn("dbo.NewsLetter", "CultureCode");
            DropColumn("dbo.NewsLetter", "LocalizationId");
            DropColumn("dbo.OrganizationService", "CultureCode");
            DropColumn("dbo.OrganizationService", "LocalizationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrganizationService", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.OrganizationService", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.NewsLetter", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.NewsLetter", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.LookupValue", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.LookupValue", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.Lookup", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.Lookup", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.DocumentTemplate", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.DocumentTemplate", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ContentLocalization", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ContentLocalization", "CultureCode", c => c.String(maxLength: 20));
            AddColumn("dbo.ContentView", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ContentView", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ContentNode", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ContentNode", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ContentControlType", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ContentControlType", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ContentControl", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ContentControl", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ContentViewControl", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ContentViewControl", "CultureCode", c => c.String(maxLength: 10));
            DropIndex("dbo.ContentView", "IX_ContentViewName");
            DropIndex("dbo.ContentNode", "IX_ContentNodeRoute");
            DropIndex("dbo.ContentNode", "IX_ContentNodeName");
            DropColumn("dbo.Subscription", "ObjectId");
            DropColumn("dbo.Subscription", "Object");
            CreateIndex("dbo.OrganizationService", "LocalizationId");
            CreateIndex("dbo.OrganizationService", "CultureCode");
            CreateIndex("dbo.NewsLetter", "LocalizationId");
            CreateIndex("dbo.NewsLetter", "CultureCode");
            CreateIndex("dbo.LookupValue", "LocalizationId");
            CreateIndex("dbo.LookupValue", "CultureCode");
            CreateIndex("dbo.Lookup", "LocalizationId");
            CreateIndex("dbo.Lookup", "CultureCode");
            CreateIndex("dbo.DocumentTemplate", "LocalizationId");
            CreateIndex("dbo.DocumentTemplate", "CultureCode");
            CreateIndex("dbo.ContentLocalization", "LocalizationId");
            CreateIndex("dbo.ContentLocalization", "CultureCode");
            CreateIndex("dbo.ContentView", "LocalizationId");
            CreateIndex("dbo.ContentView", "CultureCode");
            CreateIndex("dbo.ContentView", "Name", unique: true, name: "IX_ContentViewName");
            CreateIndex("dbo.ContentNode", "LocalizationId");
            CreateIndex("dbo.ContentNode", "CultureCode");
            CreateIndex("dbo.ContentNode", new[] { "Area", "Controller", "Action", "View" }, unique: true, name: "IX_ContentNodeRoute");
            CreateIndex("dbo.ContentNode", "Name", unique: true, name: "IX_ContentNodeName");
            CreateIndex("dbo.ContentControlType", "LocalizationId");
            CreateIndex("dbo.ContentControlType", "CultureCode");
            CreateIndex("dbo.ContentControl", "LocalizationId");
            CreateIndex("dbo.ContentControl", "CultureCode");
            CreateIndex("dbo.ContentViewControl", "LocalizationId");
            CreateIndex("dbo.ContentViewControl", "CultureCode");
        }
    }
}
