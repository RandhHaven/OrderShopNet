using MediatR;
using Microsoft.Extensions.Logging;
using OrderShopNet.Api.Application.Models;
using OrderShopNet.Api.Domain.Events;
using System;

namespace OrderShopNet.Api.Application.Product.EventHandlers;

public sealed class ProductCompletedEventHandler : INotificationHandler<DomainEventNotification<ProductCompletedEvent>>
{
    private readonly ILogger<ProductCompletedEventHandler> logger;

    public ProductCompletedEventHandler(ILogger<ProductCompletedEventHandler> _logger)
    {
        this.logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
    }

    public Task Handle(DomainEventNotification<ProductCompletedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;
        this.logger.LogInformation($" Clean Architecture Domanin Event: {domainEvent.GetType().Name}");
        return Task.CompletedTask;
    }
}