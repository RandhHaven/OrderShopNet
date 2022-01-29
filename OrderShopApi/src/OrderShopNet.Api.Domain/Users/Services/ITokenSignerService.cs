using OrderShopNet.Api.Domain.Common;

namespace OrderShopNet.Api.Domain.Users.Services
{
    public interface ITokenSignerService
    {
        public string SignToken(UserResult user);
    }
}
