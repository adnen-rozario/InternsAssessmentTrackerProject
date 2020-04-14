using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessmentTracker.Entities.Entities
{
    public class Mentor
    {
        public int MentorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<MentorProjectRelation> MentorProjectRelation { get; set; }

    }
}
