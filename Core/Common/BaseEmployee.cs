namespace Core.Common
{
    public abstract class BaseEmployee: AuditableBaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
