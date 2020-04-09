using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessment.Entities.Entities
{
   public class Interns
    {
        public int InternsId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<Intern_Rating> Intern_Rating { get; set; }
        public ICollection<Project_InternRelation> Project_InternRelation { get; set; }

    }
}
