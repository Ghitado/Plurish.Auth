using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Plurish.Auth.Infrastructure.Extensions;

namespace Plurish.Auth.Infrastructure.DataAccess;
public class DatabaseDesignTimeAuthDbContextFactory : IDesignTimeDbContextFactory<AuthDbContext>
{
    public AuthDbContext CreateDbContext(string[] args)
    {
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "Plurish.Auth.Api");

        IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(basePath) 
        .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true) 
        .Build();

        var builder = new DbContextOptionsBuilder<AuthDbContext>();
        var connectionString = configuration.ConnectionString();
        builder.UseSqlServer(connectionString);
        return new AuthDbContext(builder.Options);
    }
}