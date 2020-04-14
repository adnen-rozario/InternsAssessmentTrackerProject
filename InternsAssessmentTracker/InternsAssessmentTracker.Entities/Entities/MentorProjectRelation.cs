using InternsAssessment.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessmentTracker.Entities.Entities
{
    public class MentorProjectRelation
    {
        public int MentorProjectRelationId { get; set; }

        public int MentorId { get; set; }
        public Mentor Mentor { get; set; }

        public int ProjectsId { get; set; }
        public Projects Projects { get; set; }
    }
}
