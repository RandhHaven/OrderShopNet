using Microsoft.IdentityModel.Tokens;
using OrderShopNet.Api.Domain.Common;
using OrderShopNet.Api.Domain.Users.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OrderShopNet.Api.Infrastructure.Services
{
    public class TokenSignerService : ITokenSignerService
    {
        public string SignToken(UserResult user)
        {
            //var jwtSecret = configuration.Get<string>("ELASTICSEARCH_PORT");
            //var issuer = Environment.GetEnvironmentVariable(EnvironmentVariablesConstants.JWT_ISSUER);
            //var audience = Environment.GetEnvironmentVariable(EnvironmentVariablesConstants.JWT_AUDIENCE);
            //var expiresIn = Environment.GetEnvironmentVariable(EnvironmentVariablesConstants.JWT_EXPIRES_IN);

            try
            {
                var jwtSecret = "/B?D(G+KbPeShVmYq3t6w9z$C&F)H@McQfTjWnZr4u7x!A%D*G-KaNdRgUkXp2s5";
                var issuer = "ordershop_issuer";
                var audience = "ordershop_udience";
                var expiresIn = 86400;

                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
                var jwtExpirationInMinutes = expiresIn;

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserId));
                claims.Add(new Claim(ClaimTypes.Email, user.Email));
                claims.Add(new Claim(ClaimTypes.Name, user.UserName ?? ""));

                var securityTokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = issuer,
                    Audience = audience,
                    Expires = DateTime.UtcNow.AddSeconds(jwtExpirationInMinutes),
                    Subject = new ClaimsIdentity(claims),
                    SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
                };

                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
                return jwtSecurityTokenHandler.WriteToken(securityToken);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
