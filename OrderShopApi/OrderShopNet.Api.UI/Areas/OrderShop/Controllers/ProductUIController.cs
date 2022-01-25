using Microsoft.AspNetCore.Mvc;
using OrderShopNet.Api.Application.Product.Queries.GetAll;
using OrderShopNet.Api.Application.EntitiesDto;
using OrderShopNet.Api.UI.SharedController;
using OrderShopNet.Api.Application.Product.Commands.DeleteProduct;
using OrderShopNet.Api.Core.Product.Commands.CreateProduct;
using OrderShopNet.Api.Application.Product.Commands.UpdateProduct;

namespace OrderShopNet.Api.UI.Areas.OrderShop.Controllers
{
    public class ProductUIController : ApiControllerBase
    {
        [HttpGet("GetById/{id}/{productid}")]
        public async Task<ActionResult<ProductDetailDto>> GetById(Guid id, Guid productid)
        {
            return await this.Mediator.Send(new GetProductByIdQuery { OrderShopId = id, ProductId = productid });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(Guid id)
        {
            await this.Mediator.Send(new DeleteProductCommand { Id  = id });
            return NoContent();
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Guid>> Create(CreateProductCommand command)
        {
            return await this.Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDetailDto>> Update(Guid id, UpdateProductCommand command)
        {
            if (id != command.OrderShopId)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);

        }
    }
}