using MediatR;
using Plurish.Auth.Domain.Enums;

namespace Plurish.Auth.Application.UseCases.SignUp;
public record SignUpCommand(string Name, string Email, string Password, Role Role) : IRequest<bool>;

