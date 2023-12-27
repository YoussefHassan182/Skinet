using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _Context ;
        public ProductRepository(StoreContext context)
        {
            _Context = context;
        }

        public async Task<ProductBrand> GetProductBrandByIdAsync(int Id)
        {
            return await _Context.ProductBrands.FindAsync(Id);
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _Context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int Id)
        {
            return await _Context.Products.FindAsync(Id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _Context.Products.ToListAsync();
        }

        public async Task<ProductType> GetProductTypeByIdAsync(int Id)
        {
            return await _Context.ProductTypes.FindAsync(Id);
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
                        return await _Context.ProductTypes.ToListAsync();

        }
    }
}