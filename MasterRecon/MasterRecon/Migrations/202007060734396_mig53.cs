namespace MasterRecon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig53 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PageMasters",
                c => new
                    {
                        PageID = c.Long(nullable: false, identity: true),
                        PageName = c.String(nullable: false),
                        PageType = c.Int(nullable: false),
                        ControllerName = c.String(),
                        ActionName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                        CreatedBy = c.Long(),
                        CreatedDtTm = c.DateTime(),
                        ModifiedBy = c.Long(),
                        ModifiedDtTm = c.DateTime(),
                    })
                .PrimaryKey(t => t.PageID);
            
            CreateTable(
                "dbo.RoleMasters",
                c => new
                    {
                        RoleID = c.Long(nullable: false, identity: true),
                        RoleName = c.String(nullable: false),
                        ClientID = c.Long(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                        CreatedBy = c.Long(),
                        CreatedDtTm = c.DateTime(),
                        ModifiedBy = c.Long(),
                        ModifiedDtTm = c.DateTime(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.RolePageMappings",
                c => new
                    {
                        RolePageID = c.Long(nullable: false, identity: true),
                        PageID = c.Long(nullable: false),
                        RoleID = c.Long(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                        CreatedBy = c.Long(),
                        CreatedDtTm = c.DateTime(),
                        ModifiedBy = c.Long(),
                        ModifiedDtTm = c.DateTime(),
                    })
                .PrimaryKey(t => t.RolePageID);
            
            CreateTable(
                "dbo.UserMasters",
                c => new
                    {
                        UserID = c.Long(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        MobileNo = c.String(nullable: false),
                        EmailID = c.String(nullable: false),
                        RoleID = c.Long(nullable: false),
                        ClientID = c.Long(nullable: false),
                        ManagerID = c.Long(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                        CreatedBy = c.Long(),
                        CreatedDtTm = c.DateTime(),
                        ModifiedBy = c.Long(),
                        ModifiedDtTm = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserMasters");
            DropTable("dbo.RolePageMappings");
            DropTable("dbo.RoleMasters");
            DropTable("dbo.PageMasters");
        }
    }
}
