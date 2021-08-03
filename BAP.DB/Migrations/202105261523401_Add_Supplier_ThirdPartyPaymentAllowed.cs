namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Supplier_ThirdPartyPaymentAllowed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Supplier", "ThirdPartyPaymentAllowed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Supplier", "ThirdPartyPaymentAllowed");
        }
    }
}
