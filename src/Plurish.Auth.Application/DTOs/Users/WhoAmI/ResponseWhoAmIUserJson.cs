namespace Plurish.Auth.Application.DTOs.Users.WhoAmI;
public record ResponseWhoAmIUserJson(
    string Username,
    string Email,
    string Role
);
