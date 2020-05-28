using Hahn.ApplicatonProcess.May2020.Infrastructure.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicatonProcess.May2020.Web.Infrastructure
{
    public static class MvcServiceConfiguration
    {
        public static IMvcBuilder ConfigureMvc(this IServiceCollection services)
        {

          // Add framework services.
          return services.AddMvc(options => options.Filters.Add<ApiExceptionFilterAttribute>());
            // .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
    }
}
