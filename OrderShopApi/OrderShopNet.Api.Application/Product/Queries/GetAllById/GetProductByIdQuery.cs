using AutoMapper;
using MediatR;
using OrderShopNet.Api.Application.Common.Exceptions;
using OrderShopNet.Api.Application.Common.Interfaces;
using OrderShopNet.Api.Domain.Entities;
using OrderShopNet.Api.Application.EntitiesDto;

namespace OrderShopNet.Api.Application.Product.Queries.GetAll;

public sealed class GetProductByIdQuery : IRequest<ProductDetailDto>
{
    public Guid OrderShopId { get; set; }
    public Guid ProductId { get; set; }
}

public sealed class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDetailDto>
{
    private readonly IApplicationDbContext context;
    private readonly IMapper mapper;

    public GetProductByIdQueryHandler(IApplicationDbContext _context, IMapper _mapper)
    {
        this.context = _context ?? throw new ArgumentNullException(nameof(_context));
        this.mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
    }

    public async Task<ProductDetailDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await this.context.Products
               .FindAsync(new object[] { request.OrderShopId }, cancellationToken);
        if (Object.Equals(entity, null))
        {
            throw new NotFoundException($"Error Get By Id Product: {nameof(ProductDetail)}, {request.OrderShopId}");
        }
        var entityDto = this.mapper.Map<ProductDetailDto>(entity);
        return entityDto;
    }
}