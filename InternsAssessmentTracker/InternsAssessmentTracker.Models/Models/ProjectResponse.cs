using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessmentTracker.Models.Models
{
    public class ProjectResponse
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string ProjectDescription { get; set; }

        public string ProjectTechnologies { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
