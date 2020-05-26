using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.May2020.Domain.Services;
using Hahn.ApplicatonProcess.May2020.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hahn.ApplicatonProcess.May2020.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _service;
        private readonly ILogger<ApplicantController> _logger;

        public ApplicantController(IApplicantService service, ILogger<ApplicantController> logger)
        {
            _service = service;
            _logger = logger;
        }
        // GET: api/<ApplicantController>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IList<Applicant>> Get()
        {
            return await _service.Get();
        }

        // GET api/<ApplicantController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<Applicant> Get(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            return await _service.Get(id);
        }

        // POST api/<ApplicantController>
        [HttpPost]
        [Produces("application/json")]
        public async Task<string> Post(ApplicantPostRequest model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            var result = await _service.Add(model);
            var objectUrl = this.Url.Action(nameof(Get), new {id = result.Id});
            return objectUrl;
        }

        // PUT api/<ApplicantController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, Applicant model)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            await _service.Update(id, model);
        }

        // DELETE api/<ApplicantController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            await _service.Delete(id);
        }
    }
}
