namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShowIfEmptyToProductCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategory", "ShowIfEmpty", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductCategory", "ShowIfEmpty");
        }
    }
}
