namespace MasterRecon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _55 : DbMigration
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
                        IsRequired = c.Boolean(nullable: false),
                        IsActivated = c.Boolean(),
                        ActivatedDtTm = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                        CreatedBy = c.Long(),
                        CreatedDtTm = c.DateTime(),
                        ModifiedBy = c.Long(),
                        ModifiedDtTm = c.DateTime(),
                    })
                .PrimaryKey(t => t.RegistrationWiseSearchTypeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RegistrationWiseSearchTypes");
        }
    }
}
