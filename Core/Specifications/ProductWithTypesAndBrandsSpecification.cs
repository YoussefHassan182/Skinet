using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpecification()
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);
        }

        public ProductWithTypesAndBrandsSpecification(int Id) : base(x=>x.Id==Id)
        {
              AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);
        }
    }
}