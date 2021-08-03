namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncreaseProductName : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Product", "IX_ProductName");
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false, maxLength: 256));
            CreateIndex("dbo.Product", "Name", unique: true, name: "IX_ProductName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Product", "IX_ProductName");
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false, maxLength: 80));
            CreateIndex("dbo.Product", "Name", unique: true, name: "IX_ProductName");
        }
    }
}
