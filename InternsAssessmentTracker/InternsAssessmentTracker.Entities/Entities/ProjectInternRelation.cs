using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessment.Entities.Entities
{
   public class ProjectInternRelation
    {
        public int ProjectInternRelationId { get; set; }
        public int ProjectsId { get; set; }
        public Projects Projects { get; set; }
        public int InternsId { get; set; }
        public Interns Interns { get; set; }
    }
}
