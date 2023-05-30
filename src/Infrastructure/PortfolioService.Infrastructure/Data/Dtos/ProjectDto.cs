using PortfolioService.Domain.Entities;

namespace PortfolioService.Infrastructure.Data.Dtos
{
    public class ProjectDto : BaseDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public ProjectLink ProjectLink { get; set; }
        public IEnumerable<string> DescriptionList { get; set; }
        public IEnumerable<string> Technologies { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
