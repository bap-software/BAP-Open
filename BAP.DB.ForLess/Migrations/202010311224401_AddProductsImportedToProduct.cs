namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductsImportedToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ProductsImported", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "ProductsImported");
        }
    }
}
