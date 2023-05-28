using Microsoft.AspNetCore.Mvc;
using PortfolioService.Api.Dtos.Request;
using PortfolioService.Infrastructure.Data.Repositories;

namespace PortfolioService.Api.Controllers
{
    public class ExperiencesController : BaseApiController
    {
        private readonly ExperienceRepository _repository;

        public ExperiencesController(ExperienceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Create([FromBody] ExperienceCreateRequest request)
        {
            return Ok();
        }
    }
}
