namespace OrderShopNet.Api.Application.Order.Commands.DeleteOrder;

using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderShopNet.Api.Application.Common.Exceptions;
using OrderShopNet.Api.Application.Common.Interfaces;
using OrderShopNet.Api.Domain.Entities;

public sealed class DeleteOrderCommand : IRequest
{
    public Guid OrderShopId { get; set; }
}

public sealed class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{
    private readonly IApplicationDbContext context;

    public DeleteOrderCommandHandler(IApplicationDbContext _context)
    {
        this.context = _context ?? throw new ArgumentNullException(nameof(_context));
    }

    public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var entityDelete = await this.context.OrderShops
            .Where(x => x.OrderShopId == request.OrderShopId)
            .SingleOrDefaultAsync(cancellationToken);

        var entityDeleteProducts = await this.context.Products
           .Where(x => x.OrderShopId == request.OrderShopId)
           .SingleOrDefaultAsync(cancellationToken);

        if (Object.Equals(entityDelete, null))
        {
            throw new NotFoundException($"Error Delete Order {nameof(OrderShop) } - {request.OrderShopId}");
        }

        this.context.OrderShops.Remove(entityDelete);

        this.context.Products.Remove(entityDeleteProducts);

        await this.context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}