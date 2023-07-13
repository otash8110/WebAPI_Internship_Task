using API.DTO;
using API.Response;
using Core.Common;
using System.Threading.Tasks;

namespace API.IServices
{
    public interface IManagerService<TModel, TResponse, TObject>
        where TModel : BaseEntity
        where TResponse : class
        where TObject : class
    {
        public Task<TResponse> GetManagerAsync(int managerId);
        public Task<TResponse> AddManagerAsync(TObject managerObject);
        public Task DeleteManagerAsync(int managerId);
        public Task<TResponse> UpdateManagerAsync(TObject managerObject, int id);
    }
}
