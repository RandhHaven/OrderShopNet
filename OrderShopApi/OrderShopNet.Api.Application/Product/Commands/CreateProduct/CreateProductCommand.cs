using MediatR;
using OrderShopNet.Api.Application.Common.Interfaces;
using OrderShopNet.Api.Domain.Entities;

namespace OrderShopNet.Api.Core.Product.Commands.CreateProduct;

public class CreateProductCommand : IRequest<Guid?>
{
    public String? NameProduct { get; set; }

    public String? Description { get; set; }

    public Int32? Quantity { get; set; }

    public Guid? OrderShopId { get; set; }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid?>
{
    private readonly IApplicationDbContext context;

    public CreateProductCommandHandler(IApplicationDbContext _context)
    {
        this.context = _context ?? throw new ArgumentNullException(nameof(_context));
    }

    public async Task<Guid?> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = new ProductDetail();

        entity.NameProduct = request.NameProduct;
        entity.Description = request.Description;
        entity.Quantity = request.Quantity;
        entity.OrderShopId = request.OrderShopId;

        this.context.Products.Add(entity);

        await this.context.SaveChangesAsync(cancellationToken);

        return entity.ProductId;
    }
}