using System.Security.Claims;

namespace Demo.Application.Abstractions
{
    public interface IJwtTokenService
    {
        public string GenerateAccessToken(IEnumerable<Claim> claims);

        public string GenerateRefreshToken();

        public ClaimsPrincipal GetClaimsPrincipalFromExpiredToken(string token);
    }
}
