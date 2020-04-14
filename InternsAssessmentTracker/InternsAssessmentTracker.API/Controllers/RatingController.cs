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
    //[Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService ratingService;
        private ILog logger;


        public RatingController(IRatingService ratingService, ILog logger)
        {
            this.ratingService = ratingService;
            this.logger = logger;
        }

        [HttpPost]
        [Route("api/Rating")]

        public IActionResult Post(InternRatingRequest request)
        {
            try
            {
                var response = ratingService.AddInternRating(request);

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

        [HttpPost]
        [Route("api/getinternrating")]
        public IActionResult GetInternRating(InternRatingRequest request)
        {
            try
            {
                return Ok(ratingService.GetInternRatings(request));
            }
            catch (Exception ex)
            {
                this.logger.Error(ex);

                throw;
            }
        }

        [HttpGet]
        [Route("api/getratings")]
        public IActionResult GetRatings()
        {
            try
            {
                return Ok(ratingService.GetRatings());
            }
            catch (Exception ex)
            {
                this.logger.Error(ex);

                throw;
            }
        }
    }
}