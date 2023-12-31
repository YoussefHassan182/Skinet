using System.Linq.Expressions;
using core.Specifications;
namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecifications<T>
    {   
          public BaseSpecification(){}
          public BaseSpecification(Expression<Func<T, bool>> criteria)
          {
            Criteria = criteria;
          }
        public Expression<Func<T, bool>> Criteria {get;} 
        public Expression<Func<T, object>> OrderBy {get;private set;}
        public Expression<Func<T, object>> OrderByDescending {get;private set;}
        public List<Expression<Func<T, object>>> Includes {get;} = new();
        public int Take {get;private set;}
        public int Skip {get;private set;}
        public bool IsPaginEnabled {get;private set;}
protected void AddInclude(Expression<Func<T,object>>IncludeExpression)
{
    Includes.Add(IncludeExpression);
}
protected void AddOrderBy(Expression<Func<T,object>>OrderByExpression)
{
OrderBy = OrderByExpression;
}
protected void AddOrderByDescending(Expression<Func<T,object>>OrderByDescendingExpression)
{
OrderByDescending = OrderByDescendingExpression;
}
protected void ApplyPaging(int skip,int take)
{
Skip=skip;
 Take= take;
IsPaginEnabled = true;
}
}
}