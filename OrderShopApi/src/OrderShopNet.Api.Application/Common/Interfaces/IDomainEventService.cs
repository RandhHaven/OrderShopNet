namespace OrderShopNet.Api.Application.Common.Interfaces;

using OrderShopNet.Api.Domain.Common;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}