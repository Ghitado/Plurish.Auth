using MediatR;
using Plurish.Auth.Domain.Repositories;
using Plurish.Auth.Domain.Services;

namespace Plurish.Auth.Application.UseCases.SignIn;
public class SignInCommandHandler : IRequestHandler<SignInCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public SignInCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<string> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUsernameOrEmailAsync(request.UsernameOrEmail);

        if (user == null || !_passwordHasher.VerifyPassword(user.Password, request.Password))
            throw new UnauthorizedAccessException("Invalid credentials.");

        // Generate a JWT token here (skipping implementation for brevity)
        return "JWT_TOKEN";
    }
}

