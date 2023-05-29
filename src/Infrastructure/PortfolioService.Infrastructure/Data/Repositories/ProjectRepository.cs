using PortfolioService.Application.Interfaces;
using PortfolioService.Domain.Entities;

namespace PortfolioService.Infrastructure.Data.Repositories
{
    public class ProjectRepository: IProjectRepository<Project>
    {
        public Task<Project> CreateAsync(Project entity)
        {
            throw new NotImplementedException();
        }

        public Task<Project> UpdateAsync(Project entity)
        {
            throw new NotImplementedException();
        }

        public Task<Project> DeleteAsync(Project entity)
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
