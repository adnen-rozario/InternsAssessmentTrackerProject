using InternsAssessment.Entities.Entities;
using InternsAssessmentTracker.Entities.Repository;
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
        private readonly IRatingMasterRepository ratingMasterRepository;
        private readonly IProjectInternRepository projectInternRepository;
        private readonly IInternRepository internRepository;


        public RatingService(IInternRatingRepository internRatingRepository, IRatingMasterRepository ratingMasterRepository, IProjectInternRepository projectInternRepository, IInternRepository internRepository)
        {
            this.internRatingRepository = internRatingRepository;
            this.ratingMasterRepository = ratingMasterRepository;
            this.projectInternRepository = projectInternRepository;
            this.internRepository = internRepository;
        }

        public bool AddInternRating(InternRatingRequest request)
        {
            try
            {
                if (request.InternId != 0 && request.Rating.Any())
                {
                    var avgInternRating = (int)request.Rating.Average(x => x.RatingId);
                    foreach (var rate in request.Rating)
                    {
                        this.internRatingRepository.Create(new InternRating() { InternsId = request.InternId, RatingMasterId = rate.RatingId, TechnologiesId = rate.TechId, CreatedDate = DateTime.Now });

                    }

                    this.internRatingRepository.Save();

                    var updateItem = this.internRepository.FindByCondition(x => x.InternsId == request.InternId).FirstOrDefault();
                    updateItem.OverallRating = avgInternRating;
                    this.internRepository.Update(updateItem);

                    this.internRepository.Save();

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
                    //var response = this.internRatingRepository.FindByCondition(x => x.InternsId == request.InternId, "Interns,Technologies,Technologies.ProjectTechnologiesRelation,Technologies.ProjectTechnologiesRelation.Projects,Rating")
                    //     .ToList()
                    //     .Select(
                    //     x => new InternRatingResponse()
                    //     {
                    //         InternId = x.Interns.InternsId,
                    //         InternName = x.Interns?.Name,
                    //         //ProjectName = x.Interns?.ProjectInternRelation?.FirstOrDefault()?.Projects.Name,
                    //         ProjectName = x.Technologies.ProjectTechnologiesRelation.Select(y => y.Projects.Name).FirstOrDefault(),
                    //         TechId = x.TechnologiesId,
                    //         ProjectDescription = x.Technologies.ProjectTechnologiesRelation.Select(y => y.Projects.Description).FirstOrDefault(),

                    //         TechnologyName = x.Technologies?.Name,
                    //         TechnologyRating = x.Rating?.Rate
                    //     });

                    var response = this.projectInternRepository.FindByCondition(x => x.InternsId == request.InternId, "Interns,Projects,Projects.ProjectTechnologiesRelation,Projects.ProjectTechnologiesRelation.Technologies")
                        .ToList()
                        .Select(
                        x => new InternRatingResponse()
                        {
                            InternId = x.InternsId,
                            InternName = x.Interns.Name,
                            ProjectName = x.Projects.Name,
                            ProjectDescription = x.Projects.Description,
                            TechIds = x.Projects.ProjectTechnologiesRelation.Select(y => y.TechnologiesId).ToList(),
                            TechnologyNameList = x.Projects.ProjectTechnologiesRelation.Select(y => y.Technologies.Name).ToList()

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

        public IEnumerable<KeyValueResponse> GetRatings()
        {
            try
            {
                return this.ratingMasterRepository.FindAll()
                      .Select(x =>
                      new KeyValueResponse()
                      {
                          Key = x.RatingMasterId,
                          Value = x.Rate
                      });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
