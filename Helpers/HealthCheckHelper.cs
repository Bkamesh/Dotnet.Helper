using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace dotnet.helper.HealthCheckHelpers;

public class CustomHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        //health check logic can be added here
        return Task.FromResult(HealthCheckResult.Healthy("The service is healthy."));
    }
}

