namespace PortfolioService.Infrastructure.Data.Dtos
{
    public class ProjectDto : BaseDto
    {
        public string Name { get; set; }
        public string ProjectUrl { get; set; }
        public IEnumerable<string> DescriptionList { get; set; }
        public IEnumerable<string> Skills { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
