using AutoMapper;
using MongoDB.Bson;
using PortfolioService.Application.Interfaces;
using PortfolioService.Domain.Entities;
using PortfolioService.Infrastructure.Data.Dtos;

namespace PortfolioService.Infrastructure.Data.Repositories
{
    public class ExperienceRepository : IExperienceRepository<Experience>
    {
        private readonly MongoClientService _dbClientService;
        private readonly IMapper _mapper;

        public ExperienceRepository(MongoClientService dbClientService, IMapper mapper)
        {
            _dbClientService = dbClientService;
            _mapper = mapper;
        }

        public async Task<Experience> CreateAsync(Experience entity)
        {
            var collection = _dbClientService.GetCollection<BsonDocument>("experiences");
            var dtoModel = _mapper.Map<ExperienceDto>(entity);
            var document = dtoModel.ToBsonDocument();
            await collection.InsertOneAsync(document);
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

        public Task<IEnumerable<Experience>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
