using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plurish.Auth.Application.DTOs.Users.SignIn;
using Plurish.Auth.Application.DTOs.Users.SignOut;
using Plurish.Auth.Application.DTOs.Users.SignUp;
using Plurish.Auth.Application.DTOs.Users.WhoAmI;
using Plurish.Auth.Application.UseCases.Users.Register;
using Plurish.Auth.Application.UseCases.Users.SignIn;
using Plurish.Auth.Application.UseCases.Users.SignOut;
using Plurish.Auth.Application.UseCases.Users.WhoAmI;

namespace Plurish.Auth.Api.Controllers;
[Route("api/auth")]
[ApiController]
public class UserController : ControllerBase
{

    [HttpPost("signup")]
    [ProducesResponseType(typeof(ResponseSignUpUserJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> SignUp(
        [FromServices] ISignUpUserUseCase useCase,
        [FromBody] RequestSignUpUserJson request)
    {
        var result = await useCase.Execute(request);

        return Created(string.Empty, result);
    }

    [HttpPost("signin")]
    [ProducesResponseType(typeof(ResponseSignInUserJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> SignIn(
        [FromServices] ISignInUserUseCase signInUseCase,
        [FromBody] RequestSignInUserJson request)
    {
        var result = await signInUseCase.Execute(request);

        return Ok(result);
    }

    [Authorize]
    [HttpPost("signout")]
    [ProducesResponseType(typeof(ResponseSignOutUserJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> SignOut(
        [FromServices] ISignOutUserUseCase signOutUseCase,
        [FromBody] RequestSignOutUserJson request)
    {
        var result = await signOutUseCase.Execute(request);

        return Ok(result);
    }

    [Authorize]
    [HttpGet("whoami")]
    [ProducesResponseType(typeof(ResponseWhoAmIUserJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> WhoAmI(
        [FromServices] IWhoAmIUserUseCase whoAmIUseCase)
    {
        var request = new RequestWhoAmIUserJson();
        var result = await whoAmIUseCase.Execute(request);

        return Ok(result);
    }
}
