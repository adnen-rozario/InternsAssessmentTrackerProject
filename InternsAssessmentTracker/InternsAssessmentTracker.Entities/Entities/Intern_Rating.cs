using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessment.Entities.Entities
{
    public class Intern_Rating
    {
        public int Intern_RatingId { get; set; }
        public int InternsId { get; set; }
        public Interns Interns { get; set; }
        public int TechnologiesId { get; set; }
        public Technologies Technologies { get; set; }
        public int Rating_MasterId { get; set; }
        public Rating_Master Rating { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
