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
    public class RatingController : ControllerBase
    {
        private readonly IRatingService ratingService;

        public RatingController(IRatingService ratingService)
        {
            this.ratingService = ratingService;
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
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("api/GetInternRating")]
        public IActionResult GetInternRating(InternRatingRequest request)
        {
            try
            {
                return Ok(ratingService.GetInternRatings(request));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}