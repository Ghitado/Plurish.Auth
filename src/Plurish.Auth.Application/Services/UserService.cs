
using Plurish.Auth.Domain.Entities;
using Plurish.Auth.Domain.Repositories;
using Plurish.Auth.Domain.Services;
using System;

namespace Plurish.Auth.Application.Services;
public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
    }

    public async Task<bool> RegisterUserAsync(User user, string password)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));

        var existingUser = await _userRepository.GetByUsernameOrEmailAsync(user.Email);
        if (existingUser != null) throw new InvalidOperationException("Email already in use");

        user.Password = _passwordHasher.HashPassword(password);

        return await _userRepository.CreateAsync(user);
    }

    public async Task<User> AuthenticateAsync(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            throw new ArgumentException("Email and password must be provided.");

        var user = await _userRepository.GetByUsernameOrEmailAsync(email);

        if (user == null)
            throw new InvalidOperationException("Invalid email or password.");

        if (!_passwordHasher.VerifyPassword(user.Password, password))
            throw new InvalidOperationException("Invalid email or password.");

        return user;
    }
}
