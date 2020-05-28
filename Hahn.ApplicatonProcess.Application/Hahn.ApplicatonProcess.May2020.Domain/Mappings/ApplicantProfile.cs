using Hahn.ApplicatonProcess.May2020.Infrastructure.Models;

namespace Hahn.ApplicatonProcess.May2020.Domain.Mappings
{
    public class ApplicantProfile : EntityModelProfile
    {
        public ApplicantProfile()
        {
            CreateMap<Infrastructure.Models.Applicant, Data.Entities.Applicant>()
                .ReverseMap();
            CreateMap<ApplicantPostRequest, Data.Entities.Applicant>();
        }
    }
}
