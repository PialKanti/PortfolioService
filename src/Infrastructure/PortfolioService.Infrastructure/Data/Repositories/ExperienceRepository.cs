using AutoMapper;
using MongoDB.Driver;
using PortfolioService.Application.Interfaces;
using PortfolioService.Domain.Entities;
using PortfolioService.Infrastructure.Data.Dtos;

namespace PortfolioService.Infrastructure.Data.Repositories
{
    public class ExperienceRepository : IExperienceRepository<Experience>
    {
        private readonly MongoClientService _dbClientService;
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ExperienceDto> _collection;

        public ExperienceRepository(MongoClientService dbClientService, IMapper mapper)
        {
            _dbClientService = dbClientService;
            _mapper = mapper;
            _collection = _dbClientService.GetCollection<ExperienceDto>("experiences");
        }

        public async Task<Experience> CreateAsync(Experience entity)
        {
            var dtoModel = _mapper.Map<ExperienceDto>(entity);
            await _collection.InsertOneAsync(dtoModel);
            return entity;
        }

        public Task<Experience> UpdateAsync(Experience entity)
        {
            throw new NotImplementedException();
        }

        public Task<Experience> DeleteAsync(Experience entity)
        {
            throw new NotImplementedException();
        }

        public Task<Experience> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Experience>> GetAsync()
        {
            var filteredList = await _collection.Find(_=> true).ToListAsync();

            return filteredList.Select(dtoModel => _mapper.Map<Experience>(dtoModel));
        }
    }
}
