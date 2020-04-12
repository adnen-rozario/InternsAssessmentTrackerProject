using InternsAssessment.Entities.Entities;
using InternsAssessmentTracker.Entities.Repository.Interfaces;
using InternsAssessmentTracker.Models.Models;
using InternsAssessmentTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InternsAssessmentTracker.Services.Services
{
    public class RatingService : IRatingService
    {
        private readonly IInternRatingRepository internRatingRepository;

        public RatingService(IInternRatingRepository internRatingRepository)
        {
            this.internRatingRepository = internRatingRepository;
        }

        public bool AddInternRating(InternRatingRequest request)
        {
            try
            {
                if (request.InternId != 0 && request.Rating.Any())
                {
                    foreach (var rate in request.Rating)
                    {
                        this.internRatingRepository.Create(new InternRating() { InternsId = request.InternId, RatingMasterId = rate.RatingId, TechnologiesId = rate.TechId, CreatedDate = DateTime.Now });
                    }

                    this.internRatingRepository.Save();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<InternRatingResponse> GetInternRatings(InternRatingRequest request)
        {
            try
            {
                if (request.InternId != 0)
                {
                    var response = this.internRatingRepository.FindByCondition(x => x.InternsId == request.InternId, "Interns,Technologies,Technologies.ProjectTechnologiesRelation,Technologies.ProjectTechnologiesRelation.Projects,Rating")
                         .ToList()
                         .Select(
                         x => new InternRatingResponse()
                         {
                             InternId = x.Interns.InternsId,
                             InternName = x.Interns?.Name,
                             //ProjectName = x.Interns?.ProjectInternRelation?.FirstOrDefault()?.Projects.Name,
                             ProjectName = x.Technologies.ProjectTechnologiesRelation.Select(y => y.Projects.Name).FirstOrDefault(),
                             

                             TechnologyName = x.Technologies?.Name,
                             TechnologyRating = x.Rating?.Rate
                         });


                    return response;
                }

                return Enumerable.Empty<InternRatingResponse>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
