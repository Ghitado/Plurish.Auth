using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Plurish.Auth.Application.Services.Cryptography;

namespace Plurish.Auth.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AddPasswordEncripter(services, configuration);
    }

    private static void AddPasswordEncripter(IServiceCollection services, IConfiguration configuration)
    {
        var additionalKey = configuration.GetValue<string>("Setting:Password:AdditionalKey");

        services.AddScoped(option => new PasswordEncripter(additionalKey!));
    }
}

