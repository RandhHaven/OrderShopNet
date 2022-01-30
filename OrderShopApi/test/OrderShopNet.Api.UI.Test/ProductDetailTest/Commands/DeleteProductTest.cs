using FluentAssertions;
using NUnit.Framework;
using OrderShopNet.Api.Application.Common.Exceptions;
using OrderShopNet.Api.Application.Product.Commands.CreateProduct;
using OrderShopNet.Api.Application.Product.Commands.DeleteProduct;
using OrderShopNet.Api.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace OrderShopNet.Api.UI.Test.ProductDetailTest.Commands;

using static Testing;

internal class DeleteProductTest : TestBase
{
    [Test]
    public async Task ShouldRequireValidProductId()
    {
        var command = new DeleteProductCommand { Id = Guid.Empty };
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteProduct()
    {
        var productId = await SendAsync(new CreateProductCommand
        {
            NameProduct = "Test New Name Product",
            Description = "Test New Description Product",
            Quantity = 10
        });

        await SendAsync(new DeleteProductCommand
        {
            Id = productId.Value
        });

        var list = await FindAsync<ProductDetail>(productId);

        list.Should().BeNull();
    }
}