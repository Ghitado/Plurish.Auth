using MediatR;

namespace Plurish.Auth.Application.UseCases.TwoFactor;
public record TwoFactorCommand(Guid UserId, string Code) : IRequest<bool>;

