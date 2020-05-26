using System.Collections.Generic;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.May2020.Infrastructure.Models;

namespace Hahn.ApplicatonProcess.May2020.Domain.Services
{
    public interface IApplicantService
    {
        public Task<IList<Applicant>> Get();
        public Task<Applicant> Get(int id);
        public Task<Applicant> Add(ApplicantPostRequest model);
        public Task Update(int id, Applicant model);
        public Task Delete(int id);
    }
}