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
        public DbSet<RegistrationMaster> RegistrationMasters { get; set; }
        public DbSet<ClientMaster> ClientMasters { get; set; }
        public DbSet<RoleMaster> RoleMasters { get; set; }
        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<PageMaster> PageMasters { get; set; }
        public DbSet<RolePageMapping> RolePageMappings { get; set; }
        public DbSet<LicenseGenerationMaster> LicenseGenerationMasters { get; set; }
        public DbSet<LicenseKeys> LicenseKeys { get; set; }
        public DbSet<SearchTypeMaster> SearchTypeMasters { get; set; }
        public DbSet<SearchStatusMaster> SearchStatusMasters { get; set; }
        public DbSet<SearchDetailMaster> SearchDetailMasters { get; set; }
        public DbSet<SearchDetailTransactions> SearchDetailTransactions { get; set; }
        public DbSet<SearchTransactionStatusLogs> SearchTransactionStatusLogs { get; set; }
        public DbSet<PageLogMaster> PageLogMasters { get; set; }
        public DbSet<PageActionLogMaster> PageActionLogMasters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
