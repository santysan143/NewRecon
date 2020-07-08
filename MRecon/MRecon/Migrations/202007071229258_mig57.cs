namespace MRecon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig57 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RegistrationMasters", "IsActivated", c => c.Boolean());
            AlterColumn("dbo.RegistrationWiseSearchTypes", "IsRequired", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegistrationWiseSearchTypes", "IsRequired", c => c.Boolean(nullable: false));
            AlterColumn("dbo.RegistrationMasters", "IsActivated", c => c.Boolean(nullable: false));
        }
    }
}
