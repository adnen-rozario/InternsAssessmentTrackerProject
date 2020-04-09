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
        public ICollection<Intern_Rating> Intern_Rating { get; set; }
        public ICollection<Project_TechnologiesRelation> Project_TechnologiesRelation { get; set; }

    }
}
