using InternsAssessment.Entities.DataContext;
using InternsAssessment.Entities.Repository;
using InternsAssessmentTracker.Entities.Entities;
using InternsAssessmentTracker.Entities.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessmentTracker.Entities.Repository
{
    public class MentorProjectRepository : Repository<MentorProjectRelation>, IMentorProjectRepository
    {
        public MentorProjectRepository(IATrackerDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
