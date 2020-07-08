namespace MasterRecon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _56 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SearchTypeMasters",
                c => new
                    {
                        SearchTypeID = c.Long(nullable: false, identity: true),
                        SearchName = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                        CreatedBy = c.Long(),
                        CreatedDtTm = c.DateTime(),
                        ModifiedBy = c.Long(),
                        ModifiedDtTm = c.DateTime(),
                    })
                .PrimaryKey(t => t.SearchTypeID);
            
            AlterColumn("dbo.RegistrationWiseSearchTypes", "IsRequired", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegistrationWiseSearchTypes", "IsRequired", c => c.Boolean(nullable: false));
            DropTable("dbo.SearchTypeMasters");
        }
    }
}
