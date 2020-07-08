namespace MRecon.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using MRecon.Model;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DbModel")
        {
        }

        //Tables
        //Used
        public DbSet<RegistrationWiseSearchTypes> RegistrationWiseSearchTypes { get; set; }
        //Used
        public DbSet<EmailConfigurationMaster> EmailConfigurationMasters { get; set; }
        //Used
        public DbSet<RegistrationMaster> RegistrationMasters { get; set; }
        public DbSet<ClientMaster> ClientMasters { get; set; }
        //Used
        public DbSet<RoleMaster> RoleMasters { get; set; }
        //Used
        public DbSet<UserMaster> UserMasters { get; set; }
        //Used
        public DbSet<PageMaster> PageMasters { get; set; }
        //Used
        public DbSet<RolePageMapping> RolePageMappings { get; set; }
        //Unused
        public DbSet<LicenseGenerationMaster> LicenseGenerationMasters { get; set; }
        //Used
        public DbSet<LicenseKeys> LicenseKeys { get; set; }
        //Used
        public DbSet<SearchTypeMaster> SearchTypeMasters { get; set; }
        //Unused
        public DbSet<SearchStatusMaster> SearchStatusMasters { get; set; }
        //Unused
        public DbSet<SearchDetailMaster> SearchDetailMasters { get; set; }
        //Unused
        public DbSet<SearchDetailTransactions> SearchDetailTransactions { get; set; }
        //Unused
        public DbSet<SearchTransactionStatusLogs> SearchTransactionStatusLogs { get; set; }
        //Used
        public DbSet<PageLogMaster> PageLogMasters { get; set; }
        //Used
        public DbSet<PageActionLogMaster> PageActionLogMasters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
