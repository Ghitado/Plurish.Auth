namespace Plurish.Auth.Application.Validation;
public static class ValidationMessages
{
    public const string RequiredField = "This field is required.";
    public const string MaxUsernameLength = "Username must be at most 100 characters.";
    public const string InvalidEmail = "Invalid email format.";
    public const string PasswordLength = "Password must be between 6 and 50 characters.";
    public const string InvalidRole = "Invalid role.";
}
