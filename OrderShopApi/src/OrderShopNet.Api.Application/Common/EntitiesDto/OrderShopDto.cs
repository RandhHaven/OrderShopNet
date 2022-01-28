namespace OrderShopNet.Api.Application.EntitiesDto;

using OrderShopNet.Api.Application.Common.Mappings;
using OrderShopNet.Api.Domain.Entities;

public sealed class OrderShopDto : IMapFrom<OrderShop>
{
    public OrderShopDto()
    {
        Items = new List<ProductDetailDto>();
    }

    public Guid? OrderShopId { get; set; }

    public String? Title { get; set; }

    public String? NumberOrder { get; set; }

    public IList<ProductDetailDto> Items { get; set; }
}