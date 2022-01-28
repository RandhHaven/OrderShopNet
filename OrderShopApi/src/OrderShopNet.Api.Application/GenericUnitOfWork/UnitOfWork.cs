namespace OrderShopNet.Api.Application.GenericUnitOfWork;

using OrderShopNet.Api.Application.Common.Interfaces;
using OrderShopNet.Api.Application.GenericRepository;

internal class UnitOfWork : IUnitOfWork
{
    private readonly IApplicationDbContext databaseContext;

    public UnitOfWork(IApplicationDbContext _databaseContext)
    {
        this.databaseContext = _databaseContext ?? throw new ArgumentNullException(nameof(_databaseContext));
    }

    public void Dispose()
    {
        this.databaseContext.Dispose();
    }

    public void Commit()
    {
        this.databaseContext.SaveChanges();
    }
}