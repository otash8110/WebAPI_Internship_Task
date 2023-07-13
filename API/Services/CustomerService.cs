using API.DTO;
using API.IServices;
using API.Response;
using Infrastructure.Entities;
using Infrastructure.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<CustomerModel> customerRepository;

        public CustomerService(IGenericRepository<CustomerModel> customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<CustomerResponse> AddCustomer(CustomerObject customerObject)
        {
            var customer = new CustomerModel
            {
                Name = customerObject.Name,
                Surname = customerObject.Surname
            };
            var phoneNumber = new CustomerPhoneModel
            {
                PhoneNumber = customerObject.PhoneNumber
            };

            customer.CustomerPhones = new List<CustomerPhoneModel> { phoneNumber };
            var customerResult = await customerRepository.AddAsync(customer);

            return MapCustomerFromModel(customerResult);
        }

        public async Task DeleteCustomer(int customerId)
        {
            await customerRepository.Delete(customerId);
        }

        public async Task<CustomerResponse> GetCustomer(int customerId)
        {
            var customer = await customerRepository.Get();
            var result = customer.Select(MapCustomerFromModel).Where(c => c.Id == customerId).FirstOrDefault();

            return result;
        }

        public async Task<CustomerResponse> UpdateCustomer(CustomerObject customerObject)
        {
            var customer = await customerRepository.GetOne(customerObject.Id);
            customer.Name = customerObject.Name;
            customer.Surname = customerObject.Surname;
            customer.CustomerPhones.FirstOrDefault().PhoneNumber = customerObject.PhoneNumber;

            var updatedCustomer = await customerRepository.Update(customer);

            return MapCustomerFromModel(updatedCustomer);
        }

        private CustomerResponse MapCustomerFromModel(CustomerModel model)
        {
            var result = new CustomerResponse
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                PhoneNumbers = model.CustomerPhones.Select(p => new CustomerPhoneResponse
                {
                    Id = p.Id,
                    PhoneNumber = p.PhoneNumber,
                })
            };

            if (model.AccountManager != null)
            {
                result.AccountManager = new ManagerResponse
                {
                    Id = model.AccountManager.Id,
                    Name = model.AccountManager.Name,
                    PhoneNumber = model.AccountManager.PhoneNumber
                };
            }

            return result;
        }
    }
}
