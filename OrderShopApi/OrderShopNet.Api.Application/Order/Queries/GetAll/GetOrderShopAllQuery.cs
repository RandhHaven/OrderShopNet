using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderShopNet.Api.Application.Common.Interfaces;
using OrderShopNet.Api.Domain.EntitiesDto;

namespace OrderShopNet.Api.Application.Order.Queries.GetAll
{
    internal sealed class GetOrderShopAllQuery : IRequest<GetAllVm>
    {
    }

    internal sealed class GetOrderShopAllQueryHandler : IRequestHandler<GetOrderShopAllQuery, GetAllVm>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public GetOrderShopAllQueryHandler(IApplicationDbContext _context, IMapper _mapper)
        {
            this.context = _context ?? throw new ArgumentNullException(nameof(_context));
            this.mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        public async Task<GetAllVm> Handle(GetOrderShopAllQuery request, CancellationToken cancellationToken)
        {
            var listVm = new GetAllVm
            {               
                Lists = await context.OrderShops
                .AsNoTracking()
                .ProjectTo<OrderShopDto>(mapper.ConfigurationProvider)
                .OrderBy(t => t.Title)
                .ToListAsync(cancellationToken)
            };
            return listVm;
        }
    }
}
