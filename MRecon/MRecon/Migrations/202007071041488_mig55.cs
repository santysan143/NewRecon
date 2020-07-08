namespace MRecon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig55 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegistrationWiseSearchTypes", "IsRequired", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegistrationWiseSearchTypes", "IsRequired");
        }
    }
}
