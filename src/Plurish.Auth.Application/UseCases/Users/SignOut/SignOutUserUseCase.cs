using Plurish.Auth.Application.DTOs.Users.SignOut;
using Plurish.Auth.Domain.Services;

namespace Plurish.Auth.Application.UseCases.Users.SignOut;
public class SignOutUserUseCase : ISignOutUserUseCase
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public SignOutUserUseCase(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator ?? throw new ArgumentNullException(nameof(jwtTokenGenerator));
    }

    public async Task<ResponseSignOutUserJson> Execute(RequestSignOutUserJson request)
    {
        // Em uma implementação real, você pode querer adicionar tokens à uma blacklist ou realizar
        // algum outro processo para invalidar o token. Neste exemplo, consideramos que, após o logout,
        // o token é simplesmente ignorado no lado do cliente.

        // O processo de "logout" normalmente envolve remover o token do lado do cliente.
        // Para fins desse exemplo, vamos simplesmente retornar um sucesso.

        return new ResponseSignOutUserJson(Success: true);
    }
}
