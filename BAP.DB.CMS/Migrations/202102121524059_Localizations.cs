namespace BAP.CMSDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Localizations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Localization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 1024),
                        ResourceSet = c.String(maxLength: 80),
                        FileName = c.String(maxLength: 512),
                        Value = c.String(),
                        Object = c.String(maxLength: 255),
                        ObjectId = c.Int(nullable: false),
                        CultureCode = c.String(maxLength: 10),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.Object, t.ObjectId }, name: "IX_LocalizationObject")
                .Index(t => t.CultureCode)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Localization", new[] { "OwnerPermissions" });
            DropIndex("dbo.Localization", new[] { "OwnerGroup" });
            DropIndex("dbo.Localization", "IX_Tenant");
            DropIndex("dbo.Localization", new[] { "CultureCode" });
            DropIndex("dbo.Localization", "IX_LocalizationObject");
            DropTable("dbo.Localization");
        }
    }
}
