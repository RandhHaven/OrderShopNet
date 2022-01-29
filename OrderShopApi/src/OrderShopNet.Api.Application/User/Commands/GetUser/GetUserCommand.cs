using MediatR;
using OrderShopNet.Api.Application.Common.Interfaces;
using OrderShopNet.Api.Domain.Users.Services;

namespace OrderShopNet.Api.Application.User.Commands.GetUser;

public class GetUserCommand : IRequest<String>
{
    public String Email { get; set; }
    public String Password { get; set; }
}

public class GetUserCommandHandler : IRequestHandler<GetUserCommand, String>
{
    private readonly IIdentityService _identityService;
    private readonly ITokenSignerService _tokenSignerService;

    public GetUserCommandHandler(IIdentityService identityService,
        ITokenSignerService tokenSignerService)
    {
        _identityService = identityService;
        _tokenSignerService = tokenSignerService;
    }

    public async Task<String> Handle(GetUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _identityService.AuthenticateAsync(request.Email, request.Password);
        var jwtToken = _tokenSignerService.SignToken(user);
        return jwtToken;
    }
}