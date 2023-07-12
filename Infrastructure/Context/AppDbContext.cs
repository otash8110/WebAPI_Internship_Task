
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base()
        {

        }

        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<AccountManagerModel> AccountManagers { get; set; }
    }
}
