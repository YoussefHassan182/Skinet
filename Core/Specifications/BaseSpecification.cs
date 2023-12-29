using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using core.Specifications;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecifications<T>
    {
        public Expression<Func<T, bool>> Criteria {get;}
        public List<Expression<Func<T, object>>> Includes {get;} = new();

        public BaseSpecification
        (Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public BaseSpecification()
        {
        }

        protected void AddInclude(Expression<Func<T,object>>IncludeExpression)
{
    Includes.Add(IncludeExpression);
}

       
    }
}