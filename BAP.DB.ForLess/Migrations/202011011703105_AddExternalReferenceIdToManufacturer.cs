namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExternalReferenceIdToManufacturer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Manufacturer", "ExternalReferenceId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Manufacturer", "ExternalReferenceId");
        }
    }
}
