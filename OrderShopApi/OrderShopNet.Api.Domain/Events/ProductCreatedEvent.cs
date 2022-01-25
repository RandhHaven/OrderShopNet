using OrderShopNet.Api.Domain.Common;
using OrderShopNet.Api.Domain.Entities;

namespace OrderShopNet.Api.Domain.Events;

public class ProductCreatedEvent : DomainEvent
{
    public ProductCreatedEvent(ProductDetail item)
    {
        Item = item;
    }

    public ProductDetail Item { get; }
}