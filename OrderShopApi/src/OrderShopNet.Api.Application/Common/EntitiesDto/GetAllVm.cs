namespace OrderShopNet.Api.Application.EntitiesDto;

public sealed class GetAllVm
{
    public IList<OrderShopDto> Lists { get; set; } = new List<OrderShopDto>();
}