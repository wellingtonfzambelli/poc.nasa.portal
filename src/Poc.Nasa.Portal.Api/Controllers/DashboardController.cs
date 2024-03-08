using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poc.Nasa.Portal.Api.Controllers.Base;
using Poc.Nasa.Portal.App.Nasa.Dashboard;
using Poc.Nasa.Portal.App.Shared.Dt;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Poc.Nasa.Portal.Api.Controllers;

[ApiController]
[Route("nasa/v1")]
public sealed class DashboardController : AstronomyBaseController
{
    public DashboardController(IMediator mediator) : base(mediator)
    { }

    [HttpGet]
    [Route("dashboard")]
    [ProducesResponseType(typeof(DashboardResponseHandlerDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BadRequestDto), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetDashboardAsync
    (
        [FromHeader(Name = TrackId)][Required] Guid trackId,
        CancellationToken ct
    )
    {
        var response = base.Mediator.Send(
            new DashboardRequestHandlerDto(trackId),
            ct);

        if (response.Result.IsValid())
            return Ok(response.Result);

        return BadRequest(response.Result.GetErrors());
    }
}