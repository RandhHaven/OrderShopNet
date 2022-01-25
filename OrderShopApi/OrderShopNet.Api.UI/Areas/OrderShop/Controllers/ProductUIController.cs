using Microsoft.AspNetCore.Mvc;
using OrderShopNet.Api.Application.Product.Queries.GetAll;
using OrderShopNet.Api.Application.EntitiesDto;
using OrderShopNet.Api.UI.SharedController;

namespace OrderShopNet.Api.UI.Areas.OrderShop.Controllers
{
    public class ProductUIController : ApiControllerBase
    {
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<ProductDetailDto>> GetById(Guid id)
        {
            return await this.Mediator.Send(new GetProductByIdQuery());
        }

    }
}
