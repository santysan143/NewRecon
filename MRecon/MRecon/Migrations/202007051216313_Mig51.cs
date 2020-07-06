namespace MRecon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig51 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegistrationMasters", "ActivatedBy", c => c.String());
            AddColumn("dbo.RegistrationMasters", "ActivatedDtTm", c => c.DateTime());
            AddColumn("dbo.RegistrationMasters", "ActivatedTillDtTm", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegistrationMasters", "ActivatedTillDtTm");
            DropColumn("dbo.RegistrationMasters", "ActivatedDtTm");
            DropColumn("dbo.RegistrationMasters", "ActivatedBy");
        }
    }
}
