namespace PortfolioService.Application.Interfaces
{
    public interface IExperienceRepository<T>
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAll();
    }
}
