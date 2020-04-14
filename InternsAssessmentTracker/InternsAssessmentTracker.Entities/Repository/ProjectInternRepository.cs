using InternsAssessment.Entities.DataContext;
using InternsAssessment.Entities.Entities;
using InternsAssessment.Entities.Repository;
using InternsAssessmentTracker.Entities.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessmentTracker.Entities.Repository
{
    public class ProjectInternRepository : Repository<ProjectInternRelation>, IProjectInternRepository
    {
        public ProjectInternRepository(IATrackerDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
