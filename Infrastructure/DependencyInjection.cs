using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInftrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"), 
                    builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
            });

            services.AddScoped<IGenericRepository<CustomerModel>, GenericRepository<CustomerModel>>();
            services.AddScoped<IGenericRepository<CustomerPhoneModel>, GenericRepository<CustomerPhoneModel>>();
            services.AddScoped<IGenericRepository<AccountManagerModel>, GenericRepository<AccountManagerModel>>();
            services.AddScoped<IGenericRepository<SmmManagerModel>, GenericRepository<SmmManagerModel>>();
            services.AddScoped<IGenericRepository<ProjectModel>, GenericRepository<ProjectModel>>();
        }
    }
}
