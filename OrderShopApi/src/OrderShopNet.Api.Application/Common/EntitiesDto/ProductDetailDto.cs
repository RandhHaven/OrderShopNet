namespace OrderShopNet.Api.Application.EntitiesDto;

using OrderShopNet.Api.Application.Common.Mappings;
using OrderShopNet.Api.Domain.Entities;

public sealed class ProductDetailDto : IMapFrom<ProductDetail>
{
    public Guid ProductId { get; set; }

    public String? NameProduct { get; set; }

    public String? Description { get; set; }

    public Int32? Quantity { get; set; }

    public Guid? OrderShopId { get; set; }

    public OrderShop? OrderShop { get; set; }
}
