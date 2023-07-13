using Core.Entities;

namespace Infrastructure.Entities
{
    public class CustomerModel : Customer
    {
        public int? AccountManagerId { get; set; }
        public AccountManagerModel AccountManager { get; set; }
        public ICollection<CustomerPhoneModel> CustomerPhones { get; set; }
    }
}
