using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortfolioService.Api.Dtos.Request;
using PortfolioService.Application.Interfaces;
using PortfolioService.Domain.Entities;

namespace PortfolioService.Api.Controllers
{
    public class ExperiencesController : BaseApiController
    {
        private readonly IExperienceRepository<Experience> _repository;
        private readonly IMapper _mapper;

        public ExperiencesController(IExperienceRepository<Experience> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ExperienceCreateRequest request)
        {
            var entity = _mapper.Map<Experience>(request);
            await _repository.CreateAsync(entity);
            return Ok();
        }
    }
}
