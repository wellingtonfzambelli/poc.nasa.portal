using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Poc.Nasa.Portal.Api.Filters;

internal sealed class ClaimAuthorizeAttribute : TypeFilterAttribute
{
    public ClaimAuthorizeAttribute(string claimType, string claimValue) : base(typeof(ClaimRequirementFilter)) =>
        Arguments = new object[] { new Claim(claimType, claimValue) };
}

public class ClaimRequirementFilter : IAuthorizationFilter
{
    private readonly Claim _claim;

    public ClaimRequirementFilter(Claim claim) =>
        _claim = claim;

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User as ClaimsPrincipal;

        if (user == null || !user.Identity.IsAuthenticated)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        if (!user.HasClaim(_claim.Type, _claim.Value))
            context.Result = new ForbidResult();
    }
}