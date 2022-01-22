namespace OrderShopNet.Api.Domain.Events;

using OrderShopNet.Api.Domain.Common;
using OrderShopNet.Api.Domain.Entities;

internal class ProductCompletedEvent : DomainEvent
{
    public ProductCompletedEvent(ProductDetail item)
    {
        Item = item;
    }

    public ProductDetail Item { get; }
}
