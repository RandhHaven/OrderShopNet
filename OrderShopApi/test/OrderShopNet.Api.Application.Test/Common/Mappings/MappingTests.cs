namespace OrderShopNet.Api.Application.Test.Common.Mappings;

using AutoMapper;
using NUnit.Framework;
using OrderShopNet.Api.Application.Common.Mappings;
using OrderShopNet.Api.Application.EntitiesDto;
using OrderShopNet.Api.Domain.Entities;
using System;
using System.Runtime.Serialization;

public class MappingTests
{
    private readonly IConfigurationProvider configuration;
    private readonly IMapper mapper;

    public MappingTests()
    {
        this.configuration = new MapperConfiguration(config =>
           config.AddProfile<MappingProfile>());
        this.mapper = this.configuration.CreateMapper();
    }

    [Test]
    public void ShouldHaveValidConfiguration()
    {
        this.configuration.AssertConfigurationIsValid();
    }

    [Test]
    [TestCase(typeof(OrderShop), typeof(OrderShopDto))]
    [TestCase(typeof(ProductDetail), typeof(ProductDetailDto))]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
        var instance = GetInstanceOf(source);
        this.mapper.Map(instance, source, destination);
    }

    private object GetInstanceOf(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) != null)
            return Activator.CreateInstance(type)!;

        // Type without parameterless constructor
        return FormatterServices.GetUninitializedObject(type);
    }
}