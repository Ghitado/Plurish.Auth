using Plurish.Auth.Application.DTOs.Users.SignUp;

namespace Plurish.Auth.Application.UseCases.Users.Register;
public interface ISignUpUserUseCase
{
    Task<ResponseSignUpUserJson> Execute(RequestSignUpUserJson request);
}


