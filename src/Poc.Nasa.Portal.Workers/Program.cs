﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using Poc.Nasa.Portal.Infrastructure.MessageBroker;
using Poc.Nasa.Portal.Workers.Consumers.PictureOfTheDay;

namespace Poc.Nasa.Portal.Workers;

public class Program
{
    private static string EnvironmentName => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
               .AddEnvironmentVariables()
               .AddJsonFile("appsettings.json", optional: true)
               .AddJsonFile($"appsettings.{EnvironmentName}.json", optional: true)
               .Build();

    public static async Task Main(string[] args)
    {
        Console.WriteLine("*** Testando o consumo de mensagens com RabbitMQ + Filas ***");

        var host = CreateHostBuilder(args).Build();
        await host.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
         .ConfigureAppConfiguration(builder =>
         {
             builder.Sources.Clear();
             builder.AddConfiguration(Configuration);
         })
        .ConfigureServices((hostContext, services) =>
        {
            services.AddHostedService<PictureOfTheDayConsumer>();
            //services.AddScoped<ISetupMessageBroker, SetupMessageBroker>();
            AddRabbitMQ(services, Configuration);
        });

    static void AddRabbitMQ(IServiceCollection services, IConfiguration config) =>
        services.AddScoped<ISetupMessageBroker>(p =>
            new SetupMessageBroker(
                config.RabbitServer(),
                config.RabbitVHost(),
                config.RabbitUsername(),
                config.RabbitPassord())
        );
}