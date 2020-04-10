using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessment.Entities.Entities
{
    public class Projects
    {
        public int ProjectsId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<ProjectInternRelation> ProjectInternRelation { get; set; }
        public ICollection<ProjectTechnologiesRelation> ProjectTechnologiesRelation { get; set; }

    }
}
