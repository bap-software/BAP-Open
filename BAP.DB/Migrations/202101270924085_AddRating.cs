namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Rating");
            DropColumn("dbo.Customer", "Rating");
        }
    }
}
