using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {  
        public ProductWithTypesAndBrandsSpecification(){}
         public ProductWithTypesAndBrandsSpecification(int Id) : base(x=>x.Id==Id)
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);
        }
        public ProductWithTypesAndBrandsSpecification
        (ProductSpecParams productSpecParams):base
        (x=>
        (string.IsNullOrEmpty(productSpecParams.Search)||
        x.Name.ToLower().Contains(productSpecParams.Search))&&
         (!productSpecParams.BrandId.HasValue||x.ProductBrandId==productSpecParams.BrandId.Value)
         &&
         (!productSpecParams.TypeId.HasValue||x.ProductTypeId==productSpecParams.TypeId.Value)
         )
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);
    ApplyPaging
    (productSpecParams.PageSize * (productSpecParams.PageIndex-1),productSpecParams.PageSize);
            // AddOrderByDescending(x=>x.Price);
            // AddOrderBy(x=>x.Price);
           //The difference between String.IsNullOrEmpty and == null in C# is that String.IsNullOrEmpty checks both for null and empty strings, while == null only checks for null strings.
           if (!string.IsNullOrEmpty(productSpecParams.Sort))
           {
        switch (productSpecParams.Sort)
        {
            case "priceAsc":AddOrderBy(x=>x.Price);
            break;
            case "priceDesc":AddOrderByDescending(x=>x.Price);
            break;
            default: AddOrderBy(x=>x.Name);
            break;
        }
           }
        }    
    }
}