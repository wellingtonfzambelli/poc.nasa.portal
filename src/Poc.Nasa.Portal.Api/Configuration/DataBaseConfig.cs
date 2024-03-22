using Microsoft.EntityFrameworkCore;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using Poc.Nasa.Portal.Infrastructure.Context;

namespace Poc.Nasa.Portal.Api.Configuration;

public static class DataBaseConfig
{
    public static void AddDatabasesConfiguration(this IServiceCollection services, IConfiguration config)
    {
        string connection = config.ConnectionString();
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));

        services.AddDbContext<NasaPortalContext>(options =>
            options.UseMySql(connection, serverVersion));

        services.AddDbContext<IdentityDataContext>(options =>
            options.UseMySql(connection, serverVersion));
    }
}