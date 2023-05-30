namespace PortfolioService.Application.Interfaces
{
    public interface IProjectRepository<T> : IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetByTypeAsync(string type);
    }
}
