using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessment.Entities.Entities
{
    public class Projects
    {
        public int ProjectsId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<Project_InternRelation> Project_InternRelation { get; set; }
        public ICollection<Project_TechnologiesRelation> Project_TechnologiesRelation { get; set; }

    }
}
