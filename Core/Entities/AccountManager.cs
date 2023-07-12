using Core.Common;

namespace Core.Entities
{
    public class AccountManager: AuditableBaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
