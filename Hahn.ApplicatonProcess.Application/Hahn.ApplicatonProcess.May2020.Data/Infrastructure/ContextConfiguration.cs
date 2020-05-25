using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicatonProcess.May2020.Data.Infrastructure
{
    public static class ContextConfiguration
    {
        public static IServiceCollection ConfigureApplicantContext(this IServiceCollection services)
        {
            return
                services.AddDbContext<ApplicantContext>(options => options.UseInMemoryDatabase(databaseName: "Applicants"));
        }
    }
}
