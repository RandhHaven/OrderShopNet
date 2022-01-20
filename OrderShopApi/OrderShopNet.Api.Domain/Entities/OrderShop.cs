using OrderShopNet.Api.Domain.Common;
namespace OrderShopNet.Api.Domain.Entities;

using System.ComponentModel.DataAnnotations;

public sealed class OrderShop : AuditableEntity
{
    [Required]
    [Key]
    public Int64 OrderShopId { get; set; }

    public String? Title { get; set; }

    public String? NumberOrder { get; set; }

    public IList<ProductDetail> Items { get; private set; } = new List<ProductDetail>();
}