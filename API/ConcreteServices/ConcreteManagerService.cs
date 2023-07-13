using API.DTO;
using API.Response;
using API.Services;
using Core.Common;
using Infrastructure.Repository;

namespace API.ConcreteServices
{
    public class ConcreteManagerService<TModel, TResponse, TObject> : ManagerService<TModel, TResponse, TObject>
        where TModel : BaseEmployee, new()
        where TResponse : ManagerResponse, new()
        where TObject : ManagerObject, new()
    {

        public ConcreteManagerService(IGenericRepository<TModel> accountManagerRepository) : base(accountManagerRepository)
        {

        }

        protected override TResponse MapAccountManagerFromModel(TModel model)
        {
            return new TResponse
            {
                Id = model.Id,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
            };
        }

        protected override TModel MapManagerFromObject(TObject managerObject)
        {
            return new TModel
            {
                Id = managerObject.Id,
                Name = managerObject.Name,
                PhoneNumber = managerObject.PhoneNumber,
            };
        }

        protected override TModel UpdateModel(TModel oldModel, TObject newModel)
        {
            oldModel.Name = newModel.Name;
            oldModel.PhoneNumber = newModel.PhoneNumber;

            return oldModel;
        }
    }
}
