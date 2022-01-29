using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using OrderShopNet.Api.Application.Common.Interfaces;
using OrderShopNet.Api.Application.Common.Mappings;
using OrderShopNet.Api.Application.Models;
using OrderShopNet.Api.Application.EntitiesDto;

namespace OrderShopNet.Api.Application.Order.Queries.GetWithPagination;

public class GetOrderShopWithPagination : IRequest<PaginatedList<OrderShopDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetOrderShopWithPaginationHandler : IRequestHandler<GetOrderShopWithPagination, PaginatedList<OrderShopDto>>
{
    private readonly IApplicationDbContext context;
    private readonly IMapper mapper;

    public GetOrderShopWithPaginationHandler(IApplicationDbContext _context, IMapper _mapper)
    {
        this.context = _context ?? throw new ArgumentNullException(nameof(_context));
        this.mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
    }

    public async Task<PaginatedList<OrderShopDto>> Handle(GetOrderShopWithPagination request, CancellationToken cancellationToken)
    {
        return await this.context.OrderShops
           .OrderBy(x => x.NumberOrder)
           .ProjectTo<OrderShopDto>(this.mapper.ConfigurationProvider)
           .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}