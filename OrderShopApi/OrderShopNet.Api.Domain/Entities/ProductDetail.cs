namespace OrderShopNet.Api.Domain.Entities;

using OrderShopNet.Api.Domain.Common;
using System.ComponentModel.DataAnnotations;

public sealed class ProductDetail : AuditableEntity, IHasDomainEvent
{
    [Key]
    public Guid ProductId { get; set; }
    public String? NameProduct { get; set; }
    public Int32 ListId { get; set; }
    public String? Description { get; set; }
    public Int32? Quantity { get; set; }
    public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
}