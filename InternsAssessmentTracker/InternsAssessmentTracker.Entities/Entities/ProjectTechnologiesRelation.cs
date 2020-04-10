using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessment.Entities.Entities
{
    public class ProjectTechnologiesRelation
    {
        public int ProjectTechnologiesRelationId { get; set; }
        public int ProjectsId { get; set; }
        public Projects Projects { get; set; }
        public int TechnologiesId { get; set; }
        public Technologies Technologies { get; set; }
    }
}
