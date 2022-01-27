namespace OrderShopNet.Api.Domain.Events;

using OrderShopNet.Api.Domain.Common;
using OrderShopNet.Api.Domain.Entities;

public class ProductCompletedEvent : DomainEvent
{
    public ProductCompletedEvent(ProductDetail item)
    {
        Item = item;
    }

    public ProductDetail Item { get; }
}