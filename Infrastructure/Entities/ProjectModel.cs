using Core.Entities;

namespace Infrastructure.Entities
{
    public class ProjectModel : Project
    {
        public int? CustomerId { get; set; }
        public CustomerModel CustomerModel { get; set; }

        public int? SmmManagerId { get; set; }
        public SmmManagerModel SmmManager { get; set; }
    }
}
