using Plurish.Auth.Application.DTOs.Users.SignOut;

namespace Plurish.Auth.Application.UseCases.Users.SignOut;
public interface ISignOutUserUseCase
{
    public Task<ResponseSignOutUserJson> Execute(RequestSignOutUserJson request);
}

