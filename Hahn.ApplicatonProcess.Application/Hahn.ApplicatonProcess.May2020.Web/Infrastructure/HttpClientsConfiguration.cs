using System;
using Hahn.ApplicatonProcess.May2020.Domain.Services;
using Hahn.ApplicatonProcess.May2020.Infrastructure.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicatonProcess.May2020.Web.Infrastructure
{
    public static class HttpClientsConfiguration
    {
        public static void ConfigureCountriesApiHttpClient(this IServiceCollection services, IConfigurationSection configuration)
        {
            var countriesApiConfiguration = configuration.Get<CountriesApiConfiguration>();
            services.AddHttpClient<ICountryService, CountryService>(c => c.BaseAddress = new Uri(countriesApiConfiguration.BaseUrl));
        }
    }
}
