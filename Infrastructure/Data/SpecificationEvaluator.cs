using System.Linq.Expressions;
using core.Specifications;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity :class
    {
        public static IQueryable<TEntity> GetQuery
        (
            IQueryable<TEntity>InputQuey,
        ISpecifications<TEntity>Spec
        )
        {
var Query = InputQuey;
if (Spec.Criteria!=null)
{
    Query = Query.Where(Spec.Criteria);
}

Query = Spec.Includes.Aggregate(Query,(current,include) => current.Include(include));
return Query;     
}
    }
}