

using core.Specifications;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {     
       private readonly StoreContext _StoreContext ;

        public GenericRepository(StoreContext storeContext)
        {
            _StoreContext = storeContext;
        }


        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _StoreContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {            
            return await _StoreContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityWithSpec(ISpecifications<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecifications<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
        private IQueryable<T> ApplySpecification(ISpecifications<T>spec)
        {
return SpecificationEvaluator<T>.GetQuery(_StoreContext.Set<T>().AsQueryable(),spec);
        }
    }
}