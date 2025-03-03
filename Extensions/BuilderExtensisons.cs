using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Prometheus;

namespace dotnet.helper.Extensions;

public static class BuilderExtensions
{
    public static void AddRedisCache(this IServiceCollection services, IConfiguration configuration, string applicationName)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetValue<string>("Redis:Configuration");
            options.InstanceName = applicationName;
        });
    }


    public static void AddSqlServerDbContext<T>(this IServiceCollection services, string ConnectionString) where T : DbContext
    {
        services.AddDbContext<T>(options =>
        {
            options.UseSqlServer(ConnectionString, options => 
            {
                options.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
            }).UseSnakeCaseNamingConvention();

        });
    }

    public static void AddPostgresDbContext<T>(this WebApplicationBuilder builder, string connectionString) where T : DbContext
    {
        builder.Services.AddDbContext<T>(options =>
        {
            options.UseNpgsql(connectionString, npgsqlOptions =>
            {
                npgsqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
            }).UseSnakeCaseNamingConvention();
        });
    }


   public static void AddPostgreslog(this WebApplicationBuilder builder, string connectionString, string tableName="logs",string schema="logs")
   {
       builder.Logging.ClearProviders();
       builder.Logging.AddSerilog(new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.PostgreSQL(connectionString, tableName, schemaName: schema, needAutoCreateTable : true)
                .CreateLogger());
   }

   public static void AddMongoDblog(this WebApplicationBuilder builder, string connectionString, string tableName="logs")
   {
       builder.Logging.ClearProviders();
       builder.Logging.AddSerilog(new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.MongoDBBson(connectionString, tableName)
                .CreateLogger());
   }

   public static void AddRedinessAndLivenessCheck(this WebApplicationBuilder builder)
   {
    
     builder.Services.AddHealthChecks()
        .AddCheck("Liveness", () => HealthCheckResult.Healthy(), tags: new[] { "liveness" })
        .AddCheck("Readiness", () => HealthCheckResult.Healthy(), tags: new[] { "readiness" });
   }

   public static void AddPrometheusMonitoring(this WebApplicationBuilder builder)
   {
        builder.Services.UseHttpClientMetrics();
   }

    public static void RegisterApplication(this WebApplicationBuilder builder, Dictionary<Type, Type> applications)
    {
        foreach (var application in applications)
        {
            builder.Services.AddSingleton(application.Key, application.Value);
        }
    }

    public static void CustomCorsOrigin(this WebApplicationBuilder builder,string CorsPolicyName)
    {
        var Origins = builder.Configuration.GetValue<string>("Cors:Origins")?.Split(';') ?? new string[] { "" };
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicyName, builder => builder
                .WithOrigins(Origins)
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
    }
}
