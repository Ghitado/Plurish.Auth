using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Plurish.Auth.Domain.Repositories;
using Plurish.Auth.Infrastructure.DataAccess;
using Plurish.Auth.Infrastructure.Extensions;
using Plurish.Auth.Infrastructure.Repositories;

namespace Plurish.Auth.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext_SqlServer(services, configuration);
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }

    private static void AddDbContext_SqlServer(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.ConnectionString(); 

        services.AddDbContext<AuthDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }
}

 