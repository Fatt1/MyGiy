using Demo.Application.Abstractions;
using Demo.Infrastructure.DependencyInjection.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Demo.Infrastructure.Authentication
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtOption _jwtOption = new JwtOption();

        public JwtTokenService(IConfiguration configuration)
        {
            configuration.GetSection(nameof(JwtOption)).Bind(_jwtOption);

        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var serectKey = Encoding.UTF8.GetBytes(_jwtOption.SecretKey);

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(serectKey), SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken
            (
                signingCredentials: signingCredentials
            );

        public string GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }

        public ClaimsPrincipal GetClaimsPrincipalFromExpiredToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
