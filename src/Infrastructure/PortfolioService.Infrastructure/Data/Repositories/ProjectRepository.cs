using AutoMapper;
using MongoDB.Driver;
using PortfolioService.Application.Interfaces;
using PortfolioService.Domain.Entities;
using PortfolioService.Infrastructure.Data.Dtos;

namespace PortfolioService.Infrastructure.Data.Repositories
{
    public class ProjectRepository: IProjectRepository<Project>
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProjectDto> _collection;

        public ProjectRepository(MongoClientService dbClientService, IMapper mapper)
        {
            _mapper = mapper;
            _collection = dbClientService.GetCollection<ProjectDto>("projects");
        }

        public async Task<Project> CreateAsync(Project entity)
        {
            var dtoModel = _mapper.Map<ProjectDto>(entity);
            await _collection.InsertOneAsync(dtoModel);
            return entity;
        }

        public async Task<Project> UpdateAsync(string id, Project entity)
        {
            var dtoModel = _mapper.Map<ProjectDto>(entity);
            await _collection.ReplaceOneAsync(project => string.Equals(project.Id, id), dtoModel);
            return entity;
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(project => string.Equals(project.Id, id));
        }

        public async Task<Project?> GetAsync(string id)
        {
            var projectDto = await _collection.Find(dtoModel => dtoModel.Id == id).FirstOrDefaultAsync();
            return projectDto == null ? null : _mapper.Map<Project>(projectDto);
        }

        public async Task<IEnumerable<Project>> GetAsync()
        {
            var filteredList = await _collection.Find(dtoModel => true).ToListAsync();
            return filteredList.Select(dtoModel => _mapper.Map<Project>(dtoModel));
        }

        public async Task<IEnumerable<Project>> GetByTypeAsync(string type)
        {
            var filteredList = await _collection.Find(dtoModel => string.Equals(dtoModel.Type, type)).ToListAsync();
            return filteredList.Select(dtoModel => _mapper.Map<Project>(dtoModel));
        }
    }
}
