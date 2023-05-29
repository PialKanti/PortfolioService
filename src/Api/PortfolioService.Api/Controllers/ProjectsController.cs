using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortfolioService.Api.Dtos.Request.Projects;
using PortfolioService.Application.Interfaces;
using PortfolioService.Domain.Entities;

namespace PortfolioService.Api.Controllers
{
    public class ProjectsController : BaseApiController
    {
        private readonly IProjectRepository<Project> _repository;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectRepository<Project> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateRequest request)
        {
            var entity = _mapper.Map<Project>(request);
            await _repository.CreateAsync(entity);
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] UpdateRequest request)
        {
            if (!string.Equals(id, request.Id))
            {
                return BadRequest();
            }

            var entity = _mapper.Map<Project>(request);
            await _repository.UpdateAsync(id, entity);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var entities = await _repository.GetAsync();
            return Ok(entities);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
