using System.ComponentModel.DataAnnotations;

namespace PortfolioService.Api.Dtos.Request.Projects
{
    public class UpdateRequest
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? ProjectUrl { get; set; }
        [Required]
        public IEnumerable<string>? DescriptionList { get; set; }
        [Required]
        public IEnumerable<string>? Skills { get; set; }
        [Required]
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
