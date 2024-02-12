using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Poc.Nasa.Portal.Api.Shared;

public abstract class AstronomyBaseController : ControllerBase
{
    protected const string TrackId = "track-id";
    protected readonly IMediator Mediator;

    protected AstronomyBaseController(IMediator mediator) =>
        Mediator = mediator;
}