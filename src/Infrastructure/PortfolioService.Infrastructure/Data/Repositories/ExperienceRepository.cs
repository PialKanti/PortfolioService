﻿using AutoMapper;
using MongoDB.Driver;
using PortfolioService.Application.Interfaces;
using PortfolioService.Domain.Entities;
using PortfolioService.Infrastructure.Data.Dtos;

namespace PortfolioService.Infrastructure.Data.Repositories
{
    public class ExperienceRepository : IExperienceRepository<Experience>
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ExperienceDto> _collection;

        public ExperienceRepository(MongoClientService dbClientService, IMapper mapper)
        {
            _mapper = mapper;
            _collection = dbClientService.GetCollection<ExperienceDto>("experiences");
        }

        public async Task<Experience> CreateAsync(Experience entity)
        {
            var dtoModel = _mapper.Map<ExperienceDto>(entity);
            await _collection.InsertOneAsync(dtoModel);
            return entity;
        }

        public async Task<Experience> UpdateAsync(string id, Experience entity)
        {
            var dtoModel = _mapper.Map<ExperienceDto>(entity);
            await _collection.ReplaceOneAsync(experience => string.Equals(experience.Id, id), dtoModel);
            return entity;
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(experience => string.Equals(experience.Id, id));
        }

        public async Task<Experience?> GetAsync(string id)
        {
            var experienceDto = await _collection.Find(dtoModel => dtoModel.Id == id).FirstOrDefaultAsync();
            return experienceDto == null ? null : _mapper.Map<Experience>(experienceDto);
        }

        public async Task<IEnumerable<Experience>> GetAsync()
        {
            var filteredList = await _collection.Find(dtoModel => true).SortByDescending(dtoModel => dtoModel.StartDateTime).ToListAsync();
            return filteredList.Select(dtoModel => _mapper.Map<Experience>(dtoModel));
        }
    }
}
