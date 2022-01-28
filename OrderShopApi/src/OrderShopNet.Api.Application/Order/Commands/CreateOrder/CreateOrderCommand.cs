using AutoMapper;
using MediatR;
using OrderShopNet.Api.Application.Common.Interfaces;
using OrderShopNet.Api.Application.EntitiesDto;
using OrderShopNet.Api.Domain.Entities;

namespace OrderShopNet.Api.Application.Order.Commands.CreateOrder;

public sealed class CreateOrderCommand : IRequest<Guid?>
{
    public String? Title { get; set; }

    public String? NumberOrder { get; set; }

    public List<ProductDetailDto> Items { get; set; } = new List<ProductDetailDto>();

}

public sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid?>
{
    private readonly IApplicationDbContext context;
    private readonly IMapper mapper;

    public CreateOrderCommandHandler(IApplicationDbContext _context, IMapper _mapper)
    {
        this.context = _context ?? throw new ArgumentNullException(nameof(_context));
        this.mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
    }

    public async Task<Guid?> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = new OrderShop();

        entity.Title = request.Title;
        entity.NumberOrder = request.NumberOrder;
        this.context.OrderShops.Add(entity);
        if (!Object.Equals(request.Items, null) && request.Items.Any())
        {
            request.Items.ToList().ForEach(itemDto =>
            {
                var item = new ProductDetail
                {
                    NameProduct = itemDto.NameProduct,
                    Description = itemDto.Description,
                    Quantity =  itemDto.Quantity
                };                               
                this.context.Products.Add(item);
                item.OrderShopId = entity.OrderShopId;
                entity.ProductOrderGuid = Convert.ToString(item.ProductId);
            });
        }        

        await this.context.SaveChangesAsync(cancellationToken);

        return entity.OrderShopId;
    }
}