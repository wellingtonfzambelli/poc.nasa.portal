using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Poc.Nasa.Portal.Api.Controllers.Base;

[EnableRateLimiting("fixed")]
public abstract class AstronomyBaseController : ControllerBase
{
    protected const string TrackId = "track-id";
    protected readonly IMediator Mediator;

    protected AstronomyBaseController(IMediator mediator) =>
        Mediator = mediator;
}