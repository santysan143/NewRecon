namespace MRecon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig56 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RegistrationWiseSearchTypes", "IsActivated", c => c.Boolean());
            AlterColumn("dbo.RegistrationWiseSearchTypes", "ActivatedDtTm", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegistrationWiseSearchTypes", "ActivatedDtTm", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RegistrationWiseSearchTypes", "IsActivated", c => c.Boolean(nullable: false));
        }
    }
}
