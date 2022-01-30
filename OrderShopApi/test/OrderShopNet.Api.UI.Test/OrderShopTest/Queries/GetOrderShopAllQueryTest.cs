namespace OrderShopNet.Api.UI.Test.OrderShopTest.Queries;

using FluentAssertions;
using NUnit.Framework;
using OrderShopNet.Api.Application.Order.Queries.GetAll;
using System.Linq;
using System.Threading.Tasks;
using OrderShopNet.Api.Domain.Entities;
using static Testing;

internal class GetOrderShopAllQueryTest : TestBase
{
    [Test]
    public async Task ShouldReturnAllListsOrderShops()
    {
        await AddAsync(new OrderShop
        {
            Title = "Shopping",
            NumberOrder = "K20",
            Items =
                    {
                        new ProductDetail { NameProduct= "First Product ", Description = "First Description", Quantity = 10 },
                        new ProductDetail { NameProduct= "Second Product", Description = "Second Product", Quantity = 20 },
                        new ProductDetail { NameProduct= "Third Product", Description = "Third Product", Quantity = 30 },
                        new ProductDetail { NameProduct= "Fourth Product", Description = "Fourth Product", Quantity = 40 },
                        new ProductDetail { NameProduct= "Fifth Product", Description = "Fifth Product", Quantity = 50 }
                    }
        });

        var query = new GetOrderShopAllQuery();

        var result = await SendAsync(query);

        result.Lists.Should().HaveCount(1);
        result.Lists.First().Items.Should().HaveCount(5);
    }
}