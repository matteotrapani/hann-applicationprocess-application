using FluentValidation.AspNetCore;
using Hahn.ApplicatonProcess.May2020.Infrastructure.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicatonProcess.May2020.Web.Infrastructure
{
    public static class MvcServiceConfiguration
    {
        public static IMvcBuilder ConfigureMvc(this IServiceCollection services)
        {
            return services.AddControllersWithViews(options => options.Filters.Add<ApiExceptionFilterAttribute>());
        }
    }
}