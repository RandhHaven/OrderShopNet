namespace OrderShopNet.Api.UI.Areas.OrderShop.Controllers;

using Microsoft.AspNetCore.Mvc;
using OrderShopNet.Api.Application.Models;
using OrderShopNet.Api.Application.Order.Commands.CreateOrder;
using OrderShopNet.Api.Application.Order.Queries.GetAll;
using OrderShopNet.Api.Core.Order.Commands.DeleteOrder;
using OrderShopNet.Api.Core.Order.Commands.UpdateOrder;
using OrderShopNet.Api.Core.Order.Queries.GetWithPagination;
using OrderShopNet.Api.Application.EntitiesDto;
using OrderShopNet.Api.UI.SharedController;

[ApiController]
[Area("OrderShop")]
public class OrderShopUIController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetAllVm>> Get()
    {
        return await this.Mediator.Send(new GetOrderShopAllQuery());
    }

    [HttpGet("GetOrderWithPagination")]
    public async Task<ActionResult<PaginatedList<OrderShopDto>>> GetOrderWithPagination([FromQuery] GetOrderShopWithPagination query)
    {
        return await Mediator.Send(query);
    }
   
    [HttpGet("GetById/{id}")]
    public async Task<ActionResult<OrderShopDto>> GetById(Guid id)
    {
        return await this.Mediator.Send(new GetOrderShopByIdQuery { OrderShopId = id });
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await this.Mediator.Send(new DeleteOrderCommand { OrderShopId = id });
        return NoContent();
    }

    [HttpPost("{id}")]
    public async Task<ActionResult<Guid>> Create(CreateOrderCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, UpdateOrderCommand command)
    {
        if (id != command.OrderShopId)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }
}