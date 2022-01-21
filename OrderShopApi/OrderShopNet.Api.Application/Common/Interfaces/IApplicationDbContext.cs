namespace OrderShopNet.Api.Application.Common.Interfaces;

using Microsoft.EntityFrameworkCore;
using OrderShopNet.Api.Domain.Entities;

public interface IApplicationDbContext
{
    DbSet<OrderShop> OrderShop { get; }

    DbSet<ProductDetail> ProductDetail { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    void Dispose();

    int SaveChanges();
}