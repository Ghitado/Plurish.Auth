using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Plurish.Auth.Application.DTOs.Users.WhoAmI;

namespace Plurish.Auth.Application.UseCases.Users.WhoAmI;
public class WhoAmIUserUseCase : IWhoAmIUserUseCase
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public WhoAmIUserUseCase(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    public Task<ResponseWhoAmIUserJson> Execute(RequestWhoAmIUserJson request)
    {
        var httpContext = _httpContextAccessor.HttpContext;

        if (httpContext?.User?.Identity is not ClaimsIdentity identity || !identity.IsAuthenticated)
        {
            throw new UnauthorizedAccessException("User is not authenticated.");
        }

        var username = identity.FindFirst(ClaimTypes.Name)?.Value ?? "Unknown";
        var email = identity.FindFirst(ClaimTypes.Email)?.Value ?? "Unknown";
        var role = identity.FindFirst(ClaimTypes.Role)?.Value ?? "Unknown";

        var response = new ResponseWhoAmIUserJson(
            Username: username,
            Email: email,
            Role: role
        );

        return Task.FromResult(response);
    }
}
