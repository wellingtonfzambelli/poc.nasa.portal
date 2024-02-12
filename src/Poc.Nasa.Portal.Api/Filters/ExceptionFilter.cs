using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Poc.Nasa.Portal.App.Shared.Dt;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using System.Net;

namespace Poc.Nasa.Portal.Api.Filters;

internal sealed class ExceptionFilter : IExceptionFilter
{
    private readonly ILogger<ExceptionFilter> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ExceptionFilter(ILogger<ExceptionFilter> logger, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }

    public void OnException(ExceptionContext context)
    {
        var correlationId = _httpContextAccessor?.HttpContext?.Request.Headers["track-id"].ToString();

        if (correlationId is null)
            correlationId = Guid.NewGuid().ToString();

        var response = context.HttpContext.Response;

        response.StatusCode = (int)HttpStatusCode.BadRequest;
        response.ContentType = "application/json";
        context.ExceptionHandled = true;
        context.Result = new BadRequestObjectResult(
            new[]
            {
                new BadRequestDto
                {
                    Code = MessageValidation.GeneralError.code,
                    Message = MessageValidation.GeneralError.description
                }
            });

        _logger.LogError(context.Exception, null);
    }
}