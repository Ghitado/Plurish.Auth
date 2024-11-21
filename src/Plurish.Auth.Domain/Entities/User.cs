using Plurish.Auth.Domain.Enums;

namespace Plurish.Auth.Domain.Entities;

public class User : EntityBase
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public Role Role { get; private set; }

    public string? TwoFactorCode { get; private set; }
    public DateTime? TwoFactorExpiration { get; private set; }

    public User(string name, string email, string password, Role role)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required");
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email is required");
        if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password is required");

        Name = name;
        Email = email;
        Password = password; 
        Role = role;
    }

    public void GenerateTwoFactorCode()
    {
        TwoFactorCode = new Random().Next(100000, 999999).ToString();
        TwoFactorExpiration = DateTime.UtcNow.AddMinutes(5);
    }

    public bool ValidateTwoFactorCode(string code)
    {
        return TwoFactorCode == code && TwoFactorExpiration > DateTime.UtcNow;
    }
}
