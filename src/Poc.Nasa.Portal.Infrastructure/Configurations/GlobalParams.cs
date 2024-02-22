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

    // RabbitMQ
    public static string RabbitVHost(this IConfiguration configuration) =>
        configuration.GetValue<string>("RABBITMQ_VHOST");
    public static string RabbitHostname(this IConfiguration configuration) =>
        configuration.GetValue<string>("RABBITMQ_SERVER");
    public static string RabbitUsername(this IConfiguration configuration) =>
        configuration.GetValue<string>("RABBITMQ_USERNAME");
    public static string RabbitPassord(this IConfiguration configuration) =>
        configuration.GetValue<string>("RABBITMQ_PASSWORD");

    public static string RabbitQueuePictureOfTheDay(this IConfiguration configuration) =>
        configuration.GetValue<string>("RABBITMQ_PICTURE_OF_THE_DAY_QUEUE");
    public static string RabbitExchangePictureOfTheDay(this IConfiguration configuration) =>
        configuration.GetValue<string>("RABBITMQ_PICTURE_OF_THE_DAY_EXCHANGE");
    public static string RabbitRoutingKeyPictureOfTheDay(this IConfiguration configuration) =>
        configuration.GetValue<string>("RABBITMQ_PICTURE_OF_THE_DAY_ROUTING_KEY");
}