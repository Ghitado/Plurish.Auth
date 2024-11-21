
using Microsoft.AspNetCore.Mvc;
using Plurish.Auth.Application.Services;
using Plurish.Auth.Domain.Entities;

namespace Plurish.Auth.Api.Controllers;
[Route("api/auth")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] User user, [FromQuery] string password)
    {
        try
        {
            bool created = await _userService.RegisterUserAsync(user, password);
            if (created)
                return Ok("User registered successfully");
            return BadRequest("Failed to register user");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromQuery] string email, [FromQuery] string password)
    {
        try
        {
            var user = await _userService.AuthenticateAsync(email, password);
            return Ok(user); // Retorna os dados do usuário ou um token de autenticação, conforme a necessidade
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
