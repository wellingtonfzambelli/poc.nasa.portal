using Microsoft.AspNetCore.RateLimiting;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using System.Threading.RateLimiting;

namespace Poc.Nasa.Portal.Api.Configuration;

public static class RateLimitConfig
{
    public static void AddRateLimitConfiguration(this IServiceCollection services, IConfiguration config)
    {
        services.AddRateLimiter(options =>
            options.AddFixedWindowLimiter(policyName: "fixed", options =>
            {
                options.PermitLimit = config.RateLimit();
                options.Window = TimeSpan.FromSeconds(config.RateLimitSeconds());
                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                options.QueueLimit = config.RateLimitQueueLimit();
            })
            .OnRejected = async (context, token) =>
            {
                context.HttpContext.Response.StatusCode = 429;
                if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
                {
                    await context.HttpContext.Response.WriteAsync
                    (
                        $"Too many requests. Please try again after {retryAfter.TotalSeconds} seconds.",
                        cancellationToken: token
                    );
                }
                else
                {
                    await context.HttpContext.Response.WriteAsync
                    (
                        $"Too many requests. Please try again later",
                        cancellationToken: token
                    );
                }
            });
    }
}