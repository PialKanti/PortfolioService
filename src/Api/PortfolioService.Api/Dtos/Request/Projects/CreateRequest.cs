using PortfolioService.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace PortfolioService.Api.Dtos.Request.Projects
{
    public class CreateRequest
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Type { get; set; }
        [Required]
        public ProjectLink? ProjectLink { get; set; }
        [Required]
        public IEnumerable<string>? DescriptionList { get; set; }
        [Required]
        public IEnumerable<string>? Technologies { get; set; }
        [Required]
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
    }
}
