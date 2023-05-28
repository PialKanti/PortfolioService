namespace PortfolioService.Domain.Entities
{
    public class Experience
    {
        public string Title { get; set; }
        public string EmploymentType { get; set; }
        public Company Company { get; set; }
        public IEnumerable<string> Responsibilities { get; set; }
        public IEnumerable<string> Skills { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
