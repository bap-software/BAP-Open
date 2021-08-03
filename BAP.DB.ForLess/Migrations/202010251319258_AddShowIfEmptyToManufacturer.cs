namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShowIfEmptyToManufacturer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Manufacturer", "ShowIfEmpty", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Manufacturer", "ShowIfEmpty");
        }
    }
}
