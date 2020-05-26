using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hahn.ApplicatonProcess.May2020.Data;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using Hahn.ApplicatonProcess.May2020.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Applicant = Hahn.ApplicatonProcess.May2020.Data.Entities.Applicant;

namespace Hahn.ApplicatonProcess.May2020.Domain.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly ApplicantContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ApplicantService> _logger;

        public ApplicantService(ApplicantContext context, IMapper mapper, ILogger<ApplicantService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;

            _logger.LogInformation("############# APPLICANT SERVICE ##########3");
        }

        private async Task<Data.Entities.IApplicant> GetEntityById(int id)
        {
            if (id <= 0)
                throw new ArgumentException(nameof(id));
            var entity = await _context.Applicants.FirstOrDefaultAsync(a => a.Id == id);
            if (entity == null)
                throw new NotFoundException(typeof(Applicant), id);
            return entity;
        }

        public async Task<IList<IApplicant>> Get()
        {
            var entities = await _context.Applicants.ToListAsync();
            return _mapper.Map<IList<IApplicant>>(entities);
        }

        public async Task<IApplicant> Get(int id)
        {
            var entity = await GetEntityById(id);

            return _mapper.Map<IApplicant>(entity);
        }

        public async Task<IApplicant> Add(IApplicantPostRequest model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            var entityToAdd = _mapper.Map<Applicant>(model);
            await _context.AddAsync(entityToAdd);
            await _context.SaveChangesAsync();
            var result = await Get(entityToAdd.Id);

            return result;
        }

        public async Task Update(int id, IApplicant model)
        {
            var entityToUpdate = await GetEntityById(id);
            entityToUpdate = _mapper.Map(model, entityToUpdate);
            _context.Applicants.Update(entityToUpdate);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entityToDelete = await GetEntityById(id);
            _context.Applicants.Remove(entityToDelete);
            await _context.SaveChangesAsync();
        }
    }
}