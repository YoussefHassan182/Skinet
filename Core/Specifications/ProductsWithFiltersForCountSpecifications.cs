using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithFiltersForCountSpecifications:BaseSpecification<Product>
    {
        public ProductsWithFiltersForCountSpecifications(ProductSpecParams productSpecParams)
        :base
        (x=>
        (string.IsNullOrEmpty(productSpecParams.Search)||
        x.Name.ToLower().Contains(productSpecParams.Search))&&
         (!productSpecParams.BrandId.HasValue||x.ProductBrandId==productSpecParams.BrandId.Value)
         &&
         (!productSpecParams.TypeId.HasValue||x.ProductTypeId==productSpecParams.TypeId.Value)
         )
        {
        }
    }
}