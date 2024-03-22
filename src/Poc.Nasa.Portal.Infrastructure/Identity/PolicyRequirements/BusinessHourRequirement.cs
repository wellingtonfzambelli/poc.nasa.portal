using Microsoft.AspNetCore.Authorization;

namespace Poc.Nasa.Portal.Infrastructure.Identity.PolicyRequirements;

public sealed class BusinessHourRequirement : IAuthorizationRequirement
{
    public BusinessHourRequirement() { }
}