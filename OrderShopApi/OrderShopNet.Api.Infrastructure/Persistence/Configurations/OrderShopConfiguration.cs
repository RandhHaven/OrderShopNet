namespace OrderShopNet.Api.Infrastructure.Persistence.Configurations;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderShopNet.Api.Domain.Entities;

internal class OrderShopConfiguration
{
    public void Configure(EntityTypeBuilder<OrderShop> builder)
    {      
        builder.Property(t => t.Title)
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(t => t.NumberOrder)
           .HasMaxLength(10)
           .IsRequired();
    }
}