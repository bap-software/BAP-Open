namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Supplier_Feature : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductSupplierData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                        ExternalProductId = c.Int(nullable: false),
                        LastOutOfStockDate = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            AddColumn("dbo.Product", "ProductSupplierDataId", c => c.Int());
            AddColumn("dbo.Supplier", "Config", c => c.String(nullable: false));
            AddColumn("dbo.Supplier", "SupplierActionClassesDbValue", c => c.String(nullable: false));
            AddColumn("dbo.Supplier", "SupplierActionAssembly", c => c.String(nullable: false));
            AddColumn("dbo.Supplier", "PublicId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Product", "ProductSupplierDataId");
            AddForeignKey("dbo.Product", "ProductSupplierDataId", "dbo.ProductSupplierData", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "ProductSupplierDataId", "dbo.ProductSupplierData");
            DropIndex("dbo.ProductSupplierData", new[] { "OwnerPermissions" });
            DropIndex("dbo.ProductSupplierData", new[] { "OwnerGroup" });
            DropIndex("dbo.ProductSupplierData", "IX_Tenant");
            DropIndex("dbo.Product", new[] { "ProductSupplierDataId" });
            DropColumn("dbo.Supplier", "PublicId");
            DropColumn("dbo.Supplier", "SupplierActionAssembly");
            DropColumn("dbo.Supplier", "SupplierActionClassesDbValue");
            DropColumn("dbo.Supplier", "Config");
            DropColumn("dbo.Product", "ProductSupplierDataId");
            DropTable("dbo.ProductSupplierData");
        }
    }
}
