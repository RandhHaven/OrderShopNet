using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderShopNet.Api.Application.Common.Exceptions;
using OrderShopNet.Api.Application.Common.Interfaces;
using OrderShopNet.Api.Domain.Entities;

namespace OrderShopNet.Api.Application.Product.Commands.DeleteProduct;

public sealed class DeleteProductCommand : IRequest
{
    public Guid? Id { get; set; }
}

public sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IApplicationDbContext context;

    public DeleteProductCommandHandler(IApplicationDbContext _context)
    {
        this.context = _context ?? throw new ArgumentNullException(nameof(_context));
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var entityDelete = await this.context.Products
             .Where(x => x.ProductId == request.Id)
             .SingleOrDefaultAsync(cancellationToken);

        if (Object.Equals(entityDelete, null))
        {
            throw new NotFoundException($"Error Delete Order {nameof(ProductDetail) } - {request.Id}");
        }

        this.context.Products.Remove(entityDelete);

        await this.context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}