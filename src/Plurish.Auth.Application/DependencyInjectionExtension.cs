using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Plurish.Auth.Application.Services;
using Plurish.Auth.Application.Services.Cryptography;
using Plurish.Auth.Application.Services.Tokens;
using Plurish.Auth.Application.UseCases.Users.Register;
using Plurish.Auth.Application.UseCases.Users.SignIn;
using Plurish.Auth.Application.UseCases.Users.SignOut;
using Plurish.Auth.Application.UseCases.Users.WhoAmI;
using Plurish.Auth.Domain.Services;

namespace Plurish.Auth.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AddPasswordEncripter(services, configuration);
        AddUseCases(services);
        AddServices(services);
    }

    private static void AddPasswordEncripter(IServiceCollection services, IConfiguration configuration)
    {
        var additionalKey = configuration.GetValue<string>("Settings:Password:AdditionalKey");

        services.AddScoped(option => new PasswordEncripter(additionalKey!));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<ISignUpUserUseCase, SignUpUserUseCase>();
        services.AddScoped<ISignInUserUseCase, SignInUserUseCase>();
        services.AddScoped<ISignOutUserUseCase, SignOutUserUseCase>();
        services.AddScoped<IWhoAmIUserUseCase, WhoAmIUserUseCase>();
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
    }
}
