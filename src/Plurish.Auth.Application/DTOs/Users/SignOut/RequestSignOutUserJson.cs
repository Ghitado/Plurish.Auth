using Plurish.Auth.Application.Validation;
using System.ComponentModel.DataAnnotations;

namespace Plurish.Auth.Application.DTOs.Users.SignOut;
public record RequestSignOutUserJson(
        [Required(ErrorMessage = ValidationMessages.RequiredField)]
        string AccessToken
    );

