namespace OrderShopNet.Api.Core.GenericUnitOfWork;

using OrderShopNet.Api.Core.GenericRepository;
using OrderShopNet.Api.Infrastructure.Persistence;

internal class UnitOfWork : IUnitOfWork
{
    private readonly OrderShopContext _databaseContext;

    public UnitOfWork(OrderShopContext databaseContext)
    {
        this._databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
    }

    public void Dispose()
    {
        this._databaseContext.Dispose();
    }

    public void Commit()
    {
        this._databaseContext.SaveChanges();
    }
}