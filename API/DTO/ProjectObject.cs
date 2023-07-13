namespace API.DTO
{
    public class ProjectObject
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public int CustomerId { get; set; }
        public int AccountManagerId { get; set; }
        public int SmmManagerId { get; set; }
    }
}
