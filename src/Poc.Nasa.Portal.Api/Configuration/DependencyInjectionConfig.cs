using FluentValidation;
using MediatR;
using Poc.Nasa.Portal.App.AutoMapper;
using Poc.Nasa.Portal.App.Nasa.AstronomyPicture.GetAllPictureOfTheDay;
using Poc.Nasa.Portal.App.Nasa.AstronomyPicture.GetPictureOfTheDay;
using Poc.Nasa.Portal.App.Nasa.Authentication.Login;
using Poc.Nasa.Portal.App.Nasa.Authentication.SignUp;
using Poc.Nasa.Portal.App.Nasa.Dashboard;
using Poc.Nasa.Portal.Infrastructure.Cache;
using Poc.Nasa.Portal.Infrastructure.UnitOfWork;

namespace Poc.Nasa.Portal.Api.Configuration;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<GetPictureOfTheDayValidator>();
        services.AddValidatorsFromAssemblyContaining<LoginValidator>();
        services.AddValidatorsFromAssemblyContaining<SignupValidator>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        services.AddAutoMapper(typeof(ConfigurationMapping));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICacheService, CacheService>();

        services.AddScoped<IRequestHandler<GetPictureOfTheDayRequestHandlerDto, GetPictureOfTheDayResponseHandlerDto>, GetPictureOfTheDayHandler>();
        services.AddScoped<IRequestHandler<GetAllPictureOfTheDayRequestHandlerDto, GetAllPictureOfTheDayResponseHandlerDto>, GetAllPictureOfTheDayHandler>();
        services.AddScoped<IRequestHandler<DashboardRequestHandlerDto, DashboardResponseHandlerDto>, DashboardHandler>();
        services.AddScoped<IRequestHandler<LoginRequestHandlerDto, LoginResponseHandlerDto>, LoginHandler>();
        services.AddScoped<IRequestHandler<SignupRequestHandlerDto, SignupResponseHandlerDto>, SignupHandler>();
    }
}