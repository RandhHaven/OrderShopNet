namespace OrderShopNet.Api.Infrastructure.Persistence.Configurations;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderShopNet.Api.Domain.Entities;

internal class OrderShopConfiguration
{
    public void Configure(EntityTypeBuilder<OrderShop> builder)
    {      
        builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();
    }
}