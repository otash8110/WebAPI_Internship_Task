using API.DTO;
using API.IServices;
using API.Response;
using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService) {
            this.customerService = customerService;
        }

        [HttpGet("{id}")]
        public async Task<CustomerResponse> Get(int id)
        {
            try
            {
                var result = await customerService.GetCustomer(id);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<CustomerResponse> Post([FromBody] CustomerObject value)
        {
            try
            {
                var result = await customerService.AddCustomer(value);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut()]
        public async Task<CustomerResponse> Put([FromBody] CustomerUpdateObject value)
        {
            try
            {
                var result = await customerService.UpdateCustomer(value);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            try
            {
                await customerService.DeleteCustomer(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
