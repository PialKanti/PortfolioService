namespace PortfolioService.Application.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(string id,T entity);
        Task DeleteAsync(string id);
        Task<T?> GetAsync(string id);
        Task<IEnumerable<T>> GetAsync();
    }
}
