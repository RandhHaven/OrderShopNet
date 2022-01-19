using OrderShopNet.Api.Domain.Common;
using OrderShopNet.Api.Domain.Entities;

namespace OrderShopNet.Api.Domain.Events;
internal class OrderShopCompletedEvent : DomainEvent
{
    public OrderShopCompletedEvent(OrderShop item)
    {
        Item = item;
    }

    public OrderShop Item { get; }
}
