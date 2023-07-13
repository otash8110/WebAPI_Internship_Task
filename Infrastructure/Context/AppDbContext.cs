using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<AccountManagerModel> AccountManagers { get; set; }
        public DbSet<SmmManagerModel > SmmManagers { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<CustomerPhoneModel> CustomerPhones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectModel>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<ProjectModel>()
                .HasKey(k => new { k.CustomerId, k.AccountManagerId, k.SmmManagerId, k.Id });

            modelBuilder.Entity<CustomerModel>().Navigation(c => c.CustomerPhones).AutoInclude(true);
            modelBuilder.Entity<CustomerModel>().Navigation(c => c.AccountManager).AutoInclude(true);

            modelBuilder.Entity<CustomerPhoneModel>().Navigation(p => p.Customer).AutoInclude(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
