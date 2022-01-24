namespace OrderShopNet.Api.Domain.EntitiesDto;

public sealed class OrderShopDto
{
    public Guid? OrderShopId { get; set; }

    public String? Title { get; set; }

    public String? NumberOrder { get; set; }

    public IList<ProductDetailDto> Items { get; set; }
}