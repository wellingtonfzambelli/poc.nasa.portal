using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;

namespace Poc.Nasa.Portal.Infrastructure.DI;

public static class CommonServiceCollectionExtensions
{
    public static void AddCommonServiceCollection(this IServiceCollection services)
    {
        AddLogging(services);
    }

    static void AddLogging(IServiceCollection services)
    {
        var loggerConfig = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.MySQL(
                "server=127.0.0.1;User Id=root;password=root;Persist Security Info=True;database=loterias;",
                "EventLog3")
            .CreateLogger();

        services.AddSingleton<ILoggerFactory>(new SerilogLoggerFactory(loggerConfig));
    }
}