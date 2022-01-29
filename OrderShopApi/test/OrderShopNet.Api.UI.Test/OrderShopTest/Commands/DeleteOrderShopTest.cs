using FluentAssertions;
using NUnit.Framework;
using OrderShopNet.Api.Application.Common.Exceptions;
using OrderShopNet.Api.Application.Order.Commands.CreateOrder;
using OrderShopNet.Api.Application.Order.Commands.DeleteOrder;
using System;
using System.Threading.Tasks;
using OrderShopNet.Api.Domain.Entities;

namespace OrderShopNet.Api.UI.Test.OrderShopTest.Commands;

using static Testing;

public class DeleteOrderShopTest : TestBase
{
    [Test]
    public async Task ShouldRequireValidTodoListId()
    {
        var command = new DeleteOrderCommand { OrderShopId = Guid.Empty };
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoList()
    {
        var orderShopId = await SendAsync(new CreateOrderCommand
        {
            Title = "New List",
            NumberOrder = "Number Order"
        });

        await SendAsync(new DeleteOrderCommand
        {
            OrderShopId = orderShopId.Value
        });

        var list = await FindAsync<OrderShop>(orderShopId);

        list.Should().BeNull();
    }
}