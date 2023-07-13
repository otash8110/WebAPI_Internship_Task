using Core.Entities;

namespace Infrastructure.Entities
{
    public class AccountManagerModel: AccountManager
    {
        public IList<ProjectModel> Projects { get; set; }

    }
}
