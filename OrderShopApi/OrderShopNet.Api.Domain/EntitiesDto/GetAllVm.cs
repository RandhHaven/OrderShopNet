namespace OrderShopNet.Api.Domain.EntitiesDto;

public sealed class GetAllVm
{
    public IList<OrderShopDto> Lists { get; set; } = new List<OrderShopDto>();
}