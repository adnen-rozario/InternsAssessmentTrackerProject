using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessment.Entities.Entities
{
   public class RatingMaster
    {
        public int RatingMasterId { get; set; }
        public string Rate { get; set; }
        public ICollection<InternRating> InternRating { get; set; }
    }
}
