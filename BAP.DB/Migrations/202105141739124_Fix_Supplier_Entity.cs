namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix_Supplier_Entity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Supplier", "ExecutionConfig", c => c.String(nullable: false));
            AlterColumn("dbo.ProductSupplierData", "LastOutOfStockDate", c => c.DateTime());
            DropColumn("dbo.Supplier", "Config");
            DropColumn("dbo.Supplier", "PublicId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Supplier", "PublicId", c => c.Guid(nullable: false));
            AddColumn("dbo.Supplier", "Config", c => c.String(nullable: false));
            AlterColumn("dbo.ProductSupplierData", "LastOutOfStockDate", c => c.DateTimeOffset(precision: 7));
            DropColumn("dbo.Supplier", "ExecutionConfig");
        }
    }
}
