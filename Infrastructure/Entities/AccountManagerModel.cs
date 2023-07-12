using Core.Entities;

namespace Infrastructure.Entities
{
    public class AccountManagerModel: AccountManager
    {
        public AccountManagerModel()
        {
            SmmManagers = new HashSet<SmmManagerModel>();
        }

        public virtual ICollection<SmmManagerModel> SmmManagers { get; set; }
    }
}
