using Hahn.ApplicatonProcess.May2020.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicatonProcess.May2020.Web.Infrastructure
{
    public static class BusinessServicesConfiguration
    {
        public static IServiceCollection ConfigureBusinessServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IApplicantService, ApplicantService>()
                ;
        }
    }
}