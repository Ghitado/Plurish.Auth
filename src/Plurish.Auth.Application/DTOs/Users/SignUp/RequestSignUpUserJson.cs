using Plurish.Auth.Application.Validation;
using Plurish.Auth.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Plurish.Auth.Application.DTOs.Users.SignUp;
public record RequestSignUpUserJson(
    [Required(ErrorMessage = ValidationMessages.RequiredField)]
    [StringLength(100, ErrorMessage = ValidationMessages.MaxUsernameLength)]
    string Username,

    [Required(ErrorMessage = ValidationMessages.RequiredField)]
    [EmailAddress(ErrorMessage = ValidationMessages.InvalidEmail)]
    string Email,

    [Required(ErrorMessage = ValidationMessages.RequiredField)]
    [StringLength(50, MinimumLength = 6, ErrorMessage = ValidationMessages.PasswordLength)]
    string Password,

    [Required(ErrorMessage = ValidationMessages.RequiredField)]
    [EnumDataType(typeof(Role), ErrorMessage = ValidationMessages.InvalidRole)]
    Role Role
);


