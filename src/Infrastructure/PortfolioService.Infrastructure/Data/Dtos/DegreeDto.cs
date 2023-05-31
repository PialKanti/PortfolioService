using PortfolioService.Domain.Entities;

namespace PortfolioService.Infrastructure.Data.Dtos
{
    public class DegreeDto : BaseDto
    {
        public string Name { get; set; }
        public Institution Institution { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
    }
}
