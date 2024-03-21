using Microsoft.EntityFrameworkCore;
using Poc.Nasa.Portal.Infrastructure.Configurations;

namespace Poc.Nasa.Portal.Api.Configuration;

public static class MySqlConfig
{
    public static void AddMySqlConfiguration(this IServiceCollection services, IConfiguration config)
    {
        string connection = config.ConnectionString();
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));
        services.AddDbContext<NasaPortalContext>(o => o.UseMySql(connection, serverVersion));
    }
}