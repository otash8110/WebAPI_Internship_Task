using Core.Entities;

namespace Infrastructure.Entities
{
    public class CustomerModel : Customer
    {
        public AccountManagerModel AccountManager { get; set; }
    }
}
