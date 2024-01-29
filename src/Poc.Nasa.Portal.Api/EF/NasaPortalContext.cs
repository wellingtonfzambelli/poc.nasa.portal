using Microsoft.EntityFrameworkCore;

namespace Poc.Nasa.Portal.Api.EF;

public sealed class NasaPortalContext : DbContext
{
    public NasaPortalContext(DbContextOptions<NasaPortalContext> options) : base(options) { }
}