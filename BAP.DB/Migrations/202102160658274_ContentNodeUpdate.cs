namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContentNodeUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContentNode", "KeepViewFile", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContentNode", "KeepViewFile");
        }
    }
}
