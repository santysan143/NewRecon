namespace MRecon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig53 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserMasters", "ManagerID", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserMasters", "ManagerID", c => c.Long(nullable: false));
        }
    }
}
