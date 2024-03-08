using MediatR;

namespace Poc.Nasa.Portal.App.Nasa.Dashboard;

public sealed class DashboardRequestHandlerDto : IRequest<DashboardResponseHandlerDto>
{
    public DashboardRequestHandlerDto(Guid trackId) =>
        TrackId = trackId;

    public Guid TrackId { get; set; }
}