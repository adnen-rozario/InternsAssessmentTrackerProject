using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessment.Entities.Entities
{
    public class InternRating
    {
        public int InternRatingId { get; set; }
        public int InternsId { get; set; }
        public Interns Interns { get; set; }
        public int TechnologiesId { get; set; }
        public Technologies Technologies { get; set; }
        public int RatingMasterId { get; set; }
        public RatingMaster Rating { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
