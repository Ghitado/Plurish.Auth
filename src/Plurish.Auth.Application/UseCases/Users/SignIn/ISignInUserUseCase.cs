using Plurish.Auth.Application.DTOs.Users.SignIn;

namespace Plurish.Auth.Application.UseCases.Users.SignIn;
public interface ISignInUserUseCase
{
    Task<ResponseSignInUserJson> Execute(RequestSignInUserJson request);
}
