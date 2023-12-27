using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _Repo;
        public ProductsController(IProductRepository repo)
        {
           _Repo = repo;
        }
       
        [HttpGet("products")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
           return Ok(await _Repo.GetProductsAsync());
        }
          [HttpGet("products/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
           return Ok(await _Repo.GetProductByIdAsync(id));
        }
         [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
           return Ok(await _Repo.GetProductBrandsAsync());
        }
          [HttpGet("brands/{id}")]
        public async Task<ActionResult<ProductBrand>> GetProductBrand(int id)
        {
           return Ok(await _Repo.GetProductBrandByIdAsync(id));
        }
         [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
           return Ok(await _Repo.GetProductTypesAsync());
        }
          [HttpGet("types/{id}")]
        public async Task<ActionResult<ProductType>> GetProductType(int id)
        {
           return Ok(await _Repo.GetProductTypeByIdAsync(id));
        }
    }
}