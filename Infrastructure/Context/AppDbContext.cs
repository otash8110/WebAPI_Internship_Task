
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
            modelBuilder.Entity<AccountManagerModel>()
                .HasMany(s => s.SmmManagers)
                .WithMany(a => a.AccountManagers)
                .UsingEntity(c =>
                {
                    c.ToTable("AccountSmmManager");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
