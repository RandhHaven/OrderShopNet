namespace OrderShopNet.Api.Domain.EntitiesDTO;

using OrderShopNet.Api.Domain.Entities;

internal class ProductDetailDto
{
    public Guid? ProductId { get; set; }
    public String? NameProduct { get; set; }
    public String? Description { get; set; }
    public Int32? Quantity { get; set; }
    public OrderShop? OrderShopId { get; set; }
}
