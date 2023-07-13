using Core.Entities;

namespace Infrastructure.Entities
{
    public class SmmManagerModel : SmmManager
    {
        public ICollection<ProjectModel> Projects { get; set; }
    }
}
