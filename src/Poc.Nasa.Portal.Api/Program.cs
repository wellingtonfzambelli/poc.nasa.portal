using Poc.Nasa.Portal.Api.Configuration;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using Serilog;

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

// ConfigureServices
// Add services to the container.
builder.Services.AddControllerConfiguration();
builder.Services.AddDatabasesConfiguration(_configuration);
builder.Services.AddIdentityConfiguration();
builder.Services.AddAuthorizationPolicies();
builder.Services.AddJwtConfiguration(_configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddClientConfiguration(_configuration);
builder.Services.AddRabbitConfiguration(_configuration);
builder.Services.AddRedisConfiguration(_configuration);
builder.Services.AddHealthCheckConfiguration(_configuration);
builder.Services.AddCorsConfiguration(_configuration);
builder.AddSerilogConfiguration(_path, _configuration);
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

// Configure
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) { }

app.UseSwaggerConfiguration();
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseJwtConfiguration();
app.MapControllers();
app.UseCors(_configuration.CorsName());
app.UseHealthCheckConfiguration();
app.Run();