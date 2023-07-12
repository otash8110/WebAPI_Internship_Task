namespace Core.Common
{
    public class AuditableBaseEntity: BaseEntity
    {
        public DateTime LastModified { get; set; }
    }
}
