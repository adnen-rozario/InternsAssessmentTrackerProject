using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessment.Entities.Entities
{
    public class Technologies
    {
        public int TechnologiesId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<InternRating> Intern_Rating { get; set; }
        public ICollection<ProjectTechnologiesRelation> ProjectTechnologiesRelation { get; set; }

    }
}
