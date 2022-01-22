namespace OrderShopNet.Api.Core.Product.Commands.CreateProduct
{
    using MediatR;
    using System;

    internal class CreateProductCommand : IRequest
    {
        public String? NameProduct { get; set; }
        public Int32 ListId { get; set; }
        public String? Description { get; set; }
        public Int32? Quantity { get; set; }
    }
}
