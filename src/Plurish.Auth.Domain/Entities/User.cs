using Plurish.Auth.Domain.Enums;

namespace Plurish.Auth.Domain.Entities;

public class User : EntityBase
{
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public Role Role { get; private set; }

    public string? TwoFactorCode { get; private set; }
    public DateTime? TwoFactorExpiration { get; private set; }

    public User(string username, string email, string password, Role role)
    {
        Username = username;
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
