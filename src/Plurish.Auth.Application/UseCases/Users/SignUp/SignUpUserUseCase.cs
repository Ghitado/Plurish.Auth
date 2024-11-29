using Plurish.Auth.Application.DTOs.Users.SignUp;
using Plurish.Auth.Domain.Entities;
using Plurish.Auth.Domain.Repositories;
using Plurish.Auth.Domain.Services;

namespace Plurish.Auth.Application.UseCases.Users.Register;
public class SignUpUserUseCase : ISignUpUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public SignUpUserUseCase(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
    }

    public async Task<ResponseSignUpUserJson> Execute(RequestSignUpUserJson request)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);
        if (existingUser != null)
        {
            throw new InvalidOperationException("Email already in use.");
        }

        var user = new User(
            request.Username,
            request.Email,
            _passwordHasher.HashPassword(request.Password),
            request.Role
        );

        await _userRepository.CreateAsync(user);

        return new ResponseSignUpUserJson(
            user.Username,
            user.Email,
            user.Role
        );
    }
}

