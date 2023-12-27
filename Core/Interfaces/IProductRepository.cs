using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int Id);
        Task<IReadOnlyList<Product>> GetProductsAsync();

  Task<ProductBrand> GetProductBrandByIdAsync(int Id);
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
  Task<ProductType> GetProductTypeByIdAsync(int Id);
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();

    }
}