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
    [Route("api/[controller]")]
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
    }
}
