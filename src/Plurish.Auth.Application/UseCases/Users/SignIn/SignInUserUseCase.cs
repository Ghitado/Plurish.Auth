using Plurish.Auth.Application.DTOs.Users.SignIn;
using Plurish.Auth.Domain.Entities;
using Plurish.Auth.Domain.Repositories;
using Plurish.Auth.Domain.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Plurish.Auth.Application.UseCases.Users.SignIn;
public class SignInUserUseCase : ISignInUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public SignInUserUseCase(IUserRepository userRepository,
                              IPasswordHasher passwordHasher,
                              IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        _jwtTokenGenerator = jwtTokenGenerator ?? throw new ArgumentNullException(nameof(jwtTokenGenerator));
    }

    public async Task<ResponseSignInUserJson> Execute(RequestSignInUserJson request)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user == null)
        {
            throw new InvalidOperationException("Invalid email.");
        }

        var isPasswordValid = _passwordHasher.VerifyPassword(user.Password, request.Password);
        if (!isPasswordValid)
        {
            throw new InvalidOperationException("Invalid password.");
        }

        var accessToken = _jwtTokenGenerator.GenerateAccessToken(user);
        var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();

        return new ResponseSignInUserJson(accessToken, refreshToken);
    }
}
