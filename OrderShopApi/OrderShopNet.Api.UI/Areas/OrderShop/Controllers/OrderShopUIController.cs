namespace OrderShopNet.Api.UI.Areas.OrderShop.Controllers;

using Microsoft.AspNetCore.Mvc;
using OrderShopNet.Api.Core.Order.Commands.UpdateOrder;
using OrderShopNet.Api.UI.SharedController;

[ApiController]
[Area("OrderShop")]
public class OrderShopUIController : ApiControllerBase
{
    private static readonly string[] Summaries = new[]
           {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

    public OrderShopUIController()
    {
    }

    [HttpGet(Name = "OrderShopUI")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
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