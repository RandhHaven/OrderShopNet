namespace OrderShopNet.Api.Domain.Entities;

using OrderShopNet.Api.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public sealed class ProductDetail : AuditableEntity, IHasDomainEvent
{
    [Required]
    [Key]
    public Guid ProductId { get; set; }

    public String? NameProduct { get; set; }

    public String? Description { get; set; }

    public Int32? Quantity { get; set; }

    [ForeignKey("OrderShopId")]
    public Guid? OrderShopId { get; set; }
    
    public OrderShop? OrderShop { get; set; }
            
    public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
}