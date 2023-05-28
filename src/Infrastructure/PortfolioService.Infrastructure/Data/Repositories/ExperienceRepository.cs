using MongoDB.Bson;
using PortfolioService.Application.Interfaces;
using PortfolioService.Domain.Entities;

namespace PortfolioService.Infrastructure.Data.Repositories
{
    public class ExperienceRepository : IExperienceRepository<Experience>
    {
        private readonly MongoClientService _dbClientService;

        public ExperienceRepository(MongoClientService dbClientService)
        {
            _dbClientService = dbClientService;
        }

        public async Task<Experience> CreateAsync(Experience entity)
        {
            var collection = _dbClientService.GetCollection<BsonDocument>("experiences");
            await collection.InsertOneAsync(entity.ToBsonDocument());
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
