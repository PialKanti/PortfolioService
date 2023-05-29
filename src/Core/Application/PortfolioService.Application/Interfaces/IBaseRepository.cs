namespace PortfolioService.Application.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<T?> GetAsync(string id);
        Task<IEnumerable<T>> GetAsync();
    }
}
