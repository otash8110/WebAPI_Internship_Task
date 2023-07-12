using Core.Common;

namespace Core.Entities
{
    public class Customer: AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
