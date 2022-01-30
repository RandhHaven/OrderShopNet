namespace OrderShopNet.Api.UI.Test.OrderShopTest.Commands;

using FluentAssertions;
using NUnit.Framework;
using OrderShopNet.Api.Application.Common.Exceptions;
using OrderShopNet.Api.Application.EntitiesDto;
using OrderShopNet.Api.Application.Order.Commands.CreateOrder;
using OrderShopNet.Api.Domain.Entities;
using System;
using System.Threading.Tasks;
using static Testing;

internal class CreateOrderShopTest : TestBase
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateOrderCommand();
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldRequireUniqueValue()
    {
        await SendAsync(new CreateOrderCommand
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

        var command = new CreateOrderCommand
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
        };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateOrderShop()
    {
        var userId = await RunAsDefaultUserAsync();

        var command = new CreateOrderCommand
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
        };

        var id = await SendAsync(command);

        var list = await FindAsync<OrderShop>(id);

        list.Should().NotBeNull();
        list!.Title.Should().Be(command.Title);
        list!.NumberOrder.Should().Be(command.NumberOrder);
        list.CreatedBy.Should().Be(userId);
        list.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}