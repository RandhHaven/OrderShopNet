using MediatR;
using OrderShopNet.Api.Application.Common.Interfaces;
using OrderShopNet.Api.Application.Common.Models;

namespace OrderShopNet.Api.Application.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Result>
    {
        public String Email { get; set; }
        public String Password { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
    {
        private readonly IIdentityService _identityService;

        public CreateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _identityService.CreateUserAsync(request.Email, request.Password);

            return user.Result;
        }
    }

}
