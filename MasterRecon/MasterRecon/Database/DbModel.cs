namespace MasterRecon.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
using MasterRecon.Model;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DbModel")
        {
        }

        public DbSet<RegistrationMaster> RegistrationMasters { get; set; }
        public DbSet<PageLogMaster> PageLogMasters { get; set; }
        public DbSet<PageActionLogMaster> PageActionLogMasters { get; set; }
        public DbSet<PageMaster> PageMasters { get; set; }
        public DbSet<RolePageMapping> RolePageMappings { get; set; }
        public DbSet<RoleMaster> RoleMasters { get; set; }
        public DbSet<UserMaster> UserMasters { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
