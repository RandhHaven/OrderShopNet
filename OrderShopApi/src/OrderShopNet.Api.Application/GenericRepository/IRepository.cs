namespace OrderShopNet.Api.Application.GenericRepository;

using System.Linq.Expressions;

internal interface IRepository<T>
{
    Task<T?> Get(Guid id);

    Task<IEnumerable<T>> GetAll(
        Expression<Func<T, bool>>? filter,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
        String includeProperties);

    Task<T?> GetFirstOrDefault(
        Expression<Func<T, bool>> filter,
        String includeProperties);

    Task<T> Add(T entity);

    Task<T?> Remove(Guid id);

    void Remove(T entity);
}
