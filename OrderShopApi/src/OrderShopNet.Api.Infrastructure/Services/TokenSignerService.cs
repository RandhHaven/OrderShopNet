namespace OrderShopNet.Api.Infrastructure.Services
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using OrderShopNet.Api.Domain.Common;
    using OrderShopNet.Api.Domain.Users.Services;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    public class TokenSignerService : ITokenSignerService
    {
        private readonly IConfiguration configuration;

        public TokenSignerService(IConfiguration _configuration)
        {
            this.configuration = _configuration ?? throw new ArgumentNullException(nameof(_configuration));
        }

        public string SignToken(UserResult user)
        {
            var jwtSecret = this.configuration["JWT_SERCRET"];
            var issuer = this.configuration["JWT_ISSUER"];
            var audience = this.configuration["JWT_AUDIENCE"];
            var expiresIn = int.Parse(this.configuration["JWT_EXPIRES_IN"]);

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
    }
}