using Microsoft.AspNetCore.Authorization;

namespace Poc.Nasa.Portal.Infrastructure.Identity.PolicyRequirements;

public sealed class BusinessHourHandler : AuthorizationHandler<BusinessHourRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BusinessHourRequirement requirement)
    {
        var currentHour = TimeOnly.FromDateTime(DateTime.Now);
        if (currentHour.Hour >= 8 && currentHour.Hour <= 18)
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}