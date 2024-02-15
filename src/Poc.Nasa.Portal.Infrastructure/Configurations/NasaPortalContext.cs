using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Poc.Nasa.Portal.Domain.Models.PictureOfTheDayAggregate;
using Poc.Nasa.Portal.Infrastructure.Domain.Models.PictureOfTheDayAggregate;

namespace Poc.Nasa.Portal.Infrastructure.Configurations;

public sealed class NasaPortalContext : DbContext
{
    private readonly ILoggerFactory _loggerFactory;

    public NasaPortalContext
    (
        DbContextOptions<NasaPortalContext> options,
        ILoggerFactory loggerFactory = null
    ) : base(options) =>
        _loggerFactory = loggerFactory;

    public DbSet<PictureOfTheDay> PictureOfTheDay { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_loggerFactory != null)
            optionsBuilder
                //.UseMySql("")
                .UseLoggerFactory(_loggerFactory)
                .EnableSensitiveDataLogging(false);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new PictureOfTheDayBuilder().Build(modelBuilder.Entity<PictureOfTheDay>());

        base.OnModelCreating(modelBuilder);
    }
}