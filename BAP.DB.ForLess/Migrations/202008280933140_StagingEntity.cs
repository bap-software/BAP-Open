namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StagingEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StagingEntity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DescriptionClassFullyQualifiedName = c.String(maxLength: 512),
                        TargetEntityFullyQualifiedName = c.String(maxLength: 512),
                        JsonData = c.String(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.StagingEntity", new[] { "OwnerPermissions" });
            DropIndex("dbo.StagingEntity", new[] { "OwnerGroup" });
            DropIndex("dbo.StagingEntity", "IX_Tenant");
            DropTable("dbo.StagingEntity");
        }
    }
}
