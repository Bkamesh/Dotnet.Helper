using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Hosting;
using Prometheus;

namespace dotnet.helper.Extensions;

public static class ApplicationExtensions
{
    public static void AddForwardedHeaders(this IApplicationBuilder app)
    {
       app.UseForwardedHeaders(new ForwardedHeadersOptions
       {
           ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
       });
    }

    public static void UseCustomCores(this IApplicationBuilder app, string CorsPolicyName)
    {
        app.UseCors(CorsPolicyName);
    }
    
    public static void AddSwagger(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (!env.IsProduction())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }

    public static void UsePrometheusMontoring(this IApplicationBuilder app)
    {
       app.UseHttpMetrics();
       app.UseMetricServer();
    }

    public static void UseHealthCheck(this IApplicationBuilder app)
    {
        app.UseHealthChecks("/health/live", new HealthCheckOptions
        {
            Predicate = check => check.Tags.Contains("liveness")
        });

        app.UseHealthChecks("/health/ready", new HealthCheckOptions
        {
            Predicate = check => check.Tags.Contains("readiness")
        });
    }

}