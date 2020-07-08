namespace MRecon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig54 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegistrationWiseSearchTypes",
                c => new
                    {
                        RegistrationWiseSearchTypeID = c.Long(nullable: false, identity: true),
                        RegistrationID = c.Long(nullable: false),
                        SearchTypeID = c.Long(nullable: false),
                        IsActivated = c.Boolean(nullable: false),
                        ActivatedDtTm = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                        CreatedBy = c.Long(),
                        CreatedDtTm = c.DateTime(),
                        ModifiedBy = c.Long(),
                        ModifiedDtTm = c.DateTime(),
                    })
                .PrimaryKey(t => t.RegistrationWiseSearchTypeID);
            
            AddColumn("dbo.LicenseKeys", "RegistrationID", c => c.Long(nullable: false));
            AddColumn("dbo.RegistrationMasters", "CompanyName", c => c.String());
            AddColumn("dbo.RegistrationMasters", "LicenseCount", c => c.Int(nullable: false));
            AddColumn("dbo.RegistrationMasters", "LicenseUsed", c => c.Int(nullable: false));
            DropColumn("dbo.LicenseKeys", "LicenseGenerationID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LicenseKeys", "LicenseGenerationID", c => c.Long(nullable: false));
            DropColumn("dbo.RegistrationMasters", "LicenseUsed");
            DropColumn("dbo.RegistrationMasters", "LicenseCount");
            DropColumn("dbo.RegistrationMasters", "CompanyName");
            DropColumn("dbo.LicenseKeys", "RegistrationID");
            DropTable("dbo.RegistrationWiseSearchTypes");
        }
    }
}
