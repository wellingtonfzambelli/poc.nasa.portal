using Poc.Nasa.Portal.Infrastructure.Configurations;
using Poc.Nasa.Portal.Integration.NasaPortal;
using Poc.Nasa.Portal.Integration.Shared.HttpClientBase;
using System.Net.Http.Headers;

namespace Poc.Nasa.Portal.Api.Configuration;

public static class ClientConfig
{
    public static void AddClientConfiguration(this IServiceCollection services, IConfiguration config)
    {
        var timeout = new TimeSpan(0, 0, 50);
        var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
        var nasaBaseAddress = new Uri($"{config.ApiNasaAddress()}");

        // NASA Api
        services.AddHttpClient(NamedHttpClients.NASA_PORTAL_CLIENT).ConfigureHttpClient(x =>
        {
            x.BaseAddress = nasaBaseAddress;
            x.DefaultRequestHeaders.Accept.Clear();
            x.DefaultRequestHeaders.Accept.Add(mediaType);
            x.Timeout = timeout;
        });

        services.AddScoped<INasaPortalClient>(p =>
            new NasaPortalClient(
                new BaseHttpClient(
                    p.GetService<IHttpClientFactory>().CreateClient(NamedHttpClients.NASA_PORTAL_CLIENT),
                    p.GetService<ILogger<BaseHttpClient>>()
                ),
                p.GetService<ILogger<NasaPortalClient>>(),
                config.ApiNasaApiKey())
            );
    }
}