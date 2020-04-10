using InternsAssessment.Entities.DataContext;
using InternsAssessment.Entities.Entities;
using InternsAssessment.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessmentTracker.Entities.Repository
{
    public class InternRepository : Repository<Interns>, IInternRepository
    {
        public InternRepository(IATrackerDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
    
}
