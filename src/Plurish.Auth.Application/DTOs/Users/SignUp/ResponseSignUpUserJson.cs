using Plurish.Auth.Domain.Enums;

namespace Plurish.Auth.Application.DTOs.Users.SignUp;
public record ResponseSignUpUserJson(
        string Username,
        string Email,
        Role Role
    );

