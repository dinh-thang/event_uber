using System.Linq.Expressions;
using EventUber.Application.Abstractions.Specifications;

namespace EventUber.Application.Specifications
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
    public Expression<Func<T, bool>>? Criteria { get; protected set; }

    public List<Expression<Func<T, object>>> Includes { get; }
        = new List<Expression<Func<T, object>>>();

    public List<string> IncludeStrings { get; }
        = new List<string>();

    public Expression<Func<T, object>>? OrderBy { get; private set; }
    public Expression<Func<T, object>>? OrderByDescending { get; private set; }

    public int? Take { get; private set; }
    public int? Skip { get; private set; }
    public bool IsPagingEnabled { get; private set; }

    // Add WHERE
    protected void AddCriteria(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    // Add Include
    protected void AddInclude(Expression<Func<T, object>> include)
    {
        Includes.Add(include);
    }

    // Add string include
    protected void AddInclude(string includeString)
    {
        IncludeStrings.Add(includeString);
    }

    // Add ordering
    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
    {
        OrderByDescending = orderByDescExpression;
    }

    // Pagination
    protected void ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
        IsPagingEnabled = true;
    }
    }
}