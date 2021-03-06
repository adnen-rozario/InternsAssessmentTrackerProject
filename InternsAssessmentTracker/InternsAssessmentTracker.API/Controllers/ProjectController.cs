﻿using System;
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
    //[Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;
        private ILog logger;

        public ProjectController(IProjectService projectService, ILog logger)
        {
            this.projectService = projectService;
            this.logger = logger;
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
            catch (Exception ex)
            {
                this.logger.Error(ex);
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
            catch (Exception ex)
            {
                this.logger.Error(ex);

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
            catch (Exception ex)
            {
                this.logger.Error(ex);

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
            catch (Exception ex)
            {
                this.logger.Error(ex);

                throw;
            }
        }

        [HttpGet]
        [Route("api/Projectmentors")]

        public IActionResult GetMentorNames()
        {
            try
            {
                var response = projectService.GetMentorNames();

                if (response.Any())
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
            catch (Exception ex)
            {
                this.logger.Error(ex);

                throw;
            }
        }
    }
}