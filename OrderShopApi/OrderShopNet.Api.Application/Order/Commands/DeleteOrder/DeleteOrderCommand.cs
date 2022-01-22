using MediatR;

namespace OrderShopNet.Api.Core.Order.Commands.DeleteOrder;

internal class DeleteOrderCommand : IRequest<Guid>
{
    public Int64 OrderShopId { get; set; }
}

internal class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Guid>
{
    public Task<Guid> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}