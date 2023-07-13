using API.DTO;
using API.Response;
using API.Services;
using Core.Common;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.ConcreteServices
{
    public class AccountManagerService<TModel, TResponse, TObject> : ManagerService<TModel, TResponse, TObject>
        where TModel : BaseEmployee, new()
        where TResponse : AccountManagerResponse, new()
        where TObject : AccountManagerObject, new()
    {

        public AccountManagerService(IGenericRepository<TModel> accountManagerRepository) : base(accountManagerRepository)
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
