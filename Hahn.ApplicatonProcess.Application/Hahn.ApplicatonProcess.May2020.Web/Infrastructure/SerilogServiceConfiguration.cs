using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Hahn.ApplicatonProcess.May2020.Infrastructure
{
    public static class SerilogServiceConfiguration
    {
        public static IServiceCollection ConfigureSerilog(this IServiceCollection services, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration, "Serilog")
                .CreateLogger();

            return services.AddSingleton(Log.Logger);
        }
    }
}