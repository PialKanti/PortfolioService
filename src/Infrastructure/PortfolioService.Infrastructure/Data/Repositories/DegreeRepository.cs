using AutoMapper;
using MongoDB.Driver;
using PortfolioService.Application.Interfaces;
using PortfolioService.Domain.Entities;
using PortfolioService.Infrastructure.Data.Dtos;

namespace PortfolioService.Infrastructure.Data.Repositories
{
    public class DegreeRepository : IDegreeRepository<Degree>
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<DegreeDto> _collection;

        public DegreeRepository(MongoClientService dbClientService, IMapper mapper)
        {
            _mapper = mapper;
            _collection = dbClientService.GetCollection<DegreeDto>("degrees");
        }

        public async Task<Degree> CreateAsync(Degree entity)
        {
            var dtoModel = _mapper.Map<DegreeDto>(entity);
            await _collection.InsertOneAsync(dtoModel);
            return entity;
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(dtoModel => string.Equals(dtoModel.Id, id));
        }

        public async Task<Degree?> GetAsync(string id)
        {
            var degreeDto = await _collection.Find(dtoModel => dtoModel.Id == id).FirstOrDefaultAsync();
            return degreeDto == null ? null : _mapper.Map<Degree>(degreeDto);
        }

        public async Task<IEnumerable<Degree>> GetAsync()
        {
            var filteredList = await _collection.Find(dtoModel => true)
                .SortByDescending(dtoModel => dtoModel.StartDateTime).ToListAsync();
            return filteredList.Select(dtoModel => _mapper.Map<Degree>(dtoModel));
        }

        public async Task<Degree> UpdateAsync(string id, Degree entity)
        {
            var dtoModel = _mapper.Map<DegreeDto>(entity);
            await _collection.ReplaceOneAsync(degreeDto => string.Equals(degreeDto.Id, id), dtoModel);
            return entity;
        }
    }
}
