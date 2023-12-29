using System.Net;
using API.DTOs;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
  
    public class ProductsController : BaseAPIController
    {
        private readonly IGenericRepository<Product> _Repo;
        private readonly IMapper _Mapper;

        // private readonly IGenericRepository<ProductBrand> _BRepo;
        // private readonly IGenericRepository<ProductType> _TRepo;

        public ProductsController(IGenericRepository<Product> repo,IMapper mapper)
        {
           _Repo = repo;
           _Mapper= mapper;
        }
       
        [HttpGet("products")]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
         var spec = new ProductWithTypesAndBrandsSpecification();
var products = await _Repo.ListAsync(spec);
         if (products ==null) return NotFound(new APIResponse(404));

           return Ok(_Mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(products));
        }
          [HttpGet("products/{id}")]
          //A filter that specifies the type of the value and status code returned by the action.
          [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
          [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
         var spec = new ProductWithTypesAndBrandsSpecification(id);
         var product =await _Repo.GetEntityWithSpec(spec);
         if (product ==null) return NotFound(new APIResponse(404));
           return Ok(_Mapper.Map<Product,ProductToReturnDto>(product));
        }
      //    [HttpGet("brands")]
      //   public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
      //   {
      //      return Ok(await _BRepo.GetProductBrandsAsync());
      //   }
      //     [HttpGet("brands/{id}")]
      //   public async Task<ActionResult<ProductBrand>> GetProductBrand(int id)
      //   {
      //      return Ok(await _Repo.GetProductBrandByIdAsync(id));
      //   }
      //    [HttpGet("types")]
      //   public async Task<ActionResult<List<ProductType>>> GetProductTypes()
      //   {
      //      return Ok(await _Repo.GetProductTypesAsync());
      //   }
      //     [HttpGet("types/{id}")]
      //   public async Task<ActionResult<ProductType>> GetProductType(int id)
      //   {
      //      return Ok(await _Repo.GetProductTypeByIdAsync(id));
      //   }
    }
}