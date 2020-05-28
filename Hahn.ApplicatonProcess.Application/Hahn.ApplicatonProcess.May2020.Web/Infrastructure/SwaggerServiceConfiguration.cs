using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicatonProcess.May2020.Infrastructure
{
    public static class SwaggerServiceConfiguration
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Hahn Application Process API - May 2020", Version = "v1"});

                c.ExampleFilters();

                // c.OperationFilter<AddHeaderOperationFilter>("correlationId", "Correlation Id for the request", false); // adds any string you like to the request headers - in this case, a correlation id
                // c.OperationFilter<AddResponseHeadersFilter>(); // [SwaggerResponseHeader]

                // var filePath = Path.Combine(AppContext.BaseDirectory, "WebApi.xml");
                // c.IncludeXmlComments(
                //     filePath); // standard Swashbuckle functionality, this needs to be before c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>()

                // c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>(); // Adds "(Auth)" to the summary so that you can see which endpoints have Authorization
                // or use the generic method, e.g. c.OperationFilter<AppendAuthorizeToSummaryOperationFilter<MyCustomAttribute>>();

                // add Security information to each operation for OAuth2
                // c.OperationFilter<SecurityRequirementsOperationFilter>();
                // or use the generic method, e.g. c.OperationFilter<SecurityRequirementsOperationFilter<MyCustomAttribute>>();

                // if you're using the SecurityRequirementsOperationFilter, you also need to tell Swashbuckle you're using OAuth2
                // c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                // {
                //     Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                //     In = ParameterLocation.Header,
                //     Name = "Authorization",
                //     Type = SecuritySchemeType.ApiKey
                // });
            });
            return services;
        }
    }
}
