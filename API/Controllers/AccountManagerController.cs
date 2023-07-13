using API.DTO;
using API.Response;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Infrastructure.Entities;
using API.IServices;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountManagerController : Controller
    {

        private readonly ManagerService<AccountManagerModel, AccountManagerResponse, AccountManagerObject> accountManagerService;

        public AccountManagerController(ManagerService<AccountManagerModel, AccountManagerResponse, AccountManagerObject> accountManagerService)
        {
            this.accountManagerService = accountManagerService;
        }


        [HttpGet("{id}")]
        public async Task<AccountManagerResponse> Get(int id)
        {
            try
            {
                var result = await accountManagerService.GetManagerAsync(id);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<AccountManagerResponse> Post([FromBody] AccountManagerObject value)
        {
            try
            {
                var result = await accountManagerService.AddManagerAsync(value);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut()]
        public async Task<AccountManagerResponse> Put([FromBody] AccountManagerObject value)
        {
            try
            {
                var result = await accountManagerService.UpdateManagerAsync(value, value.Id);

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
                await accountManagerService.DeleteManagerAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
