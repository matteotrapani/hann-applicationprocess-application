﻿using FluentValidation;
using Hahn.ApplicatonProcess.May2020.Domain.Services;
using Hahn.ApplicatonProcess.May2020.Infrastructure.Models;

namespace Hahn.ApplicatonProcess.May2020.Domain.Validators
{
    public class ApplicantPostRequestValidator : AbstractValidator<ApplicantPostRequest>
    {
        public ApplicantPostRequestValidator(ICountryService countryService)
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(5);
            RuleFor(x => x.FamilyName).NotNull().NotEmpty().MinimumLength(5);
            RuleFor(x => x.Address).NotNull().NotEmpty().MinimumLength(10);
            RuleFor(x => x.CountryOfOrigin).MustAsync(countryService.CheckIsAValidCountry).WithMessage(((applicant, country) => $"The country '{country}' does not exists"));
            RuleFor(x => x.EmailAddress).EmailAddress();
            RuleFor(x => x.Age).NotNull().GreaterThanOrEqualTo(20).LessThanOrEqualTo(60);
        }
    }
}