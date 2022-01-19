using Microsoft.EntityFrameworkCore;
using OrderShopNet.Api.Domain.Entities;

namespace OrderShopNet.Api.Core.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<OrderShop> OrderShop { get; }

    DbSet<ProductDetail> ProductDetail { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}