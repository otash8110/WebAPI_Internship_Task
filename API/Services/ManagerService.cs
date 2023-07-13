using API.IServices;
using Core.Common;
using Infrastructure.Repository;
using System.Threading.Tasks;

namespace API.Services
{
    public abstract class ManagerService<TModel, TResponse, TObject> : IManagerService<TModel, TResponse, TObject>
        where TModel : BaseEmployee
        where TResponse : class
        where TObject : class
    {
        private readonly IGenericRepository<TModel> managerRepository;

        public ManagerService(IGenericRepository<TModel> managerRepository)
        {
            this.managerRepository = managerRepository;
        }

        public async Task<TResponse> AddManagerAsync(TObject managerObject)
        {
            var accountManager = MapManagerFromObject(managerObject);

            var managerResult = await managerRepository.AddAsync(accountManager);

            return MapAccountManagerFromModel(managerResult);
        }

        public async Task DeleteManagerAsync(int managerId)
        {
            await managerRepository.Delete(managerId);
        }

        public async Task<TResponse> GetManagerAsync(int managerId)
        {
            var manager = await managerRepository.GetOne(managerId);

            return MapAccountManagerFromModel(manager);
        }

        public async Task<TResponse> UpdateManagerAsync(TObject managerObject, int id)
        {
            var manager = await managerRepository.GetOne(id);
            var updatedManagerModel = UpdateModel(manager, managerObject);

            var updatedManager = await managerRepository.Update(updatedManagerModel);

            return MapAccountManagerFromModel(updatedManager);
        }

        protected abstract TResponse MapAccountManagerFromModel(TModel model);

        protected abstract TModel MapManagerFromObject(TObject managerObject);

        protected abstract TModel UpdateModel(TModel oldModel, TObject newModel);
    }
}
