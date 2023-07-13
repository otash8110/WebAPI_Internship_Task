using API.ConcreteServices;
using API.DTO;
using API.IServices;
using API.Response;
using API.Services;
using Core.Entities;
using Infrastructure.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    public static class DependencyInjection
    {
        public static void AddAPIServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ManagerService<AccountManagerModel, ManagerResponse, ManagerObject>, ConcreteManagerService<AccountManagerModel, ManagerResponse, ManagerObject>>();
            services.AddScoped<ManagerService<SmmManagerModel, ManagerResponse, ManagerObject>, ConcreteManagerService<SmmManagerModel, ManagerResponse, ManagerObject>>();
        }
    }
}
