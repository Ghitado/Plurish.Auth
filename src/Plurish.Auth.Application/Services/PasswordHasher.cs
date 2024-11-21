using Plurish.Auth.Application.Services.Cryptography;
using Plurish.Auth.Domain.Services;

namespace Plurish.Auth.Application.Services;
public class PasswordHasher : IPasswordHasher
{
    private readonly PasswordEncripter _passwordEncripter;

    public PasswordHasher(PasswordEncripter passwordEncripter)
    {
        _passwordEncripter = passwordEncripter ?? throw new ArgumentNullException(nameof(passwordEncripter));
    }

    public string HashPassword(string password)
    {
        return _passwordEncripter.Encrypt(password);
    }

    public bool VerifyPassword(string hashedPassword, string providedPassword)
    {
        var encryptedProvidedPassword = _passwordEncripter.Encrypt(providedPassword);

        return hashedPassword == encryptedProvidedPassword;
    }
}

