using Poc.Nasa.Portal.Api.Filters;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

//var logger = new LoggerConfiguration()
//    .WriteTo.Console(
//        restrictedToMinimumLevel: LogEventLevel.Information,
//        theme: AnsiConsoleTheme.Code)
//    .CreateLogger();

//var logger = new LoggerConfiguration()
//    .ReadFrom.Configuration(builder.Configuration)
//    .Enrich.FromLogContext()
//    .WriteTo.MySQL("server=127.0.0.1;User Id=root;password=root;Persist Security Info=True;database=loterias;", "EventLog")
//    .CreateLogger();
//builder.Logging.ClearProviders();
//builder.Logging.AddSerilog(logger);



//var logger = new LoggerConfiguration()
//    .ReadFrom.Configuration(builder.Configuration)
//    .MinimumLevel.Information()
//    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
//    .MinimumLevel.Override("System", LogEventLevel.Information)
//    .Enrich.FromLogContext()
//    .WriteTo.Console()
//    .WriteTo.MySQL(
//        "server=127.0.0.1;User Id=root;password=root;Persist Security Info=True;database=loterias;",
//        "EventLog")
//    .CreateLogger();




//builder.Host.UseSerilog((context, configuration) =>
//    configuration
//    .Enrich.FromLogContext()
//    .Enrich.
//    .MinimumLevel.Information()
//    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
//    .MinimumLevel.Override("System", LogEventLevel.Information)

//    .WriteTo.Console()
//    .WriteTo.MySQL("server=127.0.0.1;User Id=root;password=root;Persist Security Info=True;database=loterias;", "EventLog"));

// Add services to the container.
builder.Services.AddControllers(config =>
{
    config.Filters.Add(typeof(ExceptionFilter));
}).AddJsonOptions(opts => opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();