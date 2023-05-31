namespace PortfolioService.Domain.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Type{ get; set; }
        public ProjectLink ProjectLink { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Technologies { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
    }
}
