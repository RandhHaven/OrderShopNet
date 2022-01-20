namespace OrderShopNet.Api.Domain.Events;

using OrderShopNet.Api.Domain.Common;
using OrderShopNet.Api.Domain.Entities;

internal class OrderShopCompletedEvent : DomainEvent
{
    public OrderShopCompletedEvent(OrderShop item)
    {
        Item = item;
    }

    public OrderShop Item { get; }
}
