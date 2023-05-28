using PortfolioService.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace PortfolioService.Api.Dtos.Request
{
    public class ExperienceCreateRequest
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? EmploymentType { get; set; }
        [Required]
        public Company? Company { get; set; }
        [Required]
        public IEnumerable<string>? Responsibilities { get; set; }
        [Required]
        public IEnumerable<string>? Skills { get; set; }
        [Required]
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
