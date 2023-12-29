using System.Linq.Expressions;

namespace core.Specifications
{
    public interface ISpecifications<T> 
    {
Expression<Func<T,bool>> Criteria{get;}
List<Expression<Func<T,object>>> Includes{get;}
    }
}