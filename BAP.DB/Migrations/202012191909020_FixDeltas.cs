namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDeltas : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Product", "IX_ProductName");
            AddColumn("dbo.Product", "PrepaymentAmount", c => c.Single(nullable: false));
            AddColumn("dbo.Product", "ProductsImported", c => c.Boolean(nullable: false));
            AddColumn("dbo.Manufacturer", "ShowIfEmpty", c => c.Boolean(nullable: false));
            AddColumn("dbo.Manufacturer", "ExternalReferenceId", c => c.String());
            AddColumn("dbo.ProductCategory", "ShowIfEmpty", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProductCategory", "ExternalReferenceId", c => c.String());
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Product", "ShortDescription", c => c.String(nullable: false, maxLength: 1024));
            CreateIndex("dbo.Product", "Name", unique: true, name: "IX_ProductName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Product", "IX_ProductName");
            AlterColumn("dbo.Product", "ShortDescription", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false, maxLength: 80));
            DropColumn("dbo.ProductCategory", "ExternalReferenceId");
            DropColumn("dbo.ProductCategory", "ShowIfEmpty");
            DropColumn("dbo.Manufacturer", "ExternalReferenceId");
            DropColumn("dbo.Manufacturer", "ShowIfEmpty");
            DropColumn("dbo.Product", "ProductsImported");
            DropColumn("dbo.Product", "PrepaymentAmount");
            CreateIndex("dbo.Product", "Name", unique: true, name: "IX_ProductName");
        }
    }
}
