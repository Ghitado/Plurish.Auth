namespace Plurish.Auth.Application.DTOs.Users.SignIn;
public record ResponseSignInUserJson(
        string AccessToken,
        string RefreshToken
    );

