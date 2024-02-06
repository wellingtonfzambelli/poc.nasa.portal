using Microsoft.Extensions.Configuration;

namespace Poc.Nasa.Portal.Infrastructure.Configurations;

public static class GlobalParams
{
    // MySQL
    public static string ConnectionString(this IConfiguration configuration) =>
        configuration.GetValue<string>("CONNECTIONSTRING");

    // API NASA
    public static string ApiServerNASA(this IConfiguration configuration) =>
        configuration.GetValue<string>("API_SERVER_NASA");
}