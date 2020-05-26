using AutoMapper;
using Hahn.ApplicatonProcess.May2020.Domain.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicatonProcess.May2020.Web.Infrastructure
{
    public static class AutomapperConfiguration
    {
        public static IServiceCollection ConfigureAutomapper(this IServiceCollection services)
        {
            return services.AddAutoMapper(typeof(EntityModelProfile).Assembly);
        }
    }
}