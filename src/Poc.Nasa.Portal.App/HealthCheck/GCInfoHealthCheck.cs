using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;

namespace Poc.Nasa.Portal.App.HealthCheck;

public sealed class GCInfoHealthCheck : IHealthCheck
{
    private readonly IOptionsMonitor<GCInfoOptions> _options;

    public GCInfoHealthCheck(IOptionsMonitor<GCInfoOptions> options) =>
        _options = options;

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken ct = default)
    {
        try
        {
            var options = _options.Get(context.Registration.Name);
            // This example will report degraded status if the application is using
            // more than the configured amount of memory (1gb by default).
            // Additionally we include some GC info in the reported diagnostics.
            var allocatedByte = GC.GetTotalMemory(forceFullCollection: false);
            var allocatedMb = (GC.GetTotalMemory(forceFullCollection: false) / 1024f) / 1024f;
            var msg = "Allocated (MB): " + allocatedMb + " - Allocated (Byte): " + allocatedByte;
            var data = new Dictionary<string, object>()
                    {
                        { "Allocated (MB)", allocatedMb },
                        { "Allocated (Byte)", allocatedByte },
                        { "Gen0Collections", GC.CollectionCount(0) },
                        { "Gen1Collections", GC.CollectionCount(1) },
                        { "Gen2Collections", GC.CollectionCount(2) },
                    };

            // Report failure if the allocated memory is >= the threshold.
            // Using context.Registration.FailureStatus means that the application developer can configure
            // how they want failures to appear.
            var result = allocatedByte >= options.Threshold ? context.Registration.FailureStatus : HealthStatus.Healthy;

            return Task.FromResult(new HealthCheckResult(
                result,
                description: msg,
                data: data));
        }
        catch (Exception ex)
        {
            return Task.FromResult(new HealthCheckResult(HealthStatus.Degraded, exception: ex));
        }
    }
}

public sealed class GCInfoOptions
{
    public long Threshold { get; set; } = 1024L * 1024L * 1024L;
}