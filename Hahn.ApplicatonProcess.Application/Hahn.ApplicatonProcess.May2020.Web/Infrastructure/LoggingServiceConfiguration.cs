using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Hahn.ApplicatonProcess.May2020.Infrastructure
{
    public static class LoggingServiceConfiguration
    {
        public static IServiceCollection ConfigureLogging(this IServiceCollection services,
            IConfiguration configuration)
        {
            var loggingConfiguration = configuration.GetSection("logging");
            return services.AddLogging(c => c.AddConfiguration(loggingConfiguration)
                .AddFilter("Microsoft", LogLevel.Information)
                .AddFilter("System", LogLevel.Error));
        }
    }
}