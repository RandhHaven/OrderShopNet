using FluentAssertions;
using NUnit.Framework;
using OrderShopNet.Api.Application.Common.Exceptions;
using OrderShopNet.Api.Application.Order.Commands.CreateOrder;
using OrderShopNet.Api.Application.Order.Commands.UpdateOrder;
using System;
using System.Threading.Tasks;
using OrderShopNet.Api.Domain.Entities;
using OrderShopNet.Api.Application.EntitiesDto;

namespace OrderShopNet.Api.UI.Test.OrderShopTest.Commands;

using static Testing;

internal class UpdateOrderShopTest : TestBase
{
    [Test]
    public async Task ShouldRequireValidOrderShopId()
    {
        var command = new UpdateOrderCommand { OrderShopId = Guid.NewGuid(), Title = "New Title", NumberOrder = "new Number Order" };
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldUpdateOrderShop()
    {
        var userId = await RunAsDefaultUserAsync();

        var orderShopId = await SendAsync(new CreateOrderCommand
        {
            Title = "New Tittle Order Shop",
            NumberOrder = "New Number Order",
            Items =
                    {
                        new ProductDetailDto { NameProduct= "First Product ", Description = "First Description", Quantity = 10 },
                        new ProductDetailDto { NameProduct= "Second Product", Description = "Second Product", Quantity = 20 },
                        new ProductDetailDto { NameProduct= "Third Product", Description = "Third Product", Quantity = 30 },
                        new ProductDetailDto { NameProduct= "Fourth Product", Description = "Fourth Product", Quantity = 40 },
                        new ProductDetailDto { NameProduct= "Fifth Product", Description = "Fifth Product", Quantity = 50 }
            }
        });

        var itemId = await SendAsync(new CreateOrderCommand
        {
            Title = "New Tittle Order Shop",
            NumberOrder = "New Number Order"
        });

        var command = new UpdateOrderCommand
        {
            OrderShopId = orderShopId.Value,
            Title = "Updated Item Title",
            NumberOrder = "Updated Item Number Order"
        };

        await SendAsync(command);

        var item = await FindAsync<OrderShop>(itemId);

        item.Should().NotBeNull();
        item!.Title.Should().Be(command.Title);
        item!.NumberOrder.Should().Be(command.NumberOrder);
        item.LastModifiedBy.Should().NotBeNull();
        item.LastModifiedBy.Should().Be(userId);
        item.LastModified.Should().NotBeNull();
        item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}