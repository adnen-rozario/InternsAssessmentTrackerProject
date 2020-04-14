using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternsAssessmentTracker.API.Logging;
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
        private ILog logger;

        public InternController(IInternService internService, ILog logger)
        {
            this.internService = internService;
            this.logger = logger;
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
            catch (Exception ex)
            {
                logger.Error(ex);

                throw ex;
            }
        }

        // GET: api/Intern/5
        [HttpGet]
        [Route("api/Intern/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(internService.GetInternById(id));
            }
            catch (Exception ex)
            {
                logger.Error(ex);

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
            catch (Exception ex)
            {
                logger.Error(ex);

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
            catch (Exception ex)
            {
                logger.Error(ex);

                throw;
            }
        }

        // DELETE: api/Intern/5
        [HttpDelete]
        [Route("api/Intern/{id}")]

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
            catch (Exception ex)
            {
                this.logger.Error(ex);
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
            catch (Exception ex)
            {
                this.logger.Error(ex);

                throw;
            }
        }
    }
}
