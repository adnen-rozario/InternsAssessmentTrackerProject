using InternsAssessment.Entities.DataContext;
using InternsAssessment.Entities.Entities;
using InternsAssessment.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessmentTracker.Entities.Repository
{
    public class ProjectRepository : Repository<Projects>, IProjectRepository
    {
        public ProjectRepository(IATrackerDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
