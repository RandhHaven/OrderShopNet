using AuthVec.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;
using OrderShopApi;

namespace OrderShop.Api.UI.Areas.OrderShop.Controllers;

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
}