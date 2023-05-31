using System.ComponentModel.DataAnnotations;
using PortfolioService.Domain.Entities;

namespace PortfolioService.Api.Dtos.Request.Degrees
{
    public class UpdateRequest
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public Institution? Institution { get; set; }
        [Required]
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        [Required]
        public string? Id { get; set; }
    }
}
