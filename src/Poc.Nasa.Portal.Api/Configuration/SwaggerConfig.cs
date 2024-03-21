using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Poc.Nasa.Portal.Api.Configuration;

public static class SwaggerConfig
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "POC Nasa Portal",
                    Version = "v1",
                    Description = "Api to get NASA data",
                    Contact = new OpenApiContact
                    {
                        Name = "Wellington Zambelli",
                        Email = "wellington.f.zambelli@gmail.com",
                        Url = new Uri("https://github.com/wellingtonfzambelli")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "OSD",
                        Url = new Uri("https://opensource.org/osd")
                    },
                    TermsOfService = new Uri("https://opensource.org/osd")
                });

            // Authentication - JWT
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Insert the token",
                Name = "POC Nasa Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[]{ }
            }
        });

            // Eanble the xml on visual studio -> right click on solution -> properties -> builder -> check the checkbox 'documentation file' or 'xml'
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });
    }

    public static void UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}