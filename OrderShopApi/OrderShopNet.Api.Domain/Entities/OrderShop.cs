namespace OrderShopNet.Api.Domain.Entities;

using OrderShopNet.Api.Domain.Common;
using System.ComponentModel.DataAnnotations;

public sealed class OrderShop : AuditableEntity
{
    [Required]
    [Key]
    public Guid? OrderShopId { get; set; }

    public String? Title { get; set; }

    public String? NumberOrder { get; set; }

    public IList<ProductDetail> Items { get; private set; } = new List<ProductDetail>();

    public String? ProductOrderGuid { get; set; }
}