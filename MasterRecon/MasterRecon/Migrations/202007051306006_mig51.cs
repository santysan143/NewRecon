namespace MasterRecon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig51 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegistrationMasters",
                c => new
                    {
                        RegistrationID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        MobileNo = c.String(),
                        EmailID = c.String(),
                        MacAddress = c.String(),
                        SystemName = c.String(),
                        Key = c.String(),
                        IsSentForRegistration = c.Boolean(nullable: false),
                        ActivationKey = c.String(),
                        IsActivated = c.Boolean(nullable: false),
                        ActivatedBy = c.String(),
                        ActivatedDtTm = c.DateTime(),
                        ActivatedTillDtTm = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                        CreatedBy = c.Long(),
                        CreatedDtTm = c.DateTime(),
                        ModifiedBy = c.Long(),
                        ModifiedDtTm = c.DateTime(),
                    })
                .PrimaryKey(t => t.RegistrationID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RegistrationMasters");
        }
    }
}
