using Core.Entities;

namespace Infrastructure.Entities
{
    public class ProjectModel : Project
    {
        public int SmmManagerId { get; set; }
        public SmmManagerModel SmmManager { get; set; }

        public int AccountManagerId { get; set; }
        public AccountManagerModel AccountManager { get; set; }

        public int CustomerId { get; set; }
        public CustomerModel Customer { get; set; }
    }
}
