using Microsoft.Extensions.Configuration;

namespace Plurish.Auth.Infrastructure.Extensions;
public static class ConfigurationExtension
{
    public static string ConnectionString(this IConfiguration configuration)
    {
        return configuration.GetConnectionString("DefaultConnection")!;
    }
}

