using Serilog;

namespace Poc.Nasa.Portal.Api.Configuration;

public static class SerilogConfig
{
    public static void AddSerilogConfiguration(this WebApplicationBuilder builder, string path, IConfiguration config) =>
        builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration)
            //.MinimumLevel.Information()
            //.MinimumLevel.Override("Microsoft", LogEventLevel.Error)
            //.MinimumLevel.Override("System", LogEventLevel.Error)
            //.Enrich.FromLogContext()
            //.WriteTo.Console()
            //.WriteTo.File(
            //    path: $"{path}\\logs\\log.txt",
            //    rollingInterval: RollingInterval.Day,
            //    outputTemplate: "{Timestamp:HH:mm} [{Level}] ({ThreadId}) {Message}{NewLine}{Exception}")
            //.WriteTo.MySQL(config.ConnectionString(), "EventLog")
            );
}