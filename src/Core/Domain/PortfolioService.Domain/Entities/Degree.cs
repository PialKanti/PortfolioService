namespace PortfolioService.Domain.Entities
{
    public class Degree : BaseEntity
    {
        public string Name { get; set; }
        public Institution Institution { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
    }
}
