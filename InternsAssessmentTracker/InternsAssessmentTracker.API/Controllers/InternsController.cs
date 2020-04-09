using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternsAssessmentTracker.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternsAssessmentTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternsController : ControllerBase
    {
        private readonly ImanageInterns manageInterns;

        public InternsController(ImanageInterns manageInterns)
        {
            this.manageInterns = manageInterns;
        }

        // GET: api/Interns
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Interns/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Interns
        [HttpPost]
        public void Post()
        {
            this.manageInterns.AddIntern();
        }

        // PUT: api/Interns/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
