using Hahn.ApplicatonProcess.May2020.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicatonProcess.May2020.Domain
{
    public static class SwaggerExamplesServiceConfiguration
    {
        public static IServiceCollection ConfigureSwaggerExamples(this IServiceCollection services)
        {
            services.AddSwaggerExamplesFromAssemblyOf<Applicant>();
            return services;
        }
    }
}
