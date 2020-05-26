using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hahn.ApplicatonProcess.May2020.Data;
using Hahn.ApplicatonProcess.May2020.Infrastructure.Exceptions;
using Hahn.ApplicatonProcess.May2020.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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

        private async Task<Data.Entities.Applicant> GetEntityById(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            var entity = await _context.Applicants.FirstOrDefaultAsync(a => a.Id == id);
            if (entity == null)
                throw new NotFoundException(typeof(Applicant), id);
            return entity;
        }

        public async Task<IList<Applicant>> Get()
        {
            var entities = await _context.Applicants.ToListAsync();
            return _mapper.Map<IList<Applicant>>(entities);
        }

        public async Task<Applicant> Get(int id)
        {
            var entity = await GetEntityById(id);

            return _mapper.Map<Applicant>(entity);
        }

        public async Task<Applicant> Add(ApplicantPostRequest model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            var entityToAdd = _mapper.Map<Data.Entities.Applicant>(model);
            await _context.AddAsync(entityToAdd);
            await _context.SaveChangesAsync();
            var result = await Get(entityToAdd.Id);

            return result;
        }

        public async Task Update(int id, Applicant model)
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