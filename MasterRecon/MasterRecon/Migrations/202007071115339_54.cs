namespace MasterRecon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _54 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegistrationMasters", "CompanyName", c => c.String());
            AddColumn("dbo.RegistrationMasters", "LicenseCount", c => c.Int(nullable: false));
            AddColumn("dbo.RegistrationMasters", "LicenseUsed", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegistrationMasters", "LicenseUsed");
            DropColumn("dbo.RegistrationMasters", "LicenseCount");
            DropColumn("dbo.RegistrationMasters", "CompanyName");
        }
    }
}
