using Microsoft.Extensions.Configuration;

namespace Poc.Nasa.Portal.Infrastructure.Configurations;

public static class GlobalParams
{
    // MySQL
    public static string ConnectionString(this IConfiguration configuration) =>
        configuration.GetValue<string>("CONNECTIONSTRING");

    // API NASA
    public static string ApiNasaAddress(this IConfiguration configuration) =>
        configuration.GetValue<string>("API_NASA_ADDRESS");
    public static string ApiNasaApiKey(this IConfiguration configuration) =>
        configuration.GetValue<string>("API_NASA_APIKEY");
}