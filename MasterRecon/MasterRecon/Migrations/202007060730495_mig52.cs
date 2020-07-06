namespace MasterRecon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig52 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PageActionLogMasters",
                c => new
                    {
                        PageActionLogID = c.Long(nullable: false, identity: true),
                        LogID = c.Long(nullable: false),
                        MethodName = c.String(nullable: false),
                        ActivityStartDtTm = c.DateTime(nullable: false),
                        ActivityEndDtTm = c.DateTime(),
                        RemarkType = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                        CreatedBy = c.Long(),
                        CreatedDtTm = c.DateTime(),
                        ModifiedBy = c.Long(),
                        ModifiedDtTm = c.DateTime(),
                    })
                .PrimaryKey(t => t.PageActionLogID);
            
            CreateTable(
                "dbo.PageLogMasters",
                c => new
                    {
                        LogID = c.Long(nullable: false, identity: true),
                        UserID = c.Long(nullable: false),
                        PageID = c.Long(nullable: false),
                        PageEnteredDtTm = c.DateTime(nullable: false),
                        PageLeftDtTm = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                        CreatedBy = c.Long(),
                        CreatedDtTm = c.DateTime(),
                        ModifiedBy = c.Long(),
                        ModifiedDtTm = c.DateTime(),
                    })
                .PrimaryKey(t => t.LogID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PageLogMasters");
            DropTable("dbo.PageActionLogMasters");
        }
    }
}
