using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.May2020.Domain.Services;
using Hahn.ApplicatonProcess.May2020.Infrastructure.Models;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<Applicant>>> Get()
        {
            var result = await _service.Get();
            return Ok(result);
        }

        // GET api/<ApplicantController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Applicant>> Get(int id)
        {
            var result = await _service.Get(id);
            return Ok(result);
        }

        // POST api/<ApplicantController>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> Post(ApplicantPostRequest model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            var result = await _service.Add(model);

            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
            // var objectUrl = this.Url.Action(nameof(Get), new {id = result.Id});
            // return Created(objectUrl);
        }

        // PUT api/<ApplicantController>/5
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(int id, Applicant model)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            await _service.Update(id, model);
            return NoContent();
        }

        // DELETE api/<ApplicantController>/5
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            await _service.Delete(id);
            return NoContent();
        }
    }
}
