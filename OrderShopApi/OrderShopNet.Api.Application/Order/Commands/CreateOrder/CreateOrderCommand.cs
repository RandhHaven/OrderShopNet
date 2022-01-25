using MediatR;
using OrderShopNet.Api.Application.Common.Interfaces;
using OrderShopNet.Api.Domain.Entities;

namespace OrderShopNet.Api.Application.Order.Commands.CreateOrder;

public sealed class CreateOrderCommand : IRequest<Guid?>
{
    public Guid? OrderShopId { get; set; }

    public String? Title { get; set; }

    public String? NumberOrder { get; set; }
}

public sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid?>
{
    private readonly IApplicationDbContext context;

    public CreateOrderCommandHandler(IApplicationDbContext _context)
    {
        this.context = _context ?? throw new ArgumentNullException(nameof(_context));
    }

    public async Task<Guid?> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = new OrderShop();

        entity.Title = request.Title;

        this.context.OrderShops.Add(entity);

        await this.context.SaveChangesAsync(cancellationToken);

        return entity.OrderShopId;
    }
}