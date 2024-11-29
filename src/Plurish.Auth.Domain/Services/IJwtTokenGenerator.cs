using Plurish.Auth.Domain.Entities;

namespace Plurish.Auth.Domain.Services;
public interface IJwtTokenGenerator
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
}

