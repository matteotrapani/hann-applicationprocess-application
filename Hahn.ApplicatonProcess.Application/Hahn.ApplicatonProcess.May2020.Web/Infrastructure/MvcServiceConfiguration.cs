using Hahn.ApplicatonProcess.May2020.Infrastructure.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicatonProcess.May2020.Web.Infrastructure
{
    public static class MvcServiceConfiguration
    {
        public static IServiceCollection ConfigureMvc(this IServiceCollection services)
        {
            services.AddControllersWithViews(options => options.Filters.Add<ApiExceptionFilterAttribute>());

            return services;
        }
    }
}