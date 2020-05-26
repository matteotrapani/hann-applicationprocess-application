// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Hahn.ApplicatonProcess.May2020.Domain.Models;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Hahn.ApplicatonProcess.May2020.Web.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class ApplicantController : ControllerBase
//     {
//         // GET: api/<ApplicantController>
//         [HttpGet]
//         public Task<IEnumerable<IApplicant>> Get()
//         {
//             return new string[] { "value1", "value2" };
//         }
//
//         // GET api/<ApplicantController>/5
//         [HttpGet("{id}")]
//         public string Get(int id)
//         {
//             return "value";
//         }
//
//         // POST api/<ApplicantController>
//         [HttpPost]
//         public void Post([FromBody] string value)
//         {
//         }
//
//         // PUT api/<ApplicantController>/5
//         [HttpPut("{id}")]
//         public void Put(int id, [FromBody] string value)
//         {
//         }
//
//         // DELETE api/<ApplicantController>/5
//         [HttpDelete("{id}")]
//         public void Delete(int id)
//         {
//         }
//     }
// }
