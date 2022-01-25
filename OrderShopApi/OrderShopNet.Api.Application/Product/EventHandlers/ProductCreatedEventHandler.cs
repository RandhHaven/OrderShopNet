namespace OrderShopNet.Api.Application.Product.EventHandlers;

using MediatR;
using Microsoft.Extensions.Logging;
using OrderShopNet.Api.Application.Models;
using OrderShopNet.Api.Domain.Events;

public sealed class ProductCreatedEventHandler : INotificationHandler<DomainEventNotification<ProductCreatedEvent>>
{
    private readonly ILogger<ProductCreatedEvent> logger;

    public ProductCreatedEventHandler(ILogger<ProductCreatedEvent> _logger)
    {
        this.logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
    }

    public Task Handle(DomainEventNotification<ProductCreatedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;
        this.logger.LogInformation($" Clean Architecture Domanin Event: {domainEvent.GetType().Name}");
        return Task.CompletedTask;
    }
}