using API.DTO;
using API.Response;
using System.Threading.Tasks;

namespace API.IServices
{
    public interface IProjectService
    {
        public Task<ProjectResponse> GetProjectAsync(int projectId);
        public Task<ProjectResponse> AddProjectAsync(ProjectObject projectObject);
        public Task DeleteProjectAsync(int projectId);
        public Task<ProjectResponse> UpdateProjectAsync(ProjectUpdateObject projectObject);
    }
}
