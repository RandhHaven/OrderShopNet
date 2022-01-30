using FluentAssertions;
using FluentValidation;
using NUnit.Framework;
using OrderShopNet.Api.Application.Product.Commands.CreateProduct;
using OrderShopNet.Api.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace OrderShopNet.Api.UI.Test.ProductDetailTest.Commands;

using static Testing;

internal class CreateProductTest
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateProductCommand();
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldRequireUniqueTitle()
    {
        await SendAsync(new CreateProductCommand
        {
            NameProduct = "Test Name Product",
            Description = "Test Description Product",
            Quantity = 10,
            OrderShopId = Guid.NewGuid()

        });

        var command = new CreateProductCommand
        {
            NameProduct = "Test Name Product",
            Description = "Test Description Product",
            Quantity = 10,
            OrderShopId = Guid.NewGuid()
        };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateTodoList()
    {
        var userId = await RunAsDefaultUserAsync();

        var command = new CreateProductCommand
        {
            NameProduct = "Test New Name Product",
            Description = "Test New Description Product",
            Quantity = 10,
            OrderShopId = Guid.NewGuid()
        };

        var id = await SendAsync(command);

        var list = await FindAsync<ProductDetail>(id);

        list.Should().NotBeNull();
        list!.NameProduct.Should().Be(command.NameProduct);
        list!.Description.Should().Be(command.Description);
        list!.Quantity.Should().Be(command.Quantity);
        list!.OrderShopId.Should().Be(command.OrderShopId);
        list.CreatedBy.Should().Be(userId);
        list.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
