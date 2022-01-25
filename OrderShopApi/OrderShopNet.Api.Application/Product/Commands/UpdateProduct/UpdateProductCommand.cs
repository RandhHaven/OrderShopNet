using AutoMapper;
using MediatR;
using OrderShopNet.Api.Application.Common.Exceptions;
using OrderShopNet.Api.Application.Common.Interfaces;
using OrderShopNet.Api.Application.EntitiesDto;

namespace OrderShopNet.Api.Application.Product.Commands.UpdateProduct;

public sealed class UpdateProductCommand : IRequest<ProductDetailDto>
{
    public Guid Id { get; set; }

    public String? NameProduct { get; set; }

    public String? Description { get; set; }

    public Guid? OrderShopId { get; set; }

    public Int32? Quantity { get; set; }
}

public sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDetailDto>
{
    private readonly IApplicationDbContext context;
    private readonly IMapper mapper;

    public UpdateProductCommandHandler(IApplicationDbContext _context, IMapper _mapper)
    {
        this.context = _context ?? throw new ArgumentNullException(nameof(_context));
        this.mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
    }

    public async Task<ProductDetailDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await this.context.Products
               .FindAsync(new object[] { request.Id }, cancellationToken);

        if (Object.Equals(entity, null))
        {
            throw new NotFoundException($"Error Modify Order: {nameof(ProductDetailDto)}, {request.Id}");
        }

        entity.NameProduct = request.NameProduct;
        entity.Description = request.Description;
        entity.Quantity = request.Quantity;
        entity.OrderShopId = request.OrderShopId;

        this.context.Products.Add(entity);

        await this.context.SaveChangesAsync(cancellationToken);
        var entityDto = this.mapper.Map<ProductDetailDto>(entity);
        return entityDto;
    }

    Task<ProductDetailDto> IRequestHandler<UpdateProductCommand, ProductDetailDto>.Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}