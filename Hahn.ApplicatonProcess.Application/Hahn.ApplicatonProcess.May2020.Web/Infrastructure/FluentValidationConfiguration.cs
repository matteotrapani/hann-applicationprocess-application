using FluentValidation.AspNetCore;
using Hahn.ApplicatonProcess.May2020.Domain.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicatonProcess.May2020.Web.Infrastructure
{
    public static class FluentValidationConfiguration
    {
        public static IMvcBuilder ConfigureFluentValidation(this IMvcBuilder mvcBuilder)
        {
            return mvcBuilder.AddFluentValidation(c =>
                c.RegisterValidatorsFromAssemblyContaining<ApplicantValidator>());
        }
    }
}