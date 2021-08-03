namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExternalReferenceIdToProductCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategory", "ExternalReferenceId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductCategory", "ExternalReferenceId");
        }
    }
}
