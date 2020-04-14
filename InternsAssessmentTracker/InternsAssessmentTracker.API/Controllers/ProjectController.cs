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
    //[Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpPost]
        [Route("api/Project")]

        public IActionResult Post(ProjectRequest request)
        {
            try
            {
                var response = projectService.AddProject(request);

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
        [Route("api/Project")]

        public IActionResult Get()
        {
            try
            {
                var response = projectService.GetProjects();

                if (response.Any())
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
        [Route("api/Technologies")]

        public IActionResult GetTechnologies()
        {
            try
            {
                var response = projectService.GetTechnologies();

                if (response.Any())
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
        [Route("api/Projectnames")]

        public IActionResult GetProjectNames()
        {
            try
            {
                var response = projectService.GetProjectNames();

                if (response.Any())
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

        [HttpPost]
        [Route("api/Projectassign")]

        public IActionResult AssignProjectToIntern(AssignProjectRequest request)
        {
            try
            {
                var response = projectService.AssignProjectToIntern(request);

                if (response)
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