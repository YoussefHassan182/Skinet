using core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T :class 
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
Task<T> GetEntityWithSpec(ISpecifications<T>spec);
Task<IReadOnlyList<T>>ListAsync(ISpecifications<T>spec);
    }
}