using API.DTO;
using API.IServices;
using API.Response;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet("{id}")]
        public async Task<ProjectResponse> Get(int id)
        {
            try
            {
                var result = await projectService.GetProjectAsync(id);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<ProjectResponse> Post([FromBody] ProjectObject value)
        {
            try
            {
                var result = await projectService.AddProjectAsync(value);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut()]
        public async Task<ProjectResponse> Put([FromBody] ProjectUpdateObject value)
        {
            try
            {
                var result = await projectService.UpdateProjectAsync(value);

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
                await projectService.DeleteProjectAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
