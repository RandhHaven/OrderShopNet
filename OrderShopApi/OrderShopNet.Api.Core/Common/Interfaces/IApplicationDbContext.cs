using Microsoft.EntityFrameworkCore;
using OrderShopNet.Api.Domain.Entities;

namespace OrderShopNet.Api.Core.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<OrderShop> TodoLists { get; }

    DbSet<OrderShopDetail> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}