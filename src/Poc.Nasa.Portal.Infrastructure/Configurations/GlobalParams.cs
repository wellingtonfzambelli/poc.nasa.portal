using Microsoft.Extensions.Configuration;

namespace Poc.Nasa.Portal.Infrastructure.Configurations;

public static class GlobalParams
{
    // JWT
    public static string JwtSecret(this IConfiguration configuration) =>
        configuration.GetValue<string>("JWT_SECRET") ?? throw new NullReferenceException();
    public static string JwtAudience(this IConfiguration configuration) =>
        configuration.GetValue<string>("JWT_AUDIENCE") ?? throw new NullReferenceException();
    public static string JwtIssuer(this IConfiguration configuration) =>
        configuration.GetValue<string>("JWT_ISSUER") ?? throw new NullReferenceException();
    public static int JwtExpiresInMinutes(this IConfiguration configuration) =>
        configuration.GetValue<int?>("JWT_EXPIRES_IN_MINUTES") ?? throw new NullReferenceException();

    // MySQL
    public static string ConnectionString(this IConfiguration configuration) =>
        configuration.GetValue<string>("CONNECTIONSTRING") ?? throw new NullReferenceException();

    // API NASA
    public static string ApiNasaAddress(this IConfiguration configuration) =>
        configuration.GetValue<string>("API_NASA_ADDRESS") ?? throw new NullReferenceException();
    public static string ApiNasaApiKey(this IConfiguration configuration) =>
        configuration.GetValue<string>("API_NASA_APIKEY") ?? throw new NullReferenceException();

    // Redis
    public static string RedisServer(this IConfiguration configuration) =>
        configuration.GetValue<string>("REDIS_SERVER") ?? throw new NullReferenceException();

    // RabbitMQ
    public static string RabbitVHost(this IConfiguration configuration) =>
        configuration.GetValue<string>("RABBITMQ_VHOST") ?? throw new NullReferenceException();
    public static string RabbitHostname(this IConfiguration configuration) =>
        configuration.GetValue<string>("RABBITMQ_SERVER") ?? throw new NullReferenceException();
    public static string RabbitUsername(this IConfiguration configuration) =>
        configuration.GetValue<string>("RABBITMQ_USERNAME") ?? throw new NullReferenceException();
    public static string RabbitPassord(this IConfiguration configuration) =>
        configuration.GetValue<string>("RABBITMQ_PASSWORD") ?? throw new NullReferenceException();

    public static string RabbitQueuePictureOfTheDay(this IConfiguration configuration) =>
        configuration.GetValue<string>("RABBITMQ_PICTURE_OF_THE_DAY_QUEUE") ?? throw new NullReferenceException();
    public static string RabbitExchangePictureOfTheDay(this IConfiguration configuration) =>
        configuration.GetValue<string>("RABBITMQ_PICTURE_OF_THE_DAY_EXCHANGE") ?? throw new NullReferenceException();
    public static string RabbitRoutingKeyPictureOfTheDay(this IConfiguration configuration) =>
        configuration.GetValue<string>("RABBITMQ_PICTURE_OF_THE_DAY_ROUTING_KEY") ?? throw new NullReferenceException();

    // Consumer - PictureOfTheDay
    public static int WaitInMillisecondsConsumer(this IConfiguration configuration) =>
        configuration.GetValue<int?>("CONSUMER_WAIT_IN_MILLISECONDS") ?? throw new NullReferenceException();
}