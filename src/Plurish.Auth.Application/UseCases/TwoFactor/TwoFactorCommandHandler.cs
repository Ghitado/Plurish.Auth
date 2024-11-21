using MediatR;
using Plurish.Auth.Domain.Repositories;
using Plurish.Auth.Domain.Services;

namespace Plurish.Auth.Application.UseCases.TwoFactor;
public class TwoFactorCommandHandler : IRequestHandler<TwoFactorCommand, bool>
{
    private readonly IUserRepository _userRepository;
    private readonly ITwoFactorService _twoFactorService;

    public TwoFactorCommandHandler(IUserRepository userRepository, ITwoFactorService twoFactorService)
    {
        _userRepository = userRepository;
        _twoFactorService = twoFactorService;
    }

    public async Task<bool> Handle(TwoFactorCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.UserId);

        if (user == null || !_twoFactorService.VerifyCode(request.Code, user.TwoFactorCode))
            return false;

        return true;
    }
}

