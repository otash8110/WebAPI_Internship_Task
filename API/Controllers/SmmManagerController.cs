using API.DTO;
using API.Response;
using API.Services;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmmManagerController : Controller
    {

        private readonly ManagerService<SmmManagerModel, ManagerResponse, ManagerObject> accountManagerService;

        public SmmManagerController(ManagerService<SmmManagerModel, ManagerResponse, ManagerObject> accountManagerService)
        {
            this.accountManagerService = accountManagerService;
        }

        [HttpGet("{id}")]
        public async Task<ManagerResponse> Get(int id)
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
        public async Task<ManagerResponse> Post([FromBody] ManagerObject value)
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
        public async Task<ManagerResponse> Put([FromBody] ManagerObject value)
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
