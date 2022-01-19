namespace OrderShopNet.Api.Domain.Entities;

using OrderShopNet.Api.Domain.Common;

public sealed class ProductDetail : AuditableEntity, IHasDomainEvent
{
    public Guid ProductId { get; set; }
    public String? NameProduct { get; set; }
    public Int32 ListId { get; set; }
    public String? Title { get; set; }

    public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
}