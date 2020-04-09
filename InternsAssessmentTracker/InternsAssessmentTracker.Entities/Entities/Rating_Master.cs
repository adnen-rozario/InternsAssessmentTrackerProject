using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessment.Entities.Entities
{
   public class Rating_Master
    {
        public int Rating_MasterId { get; set; }
        public string Rate { get; set; }
        public ICollection<Intern_Rating> Intern_Rating { get; set; }
    }
}
