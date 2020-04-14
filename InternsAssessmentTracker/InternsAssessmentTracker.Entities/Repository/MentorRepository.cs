using InternsAssessment.Entities.DataContext;
using InternsAssessment.Entities.Repository;
using InternsAssessmentTracker.Entities.Entities;
using InternsAssessmentTracker.Entities.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessmentTracker.Entities.Repository
{
    public class MentorRepository : Repository<Mentor>, IMentorRepository
    {
        public MentorRepository(IATrackerDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
