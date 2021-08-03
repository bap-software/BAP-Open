namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WideProductShortDescription : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "ShortDescription", c => c.String(nullable: false, maxLength: 1024));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "ShortDescription", c => c.String(nullable: false, maxLength: 256));
        }
    }
}
