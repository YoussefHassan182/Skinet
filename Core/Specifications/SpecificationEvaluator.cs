using core.Specifications;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data
{
public class SpecificationEvaluator<TEntity> where TEntity :class
{
public static IQueryable<TEntity> GetQuery
(IQueryable<TEntity>InputQuey,ISpecifications<TEntity>Spec)
{
var Query = InputQuey;
if (Spec.Criteria!=null)
{
    Query = Query.Where(Spec.Criteria);
}
if (Spec.OrderBy!=null)
{
    Query = Query.OrderBy(Spec.OrderBy);
}
if (Spec.OrderByDescending!=null)
{
    Query = Query.OrderByDescending(Spec.OrderByDescending);
}
if (Spec.IsPaginEnabled)
{
    Query = Query.Skip(Spec.Skip).Take(Spec.Take);
}
Query = Spec.Includes.Aggregate(Query,(current,include) => current.Include(include));
return Query;     
}
}
}