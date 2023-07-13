using API.DTO;
using API.Response;
using System.Threading.Tasks;

namespace API.IServices
{
    public interface ICustomerService
    {
        public Task<CustomerResponse> GetCustomer(int customerId);
        public Task<CustomerResponse> AddCustomer(CustomerObject customerObject);
        public Task DeleteCustomer(int customerId);
        public Task<CustomerResponse> UpdateCustomer(CustomerUpdateObject customerObject);
    }
}
