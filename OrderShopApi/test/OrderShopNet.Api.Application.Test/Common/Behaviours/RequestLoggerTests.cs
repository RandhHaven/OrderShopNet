namespace OrderShopNet.Api.Application.Test.Common.Behaviours;

using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using OrderShopNet.Api.Application.Common.Behaviours;
using OrderShopNet.Api.Application.Common.Interfaces;
using OrderShopNet.Api.Application.Product.Commands.CreateProduct;
using System;
using System.Threading;
using System.Threading.Tasks;

public class RequestLoggerTests
{
    private Mock<ILogger<CreateProductCommand>> _logger = null!;
    private Mock<ICurrentUserService> _currentUserService = null!;
    private Mock<IIdentityService> _identityService = null!;

    [SetUp]
    public void Setup()
    {
        _logger = new Mock<ILogger<CreateProductCommand>>();
        _currentUserService = new Mock<ICurrentUserService>();
        _identityService = new Mock<IIdentityService>();
    }

    [Test]
    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
    {
        _currentUserService.Setup(x => x.UserId).Returns(Guid.NewGuid().ToString());

        var requestLogger = new LoggingBehaviour<CreateProductCommand>(_logger.Object, _currentUserService.Object, _identityService.Object);

        await requestLogger.Process(new CreateProductCommand { NameProduct = "Test Product", 
                                                               Description = "Test Description", 
                                                               Quantity = 100, 
                                                               OrderShopId = new Guid() }, new CancellationToken());

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
    {
        var requestLogger = new LoggingBehaviour<CreateProductCommand>(_logger.Object, _currentUserService.Object, _identityService.Object);

        await requestLogger.Process(new CreateProductCommand { NameProduct = "Test Product", Description = "Test Description", Quantity = 100, OrderShopId = new Guid() }, new CancellationToken());

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Never);
    }
}