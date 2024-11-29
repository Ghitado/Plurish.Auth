using Plurish.Auth.Application.DTOs.Users.WhoAmI;

namespace Plurish.Auth.Application.UseCases.Users.WhoAmI;
public interface IWhoAmIUserUseCase
{
    Task<ResponseWhoAmIUserJson> Execute(RequestWhoAmIUserJson request);
}
