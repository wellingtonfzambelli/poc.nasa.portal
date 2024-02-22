using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Poc.Nasa.Portal.Api.Extensions;
using Poc.Nasa.Portal.Api.Filters;
using Poc.Nasa.Portal.App.AutoMapper;
using Poc.Nasa.Portal.App.HealthCheck;
using Poc.Nasa.Portal.App.Nasa.AstronomyPicture;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using Poc.Nasa.Portal.Infrastructure.MessageBroker;
using Poc.Nasa.Portal.Infrastructure.UnitOfWork;
using Poc.Nasa.Portal.Integration.NasaPortal;
using Poc.Nasa.Portal.Integration.Shared.HttpClientBase;
using Serilog;
using Serilog.Events;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();

IConfiguration _configuration = null;
string _path = null;

builder.Host.ConfigureAppConfiguration((hostingContext, configurationBuilder) =>
{
    var env = hostingContext.HostingEnvironment;

    configurationBuilder.SetBasePath(env.ContentRootPath);
    _path = env.ContentRootPath;

    configurationBuilder
        .AddEnvironmentVariables()
        .AddCommandLine(Environment.GetCommandLineArgs());

    _configuration = configurationBuilder.Build();
});

AddSerilog(builder, _path, _configuration);
AddMySQL(builder, _configuration);
HealthCheck(builder, _configuration);

// Add services to the container.
builder.Services.AddControllers(config =>
{
    config.Filters.Add(typeof(ExceptionFilter));
}).AddJsonOptions(opts => opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServiceCollection(builder.Configuration);

// DI
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddScoped<IRequestHandler<AstronomyPictureOfTheDayRequestHandlerDto, AstronomyPictureOfTheDayResponseDto>, AstronomyPictureOfTheDayHandler>();
builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AstronomyPictureOfTheDayValidator>());
builder.Services.AddAutoMapper(typeof(ConfigurationMapping));
AddClient(builder.Services, _configuration);
AddRabbitMQ(builder.Services, _configuration);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();
if (app.Environment.IsDevelopment()) // Configure the HTTP request pipeline.
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseHealthChecks("/nasa/v1/health/live", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = WriteResponse
});
app.UseHealthChecks("/nasa/v1/health/ready", new HealthCheckOptions()
{
    ResponseWriter = (httpContext, result) =>
    {
        httpContext.Response.ContentType = "application/json";

        var json = new JObject(
            new JProperty("status", result.Status.ToString()),
            new JProperty("results", new JObject(result.Entries.Select(pair =>
                new JProperty(pair.Key, new JObject(
                    new JProperty("status", pair.Value.Status.ToString()),
                    new JProperty("description", pair.Value.Description),
                    new JProperty("data", new JObject(pair.Value.Data.Select(
                        p => new JProperty(p.Key, p.Value))))))))));

        return httpContext.Response.WriteAsync(json.ToString(Formatting.Indented));
    }
});
app.Run();

static void AddClient(IServiceCollection services, IConfiguration config)
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

static void AddRabbitMQ(IServiceCollection services, IConfiguration config) =>
    services.AddScoped<ISetupMessageBroker>(p =>
        new SetupMessageBroker(
            config.RabbitHostname(),
            config.RabbitVHost(),
            config.RabbitUsername(),
            config.RabbitPassord())
    );

static void AddSerilog(WebApplicationBuilder builder, string path, IConfiguration config) =>
    builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration)
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
    .MinimumLevel.Override("System", LogEventLevel.Error)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File(
        path: $"{path}\\logs\\log.txt",
        rollingInterval: RollingInterval.Day,
        outputTemplate: "{Timestamp:HH:mm} [{Level}] ({ThreadId}) {Message}{NewLine}{Exception}")
    .WriteTo.MySQL(
        config.ConnectionString(),
    "EventLog"));

static void AddMySQL(WebApplicationBuilder builder, IConfiguration config)
{
    string connection = config.ConnectionString();
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));
    builder.Services.AddDbContext<NasaPortalContext>(o => o.UseMySql(connection, serverVersion));
}

static void HealthCheck(WebApplicationBuilder builder, IConfiguration config)
{
    string rabbitConnection = $"amqps://{builder.Configuration["RABBITMQ_USERNAME"]}:{builder.Configuration["RABBITMQ_PASSWORD"]}@{builder.Configuration["RABBITMQ_SERVER"]}/{builder.Configuration["RABBITMQ_VHOST"]}";

    builder.Services.AddHealthChecks()
    .AddHealthCheckMySql(config.ConnectionString(), name: "MySQL")
    .AddHealthCheckRabbitMQ(rabbitConnection, config, name: "RabbitMQ")
    .AddCheck<GCInfoHealthCheck>("GC");
}

static Task WriteResponse(HttpContext httpContext, HealthReport result)
{
    httpContext.Response.ContentType = "text/plan";
    return httpContext.Response.WriteAsync(result.Status.ToString());
}