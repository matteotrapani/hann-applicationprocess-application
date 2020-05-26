using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Services
{
    public interface ICountryService
    {
        Task<bool> CheckIsAValidCountry(string countryOfOrigin, CancellationToken cancellationToken);
    }
}