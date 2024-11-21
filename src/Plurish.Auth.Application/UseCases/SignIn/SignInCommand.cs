using MediatR;

namespace Plurish.Auth.Application.UseCases.SignIn;
public record SignInCommand(string UsernameOrEmail, string Password) : IRequest<string>;

