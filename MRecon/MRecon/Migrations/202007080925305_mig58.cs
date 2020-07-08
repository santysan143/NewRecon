namespace MRecon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig58 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailConfigurationMasters",
                c => new
                    {
                        EmailConfigurationID = c.Long(nullable: false, identity: true),
                        EmailID = c.String(),
                        Password = c.String(),
                        ServerName = c.String(),
                        Port = c.Int(nullable: false),
                        IsSSLRequired = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                        CreatedBy = c.Long(),
                        CreatedDtTm = c.DateTime(),
                        ModifiedBy = c.Long(),
                        ModifiedDtTm = c.DateTime(),
                    })
                .PrimaryKey(t => t.EmailConfigurationID);
            
            AddColumn("dbo.UserMasters", "ConfirmPassword", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserMasters", "ConfirmPassword");
            DropTable("dbo.EmailConfigurationMasters");
        }
    }
}
