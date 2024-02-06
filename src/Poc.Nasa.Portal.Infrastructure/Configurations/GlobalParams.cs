using Microsoft.Extensions.Configuration;

namespace Poc.Nasa.Portal.Infrastructure.Configurations;

public static class GlobalParams
{
    // SqlServer - Cash
    public static string ConnectionString(IConfiguration configuration) =>
        configuration.GetValue<string>("CONNECTION");
}