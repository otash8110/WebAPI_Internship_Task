using Core.Entities;

namespace Infrastructure.Entities
{
    public class SmmManagerModel : SmmManager
    {
        public SmmManagerModel() 
        { 
            AccountManagers = new HashSet<AccountManagerModel>();
        }

        public virtual ICollection<AccountManagerModel> AccountManagers { get; set; }
    }
}
