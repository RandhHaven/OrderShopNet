using MediatR;
using OrderShopNet.Api.Application.Common.Exceptions;
using OrderShopNet.Api.Application.Common.Interfaces;
using OrderShopNet.Api.Domain.Entities;

namespace OrderShopNet.Api.Core.Order.Commands.UpdateOrder;

public class UpdateOrderCommand : IRequest<Guid?>
{
    public Guid OrderShopId { get; set; }
    public String? Title { get; set; }
    public String? NumberOrder { get; set; }
}

public class CreateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Guid?>
{
    private readonly IApplicationDbContext context;

    public CreateOrderCommandHandler(IApplicationDbContext _context)
    {
        this.context = _context ?? throw new ArgumentNullException(nameof(_context));
    }

    public async Task<Guid?> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = await this.context.OrderShops
                .FindAsync(new object[] { request.OrderShopId }, cancellationToken);

        if (Object.Equals(entity, null))
        {
            throw new NotFoundException($"Error Modify Order: {nameof(OrderShop)}, {request.OrderShopId}");
        }

        entity.Title = request.Title;
        entity.NumberOrder = request.NumberOrder;

        await this.context.SaveChangesAsync(cancellationToken);

        return entity.OrderShopId;
    }
}