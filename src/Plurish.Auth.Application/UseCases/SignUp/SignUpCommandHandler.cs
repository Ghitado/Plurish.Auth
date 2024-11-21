using MediatR;
using Plurish.Auth.Domain.Entities;
using Plurish.Auth.Domain.Repositories;
using Plurish.Auth.Domain.Services;

namespace Plurish.Auth.Application.UseCases.SignUp;
public class SignUpCommandHandler : IRequestHandler<SignUpCommand, bool>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public SignUpCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<bool> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        var user = new User(
            request.Name,
            request.Email,
            _passwordHasher.HashPassword(request.Password),
            request.Role
        );

        return await _userRepository.CreateAsync(user);
    }
}

