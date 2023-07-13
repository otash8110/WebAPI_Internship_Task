using API.DTO;
using API.IServices;
using API.Response;
using Infrastructure.Entities;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Threading.Tasks;

namespace API.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IGenericRepository<ProjectModel> projectRepository;

        public ProjectService(IGenericRepository<ProjectModel> projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<ProjectResponse> AddProjectAsync(ProjectObject projectObject)
        {
            var project = MapProjectFromObject(projectObject);

            var projectResult = await projectRepository.AddAsync(project);

            return MapProjectFromModel(projectResult);
        }

        public async Task DeleteProjectAsync(int projectId)
        {
            var project = await projectRepository.GetOneAsync(projectId);
            await projectRepository.DeleteAsync(project);
        }

        public async Task<ProjectResponse> GetProjectAsync(int projectId)
        {
            var project = await projectRepository.GetOneAsync(projectId);

            return MapProjectFromModel(project);
        }

        public async Task<ProjectResponse> UpdateProjectAsync(ProjectUpdateObject projectObject)
        {
            var project = await projectRepository.GetOneAsync(projectObject.Id);
            project.ProjectName = projectObject.ProjectName;

            var updatedProject = await projectRepository.UpdateAsync(project);

            return MapProjectFromModel(updatedProject);
        }

        private ProjectModel MapProjectFromObject(ProjectObject projectObject)
        {
            return new ProjectModel
            {
                ProjectName = projectObject.ProjectName,
                CustomerId = projectObject.CustomerId,
                SmmManagerId = projectObject.SmmManagerId,
                AccountManagerId = projectObject.AccountManagerId,
            };
        }

        private ProjectResponse MapProjectFromModel(ProjectModel projectModel)
        {
            return new ProjectResponse
            {
                Id = projectModel.Id,
                ProjectName = projectModel.ProjectName,
                CustomerId = projectModel.CustomerId,
                AccountManagerId = projectModel.AccountManagerId,
                SmmManagerId = projectModel.SmmManagerId,
            };
        }
    }
}
