using Microsoft.EntityFrameworkCore;
namespace EMSApi.Dbcontext
{
    public class Emscontext:DbContext
    {
        public Emscontext(DbContextOptions<Emscontext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Account> accounts { get; set; }

        public DbSet<Permissioncs> Permissioncs { get; set; }

        public DbSet<AccountApplication> accountApplications { get; set; }

        public DbSet<Position> positions { get; set; }

        public DbSet<Model> models { get; set; }

        public DbSet<ModelConfiguration> modelConfigurations { get; set; }

        public DbSet<TesterMachine> testerMachines { get; set; }

        public DbSet<TestItem> testItems { get; set; }

        public DbSet<TestEquipment> testEquipment { get; set; }

        public DbSet<TestProject> testProjects { get; set; }

        public DbSet<TestProjectMode> testProjectModes { get; set; }

        public DbSet<Setting> settings { get; set; }

        public DbSet<Functions> Functions { get; set; }

        public DbSet<Files> Files { get; set; }

        public DbSet<Departments> departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("AccountNumbers");

            modelBuilder.HasSequence<int>("PermissioncNumbers");

            modelBuilder.HasSequence<int>("AccountApplicationNumber");

            modelBuilder.HasSequence<int>("PositionNumber");

            modelBuilder.Entity<Account>().Property(propert => propert.Id).HasDefaultValueSql("NEXT VALUE FOR AccountNumbers");

            modelBuilder.Entity<Permissioncs>().Property(propert => propert.Id).HasDefaultValueSql("NEXT VALUE FOR PermissioncNumbers");

            modelBuilder.Entity<AccountApplication>().Property(propert => propert.ID).HasDefaultValueSql("NEXT VALUE FOR AccountApplicationNumber");

            modelBuilder.Entity<Position>().Property(propert => propert.Id).HasDefaultValueSql("NEXT VALUE FOR PositionNumber");
        }
    }

}
