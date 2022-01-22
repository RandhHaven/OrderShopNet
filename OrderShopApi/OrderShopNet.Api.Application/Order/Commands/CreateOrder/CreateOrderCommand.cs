using MediatR;
using OrderShopNet.Api.Application.Common.Interfaces;
using OrderShopNet.Api.Domain.Entities;
using System;

namespace OrderShopNet.Api.Application.Order.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<Guid?>
{
    public Int64 OrderShopId { get; set; }

    public String? Title { get; set; }

    public String? NumberOrder { get; set; }
}

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid?>
{
    private readonly IApplicationDbContext _context;

    public CreateOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid?> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = new OrderShop();

        entity.Title = request.Title;

        _context.OrderShops.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.OrderShopId;
    }
}