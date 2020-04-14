using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternsAssessmentTracker.Models.Models;
using InternsAssessmentTracker.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternsAssessmentTracker.API.Controllers
{
    [ApiController]
    public class InternController : ControllerBase
    {
        private readonly IInternService internService;

        public InternController(IInternService internService)
        {
            this.internService = internService;
        }

        // GET: api/Intern
        [HttpGet]
        [Route("api/Intern")]
        public IActionResult Get()
        {
            try
            {
                return Ok(internService.GetIntern());
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Intern/5
        [HttpGet("{id}", Name = "Get")]
        [Route("api/Intern")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(internService.GetInternById(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: api/Intern
        [HttpPost]
        [Route("api/Intern")]
        public IActionResult Post(InternRequest requestIntern)
        {
            try
            {
                var response = internService.AddIntern(requestIntern);

                if (response == true)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/Intern/5
        [HttpPut("{id}")]
        [Route("api/Intern")]
        public IActionResult Put(int id, [FromBody] InternRequest requestIntern)
        {
            try
            {
                var response = internService.UpdateIntern(id, requestIntern);

                if (response == true)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE: api/Intern/5
        [HttpDelete("{id}")]
        [Route("api/Intern")]

        public IActionResult Delete(int id)
        {
            try
            {
                var response = internService.DeleteIntern(id);

                if (response == true)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("api/dashboard")]
        public IActionResult GetDashboardValues()
        {
            try
            {
                return Ok(internService.GetDashboardValues());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
