using Plurish.Auth.Application.Validation;
using System.ComponentModel.DataAnnotations;

namespace Plurish.Auth.Application.DTOs.Users.SignIn;
public record RequestSignInUserJson(
        [Required(ErrorMessage = ValidationMessages.RequiredField)]
        [EmailAddress(ErrorMessage = ValidationMessages.InvalidEmail)]
        string Email,

        [Required(ErrorMessage = ValidationMessages.RequiredField)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = ValidationMessages.PasswordLength)]
        string Password
    );

