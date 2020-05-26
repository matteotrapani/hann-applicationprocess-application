﻿using Hahn.ApplicatonProcess.May2020.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.May2020.Data
{
    public class ApplicantContext : DbContext
    {
        public ApplicantContext(DbContextOptions<ApplicantContext> options) : base(options) {}

        public DbSet<Applicant> Applicants { get; set; }
    }
}