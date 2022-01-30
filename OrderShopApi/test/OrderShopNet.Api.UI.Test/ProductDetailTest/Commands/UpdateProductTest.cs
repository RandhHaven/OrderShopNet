
namespace OrderShopNet.Api.UI.Test.ProductDetailTest.Commands;

using FluentAssertions;
using NUnit.Framework;
using OrderShopNet.Api.Application.Common.Exceptions;
using OrderShopNet.Api.Application.Product.Commands.CreateProduct;
using OrderShopNet.Api.Application.Product.Commands.UpdateProduct;
using OrderShopNet.Api.Domain.Entities;
using System;
using System.Threading.Tasks;
using static Testing;

internal class UpdateProductTest
{
    [Test]
    public async Task ShouldRequireValidProductId()
    {
        var command = new UpdateProductCommand
        {
            OrderShopId = Guid.NewGuid(),
            NameProduct = "New Name Product",
            Description = "New Description Product",
            Quantity = 10
        };
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldUpdateProduct()
    {
        var userId = await RunAsDefaultUserAsync();

        var productId = await SendAsync(new CreateProductCommand
        {
            OrderShopId = Guid.NewGuid(),
            NameProduct = "New Name Product",
            Description = "New Description Product",
            Quantity = 10
        });

        var command = new UpdateProductCommand
        {
            Id = productId.Value,
            OrderShopId = Guid.NewGuid(),
            NameProduct = "Update Name Product",
            Description = "Update Description Product",
            Quantity = 10
        };

        await SendAsync(command);

        var item = await FindAsync<ProductDetail>(productId);

        item.Should().NotBeNull();
        item!.NameProduct.Should().Be(command.NameProduct);
        item!.Description.Should().Be(command.Description);
        item!.Quantity.Should().Be(command.Quantity);
        item!.OrderShopId.Should().Be(command.OrderShopId);
        item.LastModifiedBy.Should().NotBeNull();
        item.LastModifiedBy.Should().Be(userId);
        item.LastModified.Should().NotBeNull();
        item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}