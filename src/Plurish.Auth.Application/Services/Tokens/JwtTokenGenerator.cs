using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Plurish.Auth.Domain.Entities;
using Plurish.Auth.Domain.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Plurish.Auth.Application.Services.Tokens;
public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IConfiguration _configuration;

    public JwtTokenGenerator(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public string GenerateAccessToken(User user)
    {
        var tokenExpirationInMinutes = int.Parse(_configuration["Settings:Jwt:AccessTokenExpirationMinutes"]!);

        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Settings:Jwt:SecretKey"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Settings:Jwt:Issuer"],
            audience: _configuration["Settings:Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(tokenExpirationInMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateRefreshToken()
    {
        return Guid.NewGuid().ToString();
    }
}

