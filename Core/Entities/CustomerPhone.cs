using Core.Common;

namespace Core.Entities
{
    public class CustomerPhone: AuditableBaseEntity
    {
        public string PhoneNumber { get; set; }
    }
}
