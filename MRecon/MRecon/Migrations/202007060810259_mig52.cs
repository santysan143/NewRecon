namespace MRecon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig52 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserMasters", "ClientID", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserMasters", "ClientID", c => c.Long(nullable: false));
        }
    }
}
