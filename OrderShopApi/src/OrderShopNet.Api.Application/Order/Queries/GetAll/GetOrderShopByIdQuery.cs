using AutoMapper;
using MediatR;
using OrderShopNet.Api.Application.Common.Exceptions;
using OrderShopNet.Api.Application.Common.Interfaces;
using OrderShopNet.Api.Domain.Entities;
using OrderShopNet.Api.Application.EntitiesDto;

namespace OrderShopNet.Api.Application.Order.Queries.GetAll
{
    public class GetOrderShopByIdQuery : IRequest<OrderShopDto>
    {
        public Guid OrderShopId { get; set; }
    }

    public sealed class GetOrderShopByIdQueryHandler : IRequestHandler<GetOrderShopByIdQuery, OrderShopDto>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public GetOrderShopByIdQueryHandler(IApplicationDbContext _context, IMapper _mapper)
        {
            this.context = _context ?? throw new ArgumentNullException(nameof(_context));
            this.mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        public async Task<OrderShopDto> Handle(GetOrderShopByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await this.context.OrderShops
                .FindAsync(new object[] { request.OrderShopId }, cancellationToken);
            if (Object.Equals(entity, null))
            {
                throw new NotFoundException($"Error Get By Id Order: {nameof(OrderShop)}, {request.OrderShopId}");
            }
            var entityDto = this.mapper.Map<OrderShopDto>(entity);  
            return entityDto;
        }
    }
}