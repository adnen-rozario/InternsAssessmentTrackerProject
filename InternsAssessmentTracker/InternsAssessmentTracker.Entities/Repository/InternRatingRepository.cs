using InternsAssessment.Entities.DataContext;
using InternsAssessment.Entities.Entities;
using InternsAssessment.Entities.Repository;
using InternsAssessmentTracker.Entities.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessmentTracker.Entities.Repository
{
    public class InternRatingRepository : Repository<InternRating>, IInternRatingRepository
    {
        public InternRatingRepository(IATrackerDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
