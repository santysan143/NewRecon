namespace MRecon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientMasters",
                c => new
                    {
                        ClientID = c.Long(nullable: false, identity: true),
                        ClientName = c.String(nullable: false),
                        MobileNo = c.String(nullable: false),
                        EmailID = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        State = c.String(),
                        Country = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                        CreatedBy = c.Long(),
                        CreatedDtTm = c.DateTime(),
                        ModifiedBy = c.Long(),
                        ModifiedDtTm = c.DateTime(),
                    })
                .PrimaryKey(t => t.ClientID);
            
            CreateTable(
                "dbo.LicenseGenerationMasters",
                c => new
                    {
                        LicenseGenerationID = c.Long(nullable: false, identity: true),
                        ClientID = c.Long(nullable: false),
                        LicencseCount = c.Int(nullable: false),
                        LicenseType = c.Int(nullable: false),
                        LicenseDuration = c.Int(nullable: false),
                        LicenseFromDtTm = c.DateTime(nullable: false),
                        LicenseToDtTm = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                        CreatedBy = c.Long(),
                        CreatedDtTm = c.DateTime(),
                        ModifiedBy = c.Long(),
                        ModifiedDtTm = c.DateTime(),
                    })
                .PrimaryKey(t => t.LicenseGenerationID);
            
            CreateTable(
                "dbo.LicenseKeys",
                c => new
                    {
                        LicenseKeyID = c.Long(nullable: false, identity: true),
                        LicenseGenerationID = c.Long(nullable: false),
                        LicenseKeyCode = c.String(nullable: false),
                        LicenseKeySequence = c.Int(nullable: false),
                        RegistrationDtTm = c.DateTime(),
                        ValidUptoDtTm = c.DateTime(),
                        MacAddress = c.String(),
                        DesktopName = c.String(),
                        IpAddress = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                        CreatedBy = c.Long(),
                        CreatedDtTm = c.DateTime(),
                        ModifiedBy = c.Long(),
                        ModifiedDtTm = c.DateTime(),
                    })
                .PrimaryKey(t => t.LicenseKeyID);
            
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
                "dbo.RegistrationMasters",
                c => new
                    {
                        RegistrationID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        MobileNo = c.String(),
                        EmailID = c.String(),
                        MacAddress = c.String(),
                        SystemName = c.String(),
                        Key = c.String(),
                        IsSentForRegistration = c.Boolean(nullable: false),
                        ActivationKey = c.String(),
                        IsActivated = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                        CreatedBy = c.Long(),
                        CreatedDtTm = c.DateTime(),
                        ModifiedBy = c.Long(),
                        ModifiedDtTm = c.DateTime(),
                    })
                .PrimaryKey(t => t.RegistrationID);
            
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
                "dbo.SearchDetailMasters",
                c => new
                    {
                        SearchDetailID = c.Long(nullable: false, identity: true),
                        MacAddress = c.String(nullable: false),
                        DesktopName = c.String(nullable: false),
                        IPAddress = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                        CreatedBy = c.Long(),
                        CreatedDtTm = c.DateTime(),
                        ModifiedBy = c.Long(),
                        ModifiedDtTm = c.DateTime(),
                    })
                .PrimaryKey(t => t.SearchDetailID);
            
            CreateTable(
                "dbo.SearchDetailTransactions",
                c => new
                    {
                        TransactionID = c.Long(nullable: false, identity: true),
                        SearchDetailID = c.Long(nullable: false),
                        SearchTypeID = c.Long(nullable: false),
                        FileName = c.String(nullable: false),
                        FilePath = c.Long(nullable: false),
                        SearchText = c.Long(nullable: false),
                        LineNo = c.Long(nullable: false),
                        SearchStatusID = c.Long(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                        CreatedBy = c.Long(),
                        CreatedDtTm = c.DateTime(),
                        ModifiedBy = c.Long(),
                        ModifiedDtTm = c.DateTime(),
                    })
                .PrimaryKey(t => t.TransactionID);
            
            CreateTable(
                "dbo.SearchStatusMasters",
                c => new
                    {
                        SearchStatusID = c.Long(nullable: false, identity: true),
                        SearchStatusName = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                        CreatedBy = c.Long(),
                        CreatedDtTm = c.DateTime(),
                        ModifiedBy = c.Long(),
                        ModifiedDtTm = c.DateTime(),
                    })
                .PrimaryKey(t => t.SearchStatusID);
            
            CreateTable(
                "dbo.SearchTransactionStatusLogs",
                c => new
                    {
                        TransactionStatusID = c.Long(nullable: false, identity: true),
                        TransactionID = c.Long(nullable: false),
                        SearchStatusID = c.Long(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                        CreatedBy = c.Long(),
                        CreatedDtTm = c.DateTime(),
                        ModifiedBy = c.Long(),
                        ModifiedDtTm = c.DateTime(),
                    })
                .PrimaryKey(t => t.TransactionStatusID);
            
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
            DropTable("dbo.SearchTypeMasters");
            DropTable("dbo.SearchTransactionStatusLogs");
            DropTable("dbo.SearchStatusMasters");
            DropTable("dbo.SearchDetailTransactions");
            DropTable("dbo.SearchDetailMasters");
            DropTable("dbo.RolePageMappings");
            DropTable("dbo.RoleMasters");
            DropTable("dbo.RegistrationMasters");
            DropTable("dbo.PageMasters");
            DropTable("dbo.PageLogMasters");
            DropTable("dbo.PageActionLogMasters");
            DropTable("dbo.LicenseKeys");
            DropTable("dbo.LicenseGenerationMasters");
            DropTable("dbo.ClientMasters");
        }
    }
}
