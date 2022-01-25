namespace OrderShopNet.Api.Core.Product.Commands.CreateProduct
{
    using MediatR;
    using System;

    public class CreateProductCommand : IRequest
    {
        public String? NameProduct { get; set; }
        public String? Description { get; set; }
        public Int32? Quantity { get; set; }
    }
}
