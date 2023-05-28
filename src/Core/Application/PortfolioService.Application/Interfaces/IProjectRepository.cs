namespace PortfolioService.Application.Interfaces
{
    public interface IProjectRepository<T>
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
