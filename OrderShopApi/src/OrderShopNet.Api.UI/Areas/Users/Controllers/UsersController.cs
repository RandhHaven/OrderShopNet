using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderShopNet.Api.Application.Common.Models;
using OrderShopNet.Api.Application.User.Commands.CreateUser;
using OrderShopNet.Api.Application.User.Commands.GetUser;
using OrderShopNet.Api.UI.SharedController;

namespace OrderShopNet.Api.UI.Areas.Users.Controllers
{
    [ApiController]
    [Area("Users")]
    public class UsersController : ApiControllerBase
    {
        [AllowAnonymous]
        [HttpPost("Signin")]
        public async Task<ActionResult<string>> GetUser(GetUserCommand command)
        {
           return await Mediator.Send(command);
        }


        [HttpPost]
        public async Task<ActionResult<Result>> Create(CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}