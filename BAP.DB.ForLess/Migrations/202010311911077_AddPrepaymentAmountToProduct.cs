namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrepaymentAmountToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "PrepaymentAmount", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "PrepaymentAmount");
        }
    }
}
