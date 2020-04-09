using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessment.Entities.Entities
{
    public class Project_TechnologiesRelation
    {
        public int Project_TechnologiesRelationId { get; set; }
        public int ProjectsId { get; set; }
        public Projects Projects { get; set; }
        public int TechnologiesId { get; set; }
        public Technologies Technologies { get; set; }
    }
}
