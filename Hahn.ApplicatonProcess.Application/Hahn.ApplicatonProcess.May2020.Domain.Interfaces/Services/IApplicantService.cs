using System.Collections.Generic;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.May2020.Domain.Models;

namespace Hahn.ApplicatonProcess.May2020.Domain.Services
{
    public interface IApplicantService
    {
        public Task<IList<IApplicant>> Get();
        public Task<IApplicant> Get(int id);
        public Task<IApplicant> Add(IApplicantPostRequest model);
        public Task Update(int id, IApplicant model);
        public Task Delete(int id);
    }
}