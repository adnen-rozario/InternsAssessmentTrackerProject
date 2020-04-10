using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public ICollection<InternRating> InternRating { get; set; }
        public ICollection<ProjectInternRelation> ProjectInternRelation { get; set; }

    }
}
