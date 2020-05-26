using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Services
{
    public class CountryService : ICountryService
    {
        private readonly HttpClient _httpClient;

        public CountryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> CheckIsAValidCountry(string countryOfOrigin, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync($"rest/v2/name/{countryOfOrigin}?fullText=true", cancellationToken);
            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}
