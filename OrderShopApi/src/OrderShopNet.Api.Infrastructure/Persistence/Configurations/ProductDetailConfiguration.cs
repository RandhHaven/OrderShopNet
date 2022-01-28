namespace OrderShopNet.Api.Infrastructure.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderShopNet.Api.Domain.Entities;

internal class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
{
    public void Configure(EntityTypeBuilder<ProductDetail> builder)
    {
        builder.Ignore(e => e.DomainEvents);
        builder.Property(t => t.ProductId)
           .IsRequired();
        builder.Property(t => t.NameProduct)
            .HasMaxLength(200)
            .IsRequired();
        builder.Property(t => t.Description)
           .HasMaxLength(200)
           .IsRequired();
        builder.Property(t => t.Quantity)
           .HasMaxLength(10)
           .IsRequired();
    }
}