using InternsAssessmentTracker.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessmentTracker.Services.Interfaces
{
    public interface IProjectService
    {
        bool AddProject(ProjectRequest requestProject);

        IEnumerable<KeyValueResponse> GetTechnologies();
    }
}
