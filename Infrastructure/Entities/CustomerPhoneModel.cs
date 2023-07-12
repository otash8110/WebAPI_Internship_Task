using Core.Entities;

namespace Infrastructure.Entities
{
    public class CustomerPhoneModel : CustomerPhone
    {
        public int? CustomerId { get; set; }
        public CustomerModel Customer { get; set; }
    }
}
